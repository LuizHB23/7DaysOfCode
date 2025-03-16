using Pokemon.Tamagotchi.RequestResponse;
using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.View;

namespace Pokemon.Tamagotchi.Controller;

internal class ControllerMascote
{
    private readonly Request request;
    private readonly Player player;

    public ControllerMascote(Player player, Request request)
    {
        this.player = player;
        this.request = request;
    }

    public void Interagir(int numero)
    {
        Mascote mascote = player.Mascotes.RetornaMascoteListaPorNumero(numero - 1);
        MenuMascote menu = new MenuMascote(player, request, mascote);
        int interacao;
        do
        {
            interacao = menu.ExibirMenu();
            switch (interacao)
            {
                case 1:
                    ExibirStatus(mascote);
                    break;
                case 2:
                    Alimentar(mascote);
                    break;
                case 3:
                    Brincar(mascote);
                    break;
                case 4:
                    mascote.EstadoMascote.Diversao = -2;
                    mascote.EstadoMascote.Fome = -1;
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    Console.ReadKey();
                    break;
            }
        }
        while(interacao != 4);
    }

    private void ExibirStatus(Mascote mascote)
    {
        Console.WriteLine(mascote);
        Console.WriteLine("Habilidades:");
        mascote.VerHabilidades();

        if(mascote.EstadoMascote.Fome >= 5)
        {
            Console.WriteLine($"{mascote.Nome} está satisfeito");
        }
        else
        {
            Console.WriteLine($"{mascote.Nome} está com fome");
        }

        if(mascote.EstadoMascote.Diversao >= 5)
        {
            Console.WriteLine($"{mascote.Nome} está feliz");
        }
        else
        {
            Console.WriteLine($"{mascote.Nome} está triste");
        }

        Console.ReadKey();
    }

    private void Alimentar(Mascote mascote)
    {
        Console.WriteLine($"{mascote.Nome} alimentado :)");
        mascote.EstadoMascote.Fome += 2;
        Console.ReadKey();
    }

    private void Brincar(Mascote mascote)
    {
        Console.WriteLine($"{mascote.Nome} está mais feliz, mas está sentindo um pouco mais de fome");
        mascote.EstadoMascote.Diversao = 3;
        mascote.EstadoMascote.Fome = -3;
        Console.ReadKey();
    }
}