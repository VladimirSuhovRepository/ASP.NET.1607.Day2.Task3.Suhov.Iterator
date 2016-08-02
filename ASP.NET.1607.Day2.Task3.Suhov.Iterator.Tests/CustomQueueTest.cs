using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASP.NET._1607.Day2.Task3.Suhov.Iterator.Tests
{
    [TestClass]
    public class CustomQueueTest
    {
        [TestMethod]
        public void TestEnqueue()
        {
            // Arrange
            var array = new int[] { 1,2,3,4,5,6 };
            // Act
            var query = new CustomQueue<int>(array);
            query.Enqueue(7);
            var arrayCheck = new int[] { 1, 2, 3, 4, 5, 6, 7};
            // Assert
            var iterator = query.Iterator();
            int i = 0;
            while (iterator.MoveNext())
            {
                Assert.AreEqual(iterator.Current, arrayCheck[i]);
                i++;
            }
        }

        [TestMethod]
        public void TestDequeue()
        {
            // Arrange
            var array = new int[] { 1, 2, 3, 4, 5, 6 };
            // Act
            var query = new CustomQueue<int>(array);
            query.Dequeue();
            var arrayCheck = new int[] {0, 2, 3, 4, 5, 6 };
            // Assert
            var iterator = query.Iterator();
            int i = 0;
            while (iterator.MoveNext())
            {
                Assert.AreEqual(iterator.Current, arrayCheck[i]);
                i++;
            }
        }
        [TestMethod]
        public void TestPeek()
        {
            // Arrange
            var array = new int[] { 1, 2, 3, 4, 5, 6 };
            // Act
            var query = new CustomQueue<int>(array);
            var item=query.Peek();
            // Assert
            Assert.AreEqual(item,1);
        }

    }
}
