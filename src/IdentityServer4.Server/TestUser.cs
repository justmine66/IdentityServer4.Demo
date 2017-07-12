using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServer4.Server
{
    public class TestUser
    {
        public string SubjectId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<Claim> Claims { get; set; }
    }
}