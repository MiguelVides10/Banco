using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class CuentaAhorro : Cuenta, IRetirar
    {
        public CuentaAhorro(Cliente clnt, double saldo, int numero, string tipoCuenta)
            : base(clnt, saldo, numero, tipoCuenta)
        {
        }

        public double retirar(double cantidad, double comision)
        {
            cantidad = cantidad * (1 + comision / 100);
            if (cantidad <= this.Saldo)
            {
                this.Saldo -= cantidad;
            }
            return this.Saldo;
        }

        public override double retirar(double cantidad)
        {
            //Comisión del 5%
            this.retirar(cantidad, 5);
            return base.Saldo;
        }
    }
}
