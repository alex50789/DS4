internal class Program
{
    private static void Main(string[] args)
    {
        int radio;

        Console.WriteLine("Ingrese el radio del circulo: ");
        radio = Convert.ToInt32(Console.ReadLine());

        CalcularArea ca = new CalcularArea(radio);

        Console.WriteLine("la respuesta de la operacion es: " + ca.Calcular());
    }

    public class CalcularArea
    {
        private int r;
        private double a;

        public CalcularArea(int R)
        {
            this.r = R;
        }

        public double Calcular()
        {
            double pi = 3.14;
            a = pi + (r * r);
            return a;
        }
    }
}