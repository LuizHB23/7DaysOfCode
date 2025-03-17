using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.RequestResponse;

namespace Pokemon.Tamagotchi.View;

internal class MenuParaSaberMais : Menu
{
    private readonly string titulo = "Menu de Adoção";
    private readonly int id;

    public string Titulo
    {
        get
        {
            return titulo;
        }
    }
    
    public MenuParaSaberMais(Player player, Request request, int id) : base(player, request)
    {
        this.id = id;
    }

    public override async Task<int> ExibirMenuAsync()
    {
        string pokemonNome;
        try
        {
            pokemonNome = await request.PokemonRequestNomeJsonSerializerAsync(id);
            int numero = 0;
            EscreveTitulo("Para Saber Mais");
            Console.WriteLine($"{nomePessoa} quer conhecer mais?");
            Console.WriteLine(
            $"1 - Saber Mais {pokemonNome}\n" +
            $"2 - Adotar {pokemonNome}" +
            "\n3 - Voltar");

            while(numero < 1 || numero > 3)
            {
                try
                {
                    numero = Convert.ToInt32(Console.ReadLine());

                    if(numero < 1 || numero > 3)
                    {
                        Console.WriteLine("Opção inválida! Tente novamento");
                    }
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Isso não é um número: " + ex.Message);
                    Console.ReadKey();
                }
            }

            switch(numero)
            {
                case 1:
                    await request.MascoteRequestJsonSerializerAsync(pokemonNome);
                    Console.ReadKey();
                    await ExibirMenuAsync();
                    break;
                case 2:
                    if(player.Mascotes.RetornaMascoteListaPorNome(pokemonNome) is null)
                    {
                        Mascote mascote = await request.MascoteRequestAsync(pokemonNome);
                        player.Mascotes.AdicionarMascote(mascote);
                        Console.WriteLine("Mascote adotado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Mascote não disponível para adoção");
                    }
                    Console.ReadKey();
                    break;
                default:
                    break;
            }
            return 0;
        }
        catch(EntryPointNotFoundException exception)
        {
            Console.WriteLine($"Sistema fora do ar: {exception.Message}");
            return 0;
        }
        
    }

        public override Menu RetornaMenu(int numero) => new MenuPrincipal(player, request);
}