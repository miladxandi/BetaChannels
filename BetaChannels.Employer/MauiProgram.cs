using Microsoft.Extensions.Logging;
using BetaChannels.Employer.Services;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;

namespace BetaChannels.Employer;

public static class MauiProgram
{
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

        // Register shared services
        builder.Services.AddSingleton<IAuthService, MockAuthService>();
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
