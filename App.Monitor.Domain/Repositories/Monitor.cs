using App.Monitor.Domain.Interfaces;
using App.Monitor.Infrastructure.Data.Interfaces;
using App.Monitor.Infrastructure.DTO;

namespace App.Monitor.Domain.Repositories
{
    public class Monitor : IMonitor
    {
        private readonly IMonitorDAO _rep;
        public Monitor(IMonitorDAO rep)
        {
            _rep = rep;
        }
        public async Task<List<AppDTO>> GetApps()
        {
            return await _rep.GetApps();            
        }

        public async Task<List<LogAppDTO>> GetLogAppById(int id, int rangeHour)
        {
            return await _rep.GetLogAppById(id,rangeHour);
        }
    }
}
