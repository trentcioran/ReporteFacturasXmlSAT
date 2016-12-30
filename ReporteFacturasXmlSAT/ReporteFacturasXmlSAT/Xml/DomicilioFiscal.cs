using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "DomicilioFiscal", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class DomicilioFiscal
    {
        [XmlAttribute(AttributeName = "calle")]
        public string Calle { get; set; }
        [XmlAttribute(AttributeName = "noExterior")]
        public string NoExterior { get; set; }
        [XmlAttribute(AttributeName = "noInterior")]
        public string NoInterior { get; set; }
        [XmlAttribute(AttributeName = "colonia")]
        public string Colonia { get; set; }
        [XmlAttribute(AttributeName = "municipio")]
        public string Municipio { get; set; }
        [XmlAttribute(AttributeName = "estado")]
        public string Estado { get; set; }
        [XmlAttribute(AttributeName = "pais")]
        public string Pais { get; set; }
        [XmlAttribute(AttributeName = "codigoPostal")]
        public string CodigoPostal { get; set; }
    }
}