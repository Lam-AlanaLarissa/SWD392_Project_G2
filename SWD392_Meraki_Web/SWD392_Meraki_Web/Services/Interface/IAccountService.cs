using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Services.Interface
{
    public interface IAccountService
    {
        public Task<bool> RegisterUserAsync(User newUser);

    }
}
