using DotLiquid.Util;
using NUnit.Framework;
using System.Linq.Expressions;

namespace DotLiquid.Tests.Util
{
    public class MathUtilityTests
    {
        [TestCase(0, 0, Result = 0)]
        [TestCase(0f, 0f, Result = 0f)]
        [TestCase(0L, 0L, Result = 0L)]
        [TestCase(0d, 0d, Result = 0d)]
        [TestCase(3, 18.0d, Result = 21d)]
        [TestCase(19d, 39, Result = 58d)]
        public object AddWorks(object a, object b)
        {
            return MathUtility.Process(Expression.Add, a, b);
        }

        [TestCase(0, 0, Result = 0d)]
        [TestCase(8, 3, Result = 11d)]
        public object AddWithDecimalWorks(decimal a, decimal b)
        {
            return MathUtility.Process(Expression.Add, a, b);
        }

        [TestCase(0, 0, Result = 0d)]
        [TestCase(8, 2.0, Result = 10)]
        [TestCase(8, 2L, Result = 10)]
        public object AddWithDecimalWorks(decimal a, object b)
        {
            return MathUtility.Process(Expression.Add, a, b);
        }

        [TestCase(0, 0, Result = 0d)]
        [TestCase(8d, 2.0, Result = 10)]
        [TestCase(8f, 2, Result = 10)]
        public object AddWithDecimalWorks(object a, decimal b)
        {
            return MathUtility.Process(Expression.Add, a, b);
        }

        [TestCase(19d, 39, Result = -20d)]
        public object MinusTests(object a, object b)
        {
            return MathUtility.Process(Expression.Subtract, a, b);
        }
    }
}