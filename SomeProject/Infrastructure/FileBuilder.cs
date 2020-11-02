using Core;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

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

                csvWriter.Configuration.AutoMap<T>();
                csvWriter.WriteRecords(records);
            }

            return memoryStream.ToArray();
        }
        #endregion

        #region PDF
        public byte[] ToPdf(IEnumerable<T> records)
        {
            throw new NotImplementedException();
        }

        public byte[] ToPdf(string html)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
