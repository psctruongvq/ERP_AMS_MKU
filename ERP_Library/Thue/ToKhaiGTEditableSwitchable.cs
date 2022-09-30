
using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using Csla.Validation;

namespace ERP_Library
{ 
	[Serializable()] 
	public class ToKhaiThueGTGTGT : Csla.BusinessBase<ToKhaiThueGTGTGT>
	{
		#region Business Properties and Methods

		//declare members
		private int _maKy = 0;
		private decimal _c10 = 0;
		private decimal _c11 = 0;
		private decimal _c12 = 0;
		private decimal _c13 = 0;
		private decimal _c14 = 0;
		private decimal _c15 = 0;
		private decimal _c16 = 0;
		private decimal _c17 = 0;
		private decimal _c18 = 0;
		private decimal _c19 = 0;
		private decimal _c20 = 0;
		private decimal _c21 = 0;
		private decimal _c22 = 0;
		private decimal _c23 = 0;
		private decimal _c24 = 0;
		private decimal _c25 = 0;
		private decimal _c26 = 0;
		private decimal _c27 = 0;
		private decimal _c28 = 0;
		private decimal _c29 = 0;
		private decimal _c30 = 0;
		private decimal _c31 = 0;
		private decimal _c32 = 0;
		private decimal _c33 = 0;
		private decimal _c34 = 0;
		private decimal _c35 = 0;
		private decimal _c36 = 0;
		private decimal _c37 = 0;
		private decimal _c38 = 0;
		private decimal _c39 = 0;
		private decimal _c40 = 0;
		private decimal _c41 = 0;
		private decimal _c42 = 0;
		private decimal _c43 = 0;
		private int _maNhanVien = Convert.ToInt32(ERP_Library.Security.CurrentUser.Info.UserID);
		private DateTime _ngayLap = DateTime.Now;

		[System.ComponentModel.DataObjectField(true, false)]
		public int MaKy
		{
			get
			{
				CanReadProperty("MaKy", true);
				return _maKy;
			}
		}

		public decimal C10
		{
			get
			{
				CanReadProperty("C10", true);
				return _c10;
			}
			set
			{
				CanWriteProperty("C10", true);
				if (!_c10.Equals(value))
				{
					_c10 = value;
					PropertyHasChanged("C10");
				}
			}
		}

		public decimal C11
		{
			get
			{
				CanReadProperty("C11", true);
				return _c11;
			}
			set
			{
				CanWriteProperty("C11", true);
				if (!_c11.Equals(value))
                {
                    _c11 = value;
                    _c40 = _c39 - _c23 - _c11;
                    if (_c40 < 0)
                    {
                        _c41 = (_c39 - _c23 - _c11) * -1;
                        _c40 = 0;
                    }
					PropertyHasChanged("C11");
				}
			}
		}

		public decimal C12
		{
			get
			{
				CanReadProperty("C12", true);
				return _c12;
			}
			set
			{
				CanWriteProperty("C12", true);
				if (!_c12.Equals(value))
				{               
					_c12 = value;

					PropertyHasChanged("C12");
				}
			}
		}

		public decimal C13
		{
			get
			{
				CanReadProperty("C13", true);
				return _c13;
			}
			set
			{
				CanWriteProperty("C13", true);
				if (!_c13.Equals(value))
				{
                    _c22 = _c13 + _c19 - _c21;
					_c13 = value;
					PropertyHasChanged("C13");
				}
			}
		}

		public decimal C14
		{
			get
			{
				CanReadProperty("C14", true);
				return _c14;
			}
			set
			{
				CanWriteProperty("C14", true);
				if (!_c14.Equals(value))
				{                 
					_c14 = value;
                    _c12 = _c14 + _c16;
					PropertyHasChanged("C14");
				}
			}
		}

		public decimal C15
		{
			get
			{
				CanReadProperty("C15", true);
				return _c15;
			}
			set
			{
				CanWriteProperty("C15", true);
				if (!_c15.Equals(value))
                {
                  
					_c15 = value;
                    _c13 = _c15 + _c17;
					PropertyHasChanged("C15");
				}
			}
		}

