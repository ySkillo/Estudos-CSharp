using System;


namespace PraticaAsyncAwait;

public class Program
{
    public static async Task Main(string[] args)
    {
        //async → diz que o método pode rodar código assíncrono
        //await → diz: “espere essa tarefa terminar, mas sem travar o programa”


        //Exemplo simples de uso do async/await com Task.Delay
        Console.WriteLine("Início");

        await Task.Delay(3000); // espera 3 segundos sem travar

        Console.WriteLine("Fim");

    }
}