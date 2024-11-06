using HATEOASBasics.Models;
using Microsoft.AspNetCore.Mvc;

namespace HATEOASBasics.Controllers;

[ApiController]
[Route("[controller]")]
public class BooksController(LinkGenerator linkGenerator) : ControllerBase
{
    private static readonly List<BookResponse> Books =
    [
        new()
        {
            Id = 1,
            Title = "The Lord of the Rings",
            Author = "J.R.R. Tolkien"
        }
    ];
    
    [HttpGet("GetBooks")]
    public ActionResult<IEnumerable<BookResponse>> GetBooksAsync()
    {
        return Ok(Books);
    }
    
    [HttpGet("GetBooks/{id:int}")]
    public ActionResult<BookResponse> GetBooksById(int id)
    {
        BookResponse? bookResponse = Books.FirstOrDefault(book => book.Id == id);
        if (bookResponse is null)
            return BadRequest("Book not found");
        
        //HATEOAS
        bookResponse.Links.Add(
            new Link
            {
                Href = linkGenerator.GetPathByAction(
                    HttpContext, 
                    action: nameof(GetBooksById),
                    values: new { id = bookResponse.Id }),
                Rel = "self",
                HttpMethod = "GET"
            });

        return Ok(bookResponse);
    }
}