		public decimal C16
		{
			get
			{
				CanReadProperty("C16", true);
				return _c16;
			}
			set
			{
				CanWriteProperty("C16", true);
				if (!_c16.Equals(value))
                {
                   
					_c16 = value;
                    _c12 = _c14 + _c16;
					PropertyHasChanged("C16");
				}
			}
		}

		public decimal C17
		{
			get
			{
				CanReadProperty("C17", true);
				return _c17;
			}
			set
			{
				CanWriteProperty("C17", true);
				if (!_c17.Equals(value))
                {
                  
					_c17 = value;
                    _c13 = _c15 + _c17;
					PropertyHasChanged("C17");
				}
			}
		}

		public decimal C18
		{
			get
			{
				CanReadProperty("C18", true);
				return _c18;
			}
			set
			{
				CanWriteProperty("C18", true);
				if (!_c18.Equals(value))
				{
					_c18 = value;
					PropertyHasChanged("C18");
				}
			}
		}

		public decimal C19
		{
			get
			{
				CanReadProperty("C19", true);
				return _c19;
			}
			set
			{
				CanWriteProperty("C19", true);
				if (!_c19.Equals(value))
                {                  
					_c19 = value;
                    _c22 = _c13 + _c19 - _c21;
					PropertyHasChanged("C19");
				}
			}
		}

		public decimal C20
		{
			get
			{
				CanReadProperty("C20", true);
				return _c20;
			}
			set
			{
				CanWriteProperty("C20", true);
				if (!_c20.Equals(value))
				{
					_c20 = value;
					PropertyHasChanged("C20");
				}
			}
		}

		public decimal C21
		{
			get
			{
				CanReadProperty("C21", true);
				return _c21;
			}
			set
			{
				CanWriteProperty("C21", true);
				if (!_c21.Equals(value))
                {
          
					_c21 = value;
                    _c22 = _c13 + _c19 - _c21;
					PropertyHasChanged("C21");
				}
			}
		}

		public decimal C22
		{
			get
			{
				CanReadProperty("C22", true);
				return _c22;
			}
			set
			{
				CanWriteProperty("C22", true);
				if (!_c22.Equals(value))
                {
                  
					_c22 = value;
					PropertyHasChanged("C22");
				}
			}
		}

		public decimal C23
		{
			get
			{
				CanReadProperty("C23", true);
				return _c23;
			}
			set
			{
				CanWriteProperty("C23", true);
				if (!_c23.Equals(value))
                {
                   
					_c23 = value;
                    _c40 = _c39 - _c23 - _c11;
                    if (_c40 < 0)
                    {
                        _c41 = (_c39 - _c23 - _c11) * -1;

                        _c40 = 0;
                    } 
                    PropertyHasChanged("C23");
				}
			}
		}

		public decimal C24
		{
			get
			{
				CanReadProperty("C24", true);
				return _c24;
			}
			set
			{
				CanWriteProperty("C24", true);
				if (!_c24.Equals(value))
				{
                 
					_c24 = value;
                    _c38 = _c24 + _c34 - _c36;
					PropertyHasChanged("C24");
				}
			}
		}

		public decimal C25
		{
			get
			{
				CanReadProperty("C25", true);
				return _c25;
			}
			set
			{
				CanWriteProperty("C25", true);
				if (!_c25.Equals(value))
				{
                 
					_c25 = value;
                    _c38 = _c25 + _c35 - _c37;
					PropertyHasChanged("C25");
				}
			}
		}

		public decimal C26
		{
			get
			{
				CanReadProperty("C26", true);
				return _c26;
			}
			set
			{
				CanWriteProperty("C26", true);
				if (!_c26.Equals(value))
                {
                  
					_c26 = value;
                    _c24 = _c26 + _c27;
					PropertyHasChanged("C26");
				}
			}
		}

		public decimal C27
		{
			get
			{
				CanReadProperty("C27", true);
				return _c27;
			}
			set
			{
				CanWriteProperty("C27", true);
				if (!_c27.Equals(value))
				{
                                   
					_c27 = value;
                    _c24 = _c26 + _c27;    
					PropertyHasChanged("C27");
				}
			}
		}

		public decimal C28
		{
			get
			{
				CanReadProperty("C28", true);
				return _c28;
			}
			set
			{
				CanWriteProperty("C28", true);
				if (!_c28.Equals(value))
				{                                 
					_c28 = value;
                    _c25 = _c28;     
					PropertyHasChanged("C28");
				}
			}
		}

