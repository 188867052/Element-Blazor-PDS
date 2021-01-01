using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Element;
using Element.Admin;

namespace IssueManage
{
    public static class ExtensionBuilder
    {
        public static IServiceCollection AddAdmin(this IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddBlazuiServices();
            services.AddSingleton<RouteService>();
            services.AddScoped<UserService>();
            services.AddService();
            services.AddAdmin<AdminDbContext, IdentityUser>();
            return services;
        }

        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<ProductService>();
            services.AddTransient<IssueService>();
            services.AddTransient<MeetingService>();
            services.AddTransient<CustomerService>();
            return services;
        }

        public static IApplicationBuilder UseAdmin(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseAuthentication();
            return app;
        }
    }
}
