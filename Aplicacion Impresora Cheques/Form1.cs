using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion_Impresora_Cheques.Model;
namespace Aplicacion_Impresora_Cheques
{
    public partial class Form1 : Form
    {
        private Impresora impresoraEpson;
        private Cheque cheque;
        public Form1()
        {
            InitializeComponent();
            this.impresoraEpson = new Impresora();
            this.cheque = new Cheque();
        }

        private void buttonProbarConexion_Click(object sender, EventArgs e)
        {
            this.impresoraEpson = new Impresora();
            probarConexionImpresora();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {
            this.impresoraEpson = new Impresora();
            probarImpresionCheque();
        }

        private void probarConexionImpresora(){
            string errorConectarImpresora = "";
            string device = "";
            if (this.impresoraEpson.ConectarImpresora(out errorConectarImpresora,out device))
            {                
                MessageBox.Show("Error al Conectar impresora :" + errorConectarImpresora+"  |  Device:"+device, "Error validacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("Impresora Encontrada!  |Device:"+device);
            }
        }

        private void probarImpresionCheque() {
            probarConexionImpresora();
            try
            {
                bool chequeInsertado = false;

                cheque.MontoCheque = 12000;
                cheque.FechaVencimiento = DateTime.Today;
                cheque.PagueseANombreDe = "Leandro Pasten";

                chequeInsertado = this.impresoraEpson.InsertarCheque();

                if (chequeInsertado)
                {
                    bool chequeRetirado = false;
                    this.impresoraEpson.ImprimirEndoso(cheque.Rut,cheque.NroSerieCI,cheque.Telefono,cheque.NroBoleta,cheque.CodAutorizacion,cheque.Sucursal);
                    this.impresoraEpson.ImprimirCheque(cheque.MontoCheque.ToString(), cheque.FechaVencimiento, cheque.PagueseANombreDe);

                    while (!chequeRetirado)
                    {
                        MessageBox.Show("Favor retirar Cheque luego de presionar aceptar.");
                        chequeRetirado = this.impresoraEpson.RetirarCheque();
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }	
        }

        private void probarImpresionFormatoNuevo() {
            probarConexionImpresora();
            try
            {
                bool chequeInsertado = false;

                cheque.MontoCheque = 12000;
                cheque.FechaVencimiento = DateTime.Today;
                cheque.PagueseANombreDe = "Leandro Pasten";

                chequeInsertado = this.impresoraEpson.InsertarCheque();

                if (chequeInsertado)
                {
                    bool chequeRetirado = false;
                    this.impresoraEpson.ImprimirEndoso(cheque.Rut, cheque.NroSerieCI, cheque.Telefono, cheque.NroBoleta, cheque.CodAutorizacion, cheque.Sucursal);
                    this.impresoraEpson.ImprimirChequeFormatoNuevo(cheque.MontoCheque.ToString(), cheque.FechaVencimiento, cheque.PagueseANombreDe);

                    while (!chequeRetirado)
                    {
                        MessageBox.Show("Favor retirar Cheque luego de presionar aceptar.");
                        chequeRetirado = this.impresoraEpson.RetirarCheque();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }	
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.impresoraEpson = new Impresora();
            probarImpresionFormatoNuevo();

        }

        private void buttonProbarOtraConect_Click(object sender, EventArgs e)
        {
            string errorConectarImpresora = "";
            this.impresoraEpson = new Impresora();
            if (this.impresoraEpson.ConectarImpresoraOtraConeccion(out errorConectarImpresora))
            {
                MessageBox.Show("Error al Conectar impresora :" + errorConectarImpresora, "Error validacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                MessageBox.Show("Impresora Encontrada!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Main_Form main = new Main_Form();
            main.Show();
            this.Close();
        }

       
    }
}
