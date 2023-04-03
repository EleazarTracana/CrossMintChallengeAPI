using CrossMintChallenge.Core.Enumeration;
using Newtonsoft.Json;

namespace CrossMintChallenge.Core.Models;

public class Cometh : Megaverse
{
    [JsonProperty(PropertyName="direction")] 
    public string Direction { get; set; }  // MegaverseDirection enum.
    public override string GetName() => "comeths";
}