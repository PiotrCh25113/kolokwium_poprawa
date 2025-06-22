using kolokwium_poprawa.DTOs;
using kolokwium_poprawa.Models;
using kolokwium_poprawa.Repositories;

namespace kolokwium_poprawa.Services;

public class RacerSevice  : IRacerService
{
    
    private readonly IRacerRepository _racerRepository;
    private readonly IParticipationRepository _participationRepository;
    private readonly ITrackRaceRepository _trackRaceRepository;
    private readonly IRaceRepository _raceRepository;

    public RacerSevice(IRacerRepository racerRepository, IParticipationRepository participationRepository,  ITrackRaceRepository trackRaceRepository, IRaceRepository raceRepository)
    {
        _racerRepository =  racerRepository;
        _participationRepository = participationRepository;
        _trackRaceRepository = trackRaceRepository;
        _raceRepository = raceRepository;
    }

    public async Task<RacerDto> getRacerDetails(int id)
    {
        ICollection<int> TrackRaceIds = _participationRepository.getAllParticipations().Result.Where(e => e.RacerId == id).Select(e => e.TrackRaceId).ToList();
        List<int> RaceIds = _trackRaceRepository.getAllTrackRaces().Result.Where(e => TrackRaceIds.Contains(e.TrackRaceId)).Select(e => e.RaceId).ToList();
        List<Race> races = _raceRepository.getAllRces().Result.Where(e => RaceIds.Contains(e.RaceId)).ToList();
        
        var racer = _racerRepository.getRacer(id).Result;
        
        
        //ICollection<Race> races = null;
        return new RacerDto()
        {
            RacerId = racer.RacerId,
            FirstName = racer.FirstName,
            LastName = racer.LastName,
            Races = races
        };
    }
}