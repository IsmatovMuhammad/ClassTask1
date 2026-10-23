using System.Data;
using System.Security.Cryptography;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.Extensions.Options;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenresRepository : IGenresRepository
{
    public void AddGenre(Genres genre)
    {
        using var conn = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, conn);
        var ds = new DataSet();
        adapter.Fill(ds);
        var builder = new NpgsqlCommandBuilder(adapter);
        DataTable genresTable = ds.Tables[0];
        DataRow row = genresTable.NewRow();
        row["name"] = genre.Name;
        adapter.Update(ds);
    }

    public void DeleteGenre(int id)
    {
        using var connection = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, connection);
        var ds = new DataSet();
        adapter.Fill(ds);

        var builder = new NpgsqlCommandBuilder(adapter);

        DataTable genresTable = ds.Tables[0];

        foreach(DataRow dataRow in genresTable.Rows)
        {
            if (Convert.ToInt32(dataRow["id"]) == id)
            {
                dataRow.Delete();
                adapter.Update(ds);
                break;
            }
        }
    }

    public void ShowAll()
    {
        using var conn = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, conn);
        var ds = new DataSet();
        DataTable genresTable = ds.Tables[0];

        foreach(DataRow dr in genresTable.Rows)
        {
            System.Console.WriteLine(dr[0]+" "+dr[1]);
        }
    }

    public void UpdateGenre(Genres genre)
    {
        using var conn = Database.Connection();
        var sql = "select * from genres";
        var adapter = new NpgsqlDataAdapter(sql, conn);
        var ds = new DataSet();
        adapter.Fill(ds);
        var builder = new NpgsqlCommandBuilder(adapter);
        DataTable genresTable = ds.Tables[0];
        foreach (DataRow row in genresTable.Rows)
        {
            if(Convert.ToInt32(row["id"]) == genre.Id)
            {
                row["name"] = genre.Name;
                adapter.Update(ds);
                break;
            }

        }
    }

}
