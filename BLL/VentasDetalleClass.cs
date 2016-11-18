using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;

namespace BLL
{
    public class VentasDetalleClass
    {
        public int Id { get; set; }
        public int VentaId { get; set; }

        public int EventoId { get; set; }
        public int Ticket { get; set; }
        public int Cantidad { get; set; }

        public VentasDetalleClass()
        {
            this.Id = 0;
            this.VentaId = 0;
            this.EventoId = 0;
            this.Ticket = 0;
            this.Cantidad = 0;
        }

        public VentasDetalleClass(int eventoid, int ticket, int cantidad)
        {
            this.EventoId = eventoid;
            this.Ticket = ticket;
            this.Cantidad = cantidad;
        }

        public DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string ordenFinal = "";
            if (!Orden.Equals(""))
                ordenFinal = " Orden by  " + Orden;
            return Conexion.ObtenerDatos("Select " + Campos + " From VentasDetalle Where " + Condicion + Orden);
        }
    }
}
