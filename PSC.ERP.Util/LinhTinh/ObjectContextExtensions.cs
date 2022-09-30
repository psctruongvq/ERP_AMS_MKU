using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;
using System.Data.Metadata.Edm;
using System.Data.Objects;
using System.Data;

namespace PSC_ERP_Util.ObjectContextExtensions
{


    public static class ObjectContextExtensions
    {
        public static string PSC_GetEntitySetName(this ObjectContext context, Type entityType)
        {
            if (entityType == null)
                throw new ArgumentNullException("entityType");

            if (!entityType.IsSubclassOf(typeof(EntityObject)))
                throw new ArgumentException("Only subclasses of EntityObject are supported.", "entityType");

            return context.PSC_GetEntitySetNameInternal(entityType);
        }
        public static string PSC_GetEntitySetName<TEntity>(this ObjectContext context) where TEntity : EntityObject
        {
            var entityType = typeof(TEntity);
            return context.PSC_GetEntitySetNameInternal(entityType);
        }

        public static string PSC_GetEntitySetFullName(this ObjectContext context, EntityObject entity)
        {
            // If the EntityKey exists, simply get the Entity Set name from the key
            if (entity.EntityKey != null)
            {
                return entity.EntityKey.EntitySetName;
            }
            else
            {
                string entityTypeName = entity.GetType().Name;
                var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
                string entitySetName = (from meta in container.BaseEntitySets
                                        where meta.ElementType.Name == entityTypeName
                                        select meta.Name).First();

                return String.Format("{0}.{1}", container.Name, entitySetName);
            }
        }
        public static string PSC_GetEntitySetFullName<TEntity>(this ObjectContext context) where TEntity : EntityObject
        {
            Type entityType = typeof(TEntity);
            string entityTypeName = entityType.Name;
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return String.Format("{0}.{1}", container.Name, entitySetName);
        }

        private static string PSC_GetEntitySetNameInternal(this ObjectContext context, Type entityType)
        {
            //Type entityType = typeof(TEntity);
            string entityTypeName = entityType.Name;
            var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            string entitySetName = (from meta in container.BaseEntitySets
                                    where meta.ElementType.Name == entityTypeName
                                    select meta.Name).First();

            return entitySetName;

            //string entitySetName;
            //IDictionary<Type, string> EntitySetNames = new Dictionary<Type, string>();
            //if (!EntitySetNames.TryGetValue(entityType, out entitySetName))
            //{
            //    while (entityType.BaseType != typeof(EntityObject))
            //        entityType = entityType.BaseType;

            //    var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
            //    var entitySet = container.BaseEntitySets.SingleOrDefault(e => e.ElementType.Name == entityType.Name);

            //    entitySetName = entitySet.Name;
            //    EntitySetNames.Add(entityType, entitySetName);
            //}

            //return entitySetName;
        }
        public static TEntity PSC_ApplyCurrentValues<TEntity>(this ObjectContext context, TEntity entity)
            where TEntity : EntityObject
        {
            return
                context.ApplyCurrentValues<TEntity>
                    (context.PSC_GetEntitySetFullName<TEntity>(), entity);
        }
        public static void PSC_AddObject<TEntity>(this ObjectContext context, TEntity entity)
           where TEntity : EntityObject
        {
            if (entity == null) throw new ArgumentNullException("entity");
            context.AddObject(context.PSC_GetEntitySetFullName<TEntity>(), entity);

        }
        //public void AddObject<TEntity>(TEntity entity) where TEntity : EntityObject
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");

        //    if (entity.EntityState != EntityState.Detached)
        //        ObjectStateManager.ChangeObjectState(entity, EntityState.Added);
        //    else
        //    {
        //        var entitySetName = GetEntitySetName<TEntity>();
        //        AddObject(entitySetName, entity);
        //    }
        //}
        public static void PSC_DeleteObject(this ObjectContext context, EntityObject entity)
        {
            if ((entity.EntityState != EntityState.Detached))
            {
                context.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            }
            else
            {
                context.Attach(entity);
                context.DeleteObject((object)entity);
            }
        }
        public static void PSC_UpdateObject<TEntity>(this ObjectContext context, TEntity entity) where TEntity : EntityObject
        {
            if (entity == null) throw new ArgumentNullException("entity");

            var entitySetName = context.PSC_GetEntitySetName(entity.GetType());
            if (entity.EntityState == EntityState.Detached)
                context.AttachTo(entitySetName, entity);
            context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        }
    }
    //public class Util
    //{

        //#region Get entity set name






        //private IDictionary<Type, string> _EntitySetNames;
        //public IDictionary<Type, string> EntitySetNames
        //{
        //    get
        //    {
        //        return _EntitySetNames ?? (_EntitySetNames = new Dictionary<Type, string>());
        //    }
        //}
        //#endregion



        //public void UpdateObject<TEntity>(TEntity current, TEntity original) where TEntity : EntityObject
        //{
        //    if (current == null) throw new ArgumentNullException("current");
        //    if (original == null) throw new ArgumentNullException("original");

        //    string entitySetName = GetEntitySetName(current.GetType());

        //    if (current.EntityState == EntityState.Detached)
        //        AttachTo(entitySetName, current);
        //    else
        //        ObjectStateManager.ChangeObjectState(current, EntityState.Modified);

        //    ObjectStateEntry objectStateEntry = ObjectStateManager.GetObjectStateEntry(current);
        //    objectStateEntry.ApplyOriginalValues(original);

        //    Type entityType = typeof(TEntity);

        //    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);
        //    bool roundtripOriginal = TypeDescriptor.GetAttributes(entityType)[typeof(RoundtripOriginalAttribute)] != null;

        //    foreach (FieldMetadata metadata in objectStateEntry.CurrentValues.DataRecordInfo.FieldMetadata)
        //    {
        //        string name = objectStateEntry.CurrentValues.GetName(metadata.Ordinal);
        //        PropertyDescriptor descriptor = properties[name];

        //        if
        //          (
        //            !roundtripOriginal &&
        //            descriptor != null &&
        //            descriptor.Attributes[typeof(RoundtripOriginalAttribute)] == null &&
        //            descriptor.Attributes[typeof(ExcludeAttribute)] == null
        //          )
        //            objectStateEntry.SetModifiedProperty(name);
        //    }

        //    if (objectStateEntry.State != EntityState.Modified)
        //        ObjectStateManager.ChangeObjectState(current, EntityState.Modified);
        //}

        //public void UpdateObject<TEntity>(TEntity entity) where TEntity : EntityObject
        //{
        //    if (entity == null) throw new ArgumentNullException("entity");

        //    var entitySetName = GetEntitySetName(entity.GetType());
        //    if (entity.EntityState == EntityState.Detached)
        //        AttachTo(entitySetName, entity);
        //    ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
        //}


    //}
}