		public decimal C29
		{
			get
			{
				CanReadProperty("C29", true);
				return _c29;
			}
			set
			{
				CanWriteProperty("C29", true);
				if (!_c29.Equals(value))
                {
                    
					_c29 = value;
                    _c27 = _c29 + _c30 + _c32;
					PropertyHasChanged("C29");
				}
			}
		}

		public decimal C30
		{
			get
			{
				CanReadProperty("C30", true);
				return _c30;
			}
			set
			{
				CanWriteProperty("C30", true);
				if (!_c30.Equals(value))
                {
                 
					_c30 = value;
                    _c27 = _c29 + _c30 + _c32;
					PropertyHasChanged("C30");
				}
			}
		}

		public decimal C31
		{
			get
			{
				CanReadProperty("C31", true);
				return _c31;
			}
			set
			{
				CanWriteProperty("C31", true);
				if (!_c31.Equals(value))
                {
                    
					_c31 = value;
                    _c28 = _c31 + _c33;
					PropertyHasChanged("C31");
				}
			}
		}

		public decimal C32
		{
			get
			{
				CanReadProperty("C32", true);
				return _c32;
			}
			set
			{
				CanWriteProperty("C32", true);
				if (!_c32.Equals(value))
                {
                    
					_c32 = value;
                    _c27 = _c29 + _c30 + _c32;
					PropertyHasChanged("C32");
				}
			}
		}

		public decimal C33
		{
			get
			{
				CanReadProperty("C33", true);
				return _c33;
			}
			set
			{
				CanWriteProperty("C33", true);
				if (!_c33.Equals(value))
                {
                    
					_c33 = value;
                    _c28 = _c31 + _c33;
					PropertyHasChanged("C33");
				}
			}
		}

		public decimal C34
		{
			get
			{
				CanReadProperty("C34", true);
				return _c34;
			}
			set
			{
				CanWriteProperty("C34", true);
				if (!_c34.Equals(value))
                {                    
					_c34 = value;
                    _c38 = _c24 + _c34 - _c36;
					PropertyHasChanged("C34");
				}
			}
		}

		public decimal C35
		{
			get
			{
				CanReadProperty("C35", true);
				return _c35;
			}
			set
			{
				CanWriteProperty("C35", true);
				if (!_c35.Equals(value))
                {
                    
					_c35 = value;
                    _c38 = _c25 + _c35 - _c37;
					PropertyHasChanged("C35");
				}
			}
		}

		public decimal C36
		{
			get
			{
				CanReadProperty("C36", true);
				return _c36;
			}
			set
			{
				CanWriteProperty("C36", true);
				if (!_c36.Equals(value))
                {
                   

					_c36 = value;
                    _c38 = _c24 + _c34 - _c36;
					PropertyHasChanged("C36");
				}
			}
		}

		public decimal C37
		{
			get
			{
				CanReadProperty("C37", true);
				return _c37;
			}
			set
			{
				CanWriteProperty("C37", true);
				if (!_c37.Equals(value))
                {
                    
					_c37 = value;
                    _c38 = _c25 + _c35 - _c37;
					PropertyHasChanged("C37");
				}
			}
		}

		public decimal C38
		{
			get
			{
				CanReadProperty("C38", true);
				return _c38;
			}
			set
			{
				CanWriteProperty("C38", true);
				if (!_c38.Equals(value))
				{
					_c38 = value;
					PropertyHasChanged("C38");
				}
			}
		}

		public decimal C39
		{
			get
			{
				CanReadProperty("C39", true);
				return _c39;
			}
			set
			{
				CanWriteProperty("C39", true);
				if (!_c39.Equals(value))
                {                 
					_c39 = value;
                    _c40 = _c39 - _c23 - _c11;
                    if (_c40 < 0)
                    {
                        _c41 = (_c39 - _c23 - _c11) * -1;
                        _c40 = 0;
                    }
					PropertyHasChanged("C39");
				}
			}
		}

		public decimal C40
		{
			get
			{
				CanReadProperty("C40", true);
				return _c40;
			}
			set
			{
				CanWriteProperty("C40", true);
				if (!_c40.Equals(value))
                {
                   
					_c40 = value;
					PropertyHasChanged("C40");
				}
			}
		}

