using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Server;
using System.Security.Claims;

namespace IdentityServer4.Server
{
    public class Config
    {
        //定义系统中的资源
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            // 客户端凭据
            return new List<Client>
            {
                // OpenID Connect implicit 客户端 (MVC)
                new Client
                {
                    ClientId = "mvc",
                    ClientName = "MVC Client",
                    AllowedGrantTypes = GrantTypes.Implicit,

                    RedirectUris = { "http://localhost:5002/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:5002" },
                    //运行访问的资源
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile
                    }
                }
            };
        }

        //测试用户
        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "1",
                    Username = "admin",
                    Password = "123456",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "admin"),
                        new Claim("website", "https://www.cnblogs.com/linezero")
                    }
                },
                new TestUser
                {
                    SubjectId = "2",
                    Username = "lijun",
                    Password = "123456",

                    Claims = new List<Claim>
                    {
                        new Claim("name", "linezero"),
                        new Claim("website", "https://github.com/linezero")
                    }
                }
            };
        }
    }
}
