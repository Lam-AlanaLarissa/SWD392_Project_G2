using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace SWD392_Meraki_Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BookingBadmintonContext _context;

        public UserRepository(BookingBadmintonContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string userId)
        {
            var user = await GetUserByIdAsync(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task CheckInUserAsync(CheckIn checkIn)
        {
            _context.CheckIns.Add(checkIn);
            await _context.SaveChangesAsync();
        }
    }
}
