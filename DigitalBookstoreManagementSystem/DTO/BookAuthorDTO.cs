namespace DigitalBookstoreManagementSystem.DTO
{
    public class BookAuthorDTO
    {

        public int BookID { get; set; }
        public required string Title { get; set; }
        public required double Price { get; set; }
        public required int StockQuantity { get; set; }
        public int AuthorID { get; set; }
        public string AuthorName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
    }
}

