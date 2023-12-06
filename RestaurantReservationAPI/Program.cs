using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestaurantReservation.Db;
using RestaurantReservation.Db.IRepositories;
using RestaurantReservation.Repositories;
using RestaurantReservationAPI.Profiles;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant Reservation API V1"));
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Authentication:Issuer"],
            ValidAudience = configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:SecretForKey"]))
        };
    });

    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API Title", Version = "v1" });
    });

    services.AddDbContext<RestaurantReservationDbContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
    });


    services.AddScoped<ICustomerRepository, CustomerRepository>();
    services.AddAutoMapper(typeof(CustomerProfile));

    services.AddScoped<IEmployeeRepository, EmployeeRepository>();
    services.AddAutoMapper(typeof(EmployeeProfile));

    services.AddScoped<IMenuItemRepository, MenuItemRepository>();
    services.AddAutoMapper(typeof(MenuItemProfile));

    services.AddScoped<IOrderRepository, OrderRepository>();
    services.AddAutoMapper(typeof(OrderProfile));

    services.AddScoped<IOrderItemRepository, OrderItemRepository>();
    services.AddAutoMapper(typeof(OrderProfile));

    services.AddScoped<IReservationRepository, ReservationRepository>();
    services.AddAutoMapper(typeof(ReservationProfile));

    services.AddScoped<IRestaurantRepository, RestaurantRepository>();
    services.AddAutoMapper(typeof(RestaurantProfile));

    services.AddScoped<ITableRepository, TableRepository>();
    services.AddAutoMapper(typeof(TableProfile));

    services.AddScoped<ITokenService, TokenService>();
}