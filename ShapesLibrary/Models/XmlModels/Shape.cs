using System.Xml.Serialization;

namespace ShapesLibrary.Models.XmlModels
{
    public class Shape
    {
        [XmlElement("type")]
        public string? Type { get; set; }

        [XmlElement("a")]
        public double? A { get; set; }

        [XmlElement("b")]
        public double? B { get; set; }

        [XmlElement("c")]
        public double? C { get; set; }
    }
}
