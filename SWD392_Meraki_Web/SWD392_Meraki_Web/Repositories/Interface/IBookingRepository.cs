using SWD392_Meraki_Web.Models;

namespace SWD392_Meraki_Web.Repositories.Interface
{
    public interface IBookingRepository
    {
        public List<BookingType> GetBookingTypes();

    }
}
