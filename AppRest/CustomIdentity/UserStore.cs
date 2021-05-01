using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using AppRest.Cast;
using BusinessLayer.Implementations;
using BusinessLayer.Interfaces;
using Microsoft.AspNet.Identity;
using WEBAPI_CustomAuth.Models;

namespace WEBAPI_CustomAuth.CustomIdentity
{
    public class UserStore<TUser> :
        IUserLoginStore<TUser>,
        IUserClaimStore<TUser>,
        IUserRoleStore<TUser>,
        IUserPasswordStore<TUser>,
        IUserSecurityStampStore<TUser>,
        IQueryableUserStore<TUser>,
        IUserEmailStore<TUser>,
        IUserPhoneNumberStore<TUser>,
        IUserTwoFactorStore<TUser, string>,
        IUserLockoutStore<TUser, string>,
        IUserStore<TUser>
        where TUser : ApplicationUser
    {
        IBL_Usuario con = new BL_Usuario();
        public IQueryable<TUser> Users => throw new NotImplementedException();


        public Task AddLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task AddToRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync(TUser user)
        {
            con.AddUsuario(castUser.cast(user));
            return Task.FromResult(0);
        }

        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
        }

        public Task<TUser> FindAsync(UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task<TUser> FindByEmailAsync(string email)
        {
            TUser user = (TUser)castUser.cast(con.GetUsuarioPorCorreo(email));
            return Task.FromResult(user);
        }

        public Task<TUser> FindByIdAsync(string userId)
        {
            User u = castUser.cast(con.GetUsuario(Int32.Parse(userId)));
            ApplicationUser user2 = new ApplicationUser();
            user2.Id = u.Id;
            user2.UserName = u.UserName;
            user2.rol = "User";
            user2.UserName = u.UserName;
            user2.SecurityStamp = Guid.NewGuid().ToString();
            TUser user = (TUser)user2;
            return Task.FromResult(user);
        }

        public Task<TUser> FindByNameAsync(string userName)
        {
            TUser user = (TUser)castUser.cast(con.GetUsuarioPorCorreo(userName));
            return Task.FromResult(user);
        }

        public Task AddClaimAsync(TUser user, Claim claim)
        {
            return Task.FromResult<int>(0);
        }


        public Task RemoveClaimAsync(TUser user, Claim claim)
        {
            return Task.FromResult<int>(0);
        }

        public Task<int> GetAccessFailedCountAsync(TUser user)
        {
            return Task.FromResult(0);
        }

        public Task<IList<Claim>> GetClaimsAsync(TUser user)
        {
            IList<Claim> result = new List<Claim>();
            return Task.FromResult(result);
        }

        public Task<string> GetEmailAsync(TUser user)
        {
            return Task.FromResult(user.UserName);
        }

        public Task<bool> GetEmailConfirmedAsync(TUser user)
        {
            return Task.FromResult(true);
        }

        public Task<bool> GetLockoutEnabledAsync(TUser user)
        {
            return Task.FromResult(false);
        }

        public Task<DateTimeOffset> GetLockoutEndDateAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetPasswordHashAsync(TUser user)
        {
            return Task.FromResult(user.password);
        }

        public Task<string> GetPhoneNumberAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(TUser user)
        {
            IList<string> result = new List<string>();
            result.Add(user.rol);
            return Task.FromResult(result);
        }

        public Task<string> GetSecurityStampAsync(TUser user)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }

        public Task<bool> GetTwoFactorEnabledAsync(TUser user)
        {
            return Task.FromResult(false);
        }

        public Task<bool> HasPasswordAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<int> IncrementAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }


        public Task RemoveFromRoleAsync(TUser user, string roleName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveLoginAsync(TUser user, UserLoginInfo login)
        {
            throw new NotImplementedException();
        }

        public Task ResetAccessFailedCountAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailAsync(TUser user, string email)
        {
            throw new NotImplementedException();
        }

        public Task SetEmailConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetLockoutEnabledAsync(TUser user, bool enabled)
        {
            return Task.FromResult(0);
        }

        public Task SetLockoutEndDateAsync(TUser user, DateTimeOffset lockoutEnd)
        {
            throw new NotImplementedException();
        }

        public Task SetPasswordHashAsync(TUser user, string passwordHash)
        {
            user.password = passwordHash;
            return Task.FromResult(0);
        }

        public Task SetPhoneNumberAsync(TUser user, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Task SetPhoneNumberConfirmedAsync(TUser user, bool confirmed)
        {
            throw new NotImplementedException();
        }

        public Task SetSecurityStampAsync(TUser user, string stamp)
        {
            user.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        public Task SetTwoFactorEnabledAsync(TUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TUser user)
        {
            throw new NotImplementedException();
        }
    }
}