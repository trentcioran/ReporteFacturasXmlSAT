using System;

namespace ReporteFacturasXmlSAT.Xml
{
    public class ReportRecord
    {
        public string FacturaArchivo { get; set; }

        public string EmisorNombre { get; set; }

        public string EmisorRfc { get; set; }

        public string ImpuestosTotal { get; set; }

        public string ImpuestosIvaTasa { get; set; }

        public string ImpuestosIvaImporte { get; set; }

        public string TipoIngreso { get; set; }

        public string Total { get; set; }

        public string Descuento { get; set; }

        public string SubTotal { get; set; }

        public string FormaPago { get; set; }

        public string Fecha { get; set; }
    }
}