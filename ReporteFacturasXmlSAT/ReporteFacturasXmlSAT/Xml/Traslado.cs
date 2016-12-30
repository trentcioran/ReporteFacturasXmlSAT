using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Traslado
    {
        [XmlAttribute(AttributeName = "impuesto")]
        public string Impuesto { get; set; }

        [XmlAttribute(AttributeName = "tasa")]
        public string Tasa { get; set; }

        [XmlAttribute(AttributeName = "importe")]
        public string Importe { get; set; }
    }
}