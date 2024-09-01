using System;
namespace laboratorio21
{
    public class Program
    {
        private static void Main(string[] args)
        {
            MyClass.Valor = 1;
            Console.WriteLine(MyClass.Valor);
        }
    }
    public class MyClass
    {
        public static int Valor;
    }
    
}