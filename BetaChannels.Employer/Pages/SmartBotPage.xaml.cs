namespace BetaChannels.Employer.Pages;

public partial class SmartBotPage : ContentPage
{
    public SmartBotPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    private async void OnAddReplyClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("پاسخ سریع", "فرم افزودن پاسخ سریع به زودی فعال می‌شود.", "باشه");
    }
}
