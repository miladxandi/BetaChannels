using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Employer.Pages.Divar;

public partial class DivarAnalyticsPage : ContentPage
{
    private readonly IDivarService _divarService;
    private readonly IAuthService _authService;
    private List<PostSummary> _postList = new();
    private string? _selectedPostToken;

    public DivarAnalyticsPage(IDivarService divarService, IAuthService authService)
    {
        InitializeComponent();
        _divarService = divarService;
        _authService = authService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CheckAuthAndLoad();
    }

    private async Task CheckAuthAndLoad()
    {
        if (!await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync("//main/login");
            return;
        }
        await LoadPosts();
    }

    private async Task LoadPosts()
    {
        ShowLoading();
        try
        {
            var result = await _divarService.GetUserPostsAsync();
            if (result.Success)
            {
                // TODO: Parse posts JSON to PostSummary list
                _postList = new List<PostSummary>();
                PostsView.IsVisible = true;
                PostsList.ItemsSource = _postList;
            }
            else
            {
                ShowError(result.ErrorMessage ?? "خطا در دریافت آگهی‌ها");
            }
        }
        catch (Exception ex)
        {
            ShowError(ex.Message);
        }
    }

    private async void OnPostSelected(object? sender, TappedEventArgs e)
    {
        if (e.Parameter is string token)
        {
            _selectedPostToken = token;
            await LoadStats(token);
        }
    }

    private async Task LoadStats(string token)
    {
        try
        {
            var result = await _divarService.GetPostStatsAsync(token);
            if (result.Success)
            {
                // TODO: Parse stats JSON
                StatsView.IsVisible = true;
            }
        }
        catch
        {
            // Silently fail for now
        }
    }

    private async void OnRefreshClicked(object? sender, EventArgs e)
    {
        await LoadPosts();
        if (_selectedPostToken is not null)
        {
            await LoadStats(_selectedPostToken);
        }
    }

    private void ShowLoading()
    {
        LoadingView.IsVisible = true;
        ErrorView.IsVisible = false;
        EmptyView.IsVisible = false;
        PostsView.IsVisible = false;
    }

    private void ShowError(string message)
    {
        LoadingView.IsVisible = false;
        ErrorView.IsVisible = true;
        EmptyView.IsVisible = false;
        PostsView.IsVisible = false;
        ErrorLabel.Text = message;
    }

    private class PostSummary
    {
        public string Token { get; set; } = "";
        public string Title { get; set; } = "";
        public string? Status { get; set; }
    }
}
