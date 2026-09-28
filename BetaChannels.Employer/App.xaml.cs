using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BetaChannels.Employer;

/// <summary>
/// ایونت اتصال موفق دیوار
/// </summary>
public partial class App : Application
{
    public static event Action? DivarConnected;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        MainPage = new AppShell(serviceProvider);
    }

    /// <summary>
    /// مدیریت deep link — betachannel://login?by=divar&auth_token=...&user_id=...
    /// </summary>
    protected override async void OnAppLinkRequestReceived(Uri uri)
    {
        base.OnAppLinkRequestReceived(uri);

        if (uri.Scheme != "betachannel") return;

        // betachannel://login?by=divar&auth_token=xxx&user_id=yyy
        if (uri.Host == "login")
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var by = query["by"];
            var authToken = query["auth_token"];
            var userIdStr = query["user_id"];
            var connected = query["connected"];

            if (by == "divar" && connected == "true")
            {
                // اتصال دیوار موفق بود — اگر توکن جدید آمد، ذخیره کن
                if (!string.IsNullOrEmpty(authToken) && Guid.TryParse(userIdStr, out var userId))
                {
                    var authService = Application.Current?.Handler?.MauiContext?.Services
                        .GetService<IAuthService>() as AdmetrixAuthService;
                    if (authService != null)
                    {
                        await authService.SetTokenFromDeepLinkAsync(authToken, userId);
                    }
                }

                // اطلاع از طریق ایونت استاتیک
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    DivarConnected?.Invoke();
                });
            }
        }
    }
}
