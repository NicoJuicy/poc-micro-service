using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> Apis =>
            new List<ApiResource>
            {
            new ApiResource("api1", "My API",new List<string>(){ 
            "notes","tags","scheduler","contacts"
                })
            };


        public static IEnumerable<Client> Clients =>
            new List<Client>
            {
        new Client
        {
            ClientId = "client",
         

            // no interactive user, use the clientid/secret for authentication
            AllowedGrantTypes = GrantTypes.ClientCredentials,

            // secret for authentication
            ClientSecrets =
            {
                new Secret("secret".Sha256())
            },

            // scopes that client has access to
            AllowedScopes = { "api1" }
        }
            };

    }
}
