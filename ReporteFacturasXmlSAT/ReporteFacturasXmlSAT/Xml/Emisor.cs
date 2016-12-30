using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Emisor
    {
        [XmlElement(ElementName = "DomicilioFiscal", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public DomicilioFiscal DomicilioFiscal { get; set; }
        [XmlElement(ElementName = "ExpedidoEn", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public ExpedidoEn ExpedidoEn { get; set; }
        [XmlElement(ElementName = "RegimenFiscal", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public RegimenFiscal RegimenFiscal { get; set; }
        [XmlAttribute(AttributeName = "rfc")]
        public string Rfc { get; set; }
        [XmlAttribute(AttributeName = "nombre")]
        public string Nombre { get; set; }
    }
}