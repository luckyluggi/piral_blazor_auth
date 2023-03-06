using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components.Authorization;

namespace Framework.Authentication;

[ExcludeFromCodeCoverage]
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds all authentication relevant stuff
    /// </summary>
    /// <param name="services">IServiceCollection</param>
    public static IServiceCollection AddMyAuthentication(this IServiceCollection services)
    {
        services.AddMsalAuthentication<RemoteAuthenticationState, MyAccount>(opt => {

            opt.ProviderOptions.Authentication.Authority = "[AUTHORITY]";
            opt.ProviderOptions.Authentication.ClientId = "[CLIENT_ID]";

            opt.ProviderOptions.Authentication.ValidateAuthority = false;
            opt.ProviderOptions.Authentication.RedirectUri = $"/authentication/login-callback";
            opt.ProviderOptions.Authentication.PostLogoutRedirectUri = $"/login";
            opt.ProviderOptions.LoginMode = "redirect"; 

            opt.ProviderOptions.DefaultAccessTokenScopes.Add("openid");
            opt.ProviderOptions.DefaultAccessTokenScopes.Add("offline_access");
        });
        services.AddScoped(sp => sp.GetRequiredService<AuthenticationStateProvider>());

        return services;
    }
}
