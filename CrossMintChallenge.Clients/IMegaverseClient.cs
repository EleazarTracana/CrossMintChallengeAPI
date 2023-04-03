using CrossMintChallenge.Clients.Models;
using Refit;

namespace CrossMintChallenge.Clients;

[Headers("Content-Type: application/json")]
public interface IMegaverseClient
{

    [Post("/api/{megaverseName}")]
    Task Create([Body] string request, [AliasAs("megaverseName")] string megaverseName);
    
    [Delete("/api/{megaverseName}")]
    Task Delete([Body] string request, [AliasAs("megaverseName")] string megaverseName);
    
    [Get("/api/map/{candidateId}/goal")]
    Task<GoalMapResponse> GetGoalMap(string candidateId);
}