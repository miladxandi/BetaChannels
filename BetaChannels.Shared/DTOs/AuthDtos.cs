using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.DTOs;

public class LoginDto
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class RegisterDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; }
}

/// <summary>
/// درخواست ارسال کد OTP به شماره موبایل
/// </summary>
public class PhoneOtpRequestDto
{
    public string Phone { get; set; } = string.Empty;
}

/// <summary>
/// تأیید کد OTP و دریافت توکن
/// </summary>
public class PhoneOtpVerifyDto
{
    public string Phone { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
}

/// <summary>
/// پاسخ درخواست OTP
/// </summary>
public class OtpRequestResultDto
{
    public bool Success { get; set; }
    public int TtlMinutes { get; set; }
    public int ResendAfter { get; set; }
    public string? DevCode { get; set; } // فقط در محیط توسعه
    public string? ErrorMessage { get; set; }
}

public class AuthResultDto
{
    public bool Success { get; set; }
    public string? Token { get; set; }
    public string? ErrorMessage { get; set; }
    public Guid? UserId { get; set; }
    public string? Name { get; set; }
    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Role { get; set; }
}
