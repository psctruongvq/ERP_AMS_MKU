using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PSC_ERP_Core
{
    public static class ExpressionEx
    {//http://blogs.msdn.com/b/meek/archive/2008/05/02/linq-to-entities-combining-predicates.aspx
        public static Expression<T> Compose<T>(this Expression<T> first, Expression<T> second, Func<Expression, Expression, Expression> merge)
        {
            // build parameter map (from parameters of second to parameters of first)
            var map = first.Parameters.Select((f, i) => new { f, s = second.Parameters[i] }).ToDictionary(p => p.s, p => p.f);

            // replace parameters in the second lambda expression with parameters from the first
            var secondBody = ParameterRebinder.ReplaceParameters(map, second.Body);

            // apply composition of lambda expression bodies to parameters from the first expression 
            return Expression.Lambda<T>(merge(first.Body, secondBody), first.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return first.Compose(second, Expression.And);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            /*su dung
                Expression<Func<Car, bool>> theCarIsRed = c => c.Color == "Red";
                Expression<Func<Car, bool>> theCarIsCheap = c => c.Price < 10.0;
                Expression<Func<Car, bool>> theCarIsRedOrCheap = theCarIsRed.Or(theCarIsCheap);
                var query = carQuery.Where(theCarIsRedOrCheap);
              */
            return first.Compose(second, Expression.Or);
        }
    }
}
