//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
//	  Code duoc tao boi DESKTOP-J5VELTF\DELL luc 10:47:31 ngay 24/12/2021
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.EntityClient;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace PSC_ERP_Business.Main.Model
{
    
    /// <summary>
    /// No Metadata Documentation available.
    /// </summary>
    [EdmEntityTypeAttribute(NamespaceName="PSC_ERPModel", Name="EntityTrackingLog")]
    [Serializable()]
    [DataContractAttribute(IsReference=true)]
    public partial class EntityTrackingLog : PSC_ERP_Core.BaseEntityObject//EntityObject
    {
    	public EntityTrackingLog()
    	{
    
    	}
        #region Factory Method
    
        /// <summary>
        /// Create a new EntityTrackingLog object.
        /// </summary>
        /// <param name="id">Initial value of the ID property.</param>
        /// <param name="logDate">Initial value of the LogDate property.</param>
        /// <param name="thread">Initial value of the Thread property.</param>
        /// <param name="level">Initial value of the Level property.</param>
        /// <param name="logger">Initial value of the Logger property.</param>
        /// <param name="message">Initial value of the Message property.</param>
        public static EntityTrackingLog CreateEntityTrackingLog(long id, System.DateTime logDate, string thread, string level, string logger, string message)
        {
            EntityTrackingLog entityTrackingLog = new EntityTrackingLog();
            entityTrackingLog.ID = id;
            entityTrackingLog.LogDate = logDate;
            entityTrackingLog.Thread = thread;
            entityTrackingLog.Level = level;
            entityTrackingLog.Logger = logger;
            entityTrackingLog.Message = message;
            return entityTrackingLog;
        }

        #endregion

        #region Primitive Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=true, IsNullable=false)]
        [DataMemberAttribute()]
        public long ID
        {
            get
            {
                return _iD;
            }
            set
            {
                if (_iD != value)
                {
        			long oldValue =  _iD;
        			bool stopChanging = false;
                    On_ID_Changing(oldValue, ref value, ref stopChanging);
                    ReportPropertyChanging("ID");
        			if(!stopChanging)
        			{
        				_iD = StructuralObject.SetValidValue(value);
        				ReportPropertyChanged("ID");
        				On_ID_Changed(oldValue, _iD);//\\
        			}
                }
            }
        }
    	public static String ID_PropertyName { get { return "ID"; } }
        private long _iD;
        partial void On_ID_Changing(long currentValue, ref long newValue, ref bool stopChanging);
        partial void On_ID_Changed(long oldValue, long currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string EntityKeys
        {
            get
            {
                return _entityKeys;
            }
            set
            {
    			string oldValue =  _entityKeys;
    			bool stopChanging = false;
                On_EntityKeys_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("EntityKeys");
    			if(!stopChanging)
    			{
    				_entityKeys = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("EntityKeys");
    				On_EntityKeys_Changed(oldValue, _entityKeys);//\\
    			}
            }
        }
    	public static String EntityKeys_PropertyName { get { return "EntityKeys"; } }
        private string _entityKeys;
        partial void On_EntityKeys_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_EntityKeys_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string CurrentPropertyValues
        {
            get
            {
                return _currentPropertyValues;
            }
            set
            {
    			string oldValue =  _currentPropertyValues;
    			bool stopChanging = false;
                On_CurrentPropertyValues_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("CurrentPropertyValues");
    			if(!stopChanging)
    			{
    				_currentPropertyValues = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("CurrentPropertyValues");
    				On_CurrentPropertyValues_Changed(oldValue, _currentPropertyValues);//\\
    			}
            }
        }
    	public static String CurrentPropertyValues_PropertyName { get { return "CurrentPropertyValues"; } }
        private string _currentPropertyValues;
        partial void On_CurrentPropertyValues_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_CurrentPropertyValues_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string OldPropertyValues
        {
            get
            {
                return _oldPropertyValues;
            }
            set
            {
    			string oldValue =  _oldPropertyValues;
    			bool stopChanging = false;
                On_OldPropertyValues_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("OldPropertyValues");
    			if(!stopChanging)
    			{
    				_oldPropertyValues = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("OldPropertyValues");
    				On_OldPropertyValues_Changed(oldValue, _oldPropertyValues);//\\
    			}
            }
        }
    	public static String OldPropertyValues_PropertyName { get { return "OldPropertyValues"; } }
        private string _oldPropertyValues;
        partial void On_OldPropertyValues_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_OldPropertyValues_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string NewPropertyValues
        {
            get
            {
                return _newPropertyValues;
            }
            set
            {
    			string oldValue =  _newPropertyValues;
    			bool stopChanging = false;
                On_NewPropertyValues_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NewPropertyValues");
    			if(!stopChanging)
    			{
    				_newPropertyValues = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("NewPropertyValues");
    				On_NewPropertyValues_Changed(oldValue, _newPropertyValues);//\\
    			}
            }
        }
    	public static String NewPropertyValues_PropertyName { get { return "NewPropertyValues"; } }
        private string _newPropertyValues;
        partial void On_NewPropertyValues_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_NewPropertyValues_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public Nullable<int> UserID
        {
            get
            {
                return _userID;
            }
            set
            {
    			Nullable<int> oldValue =  _userID;
    			bool stopChanging = false;
                On_UserID_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserID");
    			if(!stopChanging)
    			{
    				_userID = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("UserID");
    				On_UserID_Changed(oldValue, _userID);//\\
    			}
            }
        }
    	public static String UserID_PropertyName { get { return "UserID"; } }
        private Nullable<int> _userID;
        partial void On_UserID_Changing(Nullable<int> currentValue, ref Nullable<int> newValue, ref bool stopChanging);
        partial void On_UserID_Changed(Nullable<int> oldValue, Nullable<int> currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public System.DateTime LogDate
        {
            get
            {
                return _logDate;
            }
            set
            {
    			System.DateTime oldValue =  _logDate;
    			bool stopChanging = false;
                On_LogDate_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LogDate");
    			if(!stopChanging)
    			{
    				_logDate = StructuralObject.SetValidValue(value);
    				ReportPropertyChanged("LogDate");
    				On_LogDate_Changed(oldValue, _logDate);//\\
    			}
            }
        }
    	public static String LogDate_PropertyName { get { return "LogDate"; } }
        private System.DateTime _logDate;
        partial void On_LogDate_Changing(System.DateTime currentValue, ref System.DateTime newValue, ref bool stopChanging);
        partial void On_LogDate_Changed(System.DateTime oldValue, System.DateTime currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string Thread
        {
            get
            {
                return _thread;
            }
            set
            {
    			string oldValue =  _thread;
    			bool stopChanging = false;
                On_Thread_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Thread");
    			if(!stopChanging)
    			{
    				_thread = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("Thread");
    				On_Thread_Changed(oldValue, _thread);//\\
    			}
            }
        }
    	public static String Thread_PropertyName { get { return "Thread"; } }
        private string _thread;
        partial void On_Thread_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Thread_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string Level
        {
            get
            {
                return _level;
            }
            set
            {
    			string oldValue =  _level;
    			bool stopChanging = false;
                On_Level_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Level");
    			if(!stopChanging)
    			{
    				_level = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("Level");
    				On_Level_Changed(oldValue, _level);//\\
    			}
            }
        }
    	public static String Level_PropertyName { get { return "Level"; } }
        private string _level;
        partial void On_Level_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Level_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string Logger
        {
            get
            {
                return _logger;
            }
            set
            {
    			string oldValue =  _logger;
    			bool stopChanging = false;
                On_Logger_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Logger");
    			if(!stopChanging)
    			{
    				_logger = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("Logger");
    				On_Logger_Changed(oldValue, _logger);//\\
    			}
            }
        }
    	public static String Logger_PropertyName { get { return "Logger"; } }
        private string _logger;
        partial void On_Logger_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Logger_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=false)]
        [DataMemberAttribute()]
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
    			string oldValue =  _message;
    			bool stopChanging = false;
                On_Message_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Message");
    			if(!stopChanging)
    			{
    				_message = StructuralObject.SetValidValue(value, false);
    				ReportPropertyChanged("Message");
    				On_Message_Changed(oldValue, _message);//\\
    			}
            }
        }
    	public static String Message_PropertyName { get { return "Message"; } }
        private string _message;
        partial void On_Message_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Message_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string Method
        {
            get
            {
                return _method;
            }
            set
            {
    			string oldValue =  _method;
    			bool stopChanging = false;
                On_Method_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("Method");
    			if(!stopChanging)
    			{
    				_method = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("Method");
    				On_Method_Changed(oldValue, _method);//\\
    			}
            }
        }
    	public static String Method_PropertyName { get { return "Method"; } }
        private string _method;
        partial void On_Method_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_Method_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string ComputerUser
        {
            get
            {
                return _computerUser;
            }
            set
            {
    			string oldValue =  _computerUser;
    			bool stopChanging = false;
                On_ComputerUser_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ComputerUser");
    			if(!stopChanging)
    			{
    				_computerUser = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("ComputerUser");
    				On_ComputerUser_Changed(oldValue, _computerUser);//\\
    			}
            }
        }
    	public static String ComputerUser_PropertyName { get { return "ComputerUser"; } }
        private string _computerUser;
        partial void On_ComputerUser_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_ComputerUser_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string LogType
        {
            get
            {
                return _logType;
            }
            set
            {
    			string oldValue =  _logType;
    			bool stopChanging = false;
                On_LogType_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("LogType");
    			if(!stopChanging)
    			{
    				_logType = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("LogType");
    				On_LogType_Changed(oldValue, _logType);//\\
    			}
            }
        }
    	public static String LogType_PropertyName { get { return "LogType"; } }
        private string _logType;
        partial void On_LogType_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_LogType_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string EntitySet
        {
            get
            {
                return _entitySet;
            }
            set
            {
    			string oldValue =  _entitySet;
    			bool stopChanging = false;
                On_EntitySet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("EntitySet");
    			if(!stopChanging)
    			{
    				_entitySet = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("EntitySet");
    				On_EntitySet_Changed(oldValue, _entitySet);//\\
    			}
            }
        }
    	public static String EntitySet_PropertyName { get { return "EntitySet"; } }
        private string _entitySet;
        partial void On_EntitySet_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_EntitySet_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string ObjectSet
        {
            get
            {
                return _objectSet;
            }
            set
            {
    			string oldValue =  _objectSet;
    			bool stopChanging = false;
                On_ObjectSet_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("ObjectSet");
    			if(!stopChanging)
    			{
    				_objectSet = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("ObjectSet");
    				On_ObjectSet_Changed(oldValue, _objectSet);//\\
    			}
            }
        }
    	public static String ObjectSet_PropertyName { get { return "ObjectSet"; } }
        private string _objectSet;
        partial void On_ObjectSet_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_ObjectSet_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string UserNetworkIP
        {
            get
            {
                return _userNetworkIP;
            }
            set
            {
    			string oldValue =  _userNetworkIP;
    			bool stopChanging = false;
                On_UserNetworkIP_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("UserNetworkIP");
    			if(!stopChanging)
    			{
    				_userNetworkIP = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("UserNetworkIP");
    				On_UserNetworkIP_Changed(oldValue, _userNetworkIP);//\\
    			}
            }
        }
    	public static String UserNetworkIP_PropertyName { get { return "UserNetworkIP"; } }
        private string _userNetworkIP;
        partial void On_UserNetworkIP_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_UserNetworkIP_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string MyColumn
        {
            get
            {
                return _myColumn;
            }
            set
            {
    			string oldValue =  _myColumn;
    			bool stopChanging = false;
                On_MyColumn_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("MyColumn");
    			if(!stopChanging)
    			{
    				_myColumn = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("MyColumn");
    				On_MyColumn_Changed(oldValue, _myColumn);//\\
    			}
            }
        }
    	public static String MyColumn_PropertyName { get { return "MyColumn"; } }
        private string _myColumn;
        partial void On_MyColumn_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_MyColumn_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string NDCTest
        {
            get
            {
                return _nDCTest;
            }
            set
            {
    			string oldValue =  _nDCTest;
    			bool stopChanging = false;
                On_NDCTest_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NDCTest");
    			if(!stopChanging)
    			{
    				_nDCTest = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("NDCTest");
    				On_NDCTest_Changed(oldValue, _nDCTest);//\\
    			}
            }
        }
    	public static String NDCTest_PropertyName { get { return "NDCTest"; } }
        private string _nDCTest;
        partial void On_NDCTest_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_NDCTest_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string NDCTest2
        {
            get
            {
                return _nDCTest2;
            }
            set
            {
    			string oldValue =  _nDCTest2;
    			bool stopChanging = false;
                On_NDCTest2_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("NDCTest2");
    			if(!stopChanging)
    			{
    				_nDCTest2 = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("NDCTest2");
    				On_NDCTest2_Changed(oldValue, _nDCTest2);//\\
    			}
            }
        }
    	public static String NDCTest2_PropertyName { get { return "NDCTest2"; } }
        private string _nDCTest2;
        partial void On_NDCTest2_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_NDCTest2_Changed(string oldValue, string currentValue);
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [EdmScalarPropertyAttribute(EntityKeyProperty=false, IsNullable=true)]
        [DataMemberAttribute()]
        public string BusinessCode
        {
            get
            {
                return _businessCode;
            }
            set
            {
    			string oldValue =  _businessCode;
    			bool stopChanging = false;
                On_BusinessCode_Changing(oldValue, ref value, ref stopChanging);
                ReportPropertyChanging("BusinessCode");
    			if(!stopChanging)
    			{
    				_businessCode = StructuralObject.SetValidValue(value, true);
    				ReportPropertyChanged("BusinessCode");
    				On_BusinessCode_Changed(oldValue, _businessCode);//\\
    			}
            }
        }
    	public static String BusinessCode_PropertyName { get { return "BusinessCode"; } }
        private string _businessCode;
        partial void On_BusinessCode_Changing(string currentValue, ref string newValue, ref bool stopChanging);
        partial void On_BusinessCode_Changed(string oldValue, string currentValue);

        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [XmlIgnoreAttribute()]
        [SoapIgnoreAttribute()]
        [DataMemberAttribute()]
        [EdmRelationshipNavigationPropertyAttribute("PSC_ERPModel", "FK_EntityTrackingLogs_app_users", "app_users")]
        public app_users app_users
        {//test
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_EntityTrackingLogs_app_users", "app_users").Value;
            }
            set
            {
    			bool stopChanging = false;
    			On_app_users_Changing(ref value, ref stopChanging);//\\//
    			if(!stopChanging)
    			{
    				((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_EntityTrackingLogs_app_users", "app_users").Value = value;
    				On_app_users_Changed(this.app_users);//\\//
    			}
    	    }
        }
    	public static String app_users_ReferencePropertyName { get { return "app_users"; } }
    	partial void On_app_users_Changing(ref app_users newValue, ref bool stopChanging);
    	partial void On_app_users_Changed(app_users currentValue);
        /// <summary>
        /// No Metadata Documentation available.
        /// </summary>
        [BrowsableAttribute(false)]
        [DataMemberAttribute()]
        public EntityReference<app_users> app_usersReference
        {
            get
            {
                return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<app_users>("PSC_ERPModel.FK_EntityTrackingLogs_app_users", "app_users");
            }
            set
            {
                if ((value != null))
                {
                    ((IEntityWithRelationships)this).RelationshipManager.InitializeRelatedReference<app_users>("PSC_ERPModel.FK_EntityTrackingLogs_app_users", "app_users", value);
                }
            }
        }

        #endregion

    }
}
