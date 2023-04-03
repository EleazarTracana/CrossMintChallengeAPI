using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CrossMintChallenge.Clients.Models;

public class MegaverseRequest
{
    [JsonProperty(PropertyName="row")] 
    public int Row { get; set; }
    
    [JsonProperty(PropertyName="column")] 
    public int Column { get; set; }
    
    [JsonProperty(PropertyName="candidateId")] 
    public string CandidateId { get; set; }

    public MegaverseRequest(int row, int column, Guid candidateId)
    {
        this.Row = row;
        this.Column = column;
        this.CandidateId = candidateId.ToString();
    }

    public MegaverseRequest()
    {
        
    }
}