using Application.DTOs.Book;
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
    public async Task<ActionResult<ApiResponse<List<BookResponseDto>>>> GetBooks()
    {
        return await book.GetBooks();
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<bool>>> AddBook(BookCreateDto book1)
    {
        return await book.AddBook(book1);
    }

    [HttpDelete]
    public async Task<ActionResult<ApiResponse<bool>>> DeleteBook(int id)
    {
        return await book.DeleteBook(id);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<bool>>> UpdateBook(int id, BookUpdateDto book1)
    {
        return await book.UpdateBook(id, book1);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ApiResponse<BookResponseDto>>> GetBook(int id)
    {
        return await book.GetBook(id);
    }
}
