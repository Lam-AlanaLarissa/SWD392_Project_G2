using AspNetCore;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingBadmintonContext _context;

        public BookingRepository(BookingBadmintonContext context)
        {
            _context = context;
        }

        public List<BookingType> GetBookingTypes()
        {
            return _context.BookingTypes.Where(bt => bt.Status == 1).ToList();
        }
    }
}
