using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Comprobante", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Comprobante
    {
        [XmlElement(ElementName = "Emisor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Emisor Emisor { get; set; }
        [XmlElement(ElementName = "Receptor", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Receptor Receptor { get; set; }
        [XmlElement(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Conceptos Conceptos { get; set; }
        [XmlElement(ElementName = "Impuestos", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Impuestos Impuestos { get; set; }
        [XmlElement(ElementName = "Complemento", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public Complemento Complemento { get; set; }
        [XmlAttribute(AttributeName = "cfdi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Cfdi { get; set; }
        [XmlAttribute(AttributeName = "xsi", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Xsi { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "serie")]
        public string Serie { get; set; }
        [XmlAttribute(AttributeName = "folio")]
        public string Folio { get; set; }
        [XmlAttribute(AttributeName = "fecha")]
        public string Fecha { get; set; }
        [XmlAttribute(AttributeName = "formaDePago")]
        public string FormaDePago { get; set; }
        [XmlAttribute(AttributeName = "subTotal")]
        public string SubTotal { get; set; }
        [XmlAttribute(AttributeName = "descuento")]
        public string Descuento { get; set; }
        [XmlAttribute(AttributeName = "total")]
        public string Total { get; set; }
        [XmlAttribute(AttributeName = "metodoDePago")]
        public string MetodoDePago { get; set; }
        [XmlAttribute(AttributeName = "tipoDeComprobante")]
        public string TipoDeComprobante { get; set; }
        [XmlAttribute(AttributeName = "LugarExpedicion")]
        public string LugarExpedicion { get; set; }
        [XmlAttribute(AttributeName = "NumCtaPago")]
        public string NumCtaPago { get; set; }
        [XmlAttribute(AttributeName = "noCertificado")]
        public string NoCertificado { get; set; }
        [XmlAttribute(AttributeName = "certificado")]
        public string Certificado { get; set; }
        [XmlAttribute(AttributeName = "sello")]
        public string Sello { get; set; }
    }
}