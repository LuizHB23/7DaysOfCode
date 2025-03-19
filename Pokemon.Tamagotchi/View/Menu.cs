using Pokemon.Tamagotchi.Services;
using Pokemon.Tamagotchi.Models;

namespace Pokemon.Tamagotchi.View;

internal abstract class Menu
{
    protected readonly Player player;
    protected readonly string nomePessoa;
    protected readonly Request request;

    public Menu(Player player, Request request)
    {
        this.player = player;
        nomePessoa = player.Nome;
        this.request = request;
    }

    public abstract Task<int> ExibirMenuAsync();
    public abstract Menu RetornaMenu(int numero);
    protected void EscreveTitulo(string titulo)
    {
        LimpaConsole();
        MostrarLogo();
        string empty = String.Empty;
        Console.WriteLine(empty.PadLeft(titulo.Count(), '-'));
        Console.WriteLine(titulo);
        Console.WriteLine(empty.PadLeft(titulo.Count(), '-'));
    }

    protected void LimpaConsole()
    {
        Console.Clear();
    }

    public static void MostrarLogo()
    {
        Console.Clear();
        Console.WriteLine(@"
            ▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
            ░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
            ░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀");

        Console.WriteLine();
    }
}