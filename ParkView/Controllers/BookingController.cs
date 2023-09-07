using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkView.Models;
using ParkView.ViewModels;
using Stripe.Checkout;
using System.Security.Claims;

namespace ParkView.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IBookingRepo _bookingRepo;

        public BookingController(IHotelRepo hotelRepo, IRoomRepo roomRepo, IBookingRepo bookingRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
            _bookingRepo = bookingRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Book(int hotelId, int roomId)
        {
            var hotel = _hotelRepo.GetHotelById(hotelId);
            var room = _roomRepo.GetRoomById(roomId);

            var bookingViewModel = new BookingViewModel()
            {
                Room = room,
                Hotel = hotel
            };
            return View(bookingViewModel);
        }

        private int DaysDifferenceDateOnlyConverted(DateOnly d1, DateOnly d2) => (new DateTime(d1.Year, d1.Month, d1.Day) - new DateTime(d2.Year, d2.Month, d2.Day)).Days;


        [Authorize]
        public IActionResult CheckOut(string checkInDate, string checkoutDate, string noOfAdults, string noOfChildrens, string cabCheckBox, string foodCheckBox, string hotelId, string roomId)
        {

            var hotel = _hotelRepo.GetHotelById(int.Parse(hotelId));
            var room = _roomRepo.GetRoomById(int.Parse(roomId));


            DateOnly inDate, outDate;
            try
            {
                inDate = DateOnly.ParseExact(checkInDate, "yyyy-MM-dd", null);
                outDate = DateOnly.ParseExact(checkoutDate, "yyyy-MM-dd", null);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }

            var daysDifference = DaysDifferenceDateOnlyConverted(outDate, inDate);

            var roomPrice = room.PricePerNight;
            var adults = int.Parse(noOfAdults);
            var childrens = int.Parse(noOfChildrens);

            double roomTotalPrice = 0;

            if (adults > 2)
            {
                roomTotalPrice = (roomPrice + (adults - 2) * 0.25 * roomPrice) * daysDifference;
            }
            else
            {
                roomTotalPrice = roomPrice * daysDifference;
            }

            double childrenPrices = childrens * 2500;

            var cabPrices = 0;
            if (cabCheckBox == "yes")
            {
                cabPrices = 2000;
            }

            var foodPrices = 0;
            if (foodCheckBox == "yes")
            {
                foodPrices = adults * 1200 * daysDifference;
            }


            var totalPrice = roomTotalPrice + childrenPrices + cabPrices + foodPrices;

            Console.WriteLine("Total Price:" + totalPrice.ToString());


            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var booking = new Booking()
            {
                UserId = userId,
                RoomId = room.RoomId,
                HotelName = hotel.HotelName,
                CheckInDate = new DateTime(inDate.Year, inDate.Month, inDate.Day),
                CheckOutDate = new DateTime(outDate.Year, outDate.Month, outDate.Day),
                TotalPrice = totalPrice,
                NoOfAdults = adults,
                NoOfChildrens = childrens,
                HasOptedCab = cabCheckBox == "yes",
                HasOptedFood = foodCheckBox == "yes",
                CreatedAt = DateTime.Now,
                RoomPrice = roomPrice,
                ChildrensPrice = childrenPrices,
                CabPrice = cabPrices,
                MealPrice = foodPrices
            };


            _bookingRepo.SaveBooking(booking);

            decimal totalDecimalPrice = (decimal)totalPrice;

            // save the transactions in transactions table with payment - inititated
            return RedirectToAction("StripePayment", totalDecimalPrice);

        }


        public IActionResult StripePayment(decimal totalAmount)
        {
            var baseUrl = "https://localhost:7149/";

            decimal totalAmountInCents = totalAmount * 100;

            //decimal minimumAmountInCents = 50;

            //if (totalAmountInCents < minimumAmountInCents)
            //{
            //    totalAmountInCents = minimumAmountInCents;
            //}



            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = baseUrl + $"Reservation/ReservationSuccess", // callback success url
                CancelUrl = baseUrl + $"Reservation/ReservationFail",  // callback failure url
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            UnitAmount = (long)totalAmountInCents,
                            Currency = "inr",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Booking Payment",
                            }
                        },
                        Quantity = 1,
                    }
                },
                Mode = "payment",
            };



            var service = new Stripe.Checkout.SessionService();
            var session = service.Create(options);



            //TempData["sessionId"] = session.Id;



            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }



    }
}
