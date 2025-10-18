namespace labcalcgit.Models;

public class VesselOption
{
    public required string Name { get; set; }
    /// <summary>
    /// Vessel capacity in milliliters
    /// </summary>
    public required double Capacity { get; set; }
}
