using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Impuestos
    {
        [XmlElement(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Traslados Traslados { get; set; }

        [XmlAttribute(AttributeName = "totalImpuestosTrasladados")]
        public string TotalImpuestosTrasladados { get; set; }
    }
}