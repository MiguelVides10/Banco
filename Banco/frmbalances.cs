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
    public partial class frmbalances : Form
    {
        public ClienteCrud clntCrud;
        public string rutaCliente, rutaCnta;
        public frmbalances(string rutaClnt, string rutaCuenta)
        {
            InitializeComponent();
            rutaCliente = rutaClnt;
            rutaCnta = rutaCuenta; 
            clntCrud = new ClienteCrud();
            clntCrud.cargarClientes(rutaCliente, this.dgvClientes);
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string duiCliente = dgvClientes.SelectedRows[0].Cells[1].Value.ToString();
            leerCuentas(rutaCnta, duiCliente);
        }

        public void leerCuentas(string ruta, string dui)
        {
            using (StreamReader lector = new StreamReader(ruta))
            {
                listBox1.Items.Clear();
                string datos;
                while ((datos = lector.ReadLine()) != null)
                {
                    string[] fila = datos.Split(',');
                    string dui1 = fila[1];
                    if(dui == dui1)
                    {
                        string saldo = fila[2];
                        string numero = fila[3];
                        string tipoCuenta = fila[4];

                        listBox1.Items.Add("Saldo: "+saldo);
                        listBox1.Items.Add("Numero de cuenta: "+numero);
                        listBox1.Items.Add("Tipo de Cuenta: "+tipoCuenta);
                    }
                }
            }
        }
    }
}
