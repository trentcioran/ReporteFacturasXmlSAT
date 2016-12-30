using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "RegimenFiscal", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class RegimenFiscal
    {
        [XmlAttribute(AttributeName = "Regimen")]
        public string Regimen { get; set; }
    }
}