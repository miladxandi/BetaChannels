namespace BetaChannels.Shared.Interfaces;

/// <summary>
/// انتزاع ذخیره‌سازی امن توکن — پیاده‌سازی واقعی در هر پلتفرم MAUI
/// (با Microsoft.Maui.Storage.SecureStorage)
/// </summary>
public interface ITokenStorage
{
    Task<string?> GetAsync(string key);
    Task SetAsync(string key, string value);
    void Remove(string key);
}
