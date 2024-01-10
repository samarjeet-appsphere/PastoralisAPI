using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pastoralis.Repostitory;
using Pastoralis.UseModels;

namespace Pastoralis.Controllers
{
    [Route("api/slot")]
    public class BookingController : Controller
    { private readonly IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        [HttpPost]
        [Route("/availablity")]
        
        public IActionResult AvailabilitySlots([FromBody]SlotModel model)
        { 
           _bookingRepository.PastorAvailableSlots(model);
            return View(model);
           
        }
    }
}