		public decimal C41
		{
			get
			{
				CanReadProperty("C41", true);
				return _c41;
			}
			set
			{
				CanWriteProperty("C41", true);
				if (!_c41.Equals(value))
                {
                     
					_c41 = value;
					PropertyHasChanged("C41");
				}
			}
		}

		public decimal C42
		{
			get
			{
				CanReadProperty("C42", true);
				return _c42;
			}
			set
			{
				CanWriteProperty("C42", true);
				if (!_c42.Equals(value))
                {
                    
					_c42 = value;
                    _c43 = _c41 - _c42;
					PropertyHasChanged("C42");
				}
			}
		}

		public decimal C43
		{
			get
			{
				CanReadProperty("C43", true);
				return _c43;
			}
			set
			{
				CanWriteProperty("C43", true);
				if (!_c43.Equals(value))
                {
                  
					_c43 = value;
					PropertyHasChanged("C43");
				}
			}
		}

		public int MaNhanVien
		{
			get
			{
				CanReadProperty("MaNhanVien", true);
				return _maNhanVien;
			}
			set
			{
				CanWriteProperty("MaNhanVien", true);
				if (!_maNhanVien.Equals(value))
				{
					_maNhanVien = value;
					PropertyHasChanged("MaNhanVien");
				}
			}
		}

		public DateTime NgayLap
		{
			get
			{
				CanReadProperty("NgayLap", true);
				return _ngayLap.Date;
			}
            set{
                  if (!_ngayLap.Equals(value))
                  {
                      _ngayLap=value;
                      PropertyHasChanged();
                  }
            }
         
		} 
		protected override object GetIdValue()
		{
			return _maKy;
		}

		#endregion //Business Properties and Methods

		#region Validation Rules
		private void AddCustomRules()
		{
			//add custom/non-generated rules here...
		}

		private void AddCommonRules()
		{

		}

		protected override void AddBusinessRules()
		{
			AddCommonRules();
			AddCustomRules();
		}
		#endregion //Validation Rules

		#region Authorization Rules
		protected override void AddAuthorizationRules()
		{
			//TODO: Define authorization rules in ToKhaiThueGTGTGT
			//AuthorizationRules.AllowRead("MaKy", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C10", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C11", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C12", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C13", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C14", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C15", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C16", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C17", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C18", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C19", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C20", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C21", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C22", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C23", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C24", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C25", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C26", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C27", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C28", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C29", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C30", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C31", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C32", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C33", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C34", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C35", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C36", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C37", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C38", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C39", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C40", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C41", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C42", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("C43", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("MaNhanVien", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("NgayLap", "ToKhaiThueGTGTGTReadGroup");
			//AuthorizationRules.AllowRead("NgayLapString", "ToKhaiThueGTGTGTReadGroup");

			//AuthorizationRules.AllowWrite("C10", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C11", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C12", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C13", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C14", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C15", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C16", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C17", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C18", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C19", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C20", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C21", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C22", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C23", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C24", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C25", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C26", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C27", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C28", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C29", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C30", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C31", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C32", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C33", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C34", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C35", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C36", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C37", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C38", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C39", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C40", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C41", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C42", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("C43", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("MaNhanVien", "ToKhaiThueGTGTGTWriteGroup");
			//AuthorizationRules.AllowWrite("NgayLapString", "ToKhaiThueGTGTGTWriteGroup");
		}


		public static bool CanGetObject()
		{
			//TODO: Define CanGetObject permission in ToKhaiThueGTGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTViewGroup"))
			//	return true;
			//return false;
		}

		public static bool CanAddObject()
		{
			//TODO: Define CanAddObject permission in ToKhaiThueGTGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTAddGroup"))
			//	return true;
			//return false;
		}

		public static bool CanEditObject()
		{
			//TODO: Define CanEditObject permission in ToKhaiThueGTGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTEditGroup"))
			//	return true;
			//return false;
		}

		public static bool CanDeleteObject()
		{
			//TODO: Define CanDeleteObject permission in ToKhaiThueGTGTGT
			return true;
			//if (Csla.ApplicationContext.User.IsInRole("ToKhaiThueGTGTGTDeleteGroup"))
			//	return true;
			//return false;
		}
		#endregion //Authorization Rules

