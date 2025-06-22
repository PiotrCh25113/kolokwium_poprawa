using System;
using System.Collections.Generic;

namespace kolokwium_poprawa.Models;

public partial class RaceParticipation
{
    public int TrackRaceId { get; set; }

    public int RacerId { get; set; }

    public int FinishTimeInSeconds { get; set; }

    public int Position { get; set; }

    public virtual Racer Racer { get; set; } = null!;

    public virtual TrackRace TrackRace { get; set; } = null!;
}
