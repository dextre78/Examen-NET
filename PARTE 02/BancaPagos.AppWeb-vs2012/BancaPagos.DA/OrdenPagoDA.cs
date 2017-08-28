using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BancaPagos.BE;
using System.Data.SqlClient;
using System.Configuration;

namespace BancaPagos.DA
{
    public class OrdenPagoDA
    {

         string strcnn = ConfigurationManager.ConnectionStrings["ConnectBanca"].ToString();

        public List<OrdenPago> GetOrdenPagobyMoneda(string Moneda)
        {
            OrdenPago OrdenPago;
            var lresult = new List<OrdenPago>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_find_ordenPago_byMoneda", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@Moneda", Moneda);
                    
                    using (var rd = query.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                OrdenPago = new OrdenPago();
                                OrdenPago.id_ordenPago = Convert.ToInt32(rd["id_ordenPago"]);
                                OrdenPago.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                OrdenPago.Monto = Convert.ToDecimal(rd["Monto"]);
                                OrdenPago.Moneda = rd["Moneda"].ToString();
                                OrdenPago.Banco = rd["Banco"].ToString();
                                OrdenPago.Sucursal = rd["Sucursal"].ToString();
                                OrdenPago.Estado = rd["Estado"].ToString();
                                OrdenPago.FechaPago = Convert.ToDateTime(rd["FechaPago"]);
                                lresult.Add(OrdenPago);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lresult;
        }


        public List<OrdenPago> findAll(string pBanco, string pSucursal)
         {
             OrdenPago OrdenPago;
             var lresult = new List<OrdenPago>();
             try
             {
                 using (SqlConnection cnn = new SqlConnection(strcnn))
                 {
                     cnn.Open();

                     var query = new SqlCommand("sp_findAll_ordenPago", cnn);
                     query.CommandType = System.Data.CommandType.StoredProcedure;

                     query.Parameters.AddWithValue("@NombreBanco", pBanco);
                     query.Parameters.AddWithValue("@NombreSucursal", pSucursal);

                     using (var rd = query.ExecuteReader())
                     {
                         if (rd.HasRows)
                         {
                             while (rd.Read())
                             {
                                 OrdenPago = new OrdenPago();
                                 OrdenPago.id_ordenPago = Convert.ToInt32(rd["id_ordenPago"]);
                                 OrdenPago.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                 OrdenPago.Monto = Convert.ToDecimal(rd["Monto"]);
                                 OrdenPago.Moneda = rd["Moneda"].ToString();
                                 OrdenPago.Banco = rd["Banco"].ToString();
                                 OrdenPago.Sucursal = rd["Sucursal"].ToString();
                                 OrdenPago.Estado = rd["Estado"].ToString();
                                 OrdenPago.FechaPago = Convert.ToDateTime(rd["FechaPago"]);
                                 lresult.Add(OrdenPago);
                             }
                         }
                     }

                 }
             }
             catch (Exception ex)
             {
                 throw ex;
             }

             return lresult;
         }

        public OrdenPago find(int id)
        {
            OrdenPago OrdenPago = new OrdenPago();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_find_ordenPago", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_ordenPago", id);

                    using (var rd = query.ExecuteReader())
                    {
                         if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                OrdenPago.id_ordenPago = Convert.ToInt32(rd["id_ordenPago"]);
                                OrdenPago.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                OrdenPago.Monto = Convert.ToDecimal(rd["Monto"]);
                                OrdenPago.Moneda = rd["Moneda"].ToString();
                                OrdenPago.FechaPago = Convert.ToDateTime(rd["FechaPago"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return OrdenPago;
        }


        public bool insert(OrdenPago OrdenPago)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_insert_ordenPago", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_sucursal", OrdenPago.id_sucursal);
                    query.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    query.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    query.Parameters.AddWithValue("@Estado", OrdenPago.Estado);                    

                    query.ExecuteReader();

                    result = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public bool edit(OrdenPago OrdenPago)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_edit_ordenPago", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_ordenPago", OrdenPago.id_ordenPago);
                    query.Parameters.AddWithValue("@id_sucursal", OrdenPago.id_sucursal);
                    query.Parameters.AddWithValue("@Monto", OrdenPago.Monto);
                    query.Parameters.AddWithValue("@Moneda", OrdenPago.Moneda);
                    query.Parameters.AddWithValue("@Estado", OrdenPago.Estado);                    

                    query.ExecuteReader();

                    result = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }


        public bool delete(int id)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_delete_ordenPago", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_ordenPago", id);
                    query.ExecuteReader();
                    result = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }
    }
    
}
