namespace YourBooksStore.Core
{
    public class Book
    {
        public int ISN { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public Category Category { get; set; }
    }

}