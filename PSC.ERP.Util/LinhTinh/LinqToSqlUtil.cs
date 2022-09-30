using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects.DataClasses;

namespace PSC_ERP_Util
{
    class LinqToSqlUtil
    {
        public static int ExecuteCommand(System.Data.Linq.DataContext dataContext, String commandTextWithFormat, params Object[] parameters)
        {
            return dataContext.ExecuteCommand(commandTextWithFormat, parameters);
        }
        ///////////
        public static TEntity SelectFirst<TEntity>(System.Data.Linq.DataContext dataContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in (dataContext.GetTable<TEntity>())

                         select p).First();
            return query;
        }
        public static TEntity SelectFirstOrDefault<TEntity>(System.Data.Linq.DataContext dataContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in (dataContext.GetTable<TEntity>())

                         select p).FirstOrDefault();
            return query;
        }

        ///////////

        public static TEntity SelectLastOrDefault<TEntity>(System.Data.Linq.DataContext dataContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in dataContext.GetTable<TEntity>()

                         select p).LastOrDefault();
            return query;
        }


        //////////////
        public static IEnumerable<TEntity> SelectTopN<TEntity>(System.Data.Linq.DataContext dataContext, int n) where TEntity : EntityObject//, new()
        {
            var query = (from p in dataContext.GetTable<TEntity>()

                         select p).Take(n);
            return query;
        }
        //////////////
        public static IEnumerable<TEntity> ExecuteQuery<TEntity>(System.Data.Linq.DataContext dataContext, String commandTextWithFormat, params Object[] parameters)
        {
            //            Northwnd db = new Northwnd(@"c:\northwnd.mdf");
            //            IEnumerable<Customer> results = db.ExecuteQuery<Customer>
            //            (@"SELECT c1.custid as CustomerID, c2.custName as ContactName
            //    FROM customer1 as c1, customer2 as c2
            //    WHERE c1.custid = c2.custid"
            //            );
            //        IEnumerable<Customer> results = db.ExecuteQuery<Customer>
            //("SELECT contactname FROM customers WHERE city = {0}",
            //"London");

            return dataContext.ExecuteQuery<TEntity>(commandTextWithFormat, parameters);
        }
    }
}
