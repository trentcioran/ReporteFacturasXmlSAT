using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using CsvHelper;

namespace ReporteFacturasXmlSAT.Xml
{
    public class DirectoryProcessor
    {
        public void ProcessDirectory(string directory, Action<string> Log)
        {
            Log("Obteniendo los archivos a procesar...");

            string[] files = Directory.GetFiles(directory, "*.xml",
                SearchOption.AllDirectories);

            Log(string.Format("Encontre [{0}] archivos", files.Length));

            List<ReportRecord> records = new List<ReportRecord>();
            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
            foreach (string file in files)
            {
                Log(string.Format("Procesando archivo: {0}", file));
                using (StreamReader reader = new StreamReader(file))
                {
                    Comprobante record = (Comprobante)serializer.Deserialize(reader);

                    records.Add(new ReportRecord
                    {
                        FacturaArchivo = Path.GetFileNameWithoutExtension(file),
                        EmisorNombre = record.Emisor.Nombre,
                        EmisorRfc = record.Emisor.Rfc,
                        ImpuestosTotal = record.Impuestos.TotalImpuestosTrasladados,
                        ImpuestosIvaTasa = GetImpuesto("IVA", record.Impuestos).Tasa,
                        ImpuestosIvaImporte = GetImpuesto("IVA", record.Impuestos).Importe,
                        Fecha = record.Fecha,
                        FormaPago = record.FormaDePago,
                        Descuento = record.Descuento,
                        TipoIngreso = record.TipoDeComprobante,
                        SubTotal = record.SubTotal,
                        Total = record.Total
                    });
                }
            }

            var reportPath = Path.Combine(directory, "Reporte.csv");
            using (var stream = File.CreateText(reportPath))
            using (var writer = new CsvWriter(stream))
            {
                writer.WriteRecords(records);
            }
        }

        private Traslado GetImpuesto(string impuesto, Impuestos impuestos)
        {
            if (impuestos.Traslados == null || impuestos.Traslados.Traslado.Count == 0)
            {
                return new Traslado
                {
                    Importe = string.Empty,
                    Tasa = string.Empty
                };
            }

            Traslado imp = impuestos.Traslados
                .Traslado
                .FirstOrDefault(x => x.Impuesto.ToLowerInvariant().Equals(impuesto.ToLowerInvariant()));

            if (imp == null)
            {
                return new Traslado
                {
                    Importe = string.Empty,
                    Tasa = string.Empty
                };
            }

            return imp;
        }
    }
}