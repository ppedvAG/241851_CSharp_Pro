namespace ASP_API
{
    public class Book
    {
        public int Id { get; set; }
        public string Titel { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int Pages { get; set; }
    }
}
