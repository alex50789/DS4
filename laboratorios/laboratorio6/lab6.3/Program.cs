class Program
{
    private static void Main(string[] args)
    {
        try
        {
            int[] myNumbers = { 1, 2, 3 };
            Console.WriteLine(myNumbers[10]);
        }
        catch (Exception e)
        {
            Console.WriteLine("Algo salio mal, valide el indice del arreglo");
        }

        finally 
        { 
            Console.WriteLine("continuacion de la aplicacion, luego del bloqueo try/catch");
        }
    }

}