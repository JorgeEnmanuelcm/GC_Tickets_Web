using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class VentasClass : ClaseMaestra
    {
        public int VentaId { get; set; }
        public int UsuarioId { get; set; }
        public string Fecha { get; set; }
        public string Descripcion { get; set; }
        public int Total { get; set; }
        public List<VentasDetalleClass> Detalle { get; set; }

        public VentasClass()
        {
            this.VentaId = 0;
            this.UsuarioId = 0;
            this.Fecha = "";
            this.Descripcion = "";
            this.Total = 0;
            this.Detalle = new List<VentasDetalleClass>();
        }

        public VentasClass(int ventaid)
        {
            this.VentaId = ventaid;    
        }

        public void AgregarVenta(int EventoId, int Ticket, int Cantidad)
        {
            this.Detalle.Add(new VentasDetalleClass(EventoId, Ticket, Cantidad));
        }

        public override bool Insertar()
        {
            ConexionDB Conexion = new ConexionDB();
            int Retorno = 0;
            object Identity;
            try
            {
                Identity = Conexion.ObtenerValor(String.Format("Insert Into Ventas(UsuarioId, Fecha, Descripcion, Total) values({0}, '{1}', '{2}', {3}) select SCOPE_IDENTITY()", this.UsuarioId, this.Fecha, this.Descripcion, this.Total));
                Retorno = Utilities.intConvertir(Identity.ToString());
                this.VentaId = Retorno;
                if (Retorno > 0)
                {
                    foreach (VentasDetalleClass var in Detalle)
                    {
                        Conexion.Ejecutar(String.Format("Insert into VentasDetalle(VentaId, EventoId, Ticket, Cantidad) Values ({0}, {1}, {2}, {3})", this.VentaId, var.EventoId, var.Ticket, var.Cantidad));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno > 0;
        }

        public override bool Editar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Update Ventas set UsuarioId={0}, Fecha='{1}', Descripcion='{2}', Total={3} where VentaId= {4}", this.UsuarioId, this.Fecha, this.Descripcion, this.Total, this.VentaId));
                if (Retorno)
                {
                    Conexion.Ejecutar(String.Format("Delete from VentasDetalle Where VentaId= {0}", this.VentaId));
                    foreach (VentasDetalleClass var in this.Detalle)
                    {
                        Conexion.Ejecutar(string.Format("Insert into VentasDetalle(VentaId, EventoId, Ticket, Cantidad) Values ({0}, {1}, {2}, {3})", this.VentaId, var.EventoId, var.Ticket, var.Cantidad));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }

        public override bool Eliminar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Delete from VentasDetalle Where VentaId= {0};" + "Delete from Ventas where VentaId= {0}", this.VentaId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            DataTable dtEventDetalle = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(String.Format("select * from Ventas where VentaId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.VentaId = (int)dt.Rows[0]["VentaId"];
                    this.UsuarioId = (int)dt.Rows[0]["UsuarioId"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Total = (int)dt.Rows[0]["Total"];
                    dtEventDetalle = Conexion.ObtenerDatos(String.Format("select * from VentasDetalle where VentaId=" + IdBuscado));
                    dtEventDetalle.Clear();
                    foreach (DataRow row in dtEventDetalle.Rows)
                    {
                        AgregarVenta((int)dtEventDetalle.Rows[0]["EventoId"], (int)dtEventDetalle.Rows[0]["Ticket"], (int)dtEventDetalle.Rows[0]["Cantidad"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = " Order by " + Orden;
            return Conexion.ObtenerDatos("Select " + Campos + "From Ventas where " + Condicion + " " + OrdenFinal);
        }
    }
}
