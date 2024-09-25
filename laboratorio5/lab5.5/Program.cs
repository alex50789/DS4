using System;

class Estudiante
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
}

internal class ListaEstudiantes
{
    private List<Estudiante> estudiantes;

    public ListaEstudiantes()
    {
        estudiantes = new List<Estudiante>
        {
            new Estudiante { Nombre = "Ana", Edad = 12 },
            new Estudiante { Nombre = "Juan", Edad = 10 },
            new Estudiante { Nombre = "Sofia", Edad = 11 }
        };
    }

    public void ImprimirEstudiantes()
    {
        Console.WriteLine("Lista de Estudiantes:");
        foreach (Estudiante estudiante in estudiantes)
        {
            Console.WriteLine($"Nombre: {estudiante.Nombre}, Edad: {estudiante.Edad}");
        }
    }

    static void Main(string[] args)
    {
        ListaEstudiantes programa = new ListaEstudiantes();
        programa.ImprimirEstudiantes();
        Console.ReadKey();
    }
}
