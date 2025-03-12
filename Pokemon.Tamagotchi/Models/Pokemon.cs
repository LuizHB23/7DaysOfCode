using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Response;
internal class Pokemon
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public void ExibirPokemons()
    {
        System.Console.WriteLine($"Name: {Name}");
        System.Console.WriteLine($"Url: {Url}");
    }

}