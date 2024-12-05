using System;

class ClaseBase
{
    public void test()
    {

    }

    public virtual void MasTest()
    {

    }
}

class ClaseHijo : ClaseBase
{
    public override void MasTest() 
    {

    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Corrio la aplicacion");

        ClaseHijo hijo = new ClaseHijo();
        hijo.MasTest();
    }
}