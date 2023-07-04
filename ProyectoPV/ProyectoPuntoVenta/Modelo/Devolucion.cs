using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Modelo
{
    public class Devolucion
    {
        public int idproveedor { get; set; }
        public int NumeroDocumento { get; set; }
        public int IdCompra { get; set; }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
