using System;

class Programa
{
    static void Main()
    {
        Console.Write("Ingrese el primer lado del triángulo: ");
        double lado1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el segundo lado del triángulo: ");
        double lado2 = Convert.ToDouble(Console.ReadLine());

        Console.Write("Ingrese el tercer lado del triángulo: ");
        double lado3 = Convert.ToDouble(Console.ReadLine());

        if ((lado1 + lado2 > lado3) && (lado1 + lado3 > lado2) && (lado2 + lado3 > lado1))
        {
            Console.WriteLine("Los lados ingresados forman un triángulo.");

            if (lado1 == lado2 && lado2 == lado3)
            {
                Console.WriteLine("Es un triángulo equilátero (todos los lados son iguales).");
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                Console.WriteLine("Es un triángulo isósceles (dos lados son iguales).");
            }
            else
            {
                Console.WriteLine("Es un triángulo escaleno (todos los lados son diferentes).");
            }
        }
        else
        {
            Console.WriteLine("Los lados ingresados no forman un triángulo válido.");
        }
    }
}