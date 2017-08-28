using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BancaPagos.BE;
using System.Data.SqlClient;
using System.Configuration;

namespace BancaPagos.DA
{
    public class SucursalDA
    {

        string strcnn = ConfigurationManager.ConnectionStrings["ConnectBanca"].ToString();


        public List<Sucursal> findAll(string pNombre)
        {

            Sucursal sucursal;
            var lresult = new List<Sucursal>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_find_sucursal_byBanco", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@Nombre", pNombre);

                    using (var rd = query.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                sucursal = new Sucursal();
                                sucursal.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                sucursal.id_banca = Convert.ToInt32(rd["id_banco"]);
                                sucursal.Nombre = rd["Nombre"].ToString();
                                sucursal.Banco= rd["Banco"].ToString();
                                sucursal.Direccion = rd["Direccion"].ToString();
                                sucursal.FechaRegistro = Convert.ToDateTime(rd["FechaRegistro"]);
                                lresult.Add(sucursal);
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


        public List<Sucursal> findAllById(int id)
        {

            Sucursal sucursal;
            var lresult = new List<Sucursal>();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_findAllById_sucursal", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@id_sucursal", id);

                    using (var rd = query.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                sucursal = new Sucursal();
                                sucursal.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                sucursal.id_banca = Convert.ToInt32(rd["id_banco"]);
                                sucursal.Nombre = rd["Nombre"].ToString();                                
                                sucursal.Direccion = rd["Direccion"].ToString();
                                sucursal.FechaRegistro = Convert.ToDateTime(rd["FechaRegistro"]);
                                lresult.Add(sucursal);
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

        public Sucursal find(int id)
        {
            Sucursal sucursal = new Sucursal();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_find_sucursal", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@id_sucursal", id);

                    using (var rd = query.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                sucursal.id_sucursal = Convert.ToInt32(rd["id_sucursal"]);
                                sucursal.id_banca = Convert.ToInt32(rd["id_banco"]);
                                sucursal.Nombre = rd["Nombre"].ToString();                                
                                sucursal.Direccion = rd["Direccion"].ToString();
                                sucursal.FechaRegistro = Convert.ToDateTime(rd["FechaRegistro"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return sucursal;
        }


        public bool insert(Sucursal sucursal)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_insert_sucursal", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_banco", sucursal.id_banca);
                    query.Parameters.AddWithValue("@Nombre", sucursal.Nombre);
                    query.Parameters.AddWithValue("@Direccion", sucursal.Direccion);

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

        public bool edit(Sucursal Sucursal)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_edit_sucursal", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_banco", Sucursal.id_banca);
                    query.Parameters.AddWithValue("@Nombre", Sucursal.Nombre);
                    query.Parameters.AddWithValue("@Direccion", Sucursal.Direccion);
                    query.Parameters.AddWithValue("@FechaRegistro", Sucursal.FechaRegistro);

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

                    var query = new SqlCommand("sp_delete_sucursal", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_banco", id);
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
