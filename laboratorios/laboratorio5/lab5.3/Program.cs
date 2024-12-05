using System;

internal class ForEachFrutas
{
    private string[] frutas = { "manzana", "platano", "naranja" };

    public void ImprimirFrutas()
    {
        Console.WriteLine("Lista de frutas:");
        foreach (string fruta in frutas)
        {
            Console.WriteLine(fruta);
        }
    }

    static void Main(string[] args)
    {
        ForEachFrutas ejemplo = new ForEachFrutas();
        ejemplo.ImprimirFrutas();
        Console.ReadKey();
    }
}