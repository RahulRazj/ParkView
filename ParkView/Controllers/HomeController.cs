using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ParkView.Models;
using ParkView.Models.IRepositories;
using ParkView.Utils;
using System;
using System.Diagnostics;
using System.Security.Claims;

namespace ParkView.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IContactRepo _contactRepo;
        private readonly IUserRepo _userRepo;

        //public IEnumerable<Location> allLocations { get; set; }

        public HomeController(ILogger<HomeController> logger, IHotelRepo hotelRepo, IContactRepo contactRepo, IUserRepo userRepo)
        {
            _hotelRepo = hotelRepo;
            _contactRepo = contactRepo;
            _userRepo = userRepo;
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

        public IActionResult HandleContact(string name, string email, string message)
        {
            var contact = new ContactUsMessage()
            {
                Name = name,
                Email = email,
                Message = message,
                CreatedAt = DateTime.Now

            };

            _contactRepo.AddContact(contact);

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (userId != null)
            {
                var user = _userRepo.GetUserById(userId);
                string userNumber = "91" + user.PhoneNumber;

                ExternalRequest.SendContactWhatsappMessage(userNumber, user.UserName);
            }

            return RedirectToAction("Index");
        }
    }
}