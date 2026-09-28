using BetaChannels.Employer.Services;

namespace BetaChannels.Employer.Pages;

public partial class SettingsPlaceholderPage : ContentPage
{
    private readonly AppState _appState;

    public SettingsPlaceholderPage(AppState appState)
    {
        InitializeComponent();
        _appState = appState;
        MessagesSwitch.IsToggled = Preferences.Default.Get("employer-notify-messages", true);
        ProjectsSwitch.IsToggled = Preferences.Default.Get("employer-notify-projects", true);
        UpdateUserName();
    }

    private void UpdateUserName()
    {
        var name = _appState.UserFullName ?? "کارفرما";
        NameLabel.Text = name;
        AvatarLabel.Text = name.Length > 0 ? name[..1] : "ک";
    }

    private void OnMessagesToggled(object? sender, ToggledEventArgs e) =>
        Preferences.Default.Set("employer-notify-messages", e.Value);

    private void OnProjectsToggled(object? sender, ToggledEventArgs e) =>
        Preferences.Default.Set("employer-notify-projects", e.Value);

    private async void OnEditNameClicked(object? sender, EventArgs e)
    {
        var name = await DisplayPromptAsync("ویرایش نام", "نام نمایشی خود را وارد کنید:", "ذخیره", "لغو", initialValue: _appState.UserFullName ?? "کارفرما");
        if (!string.IsNullOrWhiteSpace(name))
        {
            _appState.UserFullName = name.Trim();
            UpdateUserName();
        }
    }

    private async void OnHelpClicked(object? sender, EventArgs e)
    {
        await DisplayAlertAsync("راهنمای پنل", "از داشبورد برای مدیریت پروژه‌ها، یافتن فریلنسرها و پیگیری پرداخت‌ها استفاده کنید. برای راهنمایی بیشتر با پشتیبانی در ارتباط باشید.", "متوجه شدم");
    }

    private async void OnSupportClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/messages");
    }

    private async void OnLogoutClicked(object? sender, EventArgs e)
    {
        var confirmed = await DisplayAlertAsync("خروج از حساب", "از حساب کاربری خارج می‌شوید؟", "خروج", "انصراف");
        if (!confirmed)
            return;

        await _appState.LogoutAsync();
        await Shell.Current.GoToAsync("//main/login");
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }
}
