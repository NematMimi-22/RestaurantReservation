using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RestaurantReservation.Db;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using RestaurantReservationAPI.Profiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant Reservation API", Version = "v1" });
});

builder.Services.AddDbContext<RestaurantReservationDbContext>(options =>
{
    options.UseSqlServer("Data Source=DESKTOP-CUQN3UP\\SQLEXPRESS;Initial Catalog=RestaurantReservationCore;Integrated Security=True;TrustServerCertificate=true");
});

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddAutoMapper(typeof(CustomerProfile));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddAutoMapper(typeof(EmployeeProfile));

builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddAutoMapper(typeof(MenuItemProfile));

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddAutoMapper(typeof(OrderProfile));

builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddAutoMapper(typeof(OrderProfile));

builder.Services.AddScoped<IReservationRepository,ReservationRepository>();
builder.Services.AddAutoMapper(typeof(ReservationProfile));

builder.Services.AddScoped<IRestaurantRepository, RestaurantRepository>();
builder.Services.AddAutoMapper(typeof(RestaurantProfile));

builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddAutoMapper(typeof(TableProfile));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Reservation API V1"));
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();