using System.Collections.Generic;
using System.Xml;

namespace BddAttributesTestProject.Helpers
{
    public static class XmlDocReader
    {
        public static IEnumerable<object[]> ReadSingleNode(XmlNodeList nodeList, params string[] nodeNames)
        {
            if (nodeList != null)
            {
                foreach (XmlNode node in nodeList)
                {
                    var nodesArray = new object[3];

                    for (var i = 0; i < nodeNames.Length; i++)
                    {
                        var value = int.Parse(node.SelectSingleNode((string) nodeNames.GetValue(i)).InnerText);
                        nodesArray[i] = value;
                    }

                    yield return nodesArray;
                }
            }
        }
    }
}