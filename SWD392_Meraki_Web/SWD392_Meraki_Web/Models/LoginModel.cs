namespace SWD392_Meraki_Web.Models
{
    public class LoginModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool Remember { get; set; }
    }
}

