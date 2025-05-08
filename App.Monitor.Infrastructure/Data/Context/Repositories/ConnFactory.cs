using App.Monitor.Infrastructure.Data.Context.Interface;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace App.Monitor.Infrastructure.Data.Context.Repositories
{
    public class ConnFactory : IConnFactory
    {
        private readonly IConfiguration _conf;
        private readonly string _connStringReadOnly, _connStringUpdate;
        private NpgsqlConnection _connectionReadOnly, _connectionUpdate;
        private SemaphoreSlim _semaphore;
        private bool _disposed;

        public ConnFactory(IConfiguration conf)
        {
            _conf = conf;
            _connStringReadOnly = _conf.GetConnectionString("ReadOnlyConnection") ?? throw new Exception("Connection ReadOnly string not found");
            _connStringUpdate = _conf.GetConnectionString("UpdateConnection") ?? throw new Exception("Connection Update string not found");
            _semaphore = new SemaphoreSlim(1);
        }

        public NpgsqlConnection GetConnectionStringReadOnly()
        {
            _semaphore.Wait();
            try
            {
                if (_connectionReadOnly == null)
                {
                    _connectionReadOnly = new NpgsqlConnection(_connStringReadOnly);
                    _connectionReadOnly.Open();
                }
            }
            finally
            {
                _semaphore.Release();
            }
            return _connectionReadOnly;
        }

        public NpgsqlConnection GetSqlConnectionUpdate()
        {
            _semaphore.Wait();
            try
            {
                if (_connectionUpdate == null)
                {
                    _connectionUpdate = new NpgsqlConnection(_connStringUpdate);
                    _connectionUpdate.Open();
                }
            }
            finally
            {
                _semaphore.Release();
            }
            return _connectionUpdate;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _connectionReadOnly?.Close();
                    _connectionReadOnly?.Dispose();
                    _connectionUpdate?.Close();
                    _connectionUpdate?.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
