using Microsoft.AspNetCore.Mvc;
using ParkView.Models;

namespace ParkView.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotelRepo _hotelRepo;

        public HotelController(IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OurHotels()
        {
            var allLocations = _hotelRepo.AllLocations;
            return View(allLocations);
        }

        public IActionResult Detail(string query)
        {
            var hotel = _hotelRepo.SearchHotels(query);
            return View(hotel);
        }

        public IActionResult HotelView(int id)
        {
            var hotel = _hotelRepo.GetHotelById(id);
            return View(hotel);
        }
    }
}
