using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Enums;
using BetaChannels.Shared.Interfaces;
using BetaChannels.Shared.Models;

namespace BetaChannels.Shared.Services;

public class MockFreelancerService : IFreelancerService
{
    private readonly List<Freelancer> _freelancers = new()
    {
        new Freelancer
        {
            FullName = "علی محمدی",
            Bio = "فیلم‌بردار و تدوین‌گر حرفه‌ای با ۵ سال تجربه",
            Skills = new() { ServiceCategory.Videography, ServiceCategory.VideoEditing },
            Rating = 4.8,
            TotalReviews = 42,
            HourlyRate = 500_000,
            Status = FreelancerStatus.Available,
            CompletedProjects = 87,
            SocialMediaLinks = new() { "https://instagram.com/ali_video" }
        },
        new Freelancer
        {
            FullName = "سارا احمدی",
            Bio = "متخصص مدیریت شبکه‌های اجتماعی و تولید محتوا",
            Skills = new() { ServiceCategory.InstagramAdmin, ServiceCategory.ContentCreation },
            Rating = 4.9,
            TotalReviews = 63,
            HourlyRate = 350_000,
            Status = FreelancerStatus.Available,
            CompletedProjects = 120,
            SocialMediaLinks = new() { "https://instagram.com/sara_content" }
        },
        new Freelancer
        {
            FullName = "رضا کریمی",
            Bio = "متخصص یوتیوب و آپارات - ساخت ویدیو و سئو",
            Skills = new() { ServiceCategory.YouTubeAdmin, ServiceCategory.AparatAdmin, ServiceCategory.SEO },
            Rating = 4.6,
            TotalReviews = 28,
            HourlyRate = 400_000,
            Status = FreelancerStatus.Busy,
            CompletedProjects = 54,
            SocialMediaLinks = new() { "https://youtube.com/reza_channel" }
        },
        new Freelancer
        {
            FullName = "مریم حسینی",
            Bio = "طراح سایت و متخصص سئو با تجربه در پروژه‌های بزرگ",
            Skills = new() { ServiceCategory.WebDesign, ServiceCategory.SEO },
            Rating = 4.7,
            TotalReviews = 35,
            HourlyRate = 600_000,
            Status = FreelancerStatus.Available,
            CompletedProjects = 45,
            SocialMediaLinks = new() { }
        }
    };

    public Task<List<FreelancerProfileDto>> SearchFreelancersAsync(FreelancerSearchDto search)
    {
        var query = _freelancers.AsEnumerable();

        if (!string.IsNullOrEmpty(search.Keyword))
            query = query.Where(f => f.FullName.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase)
                || f.Bio.Contains(search.Keyword, StringComparison.OrdinalIgnoreCase));

        if (search.Category.HasValue)
            query = query.Where(f => f.Skills.Contains(search.Category.Value));

        if (search.MinRate.HasValue)
            query = query.Where(f => f.HourlyRate >= search.MinRate.Value);

        if (search.MaxRate.HasValue)
            query = query.Where(f => f.HourlyRate <= search.MaxRate.Value);

        if (search.MinRating.HasValue)
            query = query.Where(f => f.Rating >= search.MinRating.Value);

        if (search.Status.HasValue)
            query = query.Where(f => f.Status == search.Status.Value);

        var result = query.Select(f => MapToDto(f)).ToList();
        return Task.FromResult(result);
    }

    public Task<FreelancerProfileDto?> GetFreelancerByIdAsync(Guid id)
    {
        var f = _freelancers.FirstOrDefault();
        return Task.FromResult(f != null ? MapToDto(f) : null);
    }

    public Task<FreelancerProfileDto?> GetFreelancerByUserIdAsync(Guid userId)
    {
        var f = _freelancers.FirstOrDefault();
        return Task.FromResult(f != null ? MapToDto(f) : null);
    }

    public Task UpdateProfileAsync(Guid userId, FreelancerProfileUpdateDto dto)
    {
        return Task.CompletedTask;
    }

    public Task<List<FreelancerProfileDto>> GetFeaturedFreelancersAsync()
    {
        var result = _freelancers
            .OrderByDescending(f => f.Rating)
            .Take(3)
            .Select(f => MapToDto(f))
            .ToList();
        return Task.FromResult(result);
    }

    private static FreelancerProfileDto MapToDto(Freelancer f) => new()
    {
        Id = f.Id,
        FullName = f.FullName,
        Bio = f.Bio,
        Skills = f.Skills,
        Rating = f.Rating,
        TotalReviews = f.TotalReviews,
        HourlyRate = f.HourlyRate,
        Status = f.Status,
        CompletedProjects = f.CompletedProjects,
        AvatarUrl = f.AvatarUrl
    };
}
