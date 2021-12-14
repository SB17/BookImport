namespace BookImport
{
    public class Book
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public List<string> Authors { get; set; }
        public decimal  Price { get; set; }
    }
}