using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.RequestResponse;

namespace Pokemon.Tamagotchi.View;

internal class MenuMascote: Menu
{
    private readonly string titulo = "Menu do Mascote";
    private Mascote mascote;
    private readonly string nomeMascote;

    public string Titulo
    {
        get
        {
            return titulo;
        }
    }
    
    public MenuMascote(Player player, Request request, Mascote mascote) : base(player, request)
    {
        this.mascote = mascote;
        nomeMascote = mascote.Nome!;
    }

    public override int ExibirMenu()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha sua interação com o mascote");
        Console.WriteLine(
            $"1 - Saber como {nomeMascote} está\n" +
            $"2 - Alimentar {nomeMascote}\n" +
            $"3 - Brincar com {nomeMascote}\n" +
            "4 - Voltar");

        int numero = Convert.ToInt32(Console.ReadLine());
        return numero;
    }

    public override Menu RetornaMenu(int numero)
    {
        throw new NotImplementedException();
    }
}
