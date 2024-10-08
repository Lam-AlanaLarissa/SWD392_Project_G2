using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface IAccountRepository
    {
        User? GetUser(LoginModel obj);
    }
}
