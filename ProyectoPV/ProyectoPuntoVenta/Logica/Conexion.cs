using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoPuntoVenta.Logica
{
    public class Conexion
    {

        public    string CN = ConfigurationManager.ConnectionStrings["conexion"].ToString();
        public  string ruta()
        {
            return ConfigurationManager.ConnectionStrings["conexion"].ToString();
        }
    }
}
