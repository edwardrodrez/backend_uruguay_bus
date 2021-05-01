using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AppRest.Cast;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Share.Entities;
using WEBAPI_CustomAuth.CustomIdentity;
using WEBAPI_CustomAuth.Models;

namespace WEBAPI_CustomAuth
{
    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }
        IBL_Usuario con = new BL_Usuario();

        public new async Task<ApplicationUser> FindAsync(string userName, string password)
        {

            Usuario us = con.login(userName, password);

            if (us == null)
            {
                return null;
            }
            else
            {
                User us2 = castUser.cast(con.GetUsuarioPorCorreo(userName));
                ApplicationUser a = new ApplicationUser();
                a.Id = us2.Id;
                a.UserName = us2.UserName;
                return a;
            }

        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new CustomIdentity.UserStore<ApplicationUser>());
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = true,
                RequireDigit = true,
                RequireLowercase = true,
                RequireUppercase = true,
            };
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }
}
