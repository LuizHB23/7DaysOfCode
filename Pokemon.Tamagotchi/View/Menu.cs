using Pokemon.Tamagotchi.Controller.RequestResponse;

namespace Pokemon.Tamagotchi.View;

internal abstract class Menu
{
    protected readonly string nomePessoa;
    protected readonly Request request;

    public Menu(string nome, Request request)
    {
        nomePessoa = nome;
        this.request = request;
    }

    public abstract int ExibirMenu();
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