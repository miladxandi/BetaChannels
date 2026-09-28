namespace BetaChannels.Employer.Pages;

public partial class CompetitorAnalysisPage : ContentPage
{
    public CompetitorAnalysisPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnAddCompetitorTapped(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("افزودن رقیب", "رقیب با موفقیت اضافه شد.", "باشه");
    }

    private async void OnCompetitorSelected(object? sender, TappedEventArgs e)
    {
        // In a real app, this would navigate to a detailed competitor view
        await DisplayAlert("تحلیل رقیب", "جزئیات تحلیل رقیب نمایش داده می‌شود.", "باشه");
    }
}
