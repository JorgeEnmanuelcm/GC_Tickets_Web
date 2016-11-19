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
    public partial class EventosForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDropDownList();
                CargarGridView();
                EliminarButton.Enabled = false;
                EventosClass Evento = new EventosClass();
                int Id = 0;
                if (Request.QueryString["ID"] != null)
                {
                    Id = Utilities.intConvertir(Request.QueryString["ID"].ToString());
                    if (Evento.Buscar(Id))
                    {
                        if (EventosGridView.Rows.Count == 0)
                        {
                            DevolverDatos(Evento);
                        }
                    }
                }
            }
        }

        private void Limpiar()
        {
            EventoIdTextBox.Text = string.Empty;
            TipoEventoIdDropDownList.ClearSelection();
            NombreEventoTextBox.Text = string.Empty;
            FechaEventoTextBox.Text = string.Empty;
            LugarEventoTextBox.Text = string.Empty;
            DescTicketTextBox.Text = string.Empty;
            CantDisponibleTextBox.Text = string.Empty;
            PrecioTicketTextBox.Text = string.Empty;
            Imagen.ImageUrl = "/Flayers/imagen.jpg";
            EventosGridView.DataSource = string.Empty;
            EventosGridView.DataBind();
        }

        private void CargarGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("DescTicket"), new DataColumn("CantDisponible"), new DataColumn("PrecioTicket") });
            ViewState["EventosClass"] = dt;
        }

        private void CargarDropDownList()
        {
            TipoEventoClass Tipo = new TipoEventoClass();
            TipoEventoIdDropDownList.DataSource = Tipo.Listado(" * ", "1=1", "");
            TipoEventoIdDropDownList.DataTextField = "Descripcion";
            TipoEventoIdDropDownList.DataValueField = "TipoEventoId";
            TipoEventoIdDropDownList.DataBind();
        }

        private bool ObtenerDatos(EventosClass Evento)
        {
            bool Retorno = true;
            int id = Utilities.intConvertir(EventoIdTextBox.Text);
            int tipoEventoid = Utilities.intConvertir(TipoEventoIdDropDownList.SelectedValue);
            if (id > 0)
            {
                Evento.EventoId = id;
            }
            else
            {
                Retorno = false;
            }
            if (tipoEventoid > 0)
            {
                Evento.TipoEventoId = tipoEventoid;
            }
            else
            {
                Retorno = false;
            }
            if (NombreEventoTextBox.Text.Length > 0)
            {
                Evento.NombreEvento = NombreEventoTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (FechaEventoTextBox.Text.Length > 0)
            {
                Evento.FechaEvento = FechaEventoTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (LugarEventoTextBox.Text.Length > 0)
            {
                Evento.LugarEvento = LugarEventoTextBox.Text;
                Evento.Imagen = Imagen.ImageUrl;
            }
            else
            {
                Retorno = false;
            }
            if (EventosGridView.Rows.Count > 0)
            {
                foreach (GridViewRow var in EventosGridView.Rows)
                {
                    Evento.AgregarTickets(var.Cells[0].Text, Convert.ToInt32(var.Cells[1].Text), Convert.ToInt32(var.Cells[2].Text));
                }
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        public void DevolverDatos(EventosClass Evento)
        {
            DataTable dt = new DataTable();
            EventoIdTextBox.Text = Evento.EventoId.ToString();
            NombreEventoTextBox.Text = Evento.NombreEvento.ToString();
            FechaEventoTextBox.Text = Evento.FechaEvento.ToString();
            LugarEventoTextBox.Text = Evento.LugarEvento.ToString();
            Imagen.ImageUrl = Evento.Imagen;
            foreach (var item in Evento.Detalle)
            {
                dt = (DataTable)ViewState["EventosClass"];
                dt.Rows.Add(item.DescTicket, item.CantDisponible, item.PrecioTicket);
                ViewState["EventosClass"] = dt;
                EventosGridView.DataSource = (DataTable)ViewState["EventosClass"];
                EventosGridView.DataBind();
            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            EliminarButton.Enabled = false;
            GuardarButton.Text = "Guardar";
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["EventosClass"];
            dt.Rows.Add(DescTicketTextBox.Text, CantDisponibleTextBox.Text, PrecioTicketTextBox.Text);
            ViewState["EventosClass"] = dt;
            EventosGridView.DataSource = dt;
            EventosGridView.DataBind();
            CantDisponibleTextBox.Text = string.Empty;
            PrecioTicketTextBox.Text = string.Empty;
            EventosGridView.DataSource = string.Empty;
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            EventosClass Evento = new EventosClass();
            if (Evento.UnicoEvento(NombreEventoTextBox.Text))
            {
                Utilities.ShowToastr(this, "error", "Ese evento ya existe!", "error");
                NombreEventoTextBox.Text = string.Empty;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(EventoIdTextBox.Text))
                {
                    ObtenerDatos(Evento);
                    if (Evento.Insertar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se guardo con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
                if (EventoIdTextBox.Text.Length > 0)
                {
                    ObtenerDatos(Evento);
                    if (Evento.Editar())
                    {
                        Limpiar();
                        EliminarButton.Enabled = false;
                        GuardarButton.Text = "Guardar";
                        Utilities.ShowToastr(this, "bien", "Se modifico con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            EventosClass Evento = new EventosClass();
            try
            {
                ObtenerDatos(Evento);
                if (Evento.Buscar(Evento.EventoId))
                {
                    if (Evento.Eliminar())
                    {
                        Limpiar();
                        EliminarButton.Enabled = false;
                        GuardarButton.Text = "Guardar";
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
            EventosClass Evento = new EventosClass();
            int id = Utilities.intConvertir(EventoIdTextBox.Text);
            if (id < 0)
            {
                Utilities.ShowToastr(this, "error", "Mensaje", "error");
            }
            else
            {
                if (Evento.Buscar(id))
                {
                    EliminarButton.Enabled = true;
                    GuardarButton.Text = "Modificar";
                    DevolverDatos(Evento);
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }

        protected void ImagenButton_Click(object sender, EventArgs e)
        {
            EventosClass Evento = new EventosClass();
            Evento.Imagen = "/Flayers/" + ImagenFileUpload.FileName;
            ImagenFileUpload.SaveAs(Server.MapPath("/Flayers/" + ImagenFileUpload.FileName));
            if (ImagenFileUpload.HasFile)
            {
                Imagen.ImageUrl = "/Flayers/" + ImagenFileUpload.FileName;
            }
        }
    }
}