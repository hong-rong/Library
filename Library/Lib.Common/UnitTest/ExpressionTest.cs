using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Lib.Common.UnitTest
{
    public class Entity
    {
        public int Age { get; set; }
        public int Count { get; set; }
    }

    public class ExpressionTest
    {
        public void Test()
        {
            Func<Entity, int> query = e => e.Count;

            var mockData = new List<Entity>
                {
                    new Entity() {Age = 20,Count = 1},
                    new Entity() {Age = 40,Count = 1},
                    new Entity() {Age = 60,Count = 1},
                };

            int a = mockData.Max(e => e.Count);
            int b = mockData.Max(query);
        }
    }
}