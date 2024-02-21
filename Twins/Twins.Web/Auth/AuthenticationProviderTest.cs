using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace Twins.Web.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider

    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            //await Task.Delay(3000);
            var anonimous = new ClaimsIdentity();
            var sebasUser = new ClaimsIdentity(new List<Claim>
            {
                new Claim("FirstName","Sebastian"),
                new Claim("LastName","Sebastian"),
                new Claim(ClaimTypes.Name,"Sebastian@yopmail.com"),
                new Claim(ClaimTypes.Role,"Admin")
            },
            authenticationType: "test");
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(sebasUser)));
        }

    }
}
