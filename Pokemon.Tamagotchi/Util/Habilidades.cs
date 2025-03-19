using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Util;

internal class Habilidades
{
    [JsonPropertyName("name")]
    public string? Nome { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public void ExibirHabilidade()
    {
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine($"Nome: {Nome}");
        System.Console.WriteLine("--------------------\n");
    }
}