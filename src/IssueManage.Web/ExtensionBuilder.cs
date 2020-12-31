using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Element;
using Element.Admin;
using IssueManage.Pages.Abstract;
using Admin.ServerRender;
using IssueManage.Services;

namespace IssueManage.Web
{
    public static class ExtensionBuilder
    {
        public static IServiceCollection AddAdmin<TUserService>(this IServiceCollection services)
            where TUserService : class, IUserService
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddBlazuiServices();
            services.AddSingleton<RouteService>();
            services.AddScoped<IUserService, TUserService>();
            services.AddService();
            services.AddAdmin<DocsDbContext, IdentityUser>();
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
