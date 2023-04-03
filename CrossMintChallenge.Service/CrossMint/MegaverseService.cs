using System.Threading.Tasks;
using CrossMintChallenge.Clients;
using CrossMintChallenge.Core.Interfaces;
using CrossMintChallenge.Core.Models;
using Newtonsoft.Json;

namespace CrossMintChallenge.Services.CrossMint;

public class MegaverseService : IMegaverseService
{
    private readonly IMegaverseClient _megaverseClient;
    private const int DELAY_MILLISECONDS = 1000;

    public MegaverseService(IMegaverseClient megaverseClient)
    {
        _megaverseClient = megaverseClient;
    }

    public async Task CreatePolyanet(Polyanet polyanet)
    {
        var request = JsonConvert.SerializeObject(polyanet);
        await _megaverseClient.Create(request, polyanet.GetName())
            .ConfigureAwait(false);

        // An error 429 was encountered while using the API, indicating that there may be a limit on the number of calls per minute. The issue was resolved by implementing a delay.
        await Task.Delay(DELAY_MILLISECONDS)
            .ConfigureAwait(false);
    }
    
    public async Task CreateSoloon(Soloon soloon)
    {
        var request = JsonConvert.SerializeObject(soloon);
        await _megaverseClient.Create(request, soloon.GetName())
            .ConfigureAwait(false);
        
        await Task.Delay(DELAY_MILLISECONDS)
            .ConfigureAwait(false);
    }
    
    public async Task CreateCometh(Cometh cometh)
    {
        var request = JsonConvert.SerializeObject(cometh);
        await _megaverseClient.Create(request, cometh.GetName())
            .ConfigureAwait(false);

        await Task.Delay(DELAY_MILLISECONDS)
            .ConfigureAwait(false);
    }
    
    public async Task DeleteOne(Megaverse megaverse)
    {
        var request = JsonConvert.SerializeObject(megaverse);
        await _megaverseClient.Delete(request, megaverse.GetName())
            .ConfigureAwait(false);
        
        await Task.Delay(DELAY_MILLISECONDS)
            .ConfigureAwait(false);
    }
}