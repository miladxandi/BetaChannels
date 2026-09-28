using BetaChannels.Employer.Services;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Helpers;
using BetaChannels.Shared.Models;

namespace BetaChannels.Employer.Pages;

public partial class ProjectsPage : ContentPage
{
    private readonly AppState _appState;
    private List<ProjectViewModel> _projects = new();

    public ProjectsPage(AppState appState)
    {
        InitializeComponent();
        _appState = appState;

        // Populate category picker
        foreach (var cat in Enum.GetValues<ServiceCategory>())
        {
            CategoryPicker.Items.Add(cat.ToPersianName());
        }
        CategoryPicker.SelectedIndex = 0;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadProjects();
    }

    private void LoadProjects()
    {
        _projects = new List<ProjectViewModel>
        {
            new() { Title = "فیلم‌برداری مراسم عروسی", Description = "فیلم‌برداری حرفه‌ای مراسم عروسی با دو دوربین و تجهیزات کامل", Category = ServiceCategory.Videography, Budget = 15_000_000, IsOpen = true, Deadline = DateTime.UtcNow.AddDays(20) },
            new() { Title = "مدیریت پیج اینستاگرام", Description = "مدیریت کامل پیج اینستاگرام شامل تولید محتوا، استوری و رشد فالوور", Category = ServiceCategory.InstagramAdmin, Budget = 8_000_000, IsOpen = true, Deadline = DateTime.UtcNow.AddDays(30) },
            new() { Title = "طراحی سایت فروشگاهی", Description = "طراحی و راه‌اندازی سایت فروشگاهی با ووکامرس و درگاه پرداخت", Category = ServiceCategory.WebDesign, Budget = 25_000_000, IsOpen = false, Deadline = DateTime.UtcNow.AddDays(-5) }
        };
        ProjectList.ItemsSource = _projects;
    }

    private void OnAddClicked(object? sender, EventArgs e)
    {
        CreateModal.IsVisible = true;
    }

    private void OnCloseModalClicked(object? sender, EventArgs e)
    {
        CreateModal.IsVisible = false;
    }

    private void OnCreateClicked(object? sender, EventArgs e)
    {
        var title = TitleEntry.Text?.Trim();
        var desc = DescEditor.Text?.Trim();
        if (string.IsNullOrEmpty(title))
            return;

        decimal.TryParse(BudgetEntry.Text, out var budget);
        int.TryParse(DeadlineEntry.Text, out var days);
        if (days <= 0) days = 30;

        var selectedCatIndex = CategoryPicker.SelectedIndex;
        var categories = Enum.GetValues<ServiceCategory>().ToList();
        var category = selectedCatIndex >= 0 && selectedCatIndex < categories.Count ? categories[selectedCatIndex] : ServiceCategory.Videography;

        _projects.Insert(0, new ProjectViewModel
        {
            Title = title,
            Description = desc ?? "",
            Category = category,
            Budget = budget,
            IsOpen = true,
            Deadline = DateTime.UtcNow.AddDays(days)
        });

        ProjectList.ItemsSource = null;
        ProjectList.ItemsSource = _projects;

        // Reset form
        TitleEntry.Text = "";
        DescEditor.Text = "";
        BudgetEntry.Text = "";
        DeadlineEntry.Text = "30";
        CategoryPicker.SelectedIndex = 0;
        CreateModal.IsVisible = false;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    public class ProjectViewModel
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public ServiceCategory Category { get; set; }
        public decimal Budget { get; set; }
        public bool IsOpen { get; set; }
        public DateTime? Deadline { get; set; }

        public string DeadlineText
        {
            get
            {
                if (!Deadline.HasValue) return "";
                var remaining = (Deadline.Value - DateTime.UtcNow).Days;
                return $"{remaining.ToPersianDigits()} روز باقیمانده";
            }
        }
    }
}
