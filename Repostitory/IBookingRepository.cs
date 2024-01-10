using Pastoralis.UseModels;

namespace Pastoralis.Repostitory
{
    public interface IBookingRepository
    {
       void PastorAvailableSlots(SlotModel model);
    }
}
