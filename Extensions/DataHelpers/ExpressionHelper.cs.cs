using System;
using System.Linq.Expressions;

namespace Extensions.DataHelpers
{
    public static class ExpressionHelper
    {
        public static Expression MapProperyAccessExpr(this Expression source, String propertyName)
        {
            var properties = propertyName.Split('.');
            var result = source;
            foreach (String property in properties)
            {
                result = Expression.Property(result, property);
            }
            return result;
        }
    }
}