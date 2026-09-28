using BetaChannels.Employer.Services;
using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Helpers;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Employer.Pages;

public partial class PaymentsPage : ContentPage
{
    private readonly AppState _appState;
    private readonly IPaymentService _paymentService;

    public PaymentsPage(AppState appState, IPaymentService paymentService)
    {
        InitializeComponent();
        _appState = appState;
        _paymentService = paymentService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadPayments();
    }

    private async Task LoadPayments()
    {
        if (!_appState.UserId.HasValue) return;

        var payments = await _paymentService.GetPaymentsByUserAsync(_appState.UserId.Value);
        var total = await _paymentService.GetTotalSpentAsync(_appState.UserId.Value);

        TotalSpentLabel.Text = total.ToPersianDigits();
        PendingLabel.Text = payments.Count(p => p.Status == PaymentStatus.Pending).ToPersianDigits();
        CompletedLabel.Text = payments.Count(p => p.Status == PaymentStatus.Completed).ToPersianDigits();
        TotalCountLabel.Text = payments.Count.ToPersianDigits();

        PaymentList.ItemsSource = payments.Select(p => new PaymentViewModel
        {
            Description = p.Description,
            Amount = p.Amount,
            Status = p.Status,
            CreatedAtText = p.CreatedAt.ToShamsiDate()
        }).ToList();
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//main/dashboard");
    }

    public class PaymentViewModel
    {
        public string Description { get; set; } = "";
        public decimal Amount { get; set; }
        public PaymentStatus Status { get; set; }
        public string CreatedAtText { get; set; } = "";
    }
}
