namespace BetaChannels.Shared.Interfaces;

/// <summary>
/// سرویس اتصال به دیوار — OAuth، آگهی‌ها و آمار
/// </summary>
public interface IDivarService
{
    /// <summary>
    /// دریافت URL احراز هویت OAuth دیوار (برای باز کردن در WebView)
    /// </summary>
    Task<DivarAuthUrlResult> GetAuthUrlAsync();

    /// <summary>
    /// دریافت لیست آگهی‌های کاربر از دیوار
    /// </summary>
    Task<DivarPostsResult> GetUserPostsAsync();

    /// <summary>
    /// دریافت آمار یک آگهی خاص
    /// </summary>
    Task<DivarPostStatsResult> GetPostStatsAsync(string postToken);
}

public class DivarAuthUrlResult
{
    public bool Success { get; set; }
    public string? AuthUrl { get; set; }
    public string? ErrorMessage { get; set; }
}

public class DivarPostsResult
{
    public bool Success { get; set; }
    public object? Posts { get; set; }
    public string? ErrorMessage { get; set; }
}

public class DivarPostStatsResult
{
    public bool Success { get; set; }
    public object? Stats { get; set; }
    public string? ErrorMessage { get; set; }
}
