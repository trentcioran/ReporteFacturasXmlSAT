using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Receptor
    {
        [XmlElement(ElementName = "Domicilio", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Domicilio Domicilio { get; set; }
        [XmlAttribute(AttributeName = "rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "nombre")]
        public string Nombre { get; set; }
    }
}