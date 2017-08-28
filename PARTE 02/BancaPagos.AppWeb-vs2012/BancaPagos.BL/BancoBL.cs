using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.SqlClient;
using BancaPagos.BE;

namespace BancaPagos.BL
{
    public class BancoBL
    {
        public List<Banco> findAll()
        {
            try
            {
                return new BancaPagos.DA.BancoDA().findAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
        public Banco find(int id)
        {
            try
            {
                return new BancaPagos.DA.BancoDA().find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool insert(Banco banco)
        {
            try
            {
                return new BancaPagos.DA.BancoDA().insert(banco);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool edit(Banco banco)
        {
            try
            {
                return new BancaPagos.DA.BancoDA().edit(banco);
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
                return new BancaPagos.DA.BancoDA().delete(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
