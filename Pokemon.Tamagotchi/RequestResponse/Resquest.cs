using Pokemon.Tamagotchi.Models;
using System.Text.Json;
using RestSharp;

namespace Pokemon.Tamagotchi.RequestResponse;

internal class Request
{
    private readonly string endereco;

    public Request(string endereco)
    {
        this.endereco = endereco;
    }

    public void PokemonRequestRestSharp()
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

    public void PokemonRequestNomeRestSharp(string nome)
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

    public async Task PokemonRequestJsonSerializer()
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco);
            var deserializer = JsonSerializer.Deserialize<Resposta>(response);

            deserializer!.ExibeResultado();
        }
    }

    public async Task MascoteRequestJsonSerializer(string nome)
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
}