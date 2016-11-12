﻿using System;
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
        TipoEventoClass TipoEvento = new TipoEventoClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            TipoEventoIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
        }

        private bool ObtenerDatos()
        {
            bool Retorno = true;
            int id;
            int.TryParse(TipoEventoIdTextBox.Text, out id);
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

        private void DevolverDatos()
        {
            TipoEventoIdTextBox.Text = TipoEvento.TipoEventoId.ToString();
            DescripcionTextBox.Text = TipoEvento.Descripcion.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (TipoEvento.UnicaDescripcion(DescripcionTextBox.Text))
            {
                Utilities.ShowToastr(this, "error", "Este tipo de evento ya existe!", "error");
                DescripcionTextBox.Text = string.Empty;
            }
            else
            {
                if (TipoEventoIdTextBox.Text.Length == 0)
                {
                    ObtenerDatos();
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
                    ObtenerDatos();
                    if (TipoEvento.Editar())
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
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatos();
                if (TipoEvento.Buscar(TipoEvento.TipoEventoId))
                {
                    if (TipoEvento.Eliminar())
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
            int id;
            int.TryParse(TipoEventoIdTextBox.Text, out id);
            if (id < 0)
            {
                Utilities.ShowToastr(this, "error", "Mensaje", "error");
            }
            else
            {
                if (TipoEvento.Buscar(id))
                {
                    DevolverDatos();
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }
    }
}