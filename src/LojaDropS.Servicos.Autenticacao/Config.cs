using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LojaDropS.Servicos.Autenticacao
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Email(),
                new IdentityResources.Profile(),
                new IdentityResources.Phone(),
                new IdentityResources.Address(),
                new IdentityResource
                {
                    Name = "roles",
                    DisplayName = "Roles",
                    UserClaims =
                    {
                        "role"
                    }
                }
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new ApiResource[]
            {
                new ApiResource
                {
                    Name = "apiVendas",
                    DisplayName = "Api Vendas",
                    Enabled = true,
                    ApiSecrets =
                    {
                        new Secret("iTqp9@&9EQAbEv")
                    },
                    Scopes =
                    {
                        new Scope("api.vendas:full")
                    },
                }
            };
        }

        public static List<TestUser> GetUsers()
        {
            return new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "2573",
                    Username = "usuario1",
                    IsActive = true,
                    Password = "123456",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Usuário 1"),
                        new Claim(JwtClaimTypes.Email, "usuario1@email.com"),
                        new Claim(JwtClaimTypes.PhoneNumber, "55319665596836"),
                        new Claim(JwtClaimTypes.Role, "user"),
                    }
                },
                new TestUser
                {
                    SubjectId = "1617",
                    Username = "fornecedor1",
                    IsActive = true,
                    Password = "123456",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Fornecedor 1"),
                        new Claim(JwtClaimTypes.Email, "fornecedor1@email.com"),
                        new Claim(JwtClaimTypes.PhoneNumber, "5531963524685"),
                        new Claim(JwtClaimTypes.Role, "fornecedor"),
                    }
                },
                new TestUser
                {
                    SubjectId = "9852",
                    Username = "admin1",
                    IsActive = true,
                    Password = "123456",
                    Claims =
                    {
                        new Claim(JwtClaimTypes.Name, "Admin 1"),
                        new Claim(JwtClaimTypes.Email, "admin1@email.com"),
                        new Claim(JwtClaimTypes.PhoneNumber, "5531965325899"),
                        new Claim(JwtClaimTypes.Role, "admin"),
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    Enabled = true,
                    ClientName = "Loja  - Marketplace",
                    ClientId = "lojadrops.marketplace",
                    ClientSecrets =
                    {
                        new Secret("123456".Sha256())
                    },
                    AllowedScopes =
                    {
                        "api.vendas:full",
                        "openid",
                        "profile",
                        "email",
                        "roles"
                    },
                    AllowAccessTokensViaBrowser = true,
                    AllowedGrantTypes = GrantTypes.Implicit,
                    ClientUri = "http://localhost:4200",
                    RedirectUris = { "http://localhost:4200/#/login-callback?" },
                    //RedirectUris = { "http://localhost:4200/signin-oidc" },
                    PostLogoutRedirectUris = { "http://localhost:4200/#/" },
                    AllowedCorsOrigins =
                    {
                        "http://localhost:4200"
                    },
                    RequireConsent = false
                },
                new Client
                {
                    ClientId = "apiClient",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("123456".ToSha256())
                    },
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    AllowedScopes =
                    {
                        "api.vendas:full",
                        "openid",
                        "profile",
                        "email",
                    }
                },
            };
        }

    }
}
