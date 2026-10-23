using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    public void AddBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = 
        $"insert into book(title, publishedyear, totalCopies)values(@title, @publishedyear, @totalcopies)";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("title", book.Title);
        cmd.Parameters.AddWithValue("publishedyear", book.PublishedYear);
        cmd.Parameters.AddWithValue("totalcopies", book.TotalCopies);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Book Added!");
    }

    public void DeleteBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from book where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Book deleted!");
    }

    public Book GetBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select id, title, publishedyear, totalcopies from books where id = @id";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("id", id);
        var data = cmd.ExecuteReader();
        var book = new Book();
        while (data.Read())
        {
            book.Id = data.GetInt32(0);
            book.Title = data.GetString(1);
            book.PublishedYear = data.GetInt32(2);
            book.TotalCopies = data.GetInt32(3);
        }
        return book;
    }

    public List<Book> GetBooks()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select id, title, publishedyear, totalcopies";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var books = new List<Book>();
        while (data.Read())
        {
            var book = new Book();
            book.Id = data.GetInt32(0);
            book.Title = data.GetString(1);
            book.PublishedYear = data.GetInt32(2);
            book.TotalCopies = data.GetInt32(3);
            books.Add(book); 
        }
        return books;
    }

    public void UpdateBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = 
        $"update books set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.Parameters.AddWithValue("title", book.Title);
        cmd.Parameters.AddWithValue("publishedyear", book.PublishedYear);
        cmd.Parameters.AddWithValue("totalcopies", book.TotalCopies);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Book updated!");
    }

}
