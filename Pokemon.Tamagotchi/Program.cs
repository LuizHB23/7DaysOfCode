using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.Menus;

string endereco = "https://pokeapi.co/api/v2/pokemon";

Request request = new Request(endereco);

Menu.MostrarLogo();

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

MenuPrincipal menu = new MenuPrincipal(nome, request);
int numero = menu.ExibirMenu();

Menu novoMenu = menu.RetornaMenu(numero);

while(novoMenu is not null)
{
    numero = novoMenu.ExibirMenu();
    novoMenu = novoMenu.RetornaMenu(numero);
}

/*request.PokemonRequestRestSharp();
request.PokemonRequestNomeRestSharp("pikachu");
await request.PokemonRequestJsonSerializer();
await request.MascoteRequestJsonSerializer("pikachu");*/

