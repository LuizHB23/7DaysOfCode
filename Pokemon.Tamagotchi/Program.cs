using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.Menus;

string endereco = "https://pokeapi.co/api/v2/pokemon";

Request request = new Request(endereco);

Menu.MostrarTitulo();

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

MenuPrincipal menu = new MenuPrincipal(nome);
int numero = menu.ExibirMenu();

Menu novoMenu = menu.RetornaMenu(numero);

while(novoMenu is not null)
{
    novoMenu.ExibirMenu();
    novoMenu = novoMenu.RetornaMenu(numero);
}

/*request.PokemonRequestRestSharp();
request.PokemonRequestNomeRestSharp("pikachu");
await request.PokemonRequestJsonSerializer();
await request.MascoteRequestJsonSerializer("pikachu");*/

