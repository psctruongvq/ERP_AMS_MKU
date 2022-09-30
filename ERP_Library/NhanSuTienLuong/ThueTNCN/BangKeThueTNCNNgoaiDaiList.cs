namespace ERP_Library
{
    using Csla;
    using Csla.Data;
    using System;
    using System.Data;
    using System.Data.SqlClient;

    [Serializable]
    public class BangKeThueTNCNNgoaiDaiList : BusinessListBase<BangKeThueTNCNNgoaiDaiList, BangKeThueTNCNNgoaiDai>
    {
        private int iddef = -1;

        private BangKeThueTNCNNgoaiDaiList()
        {
        }

        protected override object AddNewCore()
        {
            BangKeThueTNCNNgoaiDai item = BangKeThueTNCNNgoaiDai.NewBangKeThueTNCNNgoaiDaiChild();
            item._id = this.iddef;
            this.iddef--;
            base.Add(item);
            return item;
        }

        private void DataPortal_Fetch(FilterCriteria criteria)
        {
            base.RaiseListChangedEvents = false;
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    this.ExecuteFetch(tr, criteria);
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
            base.RaiseListChangedEvents = true;
        }

        protected override void DataPortal_Update()
        {
            base.RaiseListChangedEvents = false;
            using (SqlConnection connection = new SqlConnection(Database.ERP_Connection))
            {
                connection.Open();
                SqlTransaction tr = connection.BeginTransaction();
                try
                {
                    foreach (BangKeThueTNCNNgoaiDai dai in base.DeletedList)
                    {
                        dai.DeleteSelf(tr);
                    }
                    base.DeletedList.Clear();
                    foreach (BangKeThueTNCNNgoaiDai dai2 in this)
                    {
                        if (dai2.IsNew)
                        {
                            dai2.Insert(tr);
                        }
                        else
                        {
                            dai2.Update(tr);
                        }
                    }
                    tr.Commit();
                }
                catch
                {
                    tr.Rollback();
                    throw;
                }
            }
            base.RaiseListChangedEvents = true;
        }

        private void ExecuteFetch(SqlTransaction tr, FilterCriteria criteria)
        {
            using (SqlCommand command = tr.Connection.CreateCommand())
            {
                command.Transaction = tr;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spd_Select_BangKeThueTNCNNgoaiDaiList";
                command.Parameters.AddWithValue("@Nam", criteria.Nam);
                using (SafeDataReader reader = new SafeDataReader(command.ExecuteReader()))
                {
                    while (reader.Read())
                    {
                        base.Add(BangKeThueTNCNNgoaiDai.GetBangKeThueTNCNNgoaiDai(reader));
                    }
                }
            }
        }

        public static BangKeThueTNCNNgoaiDaiList GetBangKeThueTNCNNgoaiDaiList(int Nam)
        {
            return DataPortal.Fetch<BangKeThueTNCNNgoaiDaiList>(new FilterCriteria(Nam));
        }

        public static BangKeThueTNCNNgoaiDaiList NewBangKeThueTNCNNgoaiDaiList()
        {
            return new BangKeThueTNCNNgoaiDaiList();
        }

        [Serializable]
        private class FilterCriteria
        {
            public int Nam;

            public FilterCriteria(int nam)
            {
                this.Nam = nam;
            }
        }
    }
}

