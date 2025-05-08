using App.Monitor.Infrastructure.DTO;

namespace App.Monitor.Domain.Interfaces
{
    public interface IMonitor
    {
        Task<List<AppDTO>> GetApps();
        Task<List<LogAppDTO>> GetLogAppById(int id,int rangeHour);
    }
}
