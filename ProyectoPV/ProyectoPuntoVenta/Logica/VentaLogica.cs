using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Logica
{
    public class VentaLogica
    {
        private static VentaLogica instancia = null;
        Conexion Myconexion = new Conexion();

        public VentaLogica()
        {

        }

        public static VentaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new VentaLogica();
                }
                return instancia;
            }
        }

        public List<Venta> ListarVenta() {
            List<Venta> Lista = new List<Venta>();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT IdVenta, TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,TotalPagar,PagoCon,Cambio,CONVERT(char(10),FechaRegistro,103)[FechaRegistro],CASE  WHEN TipoVenta = 'P' THEN 'Pago' WHEN TipoVenta = 'C' THEN 'Venta' END AS TipoVenta FROM VENTA");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TotalPagar = Convert.ToDecimal(dr["TotalPagar"],new CultureInfo("es-PE")),
                                PagoCon = Convert.ToDecimal(dr["PagoCon"], new CultureInfo("es-PE")),
                                Cambio = Convert.ToDecimal(dr["Cambio"], new CultureInfo("es-PE")),
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                TipoVenta= dr["TipoVenta"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Venta>();
                }
            }
            return Lista;
        }
        public List<Venta> ListarVentaDev()
        {
            List<Venta> Lista = new List<Venta>();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SELECT IdVenta, TipoDocumento,NumeroDocumento,DocumentoCliente,NombreCliente,TotalPagar,PagoCon,Cambio,CONVERT(char(10),FechaRegistro,103)[FechaRegistro] FROM VENTA_DEV where estado='1' ");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Venta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                TipoDocumento = dr["TipoDocumento"].ToString(),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                DocumentoCliente = dr["DocumentoCliente"].ToString(),
                                NombreCliente = dr["NombreCliente"].ToString(),
                                TotalPagar = Convert.ToDecimal(dr["TotalPagar"], new CultureInfo("es-Co")),
                                PagoCon = Convert.ToDecimal(dr["PagoCon"], new CultureInfo("es-Co")),
                                Cambio = Convert.ToDecimal(dr["Cambio"], new CultureInfo("es-Co")),
                                FechaRegistro = dr["FechaRegistro"].ToString()
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Venta>();
                }
            }
            return Lista;
        }

        public List<DetalleVenta> ListarDetalleVentaDev()
        {
            List<DetalleVenta> Lista = new List<DetalleVenta>();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    //  sb.AppendLine("select dv.IdVenta,p.Nombre,dv.Cantidad,dv.PrecioVenta,dv.SubTotal from DETALLE_VENTA dv");
                    //  sb.AppendLine("inner join PRODUCTO P on p.IdProducto = dv.IdProducto");

                    sb.AppendLine(" select dv.IdVenta,p.Nombre,count(dv.Cantidad) as Cantidad ,sum(dv.PrecioVenta)/count(dv.Cantidad) as PrecioVenta,sum(dv.SubTotal) as SubTotal");
                    sb.AppendLine(" from DETALLE_VENTA_DEV dv ");
                    sb.AppendLine(" inner join PRODUCTO P on p.IdProducto = dv.IdProducto ");
                    sb.AppendLine(" group by dv.IdVenta,p.Nombre");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new DetalleVenta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"], new CultureInfo("es-PE")),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"], new CultureInfo("es-PE"))
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<DetalleVenta>();
                }
            }
            return Lista;
        }
        public List<DetalleVenta> ListarDetalleVenta()
        {
            List<DetalleVenta> Lista = new List<DetalleVenta>();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    //  sb.AppendLine("select dv.IdVenta,p.Nombre,dv.Cantidad,dv.PrecioVenta,dv.SubTotal from DETALLE_VENTA dv");
                    //  sb.AppendLine("inner join PRODUCTO P on p.IdProducto = dv.IdProducto");

                    sb.AppendLine(" select dv.IdVenta,p.Nombre,count(dv.Cantidad) as Cantidad ,sum(dv.PrecioVenta)/count(dv.Cantidad) as PrecioVenta,sum(dv.SubTotal) as SubTotal");
                    sb.AppendLine(" from DETALLE_VENTA dv ");
                    sb.AppendLine(" inner join PRODUCTO P on p.IdProducto = dv.IdProducto ");
                    sb.AppendLine(" group by dv.IdVenta,p.Nombre");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new DetalleVenta()
                            {
                                IdVenta = Convert.ToInt32(dr["IdVenta"].ToString()),
                                oProducto = new Producto() { Nombre = dr["Nombre"].ToString() },
                                Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"], new CultureInfo("es-PE")),
                                SubTotal = Convert.ToDecimal(dr["SubTotal"], new CultureInfo("es-PE"))
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<DetalleVenta>();
                }
            }
            return Lista;
        }


        public bool ControlStock(int idproducto,int cantidad, bool restar)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    string query = string.Format("update producto set Stock = (Stock {0} {1}) where IdProducto = {2}", restar ? "-" : "+", cantidad, idproducto);
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }
        public bool actDevoluciones(int numDev,int numVenta)
        {
            bool respuesta = true;
            DateTime fechaActual = DateTime.Now;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    string query = string.Format("update VENTA_DEV set estado='0', fechaDev=" + " ' " +  fechaActual.ToString("yyyy-MM-dd hh:mm:ss") +" '" + " ,IdVentaDev=" + " ' " + numVenta.ToString() + " '" + "  where IdVenta=" + numDev.ToString());
                    SqlCommand cmd = new SqlCommand(query.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    respuesta = true;
                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }

            return respuesta;

        }


        public int Registrar(Venta objeto)
        {
            int respuesta = 0;

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    oConexion.Open();
                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idventa int = 0");
                    sb.AppendLine(string.Format("insert into VENTA(TipoDocumento,NumeroDocumento,IdUsuario,DocumentoCliente,NombreCliente,TotalPagar,PagoCon,Cambio,TipoVenta) values('{0}',({1}),{2},'{3}','{4}','{5}','{6}','{7}','{8}')"
                        , objeto.TipoDocumento
                        , "select right('000000' + cast((select count(*) + 1 from venta) as varchar), 6)"
                        , objeto.oPersona.IdPersona
                        , objeto.DocumentoCliente
                        , objeto.NombreCliente
                        , Convert.ToInt64(objeto.TotalPagar)
                        , Convert.ToInt64(objeto.PagoCon)
                        , Convert.ToInt64(objeto.Cambio)
                        ,objeto.TipoVenta));

                    sb.AppendLine("set @idventa = SCOPE_IDENTITY()");
                    foreach (DetalleVenta dv in objeto.oDetalleVenta)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_VENTA(IdVenta,IdProducto,Cantidad,PrecioVenta,SubTotal) values({0},{1},{2},'{3}','{4}')",
                            "@idventa", dv.oProducto.IdProducto,Convert.ToInt16(dv.Cantidad), Convert.ToInt64(dv.PrecioVenta), Convert.ToInt64(dv.SubTotal)));
                    }
                    sb.AppendLine("select @idventa");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = objTransacion;
                    try
                    {
                        int idventa = 0;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out idventa);

                        if (idventa != 0)
                        {
                            objTransacion.Commit();
                            respuesta = idventa;
                        }
                        else
                        {
                            objTransacion.Rollback();
                            respuesta = idventa;
                        }

                    }
                    catch (Exception e)
                    {
                        objTransacion.Rollback();
                        respuesta = 0;
                    }

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public DataTable Reporte(string fechainicio , string fechafin, string id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(20),v.FechaRegistro,21)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],p.Nombre[Nombre Vendedor],v.DocumentoCliente,v.NombreCliente,");
                    sb.AppendLine("convert(int,v.TotalPagar)[Total Pagar],convert(int,v.PagoCon)[Pago Con],convert(int,v.Cambio)[Cambio]   from VENTA v");
                    sb.AppendLine("inner join persona p on p.IdPersona = v.IdUsuario");
                    sb.AppendLine("where convert(date,v.FechaRegistro) between @fechainicio and @fechafin");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd)) {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }

        public DataTable ReporteDeventas(string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10),v.FechaRegistro,103)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],p.Nombre[Nombre Vendedor],v.DocumentoCliente,v.NombreCliente,");
                    sb.AppendLine("convert(int,v.TotalPagar)[Total Pagar],convert(int,v.PagoCon)[Pago Con],convert(int,v.Cambio)[Cambio]   from VENTA v");
                    sb.AppendLine("inner join persona p on p.IdPersona = v.IdUsuario");
                    sb.AppendLine("where convert(date,v.FechaRegistro) between @fechainicio and @fechafin");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }
        public DataTable ReporteCaja(string fechainicio, string fechafin,string idUsuario)
    {
        DataTable dt = new DataTable();
        using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SET DATEFORMAT dmy");
                sb.AppendLine("select convert(char(10),v.FechaRegistro,103)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],p.Nombre[Nombre Vendedor],v.DocumentoCliente,v.NombreCliente,");
                sb.AppendLine("convert(int,v.TotalPagar)[Total Pagar],convert(int,v.PagoCon)[Pago Con],convert(int,v.Cambio)[Cambio] ,CASE  ");
                sb.AppendLine(" WHEN TipoVenta = 'C' THEN 1 ");
                sb.AppendLine(" WHEN TipoVenta = 'P' THEN 0  end  as TipoVenta  from VENTA v");
                sb.AppendLine("inner join persona p on p.IdPersona = v.IdUsuario");
                sb.AppendLine("where convert(date,v.FechaRegistro) between @fechainicio and @fechafin");
                sb.AppendLine(" and v.idUsuario =@usuario");
                SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                cmd.Parameters.AddWithValue("@fechafin", fechafin);
                cmd.Parameters.AddWithValue("@usuario", idUsuario);

                cmd.CommandType = CommandType.Text;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                dt = new DataTable();
            }
        }
        return dt;

    }
        public DataTable ReporteCompraCev(string fechainicio, string fechafin, string idUsuario)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10),v.FechaRegistro,103)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],p.Nombre[Nombre Vendedor],v.DocumentoCliente,v.NombreCliente,");
                    sb.AppendLine("convert(int,v.TotalPagar)[Total Pagar],convert(int,v.PagoCon)[Pago Con],convert(int,v.Cambio)[Cambio]   from VENTA_DEV v");
                    sb.AppendLine("inner join persona p on p.IdPersona = v.IdUsuario");
                    sb.AppendLine("where convert(date,v.FechaDev) between @fechainicio and @fechafin");
                    sb.AppendLine(" and v.idUsuario =@usuario");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@usuario", idUsuario);

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }
        public DataTable ReportreDevActivas()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select idventa,totalpagar,fechaRegistro from VENTA_DEV where estado=1");
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }
        public DataTable reporteIva(string numfactura)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    

                    cmd = new SqlCommand("sp_GenerarImpuestos", oConexion);
                    cmd.Parameters.Add(new SqlParameter("@numfac", numfactura));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    return dt;

                }

                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;
            

        }
        public DataTable ReporteVentaDev(string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10),v.FechaRegistro,103)[Fecha Venta],v.TipoDocumento,v.NumeroDocumento,p.Documento[Documento Vendedor],");
                    sb.AppendLine("p.Nombre[Nombre Vendedor], v.DocumentoCliente, v.NombreCliente,");
                    sb.AppendLine("convert(int, v.TotalPagar)[Total Pagar], convert(int, v.PagoCon)[Pago Con], convert(int, v.Cambio)[Cambio], v.estado, DEV.idProducto, pr.Nombre,");
                    sb.AppendLine("DEV.cantidad, DEV.precioVenta, DEV.cantidad*DEV.precioVenta as subtotal");
                    sb.AppendLine("from VENTA_DEV v");
                    sb.AppendLine("inner ");
                    sb.AppendLine("join persona p on p.IdPersona = v.IdUsuario ");
                    sb.AppendLine("inner ");
                    sb.AppendLine("join DETALLE_VENTA_DEV DEV on DEV.idVenta = v.idVenta ");
                    sb.AppendLine("inner ");
                    sb.AppendLine("join PRODUCTO pr on pr.IdProducto = DEV.IdProducto");
                    sb.AppendLine("where convert(date,v.FechaRegistro) between @fechainicio and @fechafin");
                     SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                  

                    cmd.CommandType = CommandType.Text;

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;

        }
        public void AbreCajon()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\x1B" + "p" + "\x00" + "\x0F" + "\x96");
            //Caracteres de apertura cajon 0
        }
        public DataTable reporteGrafVentas(string fechainicio, string fechafin)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {


                    cmd = new SqlCommand("sp_GenerarVentasGrafica", oConexion);
                    cmd.Parameters.Add(new SqlParameter("@fechainicio", fechainicio));
                    cmd.Parameters.Add(new SqlParameter("@fechafin", fechafin));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    return dt;

                }

                catch (Exception ex)
                {
                    dt = new DataTable();
                }
            }
            return dt;


        }

    }
 }
