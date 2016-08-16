using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PointOfService;

namespace Aplicacion_Impresora_Cheques.Model
{
    class Impresora
    {
        private PosPrinter posPrinter;
        private string stringGetDevice = "PosPrinter";
        private string logicalNameDevice = "TM-H6000III";
        
        public bool ConectarImpresora(out string errorString, out string device)
        {
            bool error = true;
            errorString = "";
            device = "";
            PosExplorer myPosExplorer = new PosExplorer();
            DeviceCollection myDevicesPrinter = myPosExplorer.GetDevices(stringGetDevice);
           

            bool arg_41_0;
            if (this.posPrinter != null)
            {
                bool arg_2F_0 = this.posPrinter.DeviceEnabled;
                arg_41_0 = !this.posPrinter.DeviceEnabled;
            }
            else
            {
                arg_41_0 = true;
            }
            bool result;
            if (!arg_41_0)
            {
                result = false;
            }
            else
            {
                foreach (DeviceInfo devInfo in myDevicesPrinter)
                {
                    if (devInfo.ServiceObjectName.Trim() == logicalNameDevice.Trim())
                    {
                        
                        try
                        {
                            
                            this.posPrinter = (myPosExplorer.CreateInstance(devInfo) as PosPrinter);
                            this.posPrinter.Open();
                            this.posPrinter.Claim(1000);
                            this.posPrinter.DeviceEnabled = true;
                            error = false;
                            if (devInfo.LogicalNames.Length > 0)
                            {
                                device = devInfo.LogicalNames[0];
                            }
                        }
                        catch (Exception e)
                        {
                            
                            errorString = e.Message;
                            //error = false;
                            break;
                        }
                    }
                }
                result = error;
            }
            return result;
        }

        public bool ConectarImpresoraOtraConeccion(out string errorString)
        {
            bool error = true;
            errorString = "";            
            try
            {
                PosExplorer posExplorer = new PosExplorer();                
                DeviceInfo receiptPrinterDevice = posExplorer.GetDevice(DeviceType.PosPrinter, logicalNameDevice);
                this.posPrinter = posExplorer.CreateInstance(receiptPrinterDevice) as PosPrinter;                
                this.posPrinter.Open();
                this.posPrinter.Claim(1000);
                this.posPrinter.DeviceEnabled = true;
                error = false;
            }
            catch (Exception e)
            {

                errorString = e.Message;                                                
            }

            return error;
        }
        public bool InsertarCheque()
        {
            bool result;
            try
            {
                this.posPrinter.BeginInsertion(10000);
                this.posPrinter.EndInsertion();
            }
            catch (Exception e_22)
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        public bool RetirarCheque()
        {
            bool result;
            try
            {
                this.posPrinter.BeginRemoval(10000);
                this.posPrinter.EndRemoval();
            }
            catch (Exception e_22)
            {
                result = false;
                return result;
            }
            result = true;
            return result;
        }

        public void ImprimirCheque(string monto, DateTime fechaVencimiento, string PagueseANombreDe)
        {
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            string stringAImprimir = "\u001b|rA                                                    " + Convert.ToInt64(monto).ToString("N0") + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            //this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            //this.posPrinter.PrintNormal(PrinterStation.Slip, " \n"); //se agrega otro salto de linea 
            stringAImprimir = string.Concat(new object[]
			{
				"\u001b|rA                                          ",
				fechaVencimiento.Day,
				"  ",
				TextHelper.MesEnPalabras(fechaVencimiento.Month),
				" ",
				fechaVencimiento.Year
                /*"\u001b|rA                                           ",
				fechaVencimiento.Day,
				"   ",
				TextHelper.MesEnPalabras(fechaVencimiento.Month),
				"   ",
				fechaVencimiento.Year*/
			});
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C" + PagueseANombreDe + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C" + TextHelper.Convertir(monto, false) + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            if (stringAImprimir.Length > 67)
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir.Substring(0, 67) + "-\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "     " + stringAImprimir.Substring(67) + "\n");
            }
            else
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                stringAImprimir = "     ";
                stringAImprimir = stringAImprimir.PadRight(25, '*');
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            }
            //this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Normal);
            //this.posPrinter.ClearOutput();
        }

