using System;

class Programa
{
    static void Main()
    {
        // Solicitar al usuario el precio del producto
        double precio = 0;
        bool precioValido = false;

        while (!precioValido)
        {
            Console.Write("Ingrese el precio del producto (debe ser un valor positivo): ");
            if (double.TryParse(Console.ReadLine(), out precio) && precio > 0)
            {
                precioValido = true;
            }
            else
            {
                Console.WriteLine("El precio ingresado no es válido. Debe ser un número positivo.");
            }
        }

        // Solicitar la forma de pago
        Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ");
        string formaDePago = Console.ReadLine().ToLower();

        // Validar la forma de pago
        while (formaDePago != "efectivo" && formaDePago != "tarjeta")
        {
            Console.WriteLine("Forma de pago inválida. Debe ser 'efectivo' o 'tarjeta'.");
            Console.Write("Ingrese la forma de pago (efectivo/tarjeta): ");
            formaDePago = Console.ReadLine().ToLower();
        }

        // Si el método de pago es tarjeta, pedir el número de tarjeta
        if (formaDePago == "tarjeta")
        {
            string numeroTarjeta = "";
            bool tarjetaValida = false;

            while (!tarjetaValida)
            {
                Console.Write("Ingrese el número de la tarjeta (16 dígitos): ");
                numeroTarjeta = Console.ReadLine();

                // Validar que el número de tarjeta tenga exactamente 16 dígitos
                if (numeroTarjeta.Length == 16 && long.TryParse(numeroTarjeta, out _))
                {
                    tarjetaValida = true;
                }
                else
                {
                    Console.WriteLine("El número de tarjeta ingresado no es válido. Debe tener exactamente 16 dígitos.");
                }
            }

            Console.WriteLine($"Pago procesado con tarjeta. Número de tarjeta: {numeroTarjeta}");
        }
        else
        {
            Console.WriteLine("Pago procesado en efectivo.");
        }

        // Mostrar el precio del producto
        Console.WriteLine($"El precio del producto es: {precio:C}");
    }
}