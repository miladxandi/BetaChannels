namespace BetaChannels.Employer.Pages;

public partial class AdChannelsPage : ContentPage
{
    public AdChannelsPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnChannelSelected(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("کانال انتخاب شد", "کانال تبلیغاتی با موفقیت انتخاب شد. برای نهایی‌سازی تبلیغ ادامه دهید.", "باشه");
    }

    private async void OnStartAdClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("شروع تبلیغ", "لطفاً ابتدا یک کانال تبلیغاتی انتخاب کنید.", "باشه");
    }
}
