using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.Repositories;

public interface ITrackRaceRepository
{
    Task<ICollection<TrackRace>> getAllTrackRaces();
}