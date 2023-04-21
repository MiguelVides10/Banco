using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class CuentaCorriente : Cuenta, IRetirar
    {
        public CuentaCorriente(Cliente clnt, double saldo, int numero, string tipoCuenta)
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
            //Comisión del 2%
            this.retirar(cantidad, 2);
            return base.Saldo;
        }


    }
}
