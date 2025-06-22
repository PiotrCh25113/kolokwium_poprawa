using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.Repositories;

public interface IRaceRepository
{
    Task<ICollection<Race>> getAllRces();
}