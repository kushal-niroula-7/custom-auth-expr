using Npgsql;
using System.Data;

namespace AcerX;

public static class ConnectionProvider
{
    public static IDbConnection GetDbConnection()
    {
        var connectionString = "Server=localhost;Port=5432;Database=first_run;User Id=postgres;Password=admin;";
        return new NpgsqlConnection(connectionString);
    }
}
