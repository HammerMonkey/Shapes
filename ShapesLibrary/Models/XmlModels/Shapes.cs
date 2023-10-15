using System.Xml.Serialization;

namespace ShapesLibrary.Models.XmlModels
{
    [XmlRoot("shapes")]
    public class Shapes
    {
        [XmlElement("shape")]
        public List<Shape>? ShapesList { get; set; }
    }
}
