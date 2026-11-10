using System.Data.Common;
using System.Diagnostics;
using System.Net;
using Application.DTOs.Book;
using Application.Interfaces;
using Application.Responses;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Repositories;

namespace Application.Services;

public class BookService(IBookRepository repository1) : IBookService
{
    private IBookRepository repository = repository1;

    public async Task<ApiResponse<bool>> AddBook(BookCreateDto book)
    {
        var book1 = new Book()
        {
            Title = book.Title,
            PublishedYear = book.PublishedYear,
            TotalCopies = book.TotalCopies
        };
        var res = await repository.AddBook(book1);
        return res == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Book added !", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Book not added !");
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var conn = await repository.DeleteBook(id);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deleted !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not Deleted !", conn);
    }

    public async Task<ApiResponse<BookResponseDto>> GetBook(int id)
    {
        var bo = await repository.GetBook(id);
        var book = new BookResponseDto
        {
            Title = bo.Title,
            PublishedYear = bo.PublishedYear,
            TotalCopies = bo.TotalCopies
        };
        return new ApiResponse<BookResponseDto>(HttpStatusCode.OK, "Book by id", book);
    }

    public async Task<ApiResponse<List<BookResponseDto>>> GetBooks()
    {
        var book = await repository.GetBooks();
        var book1 = book.Select(s => new BookResponseDto
        {
            Id = s.Id,
            Title = s.Title,
            PublishedYear = s.PublishedYear,
            TotalCopies = s.TotalCopies
        }).ToList();
        return new ApiResponse<List<BookResponseDto>>(HttpStatusCode.OK, "List of book", book1);
    }

    public async Task<ApiResponse<bool>> UpdateBook(int id, BookUpdateDto book)
    {
        var book1 = new Book()
        {
            Id = id,
            Title = book.Title,
            PublishedYear = book.PublishedYear,
            TotalCopies = book.TotalCopies
        };
        var conn = await repository.UpdateBook(book1);
        return conn == true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Book updated !", conn)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Book not update !");
    }

}
