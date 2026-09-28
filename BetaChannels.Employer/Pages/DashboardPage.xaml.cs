using BetaChannels.Employer.Services;

namespace BetaChannels.Employer.Pages;

public partial class DashboardPage : ContentPage
{
    private readonly AppState _appState;
    private bool _drawerOpen;

    public DashboardPage(AppState appState)
    {
        InitializeComponent();
        _appState = appState;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateDrawerUserInfo();
    }

    private void UpdateDrawerUserInfo()
    {
        var name = _appState.UserFullName ?? "کاربر";
        DrawerName.Text = name;
        DrawerAvatar.Text = name.Length > 0 ? name[0].ToString() : "ک";
    }

    private async void OnHamburgerClicked(object? sender, EventArgs e)
    {
        if (_drawerOpen)
            await CloseDrawer();
        else
            await OpenDrawer();
    }

    private async void OnOverlayTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
    }

    private async Task OpenDrawer()
    {
        _drawerOpen = true;
        DrawerOverlay.IsVisible = true;
        await SideDrawer.TranslateTo(0, 0, 250, Easing.CubicOut);
    }

    private async Task CloseDrawer()
    {
        _drawerOpen = false;
        await SideDrawer.TranslateTo(280, 0, 250, Easing.CubicIn);
        DrawerOverlay.IsVisible = false;
    }

    // Drawer menu handlers
    private async void OnDrawerHomeTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
    }

    private async void OnDrawerFreelancersTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//freelancers");
    }

    private async void OnDrawerProjectsTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//projects");
    }

    private async void OnDrawerPaymentsTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//payments");
    }

    private async void OnDrawerDivarTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//main/divar");
    }

    private async void OnDrawerSettingsTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//main/settings");
    }

    private async void OnDrawerHelpTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await Shell.Current.GoToAsync("//main/messages");
    }

    // Feature card navigation handlers
    private async void OnGrowthTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//growth");
    }

    private async void OnIdeasTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//ideas");
    }

    private async void OnContentSeoTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//content-seo");
    }

    private async void OnDivarTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//main/divar");
    }

    private async void OnAdChannelsTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//ad-channels");
    }

    private async void OnNetworksTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//networks");
    }

    private async void OnAccountingTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//accounting");
    }

    private async void OnCompetitorsTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//competitors");
    }

    private async void OnSmartBotTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//smart-bot");
    }

    private async void OnPaymentsTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//payments");
    }

    private async void OnProjectsTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//projects");
    }

    private async void OnLogoutTapped(object? sender, TappedEventArgs e)
    {
        await CloseDrawer();
        await _appState.LogoutAsync();
        await Shell.Current.GoToAsync("//main/login");
    }
}
