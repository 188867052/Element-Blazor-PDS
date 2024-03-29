﻿using Element.Admin;
using IssueManage.Pages;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace IssueManage
{
    public static class ExtensionBuilder2
    {
        public static IServiceCollection AddAdmin<TDbContext>(this IServiceCollection services)
            where TDbContext : IdentityDbContext<IdentityUser>
        {
            services.AddAdmin<IdentityUser, UserService, TDbContext>(null);
            return services;
        }
        public static IServiceCollection AddAdmin<TDbContext, TUser>(this IServiceCollection services)
            where TUser : IdentityUser
            where TDbContext : IdentityDbContext<TUser>
        {
            services.AddAdmin<TUser, UserService, TDbContext>(null);
            return services;
        }

        public static IServiceCollection AddAdmin<TUser, TUserService, TDbContext>(this IServiceCollection services, Action<IdentityOptions> optionConfigure)
            where TUser : IdentityUser
            where TDbContext : IdentityDbContext<TUser>
        {
            services.AddControllers();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddHttpClient();
            services.AddSingleton<ResourceAccessor>();
            services.AddSingleton<RouteService>();
            services.AddScoped<UserService>();
            services.AddAuthentication(o =>
            {
                o.DefaultScheme = IdentityConstants.ApplicationScheme;
                o.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddIdentityCookies();
            var builder = services.AddIdentityCore<TUser>(o =>
              {
                  o.Stores.MaxLengthForKeys = 128;
              }).AddRoles<IdentityRole>()
              .AddSignInManager<SignInManager<TUser>>()
              .AddDefaultTokenProviders()
              .AddEntityFrameworkStores<TDbContext>();

            if (optionConfigure != null)
            {
                services.Configure(optionConfigure);
            }
            else
            {
                services.Configure<IdentityOptions>(options =>
                {
                    // Default Password settings.
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 1;
                });
            }
            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
            return services;
        }
    }
}
