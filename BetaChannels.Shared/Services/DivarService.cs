using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using BetaChannels.Shared.Interfaces;

namespace BetaChannels.Shared.Services;

/// <summary>
/// سرویس واقعی اتصال به دیوار — از طریق بک‌اند ادمتریکس proxy می‌شود.
/// </summary>
public class DivarService : IDivarService
{
    private readonly HttpClient _httpClient;

    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower,
        PropertyNameCaseInsensitive = true,
    };

    public DivarService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DivarAuthUrlResult> GetAuthUrlAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/beta/divar/auth-url");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return new DivarAuthUrlResult { Success = false, ErrorMessage = error };
            }

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            var authUrl = doc.RootElement.GetProperty("authUrl").GetString();

            return new DivarAuthUrlResult { Success = true, AuthUrl = authUrl };
        }
        catch (Exception ex)
        {
            return new DivarAuthUrlResult { Success = false, ErrorMessage = ex.Message };
        }
    }

    public async Task<DivarPostsResult> GetUserPostsAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("/api/beta/divar/posts");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return new DivarPostsResult { Success = false, ErrorMessage = error };
            }

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            var posts = doc.RootElement.GetProperty("posts").Clone();

            return new DivarPostsResult { Success = true, Posts = posts };
        }
        catch (Exception ex)
        {
            return new DivarPostsResult { Success = false, ErrorMessage = ex.Message };
        }
    }

    public async Task<DivarPostStatsResult> GetPostStatsAsync(string postToken)
    {
        try
        {
            var response = await _httpClient.GetAsync($"/api/beta/divar/post-stats/{postToken}");
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadAsStringAsync();
                return new DivarPostStatsResult { Success = false, ErrorMessage = error };
            }

            using var stream = await response.Content.ReadAsStreamAsync();
            using var doc = await JsonDocument.ParseAsync(stream);
            var stats = doc.RootElement.GetProperty("stats").Clone();

            return new DivarPostStatsResult { Success = true, Stats = stats };
        }
        catch (Exception ex)
        {
            return new DivarPostStatsResult { Success = false, ErrorMessage = ex.Message };
        }
    }
}
