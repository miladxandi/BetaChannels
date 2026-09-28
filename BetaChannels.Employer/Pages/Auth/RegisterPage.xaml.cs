using BetaChannels.Employer.Services;
using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Helpers;

namespace BetaChannels.Employer.Pages.Auth;

public partial class RegisterPage : ContentPage, IDisposable
{
    private readonly AppState _appState;
    private int _resendTimer;
    private CancellationTokenSource? _timerCts;
    private bool _isLoading;

    public RegisterPage(AppState appState)
    {
        InitializeComponent();
        _appState = appState;
    }

    private async void OnSendOtpClicked(object? sender, EventArgs e)
    {
        var phone = PhoneEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(phone))
            return;

        SetLoading(true);
        HideError();

        try
        {
            var result = await _appState.RequestOtpAsync(phone);
            SetLoading(false);

            if (result.Success)
            {
                PhoneStep.IsVisible = false;
                OtpStep.IsVisible = true;
                _resendTimer = result.ResendAfter;

                if (!string.IsNullOrEmpty(result.DevCode))
                {
                    OtpEntry.Text = result.DevCode;
                }

                StartResendTimer();
            }
            else
            {
                ShowError(result.ErrorMessage ?? "خطا در ارسال کد تأیید");
            }
        }
        catch (Exception ex)
        {
            SetLoading(false);
            ShowError($"خطا: {ex.Message}");
        }
    }

    private async void OnVerifyClicked(object? sender, EventArgs e)
    {
        var phone = PhoneEntry.Text?.Trim();
        var code = OtpEntry.Text?.Trim();
        var fullName = FullNameEntry.Text?.Trim();
        if (string.IsNullOrWhiteSpace(phone) || string.IsNullOrWhiteSpace(code))
            return;

        SetLoading(true);
        HideError();

        try
        {
            var result = await _appState.VerifyOtpAsync(phone, code);
            SetLoading(false);

            if (result)
            {
                if (!string.IsNullOrEmpty(fullName))
                {
                    _appState.UserFullName = fullName;
                }

                StopTimer();
                await Shell.Current.GoToAsync("//main/dashboard");
            }
            else
            {
                ShowError("کد تأیید نامعتبر است");
            }
        }
        catch (Exception ex)
        {
            SetLoading(false);
            ShowError($"خطا: {ex.Message}");
        }
    }

    private async void OnResendClicked(object? sender, EventArgs e)
    {
        StopTimer();
        OnSendOtpClicked(sender, e);
    }

    private void OnChangePhoneClicked(object? sender, EventArgs e)
    {
        OtpStep.IsVisible = false;
        PhoneStep.IsVisible = true;
        OtpEntry.Text = "";
        FullNameEntry.Text = "";
        CompanyEntry.Text = "";
        HideError();
        StopTimer();
    }

    private void OnLoginTapped(object? sender, TappedEventArgs e)
    {
        Shell.Current.GoToAsync("../login");
    }

    private void StartResendTimer()
    {
        StopTimer();
        _timerCts = new CancellationTokenSource();
        var token = _timerCts.Token;

        ResendTimerLabel.IsVisible = true;
        ResendButton.IsVisible = false;
        UpdateTimerLabel();

        Task.Run(async () =>
        {
            while (_resendTimer > 0 && !token.IsCancellationRequested)
            {
                await Task.Delay(1000, token);
                _resendTimer--;
                MainThread.BeginInvokeOnMainThread(UpdateTimerLabel);
            }

            if (!token.IsCancellationRequested)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    ResendTimerLabel.IsVisible = false;
                    ResendButton.IsVisible = true;
                });
            }
        }, token);
    }

    private void UpdateTimerLabel()
    {
        ResendTimerLabel.Text = $"ارسال مجدد کد تا {_resendTimer.ToPersianDigits()} ثانیه دیگر";
    }

    private void StopTimer()
    {
        _timerCts?.Cancel();
        _timerCts?.Dispose();
        _timerCts = null;
    }

    private void SetLoading(bool loading)
    {
        _isLoading = loading;
        SendOtpButton.IsEnabled = !loading;
        VerifyButton.IsEnabled = !loading;
        SendOtpButton.Text = loading ? "در حال ارسال کد..." : "ارسال کد تأیید";
        VerifyButton.Text = loading ? "در حال ثبت‌نام..." : "ثبت‌نام و ورود";
    }

    private void ShowError(string message)
    {
        ErrorLabel.Text = message;
        ErrorBox.IsVisible = true;
    }

    private void HideError()
    {
        ErrorBox.IsVisible = false;
    }

    public void Dispose()
    {
        StopTimer();
    }
}
