using Pokemon.Tamagotchi.Util;

namespace Pokemon.Tamagotchi.Models;

internal class Mascote
{
    public string? Nome { get; }
    public int Altura { get; }
    public int Peso { get; set; }
    public List<ClasseHabilidades>? ClasseHabilidades { get; set; }
    public EstadoMascote EstadoMascote { get; set; }

    public Mascote(string nome, int altura, int peso, List<ClasseHabilidades> classeHabilidades)
    {
        Nome = nome;
        Altura = altura;
        Peso = peso;
        ClasseHabilidades = classeHabilidades;
        EstadoMascote = new EstadoMascote();
    }

    public string RetornaNomeMascote() => Nome!;

    public override string ToString()
    {
        return $"Nome: {Nome} \nAltura: {Altura} \nPeso: {Peso}";
    }

    public void VerHabilidades()
    {
        foreach(var habilidade in ClasseHabilidades!)
        {
            habilidade.Habilidade.ExibirHabilidade();
        }
    }
}