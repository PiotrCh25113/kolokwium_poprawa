using kolokwium_poprawa.DTOs;

namespace kolokwium_poprawa.Services;

public interface IRacerService
{
    Task<RacerDto> getRacerDetails(int id);
}