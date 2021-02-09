using Core;
using CsvHelper;
using IronPdf;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class FileBuilder<T> : IFileBuilder<T>
    {
        #region CSV
        public byte[] ToCsv(IEnumerable<T> records)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

                csvWriter.Configuration.Delimiter = ";";
                csvWriter.Configuration.AutoMap<T>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
        #endregion

        #region PDF
        public byte[] ToPdf(IEnumerable<T> records)
        {
            var Renderer = new HtmlToPdf();

            var type = typeof(T);
            var props = type.GetProperties();
            var html = new StringBuilder("<table>");

            // Header
            html.Append("<thead><tr>");
            foreach (var p in props)
                html.Append("<th>" + p.Name + "</th>");
            html.Append("</tr></thead>");

            // Body
            html.Append("<tbody>");
            foreach (var record in records)
            {
                html.Append("<tr>");
                props.Select(s => s.GetValue(record)).ToList().ForEach(p => {
                    html.Append("<td>" + p + "</td>");
                });
                html.Append("</tr>");
            }

            html.Append("</tbody>");
            html.Append("</table>");

            return Renderer.RenderHtmlAsPdf(html.ToString()).BinaryData;
        }

        public byte[] ToPdf(string html)
        {
            var Renderer = new HtmlToPdf();
            return Renderer.RenderHtmlAsPdf(html).BinaryData;
        }
        #endregion
    }
}
