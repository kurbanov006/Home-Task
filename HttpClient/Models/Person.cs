
using System.Text.Json.Serialization;

public class Person
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("firstname")]
    public string FirstName { get; set; } = null!;

    [JsonPropertyName("lastname")]
    public string LastName { get; set; } = null!;

    [JsonPropertyName("age")]
    public int Age { get; set; }
}