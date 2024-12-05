using System;

internal class PaisesYCapitales
{
    private Dictionary<string, string> paisesYCapitales;

    public PaisesYCapitales()
    {
        paisesYCapitales = new Dictionary<string, string>
        {
            {"Francia", "Paris"},
            {"España", "Madrid"},
            {"Italia", "Roma"}
        };
    }

    public void MostrarCapitales()
    {
        Console.WriteLine("Países y sus capitales:");
        foreach (KeyValuePair<string, string> par in paisesYCapitales)
        {
            Console.WriteLine($"La capital de {par.Key} es {par.Value}.");
        }
    }

    public void AgregarPais(string pais, string capital)
    {
        if (!paisesYCapitales.ContainsKey(pais))
        {
            paisesYCapitales.Add(pais, capital);
            Console.WriteLine($"Se ha agregado {pais} con su capital {capital}.");
        }
        else
        {
            Console.WriteLine($"{pais} ya existe en el diccionario.");
        }
    }

    static void Main(string[] args)
    {
        PaisesYCapitales programa = new PaisesYCapitales();
        programa.MostrarCapitales();

        Console.WriteLine("\nAgregando un nuevo país:");
        programa.AgregarPais("Alemania", "Berlín");

        Console.WriteLine("\nLista actualizada:");
        programa.MostrarCapitales();

        Console.ReadKey();
    }
}