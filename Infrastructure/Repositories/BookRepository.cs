using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class BookRepository(Database database) : IBookRepository
{
    private Database data = database;

    public async Task<bool> AddBook(Book book)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"insert into book(title, publishedyear, totalCopies)values(@title, @publishedyear, @totalcopies)";

        var b = await conn.ExecuteAsync(query, conn);
        return b > 0;
    }

    public async Task<bool> DeleteBook(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"delete from book where id = @id";
        var b = await conn.ExecuteAsync(query, new { id });
        return b > 0;
    }

    public async Task<Book> GetBook(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"select * from book where id = @id";
        var b = await conn.QuerySingleAsync<Book>(query, new { id });
        return b;
    }

    public async Task<List<Book>> GetBooks()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from book";
        var b = await conn.QueryAsync<Book>(query);
        return b.ToList();
    }

    public async Task<bool> UpdateBook(Book book)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"update book set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        var b = await conn.ExecuteAsync(query, book);
        return b > 0;
    }

}
