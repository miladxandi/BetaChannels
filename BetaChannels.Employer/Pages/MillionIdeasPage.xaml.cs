namespace BetaChannels.Employer.Pages;

public partial class MillionIdeasPage : ContentPage
{
    public MillionIdeasPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnIdeaDetailsClicked(object? sender, EventArgs e)
    {
        if (sender is not Button { CommandParameter: string title })
            return;

        var createProject = await DisplayAlertAsync(title, "برای اجرای این ایده می‌توانید یک پروژه بسازید و از فریلنسرها پیشنهاد بگیرید.", "ساخت پروژه", "بستن");
        if (createProject)
            await Shell.Current.GoToAsync("//projects");
    }
}
