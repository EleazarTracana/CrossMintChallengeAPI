using CrossMintChallenge.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrossMintChallengeAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CrossMintChallengeController : ControllerBase
{
    private readonly ILogger<CrossMintChallengeController> _logger;
    private readonly ICrossMintChallengeService _crossMintChallengeService;

    public CrossMintChallengeController(
        ILogger<CrossMintChallengeController> logger,
        ICrossMintChallengeService crossMintChallengeService)
    {
        _logger = logger;
        _crossMintChallengeService = crossMintChallengeService;
    }
        
    [HttpPost]
    [Route("run-phase/{candidateId}")]
    public async Task RunPhase(Guid candidateId)
    {
        _logger.LogDebug("Request to RunPhase, candidateId: {}", candidateId.ToString());
        await _crossMintChallengeService.RunPhase(candidateId);
    }
    
}