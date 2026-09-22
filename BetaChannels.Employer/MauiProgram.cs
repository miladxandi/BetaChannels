using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BetaChannels.Employer.Services;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;

namespace BetaChannels.Employer;

public static class MauiProgram
{
    // آدرس بک‌اند ادمتریکس — در تولید تغییر کند
    private const string ApiBaseUrl = "https://admetrix.ir";

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        // HttpClient برای اتصال به بک‌اند ادمتریکس
        var apiClient = new HttpClient
        {
            BaseAddress = new Uri(ApiBaseUrl),
        };
        apiClient.DefaultRequestHeaders.Add("Accept", "application/json");

        // سرویس ذخیره‌سازی امن توکن (MAUI SecureStorage)
        builder.Services.AddSingleton<ITokenStorage, MauiTokenStorage>();

        // سرویس‌های واقعی
        builder.Services.AddSingleton<IAuthService>(sp =>
            new AdmetrixAuthService(apiClient, sp.GetRequiredService<ITokenStorage>()));
        builder.Services.AddSingleton<IDivarService>(new DivarService(apiClient));

        // سایر سرویس‌ها (هنوز Mock)
        builder.Services.AddSingleton<IFreelancerService, MockFreelancerService>();
        builder.Services.AddSingleton<IServiceService, MockServiceService>();
        builder.Services.AddSingleton<IPortfolioService, MockPortfolioService>();
        builder.Services.AddSingleton<IContentCalendarService, MockContentCalendarService>();
        builder.Services.AddSingleton<IPaymentService, MockPaymentService>();
        builder.Services.AddSingleton<ISubscriptionService, MockSubscriptionService>();
        builder.Services.AddSingleton<IAdvertisingService, MockAdvertisingService>();

        // Register app-specific services
        builder.Services.AddSingleton<AppState>();

        return builder.Build();
    }
}
