using System.Xml.Linq;

namespace BookImport
{
    public class XMLBookReader : IBookReader
    {
        public IEnumerable<Book> GetBooks(string fileContent)
        {
            try
            {
                var document = XDocument.Parse(fileContent);
                var books = from b in document.Descendants("book")
                            select new Book
                            {
                                Category = b.Attribute("category").Value,
                                Title = b.Element("title").Value,
                                Authors = b.Elements("author").Select(e => e.Value).ToList(),
                                Price = decimal.Parse(b.Element("price").Value)
                            };

                return books;
            }
            catch (Exception)
            {

                throw new Exception("Book xml could not be parsed.");
            }

        }

    }
}