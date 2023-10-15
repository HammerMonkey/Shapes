using ShapesLibrary.Models.XmlModels;
using System.Xml;
using System.Xml.Serialization;

namespace ShapesLibrary.Services
{
    public class XmlLoader
    {
        public static Shapes LoadShapesFromXml(string filePath)
        {
            using (var reader = XmlReader.Create(filePath))
            {
                var serializer = new XmlSerializer(typeof(Shapes));
                return (Shapes)serializer.Deserialize(reader)!;
            }
        }
    }
}
