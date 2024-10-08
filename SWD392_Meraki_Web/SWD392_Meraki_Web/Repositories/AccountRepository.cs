using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.DatabaseConnection; // For DbContext

namespace SWD392_Meraki_Web.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookingBadmintonContext _context; // Replace with your actual DbContext name

        // Constructor to inject the dependency
        public AccountRepository(BookingBadmintonContext context)
        {
            _context = context;
        }

        public User? GetUser(LoginModel obj)
        {
            return _context.Users
                .SingleOrDefault(p => p.Username == obj.Username && p.Password == obj.Password);
        }
    }
}