using BetaChannels.Shared.DTOs;

namespace BetaChannels.Shared.Interfaces;

public interface IServiceService
{
    Task<List<ServiceDto>> GetServicesByFreelancerAsync(Guid freelancerId);
    Task<ServiceDto?> GetServiceByIdAsync(Guid id);
    Task<ServiceDto> CreateServiceAsync(Guid freelancerId, CreateServiceDto dto);
    Task<ServiceDto> UpdateServiceAsync(Guid serviceId, CreateServiceDto dto);
    Task<bool> DeleteServiceAsync(Guid serviceId);
    Task<List<ServiceDto>> GetFeaturedServicesAsync();
}
