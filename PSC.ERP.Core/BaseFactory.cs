using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Data;

using System.Reflection;
using System.Linq.Expressions;
using System.Transactions;
using System.Text.RegularExpressions;
using System.Collections;
namespace PSC_ERP_Core
{
    public class BaseFactory<TObjectContext, TEntity>
        where TObjectContext : BaseObjectContext//ObjectContext
        where TEntity : EntityObject
    {
        public Boolean IsDirty
        {
            get { return Context.IsDirty; }
        }

        private TObjectContext _context = default(TObjectContext);
        public TObjectContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
                _objectSet = this.GetObjectSet();
            }
        }
        public Boolean LazyLoadingEnabled
        {
            get { return Context.ContextOptions.LazyLoadingEnabled; }
            set { Context.ContextOptions.LazyLoadingEnabled = value; }
        }
        private ObjectSet<TEntity> _objectSet = default(ObjectSet<TEntity>);
        public ObjectSet<TEntity> ObjectSet
        {
            get
            {
                if (_objectSet == null) _objectSet = this.GetObjectSet();
                return _objectSet;
            }
        }
        private String _entitySetName = String.Empty;
        public String EntitySetName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_entitySetName)) _entitySetName = this.GetEntitySetName();
                return _entitySetName;
            }
        }
        private String _entitySetFullName = String.Empty;
        public String EntitySetFullName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_entitySetFullName)) _entitySetFullName = this.GetEntitySetFullName();
                return _entitySetFullName;
            }
        }

        public virtual DateTime SystemDateTime
        {
            get
            {
                DateTime result = (from o in this.ObjectSet
                                   select DateTime.Now).FirstOrDefault();
                return result;
            }
        }
        public virtual DateTime SystemDate
        {
            get
            {
                DateTime result = (from o in this.ObjectSet
                                   select DateTime.Now).FirstOrDefault().Date;
                return result;
            }
        }

        private String _tableName = String.Empty;
        public virtual String TableName
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_tableName)) _tableName = this.GetTableName_Helper();
                return _tableName;
            }
        }

        private String _tableNameWithSchema = String.Empty;
        public virtual String TableNameWithSchema
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_tableNameWithSchema)) _tableNameWithSchema = this.GetTableNameWithSchema_Helper();
                return _tableNameWithSchema;
            }
        }

        public BaseFactory(TObjectContext context)
        {
            {
                _context = context;//DataAccess.Database.NewEntities();
                _entitySetName = this.GetEntitySetName();
                _entitySetFullName = this.GetEntitySetFullName();
                _objectSet = GetObjectSet();
            }
        }
        public static void DeleteHelper(IObjectSet<TEntity> objectSet, EntityCollection<TEntity> entityCollection)
        {


            List<Object> objectList = entityCollection.ToList<Object>();

            foreach (Object deleteObject in objectList)
                objectSet.DeleteObject(deleteObject as TEntity);



        }
        public static void DeleteHelper(TObjectContext context, EntityCollection<TEntity> entityCollection)
        {

            //List<Object> objectList = new List<Object>();
            //foreach (var obj in entityCollection)//
            //    objectList.Add(obj);

            List<Object> objectList = entityCollection.ToList<Object>();

            foreach (Object deleteObject in objectList)
                context.DeleteObject(deleteObject);


            //Int32 count = entityCollection.Count();
            //for (int i = 0; i < count; i++)
            //{
            //    Object entity = entityCollection.Skip(0).Take(1).Single();

            //    context.DeleteObject(entity);
            //}

        }
        public static void DeleteHelper(EntityCollection<TEntity> entityCollection)
        {

            if (entityCollection != null && entityCollection.Count<TEntity>() > 0)
            {
                TObjectContext context = (entityCollection.FirstOrDefault() as PSC_ERP_Core.BaseEntityObject).GetContext() as TObjectContext;

                DeleteHelper(context, entityCollection);
                //Int32 count = entityCollection.Count();
                //for (int i = 0; i < count; i++)
                //{
                //    Object entity = entityCollection.Skip(0).Take(1).Single();

                //    context.DeleteObject(entity);
                //}
            }
        }

        public static void DeleteHelper(TObjectContext context, List<Object> objectList)
        {
            foreach (Object deleteObject in objectList)
                context.DeleteObject(deleteObject);
        }
        public static void DeleteHelper(List<Object> objectList)
        {
            foreach (Object deleteObject in objectList)
            {
                BaseObjectContext context = (objectList[0] as PSC_ERP_Core.BaseEntityObject).GetContext();
                context.DeleteObject(deleteObject);
            }
        }
        public static void DeleteHelper(IQueryable<TEntity> list)
        {
            if (list != null && list.Count<TEntity>() > 0)
            {
                BaseObjectContext context = (list.FirstOrDefault() as PSC_ERP_Core.BaseEntityObject).GetContext();

                List<Object> objectList = list.ToList<Object>();

                foreach (Object deleteObject in objectList)
                    context.DeleteObject(deleteObject);

                //Int32 count = list.Count();
                //for (int i = 0; i < count; i++)
                //{
                //    TEntity entity = list.Skip(0).Take(1).Single();

                //    context.DeleteObject(entity);
                //}
            }
        }

        public void IDENTITY_INSERT_ON()
        {
            String tableName = GetTableNameWithSchema_Helper();
            Context.ExecuteStoreCommand(String.Format("SET IDENTITY_INSERT {0} ON", tableName));
        }

        public void IDENTITY_INSERT_OFF()
        {
            String tableName = GetTableNameWithSchema_Helper();
            Context.ExecuteStoreCommand(String.Format("SET IDENTITY_INSERT {0} OFF", tableName));
        }

        public void SetIdentify(Int64 index)
        {
            String tableName = GetTableNameWithSchema_Helper();
            //Context.ExecuteStoreCommand
            Context.ExecuteStoreCommand(String.Format("DBCC CHECKIDENT ('{0}', RESEED, {1})", tableName, index.ToString()));
        }
        private string GetTableNameWithSchema_Helper()
        {
            /*
            string sql = this.Context.CreateObjectSet<TEntity>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
             */
            string sql = this.ObjectSet.ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }
        private string GetTableName_Helper()
        {

            string sql = this.ObjectSet.ToTraceString();
            Regex regex = new Regex("FROM [(?<schema>.*)].[(?<table>.*)] AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }

        public virtual Boolean IsDirtyObjectInThisFactory(object entity)
        {
            Boolean result = false;
            ObjectStateEntry entry;
            if (this.Context.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
            {
                this.Context.DetectChanges();

                IEnumerable<string> changedNames = entry.GetModifiedProperties();

                result = (changedNames.Count<string>() > 0);
            }
            return result;
        }
        public virtual Boolean IsDirtyPropertyOfEntityObjectInThisFactory(object entity, string propertyName)
        {
            Boolean result = false;
            ObjectStateEntry entry;
            if (this.Context.ObjectStateManager.TryGetObjectStateEntry(entity, out entry))
            {
                this.Context.DetectChanges();

                IEnumerable<string> changedNames = entry.GetModifiedProperties();

                result = changedNames.Any(x => x == propertyName);
            }
            return result;
        }


        public virtual void Attach(TEntity entity)
        {
            this.ObjectSet.Attach(entity);
        }
        public virtual void Attach(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.ObjectSet.Attach(entity);
            }
        }
        public virtual void Attach(IQueryable<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.Attach(entity);
            }
        }
        public virtual void Attach(IQueryable<PSC_ERP_Core.BaseEntityObject> entityList)
        {
            foreach (var entity in entityList)
            {
                this.Context.Attach(entity);
            }
        }
        public virtual void Detach(TEntity entity)
        {
            this.ObjectSet.Detach(entity);
        }
        public virtual void Detach(List<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.ObjectSet.Detach(entity);
            }

        }
        public virtual void Detach(IQueryable<TEntity> entityList)
        {
            foreach (TEntity entity in entityList)
            {
                this.Detach(entity);
            }

        }

        public virtual void SaveChanges(String businessCode = null, int secondsTimeOut = 180)
        {
            Context.SaveChanges(secondsTimeOut, businessCode);
        }
        public virtual void SaveChangesWithoutTrackingLog(int secondsTimeOut = 3000)
        {
            Context.SaveChangesWithoutTrackingLog(secondsTimeOut);
        }


        //public virtual ParallelQuery<TEntity> GetAll()
        //{
        //    ParallelQuery<TEntity> query = from o in ObjectSet.AsParallel()
        //                                   select o;
        //    return query;
        //}
        public virtual IQueryable<TEntity> GetAll()
        {

            IQueryable<TEntity> query = from o in ObjectSet select o;
            return query;
        }
        public virtual ParallelQuery<TEntity> ParallelGetAll()
        {
            ParallelQuery<TEntity> query = from o in ObjectSet.AsParallel() select o;
            return query;
        }
        public virtual TEntity GetObjectBySingleKey(String key, Object value)
        {
            TEntity entity = default(TEntity);

            EntityKey entityKey = new EntityKey(EntitySetFullName, key, value);
            //try
            //{
            entity = (TEntity)Context.GetObjectByKey(entityKey);
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //}
            return entity;
        }
        ///
        //public virtual IQueryable<TEntity> GetListBySingleKey(String key, Object value)
        //{
        //    IQueryable<TEntity> list;

        //    EntityKey entityKey = new EntityKey(EntitySetFullName, key, value);
        //    try
        //    {

        //        list = from o in ObjectSet 
        //               where o.
        //               select o;//(TEntity)Context.GetObjectByKey(entityKey);
        //    }
        //    catch (Exception ex)
        //    {
        //        //throw ex;
        //    }
        //    return list;
        //}
        /// 
        public virtual TEntity GetObjectBySingleKey(KeyValuePair<string, object> entityKeyValue)
        {
            TEntity entity = default(TEntity);

            EntityKey key = new EntityKey(EntitySetFullName, entityKeyValue.Key, entityKeyValue.Value);
            //try
            //{
            entity = (TEntity)Context.GetObjectByKey(key);
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //}
            return entity;
        }
        public virtual TEntity GetObjectByMultiKey(IEnumerable<KeyValuePair<string, object>> entityKeyValues)
        {
            TEntity entity = default(TEntity);

            EntityKey key = new EntityKey(EntitySetFullName, entityKeyValues);
            //try
            //{
            entity = (TEntity)Context.GetObjectByKey(key);
            //}
            //catch (Exception ex)
            //{
            //    //throw ex;
            //}
            return entity;
        }

        public virtual TEntity CreateAloneObject()
        {
            TEntity obj = Context.CreateObject<TEntity>();

            return obj;
        }

        //public virtual T CreateAloneObject<T>() where T : EntityObject
        //{
        //    T obj = Context.CreateObject<T>();
        //    return obj;
        //}

        public virtual TEntity CreateManagedObject()
        {
            TEntity obj = Context.CreateObject<TEntity>();
            this.AddObject(obj);
            return obj;
        }


        public virtual void AddObject(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            else
                Context.AddObject(EntitySetFullName, entity);

        }


        //public virtual void AddObjectAndSaveChanges(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");
        //    else
        //    {
        //        Context.AddObject(EntitySetFullName, entity);
        //        this.SaveChanges();
        //    }

        //}

        public virtual void DeleteObject(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");
            else
                Context.DeleteObject(entity);
        }

        //public virtual void DeleteObject<T>(T entity) where T : EntityObject
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");
        //    else
        //        Context.DeleteObject(entity);
        //}

        //public virtual void DeleteObjectAndSaveChanges(TEntity entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");
        //    else
        //    {
        //        Context.DeleteObject(entity);
        //        this.SaveChanges();
        //    }
        //}

        public virtual void DeleteObjectList(IQueryable<TEntity> list)
        {

            //The method 'Skip' is only supported for sorted input in LINQ to Entities. The method 'OrderBy' must be called before the method 'Skip'.
            Int32 count = list.Count();
            for (int i = 0; i < count; i++)
            {
                TEntity entity = list.Skip(0).Take(1).Single();
                ObjectSet.DeleteObject(entity);
            }
        }
        public virtual void DeleteObjectList(List<TEntity> list)
        {
            if (list == null)
                throw new ArgumentNullException("list");
            else
                foreach (TEntity item in list)
                {
                    ObjectSet.DeleteObject(item);
                }
        }
        //public virtual void DeleteObjectListAndSaveChange(IQueryable<TEntity> list)
        //{
        //    this.DeleteObjectList(list);
        //    this.SaveChanges();
        //}
        //public virtual void DeleteObjectListAndSaveChange(List<TEntity> list)
        //{
        //    this.DeleteObjectList(list);
        //    this.SaveChanges();
        //}
        public virtual void DeleteAll()
        {


            /*cach 1
           
            List<TEntity> list = (from o in ObjectSet
                                        select o).ToList();
            int count = list.Count;
            for (int i = count - 1; i >= 0; i--)
            {
                TEntity entity = list[i];
                ObjectSet.DeleteObject(entity);
            } 
             */

            //cach 2


            IQueryable<TEntity> query = from o in ObjectSet
                                        //orderby 1//The method 'Skip' is only supported for sorted input in LINQ to Entities. The method 'OrderBy' must be called before the method 'Skip'.
                                        select o;

            int count = query.Count();
            for (int i = 0; i < count; i++)
            {
                TEntity entity = query.Skip(0).Take(1).Single();
                ObjectSet.DeleteObject(entity);
            }
        }

        //public virtual void DeleteAllAndSaveChanges()
        //{
        //    DeleteAll();
        //    SaveChanges();
        //}



        ///////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual TEntity SelectFirst()
        {

            TEntity query = (from o in ObjectSet
                             select o).First();
            return query;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public virtual TEntity SelectFirstOrDefault()
        {

            TEntity query = (from o in ObjectSet
                             select o).FirstOrDefault();
            return query;
        }
        public virtual TEntity SelectLast()
        {

            TEntity query = (from o in ObjectSet
                             select o).Last();
            return query;
        }
        public virtual TEntity SelectLastOrDefault()
        {

            TEntity query = (from o in ObjectSet
                             select o).LastOrDefault();
            return query;
        }

        public virtual IQueryable<TEntity> SelectTopN(int n)
        {

            IQueryable<TEntity> query = (from o in ObjectSet
                                         select o).Take(n);
            return query;
        }
        public virtual ParallelQuery<TEntity> ParallelSelectTopN(int n)
        {

            ParallelQuery<TEntity> query = (from o in ObjectSet.AsParallel()
                                            select o).Take(n);
            return query;
        }
        public virtual IQueryable<TEntity> SelectBottomN(int n)
        {
            ObjectSet<TEntity> objectSet = GetObjectSet();
            IQueryable<TEntity> query1 = from o in objectSet
                                         select o;
            int count = query1.Count();
            int skipIndex = count - n;

            if (skipIndex < 0) skipIndex = 0;

            IQueryable<TEntity> query2 = (from o in query1 orderby 1 select o).Skip(skipIndex).Take(n);
            return query2;
        }
        public virtual ParallelQuery<TEntity> ParallelSelectBottomN(int n)
        {
            ObjectSet<TEntity> objectSet = GetObjectSet();
            ParallelQuery<TEntity> query1 = from o in objectSet.AsParallel()
                                            select o;
            int count = query1.Count();
            int skipIndex = count - n;

            if (skipIndex < 0) skipIndex = 0;

            ParallelQuery<TEntity> query2 = (from o in query1 orderby 1 select o).Skip(skipIndex).Take(n);
            return query2;
        }
        public virtual IQueryable<TEntity> SelectSkipTake(int skipIndex, int takeCount)
        {
            ObjectSet<TEntity> objectSet = GetObjectSet();
            IQueryable<TEntity> query1 = from o in objectSet
                                         select o;
            if (skipIndex < 0) skipIndex = 0;
            IQueryable<TEntity> query2 = (from o in query1 orderby 1 select o).Skip(skipIndex).Take(takeCount);
            return query2;
        }
        public virtual ParallelQuery<TEntity> ParallelSelectSkipTake(int skipIndex, int takeCount)
        {
            ObjectSet<TEntity> objectSet = GetObjectSet();
            ParallelQuery<TEntity> query1 = from o in objectSet.AsParallel()
                                            select o;
            if (skipIndex < 0) skipIndex = 0;
            ParallelQuery<TEntity> query2 = (from o in query1 orderby 1 select o).Skip(skipIndex).Take(takeCount);
            return query2;
        }
        public virtual void Refresh(System.Data.Objects.RefreshMode refreshMode, IEnumerable collection)
        {
            this.Context.Refresh(refreshMode, collection);
        }
        public virtual void Refresh(System.Data.Objects.RefreshMode refreshMode, object entity)
        {
            this.Context.Refresh(refreshMode, entity);
        }
        public virtual void RefreshAll(System.Data.Objects.RefreshMode refreshMode)
        {
            this.Context.RefreshAll(refreshMode);
        }
        #region Helper
        private static PropertyInfo GetPublicInstancePropertyInfoInObjectContext<TObjectContext>(String propertyName)
        {
            Type type = typeof(TObjectContext);
            //Type type = Type.GetType(fullClassTypeName);
            PropertyInfo info = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            return info;
        }
        private ObjectSet<TEntity> GetObjectSet()
        {
            //String namespaceAndClassName = Context.ToString();

            PropertyInfo info = GetPublicInstancePropertyInfoInObjectContext<TObjectContext>(EntitySetName);
            ObjectSet<TEntity> objectSet = (ObjectSet<TEntity>)(info.GetValue(Context, null));
            //ObjectSet<TEntity> objectSet = this.Context.CreateObjectSet<TEntity>();
            return objectSet;
        }
        private string GetEntitySetName()
        {
            Type entityType = typeof(TEntity);

            string entityTypeName = entityType.Name;
            var container = Context.MetadataWorkspace.GetEntityContainer(Context.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return entitySetName;
        }
        private string GetEntitySetFullName()
        {
            Type entityType = typeof(TEntity);
            string entityTypeName = entityType.Name;
            var container = Context.MetadataWorkspace.GetEntityContainer(Context.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return container.Name + "." + entitySetName;
        }
        #endregion






        /*
         * 
         public T GetByPrimaryKey<T>(int id) where T : class
    {
        return (T)_db.GetObjectByKey(new EntityKey(_db.DefaultContainerName + "." + this.GetEntityName<T>(), GetPrimaryKeyInfo<T>().Name, id));
    }
        string GetEntityName<T>()
    {
            string name = typeof(T).Name;
            if (name.ToLower() == "person")
                return "People";
            else if (name.Substring(name.Length - 1, 1).ToLower() == "y")
                return name.Remove(name.Length - 1, 1) + "ies";
            else if (name.Substring(name.Length - 1, 1).ToLower() == "s")
                return name + "es";
            else
                return name + "s";
    }

    private PropertyInfo GetPrimaryKeyInfo<T>()
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (PropertyInfo pI in properties)
        {
            System.Object[] attributes = pI.GetCustomAttributes(true);
            foreach (object attribute in attributes)
            {
                if (attribute is EdmScalarPropertyAttribute)
                {
                    if ((attribute as EdmScalarPropertyAttribute).EntityKeyProperty == true)
                        return pI;
                }
                else if (attribute is ColumnAttribute)
                {

                    if ((attribute as ColumnAttribute).IsPrimaryKey == true)
                        return pI;
                }
            }
        }
        return null;
    } 
         * 
         */

    }
}
