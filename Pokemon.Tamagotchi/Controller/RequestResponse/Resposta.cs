using System.Text.Json.Serialization;
using Pokemon.Tamagotchi.Models;

namespace Pokemon.Tamagotchi.Controller.RequestResponse;

internal class Resposta
{
    [JsonPropertyName("results")]
    public virtual ICollection<PokemonClass>? Pokemons { get; set;}

    public void ExibeResultado()
    {
        foreach(var pokemon in Pokemons!)
        {
            System.Console.WriteLine($"Results:");
            pokemon.ExibirPokemons();
        }
    }
}