using CRUDECORE.Models;
using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace CRUDECORE.Datos
{
    public class ContactoDatos
    {
    public List<ContactoModel> Listar(){

            var oLista = new List<ContactoModel>();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL())){
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        oLista.Add(new ContactoModel() {
                            IdContacto = Convert.ToInt32(dr["IdContacto"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Correo = dr["Correo"].ToString(),
                        });
                    }
                }
            }
        
            return oLista;
        }
        public ContactoModel Obtener(int IdContacto)
        {

            var oContacto = new ContactoModel();

            var cn = new Conexion();

            using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", Conexion);
                cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.IdContacto = Convert.ToInt32(dr["IdContacto"]);
                        oContacto.Nombre = dr["Nombre"].ToString();
                        oContacto.Telefono = dr["Telefono"].ToString();
                        oContacto.Correo = dr["Correo"].ToString();
                    }
                }
            }

            return oContacto;
        }

        public bool Guardar(ContactoModel oContacto) {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", Conexion);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Editar(ContactoModel oContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", Conexion);
                    cmd.Parameters.AddWithValue("IdContacto", oContacto.IdContacto);
                    cmd.Parameters.AddWithValue("Nombre", oContacto.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oContacto.Telefono);
                    cmd.Parameters.AddWithValue("Correo", oContacto.Correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(int IdContacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();
                using (var Conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    Conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", Conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
