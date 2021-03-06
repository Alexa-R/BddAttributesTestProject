﻿using System.Collections.Generic;
using System.Xml;
using BddAttributesTestProject.Helpers;
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
        public void CompareNumberPairs(int value1, int value2)
        {
            Assert.Equal(value1, value2);
        }

        [Theory]
        [MemberData(nameof(GetNumbersXmlData))]
        public void MultiplyOnTwo(int value1, int value2, int expected)
        {
            Assert.Equal(expected, value1 * value2);
        }

        public static IEnumerable<object[]> GetNumbersData
        {
            get
            {
                return new[]
                {
                    new object[] { 1, 1 },
                    new object[] { -1, -1 },
                    new object[] { 0, 0 },
                    new object[] { 99, 99 },
                    new object[] { int.MinValue, int.MinValue },
                    new object[] { int.MaxValue, int.MaxValue }
                };
            }
        }

        public static IEnumerable<object[]> GetNumbersXmlData()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(
                "C://Users//Alexa//source//repos//BddAttributesTestProject//BddAttributesTestProject//UnitTestsData//MultiplyOnTwoData.xml");
            IEnumerable<object[]> xmlData = null;

            if (xmlDoc.DocumentElement != null)
            {
                var nodeList = xmlDoc.DocumentElement.SelectNodes("/NumbersGroups/NumbersGroup");
                xmlData = XmlDocReaderHelper.ReadSingleNodes(nodeList, "Number1", "Number2", "Expected");
            }

            return xmlData;
        }
    }
}