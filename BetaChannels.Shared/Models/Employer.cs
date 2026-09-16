namespace BetaChannels.Shared.Models;

public class Employer : User
{
    public string? CompanyName { get; set; }
    public string? CompanyDescription { get; set; }
    public List<Project> ActiveProjects { get; set; } = new();
    public List<Project> CompletedProjects { get; set; } = new();
}
