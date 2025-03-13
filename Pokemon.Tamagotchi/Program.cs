using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Models;

string endereco = "https://pokeapi.co/api/v2/pokemon";

Request request = new Request(endereco);

Console.WriteLine(@"
▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀");

Console.WriteLine("\nQual o seu nome?");
string nome = "";
while(nome.Equals(""))
{
    nome = Console.ReadLine()!;
    
    if(nome.Equals(""))
    {
        Console.WriteLine("\nO nome não poder ser vazio");
    }
}
/*request.PokemonRequestRestSharp();
request.PokemonRequestNomeRestSharp("pikachu");
await request.PokemonRequestJsonSerializer();
await request.MascoteRequestJsonSerializer("pikachu");*/

