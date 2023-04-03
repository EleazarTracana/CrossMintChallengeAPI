using System;
using System.Threading.Tasks;

namespace CrossMintChallenge.Core.Interfaces;

public interface ICrossMintChallengeService
{

    Task RunPhase(Guid candidateId);
}