using Pokemon.Tamagotchi.RequestResponse;

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
    
    public MenuMascotesAdotados(string nome, Request request) : base(nome, request)
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