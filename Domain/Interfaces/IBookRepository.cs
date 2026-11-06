using Domain.Models;

namespace Domain.Interfaces;

public interface IBookRepository
{
    Task<bool> AddBook(Book book);
    Task<bool> UpdateBook(Book book);
    Task<bool> DeleteBook(int id);
    Task<Book> GetBook(int id);
    Task<List<Book>> GetBooks();
}
