using Pokemon.Tamagotchi.Controller.RequestResponse;
using Pokemon.Tamagotchi.View;

namespace Pokemon.Tamagotchi.Controller;

internal class Controller
{
    private readonly string endereco = "https://pokeapi.co/api/v2/pokemon";

    public void Jogar()
    {

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

        Menu menu = new MenuPrincipal(nome, request);
        int numero;

        while(menu is not null)
        {
            numero = menu.ExibirMenu();
            menu = menu.RetornaMenu(numero);
        }

        /*request.PokemonRequestRestSharp();
        request.PokemonRequestNomeRestSharp("pikachu");
        await request.PokemonRequestJsonSerializer();
        await request.MascoteRequestJsonSerializer("pikachu");*/
    }
}