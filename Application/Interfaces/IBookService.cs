using Application.DTOs.Book;
using Application.Responses;
using Domain.Models;

namespace Application.Interfaces;

public interface IBookService
{
    Task<ApiResponse<bool>> AddBook(BookCreateDto book);
    Task<ApiResponse<bool>> UpdateBook(int id, BookUpdateDto book);
    Task<ApiResponse<bool>> DeleteBook(int id);
    Task<ApiResponse<BookResponseDto>> GetBook(int id);
    Task<ApiResponse<List<BookResponseDto>>> GetBooks();
} 
