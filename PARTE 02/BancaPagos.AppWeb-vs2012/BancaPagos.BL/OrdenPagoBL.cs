using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BancaPagos.BE;


namespace BancaPagos.BL
{
    public class OrdenPagoBL
    {

        public List<OrdenPago> GetOrdenPagobyMoneda(string Moneda)
        {
            
            var lresult = new List<OrdenPago>();
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().GetOrdenPagobyMoneda(Moneda);
            }
            catch (Exception ex)
            {
                throw ex;
            }

           
        }
        public List<OrdenPago> findAll(string pBanco, string pSucursal)
        {   
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().findAll(pBanco, pSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
        public OrdenPago find(int id)
        {
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool insert(OrdenPago OrdenPago)
        {
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().insert(OrdenPago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool edit(OrdenPago OrdenPago)
        {
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().edit(OrdenPago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool delete(int id)
        {
            try
            {
                return new BancaPagos.DA.OrdenPagoDA().delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
