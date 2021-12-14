namespace BookImport
{
    public class Program
    {
        /**
         * 1. I have split the monolithic BookImport class into multiple classes each fulfilling a single
         *    responsibility. These classes are implementation of generic interfaces.
         *    For example, XMLBookReader implements IBookReader and provides implementation of reading Books 
         *    from an XML file. This can be substituted for a JSONBookReader (in case we start getting Books
         *    in JSON)
         * 2. All the classes now implement Dependency Injection.
         * 3. The initial implementation was devoid of any error handling. That has been rectified.
         */
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
