using System.Text.Json.Serialization;

namespace Pokemon.Tamagotchi.Util;

internal class MascoteRequest
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

    public string RetornaNomeMascote() => Nome!;

    public override string ToString()
    {
        return $"Id: {Id} \nNome: {Nome} \nAltura: {Altura} \nPeso: {Peso}";
    }

    public void VerHabilidades()
    {
        foreach(var habilidade in ClasseHabilidades!)
        {
            habilidade.Habilidade.ExibirHabilidade();
        }
    }
}