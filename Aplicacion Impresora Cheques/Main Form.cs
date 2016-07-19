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
    public partial class Main_Form : Form
    {
        DateTime fechaVencimientoCheque;
        List<Cheque> listaCheques;
        private Impresora impresoraEpson;
        public Main_Form()
        {
            
            InitializeComponent();
            this.textBoxPagueseNombre.Text = "COMERCIAL CELTA LTDA";
            this.textBoxSucursal.Text = "LARRONDO";
            this.comboBoxFormatoCheque.SelectedIndex = 0;
            this.impresoraEpson = new Impresora();
            
        }

        private void textBoxMontoCheque_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {                
                e.Handled = true;
                return;
            }
        }

        

        private void textBoxNumeroDeCheques_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                e.Handled = true;                
                return;
            }
            
           
        }

        private void textBoxDiasProximoVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {               
                e.Handled = true;                 
                return;
                  
            }
            
            
        }

        private void textBoxRut_Leave(object sender, EventArgs e)
        {
            if (this.textBoxRut.Text != "")
            {
                if (!helpText.validarRut(this.textBoxRut.Text))
                {


                    MessageBox.Show("Rut Invalido. Ingrese un Rut valido");
                    this.textBoxRut.Focus();
                }
            }
        }

        private void buttonGenerarCheques_Click(object sender, EventArgs e)
        {
            
            if (!validarCamposObligatorios())
            {
                MessageBox.Show("Debe llenar todos los campos antes de generar los cheques");
            }
            else {                
                generarChequesDataGrid();
                this.buttonImprimir.Enabled = true;
                this.buttonVolver.Enabled = true;
            }
            
            
        }

        private void textBoxNumeroDeCheques_KeyUp(object sender, KeyEventArgs e)
        {
            int numDeCheques;
            try
            {
                numDeCheques = Convert.ToInt32(this.textBoxNumeroDeCheques.Text);
            }
            catch (Exception) {
                numDeCheques = 0;
            }
            if (numDeCheques > 1)
            {
                this.labelDiasProximos.Visible = true;
                this.textBoxDiasProximoVencimiento.Visible = true;
            }
            else {
                this.labelDiasProximos.Visible = false;
                this.textBoxDiasProximoVencimiento.Visible = false;
            }
        }

        private bool validarCamposObligatorios(){
            string montoCheque = this.textBoxMontoCheque.Text;
            string pagueseNombre=this.textBoxPagueseNombre.Text;
            string numeroChequeString=this.textBoxNumeroDeCheques.Text;
                            
            string rut=this.textBoxRut.Text;
            string numeroBoleta=this.textBoxNumBoleta.Text;
            string sucursal=this.textBoxSucursal.Text;
            if (numeroChequeString == "")
            {
                return false;
            }
            else {
                int numeroCheque = Convert.ToInt32(this.textBoxNumeroDeCheques.Text);
                if (numeroCheque > 1) {
                    string diasVencimiento = this.textBoxDiasProximoVencimiento.Text;
                    if (diasVencimiento == "") {
                        return false;
                    }
                }
            }
            if (montoCheque == "" || pagueseNombre == "" || rut == "" || numeroBoleta == "" || sucursal == "") {
                return false;
            }
            return true;
        }

        private void generarChequesDataGrid()
        {
            
            this.dataGridViewCheques.Rows.Clear();
            fechaVencimientoCheque = this.dateTimePickerFechaVencimiento.Value.Date;
            int cantCheques = Convert.ToInt32(this.textBoxNumeroDeCheques.Text);
            if (cantCheques > 1)
            {
                string[] fechasVencimientoCheques = helpText.obtenerFechasVencimiento(fechaVencimientoCheque, this.textBoxNumeroDeCheques.Text, this.textBoxDiasProximoVencimiento.Text);
                string[] montosCheques = helpText.obtenerTotalesCheques(this.textBoxMontoCheque.Text, this.textBoxNumeroDeCheques.Text);
                for (int i = 0; i < cantCheques; i++)
                {
                    dataGridViewCheques.Rows.Add((i + 1), montosCheques[i], fechasVencimientoCheques[i], "", this.textBoxPagueseNombre.Text, this.textBoxRut.Text, this.textBoxNumeroSerie.Text, this.textBoxNumBoleta.Text, this.textBoxSucursal.Text, this.textBoxTelefono.Text);
                }

            }
            else {
                string fechaVencimientoString = fechaVencimientoCheque.Day + "/" + fechaVencimientoCheque.Month + "/" + fechaVencimientoCheque.Year;
                dataGridViewCheques.Rows.Add("1", this.textBoxMontoCheque.Text,fechaVencimientoString , "", this.textBoxPagueseNombre.Text, this.textBoxRut.Text, this.textBoxNumeroSerie.Text, this.textBoxNumBoleta.Text, this.textBoxSucursal.Text, this.textBoxTelefono.Text);
            
            }
        }

        private void buttonVolver_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void limpiarDatos(){
            this.textBoxTelefono.Text = "";            
            this.textBoxRut.Text = "";            
            this.textBoxNumeroSerie.Text = "";
            this.textBoxNumeroDeCheques.Text = "";
            this.textBoxNumBoleta.Text = "";
            this.textBoxMontoCheque.Text = "";
            this.textBoxDiasProximoVencimiento.Text = "";
            this.dataGridViewCheques.Rows.Clear();
            this.buttonImprimir.Enabled = false;
            this.buttonVolver.Enabled = false;
            this.labelDiasProximos.Visible = false;
            this.textBoxDiasProximoVencimiento.Visible = false;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            limpiarDatos();
        }

        private void buttonImprimir_Click(object sender, EventArgs e)
        {   
            string formatoCheque=this.comboBoxFormatoCheque.Text;
            string error="";
            
                if (validarDataGridCheques(out error))
                {

                    if (formatoCheque == "")
                    {
                        MessageBox.Show("Antes de imprimir debe elegir el formato del cheque");
                        this.comboBoxFormatoCheque.Focus();
                    }
                    else {

                        string errorConectarImpresora = "";
                        string device = "";

                        buscandoImpresora buscandoImpresoraForm = new buscandoImpresora();
                        buscandoImpresoraForm.Show();       
                        Application.DoEvents();
                         
                        if (this.impresoraEpson.ConectarImpresora(out errorConectarImpresora, out device))
                        {
                            buscandoImpresoraForm.Close();
                            
                            MessageBox.Show("Error al Conectar impresora :" + errorConectarImpresora , "Error validacion de datos", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            buscandoImpresoraForm.Close();       
                            try
                            {
                                imprimirCheques(formatoCheque);
                            }
                            catch (Exception ex) {
                                MessageBox.Show("Error:" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            }      
                            
                        }                        
                    }

                }
                else {
                    MessageBox.Show("Error:"+error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            
        }

        private void dataGridViewCheques_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*int countDataGrid = dataGridViewCheques.RowCount;
             
            if (countDataGrid>0) {
                int indexCell = dataGridViewCheques.CurrentCell.ColumnIndex;                
                
            }*/
            
        }   
        private bool validarDataGridCheques(out string error){
            error = "";
            long montoCheque = Convert.ToInt64(this.textBoxMontoCheque.Text);
            long montoChequeTemporal = 0;
            listaCheques= new List<Cheque>();
            for (int i = 0; i < dataGridViewCheques.Rows.Count; i++)
            {
                Cheque cheque = new Cheque();
                cheque.NroCheques = Convert.ToInt32(dataGridViewCheques.Rows[i].Cells[0].Value.ToString());
                
                try
                {                
                    cheque.MontoCheque=Convert.ToInt64(dataGridViewCheques.Rows[i].Cells[1].Value.ToString());
                }catch(Exception){
                    error = "Uno de los montos no tiene el formato correcto. Revise fila " + (i + 1);
                    return false;                    
                }
                try
                {
                    cheque.FechaVencimiento=helpText.stringToDateTime(dataGridViewCheques.Rows[i].Cells[2].Value.ToString());                
                }
                catch (Exception) {
                    error = "Una de los fechas de vencimiento no tiene el formato Correcto. El formato debe ser dd/mm/yyyy. Revise la fila "+(i+1);
                    return false;
                }                             
                try
                {
                    cheque.CodAutorizacion = dataGridViewCheques.Rows[i].Cells[3].Value.ToString();
                    cheque.PagueseANombreDe = dataGridViewCheques.Rows[i].Cells[4].Value.ToString();
                    cheque.Rut = dataGridViewCheques.Rows[i].Cells[5].Value.ToString();
                    cheque.NroSerieCI = dataGridViewCheques.Rows[i].Cells[6].Value.ToString();
                    cheque.NroBoleta = dataGridViewCheques.Rows[i].Cells[7].Value.ToString();
                    cheque.Sucursal = dataGridViewCheques.Rows[i].Cells[8].Value.ToString();
                    cheque.Telefono = dataGridViewCheques.Rows[i].Cells[9].Value.ToString();
                }
                catch (Exception) {
                    error = "Debe llenar todos los campos";
                    return false;                    
                }
                if (cheque.CodAutorizacion == "" || cheque.PagueseANombreDe == "" || cheque.Rut == "" || cheque.NroSerieCI == "" || cheque.NroBoleta == "" || cheque.Sucursal == "") {
                    error = "Debe llenar todos los campos";                   
                    return false;                    
                }
               montoChequeTemporal=montoChequeTemporal+cheque.MontoCheque;
               listaCheques.Add(cheque);
            }
            if (montoChequeTemporal != montoCheque) {

                error = "Los montos de los cheques no coinciden con el monto total";
                return false;
            }

            return true;
        }

        private void imprimirCheques(string formatoCheque)
        {

            DialogResult questionFomatoCheque = MessageBox.Show("¿Esta seguro que quiere imprimir los cheques en el formato " + this.comboBoxFormatoCheque.Text+" ?", "Formato Cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            int cantidadCheques = dataGridViewCheques.RowCount;
            int indexCheque=0;
                        
            if (questionFomatoCheque == DialogResult.OK) { 
                foreach(Cheque cheque in listaCheques){
                    indexCheque++;                    
						bool chequeInsertado = false;
                        while (!chequeInsertado)
                        {
                            DialogResult questionPrintCheque = MessageBox.Show("Coloque el cheque en la impresora y luego presione aceptar para imprimir cheque nº" + indexCheque, "Inserte cheque", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                            if (questionPrintCheque != DialogResult.OK)
                            {
                                MessageBox.Show("Cheque cancelado por usuario, presione aceptar para pasar al siguiente cheque.");                                
                                break;
                            }
                            chequeInsertado = this.impresoraEpson.InsertarCheque();
                            //chequeInsertado = true;
                            if (chequeInsertado)
                            {
                                bool chequeRetirado = false;

                                loadingImpresionForm loading = new loadingImpresionForm();
                                loading.Show();                                
                                Application.DoEvents();
                                this.impresoraEpson.ImprimirEndoso(cheque.Rut, cheque.NroSerieCI, cheque.Telefono, cheque.NroBoleta, cheque.CodAutorizacion, cheque.Sucursal);
                                
                                if (formatoCheque == "NUEVO")
                                {                                       
                                    this.impresoraEpson.ImprimirChequeFormatoNuevo(cheque.MontoCheque.ToString(), cheque.FechaVencimiento, cheque.PagueseANombreDe);    
                                }
                                else {
                                    this.impresoraEpson.ImprimirCheque(cheque.MontoCheque.ToString(), cheque.FechaVencimiento, cheque.PagueseANombreDe);
                                }
                                loading.Close();                               
                                while (!chequeRetirado)
                                {
                                    MessageBox.Show("Favor retirar Cheque luego de presionar aceptar.");
                                    chequeRetirado = this.impresoraEpson.RetirarCheque();
                                    //chequeRetirado = true;
                                }                                
                            }
                        }
                }
                MessageBox.Show("Impresion de cheques terminada.");     
            }            
                
        }

        private void Main_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea cerrar la aplicacion? \nConsidere que si sale de la aplicacion, para utilizar nuevamente la aplicacion o la impresora Epson TM-H6000III debera reiniciar el equipo", "Salir", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        this.impresoraEpson.liberarImpresora();
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show("No se pudo liberar impresora. Error:" + ex);
                    }
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
            
            
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            Form1 test = new Form1();
            test.Show();
            
        }        
    }
}
