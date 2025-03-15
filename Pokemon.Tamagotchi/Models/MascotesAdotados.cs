namespace Pokemon.Tamagotchi.Models;

internal class MascotesAdotados
{
    private List<Mascote> listaMascotes = new List<Mascote>();

    public int RetornaQuantidadeMascotes() => listaMascotes.Count();
    public Mascote RetornaMascoteListaPorNumero(int numero) => listaMascotes[numero];
    public Mascote RetornaMascoteListaPorNome(string nome) => listaMascotes.Find(mascote => mascote.Nome!.Equals(nome));

    public void AdicionarMascote(Mascote mascote)
    {
        listaMascotes.Add(mascote);
    }

    public void MostrarMascotes()
    {
        if(VerificaMascotes())
        {
            for(int i = 0; i < listaMascotes.Count(); i++)
            {
                string nome = listaMascotes[i].RetornaNomeMascote();
                Console.WriteLine($"{i+1} - {nome}");
            }
        }
        else
        {
            Console.WriteLine("Você não possui mascotes :(");
            Console.ReadKey();
        }
        
    }

    public bool VerificaMascotes()
    {
        if(listaMascotes.Count != 0)
        {
            return true;
        }

        Console.WriteLine("Você não possui mascotes :(");
        return false;
    }
}