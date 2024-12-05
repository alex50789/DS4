namespace Labs47
{
    class Program
    {
        static void Main(string[] args)
        {
            int numero1 = 70;
            double numero2 = 67.89, numero3 = 67.89;
            Console.WriteLine(Suma(numero1, numero3));
            Console.WriteLine(Suma(numero1, numero2, numero3));

        }
        static double Suma(int x, double y, double z = 0)
        {
            return x + y + z;

        }
    }
}