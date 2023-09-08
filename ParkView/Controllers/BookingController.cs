using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParkView.Models;
using ParkView.Models.IRepositories;
using ParkView.Utils;
using ParkView.ViewModels;
using System.Security.Claims;

namespace ParkView.Controllers
{
    public class BookingController : Controller
    {
        private readonly IHotelRepo _hotelRepo;
        private readonly IRoomRepo _roomRepo;
        private readonly IBookingRepo _bookingRepo;
        private readonly ITransactionRepo _transactionRepo;
        private readonly IUserRepo _userRepo;

        public BookingController(IHotelRepo hotelRepo, IRoomRepo roomRepo, IBookingRepo bookingRepo, ITransactionRepo transactionRepo, IUserRepo userRepo)
        {
            _hotelRepo = hotelRepo;
            _roomRepo = roomRepo;
            _bookingRepo = bookingRepo;
            _transactionRepo = transactionRepo;
            _userRepo = userRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
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

        private int GetDayDifferenceDateOnly(DateOnly d1, DateOnly d2) => (new DateTime(d1.Year, d1.Month, d1.Day) - new DateTime(d2.Year, d2.Month, d2.Day)).Days;


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

            var daysDifference = GetDayDifferenceDateOnly(outDate, inDate);

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



            // save the transactions in transactions table with payment - inititated
            var transaction = new Transaction()
            {
                BookingId = booking.BookingId,
                UserId = userId,
                TotalPrice = totalPrice,
                PaymentStatus = PaymentStatus.INITIATED,
                CreatedAt = DateTime.Now
            };

            _transactionRepo.AddTransaction(transaction);

            decimal totalDecimalPrice = (decimal)totalPrice;


            return RedirectToAction("StripePayment", "Payment", new { totalAmount = totalDecimalPrice, transactionId = transaction.TransactionId });

        }

        [Authorize]
        public IActionResult ViewBooking()
        {
            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var bookings = _bookingRepo.GetCompletedBookings(userId);
            return View(bookings);
        }

        [HttpGet]
        public ActionResult DownloadPdf(int bookingId)
        {
            string fileName = "Invoice.pdf";

            var booking = _bookingRepo.GetBookingById(bookingId);

            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            var user = _userRepo.GetUserById(userId);

            var htmlContent = Utils.Utils.GetInvoiceTemplate(user.UserName, booking.CreatedAt.ToString("yyyy-MM-dd"), booking.BookingId.ToString(), booking.RoomPrice.ToString(), booking.CabPrice.ToString(), booking.MealPrice.ToString(), booking.CheckInDate.ToString("yyyy-MM-dd"), booking.TotalPrice.ToString());

            var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
            var pdfAsBytes = htmlToPdf.GeneratePdf(htmlContent);
            return File(pdfAsBytes, "application/pdf", fileName);
        }





    }

}
