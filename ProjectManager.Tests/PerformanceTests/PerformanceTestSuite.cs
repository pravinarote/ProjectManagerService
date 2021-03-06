﻿using NBench.Reporting.Targets;
using NBench.Sdk;
using NBench.Sdk.Compiler;
using NUnit.Framework;
using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;

namespace ProjectManager.Tests.PerformanceTests
{
    [Ignore("a")]
    public class PerformanceTestSuite<T>
    {
        [TestCaseSource(nameof(Benchmarks))]
        public void PerformanceTest(Benchmark benchmark)
        {
            Benchmark.PrepareForRun();
            benchmark.Run();
            benchmark.Finish();
        }

        public static IEnumerable Benchmarks()
        {
            var discovery = new ReflectionDiscovery(new ActionBenchmarkOutput(reports => { }, results =>
            {
                foreach (var assertion in results.AssertionResults)
                {
                    Assert.True(assertion.Passed, results.BenchmarkName + " " + assertion.Message);
                }
            }));

            var benchmarks = discovery.FindBenchmarks(typeof(T)).ToList();

            foreach (var benchmark in benchmarks)
            {
                var name = benchmark.BenchmarkName.Split('+')[1];
                yield return new TestCaseData(benchmark).SetName(name);
            }
        }
    }

    public class nameof<T>
    {
        public static string Property<TProp>(Expression<Func<T, TProp>> expression)
        {
            var body = expression.Body as MemberExpression;
            if (body == null)
                throw new ArgumentException("'expression' should be a member expression");
            return body.Member.Name;
        }
    }
}
