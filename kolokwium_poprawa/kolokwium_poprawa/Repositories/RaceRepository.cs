using kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Repositories;



public class RaceRepository : IRaceRepository
{
    private readonly KolokwiumContext _context;

    public RaceRepository(KolokwiumContext context)
    {
        _context = context;
    }

    public async  Task<ICollection<Race>> getAllRces()
    {
        return await _context.Races.ToListAsync();
    }
}