using Pokemon.Tamagotchi.Util;
using Pokemon.Tamagotchi.Models;
using System.Text.Json;
using RestSharp;
using AutoMapper;

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
            Resposta deserializer;

            if(response is not null)
            {
                deserializer = JsonSerializer.Deserialize<Resposta>(response)!;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
                

            deserializer!.ExibeResultado();
        }
    }

    public async Task MascotePokemonRequestJsonSerializerAsync()
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco);
            Resposta deserializer;

           if(response is not null)
            {
                deserializer = JsonSerializer.Deserialize<Resposta>(response)!;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
            
            foreach(var pokemon in deserializer.Pokemons!)
            {
                var responsePokemon = await client.GetStringAsync(endereco + $"/{pokemon.Name}");
                var deserializerPokemon = JsonSerializer.Deserialize<MascoteRequest>(responsePokemon);

                Console.WriteLine($"Id: {deserializerPokemon!.Id} - Nome: {deserializerPokemon.Nome}");
            }
        }
    }

    public async Task<string> PokemonRequestNomeJsonSerializerAsync(int id)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco + $"/{id}");
            MascoteRequest deserializer;

           if(response is not null)
            {
                deserializer = JsonSerializer.Deserialize<MascoteRequest>(response)!;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }

            return deserializer!.Nome!;
        }
    }

    public async Task MascoteRequestJsonSerializerAsync(string nome)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco + $"/{nome}");
            MascoteRequest deserializer;

           if(response is not null)
            {
                deserializer = JsonSerializer.Deserialize<MascoteRequest>(response)!;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }

            Console.WriteLine(deserializer);
            Console.WriteLine("Habilidades:\n");
            deserializer!.VerHabilidades();
        }
    }

    public async Task<Mascote> MascoteRequestAsync(string nome)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco + $"/{nome}");
            MascoteRequest deserializer;

           if(response is not null)
            {
                deserializer = JsonSerializer.Deserialize<MascoteRequest>(response)!;
            }
            else
            {
                throw new EntryPointNotFoundException();
            }
            
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MascoteRequest, Mascote>());
            var mapping = config.CreateMapper();
            Mascote mascote = mapping.Map<Mascote>(deserializer);

            return mascote;
        }
    }

    /*          Chama todos os Pokemos de forma desorganizada

    public async Task MemeMascotePokemonRequestJsonSerializerAsync(int indice)
    {
        using(HttpClient client = new HttpClient())
        {
            var response = await client.GetStringAsync(endereco + $"?offset={indice}&limit=20");
            var deserializer = JsonSerializer.Deserialize<Resposta>(response);

             if(indice < 1300)
            {
                indice += 20;
                Task task = MemeMascotePokemonRequestJsonSerializerAsync(indice);
            }
            
            foreach(var pokemon in deserializer.Pokemons)
            {
                var responsePokemon = await client.GetStringAsync(endereco + $"/{pokemon.Name}");
                var deserializerPokemon = JsonSerializer.Deserialize<Mascote>(responsePokemon);
                Console.WriteLine($"Id: {deserializerPokemon.Id} - Nome: {deserializerPokemon.Nome}");
            }
        }
    }*/

}