using Microsoft.AspNetCore.Mvc;
using TheLiblary.Domain.Entities;
using TheLiblary.Service.Interfaces;

namespace TheLiblary.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost("create")]
    public Book Create([FromBody] Book book)
    {
        return _bookService.Create(book);
    }

    [HttpDelete("delete/{id}")]
    public bool Delete(long id)
    {
        return _bookService.Delete(id);
    }

    [HttpGet("getbyid/{id}")]
    public Book GetById(long id)
    {
        return _bookService.GetById(id);
    }

    [HttpGet("getbystudentidandbookid")]
    public IEnumerable<Book> GetByStudentIdAndBookId([FromQuery] long studentId)
    {
        return _bookService.GetByStudentIdAndBookId(studentId);
    }

    [HttpPut("update")]
    public Book Update([FromBody] Book book)
    {
        return _bookService.Update(book);
    }

    [HttpPost("cancellationofrent")]
    public bool CancellationOfRent(long id, long studentId)
    {
        return _bookService.CancellationOfRent(id, studentId);
    }

    [HttpGet("renttextbooks")]
    public bool RentTextbooks(long id, long studentId)
    {
        return _bookService.RentTextbooks(id, studentId);
    }
}
