using Newtonsoft.Json;

namespace CrossMintChallenge.Core.Models;

public class Soloon : Megaverse
{
    [JsonProperty(PropertyName="color")]
    public string Color { get; set; } // MegaverseColor enum.
    public override string GetName() => "soloons";
}