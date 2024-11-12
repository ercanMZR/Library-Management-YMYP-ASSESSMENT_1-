namespace YMYP_ASSESSMENT_1.Models.Services.Dtos
{
    public record UpdateBookRequest(
    int Id,
    string? Title = null,
    string? Author = null,
    int? PublicationYear = null,
    string? ISBN = null,
    string? Genre = null,
    string? Publisher = null,
    int? PageCount = null,
    string? Language = null,
    string? Summary = null,
    int? AvailableCopies = null
);

}
