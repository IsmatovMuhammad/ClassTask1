using Application.DTOs.Book;
using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;



[ApiController]
[Route("api/[controller]")]
public class BookControllers(
    IBookService service,
    ILogger<BookControllers> logger
    ) : ControllerBase
{
    private IBookService book = service;
    private ILogger<BookControllers> _logger = logger;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<BookResponseDto>>>> GetBooks()
    {
        _logger.LogInformation("List of Book {Time}", DateTime.Now);
        return await book.GetBooks();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddBook(BookCreateDto book1)
    {
        _logger.LogInformation("Book added {Time}", DateTime.Now);
        return await book.AddBook(book1);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteBook(int id)
    {
        _logger.LogInformation("Book deleted {Time}", DateTime.Now);
        return await book.DeleteBook(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateBook(int id, BookUpdateDto book1)
    {
        _logger.LogInformation("Book updated {Time}", DateTime.Now);
        return await book.UpdateBook(id, book1);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<BookResponseDto>>> GetBook(int id)
    {
        _logger.LogInformation("Book by id {Time}", DateTime.Now);
        return await book.GetBook(id);
    }
}
