using Application.Interfaces;
using Application.Responses;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;



[ApiController]
[Route("api/[controller]")]
public class BookControllers(IBookService service) : ControllerBase
{
    private IBookService book = service;

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<Book>>>> GetBooks()
    {
        return await book.GetBooks();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddBook(Book book1)
    {
        return await book.AddBook(book1);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteBook(int id)
    {
        return await book.DeleteBook(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateBook(Book book1)
    {
        return await book.UpdateBook(book1);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<Book>>> GetBook(int id)
    {
        return await book.GetBook(id);
    }
}
