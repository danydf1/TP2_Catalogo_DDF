using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> listado = new List<Categoria>();
            SqlConnection Conexion = new SqlConnection();
            SqlCommand Comando = new SqlCommand();
            SqlDataReader lector;
            try
            {
                Conexion.ConnectionString = "data source=DESKTOP-09K26PO\\SQLEXPRESS;initial Catalog=CATALOGO_DB;integrated security=sspi ";
                Comando.CommandType = System.Data.CommandType.Text;
                Comando.CommandText = "select ID, Descripcion From CATEGORIAS";
                Comando.Connection = Conexion;
                Conexion.Open();
                lector = Comando.ExecuteReader();
                while (lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = lector.GetInt32(0);
                    aux.Descripcion = lector.GetString(1);



                    listado.Add(aux);
                }



                return listado;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    } 
}
