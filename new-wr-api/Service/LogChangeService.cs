using new_wr_api.Data;
using new_wr_api.Dto;
using Newtonsoft.Json;
using System.Security.Claims;

namespace new_wr_api.Service
{
    public interface ILogChangeService
    {
        Task LogChangeAsync(string entityName, string action, object? oldValue, object? newValue, string? changedBy);
    }

    public class LogChangeService : ILogChangeService
    {
        private readonly DatabaseContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public LogChangeService(DatabaseContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        public async Task LogChangeAsync(string entityName, string action, object? oldValue, object? newValue, string? changedBy)
        {
            var changeHistory = new ChangeHistory
            {
                EntityName = entityName,
                Action = action,
                OldValues = oldValue != null ? JsonConvert.SerializeObject(oldValue) : null,
                NewValues = newValue != null ? JsonConvert.SerializeObject(newValue) : null,
                ChangeTime = DateTime.Now,
                ChangedBy = changedBy 
            };

            _context.ChangeHistory!.Add(changeHistory);
            await _context.SaveChangesAsync();
        }
    }
}
