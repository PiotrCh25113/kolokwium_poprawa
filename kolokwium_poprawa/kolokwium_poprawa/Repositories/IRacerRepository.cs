using kolokwium_poprawa.Models;

namespace kolokwium_poprawa.Repositories;

public interface IRacerRepository
{
    Task<Racer> getRacer(int id);
    
}