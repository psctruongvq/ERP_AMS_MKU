using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data;
using System.Data.EntityClient;
using System.Reflection;
using System.Data.Metadata.Edm;
using PSC_ERP_TrackingLog;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Transactions;

namespace PSC_ERP_Core
{
    public class EntityTracking
    {
        public string BusinessCode { get; set; }
        public string Message { get; set; }
        public string EntityKeys { get; set; }
        public string CurrentPropertyValues { get; set; }
        public string OldPropertyValues { get; set; }
        public string NewPropertyValues { get; set; }
        public string LogType { get; set; }
        public string EntitySet { get; set; }//tuong ung voi bang du lieu
        public string ObjectSet { get; set; }
        public string UserNetworkIP { get; set; }
        public EntityTracking()
        {
            BusinessCode = null;
            Message = null;
            EntityKeys = null;
            CurrentPropertyValues = null;
            OldPropertyValues = null;
            NewPropertyValues = null;
            LogType = null;
            EntitySet = null;
            ObjectSet = null;
            UserNetworkIP = null;
        }
    }
    public class BaseObjectContext : System.Data.Objects.ObjectContext
    {
        //public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static int UserID
        {
            get;
            set;
        }

        public Boolean IsDirty
        {
            get { return CheckIsDirty_Helper(); }
        }

        static BaseObjectContext()
        {

        }
        public BaseObjectContext(System.Data.EntityClient.EntityConnection connection)
            : base(connection)
        {

        }
        public BaseObjectContext(string connectionString)
            : base(connectionString)
        {

        }
        protected BaseObjectContext(string connectionString, string defaultContainerName)
            : base(connectionString, defaultContainerName)
        {

        }
        protected BaseObjectContext(System.Data.EntityClient.EntityConnection connection, string defaultContainerName)
            : base(connection, defaultContainerName)
        {

        }

        public virtual void RefreshAll(System.Data.Objects.RefreshMode refreshMode)
        {
            // Get all objects in statemanager with entityKey 
            // (context.Refresh will throw an exception otherwise) 
            var refreshableObjects = (from entry in this.ObjectStateManager.GetObjectStateEntries(
                                                       EntityState.Added
                                                      | EntityState.Deleted
                                                      | EntityState.Modified
                                                      | EntityState.Unchanged)
                                      where entry.EntityKey != null
                                      select entry.Entity);

            this.Refresh(refreshMode, refreshableObjects);
        }
        //
        // Summary:
        //     Persists all updates to the data source and resets change tracking in the
        //     object context.
        //
        // Returns:
        //     The number of objects in an System.Data.EntityState.Added, System.Data.EntityState.Modified,
        //     or System.Data.EntityState.Deleted state when System.Data.Objects.ObjectContext.SaveChanges()
        //     was called.
        //
        // Exceptions:
        //   System.Data.OptimisticConcurrencyException:
        //     An optimistic concurrency violation has occurred in the data source.
        public new int SaveChanges(int secondsTimeOut = 180, String businessCode = null)//1
        {
            return SaveChanges_Helper(1, true, SaveOptions.None, secondsTimeOut, businessCode);
        }

        //
        // Summary:
        //     Persists all updates to the data source and optionally resets change tracking
        //     in the object context.
        //
        // Parameters:
        //   acceptChangesDuringSave:
        //     This parameter is needed for client-side transaction support. If true, the
        //     change tracking on all objects is reset after System.Data.Objects.ObjectContext.SaveChanges(System.Boolean)
        //     finishes. If false, you must call the System.Data.Objects.ObjectContext.AcceptAllChanges()
        //     method after System.Data.Objects.ObjectContext.SaveChanges(System.Boolean).
        //
        // Returns:
        //     The number of objects in an System.Data.EntityState.Added, System.Data.EntityState.Modified,
        //     or System.Data.EntityState.Deleted state when System.Data.Objects.ObjectContext.SaveChanges()
        //     was called.
        //
        // Exceptions:
        //   System.Data.OptimisticConcurrencyException:
        //     An optimistic concurrency violation has occurred.
        public new int SaveChanges(bool acceptChangesDuringSave, int secondsTimeOut = 180)//2
        {
            return SaveChanges_Helper(2, acceptChangesDuringSave, SaveOptions.None, secondsTimeOut);
        }


