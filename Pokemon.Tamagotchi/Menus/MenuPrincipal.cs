namespace Pokemon.Tamagotchi.Menus;

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

    public MenuPrincipal(string nome) : base(nome) {}

    public override int ExibirMenu()
    {
        LimpaConsole();
        MostrarTitulo();
        Console.WriteLine($"{nomePessoa} escolha o que quer fazer");
        Console.WriteLine(
            "1 - Adotar um mascote\n" +
            "2 - Ver seus mascotes\n" +
            "3 - Sair");
        int numero = 0;

        while(numero < 1 || numero > 3)
        {
            try
            {
                numero = Convert.ToInt32(Console.ReadLine());
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
        switch (numero)
        {
            case 1:
                return new MenuAdocao(nomePessoa);
            
            case 2:
                return new MenuMascotesAdotados(nomePessoa);

            default:
                Console.WriteLine("Até logo :)");
                return null;
        }
    }
}