using App.Monitor.Infrastructure.Data.Context.Interface;
using App.Monitor.Infrastructure.Data.Interfaces;
using App.Monitor.Infrastructure.DTO;
using Dapper;

namespace App.Monitor.Infrastructure.Data.Repositories
{
    public class MonitorDAO : IMonitorDAO
    {
        private readonly IConnFactory _conn;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);
        public MonitorDAO(IConnFactory conn)
        {
            _conn = conn;
        }
        public async Task<List<AppDTO>> GetApps()
        {
            const string query = "SELECT id,nome,link_interacao as LinkInteracao FROM aplicacoes";
            var conn = _conn.GetConnectionStringReadOnly();
            var retorno = conn.Query<AppDTO>(query).ToList();
            return retorno;
        }

        public async Task<List<LogAppDTO>> GetLogAppById(int id, int rangeHour)
        {
            const string query = @"
                    SELECT * 
                    FROM log_apps 
                    WHERE id_aplicacao = @id 
                    AND data_medicao >= NOW() - (@rangeHour || ' hours')::INTERVAL";
            _semaphore.Wait();
            try
            {
                var conn = _conn.GetConnectionStringReadOnly();
                var retorno = conn.Query<LogAppDTO>(query, new { id,rangeHour = rangeHour }).ToList();
                return retorno;
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
