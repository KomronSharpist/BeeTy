using System.Text.Json.Serialization;

namespace BeeTy.Domain.Entities;

public class Company
{
    [JsonPropertyName("department")]
    public string Department { get; set; }


    [JsonPropertyName("name")]
    public string Name { get; set; }


    [JsonPropertyName("title")]
    public string Title { get; set; }
}
