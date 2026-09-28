namespace BetaChannels.Employer.Pages;

public partial class BetaNetworksPage : ContentPage
{
    public BetaNetworksPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    private async void OnAddServiceTapped(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("افزودن خدمات", "فرم افزودن خدمات یا محصولات به زودی فعال می‌شود.", "باشه");
    }
}
