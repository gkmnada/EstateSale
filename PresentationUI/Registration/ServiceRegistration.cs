using PresentationUI.Handlers;
using PresentationUI.Services.AboutServices;
using PresentationUI.Services.AddressServices;
using PresentationUI.Services.BottomGridServices;
using PresentationUI.Services.CategoryServices;
using PresentationUI.Services.ClientServices;
using PresentationUI.Services.ContactServices;
using PresentationUI.Services.EmployeeServices;
using PresentationUI.Services.EstateDetailServices;
using PresentationUI.Services.EstateServices;
using PresentationUI.Services.LoginServices;
using PresentationUI.Services.PopularLocationServices;
using PresentationUI.Services.ServiceServices;
using PresentationUI.Services.SocialMediaServices;
using PresentationUI.Services.StatisticServices;
using PresentationUI.Services.SubscribeServices;
using PresentationUI.Services.TestimonialServices;
using PresentationUI.Settings;

namespace PresentationUI.Registration
{
    public static class ServiceRegistration
    {
        public static void ApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
            services.AddTransient<AuthorizedHttpClientHandler>();

            var values = configuration.GetSection("ApiSettings").Get<ApiSettings>();

            services.AddScoped<ILoginService, LoginService>();

            services.AddHttpClient<IAboutService, AboutService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IAddressService, AddressService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IBottomGridService, BottomGridService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<ICategoryService, CategoryService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            }).AddHttpMessageHandler<AuthorizedHttpClientHandler>();

            services.AddHttpClient<IClientService, ClientService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IContactService, ContactService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IEmployeeService, EmployeeService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IEstateDetailService, EstateDetailService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IEstateService, EstateService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IPopularLocationService, PopularLocationService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IServiceService, ServiceService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<ISocialMediaService, SocialMediaService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<IStatisticService, StatisticService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<ISubscribeService, SubscribeService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });

            services.AddHttpClient<ITestimonialService, TestimonialService>(options =>
            {
                options.BaseAddress = new Uri(values.PresentationAPI);
            });
        }
    }
}
