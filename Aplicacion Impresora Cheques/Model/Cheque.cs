using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion_Impresora_Cheques.Model
{
    class Cheque
    {
        public long MontoCheque { get; set;}
        public string PagueseANombreDe { get; set;}
        public DateTime FechaVencimiento { get; set;}
        public int NroCheques { get; set; }
        public int DiasProxVencimiento { get; set;}
        public string Rut { get; set; }
        public string NroSerieCI { get; set;}
        public string Telefono { get; set;}
        public string NroBoleta { get; set;}
        public string CodAutorizacion { get; set;}
        public string Sucursal { get; set;}
    }
}
