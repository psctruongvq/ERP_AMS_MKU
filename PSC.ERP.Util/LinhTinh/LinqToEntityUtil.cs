
/*Người viết: Nguyễn Phú Cường
 * 
 * 
 * Chức năng: Tập hợp các hàm giúp thao tác dữ liệu bằng truy vấn Linq
 * 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Objects;
using System.Data.Objects.DataClasses;

namespace PSC_ERP_Util
{
    public class LinqToEntityUtil
    {
        public static TEntity SelectFirst<TEntity>(System.Data.Objects.ObjectContext objectContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in (objectContext.CreateObjectSet<TEntity>())
                         select p).First();
            return query;
        }
        public static TEntity SelectFirstOrDefault<TEntity>(System.Data.Objects.ObjectContext objectContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in (objectContext.CreateObjectSet<TEntity>())

                         select p).FirstOrDefault();
            return query;
        }
        ////////

        //
        public static TEntity SelectLast<TEntity>(System.Data.Objects.ObjectContext objectContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in objectContext.CreateObjectSet<TEntity>()

                         select p).Last();
            return query;
        }
        public static TEntity SelectLastOrDefault<TEntity>(System.Data.Objects.ObjectContext objectContext) where TEntity : EntityObject//, new()
        {
            var query = (from p in objectContext.CreateObjectSet<TEntity>()

                         select p).LastOrDefault();
            return query;
        }
        /////////////////

        //
        public static IEnumerable<TEntity> SelectTopN<TEntity>(System.Data.Objects.ObjectContext objectContext, int n) where TEntity : EntityObject//, new()
        {
            var query = (from p in objectContext.CreateObjectSet<TEntity>()

                         select p).Take(n);
            return query;
        }
        //
        public static IEnumerable<TEntity> SelectBottomN<TEntity>(System.Data.Objects.ObjectContext objectContext, int n) where TEntity : EntityObject//, new()
        {
            ObjectSet<TEntity> objectSet = objectContext.CreateObjectSet<TEntity>();
            IQueryable<TEntity> query1 = from o in objectSet
                                         select o;
            int count = query1.Count();
            int skipIndex = count - n;

            if (skipIndex < 0) skipIndex = 0;

            IQueryable<TEntity> query2 = (from o in query1 orderby 1 select o).Skip(skipIndex).Take(n);
            return query2;
        }
        //
        public static int ExecuteCommand(System.Data.Objects.ObjectContext objectContext, String commandTextWithFormat, params Object[] parameters)
        {
            return objectContext.ExecuteStoreCommand(commandTextWithFormat, parameters);
        }


        //
        public static IEnumerable<TEntity> ExecuteQuery<TEntity>(System.Data.Objects.ObjectContext objectContext, String commandTextWithFormat, params Object[] parameters)
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

            return objectContext.ExecuteStoreQuery<TEntity>(commandTextWithFormat, parameters);
        }

    }
}
