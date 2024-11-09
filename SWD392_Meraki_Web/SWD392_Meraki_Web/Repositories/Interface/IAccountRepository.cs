using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface IAccountRepository
    {

        public User GetUserById(string userId);
        public bool UpdateUser(User user);
        public User GetUserByEmail(string email);
        public User? GetUser(User obj);
        public Task<string> AutoGenerateAccountId();
        public bool UserExists(string username, string email);
        public bool CreateAccountAsync(User acc);
    }
}
