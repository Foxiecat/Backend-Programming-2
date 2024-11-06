namespace HATEOASBasics.Models;

public class BookResponse : HalResponse
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Author { get; set; }
}