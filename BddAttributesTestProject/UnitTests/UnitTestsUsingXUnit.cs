using System.Collections.Generic;
using System.Xml;
using Xunit;

namespace BddAttributesTestProject.UnitTests
{
    public class UnitTestsUsingXUnit
    {
        [Theory]
        [InlineData(6, 1, 6)]
        [InlineData(6, 2, 12)]
        [InlineData(6, 3, 18)]
        [InlineData(6, 4, 24)]
        [InlineData(6, 5, 30)]
        [InlineData(6, 6, 36)]
        [InlineData(6, 7, 42)]
        [InlineData(6, 8, 48)]
        [InlineData(6, 9, 54)]
        [InlineData(6, 10, 60)]
        public void MultiplyOnSix(int value1, int value2, int expected)
        {
            Assert.Equal(expected, value1 * value2);
        }


        [Theory]
        [MemberData(nameof(GetNumbersData))]
        public void СompareNumberPairs(int value1, int value2)
        {
            Assert.Equal(value1, value2);
        }

        public static IEnumerable<object[]> GetNumbersData
        {
            get
            {
                return new[]
                {
                    new object[] {1, 1},
                    new object[] {-1, -1},
                    new object[] {0, 0},
                    new object[] {99, 99},
                    new object[] {int.MinValue, int.MinValue},
                    new object[] {int.MaxValue, int.MaxValue}
                };
            }
        }


        [Theory]
        [MemberData(nameof(GetNumbersXmlData))]
        public void MultiplyOnTwo(int value1, int value2, int expected)
        {
            var actual = value1 * value2;

            Assert.Equal(expected, actual);
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