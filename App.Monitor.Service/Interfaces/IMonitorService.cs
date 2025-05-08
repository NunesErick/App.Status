using App.Monitor.Infrastructure.DTO;

namespace App.Monitor.Service.Interfaces
{
    public interface IMonitorService
    {
        Task<List<AppDTO>> GetApps();
        Task<List<LogAppDTO>> GetLogAppById(int id, int rangeHour);
    }
}
