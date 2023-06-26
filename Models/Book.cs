namespace BookStore.Models
{
    public class Book
    {
        public string Title { get; set; }   
        public string ISBN { get; set; }
        public string AuthorName { get; set; }
        public string BookVersion { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
