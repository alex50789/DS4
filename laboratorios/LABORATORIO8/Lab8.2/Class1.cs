using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio82
{
    public class Cuenta
    {
        private string idCuenta;

        public Cuenta(string prntidCuenta)
        {
            this.idCuenta = prntidCuenta;
            System.Console.WriteLine(
                "Constructor Clase Base para cuenta(0)", prntidCuenta);
        }

        public virtual void CalcularIntereses()
        {
            System.Console.WriteLine(
                "Cuenta.CalcularIntereses() efectuado para la cuenta(0)",
                this.idCuenta);
        }
        public string getIdCuenta()
        {
            return this.idCuenta;
        }
    }

    public class CuentaCorriente : Cuenta
    {
        public CuentaCorriente(string prntidCuenta) : base(prntidCuenta)
        {
        }
        public override void CalcularIntereses()
        {
            System.Console.WriteLine(
                "CuentaCorriente.CalcularIntereses() efectuado para " +
                "la cuenta(0)", getIdCuenta());
        }
    }

    public class CuentaAhorro : Cuenta
    {
        public CuentaAhorro(string prntIdCuenta) : base(prntIdCuenta)
        {
        }

        public override void CalcularIntereses()
        {
            System.Console.WriteLine(
                "CuentaAhorro.CalcularIntereses() efectuado para " +
                "la cuenta (0)", getIdCuenta());
        }
    }
}
