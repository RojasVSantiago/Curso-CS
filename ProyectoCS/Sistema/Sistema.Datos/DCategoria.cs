﻿using Sistema.Entidades;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Sistema.Datos
{
    public class DCategoria
    {
        public DataTable Listar()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_listar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado =  comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close(); 
            }
        }

        public DataTable Buscar(string val) 
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_buscar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = val;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        public DataTable Seleccionar()
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_seleccionar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }

        public string Existe(string val)
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_existe", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@valor", SqlDbType.VarChar).Value = val;
                SqlParameter parExiste = new SqlParameter();
                parExiste.ParameterName = "@existe";
                parExiste.SqlDbType= SqlDbType.Int;
                parExiste.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parExiste);
                sqlCon.Open();
                comando.ExecuteNonQuery();
                respuesta = Convert.ToString(parExiste.Value);
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }

        public string Insertar (Categoria obj) 
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_insertar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el resgistro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }

        public string Actualizar (Categoria obj) 
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_actualizar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = obj.idCategoria;
                comando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = obj.nombre;
                comando.Parameters.Add("@descripcion", SqlDbType.VarChar).Value = obj.descripcion;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el resgistro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }

        public string Eliminar (int id) 
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_eliminar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el resgistro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }

        public string Activar (int id) 
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_activar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el resgistro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }

        public string Desactivar(int id) 
        {
            string respuesta = "";
            SqlConnection sqlCon = new SqlConnection();
            try
            {
                sqlCon = Conexion.getInstancia().crearConexion();
                SqlCommand comando = new SqlCommand("categoria_desactivar", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idcategoria", SqlDbType.Int).Value = id;
                sqlCon.Open();
                respuesta = comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el resgistro";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
            return respuesta;
        }
    }
}
