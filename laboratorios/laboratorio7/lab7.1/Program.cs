using lab7._1;

internal class Program
{
    private static void Main(string[] args)
    {
        Banco banco1 = new Banco();
        banco1.Operar();
        banco1.DepositosTotales();
        Console.ReadKey();
    }
}