using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "TimbreFiscalDigital", Namespace = "http://www.sat.gob.mx/TimbreFiscalDigital")]
    public class TimbreFiscalDigital
    {
        [XmlAttribute(AttributeName = "tfd", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Tfd { get; set; }
        [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
        public string SchemaLocation { get; set; }
        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
        [XmlAttribute(AttributeName = "UUID")]
        public string UUID { get; set; }
        [XmlAttribute(AttributeName = "FechaTimbrado")]
        public string FechaTimbrado { get; set; }
        [XmlAttribute(AttributeName = "selloCFD")]
        public string SelloCFD { get; set; }
        [XmlAttribute(AttributeName = "noCertificadoSAT")]
        public string NoCertificadoSAT { get; set; }
        [XmlAttribute(AttributeName = "selloSAT")]
        public string SelloSAT { get; set; }
    }
}