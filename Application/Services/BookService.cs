using System.Diagnostics;
using System.Net;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class BookService(IBookRepository repository) : IBookService
{
    private IBookRepository data = repository;

    public async Task<ApiResponse<bool>> AddBook(Book book)
    {
        var conn = await data.AddBook(book);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Added !", conn);
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var conn = await data.DeleteBook(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<Book>> GetBook(int id)
    {
        var conn = await data.GetBook(id);
        return new ApiResponse<Book>(HttpStatusCode.OK, "Book with given id.", conn);
    }

    public async Task<ApiResponse<List<Book>>> GetBooks()
    {
        var conn = await data.GetBooks();
        return new ApiResponse<List<Book>>(HttpStatusCode.OK, "List of books", conn);
    }

    public async Task<ApiResponse<bool>> UpdateBook(Book book)
    {
        var conn = await data.UpdateBook(book);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Update !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Updated !", conn);
    }

}
