using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BancaPagos.BE;
using BancaPagos.BL;

namespace BancaPagos.WebApi.Controllers
{
    public class OrdenPagoController : ApiController
    {
        public IEnumerable<OrdenPago> GetOrdenPago(string Moneda)
        {
            IEnumerable<OrdenPago> Lista = new OrdenPagoBL().GetOrdenPagobyMoneda(Moneda);
            return Lista;
        }
    }
}
