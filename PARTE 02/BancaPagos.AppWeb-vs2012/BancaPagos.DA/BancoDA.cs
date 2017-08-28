using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Data.SqlClient;
using BancaPagos.BE;

namespace BancaPagos.DA
{
    public class BancoDA
    {
        string strcnn = ConfigurationManager.ConnectionStrings["ConnectBanca"].ToString();

        public Banco find(int id)
        {
            Banco banco = new Banco();
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_find_banco", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    query.Parameters.AddWithValue("@id_banco", id);

                    using (var rd = query.ExecuteReader())
                    {  
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                banco.id_banca = Convert.ToInt32(rd["id_banco"]);
                                banco.Nombre = rd["Nombre"].ToString();
                                banco.Direccion = rd["Direccion"].ToString();
                                banco.FechaRegistro = Convert.ToDateTime(rd["FechaRegistro"]);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return banco;
        }


        public List<Banco> findAll()
        {
            Banco banco;
            List<Banco> lreturn = new List<Banco>(); 
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_findAll_banco", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var rd = query.ExecuteReader())
                    {
                        if (rd.HasRows)
                        {
                            while (rd.Read())
                            {
                                banco = new Banco();
                                banco.id_banca = Convert.ToInt32(rd["id_banco"]);
                                banco.Nombre = rd["Nombre"].ToString();
                                banco.Direccion = rd["Direccion"].ToString();
                                banco.FechaRegistro = Convert.ToDateTime(rd["FechaRegistro"]);
                                lreturn.Add(banco);
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lreturn;
        }


        public bool insert(Banco banco)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_insert_banco", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@Nombre", banco.Nombre);
                    query.Parameters.AddWithValue("@Direccion", banco.Direccion);
                    //query.Parameters.AddWithValue("@FechaRegistro", banco.FechaRegistro);

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

        public bool edit(Banco banco)
        {
            bool result = false;
            try
            {
                using (SqlConnection cnn = new SqlConnection(strcnn))
                {
                    cnn.Open();

                    var query = new SqlCommand("sp_edit_banco", cnn);
                    query.CommandType = System.Data.CommandType.StoredProcedure;

                    query.Parameters.AddWithValue("@id_banco", banco.id_banca);
                    query.Parameters.AddWithValue("@Nombre", banco.Nombre);
                    query.Parameters.AddWithValue("@Direccion", banco.Direccion);
                    //query.Parameters.AddWithValue("@FechaRegistro", banco.FechaRegistro);

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

                    var query = new SqlCommand("sp_delete_banco", cnn);
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
