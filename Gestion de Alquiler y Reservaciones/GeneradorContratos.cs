using System;
using System.Collections.Generic;
using System.IO;
using Xceed.Words.NET;

namespace ProyectoInversion // Pon el nombre exacto de tu proyecto aquí
{
    public enum TipoContrato
    {
        Apartamento,
        Local,
        Auditorio,
        CasaPlaya
    }

    public class GeneradorContratos
    {
        public void GenerarDocumento(TipoContrato tipo, Dictionary<string, string> valores, string rutaDestinoDocx)
        {
            string rutaBase = AppDomain.CurrentDomain.BaseDirectory + @"Plantillas\";
            string nombreArchivo = "";

            // Asignamos la plantilla según el tipo
            switch (tipo)
            {
                case TipoContrato.Apartamento: nombreArchivo = "CONTRATO APARTAMENTOS.docx"; break;
                case TipoContrato.Local: nombreArchivo = "CONTRATOS LOCALES.docx"; break;
                case TipoContrato.Auditorio: nombreArchivo = "CONTRATO AUDITORIO-SALA.docx"; break;
                case TipoContrato.CasaPlaya: nombreArchivo = "CONTRATO CASAS.docx"; break;
            }

            string rutaPlantilla = rutaBase + nombreArchivo;

            if (!File.Exists(rutaPlantilla))
            {
                throw new FileNotFoundException("Error: No se encontró la plantilla en: " + rutaPlantilla);
            }

            // Proceso funcional de reemplazo
            using (DocX documento = DocX.Load(rutaPlantilla))
            {
                foreach (var item in valores)
                {
                    documento.ReplaceText(item.Key, item.Value);
                }

                documento.SaveAs(rutaDestinoDocx);
            }
        }
    }
}
