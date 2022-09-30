using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;

namespace ERP_Library
{
    [Serializable()]
    public class PhieuThutuPhieuChiEditableChildList : Csla.BusinessListBase<PhieuThutuPhieuChiEditableChildList, PhieuThutuPhieuChiEditableChild>
    {
        #region BindingList Overrides
        protected override object AddNewCore()
        {
            PhieuThutuPhieuChiEditableChild item = PhieuThutuPhieuChiEditableChild.NewPhieuThutuPhieuChiEditableChild();
            this.Add(item);
            return item;
        }
        #endregion //BindingList Overrides

        #region Factory Methods
        public static PhieuThutuPhieuChiEditableChildList NewPhieuThutuPhieuChiEditableChildList()
        {
            return new PhieuThutuPhieuChiEditableChildList();
        }

        internal static PhieuThutuPhieuChiEditableChildList GetPhieuThutuPhieuChiEditableChildList(SafeDataReader dr)
        {
            return new PhieuThutuPhieuChiEditableChildList(dr);
        }

        public static PhieuThutuPhieuChiEditableChildList GetPhieuThutuPhieuChiEditableChildList(long maChungTu)
        {
            return new PhieuThutuPhieuChiEditableChildList(maChungTu);
        }

        private PhieuThutuPhieuChiEditableChildList()
        {
            MarkAsChild();
        }

        private PhieuThutuPhieuChiEditableChildList(SafeDataReader dr)
        {
            MarkAsChild();
            Fetch(dr);
        }

        private PhieuThutuPhieuChiEditableChildList(long maChungTu)
        {
            MarkAsChild();
            RaiseListChangedEvents = false;
            using (SqlConnection cn = new SqlConnection(Database.ERP_Connection))
            {
                cn.Open();
                using (SqlCommand cm = cn.CreateCommand())
                {
                    cm.CommandType = CommandType.StoredProcedure;
                    cm.CommandText = "spd_SelecttblPhieuThutuPhieuChisAll";
                    cm.Parameters.AddWithValue("@MaPhieuThu", maChungTu);
                    using (SafeDataReader dr = new SafeDataReader(cm.ExecuteReader()))
                    {
                        while (dr.Read())
                            this.Add(PhieuThutuPhieuChiEditableChild.GetPhieuThutuPhieuChiEditableChild(dr));
                    }
                }
            }
            RaiseListChangedEvents = true;
        }

        public static string GetSoChungTuString(PhieuThutuPhieuChiEditableChildList list)
            {
                string kqString = string.Empty;
                foreach (PhieuThutuPhieuChiEditableChild child in list)
                {
                    kqString =kqString+", "+ child.SoChungTuPhieuChi;
                }
           if(kqString.Length>2)
               kqString = kqString.Substring(2, kqString.Length - 2);
                return kqString;
            }
        #endregion //Factory Methods


        #region Data Access
        private void Fetch(SafeDataReader dr)
        {
            RaiseListChangedEvents = false;

            while (dr.Read())
                this.Add(PhieuThutuPhieuChiEditableChild.GetPhieuThutuPhieuChiEditableChild(dr));

            RaiseListChangedEvents = true;
        }

        internal void Update(SqlTransaction tr, ChungTu parent)
        {
            RaiseListChangedEvents = false;

            // loop through each deleted child object
            foreach (PhieuThutuPhieuChiEditableChild deletedChild in DeletedList)
                deletedChild.DeleteSelf(tr);
            DeletedList.Clear();

            // loop through each non-deleted child object
            foreach (PhieuThutuPhieuChiEditableChild child in this)
            {
                if (child.IsNew)
                    child.Insert(tr, parent);
                else
                    child.Update(tr, parent);
            }

            RaiseListChangedEvents = true;
        }

        public void DataPortal_Delete(SqlTransaction tr)
        {
            foreach (PhieuThutuPhieuChiEditableChild child in this)
            {
                child.DeleteSelf(tr);
            }
        }
        #endregion //Data Access

    }
}
