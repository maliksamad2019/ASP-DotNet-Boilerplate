using ASP_Net_Boilerplate.Controllers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP_Net_Boilerplate.Common
{
    public class CurrentUser
    {
        private readonly UserClaims ClaimsContext;
        public CurrentUser(IHttpContextAccessor context)
        {

            ClaimsContext = new UserClaims();

            var claims = context.HttpContext.User.Claims.ToList();
            ClaimsContext.Email = claims.GetClaimValue(UserClaimsType.Email);
            ClaimsContext.Id = claims.GetClaimValue(UserClaimsType.Id);
            ClaimsContext.Roles = claims.GetClaimValues(UserClaimsType.Roles).ToList();
            ClaimsContext.Username = claims.GetClaimValue(UserClaimsType.Username);
        }

        public UserClaims Claims
        {
            get
            {
                return ClaimsContext;
            }
        }
    }
}
