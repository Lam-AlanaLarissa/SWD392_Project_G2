using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.DatabaseConnection; // For DbContext

namespace SWD392_Meraki_Web.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BookingBadmintonContext _context; // Replace with your actual DbContext name

        public AccountRepository()
        {
        }

        // Constructor to inject the dependency
        public AccountRepository(BookingBadmintonContext context)
        {
            _context = context;
        }

        public User? GetUser(User obj)
        {
            return _context.Users
                .SingleOrDefault(p => p.Email == obj.Email && p.Password == obj.Password);
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email.Equals(email));
        }
        public User GetUserById(string userId)
        {
            return _context.Users.Find(userId);
        }

        public bool UpdateUser(User user)
        {
            try
            {
                _context.Users.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UserExists(string username, string email)
        {
            return _context.Users.Any(u => u.Username == username || u.Email == email);
        }

        public bool CreateAccountAsync(User acc)
        {
            try
            {
                using (var context = new BookingBadmintonContext())
                {
                    context.Users.AddAsync(acc);
                    context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
        public async Task<string> GetLatestUserIdAsync()
        {
            try
            {

                // Fetch the relevant data from the database
                var accountIds = await _context.Users
                    .Select(u => u.UserId)
                    .ToListAsync();

                // Process the data in memory to extract and order by the numeric part
                var latestAccountId = accountIds
                    .Select(id => new { UserId = id, NumericPart = int.Parse(id.Substring(2)) })
                    .OrderByDescending(u => u.NumericPart)
                    .ThenByDescending(u => u.UserId)
                    .Select(u => u.UserId)
                    .FirstOrDefault();

                return latestAccountId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public async Task<string> AutoGenerateAccountId()
        {
            string newAccountId = "";
            string latestAccountId = await GetLatestUserIdAsync();
            if (string.IsNullOrEmpty(latestAccountId))
            {
                newAccountId = "AC00000001";
            }
            else
            {
                int numericpart = int.Parse(latestAccountId.Substring(2));
                int newnumericpart = numericpart + 1;
                newAccountId = $"AC{newnumericpart:d8}";
            }
            return newAccountId;
        }
    }
}