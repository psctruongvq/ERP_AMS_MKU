using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace PSC_ERP_Util
{
    public class QueryExpressionUtil
    {
        public static Expression<Func<TValue, bool>> BuildOrExpressionTree<TValue, TCompareAgainst>(
IEnumerable<TCompareAgainst> wantedItems,
Expression<Func<TValue, TCompareAgainst>> convertBetweenTypes)
        {
            /*huong dan su dung
                int[] wantedObjIds = new[] { 8, 9, 10, 11 };

                Expression<Func<EntityTrackingLog, bool>> orClause = PSC_ERP_Util.QueryExpressionUtil.BuildOrExpressionTree<EntityTrackingLog, int>(wantedObjIds, obj => obj.ID);

                IQueryable<EntityTrackingLog> objs = _factory.Context.EntityTrackingLogs.Where(whereClause);

            */
            ParameterExpression inputParam = convertBetweenTypes.Parameters[0];

            Expression binaryExpressionTree = BuildBinaryOrTree_Helper(wantedItems.GetEnumerator(), convertBetweenTypes.Body, null);

            return Expression.Lambda<Func<TValue, bool>>(binaryExpressionTree, new[] { inputParam });
        }

        private static Expression BuildBinaryOrTree_Helper<T>(
    IEnumerator<T> itemEnumerator,
    Expression expressionToCompareTo,
    Expression expression)
        {
            if (itemEnumerator.MoveNext() == false)
                return expression;

            ConstantExpression constant = Expression.Constant(itemEnumerator.Current, typeof(T));
            BinaryExpression comparison = Expression.Equal(expressionToCompareTo, constant);

            BinaryExpression newExpression;

            if (expression == null)
                newExpression = comparison;
            else
                newExpression = Expression.OrElse(expression, comparison);

            return BuildBinaryOrTree_Helper(itemEnumerator, expressionToCompareTo, newExpression);
        }
    }
}
