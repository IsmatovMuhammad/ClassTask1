using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBook(Book book);
    Task<ApiResponse<bool>> UpdateBook(Book book);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<Book>> GetBook(int id);
    Task<ApiResponse<List<Book>>> GetBooks();
} 
