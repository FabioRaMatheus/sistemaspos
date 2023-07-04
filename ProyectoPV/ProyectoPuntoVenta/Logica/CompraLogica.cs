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
    public class CompraLogica
    {
        private static CompraLogica instancia = null;
        Conexion Myconexion = new Conexion();

        public CompraLogica()
        {

        }

        public static CompraLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new CompraLogica();
                }

                return instancia;
            }
        }


        public bool Registrar(Compra objeto)
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    oConexion.Open();

                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idcompra int = 0");
                    sb.AppendLine(string.Format("insert into COMPRA(IdPersona, IdProveedor, MontoTotal, TipoDocumento, NumeroDocumento) values({0}, {1}, '{2}', '{3}','{4}')"
                        ,objeto.oPersona.IdPersona, objeto.oProveedor.IdProveedor, objeto.MontoTotal.ToString("0.00", new CultureInfo("es-PE")), objeto.TipoDocumento, objeto.NumeroDocumento));
                        
                    sb.AppendLine("set @idcompra = SCOPE_IDENTITY()");
                    foreach (DetalleCompra dv in objeto.oDetalleCompra)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_COMPRA(IdCompra,IdProducto,Cantidad,PrecioCompra,PrecioVenta,Total) values({0},{1},{2},'{3}','{4}','{5}')", 
                            "@idcompra",dv.oProducto.IdProducto,dv.Cantidad,dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.Total.ToString("0.00", new CultureInfo("es-PE"))));

                        sb.AppendLine(string.Format("update PRODUCTO set Stock = (Stock + {0}) , PrecioCompra = '{1}', PrecioVenta = '{2}' where IdProducto = {3}", dv.Cantidad, dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.oProducto.IdProducto));
                    }
                    sb.AppendLine("select @idcompra");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = objTransacion;
                    try
                    {
                        int idcompra = 0;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out idcompra);

                        if (idcompra != 0)
                        {
                            objTransacion.Commit();
                            respuesta = true;
                        }
                        else
                        {
                            objTransacion.Rollback();
                            respuesta = false;
                        }

                    }
                    catch (Exception e)
                    {
                        objTransacion.Rollback();
                        respuesta = false;
                    }

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
        //---

        public int DevVentas(Compra objeto)
        {
            int respuesta = 0;

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    oConexion.Open();

                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idcompra int = 0");
                    sb.AppendLine(string.Format("insert into VENTA_DEV(IdUsuario, DocumentoCliente, TotalPagar, TipoDocumento, NumeroDocumento,PagoCon,Cambio,NombreCliente) values({0}, {1}, '{2}', '{3}','{4}','{2}','0','ventas mostrador')"
                        , objeto.oPersona.IdPersona, objeto.oProveedor.IdProveedor, objeto.MontoTotal.ToString("0.00", new CultureInfo("es-PE")), objeto.TipoDocumento, objeto.NumeroDocumento, objeto.MontoTotal.ToString("0.00", new CultureInfo("es-PE"))));

                    sb.AppendLine("set @idcompra = SCOPE_IDENTITY()");
                    foreach (DetalleCompra dv in objeto.oDetalleCompra)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_VENTA_DEV(IdVenta,IdProducto,Cantidad,PrecioVenta,SubTotal) values({0},{1},{2},'{3}','{4}')",
                            "@idcompra", dv.oProducto.IdProducto, dv.Cantidad, dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.Total.ToString("0.00", new CultureInfo("es-PE"))));

                        sb.AppendLine(string.Format("update PRODUCTO set Stock = (Stock + {0})  where IdProducto = {3}", dv.Cantidad, dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.oProducto.IdProducto));
                    }
                    sb.AppendLine("select @idcompra");

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


        //---

        public bool DevCompras(Compra objeto)  //esta bien
        {
            bool respuesta = true;

            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    oConexion.Open();

                    SqlTransaction objTransacion = oConexion.BeginTransaction();


                    sb.AppendLine("declare @idcompra int = 0");
                    sb.AppendLine(string.Format("insert into COMPRA_DEV(IdPersona, IdProveedor, MontoTotal, TipoDocumento, NumeroDocumento) values({0}, {1}, '{2}', '{3}','{4}')"
                        , objeto.oPersona.IdPersona, objeto.oProveedor.IdProveedor, objeto.MontoTotal.ToString("0.00", new CultureInfo("es-PE")), objeto.TipoDocumento, objeto.NumeroDocumento));

                    sb.AppendLine("set @idcompra = SCOPE_IDENTITY()");
                    foreach (DetalleCompra dv in objeto.oDetalleCompra)
                    {
                        sb.AppendLine(string.Format("insert into DETALLE_COMPRA_DEV(IdCompra,IdProducto,Cantidad,PrecioCompra,PrecioVenta,Total) values({0},{1},{2},'{3}','{4}','{5}')",
                            "@idcompra", dv.oProducto.IdProducto, dv.Cantidad, dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.Total.ToString("0.00", new CultureInfo("es-PE"))));

                        sb.AppendLine(string.Format("update PRODUCTO set Stock = (Stock - {0}) where IdProducto = {3}", dv.Cantidad, dv.PrecioCompra.ToString("0.00", new CultureInfo("es-PE")), dv.PrecioVenta.ToString("0.00", new CultureInfo("es-PE")), dv.oProducto.IdProducto));
                    }
                    sb.AppendLine("select @idcompra");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = objTransacion;
                    try
                    {
                        int idcompra = 0;
                        int.TryParse(cmd.ExecuteScalar().ToString(), out idcompra);

                        if (idcompra != 0)
                        {
                            objTransacion.Commit();
                            respuesta = true;
                        }
                        else
                        {
                            objTransacion.Rollback();
                            respuesta = false;
                        }

                    }
                    catch (Exception e)
                    {
                        objTransacion.Rollback();
                        respuesta = false;
                    }

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }


        //---


        public DataTable Reporte(string idproveedor, string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                     StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10), c.fecharegistro,103)[Fecha Compra],p.Documento[Documento Proveedor],p.RazonSocial[Razon Social Proveedor],");
                    sb.AppendLine("c.TipoDocumento[Tipo Documento],c.NumeroDocumento[Numero Documento], CONVERT(int, c.MontoTotal) as [Monto Total],");
                    sb.AppendLine("pr.Nombre[Nombre Producto],dv.Cantidad,CONVERT(int, dv.PrecioCompra)[Precio Compra],CONVERT(int, dv.PrecioVenta)[Precio Venta],dbo.f_calpago(c.NumeroDocumento) as pagos,");
                    sb.AppendLine("CONVERT(int, dv.Total)[Sub Total],c.idCompra from compra c");
                    sb.AppendLine("inner join PROVEEDOR p on p.idproveedor = c.idproveedor");
                    sb.AppendLine("inner join detalle_compra dv on dv.idcompra = c.idcompra");
                    sb.AppendLine("inner join PRODUCTO pr on pr.IdProducto = dv.IdProducto");
                    sb.AppendLine("where convert(date,c.FechaRegistro) between @fechainicio and @fechafin");
                    sb.AppendLine("and c.IdProveedor =  case @idproveedor when '0' then c.IdProveedor when 0 then c.IdProveedor else @idproveedor end");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@idproveedor", idproveedor);
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
        public DataTable ReporteDev(string idproveedor, string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    //,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10), c.fecharegistro,103)[Fecha Compra],p.Documento[Documento Proveedor],p.RazonSocial[Razon Social Proveedor],");
                    sb.AppendLine("c.TipoDocumento[Tipo Documento],c.NumeroDocumento[Numero Documento], CONVERT(int, c.MontoTotal) as [Monto Total],");
                    sb.AppendLine("pr.Nombre[Nombre Producto],dv.Cantidad,CONVERT(int, dv.PrecioCompra)[Precio Compra],CONVERT(int, dv.PrecioVenta)[Precio Venta],");
                    sb.AppendLine("CONVERT(int, dv.Total)[Sub Total],c.idCompra ,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev from COMPRA_DEV c");
                    sb.AppendLine("inner join PROVEEDOR p on p.idproveedor = c.idproveedor");
                    sb.AppendLine("inner join DETALLE_COMPRA_DEV dv on dv.idcompra = c.idcompra");
                    sb.AppendLine("inner join PRODUCTO pr on pr.IdProducto = dv.IdProducto");
                    sb.AppendLine("where convert(date,c.FechaRegistro) between @fechainicio and @fechafin");
                    sb.AppendLine("and c.IdProveedor =  case @idproveedor when '0' then c.IdProveedor when 0 then c.IdProveedor else @idproveedor end");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                    cmd.Parameters.AddWithValue("@fechafin", fechafin);
                    cmd.Parameters.AddWithValue("@idproveedor", idproveedor);
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


 
    public DataTable ReporteCartera(string idproveedor, string fechainicio, string fechafin)
    {
        DataTable dt = new DataTable();
        using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
        {
            try
            {
                //,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("SET DATEFORMAT dmy");
                sb.AppendLine("select convert(char(10), c.fecharegistro,103)[Fecha Compra],p.Documento[Documento Proveedor],p.RazonSocial[Razon Social Proveedor],");
                sb.AppendLine("c.TipoDocumento[Tipo Documento],c.NumeroDocumento[Numero Documento], CONVERT(int, c.MontoTotal) as [Monto Total],");
                sb.AppendLine("pr.Nombre[Nombre Producto],dv.Cantidad,CONVERT(int, dv.PrecioCompra)[Precio Compra],CONVERT(int, dv.PrecioVenta)[Precio Venta],");
                sb.AppendLine("CONVERT(int, dv.Total)[Sub Total],c.idCompra ,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev from COMPRA c");
                sb.AppendLine("inner join PROVEEDOR p on p.idproveedor = c.idproveedor");
                sb.AppendLine("inner join DETALLE_COMPRA dv on dv.idcompra = c.idcompra");
                sb.AppendLine("inner join PRODUCTO pr on pr.IdProducto = dv.IdProducto");
                sb.AppendLine("where convert(date,c.FechaRegistro) between @fechainicio and @fechafin");
                sb.AppendLine("and c.IdProveedor =  case @idproveedor when '0' then c.IdProveedor when 0 then c.IdProveedor else @idproveedor end");

                SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                cmd.Parameters.AddWithValue("@fechainicio", fechainicio);
                cmd.Parameters.AddWithValue("@fechafin", fechafin);
                cmd.Parameters.AddWithValue("@idproveedor", idproveedor);
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
        public DataTable ReporteCarteraConta(string fechainicio, string fechafin)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    //,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("SET DATEFORMAT dmy");
                    sb.AppendLine("select convert(char(10), c.fecharegistro,103)[Fecha Compra],p.Documento[Documento Proveedor],p.RazonSocial[Razon Social Proveedor],");
                    sb.AppendLine("c.TipoDocumento[Tipo Documento],c.NumeroDocumento[Numero Documento], CONVERT(int, c.MontoTotal) as [Monto Total],");
                    sb.AppendLine("pr.Nombre[Nombre Producto],dv.Cantidad,CONVERT(int, dv.PrecioCompra)[Precio Compra],CONVERT(int, dv.PrecioVenta)[Precio Venta],");
                    sb.AppendLine("CONVERT(int, dv.Total)[Sub Total],c.idCompra ,dbo.f_calpago(c.NumeroDocumento) as pagos, dbo.f_calcularDevol(c.NumeroDocumento) as dev from COMPRA c");
                    sb.AppendLine("inner join PROVEEDOR p on p.idproveedor = c.idproveedor");
                    sb.AppendLine("inner join DETALLE_COMPRA dv on dv.idcompra = c.idcompra");
                    sb.AppendLine("inner join PRODUCTO pr on pr.IdProducto = dv.IdProducto");
                    sb.AppendLine("where convert(date,c.FechaRegistro) between @fechainicio and @fechafin");
                    //sb.AppendLine("and c.IdProveedor =  case @idproveedor when '0' then c.IdProveedor when 0 then c.IdProveedor else @idproveedor end");

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


    }
}

