using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace GC_Tickets_Web.Registros
{
    public partial class VentasForm : System.Web.UI.Page
    {       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CargarDropDownList();
                CargarGridview();
                VentasClass Venta = new VentasClass();
                int Id = 0;
                if (Request.QueryString["ID"] != null)
                {
                    Id = Utilities.intConvertir(Request.QueryString["ID"].ToString());
                    if (Venta.Buscar(Id))
                    {
                        if (VentasGridView.Rows.Count == 0)
                        {
                            DevolverDatos(Venta);
                        }
                    }
                }
            }
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = string.Empty;
            FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            TotalTextBox.Text = string.Empty;
            VentasGridView.DataSource = string.Empty;
            VentasGridView.DataBind();
        }

        private void CargarGridview()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("EventoId"), new DataColumn("Ticket"), new DataColumn("Cantidad") });
            ViewState["VentasClass"] = dt;
        }

        private void CargarDropDownList()
        {
            UsuariosClass Usuario = new UsuariosClass();
            UsuarioIdDropDownList.DataSource = Usuario.Listado(" * ", "1=1", "");
            UsuarioIdDropDownList.DataTextField = "NombreUsuario";
            UsuarioIdDropDownList.DataValueField = "UsuarioId";
            UsuarioIdDropDownList.DataBind();

            EventosClass Evento = new EventosClass();
            EventoDropDownList.DataSource = Evento.Listado(" * ", "1=1", "");
            EventoDropDownList.DataTextField = "NombreEvento";
            EventoDropDownList.DataValueField = "EventoId";
            EventoDropDownList.DataBind();

            EventosDetalleClass Ticket = new EventosDetalleClass();
            TicketDropDownList.DataSource = Ticket.Listado(" * ", "1=1", "");
            TicketDropDownList.DataTextField = "DescTicket";
            TicketDropDownList.DataValueField = "PrecioTicket";
            TicketDropDownList.DataBind();
        }

        private bool ObtenerDatos(VentasClass Venta)
        {
            bool Retorno = true;        
            int Usuario = Utilities.intConvertir(UsuarioIdDropDownList.SelectedValue);
            int id = Utilities.intConvertir(VentaIdTextBox.Text);
            if (id > 0)
            {
                Venta.VentaId = id;
            }
            else
            {
                Retorno = false;
            }
            if (Usuario > 0)
            {
                Venta.UsuarioId = Usuario;
            }
            else
            {
                Retorno = false;
            }
            if (FechaTextBox.Text.Length > 0)
            {
                Venta.Fecha = FechaTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (DescripcionTextBox.Text.Length > 0)
            {
                Venta.Descripcion = DescripcionTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (TotalTextBox.Text.Length > 0)
            {
                Venta.Total = Utilities.intConvertir(TotalTextBox.Text);
            }
            else
            {
                Retorno = false;
            }
            if (VentasGridView.Rows.Count > 0)
            {
                foreach (GridViewRow var in VentasGridView.Rows)
                {
                    Venta.AgregarVenta(Convert.ToInt32(var.Cells[0].Text), Convert.ToInt32(var.Cells[1].Text), Convert.ToInt32(var.Cells[2].Text));
                }
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        public void DevolverDatos(VentasClass Venta)
        {
            DataTable dt = new DataTable();
            VentaIdTextBox.Text = Venta.VentaId.ToString();
            UsuarioIdDropDownList.SelectedValue = Venta.UsuarioId.ToString();
            FechaTextBox.Text = Venta.Fecha.ToString();
            DescripcionTextBox.Text = Venta.Descripcion.ToString();
            TotalTextBox.Text = Venta.Total.ToString();
            foreach (var item in Venta.Detalle)
            {
                dt = (DataTable)ViewState["VentasClass"];
                dt.Rows.Add(item.EventoId, item.Ticket, item.Cantidad);
                ViewState["VentasClass"] = dt;
                VentasGridView.DataSource = (DataTable)ViewState["VentasClass"];
                VentasGridView.DataBind();
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            int precio = Utilities.intConvertir(TicketDropDownList.SelectedValue);
            int cantidad = Utilities.intConvertir(CantidadTextBox.Text);
            int total = Utilities.intConvertir(TotalTextBox.Text);
            DataTable dt = (DataTable)ViewState["VentasClass"];
            dt.Rows.Add(EventoDropDownList.SelectedValue, TicketDropDownList.SelectedValue, CantidadTextBox.Text);
            ViewState["VentasClass"] = dt;
            VentasGridView.DataSource = dt;
            VentasGridView.DataBind();
            CantidadTextBox.Text = string.Empty;
            TotalTextBox.Text = (total + (cantidad * precio)).ToString();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            VentasClass Venta = new VentasClass();
            if (VentaIdTextBox.Text.Length == 0)
            {
                ObtenerDatos(Venta);
                if (Venta.Insertar())
                {
                    Limpiar();
                    Utilities.ShowToastr(this, "bien", "Se guardo con exito!", "success");
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
            if (VentaIdTextBox.Text.Length > 0)
            {
                ObtenerDatos(Venta);
                if (Venta.Editar())
                {
                    Limpiar();
                    Utilities.ShowToastr(this, "bien", "Se modifico con exito!", "success");
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            VentasClass Venta = new VentasClass();
            try
            {
                ObtenerDatos(Venta);
                if (Venta.Buscar(Venta.VentaId))
                {
                    if (Venta.Eliminar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se elimino con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
            }
            catch (Exception)
            {
                Utilities.ShowToastr(this, "error", "Mensaje", "error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Consultas/VentasCForm.aspx");
        }
    }
}