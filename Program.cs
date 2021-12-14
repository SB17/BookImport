namespace BookImport
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var url = "https://www.w3schools.com/xml/books.xml";
            var connString = String.Empty;

            IFileDownloader fileDownloader = new WebClientDownloader(url);
            IBookReader bookReader = new XMLBookReader();
            IBookSaver bookSaver = new DatabaseBookSaver(connString);
            var booksImport = new BooksImport(fileDownloader, bookReader, bookSaver);
            booksImport.ImportBooks();
        }
    }

}
