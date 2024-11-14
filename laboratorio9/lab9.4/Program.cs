using System;

class Aleatorio
{
    private Random random;
    public Aleatorio()
    {
        random = new Random();
    }


    public int GenerarNumero(int min, int max)
    {
        return random.Next(min, max + 1);
    }

    public int[] GenerarArreglo(int min, int max, int cantidad)
    { 
        int[] arreglo = new int[cantidad];

        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarNumero(min, max);
        }

       return arreglo;
    }
    
}

class Program
{
    static void Main()
    {
        Aleatorio aleatorio = new Aleatorio();


        int numero = aleatorio.GenerarNumero(1, 100);
        Console.WriteLine($"Número aleatorio entre 1 y 100: {numero}");


        int[] arregloNumeros = aleatorio.GenerarArreglo(10, 50, 5);
        Console.WriteLine("Arreglo de números aleatorios entre 10 y 50:");
        foreach (int num in arregloNumeros)
        {
            Console.WriteLine(num);
        }
    }
}