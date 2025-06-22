using kolokwium_poprawa.Models;
using Microsoft.EntityFrameworkCore;

namespace kolokwium_poprawa.Repositories;

public class ParticipationRepository : IParticipationRepository
{
    private readonly KolokwiumContext _context;

    public ParticipationRepository(KolokwiumContext context)
    {
        _context = context;
    }

    public async Task<ICollection<RaceParticipation>> getAllParticipations()
    {
        return await _context.RaceParticipations.ToListAsync();
    }
}