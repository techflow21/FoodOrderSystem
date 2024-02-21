using FoodOrderingSystem.Infrastructure.DataContext;
using FoodOrderingSystem.Infrastructure.Repository;
using FoodOrderingSystem.Services.EmailService;
using FoodOrderingSystem.Services.ImageService;
using FoodOrderingSystem.Services.Implementations;
using FoodOrderingSystem.Services.Interfaces;
using FoodOrderingSystem.Services.NotificationService;
using FoodOrderingSystem.Services.SmsService;

namespace FoodOrderingSystem.Api.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        public static void ConfigureServices(this IServiceCollection services)
        {
            /*services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.Password.RequiredLength = 6;
                opt.Password.RequireDigit = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;

                //opt.Tokens.EmailConfirmationTokenProvider = "emailconfirmation";

                opt.Lockout.AllowedForNewUsers = true;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                opt.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();*/

            //services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddTransient<IMailKitEmailService, MailKitEmailService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IImageUploadService, ImageUploadService>();
            services.AddScoped<IAwsStorageService, AwsStorageService>();
            services.AddScoped<IAwsNotificationService, AwsNotificationService>();
            services.AddScoped<ISnsSubscriptionService, SnsSubscriptionService>();
            services.AddScoped<ILocalStorageService, LocalStorageService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<INexmoSmsService, NexmoSmsService>();
            //services.AddScoped<ITwilioSmsService, TwilioSmsService>();

            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IMailKitEmailService, MailKitEmailService>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IContactService, ContactService>();

            //services.AddScoped<IReportService, ReportService>();
        }
    }
}
