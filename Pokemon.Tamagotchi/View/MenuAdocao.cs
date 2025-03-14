using Pokemon.Tamagotchi.Controller.RequestResponse;

namespace Pokemon.Tamagotchi.View;

internal class MenuAdocao : Menu
{
    private readonly string titulo = "Menu de Adoção";

    public string Titulo
    {
        get
        {
            return titulo;
        }
    }
    
    public MenuAdocao(string nome, Request request) : base(nome, request)
    {
    }

    public override int ExibirMenu()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha seu mascote");
        ExibirMascotesAsync().Wait();
        Console.WriteLine();
        int id = Convert.ToInt32(Console.ReadLine());
        ExibirMenuParaSaberMaisAsync(id).Wait();
        return 0;
    }

    public async Task ExibirMascotesAsync() => await request.MascotePokemonRequestJsonSerializerAsync();

    public override Menu RetornaMenu(int numero) => new MenuPrincipal(nomePessoa, request);

    private async Task ExibirMenuParaSaberMaisAsync(int id)
    {
        EscreveTitulo("Para Saber Mais");
        Console.WriteLine($"{nomePessoa} quer conhecer mais?");
        string pokemonNome = await request.PokemonRequestNomeJsonSerializerAsync(id);

        Console.WriteLine(
            $"1 - Saber Mais {pokemonNome}\n" +
            $"2 - Adotar {pokemonNome}" +
            "\n3 - Voltar");

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

        switch(numero)
        {
            case 1:
                request.MascoteRequestJsonSerializer(pokemonNome).Wait();
                Console.ReadKey();
                await ExibirMenuParaSaberMaisAsync(id);
                break;
            case 2:
                Console.WriteLine("Mascote adotado com sucesso!");
                Console.ReadKey();
                break;
            default:
                break;
        }
    }
}