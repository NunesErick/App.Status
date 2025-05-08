using Npgsql;

namespace App.Monitor.Infrastructure.Data.Context.Interface
{
    public interface IConnFactory
    {
        NpgsqlConnection GetConnectionStringReadOnly();
        NpgsqlConnection GetSqlConnectionUpdate();
    }
}
