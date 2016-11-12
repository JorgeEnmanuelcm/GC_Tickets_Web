using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class EventosClass : ClaseMaestra
    {
        public int EventoId { get; set; }
        public int TipoEventoId { get; set; }
        public string NombreEvento { get; set; }
        public string FechaEvento { get; set; }
        public string LugarEvento { get; set; }
        public List<EventosDetalleClass> Detalle { get; set; }

        public EventosClass()
        {
            this.EventoId = 0;
            this.TipoEventoId = 0;
            this.NombreEvento = "";
            this.FechaEvento = "";
            this.LugarEvento = "";
            this.Detalle = new List<EventosDetalleClass>();
        }

        public EventosClass(int eventoid)
        {
            EventoId = eventoid;
        }

        public void AgregarTickets(string DescTicket, int CantDisponible, int PrecioTicket)
        {
            this.Detalle.Add(new EventosDetalleClass(DescTicket, CantDisponible, PrecioTicket));
        }

        public override bool Insertar()
        {
            ConexionDB Conexion = new ConexionDB();
            int Retorno = 0;
            object Identity;
            try
            {
                Identity = Conexion.ObtenerValor(String.Format("Insert Into Eventos(TipoEventoId, NombreEvento, FechaEvento, LugarEvento) values({0}, '{1}', '{2}', '{3}') select @@IDENTITY", this.TipoEventoId, this.NombreEvento, this.FechaEvento, this.LugarEvento));
                int.TryParse(Identity.ToString(), out Retorno);
                this.EventoId = Retorno;
                if (Retorno > 0)
                {
                    foreach (EventosDetalleClass var in Detalle)
                    {
                        Conexion.Ejecutar(String.Format("Insert into EventosDetalle(EventoId, DescTicket, CantDisponible, PrecioTicket) Values ({0}, '{1}', {2}, {3})", this.EventoId, var.DescTicket, var.CantDisponible, var.PrecioTicket));
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
                Retorno = Conexion.Ejecutar(String.Format("Update Eventos set TipoEventoId={0}, NombreEvento='{1}', FechaEvento='{2}', LugarEvento='{3}' where EventoId= {4}", this.TipoEventoId, this.NombreEvento, this.FechaEvento, this.LugarEvento, this.EventoId));
                if (Retorno)
                {
                    Conexion.Ejecutar(String.Format("Delete from EventosDetalle Where EventoId= {0}", this.EventoId));
                    foreach (EventosDetalleClass var in this.Detalle)
                    {
                        Conexion.Ejecutar(string.Format("Insert into EventosDetalle(EventoId, DescTicket, CantDisponible, PrecioTicket) Values ({0},'{1}',{2},{3})", this.EventoId, var.DescTicket, var.CantDisponible, var.PrecioTicket));
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
                Retorno = Conexion.Ejecutar(String.Format("Delete from EventosDetalle Where EventoId= {0};" + "Delete from Eventos where EventoId= {0}", this.EventoId));
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
                dt = Conexion.ObtenerDatos(String.Format("select * from Eventos where EventoId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.EventoId = (int)dt.Rows[0]["EventoId"];
                    this.NombreEvento = dt.Rows[0]["NombreEvento"].ToString();
                    this.FechaEvento = dt.Rows[0]["FechaEvento"].ToString();
                    this.LugarEvento = dt.Rows[0]["LugarEvento"].ToString();
                    dtEventDetalle = Conexion.ObtenerDatos(String.Format("select * from EventosDetalle where EventoId=" + IdBuscado));
                    dtEventDetalle.Clear();
                    foreach (DataRow row in dtEventDetalle.Rows)
                    {
                        AgregarTickets(row["DescTicket"].ToString(), (int)dtEventDetalle.Rows[0]["CantDisponible"], (int)dtEventDetalle.Rows[0]["PrecioTicket"]);
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
            return Conexion.ObtenerDatos("Select " + Campos + "From Eventos where " + Condicion + " " + OrdenFinal);
        }

        public bool UnicoEvento(string UnicoNom)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(string.Format("select * from Eventos where NombreEvento= '" + UnicoNom + "'"));
                if (dt.Rows.Count > 0)
                {
                    this.EventoId = (int)dt.Rows[0]["EventoId"];
                    this.NombreEvento = dt.Rows[0]["NombreEvento"].ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public DataTable Dat()
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            dt = Conexion.ObtenerDatos("select NombreEvento, FechaEvento, LugarEvento from Eventos");
            return dt;
        }
    }
}
