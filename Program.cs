using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.BusinessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DoktormandenDB")));

builder.Services.AddSingleton<IUserService, UserService>(); // Userprofile logic for demo purpose
builder.Services.AddScoped<IAppointmentsService, AppointmentService>(); // Service for Appointments
builder.Services.AddScoped<IEConsultationService, EConsultationService>(); // Service for eConsultations

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
