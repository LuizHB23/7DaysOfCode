namespace Pokemon.Tamagotchi.Menus;

internal abstract class Menu
{
    protected readonly string nomePessoa;

    public Menu(string nome)
    {
        nomePessoa = nome;
    }

    public abstract int ExibirMenu();
    public abstract Menu RetornaMenu(int numero);
    protected void EscreveTitulo(string titulo)
    {
        string empty = String.Empty;
        Console.WriteLine(empty.PadLeft(titulo.Count()));
        Console.WriteLine(titulo);
        Console.WriteLine(empty.PadLeft(titulo.Count()));
    }

    protected void LimpaConsole()
    {
        Console.Clear();
    }

    public static void MostrarTitulo()
    {
        Console.Clear();
        Console.WriteLine(@"
            ▀▀█▀▀ █▀▀█ █▀▄▀█ █▀▀█ █▀▀▀ █▀▀█ ▀▀█▀▀ █▀▀ █░░█ ░▀░ 
            ░▒█░░ █▄▄█ █░▀░█ █▄▄█ █░▀█ █░░█ ░░█░░ █░░ █▀▀█ ▀█▀ 
            ░▒█░░ ▀░░▀ ▀░░░▀ ▀░░▀ ▀▀▀▀ ▀▀▀▀ ░░▀░░ ▀▀▀ ▀░░▀ ▀▀▀");
    }
}