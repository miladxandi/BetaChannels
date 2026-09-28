using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Helpers;
using BetaChannels.Shared.Interfaces;
using Microsoft.Maui.Controls.Shapes;

namespace BetaChannels.Employer.Pages;

public partial class FreelancersPage : ContentPage
{
    private readonly IFreelancerService _freelancerService;
    private List<FreelancerProfileDto> _freelancers = new();
    private ServiceCategory? _selectedCategory;
    private FreelancerStatus? _selectedStatus;

    public FreelancersPage(IFreelancerService freelancerService)
    {
        InitializeComponent();
        _freelancerService = freelancerService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        BuildCategoryChips();
        await Search();
    }

    private void BuildCategoryChips()
    {
        CategoryChips.Children.Clear();

        // "All" chip
        var allChip = CreateChip("همه", true);
        allChip.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnCategorySelected(null, allChip)) });
        CategoryChips.Children.Add(allChip);

        foreach (var cat in Enum.GetValues<ServiceCategory>())
        {
            var chip = CreateChip(cat.ToPersianName(), false);
            var capturedCat = cat;
            chip.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnCategorySelected(capturedCat, chip)) });
            CategoryChips.Children.Add(chip);
        }
    }

    private Border CreateChip(string text, bool isActive)
    {
        var border = new Border
        {
            BackgroundColor = isActive ? Color.FromArgb("#FF6B35") : Color.FromArgb("#141420"),
            StrokeShape = new RoundRectangle { CornerRadius = 20 },
            Padding = new Thickness(16, 8),
            Content = new Label
            {
                Text = text,
                FontSize = 13,
                FontFamily = "Vazirmatn",
                TextColor = isActive ? Colors.White : Color.FromArgb("#8888aa")
            }
        };
        return border;
    }

    private void OnCategorySelected(ServiceCategory? category, Border selectedChip)
    {
        _selectedCategory = category;

        // Update chip visuals
        foreach (var child in CategoryChips.Children)
        {
            if (child is Border border && border.Content is Label label)
            {
                var isActive = border == selectedChip;
                border.BackgroundColor = isActive ? Color.FromArgb("#FF6B35") : Color.FromArgb("#141420");
                label.TextColor = isActive ? Colors.White : Color.FromArgb("#8888aa");
            }
        }

        _ = Search();
    }

    private async void OnSearchTextChanged(object? sender, TextChangedEventArgs e)
    {
        await Search();
    }

    private async Task Search()
    {
        var searchDto = new FreelancerSearchDto
        {
            Keyword = string.IsNullOrEmpty(SearchEntry.Text) ? null : SearchEntry.Text,
            Category = _selectedCategory,
            Status = _selectedStatus
        };
        _freelancers = await _freelancerService.SearchFreelancersAsync(searchDto);
        FreelancerList.ItemsSource = _freelancers;
    }

    private async void OnViewProfileClicked(object? sender, EventArgs e)
    {
        Guid? id = (e as TappedEventArgs)?.Parameter as Guid?
                   ?? (sender as Button)?.CommandParameter as Guid?;
        if (id is Guid freelancerId)
        {
            await DisplayAlert("پروفایل", $"پروفایل فریلنسر {freelancerId}", "باشه");
        }
    }

    private async void OnHireClicked(object? sender, EventArgs e)
    {
        if (sender is Button button && button.CommandParameter is Guid id)
        {
            await Shell.Current.GoToAsync($"//projects?freelancer={id}");
        }
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }
}
