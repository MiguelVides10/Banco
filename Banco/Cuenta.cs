using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public abstract class Cuenta
    {
        private Cliente cliente;
        private double saldo;
        public int numero;
        public string tipoCuenta;
        internal Cliente Cliente { get => cliente; set => cliente = value; }
        public double Saldo { get => saldo; set => saldo = value; }
        public Cuenta(Cliente clnt, double psaldo, int num, string tipoCuenta)
        {
            this.Cliente = clnt;
            this.Saldo = psaldo;
            this.numero = num;
            this.tipoCuenta = tipoCuenta;
        }

        public double deposito(double cantidad)
        {
            if(cantidad > 0) {
                this.Saldo += cantidad;
            }
            return this.Saldo;
        }

        public virtual double retirar(double cantidad) { 
            throw new NotImplementedException();
        }

        //public double retirar(double cantidad, double comision)
        //{
        //    cantidad = cantidad * (1 + comision / 100);
        //    if(cantidad <= this.Saldo)
        //    {
        //        this.Saldo -= cantidad;
        //    }
        //    return this.Saldo;
        //}
        public void transferir(double cantidad, Cuenta cnt)
        {
            this.retirar(cantidad);
            cnt.deposito(cantidad);
        }
    }
}
