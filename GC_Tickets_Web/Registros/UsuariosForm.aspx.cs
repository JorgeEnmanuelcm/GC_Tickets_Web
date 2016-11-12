using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GC_Tickets_Web.Registros
{
    public partial class UsuariosForm : System.Web.UI.Page
    {
        UsuariosClass Usuario = new UsuariosClass(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        private void Limpiar()
        {
            UsuarioIdTextBox.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            NombreUsuarioTextBox.Text = string.Empty;
            ContraseniaTextBox.Text = string.Empty;
        }

        private bool ObtenerDatos()
        {
            bool Retorno = true;
            int id;
            int.TryParse(UsuarioIdTextBox.Text, out id);
            if (id > 0)
            {
                Usuario.UsuarioId = id;
            }
            else
            {
                Retorno = false;
            }
            if (NombresTextBox.Text.Length > 0)
            {
                Usuario.Nombres = NombresTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (ApellidosTextBox.Text.Length > 0)
            {
                Usuario.Apellidos = ApellidosTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (TelefonoTextBox.Text.Length > 0)
            {
                Usuario.Telefono = TelefonoTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (EmailTextBox.Text.Length > 0)
            {
                Usuario.Email = EmailTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (DireccionTextBox.Text.Length > 0)
            {
                Usuario.Direccion = DireccionTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (NombreUsuarioTextBox.Text.Length > 0)
            {
                Usuario.NombreUsuario = NombreUsuarioTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (ContraseniaTextBox.Text.Length > 0)
            {
                Usuario.Contrasenia = ContraseniaTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (id > 0)
            {
                Usuario.TipoUsuario = 0;
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        public void DevolverDatos()
        {
            UsuarioIdTextBox.Text = Usuario.UsuarioId.ToString();
            NombresTextBox.Text = Usuario.Nombres.ToString();
            ApellidosTextBox.Text = Usuario.Apellidos.ToString();
            TelefonoTextBox.Text = Usuario.Telefono.ToString();
            EmailTextBox.Text = Usuario.Email.ToString();
            DireccionTextBox.Text = Usuario.Direccion.ToString();
            NombreUsuarioTextBox.Text = Usuario.NombreUsuario.ToString();
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            // Limpiar();
            Utilities.ShowToastr(this, "error", "Mensaje", "error");
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (ContraseniaTextBox.Text.Trim() != ConfContraseniaTexBox.Text.Trim())
            {
                Utilities.ShowToastr(this, "error", "Contraseñas no coindicen!", "error");
            }
            else
            {
                if (UsuarioIdTextBox.Text.Length == 0)
                {
                    ObtenerDatos();
                    if (Usuario.Insertar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se guardo con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "Mensaje", "error");
                    }
                }
                if (UsuarioIdTextBox.Text.Length > 0)
                {
                    ObtenerDatos();
                    if (Usuario.Editar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se modifico con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "error", "error");
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            try
            {
                ObtenerDatos();
                if (Usuario.Buscar(Usuario.UsuarioId))
                {
                    if (Usuario.Eliminar())
                    {
                        Limpiar();
                        Utilities.ShowToastr(this, "bien", "Se elimino con exito!", "success");
                    }
                    else
                    {
                        Utilities.ShowToastr(this, "error", "error", "error");
                    }
                }
            }
            catch (Exception)
            {
                Utilities.ShowToastr(this, "error", "error", "error");
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(UsuarioIdTextBox.Text, out id);
            if (id < 0)
            {
                Utilities.ShowToastr(this, "error", "error", "error");
            }
            else
            {
                if (Usuario.Buscar(id))
                {
                    DevolverDatos();
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "error", "error");
                }
            }
        }
    }
}