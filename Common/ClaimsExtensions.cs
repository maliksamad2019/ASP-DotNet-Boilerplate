using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Boilerplate.Common
{
    public static class ClaimsExtensions
    {
        /// <summary>
        /// Get FirstOrDefault Claim Value
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetClaimValue(this IEnumerable<System.Security.Claims.Claim> claims, string key)
        {
            return claims.FirstOrDefault(p => p.Type.ToLower() == key.ToLower())?.Value;
        }

        /// <summary>
        /// Get All Claims Values.
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetClaimValues(this IEnumerable<System.Security.Claims.Claim> claims, string key)
        {
            return claims.Where(p => p.Type.ToLower() == key.ToLower()).Select(s => s.Value);
        }
    }
}
