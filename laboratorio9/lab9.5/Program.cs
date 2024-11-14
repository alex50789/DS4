using System;
using System.Collections.Generic;

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


    public int[] GenerarArregloSinRepetidos(int min, int max, int cantidad)
    {
        if (cantidad > (max - min + 1))
        {
            throw new ArgumentException("La cantidad solicitada es mayor que el rango disponible.");
        }

        HashSet<int> numerosGenerados = new HashSet<int>();


        while (numerosGenerados.Count < cantidad)
        {
            int numeroAleatorio = GenerarNumero(min, max);
            numerosGenerados.Add(numeroAleatorio);
        }

        return new List<int>(numerosGenerados).ToArray();
    }
}

class Programa
{
    static void Main()
    {
        Aleatorio aleatorio = new Aleatorio();


        int[] arregloNumerosSinRepetir = aleatorio.GenerarArregloSinRepetidos(10, 50, 40);

        Console.WriteLine("Arreglo de números aleatorios SIN REPETIR entre 10 y 50:");
        foreach (int num in arregloNumerosSinRepetir)
        {
            Console.WriteLine(num);
        }
    }
}