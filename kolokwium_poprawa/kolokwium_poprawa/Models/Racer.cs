using System;
using System.Collections.Generic;

namespace kolokwium_poprawa.Models;

public partial class Racer
{
    public int RacerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<RaceParticipation> RaceParticipations { get; set; } = new List<RaceParticipation>();
}
