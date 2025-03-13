namespace Pokemon.Tamagotchi.Menus;

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
    
    public MenuMascotesAdotados(string nome) : base(nome)
    {

    }

    public override int ExibirMenu()
    {
        return 0;
    }

    public override Menu RetornaMenu(int numero)
    {
        return null;
    }
}