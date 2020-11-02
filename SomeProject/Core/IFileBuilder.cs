using System.Collections.Generic;

namespace Core
{
    public interface IFileBuilder<T>
    {
        byte[] ToCsv(IEnumerable<T> records);
        byte[] ToPdf(IEnumerable<T> records);
        byte[] ToPdf(string html);
    }
}
