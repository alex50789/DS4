internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero;

        Console.WriteLine("Ingrese el primer numero: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculoMatematico op = new CalculoMatematico(primerNumero, segundoNumero);

        Console.WriteLine("la respuesta de la operacion es: " + op.Calcular());
    }

    public class CalculoMatematico
    {
        private int n1;
        private int n2;
        private int resp;

        public CalculoMatematico(int N1, int N2)
        {
            n1 = N1;
            n2 = N2;
        }

        public int Calcular()
        {
            resp = (n1+n2)*(n1-n2) ;
            return resp;
        }
    }
}