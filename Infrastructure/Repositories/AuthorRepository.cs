using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    public void AddAuthor(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into authors(fullname, country, birthyear)values('{author.FullName}', '{author.Country}', {author.BirthYear})";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Author added!!");
    }

    public void DeleteAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from authors where id = {id}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Author deleted!!");
    }

    public Author GetAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select id, fullname, country, birthyear from authors where id = {id}";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var author = new Author();
        while (data.Read())
        {
            author.Id = data.GetInt32(0);
            author.FullName = data.GetString(1);
            author.Country = data.GetString(2);
            author.BirthYear = data.GetInt32(3);
        }
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select * from authors";
        var cmd = new NpgsqlCommand(query, conn);
        var data = cmd.ExecuteReader();
        var authors = new List<Author>();
        while (data.Read())
        {
            Author author = new();
            author.Id = data.GetInt32(0);
            author.FullName = data.GetString(1);
            author.Country = data.GetString(2);
            author.BirthYear = data.GetInt32(3);
            authors.Add(author);
        }
        return authors;
    }

    public void UpdateAuthor(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update authors set fullname = '{author.FullName}', country = '{author.Country}', birthyear = {author.BirthYear}";
        var cmd = new NpgsqlCommand(query, conn);
        cmd.ExecuteNonQuery();
        System.Console.WriteLine("Author updated!!");
    }

}
