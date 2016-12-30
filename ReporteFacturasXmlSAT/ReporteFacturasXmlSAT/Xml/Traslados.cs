using System.Collections.Generic;
using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Traslados", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Traslados
    {
        [XmlElement(ElementName = "Traslado", Namespace = "http://www.sat.gob.mx/cfd/3")]
        public List<Traslado> Traslado { get; set; }
    }
}