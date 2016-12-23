using BenchmarkDotNet.Attributes;
using DotLiquid;
using DotLiquid.Util;
using System;
using System.Linq.Expressions;

namespace Benchmarks
{
    public class RawVsStandard
    {
        private static readonly Random rnd = new Random(8574);

        private decimal a = (decimal)rnd.NextDouble();
        private double b = rnd.NextDouble();
        private Delegate cachedExpression;

        public RawVsStandard()
        {
            cachedExpression = ExpressionUtility.CreateExpression(
                body: Expression.Add,
                leftType: typeof(decimal),
                rightType: typeof(double),
                resultType: typeof(double),
                castArgsToResultOnFailure: true);
        }

        [Benchmark]
        public double Raw() => (double)a + b;

        [Benchmark]
        public object FilterDoubleDouble() => StandardFilters.Plus((double)a, b);

        [Benchmark]
        public object FilterDecimalDouble() => StandardFilters.Plus(a, b);

        [Benchmark]
        public object CachedExpression()
        {
            return cachedExpression.DynamicInvoke(a, b);
        }

        [Benchmark]
        public object DynamicExpression()
        {
            var expression = ExpressionUtility.CreateExpression(
                body: Expression.Add,   
                leftType: ((object)a).GetType(),
                rightType: ((object)b).GetType(),
                resultType: ((object)a).GetType(),
                castArgsToResultOnFailure: true);

            return expression.DynamicInvoke(a, b);
        }
    }
}