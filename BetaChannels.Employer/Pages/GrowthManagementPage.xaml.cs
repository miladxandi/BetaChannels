namespace BetaChannels.Employer.Pages;

public partial class GrowthManagementPage : ContentPage
{
    private bool _isEmployerTab = true;

    public GrowthManagementPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnEmployerTabTapped(object? sender, TappedEventArgs e)
    {
        _isEmployerTab = true;
        EmployerTab.BackgroundColor = Color.FromArgb("#FF6B35");
        FreelancerTab.BackgroundColor = Colors.Transparent;
        ((Label)EmployerTab.Content).TextColor = Colors.White;
        ((Label)FreelancerTab.Content).TextColor = Color.FromArgb("#8888aa");
        EmployerSection.IsVisible = true;
        FreelancerSection.IsVisible = false;
    }

    private void OnFreelancerTabTapped(object? sender, TappedEventArgs e)
    {
        _isEmployerTab = false;
        FreelancerTab.BackgroundColor = Color.FromArgb("#FF6B35");
        EmployerTab.BackgroundColor = Colors.Transparent;
        ((Label)FreelancerTab.Content).TextColor = Colors.White;
        ((Label)EmployerTab.Content).TextColor = Color.FromArgb("#8888aa");
        FreelancerSection.IsVisible = true;
        EmployerSection.IsVisible = false;
    }

    private async void OnScenarioRequested(object? sender, EventArgs e)
    {
        await DisplayAlert("سناریوی رشد", "سناریوی رشد پیج شما در حال آماده‌سازی است. نتایج به زودی ارسال خواهد شد.", "باشه");
    }
}
