using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PresentationAPI.Context;
using PresentationAPI.Hubs;
using PresentationAPI.Services.AboutServices;
using PresentationAPI.Services.AddressServices;
using PresentationAPI.Services.BottomGridServices;
using PresentationAPI.Services.CategoryServices;
using PresentationAPI.Services.ClientServices;
using PresentationAPI.Services.ContactServices;
using PresentationAPI.Services.EmployeeServices;
using PresentationAPI.Services.EstateDetailServices;
using PresentationAPI.Services.EstateServices;
using PresentationAPI.Services.PopularLocationServices;
using PresentationAPI.Services.ServiceServices;
using PresentationAPI.Services.StatisticServices;
using PresentationAPI.Services.TestimonialServices;
using PresentationAPI.Tools;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidAudience = JwtTokenDefaults.ValidAudience,
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});

builder.Services.AddHttpClient();

builder.Services.AddTransient<DapperContext>();

builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IEstateService, EstateService>();
builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddTransient<IServiceService, ServiceService>();
builder.Services.AddTransient<IBottomGridService, BottomGridService>();
builder.Services.AddTransient<IPopularLocationService, PopularLocationService>();
builder.Services.AddTransient<ITestimonialService, TestimonialService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IEstateDetailService, EstateDetailService>();
builder.Services.AddTransient<IStatisticService, StatisticService>();
builder.Services.AddTransient<IContactService, ContactService>();
builder.Services.AddTransient<IAddressService, AddressService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials());
});

builder.Services.AddSignalR();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<AppHub>("/apphub");

app.Run();
