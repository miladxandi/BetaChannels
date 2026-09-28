namespace BetaChannels.Employer.Pages;

public partial class ContentSeoPage : ContentPage
{
    private Border[] _chips = null!;
    private View[] _sections = null!;

    public ContentSeoPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _chips = [ChipArticles, ChipWebsite, ChipSeo, ChipReport];
        _sections = [ArticlesSection, WebsiteSection, SeoSection, ReportSection];
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    private void OnChipArticles(object? sender, TappedEventArgs e) => SwitchTab(0);
    private void OnChipWebsite(object? sender, TappedEventArgs e) => SwitchTab(1);
    private void OnChipSeo(object? sender, TappedEventArgs e) => SwitchTab(2);
    private void OnChipReport(object? sender, TappedEventArgs e) => SwitchTab(3);

    private async void OnOrderContentClicked(object? sender, EventArgs e)
    {
        var createProject = await DisplayAlertAsync("سفارش تولید محتوا", "برای شروع، یک پروژه تولید محتوا بسازید تا فریلنسرها پیشنهادشان را ارسال کنند.", "رفتن به پروژه‌ها", "بعداً");
        if (createProject)
            await Shell.Current.GoToAsync("//projects");
    }

    private async void OnStartSeoClicked(object? sender, EventArgs e)
    {
        var createProject = await DisplayAlertAsync("شروع سئو", "برای دریافت پیشنهاد سئو، یک پروژه جدید ثبت کنید.", "رفتن به پروژه‌ها", "بعداً");
        if (createProject)
            await Shell.Current.GoToAsync("//projects");
    }

    private void SwitchTab(int index)
    {
        if (_chips == null) return;

        for (int i = 0; i < _chips.Length; i++)
        {
            if (i == index)
            {
                _chips[i].Style = Application.Current!.Resources["FilterChipActive"] as Style;
                ((Label)_chips[i].Content).TextColor = Colors.White;
                _sections[i].IsVisible = true;
            }
            else
            {
                _chips[i].Style = Application.Current!.Resources["FilterChip"] as Style;
                ((Label)_chips[i].Content).TextColor = Color.FromArgb("#8888aa");
                _sections[i].IsVisible = false;
            }
        }
    }
}
