using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Models;

internal class ClasseMovimentos
{
    [JsonPropertyName("move")]
    public Movimentos Movimento { get; set; }
}