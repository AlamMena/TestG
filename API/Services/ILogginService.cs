using API.DbModels;

namespace API.Services
{
    public interface ILogginService
    {
        Task<int> Savelog(Log log);
        Task<List<Log>> GetLogs();
    }
}
