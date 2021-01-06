using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace BddAttributesTestProject.UnitTests
{
    [TestFixture]
    public class UnitTestsUsingNUnit
    {
        [Test]
        [TestCase(6, 1, 6)]
        [TestCase(6, 2, 12)]
        [TestCase(6, 3, 18)]
        [TestCase(6, 4, 24)]
        [TestCase(6, 5, 30)]
        [TestCase(6, 6, 36)]
        [TestCase(6, 7, 42)]
        [TestCase(6, 8, 48)]
        [TestCase(6, 9, 54)]
        [TestCase(6, 10, 60)]
        public void MultiplyOnSix(int value1, int value2, int expected)
        {
            Assert.AreEqual(expected, value1 * value2);
        }

        [Test]
        [TestCaseSource(nameof(GetNumbersData))]
        public void СompareNumberPairs(int value1, int value2)
        {
            Assert.AreEqual(value1, value2);
        }

        public static IEnumerable<object[]> GetNumbersData =>
            new List<object[]>
            {
                new object[] {1, 1},
                new object[] {-1, -1},
                new object[] {0, 0},
                new object[] {99, 99},
                new object[] {int.MinValue, int.MinValue},
                new object[] {int.MaxValue, int.MaxValue}
            };


        [Test]
        [TestCaseSource(nameof(GetNumbersXmlData))]
        public void MultiplyOnTwo(int value1, int value2, int expected)
        {
            Assert.AreEqual(expected, value1 * value2);
        }

        public static IEnumerable<object[]> GetNumbersXmlData()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(
                "C://Users//Alexa//source//repos//BddAttributesTestProject//BddAttributesTestProject//UnitTestsData//MultiplyOnTwoData.xml");

            var nodeList = xmlDoc.DocumentElement?.SelectNodes("/NumbersGroups/NumbersGroup");

            if (nodeList == null) yield break;
            foreach (XmlNode node in nodeList)
            {
                var value1 = int.Parse(node.SelectSingleNode("Number1")?.InnerText ?? string.Empty);
                var value2 = int.Parse(node.SelectSingleNode("Number2")?.InnerText ?? string.Empty);
                var expected = int.Parse(node.SelectSingleNode("Expected")?.InnerText ?? string.Empty);

                yield return new object[] {value1, value2, expected};
            }
        }
    }
}