﻿using ProyectoPuntoVenta.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoPuntoVenta.Logica
{
    public class PersonaLogica
    {

        private static PersonaLogica instancia = null;
        Conexion Myconexion = new Conexion();

        public PersonaLogica()
        {

        }

        public static PersonaLogica Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new PersonaLogica();
                }

                return instancia;
            }
        }

        public int Registrar(Persona objeto)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarPersona", oConexion);
                    cmd.Parameters.AddWithValue("Documento", objeto.Documento);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", objeto.Telefono);
                    cmd.Parameters.AddWithValue("Clave", objeto.Clave);
                    cmd.Parameters.AddWithValue("Cupo", objeto.Cupo);
                    cmd.Parameters.AddWithValue("Username", objeto.Username);
                    cmd.Parameters.AddWithValue("IdTipoPersona", objeto.oTipoPersona.IdTipoPersona);
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
        public int RegistrarPago(pago objeto)
        {
            int respuesta = 0;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarPago", oConexion);
                    cmd.Parameters.AddWithValue("IdCompra", objeto.IdCompra);
                    cmd.Parameters.AddWithValue("IdPersona", objeto.IdPersona);
                    cmd.Parameters.AddWithValue("MontoTotal", objeto.MontoTotal);
                    cmd.Parameters.AddWithValue("Note", objeto.Note);
                    cmd.Parameters.AddWithValue("Idfactura", objeto.idFactura);
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

        public bool Modificar(Persona objeto)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("sp_ModificarPersona", oConexion);
                    cmd.Parameters.AddWithValue("IdPersona", objeto.IdPersona);
                    cmd.Parameters.AddWithValue("Documento", objeto.Documento);
                    cmd.Parameters.AddWithValue("Nombre", objeto.Nombre);
                    cmd.Parameters.AddWithValue("Direccion", objeto.Direccion);
                    cmd.Parameters.AddWithValue("Telefono", objeto.Telefono);
                    cmd.Parameters.AddWithValue("Clave", objeto.Clave);
                    cmd.Parameters.AddWithValue("Cupo", objeto.Cupo);
                    cmd.Parameters.AddWithValue("username", objeto.Username);
                    cmd.Parameters.AddWithValue("IdTipoPersona", objeto.oTipoPersona.IdTipoPersona);
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


        public List<Persona> Listar()
        {
            List<Persona> Lista = new List<Persona>();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    

                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("select p.IdPersona,p.Documento,p.Nombre,p.Direccion,p.Telefono,p.Clave,tp.IdTipoPersona,tp.Descripcion, p.Estado,p.Cupo,dbo.f_calDeuda(p.Documento) as Saldo,p.username as Username from persona p");
                    sb.AppendLine("inner join TIPO_PERSONA tp on tp.IdTipoPersona = p.IdTipoPersona");

                    SqlCommand cmd = new SqlCommand(sb.ToString(), oConexion);
                    cmd.CommandType = CommandType.Text;

                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Lista.Add(new Persona()
                            {
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                Documento = dr["Documento"].ToString(),
                                Nombre = dr["Nombre"].ToString(),
                                Direccion = dr["Direccion"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Clave = dr["Clave"].ToString(),
                                Cupo = dr["Cupo"].ToString(),
                                Saldo = dr["Saldo"].ToString(),
                                oTipoPersona = new TipoPersona() { IdTipoPersona = Convert.ToInt32(dr["IdTipoPersona"]), Descripcion = dr["Descripcion"].ToString() },
                                Estado = Convert.ToBoolean(dr["Estado"])
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    Lista = new List<Persona>();
                }
            }
            return Lista;
        }
        public DataTable Parametros()
        {
            DataTable dt = new DataTable();
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    sb.AppendLine("select *  from PARAMETROS");

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

        public bool Eliminar(int id)
        {
            bool respuesta = true;
            using (SqlConnection oConexion = new SqlConnection(Myconexion.CN))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("delete from persona where IdPersona = @id", oConexion);
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

    }
}
