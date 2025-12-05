using NewsPortal.Models;

namespace NewsPortal.Interfaces
{
    public interface IAdminUserRepository
    {
        Task<AdminUser?> GetByEmailAsync(string email);
        Task AddAsync(AdminUser user);
        Task<bool> AnyAsync();
    }
}
