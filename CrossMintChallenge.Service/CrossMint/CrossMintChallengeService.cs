using System;
using System.Threading.Tasks;
using CrossMintChallenge.Core.Interfaces;
using CrossMintChallenge.Core.Models;
using CrossMintChallenge.Utilities;
using Microsoft.Extensions.Logging;

namespace CrossMintChallenge.Services.CrossMint;

public class CrossMintChallengeService : ICrossMintChallengeService
{
    private readonly IMegaverseService _megaverseService;
    private readonly ICrossMintCandidateService _crossMintCandidateService;
    private readonly ILogger<CrossMintChallengeService> _logger;

    public CrossMintChallengeService(
        ICrossMintCandidateService crossMintCandidateService,
        IMegaverseService megaverseService,
            ILogger<CrossMintChallengeService> logger)
    {
        _megaverseService = megaverseService;
        _logger = logger;
        _crossMintCandidateService = crossMintCandidateService;
    }

    public async Task RunPhase(Guid candidateId)
    {
        _logger.LogDebug("Running CrossMint Challenge Phase");
        
        // Get Current Goal Map for challenge
        var goalMap = await _crossMintCandidateService.GetGoalMap(candidateId);
        
        // Iterate through Goal Map and Create every Megaverse entity at the Goal Map position.
        await IterateGoalMap(goalMap, async (row, column) =>
        {
            string megaverseName = goalMap[row][column];
            await CreateMegaverseEntityAtPosition(megaverseName, row, column, candidateId);
        });
    }

    private async Task CreateMegaverseEntityAtPosition(string megaverse, int row, int column, Guid candidateId)
    {
        try
        {
            // Validate Megaverse value.
            if (string.IsNullOrEmpty(megaverse))
            {
                throw new ArgumentException("Megaverse cannot be null or empty.");
            }

            // Get Megaverse Entity type.
            string entityType = megaverse.Contains("_") ? megaverse.Split("_")[1] : megaverse;

            switch (entityType)
            {
                case "POLYANET":
                    
                    // Create Polyanet.
                    Polyanet polyanet = new Polyanet() { Row = row, Column = column, CadidateId = candidateId };
                    await _megaverseService.CreatePolyanet(polyanet);
                    break;
                case "SOLOON":
                   
                    // Get Color and validate.
                    string rawColor = megaverse.Split("_")[0].ToLower();
                    MegaverseUtils.ParseAndValidateColor(rawColor);
                    
                    // Create Soloon
                    Soloon soloon = new Soloon() { Row = row, Column = column, Color = rawColor, CadidateId = candidateId };
                    await _megaverseService.CreateSoloon(soloon);
                    break;
                case "COMETH":
                    
                    // Get Direction and validate
                    string rawDirection = megaverse.Split("_")[0].ToLower();
                    MegaverseUtils.ParseAndValidateDirection(rawDirection);
                    
                    // Create Cometh
                    Cometh cometh = new Cometh() { Row = row, Column = column, Direction = rawDirection, CadidateId = candidateId };
                    await _megaverseService.CreateCometh(cometh);
                    break;
            }
        }
        catch (ArgumentException ex)
        {
            _logger.LogError($"Error: {ex.Message}", ex);
        }
        catch (Exception ex)
        {
            _logger.LogError($"An unexpected error occurred: {ex.Message}", ex);
        }
    }
    
    // Helper function for nested for each.
    private async Task IterateGoalMap(string[][] goalMap, Func<int, int, Task> action)
    {
        int rows = goalMap.Length;
        int columns = goalMap[0].Length;

        for (int row = 0; row < rows; row++)
            for (int column = 0; column < columns; column++)
                await action(row, column);
    }
}