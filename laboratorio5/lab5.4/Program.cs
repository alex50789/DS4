using System;

internal class PromedioCalificaciones
{
    private List<int> calificaciones = new List<int> { 85, 90, 78, 92, 88 };

    public void CalcularPromedio()
    {
        int suma = 0;
        foreach (int calificacion in calificaciones)
        {
            suma += calificacion;
        }
        double promedio = suma / (double)calificaciones.Count;
        Console.WriteLine($"El promedio de las calificaciones es: {promedio:F2}");
    }

    static void Main(string[] args)
    {
        PromedioCalificaciones programa = new PromedioCalificaciones();
        programa.CalcularPromedio();
        Console.ReadKey();
    }
}