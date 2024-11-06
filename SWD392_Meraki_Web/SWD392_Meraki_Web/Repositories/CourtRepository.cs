using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Repositories
{
    public class CourtRepository : ICourtRepository
    {
        private readonly BookingBadmintonContext _context; // Replace with your actual DbContext name

        public CourtRepository(BookingBadmintonContext context)
        {
            _context = context;
        }
        public List<Court> GetCourts()
        {
            var courts = from court in _context.Courts
                         join user in _context.Users on court.CreateBy equals user.UserId
                         select new Court
                         {
                             CourtId = court.CourtId,
                             CourtName = court.CourtName,
                             Location = court.Location,
                             OpeningHours = court.OpeningHours,
                             ClosingHours = court.ClosingHours,
                             Status = court.Status,
                             IsUsing = court.IsUsing,
                             CreateAt = court.CreateAt,
                             CreateBy = user.Username // Access the username directly
                         };

            return courts.ToList();
        }
        public Court GetCourtById(string courtId)
        {
            return _context.Courts.FirstOrDefault(c => c.CourtId == courtId);
        }

        public int DeleteCourt(string id)
        {
            // Tìm court theo ID trước khi xóa
            var court = _context.Courts.Find(id);
            if (court != null)
            {
                _context.Courts.Remove(court);
                return _context.SaveChanges(); // Trả về số lượng bản ghi đã bị xóa
            }
            return 0; // Không có bản ghi nào bị xóa
        }

        public List<Court> GetCourtForStaff()
        {
            var courts = from court in _context.Courts
                         select new Court
                         {
                             CourtId = court.CourtId,
                             CourtName = court.CourtName,
                             Location = court.Location,
                             Status = court.Status,
                             IsUsing = court.IsUsing,
                         };
            return courts.ToList();
        }

        public int CheckIn(string id)
        {
            var court = GetCourtById(id);
            if (court != null)
            {
                court.Status = 1; // 1 = Active
                court.IsUsing = true;
                return _context.SaveChanges();
            }
            return 0;
        }
        public int CheckOut(string id)
        {
            var court = _context.Courts.Find(id);
            if (court != null)
            {
                court.Status = 0; // 0 = Inactive
                court.IsUsing = false;
                return _context.SaveChanges();
            }
            return 0;
        }
    }
}

