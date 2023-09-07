using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ParkView.Models
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<ApplicationUser> User { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<RoomType>().HasData(
                new RoomType
                {
                    RoomTypeId = 1, Description = "Experience unparalleled luxury in our Presidential Suite, where opulent comfort meets panoramic views and personalized service.", TypeName = "Presidential Suite"
                },
                new RoomType
                {
                    RoomTypeId = 2,
                    Description = "Discover refined comfort in our Executive Rooms, designed for business travelers and discerning guests seeking a touch of elegance.",
                    TypeName = "Executive",
                },
                new RoomType
                {
                    RoomTypeId = 3,
                    Description = "Experience the pinnacle of comfort and elegance in our Super Deluxe Rooms, designed to cater to your every need.",
                    TypeName = "Super Deluxe",
                    
                },
                new RoomType
                {
                    RoomTypeId = 4,
                    Description = "Enjoy a comfortable and cozy stay in our Deluxe Rooms, offering modern amenities and a relaxing ambiance.",
                    TypeName = "Deluxe",
                });

            builder.Entity<Room>().HasData(
                new Room { RoomId = 1, RoomTypeId = 1, HotelId = 1, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 2, RoomTypeId = 2, HotelId = 1, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 3, RoomTypeId = 3, HotelId = 1, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 4, RoomTypeId = 4, HotelId = 1, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 5, RoomTypeId = 1, HotelId = 2, PricePerNight = 26000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 6, RoomTypeId = 2, HotelId = 2, PricePerNight = 22000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 7, RoomTypeId = 3, HotelId = 2, PricePerNight = 14000, TotalRoomsAvailable = 4 },
                new Room { RoomId = 8, RoomTypeId = 4, HotelId = 2, PricePerNight = 9500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 9, RoomTypeId = 1, HotelId = 3, PricePerNight = 27000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 10, RoomTypeId = 2, HotelId = 3, PricePerNight = 2200, TotalRoomsAvailable = 3 },
                new Room { RoomId = 11, RoomTypeId = 3, HotelId = 3, PricePerNight = 15000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 12, RoomTypeId = 4, HotelId = 3, PricePerNight = 8500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 13, RoomTypeId = 1, HotelId = 4, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 14, RoomTypeId = 2, HotelId = 4, PricePerNight = 23000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 15, RoomTypeId = 3, HotelId = 4, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 16, RoomTypeId = 4, HotelId = 4, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 17, RoomTypeId = 1, HotelId = 5, PricePerNight = 31000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 18, RoomTypeId = 2, HotelId = 5, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 19, RoomTypeId = 3, HotelId = 5, PricePerNight = 15500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 20, RoomTypeId = 4, HotelId = 5, PricePerNight = 8800, TotalRoomsAvailable = 5 },

                new Room { RoomId = 21, RoomTypeId = 1, HotelId = 6, PricePerNight = 29500, TotalRoomsAvailable = 2 },
                new Room { RoomId = 22, RoomTypeId = 2, HotelId = 6, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 23, RoomTypeId = 3, HotelId = 6, PricePerNight = 16000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 24, RoomTypeId = 4, HotelId = 6, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 25, RoomTypeId = 1, HotelId = 7, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 26, RoomTypeId = 2, HotelId = 7, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 27, RoomTypeId = 3, HotelId = 7, PricePerNight = 15500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 28, RoomTypeId = 4, HotelId = 7, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 29, RoomTypeId = 1, HotelId = 8, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 30, RoomTypeId = 2, HotelId = 8, PricePerNight = 21000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 31, RoomTypeId = 3, HotelId = 8, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 32, RoomTypeId = 4, HotelId = 8, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 33, RoomTypeId = 1, HotelId = 9, PricePerNight = 27000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 34, RoomTypeId = 2, HotelId = 9, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 35, RoomTypeId = 3, HotelId = 9, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 36, RoomTypeId = 4, HotelId = 9, PricePerNight = 8500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 37, RoomTypeId = 1, HotelId = 10, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 38, RoomTypeId = 2, HotelId = 10, PricePerNight = 21000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 39, RoomTypeId = 3, HotelId = 10, PricePerNight = 13000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 40, RoomTypeId = 4, HotelId = 10, PricePerNight = 7500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 41, RoomTypeId = 1, HotelId = 11, PricePerNight = 29500, TotalRoomsAvailable = 2 },
                new Room { RoomId = 42, RoomTypeId = 2, HotelId = 11, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 43, RoomTypeId = 3, HotelId = 11, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 44, RoomTypeId = 4, HotelId = 11, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 45, RoomTypeId = 1, HotelId = 12, PricePerNight = 27000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 46, RoomTypeId = 2, HotelId = 12, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 47, RoomTypeId = 3, HotelId = 12, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 48, RoomTypeId = 4, HotelId = 12, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 49, RoomTypeId = 1, HotelId = 13, PricePerNight = 29000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 50, RoomTypeId = 2, HotelId = 13, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 51, RoomTypeId = 3, HotelId = 13, PricePerNight = 13500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 52, RoomTypeId = 4, HotelId = 13, PricePerNight = 8000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 53, RoomTypeId = 1, HotelId = 14, PricePerNight = 28000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 54, RoomTypeId = 2, HotelId = 14, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 55, RoomTypeId = 3, HotelId = 14, PricePerNight = 14000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 56, RoomTypeId = 4, HotelId = 14, PricePerNight = 9000, TotalRoomsAvailable = 5 },

                new Room { RoomId = 57, RoomTypeId = 1, HotelId = 15, PricePerNight = 29000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 58, RoomTypeId = 2, HotelId = 15, PricePerNight = 20000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 59, RoomTypeId = 3, HotelId = 15, PricePerNight = 14500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 60, RoomTypeId = 4, HotelId = 15, PricePerNight = 8500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 61, RoomTypeId = 1, HotelId = 16, PricePerNight = 27000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 62, RoomTypeId = 2, HotelId = 16, PricePerNight = 21000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 63, RoomTypeId = 3, HotelId = 16, PricePerNight = 14500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 64, RoomTypeId = 4, HotelId = 16, PricePerNight = 9500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 65, RoomTypeId = 1, HotelId = 17, PricePerNight = 33000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 66, RoomTypeId = 2, HotelId = 17, PricePerNight = 25000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 67, RoomTypeId = 3, HotelId = 17, PricePerNight = 15000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 68, RoomTypeId = 4, HotelId = 17, PricePerNight = 8500, TotalRoomsAvailable = 5 },

                new Room { RoomId = 69, RoomTypeId = 1, HotelId = 18, PricePerNight = 32000, TotalRoomsAvailable = 2 },
                new Room { RoomId = 70, RoomTypeId = 2, HotelId = 18, PricePerNight = 22000, TotalRoomsAvailable = 3 },
                new Room { RoomId = 71, RoomTypeId = 3, HotelId = 18, PricePerNight = 13500, TotalRoomsAvailable = 3 },
                new Room { RoomId = 72, RoomTypeId = 4, HotelId = 18, PricePerNight = 8200, TotalRoomsAvailable = 5 }
                );

            builder.Entity<Location>().HasData(
                new Location { LocationId = 1, Address = "Kumara Krupa High Grounds ", LocationCode = "BLR", City = "Bangalore", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-New-Delhi.jpg" },
                new Location { LocationId = 2, Address = "Post Office GUINDY INDUSTRIAL ESTATE", LocationCode = "CHN", City = "Chennai", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Mumbai.jpg\r\n" },
                new Location { LocationId = 3, Address = "Barakhamba Avenue, Connaught Place, New Delhi-110001", LocationCode = "DEL", City = "Delhi", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Grand-Palace-Srinagar.jpg" },
                new Location { LocationId = 4, Address = "Rajiv Gandhi IT Park, Chandigarh", LocationCode = "CHG", City = "Chandigarh", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Golf-Spa-Resort-Goa.jpg" },
                new Location { LocationId = 5, Address = "Mumbai Sahar Airport Road", LocationCode = "MUM", City = "Mumbai", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2017/02/Jaipur.jpg" },
                new Location { LocationId = 6, Address = "Old Court House Street Dalhousie Square", LocationCode = "KOL", City = "Kolkata", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2017/02/Kolkata.jpg" },
                new Location { LocationId = 7, Address = "Road No 10, Banjara Hills", LocationCode = "HYD", City = "Hyderabad", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Temple-View-Khajuraho.jpg" },
                new Location { LocationId = 8, Address = "Ground Floor Mariplex Mall, Kalyani Nagar", LocationCode = "PUN", City = "Pune", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Ashok-Bangalore.jpg" },
                new Location { LocationId = 9, Address = "Patia, Kiit Square", LocationCode = "BBSR", City = "Bhubaneswar", HotelImageUrl = "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Resort-Spa-Bekal.jpg" });


            builder.Entity<Hotel>().HasData(
                new Hotel { HotelId = 1, HotelName = "Radisson Blu Hotel", LocationId = 1, Description = "A centrally located hotel, known for its lush green surroundings, spacious rooms, and premium dining." },
                new Hotel { HotelId = 2, HotelName = "The Westin Mindspace", LocationId = 2, Description = "A business hotel, known for its comfortable rooms, wellness facilities, and dining options." },
                new Hotel { HotelId = 3, HotelName = "The Taj Gateway Hotel", LocationId = 3, Description = "A luxury beachfront retreat offering world-class spa services, gourmet dining, and panoramic ocean views." },
                new Hotel { HotelId = 4, HotelName = "Whispering Pines Lodge", LocationId = 4, Description = "Nestled in the heart of the forest, this cozy lodge is perfect for nature enthusiasts seeking tranquility and adventure." },
                new Hotel { HotelId = 5, HotelName = "Urban Elegance Suites", LocationId = 5, Description = "Chic and modern, these downtown suites provide a sophisticated stay for business travelers and city explorers." },
                new Hotel { HotelId = 6, HotelName = "Mountain Haven Retreat", LocationId = 6, Description = "Escape to the mountains and enjoy rustic charm, hiking trails, and stunning alpine vistas at this cozy retreat." },
                new Hotel { HotelId = 7, HotelName = "Riverside Serenity Inn", LocationId = 7, Description = "A charming riverside inn with a peaceful ambiance, perfect for romantic getaways and nature lovers." },
                new Hotel { HotelId = 8, HotelName = "The Royal Palace Hotel", LocationId = 8, Description = "Experience opulence and grandeur in this historic hotel, where luxury meets timeless elegance." },
                new Hotel { HotelId = 9, HotelName = "Sunny Sands Resort & Villas", LocationId = 9, Description = "A tropical paradise with private villas, water sports, and golden beaches - a dream vacation destination." },
                new Hotel { HotelId = 10, HotelName = "Harbor View Suites", LocationId = 8, Description = "Located on the waterfront, these suites offer breathtaking harbor views, ideal for a coastal escape." },
                new Hotel { HotelId = 11, HotelName = "Wilderness Lodge & Spa", LocationId = 3, Description = "Immerse yourself in nature's beauty at this remote lodge with a spa, wildlife tours, and stargazing opportunities." },
                new Hotel { HotelId = 12, HotelName = "City Lights Boutique Hotel", LocationId = 9, Description = "A boutique hotel in the heart of the city, offering stylish rooms, fine dining, and easy access to cultural attractions." },
                new Hotel { HotelId = 13, HotelName = "Countryside Charm Inn", LocationId = 2, Description = "Experience the tranquility of the countryside in this charming inn with rolling hills and farm-to-table cuisine." },
                new Hotel { HotelId = 14, HotelName = "Palm Oasis Resort", LocationId = 3, Description = "A desert oasis with palm-lined pools, spa treatments, and desert adventures for a rejuvenating escape." },
                new Hotel { HotelId = 15, HotelName = "Historic Hideaway Mansion", LocationId = 6, Description = "Step back in time in this meticulously restored mansion, offering a glimpse into the past with modern comforts." },
                new Hotel { HotelId = 16, HotelName = "Tropical Breeze Beachfront Resort", LocationId = 7, Description = "Relax on white sandy beaches and enjoy water sports, beachfront dining, and breathtaking sunsets." },
                new Hotel { HotelId = 17, HotelName = "Alpine Retreat Lodge", LocationId = 8, Description = "Nestled in the mountains, this lodge is a haven for skiers and hikers, with cozy fireside lounges and hot tubs." },
                new Hotel { HotelId = 18, HotelName = "Rainforest Adventure Lodge", LocationId = 5, Description = "Immerse yourself in the lush rainforest with guided hikes, canopy tours, and wildlife encounters." });

        }
    }
}
