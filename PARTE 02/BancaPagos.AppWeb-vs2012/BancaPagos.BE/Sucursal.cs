using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancaPagos.BE
{
    public class Sucursal
    {
        public int id_sucursal { get; set; }
        public int id_banca { get; set; }
        public string Nombre { get; set; }
        public string Banco { get; set; }

        public IEnumerable<Banco> ListaBanco { get; set; }
        public string Direccion { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}