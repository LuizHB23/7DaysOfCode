using Pokemon.Tamagotchi.Util;
using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Services;

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