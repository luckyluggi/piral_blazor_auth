using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

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
        services.AddAuthorizationCore();
        services.AddScoped(sp => (IRemoteAuthenticationService<RemoteAuthenticationState>)sp.GetRequiredService<AuthenticationStateProvider>());
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

        return services;
    } 
}
