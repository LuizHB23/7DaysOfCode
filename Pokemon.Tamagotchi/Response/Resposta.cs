using System.Text.Json.Serialization;
using Pokemon.Tamagotchi.Models;

namespace Pokemon.Tamagotchi.Response;

internal class Resposta
{
    [JsonPropertyName("count")]
    public int Count { get; set;}

    [JsonPropertyName("next")]
    public string? Next { get; set; }

    [JsonPropertyName("previous")]
    public string? Previous { get; set; }

    [JsonPropertyName("results")]
    public virtual ICollection<Pokemon>? Pokemons { get; set;}

    public void ExibeResultado()
    {
        System.Console.WriteLine($"Count: {Count}");
        System.Console.WriteLine($"Next: {Next}");
        System.Console.WriteLine($"Previous: {Previous}");

        foreach(var pokemon in Pokemons!)
        {
            System.Console.WriteLine($"Results:");
            pokemon.ExibirPokemons();
        }
    }
}