using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Epita.QueueStorage.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Epita.QueueStorage.Gateway.Security
{
    public class SecurityManager
    {
        private const string applicationId = "ApplicationId";
        private readonly IHttpContextAccessor accessor;
        private readonly string securityKey;

        public SecurityManager(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
            using RandomNumberGenerator rng = RandomNumberGenerator.Create();

            var data = new byte[64];
            rng.GetBytes(data);

            securityKey = Encoding.UTF8.GetString(data);
        }

        public async Task SignInAsync(User user)
        {
            var identity = new GenericIdentity(user.Id, CookieAuthenticationDefaults.AuthenticationScheme);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(applicationId, securityKey)
            };

            var claimsIdentity = new ClaimsIdentity(identity, claims);

            var authProperties = new AuthenticationProperties();
            
            await accessor.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public async Task SignOutAsync()
        {
            await accessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsPrincipalObsolete(ClaimsPrincipal principal)
        {
            string claim = principal.FindFirstValue(applicationId);

            if (string.IsNullOrEmpty(claim))
            {
                return false;
            }

            return !string.Equals(claim, securityKey);
        }
    }
}