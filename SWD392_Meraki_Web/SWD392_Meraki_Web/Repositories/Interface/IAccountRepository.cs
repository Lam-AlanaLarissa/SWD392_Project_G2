using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface IAccountRepository
    {
        public User GetUserById(string userId);
        public void UpdateUser(User user);
    }
}
