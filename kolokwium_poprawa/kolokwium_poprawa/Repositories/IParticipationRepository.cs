using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.Repositories;

public interface IParticipationRepository
{
    Task<ICollection<RaceParticipation>> getAllParticipations();
}