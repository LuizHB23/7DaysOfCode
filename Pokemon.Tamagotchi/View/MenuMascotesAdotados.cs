using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Controller;

namespace Pokemon.Tamagotchi.View;

internal class MenuMascotesAdotados : Menu
{
    private readonly string titulo = "Menu Visualização dos Mascotes";

    public string Titulo
    {
        get
        {
            return titulo;
        }
    }
    
    public MenuMascotesAdotados(Player player, Request request) : base(player, request)
    {

    }

    public override async Task<int> ExibirMenuAsync()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha seu mascote");
        int numero = 0;
        
        if(!player.Mascotes.VerificaMascotes());
        else
        {
            player.Mascotes.MostrarMascotes();
            int voltar = player.Mascotes.RetornaQuantidadeMascotes() + 1;
            Console.WriteLine($"{voltar} - Voltar");
            do
            {
                try
                {
                    numero = Convert.ToInt32(Console.ReadLine());

                    if(numero < 1 || numero > voltar)
                    {
                        Console.WriteLine("Opção inválida. Tente novamente");
                    }
                }
                catch(FormatException exception)
                {
                    Console.WriteLine($"Isso não é um número: {exception.Message}");
                }
                
            }
            while(numero < 1 || numero > voltar);

            if(player.ControllerMascote is null)
            {
                ControllerMascote controllerMascote = new ControllerMascote(player, request);
                player.ControllerMascote = controllerMascote;
            }

            if(numero != voltar)
            {
                await player.ControllerMascote.Interagir(numero);
            }
        }

        return 0;
    }

    public override Menu RetornaMenu(int numero)
    {
        return new MenuPrincipal(player, request);
    }
}