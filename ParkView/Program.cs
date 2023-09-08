using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ParkView.Models;
using ParkView.Models.DbRepos;
using ParkView.Models.DbRepositories;
using ParkView.Models.IRepositories;
using Stripe;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ParkViewDbConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication().AddGoogle(
    googleOptions =>
    {
        googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
    }
    );

builder.Services.AddAuthentication().AddFacebook(
    facebookOptions =>
    {
        facebookOptions.ClientId = builder.Configuration["Authentication:Facebook:ClientId"];
        facebookOptions.ClientSecret = builder.Configuration["Authentication:Facebook:ClientSecret"];
    }
    );

builder.Services.AddScoped<IHotelRepo, HotelDbRepo>();
builder.Services.AddScoped<IRoomRepo, RoomDbRepo>();
builder.Services.AddScoped<IBookingRepo, BookingDbRepo>();
builder.Services.AddScoped<ITransactionRepo, TransactionDbRepo>();
builder.Services.AddScoped<IUserRepo, UserDbRepo>();
builder.Services.AddScoped<IContactRepo, ContactDbRepo>();

StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
