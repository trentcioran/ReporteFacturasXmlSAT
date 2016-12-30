using System.Xml.Serialization;

namespace ReporteFacturasXmlSAT.Xml
{
    [XmlRoot(ElementName = "Concepto", Namespace = "http://www.sat.gob.mx/cfd/3")]
    public class Concepto
    {
        [XmlAttribute(AttributeName = "importe")]
        public string Importe { get; set; }

        [XmlAttribute(AttributeName = "valorUnitario")]
        public string ValorUnitario { get; set; }

        [XmlAttribute(AttributeName = "descripcion")]
        public string Descripcion { get; set; }

        [XmlAttribute(AttributeName = "unidad")]
        public string Unidad { get; set; }

        [XmlAttribute(AttributeName = "cantidad")]
        public string Cantidad { get; set; }
    }
}