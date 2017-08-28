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
    public class SucursalController : ApiController
    {
        public IEnumerable<Sucursal> GetSucursalByBanco(string Banco)
        {
            var Lista = new SucursalBL().findAll(Banco);
            return Lista;
        }
    }
}
