namespace labs46
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduzca el radio del Circulo");
            double radio = double.Parse(Console.ReadLine());

            double area = Math.Pow(radio, 2) * Math.PI;

            Console.WriteLine($"el area del circulo es: {area}");
        }
    }
}