using Pokemon.Tamagotchi.Models;
using Pokemon.Tamagotchi.RequestResponse;

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
    
    public MenuAdocao(Player player, Request request) : base(player, request)
    {
    }

    public override async Task<int> ExibirMenuAsync()
    {
        EscreveTitulo(titulo);
        Console.WriteLine($"{nomePessoa} escolha seu mascote");

        try
        {
            await ExibirMascotesAsync();
        }
        catch(EntryPointNotFoundException exception)
        {
            Console.WriteLine($"Sistema fora do ar: {exception.Message}");
            Console.ReadKey();
        }

        Console.WriteLine();
        int id = 0;

        do{
            try
            { 
                Console.WriteLine($"Digite o número do mascote");
                id = Convert.ToInt32(Console.ReadLine());
                if(id > 0)
                {
                    return id;
                }
                else
                {
                    Console.WriteLine("Número inválido");
                    Console.ReadKey();
                }

            }
            catch(FormatException exception)
            {
                Console.WriteLine($"Isso não é um número: {exception.Message}");
                Console.ReadKey();
                Console.WriteLine();
            }
            catch (HttpRequestException exception)
            {
                Console.WriteLine($"Pokemon não encontrado: {exception.Message}");
                Console.ReadKey();
                Console.WriteLine();
            }
            catch(EntryPointNotFoundException exception)
            {
                Console.WriteLine($"Sistema fora do ar: {exception.Message}");
                Console.ReadKey();
            }
        }
        while(id < 1);

        return 0;
    }

    public async Task ExibirMascotesAsync() => await request.MascotePokemonRequestJsonSerializerAsync();

    public override Menu RetornaMenu(int numero)
    {
        if(numero == 0)
        {
            return new MenuPrincipal(player, request);
        }
        else
        {
            return new MenuParaSaberMais(player, request, numero);
        }
    } 
}