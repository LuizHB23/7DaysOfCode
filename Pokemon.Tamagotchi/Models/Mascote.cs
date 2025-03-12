using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Models;

internal class Mascote
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Nome { get; set; }

    [JsonPropertyName("height")]
    public int Altura { get; set; }

    [JsonPropertyName("weight")]
    public int Peso { get; set; }

    [JsonPropertyName("abilities")]
    public List<ClasseHabilidades>? ClasseHabilidades { get; set; }

    [JsonPropertyName("moves")]
    public List<ClasseMovimentos>? ClasseMovimentos { get; set; }

    public override string ToString()
    {
        return $"Id: {Id} \nNome: {Nome} \nAltura: {Altura} \nPeso: {Peso}";
    }

    public void VerHabilidades()
    {
        foreach(var habilidade in ClasseHabilidades)
        {
            habilidade.Habilidade.ExibirHabilidade();
        }
    }

    public void VerMovimentos()
    {
        foreach(var movimento in ClasseMovimentos)
        {
            movimento.Movimento.ExibirMovimento();
        }
    }
}