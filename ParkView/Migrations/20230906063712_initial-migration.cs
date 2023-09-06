using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkView.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    HotelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.HotelId);
                    table.ForeignKey(
                        name: "FK_Hotels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    RoomTypeId = table.Column<int>(type: "int", nullable: false),
                    TotalRoomsAvailable = table.Column<int>(type: "int", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                    table.ForeignKey(
                        name: "FK_Rooms_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "HotelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "RoomTypes",
                        principalColumn: "RoomTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "Address", "City", "HotelImageUrl", "LocationCode" },
                values: new object[,]
                {
                    { 1, "Kumara Krupa High Grounds ", "Bangalore", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-New-Delhi.jpg", "BLR" },
                    { 2, "Post Office GUINDY INDUSTRIAL ESTATE", "Chennai", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Mumbai.jpg\r\n", "CHN" },
                    { 3, "Barakhamba Avenue, Connaught Place, New Delhi-110001", "Delhi", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Grand-Palace-Srinagar.jpg", "DEL" },
                    { 4, "Rajiv Gandhi IT Park, Chandigarh", "Chandigarh", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Golf-Spa-Resort-Goa.jpg", "CHG" },
                    { 5, "Mumbai Sahar Airport Road", "Mumbai", "https://www.thelalit.com/wp-content/uploads/2017/02/Jaipur.jpg", "MUM" },
                    { 6, "Old Court House Street Dalhousie Square", "Kolkata", "https://www.thelalit.com/wp-content/uploads/2017/02/Kolkata.jpg", "KOL" },
                    { 7, "Road No 10, Banjara Hills", "Hyderabad", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Temple-View-Khajuraho.jpg", "HYD" },
                    { 8, "Ground Floor Mariplex Mall, Kalyani Nagar", "Pune", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Ashok-Bangalore.jpg", "PUN" },
                    { 9, "Patia, Kiit Square", "Bhubaneswar", "https://www.thelalit.com/wp-content/uploads/2016/12/The-LaLiT-Resort-Spa-Bekal.jpg", "BBSR" }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeId", "Description", "TypeName" },
                values: new object[,]
                {
                    { 1, "Experience unparalleled luxury in our Presidential Suite, where opulent comfort meets panoramic views and personalized service.", "Presidential Suite" },
                    { 2, "Discover refined comfort in our Executive Rooms, designed for business travelers and discerning guests seeking a touch of elegance.", "Executive" },
                    { 3, "Experience the pinnacle of comfort and elegance in our Super Deluxe Rooms, designed to cater to your every need.", "Super Deluxe" },
                    { 4, "Enjoy a comfortable and cozy stay in our Deluxe Rooms, offering modern amenities and a relaxing ambiance.", "Deluxe" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "HotelId", "Description", "HotelName", "LocationId" },
                values: new object[,]
                {
                    { 1, "A centrally located hotel, known for its lush green surroundings, spacious rooms, and premium dining.", "Radisson Blu Hotel", 1 },
                    { 2, "A business hotel, known for its comfortable rooms, wellness facilities, and dining options.", "The Westin Mindspace", 2 },
                    { 3, "A luxury beachfront retreat offering world-class spa services, gourmet dining, and panoramic ocean views.", "The Taj Gateway Hotel", 3 },
                    { 4, "Nestled in the heart of the forest, this cozy lodge is perfect for nature enthusiasts seeking tranquility and adventure.", "Whispering Pines Lodge", 4 },
                    { 5, "Chic and modern, these downtown suites provide a sophisticated stay for business travelers and city explorers.", "Urban Elegance Suites", 5 },
                    { 6, "Escape to the mountains and enjoy rustic charm, hiking trails, and stunning alpine vistas at this cozy retreat.", "Mountain Haven Retreat", 6 },
                    { 7, "A charming riverside inn with a peaceful ambiance, perfect for romantic getaways and nature lovers.", "Riverside Serenity Inn", 7 },
                    { 8, "Experience opulence and grandeur in this historic hotel, where luxury meets timeless elegance.", "The Royal Palace Hotel", 8 },
                    { 9, "A tropical paradise with private villas, water sports, and golden beaches - a dream vacation destination.", "Sunny Sands Resort & Villas", 9 },
                    { 10, "Located on the waterfront, these suites offer breathtaking harbor views, ideal for a coastal escape.", "Harbor View Suites", 8 },
                    { 11, "Immerse yourself in nature's beauty at this remote lodge with a spa, wildlife tours, and stargazing opportunities.", "Wilderness Lodge & Spa", 3 },
                    { 12, "A boutique hotel in the heart of the city, offering stylish rooms, fine dining, and easy access to cultural attractions.", "City Lights Boutique Hotel", 9 },
                    { 13, "Experience the tranquility of the countryside in this charming inn with rolling hills and farm-to-table cuisine.", "Countryside Charm Inn", 2 },
                    { 14, "A desert oasis with palm-lined pools, spa treatments, and desert adventures for a rejuvenating escape.", "Palm Oasis Resort", 3 },
                    { 15, "Step back in time in this meticulously restored mansion, offering a glimpse into the past with modern comforts.", "Historic Hideaway Mansion", 6 },
                    { 16, "Relax on white sandy beaches and enjoy water sports, beachfront dining, and breathtaking sunsets.", "Tropical Breeze Beachfront Resort", 7 },
                    { 17, "Nestled in the mountains, this lodge is a haven for skiers and hikers, with cozy fireside lounges and hot tubs.", "Alpine Retreat Lodge", 8 },
                    { 18, "Immerse yourself in the lush rainforest with guided hikes, canopy tours, and wildlife encounters.", "Rainforest Adventure Lodge", 5 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "HotelId", "PricePerNight", "RoomTypeId", "TotalRoomsAvailable" },
                values: new object[,]
                {
                    { 1, 1, 28000, 1, 2 },
                    { 2, 1, 20000, 2, 3 },
                    { 3, 1, 14000, 3, 3 },
                    { 4, 1, 8000, 4, 5 },
                    { 5, 2, 26000, 1, 2 },
                    { 6, 2, 22000, 2, 3 },
                    { 7, 2, 14000, 3, 4 },
                    { 8, 2, 9500, 4, 5 },
                    { 9, 3, 27000, 1, 2 },
                    { 10, 3, 2200, 2, 3 },
                    { 11, 3, 15000, 3, 3 },
                    { 12, 3, 8500, 4, 5 },
                    { 13, 4, 28000, 1, 2 },
                    { 14, 4, 23000, 2, 3 },
                    { 15, 4, 14000, 3, 3 },
                    { 16, 4, 8000, 4, 5 },
                    { 17, 5, 31000, 1, 2 },
                    { 18, 5, 20000, 2, 3 },
                    { 19, 5, 15500, 3, 3 },
                    { 20, 5, 8800, 4, 5 },
                    { 21, 6, 29500, 1, 2 },
                    { 22, 6, 20000, 2, 3 },
                    { 23, 6, 16000, 3, 3 },
                    { 24, 6, 8000, 4, 5 },
                    { 25, 7, 28000, 1, 2 },
                    { 26, 7, 20000, 2, 3 },
                    { 27, 7, 15500, 3, 3 },
                    { 28, 7, 8000, 4, 5 },
                    { 29, 8, 28000, 1, 2 },
                    { 30, 8, 21000, 2, 3 },
                    { 31, 8, 14000, 3, 3 },
                    { 32, 8, 8000, 4, 5 },
                    { 33, 9, 27000, 1, 2 },
                    { 34, 9, 20000, 2, 3 },
                    { 35, 9, 14000, 3, 3 },
                    { 36, 9, 8500, 4, 5 },
                    { 37, 10, 28000, 1, 2 },
                    { 38, 10, 21000, 2, 3 },
                    { 39, 10, 13000, 3, 3 },
                    { 40, 10, 7500, 4, 5 },
                    { 41, 11, 29500, 1, 2 },
                    { 42, 11, 20000, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "HotelId", "PricePerNight", "RoomTypeId", "TotalRoomsAvailable" },
                values: new object[,]
                {
                    { 43, 11, 14000, 3, 3 },
                    { 44, 11, 8000, 4, 5 },
                    { 45, 12, 27000, 1, 2 },
                    { 46, 12, 20000, 2, 3 },
                    { 47, 12, 14000, 3, 3 },
                    { 48, 12, 8000, 4, 5 },
                    { 49, 13, 29000, 1, 2 },
                    { 50, 13, 20000, 2, 3 },
                    { 51, 13, 13500, 3, 3 },
                    { 52, 13, 8000, 4, 5 },
                    { 53, 14, 28000, 1, 2 },
                    { 54, 14, 20000, 2, 3 },
                    { 55, 14, 14000, 3, 3 },
                    { 56, 14, 9000, 4, 5 },
                    { 57, 15, 29000, 1, 2 },
                    { 58, 15, 20000, 2, 3 },
                    { 59, 15, 14500, 3, 3 },
                    { 60, 15, 8500, 4, 5 },
                    { 61, 16, 27000, 1, 2 },
                    { 62, 16, 21000, 2, 3 },
                    { 63, 16, 14500, 3, 3 },
                    { 64, 16, 9500, 4, 5 },
                    { 65, 17, 33000, 1, 2 },
                    { 66, 17, 25000, 2, 3 },
                    { 67, 17, 15000, 3, 3 },
                    { 68, 17, 8500, 4, 5 },
                    { 69, 18, 32000, 1, 2 },
                    { 70, 18, 22000, 2, 3 },
                    { 71, 18, 13500, 3, 3 },
                    { 72, 18, 8200, 4, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_LocationId",
                table: "Hotels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_HotelId",
                table: "Rooms",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeId",
                table: "Rooms",
                column: "RoomTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
