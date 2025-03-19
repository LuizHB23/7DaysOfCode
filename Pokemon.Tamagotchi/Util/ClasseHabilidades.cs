using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Util;

internal class ClasseHabilidades
{
    [JsonPropertyName("ability")]
    public Habilidades Habilidade { get; set; }
}