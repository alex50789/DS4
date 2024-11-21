using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using ApiCalculadora.Models;

public class CalculadoraContext : DbContext
{
    public CalculadoraContext() : base("name=CalculadoraDB") // Utiliza la cadena de conexión definida en Web.config
    {
    }

    public DbSet<Operaciones> Operaciones { get; set; } // Propiedad para acceder a la tabla "operaciones"
}