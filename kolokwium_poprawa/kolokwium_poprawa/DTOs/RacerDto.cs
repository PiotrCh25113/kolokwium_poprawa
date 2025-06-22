using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.DTOs;

public class RacerDto
{
    public int RacerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
    public ICollection<Race>  Races { get; set; } = new List<Race>();
}