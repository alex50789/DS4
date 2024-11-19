Public Module Program
    Public Sub Main(args() As String)
        Dim perrito As Perro = New Perro()
        perrito.nombre = "Chizu"
        perrito.raza = "Husky"
        perrito.altura = "100cm"

        Console.WriteLine(perrito.comer("Carne"))

        Dim perrito2 As Perro = New Perro()
        perrito2.nombre = "Helios"
        perrito2.altura = "0.80cm"

        Console.WriteLine(perrito2.comer("Pollo"))

        Dim perrito3 As Perro = New Perro("Peluchin", "Mastin", "120")

        Console.WriteLine(perrito3.comer("Pan"))
    End Sub
End Module