using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BancaPagos.BE;

namespace BancaPagos.BL
{
    public class SucursalBL
    {

        public List<Sucursal> findAllById(int id)
        {
            Sucursal sucursal = new Sucursal();
            try
            {
                return new BancaPagos.DA.SucursalDA().findAllById(id);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Sucursal> findAll(string pNombre)
        {
            Sucursal sucursal = new Sucursal();
            try
            {
                return new BancaPagos.DA.SucursalDA().findAll(pNombre);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Sucursal find(int id)
        {
            
            try
            {
                return new BancaPagos.DA.SucursalDA().find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }


        public bool insert(Sucursal sucursal)
        {            
            try
            {
                return new BancaPagos.DA.SucursalDA().insert(sucursal);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public bool edit(Sucursal Sucursal)
        {
           
            try
            {
                return new BancaPagos.DA.SucursalDA().edit(Sucursal);    
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
               return new BancaPagos.DA.SucursalDA().delete(id);    
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
    
}
