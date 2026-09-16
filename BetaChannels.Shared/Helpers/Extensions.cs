using System.Globalization;
using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Helpers;

public static class EnumExtensions
{
    private static readonly PersianCalendar _persianCalendar = new();

    private static readonly string[] PersianMonthNames =
    {
        "فروردین", "اردیبهشت", "خرداد",
        "تیر", "مرداد", "شهریور",
        "مهر", "آبان", "آذر",
        "دی", "بهمن", "اسفند"
    };

    public static string ToShamsiDate(this DateTime date)
    {
        var year = _persianCalendar.GetYear(date);
        var month = _persianCalendar.GetMonth(date);
        var day = _persianCalendar.GetDayOfMonth(date);
        return $"{year}/{month:D2}/{day:D2}".ToPersianDigits();
    }

    public static string ToShamsiDateLong(this DateTime date)
    {
        var year = _persianCalendar.GetYear(date);
        var month = _persianCalendar.GetMonth(date);
        var day = _persianCalendar.GetDayOfMonth(date);
        return $"{day.ToPersianDigits()} {PersianMonthNames[month - 1]} {year.ToPersianDigits()}";
    }

    public static int GetShamsiYear(this DateTime date) => _persianCalendar.GetYear(date);

    public static int GetShamsiMonth(this DateTime date) => _persianCalendar.GetMonth(date);

    public static int GetShamsiDay(this DateTime date) => _persianCalendar.GetDayOfMonth(date);

    public static string GetShamsiMonthName(this DateTime date)
    {
        var month = _persianCalendar.GetMonth(date);
        return PersianMonthNames[month - 1];
    }

    public static string ToPersianDigits(this string input)
    {
        return input
            .Replace("0", "۰").Replace("1", "۱").Replace("2", "۲")
            .Replace("3", "۳").Replace("4", "۴").Replace("5", "۵")
            .Replace("6", "۶").Replace("7", "۷").Replace("8", "۸")
            .Replace("9", "۹");
    }

    public static string ToPersianDigits(this int number) => number.ToString().ToPersianDigits();

    public static string ToPersianDigits(this long number) => number.ToString().ToPersianDigits();

    public static string ToPersianDigits(this double number) => number.ToString().ToPersianDigits();

    public static string ToPersianDigits(this decimal number) => number.ToString("#,##0.##").ToPersianDigits();

    public static string ToPersianName(this ServiceCategory category) => category switch
    {
        ServiceCategory.Videography => "فیلم‌برداری",
        ServiceCategory.VideoEditing => "تدوین",
        ServiceCategory.InstagramAdmin => "ادمین اینستاگرام",
        ServiceCategory.TelegramAdmin => "ادمین تلگرام",
        ServiceCategory.BaleAdmin => "ادمین بله",
        ServiceCategory.EitaaAdmin => "ادمین ایتا",
        ServiceCategory.RubikaAdmin => "ادمین روبیکا",
        ServiceCategory.YouTubeAdmin => "ادمین یوتیوب",
        ServiceCategory.AparatAdmin => "ادمین آپارات",
        ServiceCategory.ContentCreation => "تولید محتوا",
        ServiceCategory.ScenarioWriting => "سناریونویسی",
        ServiceCategory.SEO => "سئو",
        ServiceCategory.WebDesign => "طراحی سایت",
        ServiceCategory.DigitalMarketing => "دیجیتال مارکتینگ",
        _ => category.ToString()
    };

    public static string ToPersianName(this SocialPlatform platform) => platform switch
    {
        SocialPlatform.Instagram => "اینستاگرام",
        SocialPlatform.Telegram => "تلگرام",
        SocialPlatform.Bale => "بله",
        SocialPlatform.Eitaa => "ایتا",
        SocialPlatform.Rubika => "روبیکا",
        SocialPlatform.YouTube => "یوتیوب",
        SocialPlatform.Aparat => "آپارات",
        SocialPlatform.GoogleAds => "گوگل ادز",
        _ => platform.ToString()
    };

    public static string ToPersianName(this SubscriptionType type) => type switch
    {
        SubscriptionType.Free => "رایگان",
        SubscriptionType.Basic => "پایه",
        SubscriptionType.Premium => "حرفه‌ای",
        SubscriptionType.VIP => "ویژه",
        _ => type.ToString()
    };

    public static string ToPersianName(this PaymentStatus status) => status switch
    {
        PaymentStatus.Pending => "در انتظار",
        PaymentStatus.Completed => "تکمیل شده",
        PaymentStatus.Failed => "ناموفق",
        PaymentStatus.Refunded => "بازگشت داده شده",
        _ => status.ToString()
    };

    public static string ToPersianName(this ContentStatus status) => status switch
    {
        ContentStatus.Draft => "پیش‌نویس",
        ContentStatus.Scheduled => "زمان‌بندی شده",
        ContentStatus.Published => "منتشر شده",
        ContentStatus.Cancelled => "لغو شده",
        _ => status.ToString()
    };

    public static string ToPersianName(this FreelancerStatus status) => status switch
    {
        FreelancerStatus.Available => "آماده به کار",
        FreelancerStatus.Busy => "مشغول",
        FreelancerStatus.Offline => "آفلاین",
        _ => status.ToString()
    };

    public static string FormatPrice(this decimal price)
    {
        return $"{price:N0} تومان".ToPersianDigits();
    }
}
