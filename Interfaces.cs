using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Have put all the interfaces in one file for brevity.
namespace BookImport
{
    public interface IFileDownloader
    {
        string DownloadFile();
    }

    public interface IBookReader
    {
        IEnumerable<Book> GetBooks(string fileContent);
    }

    public interface IBookSaver
    {
        void SaveBooks(IEnumerable<Book> books);
    }
}
