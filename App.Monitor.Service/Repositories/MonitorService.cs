using App.Monitor.Domain.Interfaces;
using App.Monitor.Infrastructure.DTO;
using App.Monitor.Service.Interfaces;

namespace App.Monitor.Service.Repositories
{
    public class MonitorService : IMonitorService
    {
        private readonly IMonitor _rep;
        public MonitorService(IMonitor rep)
        {
            _rep = rep;
        }
        public async Task<List<AppDTO>> GetApps()
        {
            return await _rep.GetApps();
        }

        public async Task<List<LogAppDTO>> GetLogAppById(int id, int rangeHour)
        {
            return await _rep.GetLogAppById(id, rangeHour);
        }
    }
}
