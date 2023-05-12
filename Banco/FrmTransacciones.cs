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
    public partial class FrmTransacciones : Form
    {
        public string rutaCuenta, duiRecibido;
        public Cliente clnt;
        public CuentaCorriente cntaCorr;
        public CuentaAhorro cntaAhrr;
        public FrmTransacciones(string rutaCnta, string dui)
        {
            rutaCuenta = rutaCnta;
            duiRecibido = dui;
            InitializeComponent();
            cargarDatos(duiRecibido, rutaCuenta);
        }

        private void btnDeposito_Click(object sender, EventArgs e)
        {
            if(cntaCorr.tipoCuenta != null)
            {
                cntaCorr.deposito(Double.Parse(txtCantidad.Text));
            }
            else
            {
                cntaAhrr.deposito(Double.Parse(txtCantidad.Text));
            }
            
        }

        public void cargarDatos(string dui, string ruta)
        {
            using (StreamReader lector = new StreamReader(ruta))
            {
                string datos;
                while ((datos = lector.ReadLine()) != null)
                {
                    string[] fila = datos.Split(',');
                    string dui1 = fila[1];
                    string tipoCuenta = fila[4];
                    if (dui == dui1 && tipoCuenta =="Cuenta de ahorro")
                    {
                        string saldo = fila[2];
                        string numero = fila[3];
                        string nombrcliente= fila[0];

                        clnt = new Cliente(nombrcliente, dui1);
                        cntaAhrr = new CuentaAhorro(clnt, Double.Parse(saldo),Convert.ToInt32(numero), tipoCuenta);

                        lblCliente.Text += clnt.nombre;
                        lblDui.Text += clnt.dui;
                        lblSaldo.Text += cntaAhrr.Saldo;
                        lblNumCuenta.Text += cntaAhrr.numero;
                        lblTipCuenta.Text += cntaAhrr.tipoCuenta;
                    } else if(dui == dui1 && tipoCuenta == "Cuenta corriente")
                    {
                        string saldo = fila[2];
                        string numero = fila[3];
                        string nombrcliente = fila[0];

                        clnt = new Cliente(nombrcliente, dui1);
                        cntaCorr = new CuentaCorriente(clnt, Double.Parse(saldo), Convert.ToInt32(numero), tipoCuenta);

                        lblCliente.Text += clnt.nombre;
                        lblDui.Text += clnt.dui;
                        lblSaldo.Text += cntaCorr.Saldo;
                        lblNumCuenta.Text += cntaCorr.numero;
                        lblTipCuenta.Text += cntaCorr.tipoCuenta;
                    }
                }
            }
        }
        public void actualizarDatos(string dui, double saldo, string ruta)
        {
            StreamReader leerDatos;
            leerDatos = File.OpenText("cuentas.csv");
        }
    }
}
