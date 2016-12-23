using System;
using System.Linq.Expressions;

namespace DotLiquid.Util
{
    public class MathUtility
    {
        public static object Process(Func<Expression, Expression, BinaryExpression> operation,
            dynamic a, dynamic b)
        {
            var left = b is decimal ? Convert.ToDecimal(a) : a;
            var right = a is decimal ? Convert.ToDecimal(b) : b;

            if (operation == Expression.Add)
                return left + right;
            if (operation == Expression.Subtract)
                return left - right;
            if (operation == Expression.Modulo)
                return left % right;
            if (operation == Expression.Divide)
                return left / right;
            if (operation == Expression.Multiply)
                return left * right;
            throw new NotSupportedException();
        }
    }
}