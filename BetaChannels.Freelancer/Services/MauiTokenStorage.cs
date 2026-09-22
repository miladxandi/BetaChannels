using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Freelancer.Services;

/// <summary>
/// پیاده‌سازی ITokenStorage با استفاده از MAUI SecureStorage
/// </summary>
public class MauiTokenStorage : ITokenStorage
{
    public async Task<string?> GetAsync(string key)
    {
        return await SecureStorage.GetAsync(key);
    }

    public async Task SetAsync(string key, string value)
    {
        await SecureStorage.SetAsync(key, value);
    }

    public void Remove(string key)
    {
        SecureStorage.Default.Remove(key);
    }
}
