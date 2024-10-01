using parcial1;
using System;
using System.Drawing;

class Program
{
    static void Main(string[] args)
    {
            int size = 5;
            GeneradorMatrix generator = new GeneradorMatrix(size); 
            generator.GenerarMatrix();
            generator.ImprimirMatrix();

            if (size % 2 == 0) 
            {
            SumaDeBordes sumaDeBordes = new SumaDeBordes();
            int sum = sumaDeBordes.CalculateSum(generator.GetMatrix());
            Console.WriteLine("Sum of borders: " + sum);
            }
    }
}
