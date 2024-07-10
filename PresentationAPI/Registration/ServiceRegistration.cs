using PresentationAPI.Context;
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

namespace PresentationAPI.Registration
{
    public static class ServiceRegistration
    {
        public static void ApiService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DapperContext>();

            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IEstateService, EstateService>();
            services.AddTransient<IAboutService, AboutService>();
            services.AddTransient<IServiceService, ServiceService>();
            services.AddTransient<IBottomGridService, BottomGridService>();
            services.AddTransient<IPopularLocationService, PopularLocationService>();
            services.AddTransient<ITestimonialService, TestimonialService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEstateDetailService, EstateDetailService>();
            services.AddTransient<IStatisticService, StatisticService>();
            services.AddTransient<IContactService, ContactService>();
            services.AddTransient<IAddressService, AddressService>();
        }
    }
}
