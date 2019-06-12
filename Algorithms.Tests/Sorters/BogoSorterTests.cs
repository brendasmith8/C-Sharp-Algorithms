﻿using Algorithms.Sorters;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;

namespace Algorithms.Tests.Sorters
{
    public class BogoSorterTests
    {
        private readonly BogoSorter<int> sorter = new BogoSorter<int>();
        private readonly Random random = new Random();

        [Test]
        [Parallelizable]
        public void ArraySorted([Random(0, 10, 100)]int n)
        {
            var testArray = new int[n];
            var correctArray = new int[n];
            for (var i = 0; i < n; i++)
            {
                var t = random.Next(0, 1000);
                testArray[i] = t;
                correctArray[i] = t;
            }

            var intComparer = new IntComparer();
            sorter.Sort(testArray, intComparer);
            Array.Sort(correctArray, intComparer);

            Assert.AreEqual(testArray, correctArray);
        }

        private class IntComparer : IComparer<int>
        {
            public int Compare(int x, int y) => x.CompareTo(y);
        }
    }
}