		#region Factory Methods
		private ToKhaiThueGTGTGT()
		{ /* require use of factory method */ }

		public static ToKhaiThueGTGTGT NewToKhaiThueGTGTGT(int maKy)
		{
			if (!CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToKhaiThueGTGTGT");
			return DataPortal.Create<ToKhaiThueGTGTGT>(new Criteria(maKy));
		}

		public static ToKhaiThueGTGTGT GetToKhaiThueGTGTGT(int maKy)
		{
			if (!CanGetObject())
				throw new System.Security.SecurityException("User not authorized to view a ToKhaiThueGTGTGT");
			return DataPortal.Fetch<ToKhaiThueGTGTGT>(new Criteria(maKy));
		}

		public static void DeleteToKhaiThueGTGTGT(int maKy)
		{
			if (!CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ToKhaiThueGTGTGT");
			DataPortal.Delete(new Criteria(maKy));
		}

		public override ToKhaiThueGTGTGT Save()
		{
			if (IsDeleted && !CanDeleteObject())
				throw new System.Security.SecurityException("User not authorized to remove a ToKhaiThueGTGTGT");
			else if (IsNew && !CanAddObject())
				throw new System.Security.SecurityException("User not authorized to add a ToKhaiThueGTGTGT");
			else if (!CanEditObject())
				throw new System.Security.SecurityException("User not authorized to update a ToKhaiThueGTGTGT");

			return base.Save();
		}

		#endregion //Factory Methods

		#region Child Factory Methods
		private ToKhaiThueGTGTGT(int maKy)
		{
			this._maKy = maKy;
		}

		internal static ToKhaiThueGTGTGT NewToKhaiThueGTGTGTChild(int maKy)
		{
			ToKhaiThueGTGTGT child = new ToKhaiThueGTGTGT(maKy);
			child.ValidationRules.CheckRules();
			child.MarkAsChild();
			return child;
		}

		internal static ToKhaiThueGTGTGT GetToKhaiThueGTGTGT(SafeDataReader dr)
		{
			ToKhaiThueGTGTGT child =  new ToKhaiThueGTGTGT();
			child.MarkAsChild();
			child.Fetch(dr);
			return child;
		}
		#endregion //Child Factory Methods

		#region Data Access

		#region Criteria

		[Serializable()]
		private class Criteria
		{
			public int MaKy;

			public Criteria(int maKy)
			{
				this.MaKy = maKy;
			}
		}

		#endregion //Criteria

		#region Data Access - Create
		[RunLocal]
		private void DataPortal_Create(Criteria criteria)
		{
			_maKy = criteria.MaKy;
			ValidationRules.CheckRules();
		}

		#endregion //Data Access - Create

		#region Data Access - Fetch
		private void DataPortal_Fetch(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteFetch(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using
		}

		private void ExecuteFetch(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "[dbo].[spd_SelecttblToKhaiThueGTGTGianTiep]";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

				using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
				{
                    while (dr.Read())
                    {
                        FetchObject(dr);
                        ValidationRules.CheckRules();

                        //load child object(s)
                        FetchChildren(dr);
                    }
				}
			}//using
		}

		#endregion //Data Access - Fetch

		#region Data Access - Insert
		protected override void DataPortal_Insert()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteInsert(tr);

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Insert

		#region Data Access - Update
		protected override void DataPortal_Update()
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					if (base.IsDirty)
					{
						ExecuteUpdate(tr);
					}

					//update child object(s)
					UpdateChildren(tr);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		#endregion //Data Access - Update

		#region Data Access - Delete
		protected override void DataPortal_DeleteSelf()
		{
			DataPortal_Delete(new Criteria(_maKy));
		}

		private void DataPortal_Delete(Criteria criteria)
		{
			SqlTransaction tr;

			using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
			{
				cn.Open();

				tr = cn.BeginTransaction();
				try
				{
					ExecuteDelete(tr, criteria);

					tr.Commit();
				}
				catch
				{
					tr.Rollback();
					throw;
				}
			}//using

		}

		private void ExecuteDelete(SqlTransaction tr, Criteria criteria)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "DeleteToKhaiThueGTGTGT";

				cm.Parameters.AddWithValue("@MaKy", criteria.MaKy);

				cm.ExecuteNonQuery();
			}//using
		}
		#endregion //Data Access - Delete

