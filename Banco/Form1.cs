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
        public string rutaClientes;
        public string rutaCuentas;
        public char separador;
        public ClienteCrud clntCrud;
        public Form1()
        {
            InitializeComponent();
            rutaClientes = @"C:\DesarrolloWeb\Banco\clientes.csv";
            rutaCuentas = @"C:\DesarrolloWeb\Banco\cuentas.csv";
            separador = ',';
            clntCrud =new ClienteCrud();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string dui = txtDui.Text;
            clnt = new Cliente(nombre, dui);
           
            clntCrud.escribirCliente(rutaClientes, clnt, separador);

            txtSaldo.Enabled = true;
            txtNumCuenta.Enabled = true;
            comboBox1.Enabled = true;
            btnCuenta.Enabled = true;
            txtDui.Enabled = false;
            txtNombre.Enabled = false;
            button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(clntCrud.compararDui(txtDui.Text, rutaClientes))
            {
                StringBuilder salida = new StringBuilder();
                string cadena;
                List<string> lista = new List<string>();
                if (comboBox1.Text == "Cuenta de ahorro")
                {
                    CuentaAhorro cntAhorro = new CuentaAhorro(
                        clnt, Double.Parse(txtSaldo.Text), int.Parse(txtNumCuenta.Text), comboBox1.Text
                        );
                    cadena = cntAhorro.Cliente.ToString() + "," + cntAhorro.Saldo.ToString() + "," +
                        cntAhorro.numero.ToString() + "," + cntAhorro.tipoCuenta;
                    lista.Add(cadena);
                }
                else
                {
                    CuentaCorriente cntCorriente = new CuentaCorriente(
                        clnt, Double.Parse(txtSaldo.Text), int.Parse(txtNumCuenta.Text), comboBox1.Text
                        );
                    cadena = cntCorriente.Cliente.ToString() + "," + cntCorriente.Saldo.ToString() + "," +
                        cntCorriente.numero.ToString() + "," + cntCorriente.tipoCuenta;
                    lista.Add(cadena);
                }
                for (int i = 0; i < lista.Count; i++)
                {
                    salida.AppendLine(string.Join(separador.ToString(), lista[i]));
                    File.AppendAllText(rutaCuentas, salida.ToString());
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmbalances frm = new frmbalances(rutaClientes, rutaCuentas);
            frm.Show();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            FrmIngreso frm = new FrmIngreso(rutaClientes, rutaCuentas);
            frm.Show();
        }
    }
}
