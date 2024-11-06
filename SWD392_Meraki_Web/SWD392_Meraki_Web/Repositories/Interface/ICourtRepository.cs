using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface ICourtRepository
    {
        public List<Court> GetCourts();
        public int DeleteCourt(string id);
        public List<Court> GetCourtForStaff();
        public int CheckIn(string courtId);
        public int CheckOut(string courtId);
        public Court GetCourtById(string courtId);
    }
}
