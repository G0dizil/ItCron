using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class IpAddressService : IIpAddressService
    {
        private readonly IpAddressDbContext _context;
        public IpAddressService(IpAddressDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IpAddressInfo>> GetAll()
        {
            return await _context.IpAddressInfo.ToListAsync();
        }

        public async Task<bool> SaveRequestHistory(IpAddressInfo model)
        {
            if (_context.IpAddressInfo.FirstOrDefault(i=>i.Ip == model.Ip) == null)
            {
                _context.IpAddressInfo.Add(model);
                await _context.SaveChangesAsync();
                return true;
            }            
            else 
            {
                return false; 
            }
        }
    }
}
