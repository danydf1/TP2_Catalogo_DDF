using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProductoNegocio
    {
            public List<Producto> listar()
            {
                List<Producto> listado = new List<Producto>();
                SqlConnection Conexion = new SqlConnection();
                SqlCommand Comando = new SqlCommand();
                SqlDataReader lector;
                try
                {
                    Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                    Comando.CommandType = System.Data.CommandType.Text;
                    Comando.CommandText = "select Codigo, Nombre, Descripcion,ImagenUrl,Precio From ARTICULOS";
                    Comando.Connection = Conexion;
                    Conexion.Open();
                    lector = Comando.ExecuteReader();
                    while (lector.Read())
                    {
                    Producto aux = new Producto();
                    aux.Codigo = lector.GetString(0);
                    aux.Nombre = lector.GetString (1);
                    aux.Descripcion = lector.GetString(2);
                    aux.ImagenURL = lector.GetString(3);


                     listado.Add(aux);
                    }



                    return listado;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

        public void agregar(Producto nuevo)
        {
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "insert into ARTICULOS (Codigo,Nombre,Descripcion) values (@Codigo,@Nombre,@Descripcion)";
                Comando.Parameters.Clear();
                Comando.Parameters.AddWithValue("@Codigo", nuevo.Codigo);
                Comando.Parameters.AddWithValue("@Nombre", nuevo.Nombre);
                Comando.Parameters.AddWithValue("@Descripcion", nuevo.Descripcion);
                Comando.Connection = Conexion;

                Conexion.Open();
                Comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Conexion.Close();
            }
        }
    }
}

