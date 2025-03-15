namespace Pokemon.Tamagotchi.Models;

internal class EstadoMascote
{
    private int fome;
    private int diversao;
    public int Fome 
    { 
        get
        {
            return fome;
        }
        set
        {
            fome += value;
            
            if(fome < 0)
            {
                fome = 0;
            }

            if(fome > 10)
            {
                fome = 10;
            }
        } 
    }

    public int Diversao { 
        get
        {
            return diversao;
        }
        set
        {
            diversao += value;

            if(diversao < 0)
            {
                diversao = 0;
            }

            if(diversao > 10)
            {
                diversao = 10;
            }
        } 
    }


    public EstadoMascote()
    {
        fome = new Random().Next(0, 11);
        diversao = new Random().Next(0, 11);
    }

}