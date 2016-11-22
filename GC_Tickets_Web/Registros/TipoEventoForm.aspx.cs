using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GC_Tickets_Web.Registros
{
    public partial class TipoEventoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EliminarButton.Visible = false;
        }

        private void Limpiar()
        {
            TipoEventoIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
        }

        private bool ObtenerDatos(TipoEventoClass TipoEvento)
        {
            bool Retorno = true;
            int id = Utilities.intConvertir(TipoEventoIdTextBox.Text);           
            if (id > 0)
            {
                TipoEvento.TipoEventoId = id;
            }
            else
            {
                Retorno = false;
            }
            if (DescripcionTextBox.Text.Length > 0)
            {
                TipoEvento.Descripcion = DescripcionTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        private void DevolverDatos(TipoEventoClass TipoEvento)
        {
            TipoEventoIdTextBox.Text = TipoEvento.TipoEventoId.ToString();
            DescripcionTextBox.Text = TipoEvento.Descripcion.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
            EliminarButton.Visible = false;
            GuardarButton.Text = "Guardar";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            TipoEventoClass TipoEvento = new TipoEventoClass();
            if (TipoEvento.UnicaDescripcion(DescripcionTextBox.Text))
            {
                Utilities.ShowToastr(this, "error", "Ese tipo de evento ya existe!", "error");
                DescripcionTextBox.Text = string.Empty;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(TipoEventoIdTextBox.Text))
                {
                    ObtenerDatos(TipoEvento);
                    if (TipoEvento.Insertar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se guardo con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
                if (TipoEventoIdTextBox.Text.Length > 0)
                {
                    ObtenerDatos(TipoEvento);
                    if (TipoEvento.Editar())
                    {
                        Limpiar();
                        EliminarButton.Visible = false;
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
            TipoEventoClass TipoEvento = new TipoEventoClass();
            try
            {
                ObtenerDatos(TipoEvento);
                if (TipoEvento.Buscar(TipoEvento.TipoEventoId))
                {
                    if (TipoEvento.Eliminar())
                    {
                        Limpiar();
                        EliminarButton.Visible = false;
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
            TipoEventoClass TipoEvento = new TipoEventoClass();
            int id = Utilities.intConvertir(TipoEventoIdTextBox.Text);
            if (id < 0)
            {
                Utilities.ShowToastr(this, "error", "Mensaje", "error");
            }
            else
            {
                if (TipoEvento.Buscar(id))
                {
                    EliminarButton.Visible = true;
                    GuardarButton.Text = "Modificar";
                    DevolverDatos(TipoEvento);
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }
    }
}