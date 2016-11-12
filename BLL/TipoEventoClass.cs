using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class TipoEventoClass : ClaseMaestra
    {
        public int TipoEventoId { get; set; }
        public string Descripcion { get; set; }

        public TipoEventoClass()
        {
            this.TipoEventoId = 0;
            this.Descripcion = "";
        }

        public TipoEventoClass(int tipoeventoid, string descripcion)
        {
            this.TipoEventoId = tipoeventoid;
            this.Descripcion = descripcion;
        }

        public override bool Insertar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool retorno = false;
            try
            {
                Conexion.Ejecutar(String.Format("Insert into TipoEvento (Descripcion) Values ('{0}')", this.Descripcion));
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
                Conexion.Ejecutar(String.Format("Update TipoEvento set Descripcion='{0}' where TipoEventoId={1}", this.Descripcion, this.TipoEventoId));
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
                Conexion.Ejecutar(String.Format("Delete From TipoEvento where TipoEventoId = {0} ", this.TipoEventoId));
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
                dt = Conexion.ObtenerDatos("Select * from TipoEvento Where TipoEventoId=" + IdBuscado);
                if (dt.Rows.Count > 0)
                {
                    this.TipoEventoId = (int)dt.Rows[0]["TipoEventoId"];
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
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
            return Conexion.ObtenerDatos(("Select " + Campos + " from TipoEvento where " + Condicion + ordenar));
        }

        public bool UnicaDescripcion(string UnicaDescrip)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from TipoEvento where Descripcion= '" + UnicaDescrip + "'"));
                if (dt.Rows.Count > 0)
                {
                    this.TipoEventoId = (int)dt.Rows[0]["TipoEventoId"];
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }
    }
}