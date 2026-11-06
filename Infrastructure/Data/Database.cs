using System.Data.Common;
using Npgsql;

namespace Infrastructure.Data;

public class Database
{
    private string connectionString = "Host=localhost;Port=5432;Database=booknest;Username=postgres;Password=1234";
    public DbConnection Connection() => new NpgsqlConnection(connectionString);
}   