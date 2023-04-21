using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Cliente
    {
        public string nombre;
        public string dui;

        public Cliente(string nombre, string dui)
        {
            this.nombre = nombre;
            this.dui = dui;
        }

        public override string ToString()
        {
            return this.nombre+" "+this.dui;
        }
    }
}
