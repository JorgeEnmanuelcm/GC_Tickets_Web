using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class UsuariosClass : ClaseMaestra
    {
        public int UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int TipoUsuario { get; set; }

        public UsuariosClass()
        {
            this.UsuarioId = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Telefono = "";
            this.Email = "";
            this.Direccion = "";
            this.NombreUsuario = "";
            this.Contrasenia = "";
            this.TipoUsuario = 0;
        }

        public UsuariosClass(int usuarioid, string nombres, string apellidos, string telefono, string email, string direccion, string nombreusuario, string contrasenia)
        {
            this.UsuarioId = usuarioid;
            this.Nombres = nombres;
            this.Apellidos = apellidos;
            this.Telefono = telefono;
            this.Email = email;
            this.Direccion = direccion;
            this.NombreUsuario = nombreusuario;
            this.Contrasenia = contrasenia;
        }

        public static int Enteros(string NumeroEntero)
        {
            int numero;
            int.TryParse(NumeroEntero, out numero);
            return numero;
        }

        public override bool Insertar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool retorno = false;
            try
            {
                Conexion.Ejecutar(String.Format("Insert Into Usuarios(Nombres, Apellidos, Telefono, Email, Direccion, NombreUsuario, Contrasenia, TipoUsuario) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}',{7})", this.Nombres, this.Apellidos, this.Telefono, this.Email, this.Direccion, this.NombreUsuario, this.Contrasenia, this.TipoUsuario));
                retorno = true;
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Editar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool retorno = false;
            try
            {
                Conexion.Ejecutar(String.Format("Update Usuarios set Nombres='{0}', Apellidos='{1}', Telefono='{2}', Email='{3}', Direccion='{4}', NombreUsuario='{5}', Contrasenia='{6}' where UsuarioId={7}", this.Nombres, this.Apellidos, this.Telefono, this.Email, this.Direccion, this.NombreUsuario, this.Contrasenia, this.UsuarioId));
                retorno = true;
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Eliminar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool retorno = false;
            try
            {
                Conexion.Ejecutar(String.Format("Delete From Usuarios where UsuarioId={0}", this.UsuarioId));
                retorno = true;
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos("Select * from Usuarios Where UsuarioId=" + IdBuscado);
                if (dt.Rows.Count > 0)
                {
                    this.UsuarioId = Enteros(dt.Rows[0]["UsuarioId"].ToString());
                    this.Nombres = dt.Rows[0]["Nombres"].ToString();
                    this.Apellidos = dt.Rows[0]["Apellidos"].ToString();
                    this.Telefono = dt.Rows[0]["Telefono"].ToString();
                    this.Email = dt.Rows[0]["Email"].ToString();
                    this.Direccion = dt.Rows[0]["Direccion"].ToString();
                    this.NombreUsuario = dt.Rows[0]["NombreUsuario"].ToString();
                    this.Contrasenia = dt.Rows[0]["Contrasenia"].ToString();
                }
            }
            catch (Exception ex) { throw ex; }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string ordenar = "";
            if (!Orden.Equals(""))
                ordenar = " orden by  " + Orden;
            return Conexion.ObtenerDatos(("Select " + Campos + " from Usuarios where " + Condicion + ordenar));
        }


        public static DataTable ListadoDt(string Condicion)
        {
            ConexionDB Conexion = new ConexionDB();
            return Conexion.ObtenerDatos(string.Format("select * from Usuarios where " + Condicion));
        }
    }


}