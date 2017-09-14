using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using DevLib.Csv;

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

            CsvDocument csv = new CsvDocument();
            csv.HeaderColumns.Add("FacturaArchivo");
            csv.HeaderColumns.Add("EmisorNombre");
            csv.HeaderColumns.Add("EmisorRfc");
            csv.HeaderColumns.Add("ImpuestosTotal");
            csv.HeaderColumns.Add("ImpuestosIvaTasa");
            csv.HeaderColumns.Add("ImpuestosIvaImporte");
            csv.HeaderColumns.Add("TipoIngreso");
            csv.HeaderColumns.Add("Total");
            csv.HeaderColumns.Add("Descuento");
            csv.HeaderColumns.Add("SubTotal");
            csv.HeaderColumns.Add("FormaPago");
            csv.HeaderColumns.Add("Fecha");

            var data = csv.Table;

            XmlSerializer serializer = new XmlSerializer(typeof(Comprobante));
            foreach (string file in files)
            {
                Log($"Procesando archivo: {file}");
                using (StreamReader reader = new StreamReader(file))
                {
                    Comprobante record = (Comprobante)serializer.Deserialize(reader);

                    data.Add(new List<string>()
                        {
                            Path.GetFileNameWithoutExtension(file)??string.Empty,
                            record.Emisor.Nombre??string.Empty,
                            record.Emisor.Rfc??string.Empty,
                            record.Impuestos.TotalImpuestosTrasladados??string.Empty,
                            GetImpuesto("IVA", record.Impuestos).Tasa??string.Empty,
                            GetImpuesto("IVA", record.Impuestos).Importe??string.Empty,
                            record.Fecha??string.Empty,
                            record.FormaDePago??string.Empty,
                            record.Descuento??string.Empty,
                            record.TipoDeComprobante??string.Empty,
                            record.SubTotal??string.Empty,
                            record.Total??string.Empty
                        });
                }
            }

            var reportPath = Path.Combine(directory, "Reporte.csv");
            csv.Save(reportPath, true);
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
                .Where(x => x.Impuesto != null)
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