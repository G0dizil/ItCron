using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IIpAddressService
    {
        Task<bool> SaveRequestHistory(IpAddressInfo model);
        Task<IEnumerable<IpAddressInfo>> GetAll();
    }
}
