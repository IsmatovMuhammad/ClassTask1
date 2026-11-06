using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepository(Database database) : IAuthorRepository
{
    private Database data = database;
    public async Task<bool> AddAuthor(Author author)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"insert into authors(fullname, country, birthyear)values(@fullname, @country, @birthyear)";
        var auth = await conn.ExecuteAsync(query, conn);
        return auth> 0;
    }

    public async Task<bool> DeleteAuthor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"delete from authors where id = @id";
        var auth = await conn.ExecuteAsync(query, conn);
        return auth>0;
    }

    public async Task<Author> GetAuthor(int id)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"select id, fullname, country, birthyear from authors where id = @id";
        var auth = await conn.QuerySingleAsync<Author>(query, new{id});
        return auth;
    }

    public async Task<List<Author>> GetAuthors()
    {
        using var conn = data.Connection();
        conn.Open();
        var query = "select * from authors";
        var auth = await conn.QueryAsync<Author>(query, conn);
        return auth.ToList();
    }

    public async Task<bool> UpdateAuthor(Author author)
    {
        using var conn = data.Connection();
        conn.Open();
        var query = $"update authors set fullname = @fullname, country = @country, birthyear = @birthyear where id = @id";
        var auth = await conn.ExecuteAsync(query, conn);
        return auth>0;
    }
}
