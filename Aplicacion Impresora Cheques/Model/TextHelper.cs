using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Aplicacion_Impresora_Cheques.Model
{
    class TextHelper
    {
        private static string[] UNIDADES = new string[]
		{
			"",
			"un ",
			"dos ",
			"tres ",
			"cuatro ",
			"cinco ",
			"seis ",
			"siete ",
			"ocho ",
			"nueve "
		};

        private static string[] DECENAS = new string[]
		{
			"diez ",
			"once ",
			"doce ",
			"trece ",
			"catorce ",
			"quince ",
			"dieciseis ",
			"diecisiete ",
			"dieciocho ",
			"diecinueve",
			"veinte ",
			"treinta ",
			"cuarenta ",
			"cincuenta ",
			"sesenta ",
			"setenta ",
			"ochenta ",
			"noventa "
		};

        private static string[] CENTENAS = new string[]
		{
			"",
			"ciento ",
			"doscientos ",
			"trecientos ",
			"cuatrocientos ",
			"quinientos ",
			"seiscientos ",
			"setecientos ",
			"ochocientos ",
			"novecientos "
		};

        private static Regex r;

        public static string Convertir(string numero, bool mayusculas)
        {
            numero = numero.Replace(".", ",");
            if (numero.IndexOf(",") == -1)
            {
                numero += ",00";
            }
            TextHelper.r = new Regex("\\d{1,9},\\d{1,2}");
            MatchCollection mc = TextHelper.r.Matches(numero);
            string result;
            if (mc.Count > 0)
            {
                string[] Num = numero.Split(new char[]
				{
					','
				});
                string literal;
                if (int.Parse(Num[0]) == 0)
                {
                    literal = "cero ";
                }
                else if (int.Parse(Num[0]) > 999999)
                {
                    literal = TextHelper.getMillones(Num[0]);
                }
                else if (int.Parse(Num[0]) > 999)
                {
                    literal = TextHelper.getMiles(Num[0]);
                }
                else if (int.Parse(Num[0]) > 99)
                {
                    literal = TextHelper.getCentenas(Num[0]);
                }
                else if (int.Parse(Num[0]) > 9)
                {
                    literal = TextHelper.getDecenas(Num[0]);
                }
                else
                {
                    literal = TextHelper.getUnidades(Num[0]);
                }
                if (mayusculas)
                {
                    result = literal.ToUpper();
                }
                else
                {
                    result = literal;
                }
            }
            else
            {
                result = null;
            }
            return result;
        }

        private static string getUnidades(string numero)
        {
            string num = numero.Substring(numero.Length - 1);
            return TextHelper.UNIDADES[int.Parse(num)];
        }

        private static string getDecenas(string num)
        {
            int i = int.Parse(num);
            string result;
            if (i < 10)
            {
                result = TextHelper.getUnidades(num);
            }
            else if (i > 19)
            {
                string u = TextHelper.getUnidades(num);
                if (u.Equals(""))
                {
                    result = TextHelper.DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                }
                else
                {
                    result = TextHelper.DECENAS[int.Parse(num.Substring(0, 1)) + 8] + "y " + u;
                }
            }
            else
            {
                result = TextHelper.DECENAS[i - 10];
            }
            return result;
        }

        private static string getCentenas(string num)
        {
            string result;
            if (int.Parse(num) > 99)
            {
                if (int.Parse(num) == 100)
                {
                    result = " cien ";
                }
                else
                {
                    result = TextHelper.CENTENAS[int.Parse(num.Substring(0, 1))] + TextHelper.getDecenas(num.Substring(1));
                }
            }
            else
            {
                result = TextHelper.getDecenas(string.Concat(int.Parse(num)));
            }
            return result;
        }

        private static string getMiles(string numero)
        {
            string c = numero.Substring(numero.Length - 3);
            string i = numero.Substring(0, numero.Length - 3);
            string result;
            if (int.Parse(i) > 0)
            {
                string j = TextHelper.getCentenas(i);
                result = j + "mil " + TextHelper.getCentenas(c);
            }
            else
            {
                result = (TextHelper.getCentenas(c) ?? "");
            }
            return result;
        }

        private static string getMillones(string numero)
        {
            string miles = numero.Substring(numero.Length - 6);
            string millon = numero.Substring(0, numero.Length - 6);
            string i;
            if (millon.Length > 1)
            {
                i = TextHelper.getCentenas(millon) + "millones ";
            }
            else if (Convert.ToInt32(millon) > 1)
            {
                i = TextHelper.getUnidades(millon) + "millones ";
            }
            else
            {
                i = TextHelper.getUnidades(millon) + "millon ";
            }
            return i + TextHelper.getMiles(miles);
        }

        public static string MesEnPalabras(int mes)
        {
            string result;
            switch (mes)
            {
                case 0:
                    result = null;
                    break;
                case 1:
                    result = "ENERO";
                    break;
                case 2:
                    result = "FEBRERO";
                    break;
                case 3:
                    result = "MARZO";
                    break;
                case 4:
                    result = "ABRIL";
                    break;
                case 5:
                    result = "MAYO";
                    break;
                case 6:
                    result = "JUNIO";
                    break;
                case 7:
                    result = "JULIO";
                    break;
                case 8:
                    result = "AGOSTO";
                    break;
                case 9:
                    result = "SEPTIEMBRE";
                    break;
                case 10:
                    result = "OCTUBRE";
                    break;
                case 11:
                    result = "NOVIEMBRE";
                    break;
                case 12:
                    result = "DICIEMBRE";
                    break;
                default:
                    result = null;
                    break;
            }
            return result;
        }
    }
}
