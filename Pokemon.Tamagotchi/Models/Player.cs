using Pokemon.Tamagotchi.Controller;

namespace Pokemon.Tamagotchi.Models;

internal class Player
{
    private ControllerMascote controllerMascote;

    public string Nome { get; set; }
    public MascotesAdotados Mascotes { get; set; }
    public ControllerMascote ControllerMascote 
    {
        get
        {
            return controllerMascote;
        }
        set 
        {
            controllerMascote = value;
        }
    }

    public Player(string nome)
    {
        Nome = nome;
        Mascotes = new MascotesAdotados();
        controllerMascote = null;
    }
}