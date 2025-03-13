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

    public async Task PokemonRequestJsonSerializerAsync()
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco);
            var deserializer = JsonSerializer.Deserialize<Resposta>(response);

            deserializer!.ExibeResultado();
        }
    }

    public async Task MascotePokemonRequestJsonSerializerAsync()
    {
        using(HttpClient client = new HttpClient())
        {
            
            var response = await client.GetStringAsync(endereco);
            var deserializer = JsonSerializer.Deserialize<Resposta>(response);
            
            foreach(var pokemon in deserializer.Pokemons)
            {
                var responsePokemon = await client.GetStringAsync(endereco + $"/{pokemon.Name}");
                var deserializerPokemon = JsonSerializer.Deserialize<Mascote>(responsePokemon);

                Console.WriteLine($"Id: {deserializerPokemon.Id} - Nome: {deserializerPokemon.Nome}");
            }
        
        }
    }

    public async Task<string> PokemonRequestNomeJsonSerializerAsync(int id)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco + $"/{id}");
            var deserializer = JsonSerializer.Deserialize<Mascote>(response);

            return deserializer.Nome;
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

    /* 
            FAZENDO PEGAR TODOS OS POKEMONS

     public async Task MascotePokemonRequestJsonSerializerAsync()
    {
        using(HttpClient client = new HttpClient())
        {
            for(int i = 0; i <= 1300; i += 20)
            {
                var response = await client.GetStringAsync(endereco + $"?offset={i}&limit=20");
                var deserializer = JsonSerializer.Deserialize<Resposta>(response);
                
                foreach(var pokemon in deserializer.Pokemons)
                {
                    var responsePokemon = await client.GetStringAsync(endereco + $"/{pokemon.Name}");
                    var deserializerPokemon = JsonSerializer.Deserialize<Mascote>(responsePokemon);

                    Console.WriteLine($"Id: {deserializerPokemon.Id} - Nome: {deserializerPokemon.Nome}");
                }
            }
        }
    }*/

}