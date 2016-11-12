using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using System.Data;

namespace BLL
{
    public class EventosDetalleClass
    {
        public int Id { get; set; }
        public int EventoId { get; set; }
        public string DescTicket { get; set; }
        public int CantDisponible { get; set; }
        public int PrecioTicket { get; set; }

        public EventosDetalleClass()
        {
            this.Id = 0;
            this.EventoId = 0;
            this.DescTicket = "";
            this.CantDisponible = 0;
            this.PrecioTicket = 0;
        }

        public EventosDetalleClass(string descripcion, int cantidad, int precio)
        {
            this.DescTicket = descripcion;
            this.CantDisponible = cantidad;
            this.PrecioTicket = precio;
        }

        public DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by  " + Orden;
            return Conexion.ObtenerDatos("Select " + Campos + " From EventosDetalle Where " + Condicion + Orden);
        }
    }
}