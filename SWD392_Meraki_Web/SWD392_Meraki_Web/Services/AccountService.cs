using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;
using SWD392_Meraki_Web.Services.Interface;

namespace SWD392_Meraki_Web.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<bool> RegisterUserAsync(User newUser)
        {
            if (_accountRepository.UserExists(newUser.Username, newUser.Email))
            {
                return false; // Username or Email already exists
            }

            // Hash password (using BCrypt.Net-Next, for example)
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            return _accountRepository.CreateAccountAsync(newUser);
        }
    }
}
