namespace BetaChannels.Employer.Pages;

public partial class PublishPage : ContentPage
{
    public PublishPage()
    {
        InitializeComponent();
    }

    private async void OnBackTapped(object? sender, TappedEventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnUploadImageTapped(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("آپلود تصویر", "انتخاب تصویر از گالری به زودی فعال می‌شود.", "باشه");
    }

    private async void OnUploadVideoTapped(object? sender, TappedEventArgs e)
    {
        await DisplayAlert("آپلود ویدیو", "انتخاب ویدیو از گالری به زودی فعال می‌شود.", "باشه");
    }

    private async void OnPublishClicked(object? sender, EventArgs e)
    {
        await DisplayAlert("انتشار", "پست شما با موفقیت در شبکه‌های انتخاب شده منتشر شد!", "باشه");
    }
}
