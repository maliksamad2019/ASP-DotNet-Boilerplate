using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Net_Boilerplate.Common
{
    public class UserClaims
    {
        public string Username { get; set; }
        public List<string> Roles { get; set; }
        public string Email { get; set; }
        public string Id { get; set; }
    }

    public static class UserClaimsType{
        public const string Username = "username";
        public const string Email = "user-email";
        public const string Roles = "user-role";
        public const string Id = "user-id";
    }
}
