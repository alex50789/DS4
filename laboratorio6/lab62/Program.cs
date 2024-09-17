class Program
{
    private static void Main(string[] args)
    {
        int num;
        Console.WriteLine("digite el numero deseado");

        try
        {
            num = Int16.Parse(Console.ReadLine());

        }
        catch (FormatException ex)
        {
            Console.WriteLine("no se ha introduvido un numero valido");
            num = -1;

        }
        catch (OverflowException ex) { 
            Console.WriteLine("El numero introducido es muy grande");
            num = -1;

        }

        Console.WriteLine(num);
    }
}