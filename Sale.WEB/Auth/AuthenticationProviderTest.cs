using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Sale.WEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            
            var anonimous = new ClaimsIdentity();
            var PruebaUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName", "Jose"),
                new Claim("LastName", "Valencia"),
                new Claim(ClaimTypes.Name, "jose.valencia@yopmail.com"),
                new Claim(ClaimTypes.Role, "Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(anonimous)));
        }
    }
}
