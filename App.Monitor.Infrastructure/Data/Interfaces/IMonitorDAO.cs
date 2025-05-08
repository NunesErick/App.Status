using App.Monitor.Infrastructure.DTO;

namespace App.Monitor.Infrastructure.Data.Interfaces
{
    public interface IMonitorDAO
    {
        Task<List<AppDTO>> GetApps();
        Task<List<LogAppDTO>> GetLogAppById(int id, int rangeHour);
    }
}
