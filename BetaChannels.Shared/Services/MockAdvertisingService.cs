using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Models;

namespace BetaChannels.Shared.Services;

public class MockAdvertisingService : IAdvertisingService
{
    private readonly List<AdvertisingChannel> _channels = new()
    {
        new() { Name = "پیج تکنولوژی", Platform = SocialPlatform.Instagram, ChannelUrl = "https://instagram.com/tech_page", Description = "پیج معرفی محصولات تکنولوژی", Followers = 150_000, AdvertisingPrice = 3_000_000, Industry = "تکنولوژی", EngagementRate = 4.2 },
        new() { Name = "کانال آموزش برنامه‌نویسی", Platform = SocialPlatform.Telegram, ChannelUrl = "https://t.me/coding_channel", Description = "آموزش برنامه‌نویسی به فارسی", Followers = 85_000, AdvertisingPrice = 1_500_000, Industry = "آموزش", EngagementRate = 6.1 },
        new() { Name = "کانال بله کسب‌وکار", Platform = SocialPlatform.Bale, ChannelUrl = "https://ble.ir/business", Description = "اخبار کسب‌وکار و استارتاپ", Followers = 45_000, AdvertisingPrice = 800_000, Industry = "کسب‌وکار", EngagementRate = 3.8 },
        new() { Name = "کانال ایتا آشپزی", Platform = SocialPlatform.Eitaa, ChannelUrl = "https://eitaa.com/cooking", Description = "دستور پخت غذاهای ایرانی", Followers = 62_000, AdvertisingPrice = 500_000, Industry = "غذا", EngagementRate = 5.5 },
        new() { Name = "کانال روبیکا سرگرمی", Platform = SocialPlatform.Rubika, ChannelUrl = "https://rubika.ir/fun", Description = "محتوای سرگرمی و طنز", Followers = 200_000, AdvertisingPrice = 2_000_000, Industry = "سرگرمی", EngagementRate = 7.3 },
        new() { Name = "کانال یوتیوب گیم", Platform = SocialPlatform.YouTube, ChannelUrl = "https://youtube.com/gaming_fa", Description = "گیم‌پلی و بررسی بازی‌ها", Followers = 320_000, AdvertisingPrice = 5_000_000, Industry = "گیم", EngagementRate = 8.1 },
        new() { Name = "کانال آپارات آموزشی", Platform = SocialPlatform.Aparat, ChannelUrl = "https://aparat.com/edu_channel", Description = "ویدیوهای آموزشی متنوع", Followers = 180_000, AdvertisingPrice = 2_500_000, Industry = "آموزش", EngagementRate = 4.9 }
    };

    public Task<List<AdvertisingChannel>> GetChannelsByIndustryAsync(string? industry)
    {
        if (string.IsNullOrEmpty(industry))
            return Task.FromResult(_channels);
        return Task.FromResult(_channels.Where(c => c.Industry == industry).ToList());
    }

    public Task<List<AdvertisingChannel>> GetChannelsByPlatformAsync(SocialPlatform platform)
        => Task.FromResult(_channels.Where(c => c.Platform == platform).ToList());

    public Task<AdvertisingChannel?> GetChannelByIdAsync(Guid id)
        => Task.FromResult(_channels.FirstOrDefault(c => c.Id == id));
}
