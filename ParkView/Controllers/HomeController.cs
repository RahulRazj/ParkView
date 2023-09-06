using Microsoft.AspNetCore.Mvc;
using ParkView.Models;
using System.Diagnostics;

namespace ParkView.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelRepo _hotelRepo;
        public IEnumerable<Location> allLocations { get; set; }

        public HomeController(ILogger<HomeController> logger, IHotelRepo hotelRepo)
        {
            _hotelRepo = hotelRepo;
        }
        public IActionResult Index()
        {
            var hotelLocations = _hotelRepo.AllLocations.ToList();
            return View(hotelLocations);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}