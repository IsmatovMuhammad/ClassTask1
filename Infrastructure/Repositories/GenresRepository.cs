using System.Data;
using System.Security.Cryptography;
using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenresRepository(Database database) : IGenresRepository
{
    private Database data = database;
    public async Task<bool> AddGenre(Genres genre)
    {
        using var conn = data.Connection();
        var query = "insert into genres(name)values(@name)";
        var auth = await conn.ExecuteAsync(query, genre);
        return auth> 0;
    }

    public async Task<bool> DeleteGenre(int id)
    {
        using var conn = data.Connection();
        var query = "delete from genres where id = @id";
        var auth = await conn.ExecuteAsync(query, new{id});
        return auth> 0;
    }

    public async Task<Genres> GetGenr(int id)
    {
        using var conn = data.Connection();
        var query = "select * from genres where id = @id";
        var auth = await conn.QuerySingleAsync<Genres>(query, new{id});
        return auth;
    }


    public async Task<List<Genres>> GetGenres()
    {
        using var conn = data.Connection();
        var query = "select * from genres";
        var auth = await conn.QueryAsync<Genres>(query);
        return auth.ToList();
    }

    public async Task<bool> UpdateGenre(Genres genre)
    {
        using var conn = data.Connection();
        var query = "update genres set name = @name where id = @id";
        var auth = await conn.ExecuteAsync(query, genre);
        return auth> 0;
    }

}
