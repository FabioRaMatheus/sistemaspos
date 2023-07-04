using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace ProyectoPuntoVenta.Logica
{
    public class ProductoLogica
    {

        private static ProductoLogica instancia = null;
        Conexion Myconexion = new Conexion(); 
        public ProductoLogica()
        {

        }

        public static ProductoLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ProductoLogica();
                }

                return instancia;
            }
        }


        public int Registrar(Producto objeto)
        {
            int respuesta = 0;
            
            using ( var oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarProducto", oConexion);
                    cmd.Parameters.AddWithValue("Codigo", objeto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", objeto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", objeto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("PrecioVenta", objeto.PrecioVenta);
                    cmd.Parameters.AddWithValue("Pesado", objeto.Pesado);
                    cmd.Parameters.AddWithValue("Stock", objeto.Stock);
                    cmd.Parameters.AddWithValue("Promocion", objeto.Promocion);
                    cmd.Parameters.AddWithValue("Iva", objeto.iva);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }
        public int copySeguriddad()
        {
            int respuesta = 0;

            using (var oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_copiaseguridad", oConexion);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    return respuesta;
                    

                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }
        public int configPantalla(string tipo)
        {
            int respuesta = 0;

            using (var oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_configPantalla", oConexion);
                    oConexion.Open();
                    respuesta = cmd.ExecuteNonQuery();
                    return respuesta;


                }
                catch (Exception ex)
                {
                    respuesta = 0;
                }
            }
            return respuesta;
        }

        public bool Modificar(Producto objeto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarProducto", oConexion);
                    cmd.Parameters.AddWithValue("IdProducto", objeto.IdProducto);
                    cmd.Parameters.AddWithValue("Codigo", objeto.Codigo);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Descripcion", objeto.Descripcion);
                    cmd.Parameters.AddWithValue("IdCategoria", objeto.oCategoria.IdCategoria);
                    cmd.Parameters.AddWithValue("PrecioVenta", objeto.PrecioVenta);
                    cmd.Parameters.AddWithValue("Stock", objeto.Stock);
                    cmd.Parameters.AddWithValue("Pesado", objeto.Pesado);
                    cmd.Parameters.AddWithValue("Promocion", objeto.Promocion);
                    cmd.Parameters.AddWithValue("Iva", objeto.iva);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    cmd.CommandType = CommandType.StoredProcedure;

                    oConexion.Open();

                    cmd.ExecuteNonQuery();

                    respuesta = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);

                }
                catch (Exception ex)
                {
                    respuesta = false;
                }

            }

            return respuesta;

        }
        public DataSet facElectronica()
        {
            DataSet dtFactura = new DataSet();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    oConexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_FacturaElectronica", oConexion);
                     cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtFactura);
                    oConexion.Close();
                  }
                catch (Exception ex)
                {
                    return dtFactura;
                }

            }

            return dtFactura;

        }
        public DataSet facElectronicaDetalle(string numFactura)
        {
            DataSet dtFactura = new DataSet();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    oConexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_FacturaElectronicaDetalle", oConexion);
                    cmd.Parameters.AddWithValue("@IdFactura", numFactura);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dtFactura);
                    oConexion.Close();
                }
                catch (Exception ex)
                {
                    return dtFactura;
                }

            }

            return dtFactura;

        }
        public List<Venta> ListarVentas(string numdoc)
        {
            List<Venta> Lista = new List<Venta>();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select idVenta,NumeroDocumento,PagoCon,TotalPagar,FechaRegistro,case TipoVenta when 'C' then 'Compra' else 'Pago' end  as TipoVenta,Cambio from venta");
                    sb.AppendLine(" where DocumentoCliente=" + "'"+numdoc.ToString() + "'");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Venta()
                            {
                                FechaRegistro = dr["FechaRegistro"].ToString(),
                                IdVenta = Convert.ToInt32(dr["idVenta"]),
                                NumeroDocumento = dr["NumeroDocumento"].ToString(),
                                PagoCon = Convert.ToDecimal(dr["PagoCon"].ToString()),
                                TotalPagar = Convert.ToDecimal(dr["TotalPagar"].ToString()),
                                TipoVenta = dr["TipoVenta"].ToString(),
                                Cambio = Convert.ToDecimal(dr["Cambio"].ToString())

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

        public List<Producto> Listar()
        {
            List<Producto> Lista = new List<Producto>();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    
                    sb.AppendLine("select p.IdProducto,p.Codigo,p.Nombre,p.Descripcion,p.IdCategoria,c.Descripcion[DesCategoria],p.Stock,p.PrecioCompra,p.PrecioVenta,p.pesado,p.Promocion,p.iva from Producto p");
                    sb.AppendLine("inner join categoria c on c.IdCategoria = p.IdCategoria");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Codigo = dr["Codigo"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCategoria = new Categoria() { IdCategoria = Convert.ToInt32(dr["IdCategoria"]),Descripcion = dr["DesCategoria"].ToString()},
                                Stock = Convert.ToInt32(dr["Stock"]),
                                Pesado = dr["Pesado"].ToString(),
                                Promocion = dr["promocion"].ToString(),
                                iva = Convert.ToInt32(dr["iva"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"],new CultureInfo("es-PE")),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"],new CultureInfo("es-PE"))
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Producto>();
                }
            }
            return Lista;
        }
        public DataTable ListarExport()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select p.IdProducto,p.Codigo,p.Nombre,p.Descripcion,p.IdCategoria,c.Descripcion[DesCategoria],p.Stock,p.PrecioCompra,p.PrecioVenta,p.pesado,p.iva from Producto p");
                    sb.AppendLine("inner join categoria c on c.IdCategoria = p.IdCategoria");

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
        public List<Devolucion> ListarFacturaDev(string Numfactura, string NumPro)
        {
            List<Devolucion> Lista = new List<Devolucion>();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select P.IdProducto  as id,C.idproveedor,C.NumeroDocumento ");
                    sb.AppendLine(", D.IdCompra, D.IdProducto, P.Descripcion, D.Cantidad, D.PrecioCompra, D.PrecioVenta,P.iva from DETALLE_COMPRA D ");
                    sb.AppendLine("      INNER JOIN PRODUCTO P ");
                    sb.AppendLine(" ON D.IdProducto = P.IdProducto ");
                    sb.AppendLine(" INNER JOIN COMPRA C ON D.IdCompra = C.IdCompra");
                    sb.AppendLine(" where  C.idproveedor=" + NumPro.ToString());
                    sb.AppendLine(" and  C.NumeroDocumento=" + Numfactura.ToString());
                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Devolucion()
                            {
                                idproveedor = Convert.ToInt32(dr["id"]),
                                NumeroDocumento = Convert.ToInt16(dr["NumeroDocumento"].ToString()),
                                IdCompra = Convert.ToInt16(dr["IdCompra"].ToString()),
                                Descripcion = dr["Descripcion"].ToString(),
                                IdProducto = Convert.ToInt16(dr["IdProducto"].ToString()),
                                Cantidad = Convert.ToInt16(dr["Cantidad"].ToString()),
                                PrecioCompra = Convert.ToDecimal(dr["PrecioCompra"]),
                                PrecioVenta = Convert.ToDecimal(dr["PrecioVenta"])
                            });
                        }
                    }

                }
                catch (Exception ex)
                {

                    Lista = new List<Devolucion>();
                }
            }
            return Lista;
        }

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from Producto where IdProducto = @id", oConexion);
                    cmd.Parameters.AddWithValue("@id", id);
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

        public DataTable Reporte(string idcategoria)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select convert(char(10), p.FechaCreacion,103)[Fecha Registro], p.Codigo,p.Nombre,p.Descripcion,c.Descripcion[Categoria],p.Stock,");
                    sb.AppendLine("CONVERT(varchar, p.PrecioCompra)[Precio Compra],CONVERT(varchar, p.PrecioVenta)[Precio Venta],P.iva from producto p");
                    sb.AppendLine("inner join CATEGORIA c on c.IdCategoria = p.IdCategoria");
                    sb.AppendLine("where c.IdCategoria = case @idcategoria when '0' then c.IdCategoria when 0 then c.IdCategoria else @idcategoria end");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.Parameters.AddWithValue("@idcategoria", idcategoria);
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
        public DataTable ReportePagosFact(string idcategoria)
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select convert(char(10), p.FechaRegistro,103)[Fecha Registro], p.idFactura, convert(int,p.MontoTotal) as MontoTotal,p.Note,p.IdPersona,e.Nombre ");
                    sb.AppendLine(" from COMPRA_pagos p");
                    sb.AppendLine(" inner join  PERSONA e on p.IdPersona=e.IdPersona");
                    sb.AppendLine("where p.idFactura="+ idcategoria.ToString());

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


    }
}
