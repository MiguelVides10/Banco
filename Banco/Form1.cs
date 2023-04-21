using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        public Cliente clnt;
        public CuentaCorriente cuenta;
        public string rutaClientes;
        public string rutaCuentas;
        public char separador;
        public Form1()
        {
            InitializeComponent();
            rutaClientes = @"C:\DesarrolloWeb\Banco\clientes.csv";
            rutaCuentas = @"C:\DesarrolloWeb\Banco\cuentas.csv";
            separador = ',';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StringBuilder salida = new StringBuilder();
            string nombre = txtNombre.Text;
            string dui = txtDui.Text;
            clnt = new Cliente(nombre, dui);
            string cadena = clnt.nombre + "," + clnt.dui;
            List<String> lista = new List<String>();
            lista.Add(cadena);
            for (int i = 0; i < lista.Count; i++)
            {
                salida.AppendLine(string.Join(separador.ToString(), lista[i]));
                File.AppendAllText(rutaClientes, salida.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader lector = new StreamReader(rutaClientes);
            string datos;
            while ((datos = lector.ReadLine()) != null)
            {
                string [] fila = datos.Split(separador);
                string nombre = fila[0];
                string dui = fila[1];
                if(clnt.nombre.Equals(nombre))
                {
                    Cliente cliente = new Cliente(nombre, dui);
                }
            }
            lector.Close();
            
            StringBuilder salida = new StringBuilder();
            string cadena;
            List<string> lista = new List<string>();
            if(comboBox1.Text =="Cuenta de ahorro")
            {
                CuentaAhorro cntAhorro = new CuentaAhorro(
                    clnt, Double.Parse(txtSaldo.Text),int.Parse(txtNumCuenta.Text),comboBox1.Text
                    );
                cadena = cntAhorro.Cliente.ToString() + "," + cntAhorro.Saldo.ToString()+","+
                    cntAhorro.numero.ToString()+","+cntAhorro.tipoCuenta;
                lista.Add(cadena);
            }
            else
            {
                CuentaCorriente cntCorriente = new CuentaCorriente(
                    clnt, Double.Parse(txtSaldo.Text), int.Parse(txtNumCuenta.Text), comboBox1.Text
                    );
                cadena = cntCorriente.Cliente.ToString() + "," + cntCorriente.Saldo.ToString() + "," +
                    cntCorriente .numero.ToString() + "," + cntCorriente .tipoCuenta;
                lista.Add(cadena);
            }
            for (int i = 0; i < lista.Count; i++)
            {
                salida.AppendLine(string.Join(separador.ToString(), lista[i]));
                File.AppendAllText(rutaCuentas, salida.ToString());
            }
        }
    }
}
