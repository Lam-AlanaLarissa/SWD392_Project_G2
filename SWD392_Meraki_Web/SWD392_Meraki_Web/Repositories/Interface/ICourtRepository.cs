using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface ICourtRepository
    {
        public List<Court> GetCourts();
        public int DeleteCourt(string id);
    }
}
