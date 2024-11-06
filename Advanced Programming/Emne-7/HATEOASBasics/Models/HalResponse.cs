namespace HATEOASBasics.Models;

public class HalResponse
{
    public List<Link> Links { get; set; } = [];
}

public class Link
{
    public required string? Href { get; set; }
    public required string Rel { get; set; }
    public required string HttpMethod { get; set; }
}