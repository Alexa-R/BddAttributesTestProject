using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BddAttributesTestProject.UnitTests
{
    [TestClass]
    public class UnitTestsUsingMsTeam
    {
        public TestContext TestContext { get; set; }

        [DataTestMethod]
        [DataRow(6, 1, 6)]
        [DataRow(6, 2, 12)]
        [DataRow(6, 3, 18)]
        [DataRow(6, 4, 24)]
        [DataRow(6, 5, 30)]
        [DataRow(6, 6, 36)]
        [DataRow(6, 7, 42)]
        [DataRow(6, 8, 48)]
        [DataRow(6, 9, 54)]
        [DataRow(6, 10, 60)]
        public void MultiplyOnSix(int value1, int value2, int expected)
        {
            Assert.AreEqual(expected, value1 * value2);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetNumbersData), DynamicDataSourceType.Method)]
        public void СompareNumberPairs(int value1, int value2)
        {
            Assert.AreEqual(value1, value2);
        }

        public static IEnumerable<object[]> GetNumbersData()
        {
            yield return new object[] {1, 1};
            yield return new object[] {-1, -1};
            yield return new object[] {0, 0};
            yield return new object[] {99, 99};
            yield return new object[] {int.MinValue, int.MinValue};
            yield return new object[] {int.MaxValue, int.MaxValue};
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "C://Users//Alexa//source//repos//BddAttributesTestProject//BddAttributesTestProject//UnitTestsData//MultiplyOnTwoData.xml",
            "NumbersGroup", DataAccessMethod.Sequential)]
        public void MultiplyOnTwo()
        {
            int value1 = int.Parse(TestContext.DataRow["Number1"].ToString());
            int value2 = int.Parse(TestContext.DataRow["Number2"].ToString());
            int expected = int.Parse(TestContext.DataRow["Expected"].ToString());

            var actual = value1 * value2;

            Assert.AreEqual(expected, actual);
        }
    }
}