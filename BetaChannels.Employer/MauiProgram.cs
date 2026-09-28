using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using BetaChannels.Employer.Services;
using BetaChannels.Employer.Pages;
using BetaChannels.Employer.Pages.Auth;
using BetaChannels.Employer.Pages.Divar;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Services;
using Sentry;

namespace BetaChannels.Employer;

public static class MauiProgram
{
    // آدرس بک‌اند ادمتریکس — در تولید تغییر کند
    private const string ApiBaseUrl = "https://admetrix.ir";

    // Sentry DSN برای ردیابی خطاها
    private const string SentryDsn = "https://a1e4edf57b884bdc9226d64359475855@sentry.miladzandi.ir/6";

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSentry(options =>
            {
                options.Dsn = SentryDsn;
                options.TracesSampleRate = 1.0;
                options.Debug = false;
#if DEBUG
                options.Environment = "development";
#else
                options.Environment = "production";
#endif
            })
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("Vazirmatn-Variable.woff2", "Vazirmatn");
                fonts.AddFont("Vazirmatn-Bold.ttf", "VazirmatnBold");
                fonts.AddFont("tabler-icons.ttf", "TablerIcons");
                fonts.AddFont("tabler-icons-filled.ttf", "TablerIconsFilled");
                fonts.AddFont("tabler-icons-200.ttf", "TablerIconsThin");
                fonts.AddFont("tabler-icons-300.ttf", "TablerIconsLight");
            });

        builder.Logging.AddSentry();

#if DEBUG
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

#if DEBUG
        // در حالت توسعه از Mock استفاده کن (بک‌اند در دسترس نیست)
        builder.Services.AddSingleton<IAuthService, MockAuthService>();
#else
        // سرویس‌های واقعی — متصل به بک‌اند ادمتریکس
        builder.Services.AddSingleton<IAuthService>(sp =>
            new AdmetrixAuthService(apiClient, sp.GetRequiredService<ITokenStorage>()));
#endif
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

        // Shell page factories use transient lifetimes so constructor dependencies are injected.
        builder.Services.AddTransient<DashboardPage>();
        builder.Services.AddTransient<FreelancersPage>();
        builder.Services.AddTransient<ProjectsPage>();
        builder.Services.AddTransient<PaymentsPage>();
        builder.Services.AddTransient<MessagesPlaceholderPage>();
        builder.Services.AddTransient<SettingsPlaceholderPage>();
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<DivarAnalyticsPage>();
        builder.Services.AddTransient<DivarLoginPage>();
        builder.Services.AddTransient<AccountingPage>();
        builder.Services.AddTransient<AdChannelsPage>();
        builder.Services.AddTransient<BetaNetworksPage>();
        builder.Services.AddTransient<CompetitorAnalysisPage>();
        builder.Services.AddTransient<ContentSeoPage>();
        builder.Services.AddTransient<GrowthManagementPage>();
        builder.Services.AddTransient<MillionIdeasPage>();
        builder.Services.AddTransient<PublishPage>();
        builder.Services.AddTransient<SmartBotPage>();

        return builder.Build();
    }
}
