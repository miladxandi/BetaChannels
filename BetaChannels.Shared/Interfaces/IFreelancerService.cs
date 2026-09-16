using BetaChannels.Shared.DTOs;
using BetaChannels.Shared.Models;

namespace BetaChannels.Shared.Interfaces;

public interface IFreelancerService
{
    Task<List<FreelancerProfileDto>> SearchFreelancersAsync(FreelancerSearchDto search);
    Task<FreelancerProfileDto?> GetFreelancerByIdAsync(Guid id);
    Task<FreelancerProfileDto?> GetFreelancerByUserIdAsync(Guid userId);
    Task UpdateProfileAsync(Guid userId, FreelancerProfileUpdateDto dto);
    Task<List<FreelancerProfileDto>> GetFeaturedFreelancersAsync();
}
