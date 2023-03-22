using BeeTy.Domain.Commons;
using System.Text.Json.Serialization;

namespace BeeTy.Domain.Entities;

public class User : Auditable
{
    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }


    [JsonPropertyName("lastName")]
    public string LastName { get; set; }


    [JsonPropertyName("age")]
    public int Age { get; set; }


    [JsonPropertyName("email")]
    public string Email { get; set; }


    [JsonPropertyName("phone")]
    public string Phone { get; set; }


    [JsonPropertyName("username")]
    public string UserName { get; set; }


    [JsonPropertyName("password")]
    public string Password { get; set; }
    public List<Plan> Plans { get; set; }
    public List<Order> Orders { get; set; }
}
