namespace BookImport
{
    public class BooksImport
    {
        readonly IBookReader BookReader;
        readonly IBookSaver BookSaver;
        readonly IFileDownloader FileDownloader;

        public BooksImport(IFileDownloader downloader, IBookReader reader, IBookSaver saver)
        {
            BookReader = reader;
            BookSaver = saver;
            FileDownloader = downloader;
        }


        public void ImportBooks()
        {
            var fileContent = FileDownloader.DownloadFile();
            var books = BookReader.GetBooks(fileContent);
            BookSaver.SaveBooks(books);
        }

    }
}