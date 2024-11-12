namespace YMYP_ASSESSMENT_1.Models.Services.Dtos
{
    public record AddBookRequest(string Title, string Author, int PublicationYear, string ISBN, string Genre, string Publisher, int PageCount, int AvailableCopies, string Language, string Summary);
    
}
