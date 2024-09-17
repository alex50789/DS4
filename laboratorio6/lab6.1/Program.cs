class Program
{
    private static void Main(string[] args)
    {
        int num; Console.WriteLine("digite el numero deseado: ");

        try
        {
            num = Int16.Parse(Console.ReadLine());

        }
        catch (FormatException ex) { 
            Console.WriteLine("no ha introducido un digito valido");
            num = -1;
        }
        Console.WriteLine(num);
    }
}