        public void ImprimirChequeFormatoNuevo(string monto, DateTime fechaVencimiento, string PagueseANombreDe)
        {
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);            
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);            
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            //this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");

            
             string montoString = monto.ToString();
                                      
             string stringAImprimir = "\u001b|rA                                              "+helpText.separateMonto(monto);
 
             
              /*for (int z = 0; z < montoString.Length; ++z)
              {
                  stringAImprimir = stringAImprimir +montoString[z]+ " ";               
                  string espacio = "";
                  if (z >= 9)
                  {
                      espacio = " ";
                  }
                  else {
                      if ((z % 2) == 0)
                      {
                          espacio = " ";
                      }
                      else {
                          espacio = "  ";
                      }
                  
                  }
                  stringAImprimir = stringAImprimir +montoString[z]+ espacio;               
              }
              stringAImprimir = stringAImprimir + ".-";    
             
             */
            //string stringAImprimir = "\u001b|rA                                              " + Convert.ToInt64(monto).ToString("N0") + ".-";
            
                        
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");            
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");            
            
            string dayFechaVenc = helpText.getDayDateTimeToString(fechaVencimiento);
            string monthFechaVenc = helpText.getMonthDateTimeToString(fechaVencimiento);
            string yearFechaVenc = helpText.getYearDateTimeToString(fechaVencimiento);

            stringAImprimir = string.Concat(new object[]
			{
				"\u001b|rA                                                   ",
				dayFechaVenc[0],
                " ",
                dayFechaVenc[1],
				"   ",
				monthFechaVenc[0],
                " ",
                monthFechaVenc[1]
				
				
			});
            
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C " + PagueseANombreDe + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C" + TextHelper.Convertir(monto, false) + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            if (stringAImprimir.Length > 67)
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir.Substring(0, 67) + "-\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "     " + stringAImprimir.Substring(67) + "\n");
            }
            else
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                stringAImprimir = "     ";
                stringAImprimir = stringAImprimir.PadRight(25, '*');
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            }
            //this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Normal);
            //this.posPrinter.ClearOutput();
        }

        public void ImprimirChequeConCaracteres(string monto, DateTime fechaVencimiento, string PagueseANombreDe)
        {
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            string stringAImprimir = "\u001b|rA   (1b|rA)                                         " + Convert.ToInt64(monto).ToString("N0") + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "(salto n) \n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            stringAImprimir = string.Concat(new object[]
			{
				"\u001b|rA         (1b|rA)                         ",
				fechaVencimiento.Day,
				"   ",
				TextHelper.MesEnPalabras(fechaVencimiento.Month),
				"   ",
				fechaVencimiento.Year
			});
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA     (1bra|1b1c)       \u001b|1C" + PagueseANombreDe + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "(1b|5uf)  \u001b|5uF");
            stringAImprimir = "\u001b|rA     (1bra|1b1c)     \u001b|1C" + TextHelper.Convertir(monto, false) + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            if (stringAImprimir.Length > 67)
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir.Substring(0, 67) + "-\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "(1b|5uf)  \u001b|5uF");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "     " + stringAImprimir.Substring(67) + "\n");
            }
            else
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "(1b|5uf)  \u001b|5uF");
                stringAImprimir = "     ";
                stringAImprimir = stringAImprimir.PadRight(25, '*');
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "(salton) \n");
            }
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Normal);
        }

        public void ImprimirEndoso(string rut, string nroSerieCI, string telefono, string boleta, string codAutorizacion, string sucursal)
        {
            
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);            
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Rotate180);           
            this.posPrinter.ChangePrintSide(PrinterSide.Opposite);


            for (int l = 0; l < 5; l++)
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            }            
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA _____________________________________\n");         
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                  Rut = " + rut.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|         Nº Serie C.I.= " + nroSerieCI.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|             Telefono = " + telefono.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|  Nº Factura o Boleta = " + boleta.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|    Cod. Autorizacion = " + codAutorizacion.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|             Sucursal = " + sucursal.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|           AUTORIZACION CHEQUES      |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|_____________________________________|\n");
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.ChangePrintSide(PrinterSide.Side1);
        }


        public void ImprimirEndosoFormatoNuevo(string rut, string nroSerieCI, string telefono, string boleta, string codAutorizacion, string sucursal)
        {

            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);
            //this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Rotate180);
            this.posPrinter.ChangePrintSide(PrinterSide.Opposite);

           
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA _____________________________________\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|           AUTORIZACION CHEQUES      |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                                     |\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|                  Rut = " + rut.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|         Nº Serie C.I.= " + nroSerieCI.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|             Telefono = " + telefono.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|  Nº Factura o Boleta = " + boleta.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|    Cod. Autorizacion = " + codAutorizacion.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|             Sucursal = " + sucursal.PadRight(13, ' ') + "|\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA|_____________________________________|\n");
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.ChangePrintSide(PrinterSide.Side1);
        }

        public void ImprimirEndoso()
        {
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);
            this.posPrinter.ChangePrintSide(PrinterSide.Opposite);
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA            16878668-9\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA            Boleta 1\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \u001b|cA            ASD\n");
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.ChangePrintSide(PrinterSide.Side1);
        }

        public void liberarImpresora() {

            
            this.posPrinter.Close();
        }
    }
}
/*
  public void ImprimirChequeFormatoNuevo(string monto, DateTime fechaVencimiento, string PagueseANombreDe)
        {
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Transaction);            
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);            
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");
            
            string stringAImprimir = "\u001b|rA                                              " + Convert.ToInt64(monto).ToString("N0") + ".-";
            
                        
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");            
            this.posPrinter.PrintNormal(PrinterStation.Slip, " \n");            
            
            string dayFechaVenc = helpText.getDayDateTimeToString(fechaVencimiento);
            string monthFechaVenc = helpText.getMonthDateTimeToString(fechaVencimiento);
            string yearFechaVenc = helpText.getYearDateTimeToString(fechaVencimiento);

            stringAImprimir = string.Concat(new object[]
			{
				"\u001b|rA                                                   ",
				dayFechaVenc[0],
                " ",
                dayFechaVenc[1],
				"   ",
				monthFechaVenc[0],
                " ",
                monthFechaVenc[1],
				"   20"+yearFechaVenc[0]+yearFechaVenc[1]
				
			});
            
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C " + PagueseANombreDe + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
            stringAImprimir = "\u001b|rA          \u001b|1C" + TextHelper.Convertir(monto, false) + ".-";
            stringAImprimir = stringAImprimir.PadRight(67, '*');
            if (stringAImprimir.Length > 67)
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir.Substring(0, 67) + "-\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "     " + stringAImprimir.Substring(67) + "\n");
            }
            else
            {
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
                this.posPrinter.PrintNormal(PrinterStation.Slip, "\u001b|5uF");
                stringAImprimir = "     ";
                stringAImprimir = stringAImprimir.PadRight(25, '*');
                this.posPrinter.PrintNormal(PrinterStation.Slip, stringAImprimir + "\n");
            }
            //this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Right90);
            this.posPrinter.TransactionPrint(PrinterStation.Slip, PrinterTransactionControl.Normal);
            this.posPrinter.RotatePrint(PrinterStation.Slip, PrintRotation.Normal);
            //this.posPrinter.ClearOutput();
        }

 
 
 */