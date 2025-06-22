using kolokwium_poprawa.DTOs;
using kolokwium_poprawa.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium_poprawa.Controllers;

[ApiController]
[Route("api/racers")]
public class RacerConroller: ControllerBase
{
    private readonly IRacerService  _racerService;

    public RacerConroller(IRacerService racerService)
    {
        _racerService = racerService;
    }

    [HttpGet("/{id}/participations")]
    public async Task<ActionResult<RacerDto>> GetracerDetails(int id)
    {
        var racer = _racerService.getRacerDetails(id).Result;
        return Ok(racer);
    }

    
}

