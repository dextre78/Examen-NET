using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancaPagos.BE
{
    public class OrdenPago
    {
        public int id_ordenPago { get; set; }
        public int id_sucursal { get; set; }
        public IEnumerable<Sucursal> ListaSucursal { get; set; }
        public decimal Monto { get; set; }
        public string Moneda { get; set; }
        public string Sucursal { get; set; }
        public string Banco { get; set; }
        public string Estado { get; set; }
        public DateTime FechaPago { get; set; }
    }
}