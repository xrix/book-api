namespace Buku.API.Models
{
    public class BookResponse
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public int Year { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        // Navigation property
        public AuthorResponse AuthorResponse { get; set; }
        public StudentResponse StudentResponse { get; set; }
    }
}