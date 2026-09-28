namespace BetaChannels.Employer.Pages;

public partial class MessagesPlaceholderPage : ContentPage
{
    public MessagesPlaceholderPage()
    {
        InitializeComponent();
    }

    private async void OnSendClicked(object? sender, EventArgs e)
    {
        var message = MessageEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(message))
            return;

        var bubble = new Border
        {
            BackgroundColor = Color.FromArgb("#5548C9A0"),
            Stroke = Color.FromArgb("#8848C9A0"),
            StrokeShape = new Microsoft.Maui.Controls.Shapes.RoundRectangle { CornerRadius = 18 },
            Padding = new Thickness(14),
            HorizontalOptions = LayoutOptions.End,
            MaximumWidthRequest = 320,
            Content = new VerticalStackLayout
            {
                Spacing = 5,
                Children =
                {
                    new Label { Text = message, FontFamily = "Vazirmatn", FontSize = 14, TextColor = Color.FromArgb("#FFF4DD") },
                    new Label { Text = $"شما · {DateTime.Now:HH:mm}", FontFamily = "Vazirmatn", FontSize = 10, TextColor = Color.FromArgb("#C2A783"), HorizontalOptions = LayoutOptions.End }
                }
            }
        };

        MessageStack.Children.Add(bubble);
        MessageEntry.Text = string.Empty;
        await ChatScroll.ScrollToAsync(bubble, ScrollToPosition.End, true);
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }
}
