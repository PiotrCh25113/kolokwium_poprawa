using kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Repositories;

public class RacerRepository : IRacerRepository
{
    private readonly KolokwiumContext _context;

    public RacerRepository(KolokwiumContext context)
    {
        _context = context;
    }

    public async Task<Racer> getRacer(int id)
    {
        return await _context.Racers.FirstOrDefaultAsync(r=>r.RacerId == id);
    }
}