        //
        public int SaveChangesWithoutTrackingLog(int secondsTimeOut = 3000)//2
        {
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                   TimeSpan.FromSeconds(secondsTimeOut)))
            {
                int num = 0;
                num = base.SaveChanges();
                //hoàn tất giao tác
                transaction.Complete();
                return num;
            }
        }

        public int SaveChangesWithoutTrackingLog_AndTransactionScope()//2
        {
                int num = 0;
                num = base.SaveChanges();
                return num;
        }


        //
        // Summary:
        //     Persists all updates to the data source with the specified System.Data.Objects.SaveOptions.
        //
        // Parameters:
        //   options:
        //     A System.Data.Objects.SaveOptions value that determines the behavior of the
        //     operation.
        //
        // Returns:
        //     The number of objects in an System.Data.EntityState.Added, System.Data.EntityState.Modified,
        //     or System.Data.EntityState.Deleted state when System.Data.Objects.ObjectContext.SaveChanges()
        //     was called.
        //
        // Exceptions:
        //   System.Data.OptimisticConcurrencyException:
        //     An optimistic concurrency violation has occurred.
        //public new int SaveChanges(SaveOptions options)//3
        //{
        //    return SaveChanges_Helper(1, true, options);
        //}

        //#region PropertyInfo
        //private static PropertyInfo GetPropertyInfo(Type classType, String propertyName)
        //{
        //    PropertyInfo info = classType.GetProperty(propertyName);
        //    return info;
        //}
        //private static PropertyInfo[] GetPropertiesInfo(Type classType)
        //{
        //    PropertyInfo[] infos = classType.GetProperties();
        //    return infos;
        //}
        //private static PropertyInfo GetPropertyInfo(String fullClassTypeName, String propertyName)
        //{
        //    Type type = Type.GetType(fullClassTypeName);
        //    return GetPropertyInfo(type, propertyName);
        //}
        //private static PropertyInfo[] GetPropertiesInfo(String fullClassTypeName)
        //{
        //    Type type = Type.GetType(fullClassTypeName);
        //    return GetPropertiesInfo(type);
        //}
        //#endregion
        //#region GetPropertyValue
        //private static object GetPropertyValue(object objectToGet, string propertyName)
        //{
        //    Type objectType = objectToGet.GetType();
        //    PropertyInfo propertyInfo = objectType.GetProperty(propertyName);
        //    object propertyValue = null;
        //    if ((propertyInfo != null) && (propertyInfo.CanRead))
        //    {
        //        propertyValue = propertyInfo.GetValue(objectToGet, null);
        //    }
        //    return propertyValue;
        //}
        //private static TResult GetPropertyValue<TResult>(object objectToGet, string propertyName)
        //{
        //    Type objectType = objectToGet.GetType();
        //    PropertyInfo info = objectType.GetProperty(propertyName);
        //    object value = null;
        //    if ((info != null) && (info.CanRead))
        //    {
        //        value = info.GetValue(objectToGet, null);
        //    }
        //    return (TResult)value;
        //}
        //private static void SetProperty(object objectToSet, string propertyName, object propertyValue)
        //{
        //    Type objectType = objectToSet.GetType();
        //    PropertyInfo propertyInfo = objectType.GetProperty(propertyName);

        //    if ((propertyInfo != null) && (propertyInfo.CanWrite))
        //        propertyInfo.SetValue(objectToSet, propertyValue, null);
        //}
        //#endregion


        //private static PropertyInfo GetPublicInstancePropertyInfoInObjectContext<TObjectContext>(String propertyName)
        //{
        //    Type type = typeof(TObjectContext);
        //    //Type type = Type.GetType(fullClassTypeName);
        //    PropertyInfo info = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
        //    return info;
        //}

        public static string SerializeObjectToXmlString(object obj, System.Text.Encoding encoding)
        {
            try
            {
                String xmlizedString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(obj.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, encoding);

                xs.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                byte[] bytes = memoryStream.ToArray();
                xmlizedString = encoding.GetString(bytes, 0, bytes.Length);//ByteArrayUtil.BytesToString(memoryStream.ToArray(), encoding);
                return xmlizedString;
            }
            catch (Exception ex)
            {
            }

            return string.Empty;
        }

        private int SaveChanges_Helper(int saveType, bool acceptChangesDuringSave, SaveOptions options, int secondsTimeOut = 180, String businessCode = null)
        {
            int num = 0;
            using (TransactionScope transaction = new TransactionScope(TransactionScopeOption.Required,
                                    TimeSpan.FromSeconds(secondsTimeOut)))
            {



                String userNetworkIP = String.Empty;
                try
                {
                    userNetworkIP = PSC_ERP_Util.NetUtil.FindLanAddress().ToString();
                }
                catch
                {
                }

                PSC_ERP_TrackingLog.EntityTrackingTool TrackingLog = new PSC_ERP_TrackingLog.EntityTrackingTool(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


                Queue<EntityTracking> addedEntriesLog = new Queue<EntityTracking>();
                Queue<EntityTracking> modifiedEntriesLog = new Queue<EntityTracking>();
                Queue<EntityTracking> deletedEntriesLog = new Queue<EntityTracking>();

                //try
                {

                    IEnumerable<ObjectStateEntry> addedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
                    IEnumerable<ObjectStateEntry> modifiedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
                    IEnumerable<ObjectStateEntry> deletedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted);



                    //duyệt modifiedEntries lần 1/2 để lấy giá trị trước khi thay đổi
                    foreach (ObjectStateEntry entry in modifiedEntries)
                    {
                        //
                        String entityKeys = "";
                        String oldPropertyValues = "";
                        String newPropertyValues = "";

                        //ghép các keys và values của 1 entry
                        foreach (var item in entry.EntityKey.EntityKeyValues)
                        {
                            String oneKeyValue = String.Format("{0}={1}", item.Key, item.Value);
                            entityKeys += oneKeyValue + "; ";
                        }


                        newPropertyValues = SerializeObjectToXmlString(entry.Entity, Encoding.Unicode);
                        //gỡ bỏ 1 ký tự lạ đầu chuỗi
                        if (newPropertyValues.Substring(0, 1) != "<")
                            newPropertyValues = newPropertyValues.Remove(0, 1);
                        //
                        String copyXml = (String)(newPropertyValues.Clone());
                        ////gỡ bỏ 1 ký tự lạ đầu chuỗi
                        //if (copyXml.Substring(0, 1) != "<")
                        //    copyXml = copyXml.Remove(0, 1);

                        PSC_ERP_Util.XML.EasyXml oldValueXml = new PSC_ERP_Util.XML.EasyXml(copyXml);



                        //lấy danh sách tên property đã bị thay đổi giá trị
                        IEnumerable<string> modifiedProperties = entry.GetModifiedProperties();

                        //duyệt qua từng property name có giá trị bị thay đổi
                        foreach (var propertyName in modifiedProperties)
                        {
                            //đọc giá trị cũ
                            object oldValue = entry.OriginalValues[propertyName];
                            //đọc giá trị mới
                            object newValue = entry.CurrentValues[propertyName];
                            if (Object.Equals(oldValue,newValue) == false)//
                            {
                                //if (oldValue != newValue)
                                //{
                                //    String oneOldPropertyValue = String.Format("{0}={1}", propertyName, oldValue.ToString());
                                //    String oneNewPropertyValue = String.Format("{0}={1}", propertyName, oldValue.ToString());

                                //    //ghép chuỗi
                                //    oldPropertyValues += oneOldPropertyValue + "; ";
                                //    newPropertyValues += oneNewPropertyValue + "; ";
                                //}

                                //gán lại giá trị cũ cho các node của oldValueXml
                                {
                                    //tìm node
                                    XmlNode node = oldValueXml.SelectSingleNode("//" + propertyName);
                                    if (node == null)
                                        node = PSC_ERP_Util.XML.EasyXml.AppendElement(oldValueXml.Doc, propertyName);
                                    node.InnerText = oldValue.ToString();//thay bằng giá trị cũ
                                }
                            }

                        }

                        oldPropertyValues = oldValueXml.ToString();
                        if (oldPropertyValues.Equals(newPropertyValues) == false)//
                        {
                            //đưa vào danh sách cần ghi modified log
                            modifiedEntriesLog.Enqueue(new EntityTracking()
                            {
                                BusinessCode = businessCode,
                                Message = LogType.Modified.ToString(),
                                EntityKeys = entityKeys,
                                OldPropertyValues = oldPropertyValues,
                                NewPropertyValues = newPropertyValues,
                                LogType = LogType.Modified.ToString(),
                                EntitySet = entry.EntitySet.Name,
                                ObjectSet = entry.Entity.GetType().Name,
                                UserNetworkIP = userNetworkIP
                            });
                        }
                    }


                    //duyệt deletedEntries
                    foreach (ObjectStateEntry entry in deletedEntries)
                    {
                        String entityKeys = "";
                        String currentPropertyValues = "";


                        foreach (var item in entry.EntityKey.EntityKeyValues)
                        {
                            String oneKeyValue = String.Format("{0}={1}", item.Key, item.Value.ToString());
                            entityKeys += oneKeyValue + "; ";
                        }
                        //
                        /*tạm thời bỏ ra
                        System.Data.Common.DbDataRecord currentValues = entry.OriginalValues;
                        for (var i = 0; i < currentValues.FieldCount; i++)
                        {
                            var propertyName = currentValues.GetName(i);
                            var currentValue = currentValues[i];
                            String oneCurrentPropertyValue = String.Format("{0}={1}", propertyName, currentValue.ToString());
                            currentPropertyValues += oneCurrentPropertyValue + "; ";
                        }
                         */
                        //tạm thời sử dụng dòng dưới đây
                        currentPropertyValues = SerializeObjectToXmlString(entry.Entity, Encoding.Unicode);
                        ////
                        deletedEntriesLog.Enqueue(new EntityTracking()
                        {
                            BusinessCode = businessCode,
                            Message = LogType.Deleted.ToString(),
                            EntityKeys = entityKeys,
                            CurrentPropertyValues = currentPropertyValues,
                            LogType = LogType.Deleted.ToString(),
                            EntitySet = entry.EntitySet.Name,
                            ObjectSet = entry.Entity.GetType().Name,
                            UserNetworkIP = userNetworkIP
                        });
                    }


                    //lưu thay đổi
                    if (saveType == 1)
                        num = base.SaveChanges();
                    else if (saveType == 2)
                        num = base.SaveChanges(acceptChangesDuringSave: acceptChangesDuringSave);
                    else if (saveType == 3)
                        num = base.SaveChanges(options);  //This persists the object to the DB.  After this call, if it's successful, it will process the item.


                    //duyệt addedEntries
                    foreach (ObjectStateEntry entry in addedEntries)
                    {
                        String entityKeys = "";
                        String currentPropertyValues = "";

                        //lay du lieu chua save
                        //////////// Access CSDL
                        //////////var container = this.MetadataWorkspace
                        //////////                       .GetEntityContainer(this.DefaultContainerName, DataSpace.CSpace);
                        //////////// Access name of related set exposed on your context
                        //////////var set = container.BaseEntitySets[entry.EntitySet.Name];
                        //////////// Access all properties
                        //////////var properties = set.ElementType.Members.Select(m => m.Name).ToList();
                        //////////// Access only keys
                        //////////var keys = set.ElementType.KeyMembers.Select(m => m.Name).ToList();

                        ////////////ghép các keys và values của 1 entry
                        //////////foreach (var keyName in keys)
                        //////////{
                        //////////    Object keyValue = entry.CurrentValues[keyName];
                        //////////    String oneKeyValue = String.Format("{0}={1}", keyName,keyValue.ToString());
                        //////////    entityKeys += oneKeyValue + ";";
                        //////////}


                        foreach (var item in entry.EntityKey.EntityKeyValues)
                        {
                            String oneKeyValue = String.Format("{0}={1}", item.Key, item.Value.ToString());
                            entityKeys += oneKeyValue + "; ";
                        }
                        // 
                        /*tạm thời bỏ ra
                        var currentValues = entry.CurrentValues;
                        for (var i = 0; i < currentValues.FieldCount; i++)
                        {
                            var propertyName = currentValues.DataRecordInfo.FieldMetadata[i].FieldType.Name;
                            var currentValue = currentValues[i];
                            String oneCurrentPropertyValue = String.Format("{0}={1}", propertyName, currentValue.ToString());
                            currentPropertyValues += oneCurrentPropertyValue + "; ";
                        }
                        */
                        //tạm thời sử dụng dòng dưới đây
                        currentPropertyValues = SerializeObjectToXmlString(entry.Entity, Encoding.Unicode);
                        ////
                        addedEntriesLog.Enqueue(new EntityTracking()
                        {
                            BusinessCode = businessCode,
                            Message = LogType.Added.ToString(),
                            EntityKeys = entityKeys,
                            CurrentPropertyValues = currentPropertyValues,
                            LogType = LogType.Added.ToString(),
                            EntitySet = entry.EntitySet.Name,
                            ObjectSet = entry.Entity.GetType().Name,
                            UserNetworkIP = userNetworkIP
                        });
                    }

                    //qua trinh ghi log
                    //
                    #region Ghi log
                    foreach (var item in addedEntriesLog)
                    {
                        //write added log
                        WriteTracking(TrackingLog, item);
                    }
                    foreach (var item in modifiedEntriesLog)
                    {
                        //write modified log
                        WriteTracking(TrackingLog, item);
                    }
                    foreach (var item in deletedEntriesLog)
                    {
                        //write deleted log
                        WriteTracking(TrackingLog, item);
                    }
                    #endregion
                    ////Fire events for changed objects.
                    //foreach (ObjectStateEntry entry in addedEntries)
                    //    SavedChages(entry, EntityState.Added);
                    //foreach (ObjectStateEntry entry in modifiedEntries)
                    //    SavedChages(entry, EntityState.Modified);
                    //foreach (ObjectStateEntry entry in deletedEntries)
                    //    SavedChages(entry, EntityState.Deleted);

                }
                //catch (OptimisticConcurrencyException e)
                //{
                //    Console.WriteLine("OptimisticConcurrencyException " + e
                //    + " handled and changes saved");
                //}

                //hoàn tất giao tác
                transaction.Complete();
            }
            return num;
        }

        private static void WriteTracking(EntityTrackingTool TrackingLog, EntityTracking item)
        {
            TrackingLog.EntityTracking(item.BusinessCode, item.Message, UserID, item.EntityKeys, item.CurrentPropertyValues, item.OldPropertyValues, item.NewPropertyValues, item.LogType, item.EntitySet, item.ObjectSet, item.UserNetworkIP);


        }

        private bool CheckIsDirty_Helper()
        {

            IEnumerable<ObjectStateEntry> addedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Added);
            if (addedEntries.Any())
                return true;
            IEnumerable<ObjectStateEntry> deletedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Deleted);
            if (deletedEntries.Any())
                return true;
            IEnumerable<ObjectStateEntry> modifiedEntries = base.ObjectStateManager.GetObjectStateEntries(EntityState.Modified);
            //duyệt modifiedEntries lần 1/2 để lấy giá trị trước khi thay đổi
            foreach (ObjectStateEntry entry in modifiedEntries)
            {
                //lấy danh sách tên property đã bị thay đổi giá trị
                IEnumerable<string> modifiedProperties = entry.GetModifiedProperties();
                //duyệt qua từng property name có giá trị bị thay đổi
                foreach (var propertyName in modifiedProperties)
                {
                    //đọc giá trị cũ
                    object oldValue = entry.OriginalValues[propertyName];
                    //đọc giá trị mới
                    object newValue = entry.CurrentValues[propertyName];

                    if (Object.Equals(oldValue, newValue) == false)//
                    {
                        return true;
                    }

                }//end foreach
            }
            return false;
        }//end fn
    }
}
