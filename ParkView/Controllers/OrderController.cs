using Microsoft.AspNetCore.Mvc;
using ParkView.Models;

namespace ParkView.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IRoomRepo _roomRepo;

        public OrderController(IHotelRepo hotelRepo, IRoomRepo roomRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
        }

        public IActionResult Index(string checkInDate, string checkoutDate, string noOfAdults, string noOfChildrens, string cabCheckBox, string foodCheckBox, string hotelId, string roomId)
        {
            Console.WriteLine("checkinDate: " + checkInDate);
            Console.WriteLine("checkoutDate: " + checkoutDate);
            Console.WriteLine("noOfAdults: " + noOfAdults);
            Console.WriteLine("noOfChildrens: " + noOfChildrens);
            Console.WriteLine("cabCheckBox: " + cabCheckBox);
            Console.WriteLine("foodCheckBox: " + foodCheckBox);
            Console.WriteLine("hotelId: " + hotelId);
            Console.WriteLine("roomId: " + roomId);



            
            return View();
        }
    }
}