		#region Data Access - Fetch
		private void Fetch(SafeDataReader dr)
		{
			FetchObject(dr);
			MarkOld();
			ValidationRules.CheckRules();

			//load child object(s)
			FetchChildren(dr);
		}

		private void FetchObject(SafeDataReader dr)
		{
			_maKy = dr.GetInt32("MaKy");
			_c10 = dr.GetDecimal("C10");
			_c11 = dr.GetDecimal("C11");
			_c12 = dr.GetDecimal("C12");
			_c13 = dr.GetDecimal("C13");
			_c14 = dr.GetDecimal("C14");
			_c15 = dr.GetDecimal("C15");
			_c16 = dr.GetDecimal("C16");
			_c17 = dr.GetDecimal("C17");
			_c18 = dr.GetDecimal("C18");
			_c19 = dr.GetDecimal("C19");
			_c20 = dr.GetDecimal("C20");
			_c21 = dr.GetDecimal("C21");
			_c22 = dr.GetDecimal("C22");
			_c23 = dr.GetDecimal("C23");
			_c24 = dr.GetDecimal("C24");
			_c25 = dr.GetDecimal("C25");
			_c26 = dr.GetDecimal("C26");
			_c27 = dr.GetDecimal("C27");
			_c28 = dr.GetDecimal("C28");
			_c29 = dr.GetDecimal("C29");
			_c30 = dr.GetDecimal("C30");
			_c31 = dr.GetDecimal("C31");
			_c32 = dr.GetDecimal("C32");
			_c33 = dr.GetDecimal("C33");
			_c34 = dr.GetDecimal("C34");
			_c35 = dr.GetDecimal("C35");
			_c36 = dr.GetDecimal("C36");
			_c37 = dr.GetDecimal("C37");
			_c38 = dr.GetDecimal("C38");
			_c39 = dr.GetDecimal("C39");
			_c40 = dr.GetDecimal("C40");
			_c41 = dr.GetDecimal("C41");
			_c42 = dr.GetDecimal("C42");
			_c43 = dr.GetDecimal("C43");
			_maNhanVien = dr.GetInt32("MaNhanVien");
			_ngayLap = dr.GetDateTime("NgayLap");
		}

		private void FetchChildren(SafeDataReader dr)
		{
		}
		#endregion //Data Access - Fetch

