namespace BetaChannels.Employer.Pages;

public partial class AccountingPage : ContentPage
{
    public AccountingPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    private void OnInvoicesTab(object? sender, TappedEventArgs e) => SwitchTab(0);
    private void OnNetworksTab(object? sender, TappedEventArgs e) => SwitchTab(1);
    private void OnGatewayTab(object? sender, TappedEventArgs e) => SwitchTab(2);

    private void SwitchTab(int index)
    {
        var tabs = new[] { InvoicesTab, NetworksTab, GatewayTab };
        var sections = new[] { InvoicesSection, NetworksSection, GatewaySection };

        for (int i = 0; i < tabs.Length; i++)
        {
            if (i == index)
            {
                tabs[i].BackgroundColor = Color.FromArgb("#FF6B35");
                ((Label)tabs[i].Content).TextColor = Colors.White;
                sections[i].IsVisible = true;
            }
            else
            {
                tabs[i].BackgroundColor = Colors.Transparent;
                ((Label)tabs[i].Content).TextColor = Color.FromArgb("#8888aa");
                sections[i].IsVisible = false;
            }
        }
    }

    private async void OnCreateInvoiceTapped(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("ایجاد فاکتور", "فرم ایجاد فاکتور جدید به زودی فعال می‌شود.", "باشه");
    }

    private async void OnAddNetworkClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("افزودن شبکه", "فرم افزودن شبکه فروش به زودی فعال می‌شود.", "باشه");
    }
}
