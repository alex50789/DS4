internal class Program
{
    private static void Main(string[] args)
    {
        int largo, ancho;

        Console.WriteLine("Ingrese el largo del rectangulo: ");
        largo = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el ancho del rectangulo: ");
        ancho = Convert.ToInt32(Console.ReadLine());

        CalcularPerimetro cp = new CalcularPerimetro(largo, ancho);

        Console.WriteLine("la respuesta de la operacion es: " + cp.Calcular());
    }

    public class CalcularPerimetro
    {
        private int l;
        private int a;
        private int r;

        public CalcularPerimetro(int L, int A)
        {
            l = L;
            a = A;
        }

        public int Calcular()
        {
            r = 2*(l+a);
            return r;
        }

    }
}