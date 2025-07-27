using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ProgrammazioneAsincrona;

internal class Program
{

    static readonly Stopwatch timer = new Stopwatch();
    
    // Corrispettivo async (Asincrono, cioè che va aspettato perché richiede del tempo)
    // Di un metodo void (che non ritorna risultato)
    public async Task FaisQualcosaAsync()
    {

    }

    // Corrispettivao async di un metodo che torna un valore
    public async Task<int> FaiQualcosaTornaUnValoreAsync()
    {
        return 1;
    }

    // ESEMPIO PRATICO

    // Scenario sync blocca il codice

    //static void Main(string[] args)
    //{
    //    timer.Start();
    //    Console.WriteLine($"Inizio programma: {timer.Elapsed.TotalSeconds}");

    //    Task1();
    //    Task2();
    //    Console.WriteLine($"Fine programma: {timer.Elapsed.TotalSeconds}");
    //    timer.Stop();


    //}

    //// Scenario Async/await asincrono che non blocca il codice ma aspetta
    //static async Task Main(string[] args)
    //{
    //    timer.Start();
    //    Console.WriteLine($"Inizio programma: {timer.Elapsed.TotalSeconds}");
    //    await Task1Async();
    //    await Task2Async();
    //    Console.WriteLine($"Fine programma: {timer.Elapsed.TotalSeconds}");
    //    timer.Stop();
    //}

    // Scenario Async/await asincrono che non blocca il codice e non aspetta
    static async Task Main(string[] args)
    {
        timer.Start();
        Console.WriteLine($"Inizio programma: {timer.Elapsed.TotalSeconds}");
        Task t1= Task1Async();
        Task t2 = Task2Async();

        await Task.WhenAll(t1,t2);

        Console.WriteLine($"Fine programma: {timer.Elapsed.TotalSeconds}");
        timer.Stop();
    }

    private static void Task1()
    {
        Console.WriteLine($"Task 1 Avviato: {timer.Elapsed.TotalSeconds}");
        Thread.Sleep(2000);
        Console.WriteLine($"Task 1 Completato: {timer.Elapsed.TotalSeconds}");
    }

    private static void Task2()
    {
        Console.WriteLine($"Task 2 Avviato: {timer.Elapsed.TotalSeconds}");
        Thread.Sleep(3000);
        Console.WriteLine($"Task 2 Completato: {timer.Elapsed.TotalSeconds}");
    }

    private static async Task Task1Async()
    {
        Console.WriteLine($"Async Task 1 Avviato: {timer.Elapsed.TotalSeconds}");
        await Task.Delay(2000);
        Console.WriteLine($"Async Task 1 Completato: {timer.Elapsed.TotalSeconds}");
    }

    private static async Task Task2Async()
    {
        Console.WriteLine($"Async Task 2 Avviato: {timer.Elapsed.TotalSeconds}");
        await Task.Delay(3000);
        Console.WriteLine($"Async Task 2 Completato: {timer.Elapsed.TotalSeconds}");
    }


}
