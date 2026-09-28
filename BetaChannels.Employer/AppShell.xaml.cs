using BetaChannels.Employer.Pages;
using BetaChannels.Employer.Pages.Auth;
using BetaChannels.Employer.Pages.Divar;
using Microsoft.Extensions.DependencyInjection;

namespace BetaChannels.Employer;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        var pageTypes = new Dictionary<string, Type>
        {
            ["login"] = typeof(LoginPage),
            ["register"] = typeof(RegisterPage),
            ["dashboard"] = typeof(DashboardPage),
            ["divar"] = typeof(DivarAnalyticsPage),
            ["messages"] = typeof(MessagesPlaceholderPage),
            ["settings"] = typeof(SettingsPlaceholderPage),
            ["freelancers"] = typeof(FreelancersPage),
            ["projects"] = typeof(ProjectsPage),
            ["payments"] = typeof(PaymentsPage),
            ["divar/login"] = typeof(DivarLoginPage),
            ["growth"] = typeof(GrowthManagementPage),
            ["content-seo"] = typeof(ContentSeoPage),
            ["networks"] = typeof(BetaNetworksPage),
            ["ad-channels"] = typeof(AdChannelsPage),
            ["accounting"] = typeof(AccountingPage),
            ["ideas"] = typeof(MillionIdeasPage),
            ["smart-bot"] = typeof(SmartBotPage),
            ["publish"] = typeof(PublishPage),
            ["competitors"] = typeof(CompetitorAnalysisPage)
        };

        foreach (var shellItem in Items)
        foreach (var section in shellItem.Items)
        foreach (var shellContent in section.Items)
        {
            if (pageTypes.TryGetValue(shellContent.Route, out var pageType))
                shellContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService(pageType));
        }
    }
}
