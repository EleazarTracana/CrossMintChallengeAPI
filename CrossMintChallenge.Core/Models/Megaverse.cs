using System;
using Newtonsoft.Json;

namespace CrossMintChallenge.Core.Models;

public abstract class Megaverse
{
    [JsonProperty(PropertyName="row")] 
    public int Row { get; set; }
    
    [JsonProperty(PropertyName="column")] 
    public int Column { get; set; }

    [JsonProperty(PropertyName="candidateId")] 
    public Guid CadidateId { get; set; }

    public virtual  string GetName() => String.Empty;
}