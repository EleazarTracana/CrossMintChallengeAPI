using System;
using System.Threading.Tasks;

namespace CrossMintChallenge.Core.Interfaces;

public interface ICrossMintCandidateService
{
    Task<string[][]> GetGoalMap(Guid candidateId);
}