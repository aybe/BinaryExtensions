using System;
using System.IO;
using BinaryExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryExtensionsTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FullyReadStreamHasNoIntersectRegions()
        {
            var buffer = new byte[1000];
            var random = new Random(0);
            random.NextBytes(buffer);
            using var source = new MemoryStream(buffer);
            using var target = new LogStream(source);
            using var reader = new BinaryReader(target);
            reader.ReadToEnd();
            var intersect = target.GetRegionsReadIntersect();
            Assert.IsTrue(intersect.Count == 0);
        }
    }
}