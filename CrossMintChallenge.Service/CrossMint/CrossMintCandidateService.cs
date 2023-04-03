using System;
using System.Threading.Tasks;
using CrossMintChallenge.Clients;
using CrossMintChallenge.Clients.Models;
using CrossMintChallenge.Core.Interfaces;

namespace CrossMintChallenge.Services.CrossMint;

public class CrossMintCandidateService : ICrossMintCandidateService
{
    private readonly IMegaverseClient _megaverseClient;

    public CrossMintCandidateService(IMegaverseClient megaverseClient)
    {
        _megaverseClient = megaverseClient;
    }
    
    public async Task<string[][]> GetGoalMap(Guid candidateId)
    {
        GoalMapResponse goalMap =  await _megaverseClient.GetGoalMap(candidateId.ToString());
        return goalMap.Goal;
    }
}