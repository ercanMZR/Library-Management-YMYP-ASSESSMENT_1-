namespace YMYP_ASSESSMENT_1.Models.Services.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;

        public string Author { get; set; }

        public int PublicationYear { get; set; }

        public string ISBN { get; set; }

        public string Genre { get; set; }

        public string Language { get; set; }

        public string Summary { get; set; }

        public int AvailableCopies { get; set; }
    }
}
