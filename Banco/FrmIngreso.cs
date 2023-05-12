using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class FrmIngreso : Form
    {
        string rutaCliente, rutaCnta, dui;

        private void button1_Click(object sender, EventArgs e)
        {
            dui = textBox1.Text;
            FrmTransacciones frm = new FrmTransacciones(rutaCnta, dui);
            frm.Show();
        }

        public FrmIngreso(string rutaclnt, string rutaCuenta)
        {
            InitializeComponent();
            rutaCliente = rutaclnt;
            rutaCnta=rutaCuenta;
        }
    }
}
