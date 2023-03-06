using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace Framework.Authentication;

public class MyAuthenticationState
{
    #region deps
    NavigationManager _navigationManager;
    AuthenticationStateProvider _authenticationStateProvider;
    #endregion 

    #region props
    public AuthenticationState AuthState { get; set; }
    public bool IsAuthenticated { get => AuthState?.User?.Identity?.IsAuthenticated ?? false; }
    public event Action OnStateChange;
    #endregion

    #region ctor
    public MyAuthenticationState(NavigationManager navigationManager, AuthenticationStateProvider authenticationStateProvider)
    {
        _navigationManager = navigationManager;
        _authenticationStateProvider = authenticationStateProvider;
    }
    #endregion

    #region operations
    public void Initialize()
    {
        _authenticationStateProvider.AuthenticationStateChanged += OnAuthenticationStateChanged;
        OnAuthenticationStateChanged(_authenticationStateProvider.GetAuthenticationStateAsync());
    }
    public void NotifyStateChanged()
    {
        OnStateChange?.Invoke();
    }
    public void Login()
    {
        _navigationManager.NavigateTo($"authentication/login?returnUrl={Uri.EscapeDataString(_navigationManager.Uri)}");
    }
    public void Logout()
    {
        Microsoft.AspNetCore.Components.WebAssembly.Authentication.NavigationManagerExtensions.NavigateToLogout(_navigationManager, "/authentication/logout");
    }

    private async void OnAuthenticationStateChanged(Task<AuthenticationState> authenticationStateTask)
    {
        AuthState = await authenticationStateTask;
        NotifyStateChanged();
    }
    #endregion
}
