using System;
using System.Collections.Generic;

namespace kolokwium_poprawa.Models;

public partial class Race
{
    public int RaceId { get; set; }

    public string Name { get; set; } = null!;

    public string Location { get; set; } = null!;

    public DateTime Date { get; set; }

    public virtual ICollection<TrackRace> TrackRaces { get; set; } = new List<TrackRace>();
}
