using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Models;

namespace Pokemon.Tamagotchi.View;

internal class MenuPrincipal : Menu
{
    private readonly string titulo = "Menu";

    public string Titulo
    {
        get
        {
            return titulo;
        }
    }

    public MenuPrincipal(Player player, Request request) : base(player, request) {}

    public override int ExibirMenu()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha o que quer fazer");
        Console.WriteLine(
            "1 - Adotar um mascote\n" +
            "2 - Ver seus mascotes\n" +
            "3 - Sair");
        int numero = 0;

        do
        {
            try
            {
                numero = Convert.ToInt32(Console.ReadLine());

                if(numero == 2 && !player.Mascotes.VerificaMascotes())
                {
                    numero = 0;
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Isso não é um número: " + ex.Message);
            }

        }while(numero < 1 || numero > 3);
        

        return numero;
    }

    public override Menu RetornaMenu(int numero)
    {
        switch (numero)
        {
            case 1:
                return new MenuAdocao(player, request);
            
            case 2:
                return new MenuMascotesAdotados(player, request);

            default:
                Console.WriteLine("Até logo :)");
                return null;
        }
    }
}