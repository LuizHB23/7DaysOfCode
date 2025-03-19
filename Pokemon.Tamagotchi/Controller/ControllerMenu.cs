using Pokemon.Tamagotchi.Services;
using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.View;

namespace Pokemon.Tamagotchi.Controller;

internal class ControllerMenu
{
    private readonly string endereco = "https://pokeapi.co/api/v2/pokemon";

    public async Task Jogar()
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

        Player player = new Player(nome);
        Menu menu = new MenuPrincipal(player, request);
        int numero;

        while(menu is not null)
        {
            numero = await menu.ExibirMenuAsync();
            menu = menu.RetornaMenu(numero);
        }

        /*          Testes
        request.PokemonRequestRestSharp();
        request.PokemonRequestNomeRestSharp("pikachu");
        await request.PokemonRequestJsonSerializer();
        await request.MascoteRequestJsonSerializer("pikachu");*/
    }
}