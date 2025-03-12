using System.Text.Json;
using RestSharp;
using Pokemon.Tamagotchi.Response;
using Pokemon.Tamagotchi.Models;

string endereco = "https://pokeapi.co/api/v2/pokemon";

PokemonRequestRestSharp();
PokemonRequestNomeRestSharp("pikachu");
await PokemonRequestJsonSerializer();
await MascoteRequestJsonSerializer("pikachu");

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

void PokemonRequestNomeRestSharp(string nome)
{
    var client = new RestClient(endereco + $"/{nome}");
    var request = new RestRequest("", Method.Get);
    var response = client.Execute(request);

    if(response.StatusCode == System.Net.HttpStatusCode.OK)
        Console.WriteLine(response.Content);
    else
        Console.WriteLine(response.ErrorMessage);
    
    Console.ReadKey();
}

async Task PokemonRequestJsonSerializer()
{
    using(HttpClient client = new HttpClient())
    {
        var response = await client.GetStringAsync(endereco);
        var deserializer = JsonSerializer.Deserialize<Resposta>(response);

        deserializer!.ExibeResultado();
    }
}

async Task MascoteRequestJsonSerializer(string nome)
{
    using(HttpClient client = new HttpClient())
    {
        var response = await client.GetStringAsync(endereco + $"/{nome}");
        var deserializer = JsonSerializer.Deserialize<Mascote>(response);

        Console.WriteLine(deserializer);
        deserializer.VerHabilidades();
        deserializer.VerMovimentos();
    }
}