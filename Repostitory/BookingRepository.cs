using Pastoralis.UseModels;
using Pastorials.Models;

namespace Pastoralis.Repostitory
{
    public class BookingRepository :IBookingRepository
    {
        private readonly PastorialsContext _context;
        public BookingRepository(PastorialsContext context) { 
            _context = context;

        }
        public void  PastorAvailableSlots(SlotModel model) 
        {
         var startTime  = model.StartTime;
         var endTime = model.EndTime;
         int duration  = model.Duration;
         int pastorId  = model.PastorId;

        }
        public void SlotCreator(DateTime startTime  , DateTime endTime , int duration, int PastorId)
        {
            Dictionary<int , List<Slot>> slots = new Dictionary<int , List<Slot>>();

        }
    }
}
