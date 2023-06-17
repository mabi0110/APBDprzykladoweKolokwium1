using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Services
{

    public interface IDbService
    {
        Task<ICollection<Order>> GetOrdersData(string? clientLastName);
    }
    public class DbService : IDbService
    {

        private readonly PastryContext _context;
        public DbService(PastryContext context)
        {
            _context = context;
        }


        public async Task<ICollection<Order>> GetOrdersData(string? clientLastName)
        {
            return await _context.Orders
                .Include(e => e.Client)
                .Include(e => e.OrderPastries)
                .ThenInclude(e => e.Pastry)
                .Where(e => clientLastName == null || e.Client.LastName == clientLastName)
                .ToListAsync();
        }
    }
}