		#region Data Access - Insert
		internal void Insert(SqlTransaction tr)
		{
			if (!IsDirty) return;

			ExecuteInsert(tr);
			MarkOld();

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteInsert(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "[dbo].[spd_InserttblToKhaiThueGTGTGianTiep]";

				AddInsertParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

		private void AddInsertParameters(SqlCommand cm)
		{
			cm.Parameters.AddWithValue("@MaKy", _maKy);
			if (_c10 != 0)
				cm.Parameters.AddWithValue("@C10", _c10);
			else
				cm.Parameters.AddWithValue("@C10", DBNull.Value);
			if (_c11 != 0)
				cm.Parameters.AddWithValue("@C11", _c11);
			else
				cm.Parameters.AddWithValue("@C11", DBNull.Value);
			if (_c12 != 0)
				cm.Parameters.AddWithValue("@C12", _c12);
			else
				cm.Parameters.AddWithValue("@C12", DBNull.Value);
			if (_c13 != 0)
				cm.Parameters.AddWithValue("@C13", _c13);
			else
				cm.Parameters.AddWithValue("@C13", DBNull.Value);
			if (_c14 != 0)
				cm.Parameters.AddWithValue("@C14", _c14);
			else
				cm.Parameters.AddWithValue("@C14", DBNull.Value);
			if (_c15 != 0)
				cm.Parameters.AddWithValue("@C15", _c15);
			else
				cm.Parameters.AddWithValue("@C15", DBNull.Value);
			if (_c16 != 0)
				cm.Parameters.AddWithValue("@C16", _c16);
			else
				cm.Parameters.AddWithValue("@C16", DBNull.Value);
			if (_c17 != 0)
				cm.Parameters.AddWithValue("@C17", _c17);
			else
				cm.Parameters.AddWithValue("@C17", DBNull.Value);
			if (_c18 != 0)
				cm.Parameters.AddWithValue("@C18", _c18);
			else
				cm.Parameters.AddWithValue("@C18", DBNull.Value);
			if (_c19 != 0)
				cm.Parameters.AddWithValue("@C19", _c19);
			else
				cm.Parameters.AddWithValue("@C19", DBNull.Value);
			if (_c20 != 0)
				cm.Parameters.AddWithValue("@C20", _c20);
			else
				cm.Parameters.AddWithValue("@C20", DBNull.Value);
			if (_c21 != 0)
				cm.Parameters.AddWithValue("@C21", _c21);
			else
				cm.Parameters.AddWithValue("@C21", DBNull.Value);
			if (_c22 != 0)
				cm.Parameters.AddWithValue("@C22", _c22);
			else
				cm.Parameters.AddWithValue("@C22", DBNull.Value);
			if (_c23 != 0)
				cm.Parameters.AddWithValue("@C23", _c23);
			else
				cm.Parameters.AddWithValue("@C23", DBNull.Value);
			if (_c24 != 0)
				cm.Parameters.AddWithValue("@C24", _c24);
			else
				cm.Parameters.AddWithValue("@C24", DBNull.Value);
			if (_c25 != 0)
				cm.Parameters.AddWithValue("@C25", _c25);
			else
				cm.Parameters.AddWithValue("@C25", DBNull.Value);
			if (_c26 != 0)
				cm.Parameters.AddWithValue("@C26", _c26);
			else
				cm.Parameters.AddWithValue("@C26", DBNull.Value);
			if (_c27 != 0)
				cm.Parameters.AddWithValue("@C27", _c27);
			else
				cm.Parameters.AddWithValue("@C27", DBNull.Value);
			if (_c28 != 0)
				cm.Parameters.AddWithValue("@C28", _c28);
			else
				cm.Parameters.AddWithValue("@C28", DBNull.Value);
			if (_c29 != 0)
				cm.Parameters.AddWithValue("@C29", _c29);
			else
				cm.Parameters.AddWithValue("@C29", DBNull.Value);
			if (_c30 != 0)
				cm.Parameters.AddWithValue("@C30", _c30);
			else
				cm.Parameters.AddWithValue("@C30", DBNull.Value);
			if (_c31 != 0)
				cm.Parameters.AddWithValue("@C31", _c31);
			else
				cm.Parameters.AddWithValue("@C31", DBNull.Value);
			if (_c32 != 0)
				cm.Parameters.AddWithValue("@C32", _c32);
			else
				cm.Parameters.AddWithValue("@C32", DBNull.Value);
			if (_c33 != 0)
				cm.Parameters.AddWithValue("@C33", _c33);
			else
				cm.Parameters.AddWithValue("@C33", DBNull.Value);
			if (_c34 != 0)
				cm.Parameters.AddWithValue("@C34", _c34);
			else
				cm.Parameters.AddWithValue("@C34", DBNull.Value);
			if (_c35 != 0)
				cm.Parameters.AddWithValue("@C35", _c35);
			else
				cm.Parameters.AddWithValue("@C35", DBNull.Value);
			if (_c36 != 0)
				cm.Parameters.AddWithValue("@C36", _c36);
			else
				cm.Parameters.AddWithValue("@C36", DBNull.Value);
			if (_c37 != 0)
				cm.Parameters.AddWithValue("@C37", _c37);
			else
				cm.Parameters.AddWithValue("@C37", DBNull.Value);
			if (_c38 != 0)
				cm.Parameters.AddWithValue("@C38", _c38);
			else
				cm.Parameters.AddWithValue("@C38", DBNull.Value);
			if (_c39 != 0)
				cm.Parameters.AddWithValue("@C39", _c39);
			else
				cm.Parameters.AddWithValue("@C39", DBNull.Value);
			if (_c40 != 0)
				cm.Parameters.AddWithValue("@C40", _c40);
			else
				cm.Parameters.AddWithValue("@C40", DBNull.Value);
			if (_c41 != 0)
				cm.Parameters.AddWithValue("@C41", _c41);
			else
				cm.Parameters.AddWithValue("@C41", DBNull.Value);
			if (_c42 != 0)
				cm.Parameters.AddWithValue("@C42", _c42);
			else
				cm.Parameters.AddWithValue("@C42", DBNull.Value);
			if (_c43 != 0)
				cm.Parameters.AddWithValue("@C43", _c43);
			else
				cm.Parameters.AddWithValue("@C43", DBNull.Value);
			if (_maNhanVien != 0)
				cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
			else
				cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
			cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
		}
		#endregion //Data Access - Insert

		#region Data Access - Update
		internal void Update(SqlTransaction tr)
		{
			if (!IsDirty) return;

			if (base.IsDirty)
			{
				ExecuteUpdate(tr);
				MarkOld();
			}

			//update child object(s)
			UpdateChildren(tr);
		}

		private void ExecuteUpdate(SqlTransaction tr)
		{
			using (SqlCommand cm = tr.Connection.CreateCommand())
			{
				cm.Transaction = tr;
				cm.CommandType = CommandType.StoredProcedure;
				cm.CommandText = "[dbo].[spd_UpdatetblToKhaiThueGTGTGianTiep]";

				AddUpdateParameters(cm);

				cm.ExecuteNonQuery();

			}//using
		}

        private void AddUpdateParameters(SqlCommand cm)
        {
            cm.Parameters.AddWithValue("@MaKy", _maKy);
            cm.Parameters.AddWithValue("@C10", _c10);
            cm.Parameters.AddWithValue("@C11", _c11);
            cm.Parameters.AddWithValue("@C12", _c12);
            cm.Parameters.AddWithValue("@C13", _c13);
            cm.Parameters.AddWithValue("@C14", _c14);
            cm.Parameters.AddWithValue("@C15", _c15);
            cm.Parameters.AddWithValue("@C16", _c16);
            cm.Parameters.AddWithValue("@C17", _c17);
            cm.Parameters.AddWithValue("@C18", _c18);
            cm.Parameters.AddWithValue("@C19", _c19);
            cm.Parameters.AddWithValue("@C20", _c20);
            cm.Parameters.AddWithValue("@C21", _c21);
            cm.Parameters.AddWithValue("@C22", _c22);
            cm.Parameters.AddWithValue("@C23", _c23);
            cm.Parameters.AddWithValue("@C24", _c24);
            cm.Parameters.AddWithValue("@C25", _c25);
            cm.Parameters.AddWithValue("@C26", _c26);
            cm.Parameters.AddWithValue("@C27", _c27);
            cm.Parameters.AddWithValue("@C28", _c28);
            cm.Parameters.AddWithValue("@C29", _c29);
            cm.Parameters.AddWithValue("@C30", _c30);
            cm.Parameters.AddWithValue("@C31", _c31);
            cm.Parameters.AddWithValue("@C32", _c32);
            cm.Parameters.AddWithValue("@C33", _c33);
            cm.Parameters.AddWithValue("@C34", _c34);
            cm.Parameters.AddWithValue("@C35", _c35);
            cm.Parameters.AddWithValue("@C36", _c36);
            cm.Parameters.AddWithValue("@C37", _c37);
            cm.Parameters.AddWithValue("@C38", _c38);
            cm.Parameters.AddWithValue("@C39", _c39);
            cm.Parameters.AddWithValue("@C40", _c40);
            cm.Parameters.AddWithValue("@C41", _c41);
            cm.Parameters.AddWithValue("@C42", _c42);
            cm.Parameters.AddWithValue("@C43", _c43);

            if (_maNhanVien != 0)
                cm.Parameters.AddWithValue("@MaNhanVien", _maNhanVien);
            else
                cm.Parameters.AddWithValue("@MaNhanVien", DBNull.Value);
            cm.Parameters.AddWithValue("@NgayLap", _ngayLap.Date);
        }

		private void UpdateChildren(SqlTransaction tr)
		{
		}
		#endregion //Data Access - Update

		#region Data Access - Delete
		internal void DeleteSelf(SqlTransaction tr)
		{
			if (!IsDirty) return;
			if (IsNew) return;

			ExecuteDelete(tr, new Criteria(_maKy));
			MarkNew();
		}
		#endregion //Data Access - Delete
		#endregion //Data Access
	}
}
