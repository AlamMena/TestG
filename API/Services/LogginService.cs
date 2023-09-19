using API.DbModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace API.Services
{
    public class LogginService : ILogginService
    {
        private readonly ApplicationDbContext _context;

        public LogginService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Log>> GetLogs()
            => await _context.Logs.ToListAsync();

        public async Task<int> Savelog(Log log)
        {
            var result = await _context.Logs.AddAsync(log);
            await _context.SaveChangesAsync();
            return result.Entity.Id;
        }
    }
}
