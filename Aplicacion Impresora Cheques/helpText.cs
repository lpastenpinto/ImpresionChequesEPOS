using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Impresora_Cheques
{
    class helpText
    {
        public static string[] obtenerTotalesCheques(string montoString, string cantidadChequesString) {
            int cantidadCheques = Convert.ToInt32(cantidadChequesString);
            int monto = Convert.ToInt32(montoString);
            string[] montos = new string[cantidadCheques];

            double division = monto / cantidadCheques;
            int resto = monto % cantidadCheques;
            for (int i = 0; i < cantidadCheques; i++) {
                if (i == (cantidadCheques - 1)) {
                    division = division + resto;
                }
                montos[i] = division.ToString();

            }
            
            return montos;
        }
        public static bool validarRut(string rut)
        {

            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        public static string[] obtenerFechasVencimiento(DateTime fechaVencimiento, string cantidadChequesString, string cantidadDiasProxVencimientoString) {
            int cantidadCheques = Convert.ToInt32(cantidadChequesString);
            int cantidadDiasProxVencimiento = Convert.ToInt32(cantidadDiasProxVencimientoString);
            string[] fechasVencimiento = new string[cantidadCheques];

            DateTime nextDate = fechaVencimiento;
            for (int i = 0; i < cantidadCheques; i++) {
                if (i == 0)
                {
                    fechasVencimiento[i] = fechaVencimiento.Day + "/" + fechaVencimiento.Month + "/" + fechaVencimiento.Year;
                }
                else {
                    nextDate = nextDate.AddDays(cantidadDiasProxVencimiento);
                    fechasVencimiento[i] = nextDate.Day + "/" + nextDate.Month + "/" + nextDate.Year;
                }
                
            }
            return fechasVencimiento;

        }
        
        public static DateTime stringToDateTime(string fecha) {
            fecha = fecha.Replace("-", "/");
            string[] fecha1 = fecha.Split('/');
            int dia = Convert.ToInt32(fecha1[0]);
            int mes = Convert.ToInt32(fecha1[1]);
            int ano = Convert.ToInt32(fecha1[2]);
            DateTime fechaNueva = new DateTime(ano, mes, dia);            
            return fechaNueva;
        }

        public static string DateTimeToString(DateTime fechaCompleta)
        {
            int dia = 0;
            int mes = 0;
            int ano = 0;
            dia = fechaCompleta.Day;
            mes = fechaCompleta.Month;
            ano = fechaCompleta.Year;

            string dia_ = dia + "";
            string mes_ = mes + "";
            if (dia < 10)
            {
                dia_ = "0" + dia;
            }
            if (mes < 10)
            {
                mes_ = "0" + mes;
            }
            return dia_ + "/" + mes_ + "/" + ano;
        }

        public static string getDayDateTimeToString(DateTime fechaCompleta) {
            int dia = 0;            
            dia = fechaCompleta.Day;            

            string dia_ = dia + "";            
            if (dia < 10)
            {
                dia_ = "0" + dia;
            }
            return dia_;
        }
        public static string getMonthDateTimeToString(DateTime fechaCompleta)
        {
            int mes = 0;
            mes = fechaCompleta.Month;

            string mes_ = mes + "";
            if (mes < 10)
            {
                mes_ = "0" + mes;
            }
            return mes_;
        }
        public static string getYearDateTimeToString(DateTime fechaCompleta) {
            string anioTemp = fechaCompleta.Year.ToString();
            string anio = "";
            for (int i = 2; i < 4; i++) {
                anio = anio + anioTemp[i];
            }
            return anio;
        }
    }
}
