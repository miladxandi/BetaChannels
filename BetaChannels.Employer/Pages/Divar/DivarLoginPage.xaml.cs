using BetaChannels.Employer.Services;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Employer.Pages.Divar;

public partial class DivarLoginPage : ContentPage
{
    private readonly IAuthService _authService;
    private readonly IDivarService _divarService;
    private readonly AppState _appState;
    private bool _isConnected;
    private bool _isConnecting;

    public DivarLoginPage(IAuthService authService, IDivarService divarService, AppState appState)
    {
        InitializeComponent();
        _authService = authService;
        _divarService = divarService;
        _appState = appState;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CheckAuthAndConnection();
    }

    private async Task CheckAuthAndConnection()
    {
        if (!await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync("//main/login");
            return;
        }

        // TODO: Check Divar connection status from server
        _isConnected = false;
        LoadingView.IsVisible = false;
        NotConnectedView.IsVisible = !_isConnected;
        ConnectedView.IsVisible = _isConnected;
    }

    private async void OnConnectClicked(object? sender, EventArgs e)
    {
        _isConnecting = true;
        ConnectButton.IsEnabled = false;
        ConnectButton.Text = "در حال اتصال...";
        ErrorBox.IsVisible = false;

        try
        {
            var result = await _divarService.GetAuthUrlAsync();
            if (result.Success && !string.IsNullOrEmpty(result.AuthUrl))
            {
                await Launcher.OpenAsync(result.AuthUrl);
            }
            else
            {
                ErrorLabel.Text = result.ErrorMessage ?? "دریافت لینک اتصال ناموفق بود";
                ErrorBox.IsVisible = true;
            }
        }
        catch (Exception ex)
        {
            ErrorLabel.Text = $"خطا: {ex.Message}";
            ErrorBox.IsVisible = true;
        }
        finally
        {
            _isConnecting = false;
            ConnectButton.IsEnabled = true;
            ConnectButton.Text = "اتصال حساب دیوار";
        }
    }

    private void OnGoToAnalyticsClicked(object? sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//main/divar");
    }

    private void OnReconnectClicked(object? sender, EventArgs e)
    {
        _isConnected = false;
        OnConnectClicked(sender, e);
    }
}
