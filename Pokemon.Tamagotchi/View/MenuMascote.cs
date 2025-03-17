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

    public override async Task<int> ExibirMenuAsync()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha sua interação com o mascote");
        Console.WriteLine(
            $"1 - Saber como {nomeMascote} está\n" +
            $"2 - Alimentar {nomeMascote}\n" +
            $"3 - Brincar com {nomeMascote}\n" +
            "4 - Voltar");

        int numero = 0;

        while(numero < 1 || numero > 4)
        {
            try
            {
                numero = Convert.ToInt32(Console.ReadLine());

                if(numero < 1 || numero > 4)
                {
                    Console.WriteLine("Opção inválida! Tente novamento");
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Isso não é um número: " + ex.Message);
            }
        }

        return numero;
    }

    public override Menu RetornaMenu(int numero)
    {
        throw new NotImplementedException();
    }
}
