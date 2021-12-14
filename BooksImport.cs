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

        //Book Import is now a collection of actions. The class itself does not need to know
        //the intricacies of implementation
        public void ImportBooks()
        {
            var fileContent = FileDownloader.DownloadFile();
            var books = BookReader.GetBooks(fileContent);
            BookSaver.SaveBooks(books);
        }

    }
}