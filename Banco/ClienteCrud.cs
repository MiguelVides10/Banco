using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public class ClienteCrud
    {
        public void escribirCliente(string ruta, Cliente clnt, char separador)
        {
            StringBuilder salida = new StringBuilder();

            string cadena = clnt.nombre + "," + clnt.dui;
            List<String> lista = new List<String>();
            lista.Add(cadena);
            for (int i = 0; i < lista.Count; i++)
            {
                salida.AppendLine(string.Join(separador.ToString(), lista[i]));
                File.AppendAllText(ruta, salida.ToString());
            }

            MessageBox.Show("Elemento guardado con éxito", "Éxito",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        public Boolean compararDui(string dui, string ruta)
        {
            using (StreamReader lector = new StreamReader(ruta))
            {
                string datos;
                while ((datos = lector.ReadLine()) != null)
                {
                    string[] fila = datos.Split(',');
                    string nombre = fila[0];
                    string dui1 = fila[1];
                    if (dui1 == dui)
                    {
                        Cliente cliente = new Cliente(nombre, dui);
                        return true;
                    }
                }
            }
            return false;
        }

        public void cargarClientes(string ruta, DataGridView dtg)
        {
            using (StreamReader lector = new StreamReader(ruta))
            {
                string datos;
                while ((datos = lector.ReadLine()) != null)
                {
                    string[] fila = datos.Split(',');
                    string nombre = fila[0];
                    string dui = fila[1];
                    Cliente tmpCliente = new Cliente( nombre, dui);
                    dtg.Rows.Add(tmpCliente.nombre,tmpCliente.dui);
                }
            }
        }
    }
}
