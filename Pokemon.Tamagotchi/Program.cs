using System.Text.Json;
using System.Text.Json.Serialization;
using RestSharp;

string endereco = "https://pokeapi.co/api/v2/pokemon";

PokemonRequestRestSharp();
await PokemonRequestJsonSerializer();

async Task PokemonRequestJsonSerializer()
{
    using(HttpClient client = new HttpClient())
    {
        var response = await client.GetStringAsync(endereco);
        var deserializer = JsonSerializer.Deserialize<Resposta>(response);

        deserializer!.ExibeResultado();
    }
}

void PokemonRequestRestSharp()
{
    var client = new RestClient(endereco);
    var request = new RestRequest("", Method.Get);
    var response = client.Execute(request);

    if(response.StatusCode == System.Net.HttpStatusCode.OK)
        Console.WriteLine(response.Content);
    else
        Console.WriteLine(response.ErrorMessage);
    
    Console.ReadKey();
}

public class Resposta
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
public class Pokemon
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    public void ExibirPokemons()
    {
        System.Console.WriteLine($"Name: {Name}");
        System.Console.WriteLine($"Url: {Url}");
    }

}