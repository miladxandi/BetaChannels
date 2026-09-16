using BetaChannels.Shared.Enums;

namespace BetaChannels.Shared.Helpers;

public static class EnumExtensions
{
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
        return $"{price:N0} تومان";
    }
}
