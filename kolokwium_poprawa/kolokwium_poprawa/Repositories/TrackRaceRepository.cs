using kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Repositories;


public class TrackRaceRepository : ITrackRaceRepository
{
    private readonly KolokwiumContext _context;

    public TrackRaceRepository(KolokwiumContext context)
    {
        _context = context;
    }

    public async  Task<ICollection<TrackRace>> getAllTrackRaces()
    {
        return await _context.TrackRaces.ToListAsync();
    }
}