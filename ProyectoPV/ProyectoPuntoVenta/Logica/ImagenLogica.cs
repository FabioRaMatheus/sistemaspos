using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Logica
{
  
    public class ImagenLogica
    {
        private static ImagenLogica instancia = null;
        Conexion Myconexion = new Conexion();

        public static ImagenLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ImagenLogica();
                }

                return instancia;
            }
        }
        public DataTable Listar()
        {
            DataTable Lista = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    //string sql = "select  p.PrecioVenta,i.idproducto,i.picture,p.IdProducto from producto p  inner join imagenesProducto i
                    //on p.Codigo = i.idproducto
                    //    where p.estado = 1
                    //and p.Stock > 0; ";

                    ////StringBuilder sb = new StringBuilder();
                    //////sb.AppendLine("select * from imagenesProducto where estado=1");
                    SqlCommand cmd = new SqlCommand();
                    //////cmd.CommandType = CommandType.Text;

                    //oConexion.Open();
                    ////SqlDataReader dr = cmd.ExecuteReader();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    //adapter.Fill(Lista);
                    //oConexion.Close();
                    //using (SqlDataReader dr = cmd.ExecuteReader())
                    //{
                    //    while (dr.Read())
                    //    {
                    //        Lista.Add(new Imagenes()
                    //        {
                    //            IdProducto = Convert.ToInt32(dr["IdProducto"]),
                    //            path = dr["path"].ToString()

                    //        });
                    //    }
                    //}



                       cmd = new SqlCommand("ventasFrecuentes", oConexion);
                       cmd.CommandType = CommandType.StoredProcedure;
                       adapter.SelectCommand = cmd;
                       adapter.Fill(Lista);

                       return Lista;

                  



                }
                catch (Exception ex)
                {
                    return Lista;
                }
            }
            return Lista;
        }
    }
    
}
