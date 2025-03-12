using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Models;

internal class ClasseHabilidades
{
    [JsonPropertyName("ability")]
    public Habilidades Habilidade { get; set; }
}