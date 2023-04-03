
using CrossMintChallenge.Core.Models;

namespace CrossMintChallenge.Core.Interfaces;

public interface IMegaverseService
{
    Task CreatePolyanet(Polyanet polyanet);
    
    Task CreateSoloon(Soloon soloon);
    
    Task CreateCometh(Cometh cometh);
    
    Task DeleteOne(Megaverse megaverse);
    
}