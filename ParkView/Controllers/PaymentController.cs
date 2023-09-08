using Microsoft.AspNetCore.Mvc;
using ParkView.Models;
using ParkView.Models.IRepositories;
using ParkView.Utils;
using Stripe.Checkout;
using System.Security.Claims;

namespace ParkView.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IBookingRepo _bookingRepo;
        private readonly IUserRepo _userRepo;
        private readonly IRoomRepo _roomRepo;

        public PaymentController(ITransactionRepo transactionRepo, IBookingRepo bookingRepo, IUserRepo userRepo, IRoomRepo roomRepo)
        {
            _transactionRepo = transactionRepo;
            _bookingRepo = bookingRepo;
            _userRepo = userRepo;
            _roomRepo = roomRepo;
        }
        public IActionResult StripePayment(decimal totalAmount, int transactionId)
        {
            var baseUrl = "https://localhost:7149/";

            decimal totalAmountInCents = totalAmount * 100; // adjusted for inr

            decimal minimumAmountInCents = 100;

            totalAmountInCents = totalAmountInCents < minimumAmountInCents ? minimumAmountInCents : totalAmountInCents;

            if (totalAmountInCents < minimumAmountInCents)
            {
                totalAmountInCents = minimumAmountInCents;
            }



            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = baseUrl + $"Payment/SuccessPayment?txnId={transactionId}", // callback success url
                CancelUrl = baseUrl + $"Payment/FailurePayment?txnId={transactionId}",  // callback failure url
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

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult SuccessPayment(int txnId)
        {
            var transaction = _transactionRepo.GetTransactionById(txnId);
            transaction.PaymentStatus = PaymentStatus.COMPLETE;
            _transactionRepo.UpdateTransaction(transaction);

            var booking = _bookingRepo.GetBookingById(transaction.BookingId);
            var room = _roomRepo.GetRoomById(booking.RoomId);

            if (room.TotalRoomsAvailable > 0)
            {
                room.TotalRoomsAvailable--;
                Console.WriteLine("room total available" + room.TotalRoomsAvailable);
                _roomRepo.UpdateRoom(room);
                Console.WriteLine("room total available" + room.TotalRoomsAvailable);
            }


            var claimIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (booking != null)
            {
                booking.IsBookingComplete = true;

                _bookingRepo.UpdateBooking(booking);
                var user = _userRepo.GetUserById(userId);
                var userNumber = "91" + user.PhoneNumber;
                ExternalRequest.SendBookingWhatsappMessage(userNumber, booking.CheckInDate.ToString("yyyy-MM-dd"), booking.CheckOutDate.ToString("yyyy-MM-dd"), booking.HotelName, "ParkView Bangalore", user.UserName);
            }
            return View();
        }

        public IActionResult FailurePayment(int txnId)
        {
            var transaction = _transactionRepo.GetTransactionById(txnId);
            transaction.PaymentStatus = PaymentStatus.FAILED;
            _transactionRepo.UpdateTransaction(transaction);
            return View();
        }
    }
}
