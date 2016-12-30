using System.Collections.Generic;
using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Conceptos", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Conceptos
    {
        [XmlElement(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public List<Concepto> Concepto { get; set; }
    }
}