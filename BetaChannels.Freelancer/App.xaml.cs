using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetaChannels.Freelancer;

/// <summary>
/// ایونت اتصال موفق دیوار — Blazor component مشترک می‌شود
/// </summary>
public partial class App : Application
{
    public static event Action? DivarConnected;

    public App()
    {
        InitializeComponent();
        MainPage = new MainPage();
    }

    /// <summary>
    /// مدیریت deep link — betachannel://login?by=divar&auth_token=...&user_id=...
    /// </summary>
    protected override async void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);

        if (uri.Scheme != "betachannel") return;

        if (uri.Host == "login")
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var by = query["by"];
            var authToken = query["auth_token"];
            var userIdStr = query["user_id"];
            var connected = query["connected"];

            if (by == "divar" && connected == "true")
            {
                if (!string.IsNullOrEmpty(authToken) && Guid.TryParse(userIdStr, out var userId))
                {
                    var authService = Application.Current?.Handler?.MauiContext?.Services
                        .GetService<IAuthService>() as AdmetrixAuthService;
                    if (authService != null)
                    {
                        await authService.SetTokenFromDeepLinkAsync(authToken, userId);
                    }
                }

                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    DivarConnected?.Invoke();
                });
            }
        }
    }
}
