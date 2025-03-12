using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Models;

internal class Movimentos
{
    [JsonPropertyName("name")]
    public string? Nome { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public void ExibirMovimento()
    {
        System.Console.WriteLine("--------------------");
        System.Console.WriteLine($"Nome: {Nome} \n");
        System.Console.WriteLine($"Url: {Url}");
        System.Console.WriteLine("--------------------");
    }
}