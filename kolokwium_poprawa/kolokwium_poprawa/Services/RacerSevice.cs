using kolokwium_poprawa.DTOs;
using kolokwium_poprawa.Models;
using kolokwium_poprawa.Repositories;

namespace kolokwium_poprawa.Services;

public class RacerSevice  : IRacerService
{
    
    private readonly IRacerRepository _racerRepository;
    private readonly IParticipationRepository _participationRepository;

    public RacerSevice(IRacerRepository racerRepository, IParticipationRepository participationRepository)
    {
        _racerRepository =  racerRepository;
        _participationRepository = participationRepository;
    }

    public async Task<RacerDto> getRacerDetails(int id)
    {

        var racer = _racerRepository.getRacer(id).Result;
        ICollection<Race> allRaces = _participationRepository.getAllParticipations().Result.Select(r => r.TrackRace.Race).ToList();
        ICollection<Race> races = allRaces.Where(r => r.RaceId == id).ToList();
        
        return new RacerDto()
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Races = races
        };
    }
}