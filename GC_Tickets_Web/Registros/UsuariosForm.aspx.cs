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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EliminarButton.Visible = false;
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

        private bool ObtenerDatos(UsuariosClass Usuario)
        {
            bool Retorno = true;
            int id = Utilities.intConvertir(UsuarioIdTextBox.Text);
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

        public void DevolverDatos(UsuariosClass Usuario)
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
            Limpiar();
            EliminarButton.Visible = false;
            GuardarButton.Text = "Guardar";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            UsuariosClass Usuario = new UsuariosClass();
            if (Usuario.UnicoUsuario(NombreUsuarioTextBox.Text))
            {
                Utilities.ShowToastr(this, "error", "Ese nombre de usuario ya existe!", "error");
                NombreUsuarioTextBox.Text = string.Empty;
            }
            else
            {
                if (ContraseniaTextBox.Text.Trim() != ConfContraseniaTexBox.Text.Trim())
                {
                    Utilities.ShowToastr(this, "error", "Contraseñas no coindicen!", "error");
                    ContraseniaTextBox.Text = string.Empty;
                    ConfContraseniaTexBox.Text = string.Empty;
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(UsuarioIdTextBox.Text))
                    {
                        ObtenerDatos(Usuario);
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
                        ObtenerDatos(Usuario);
                        if (Usuario.Editar())
                        {
                            Limpiar();
                            EliminarButton.Visible = false;
                            GuardarButton.Text = "Guardar";
                            Utilities.ShowToastr(this, "bien", "Se modifico con exito!", "success");
                        }
                        else
                        {
                            Utilities.ShowToastr(this, "error", "error", "error");
                        }
                    }
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            UsuariosClass Usuario = new UsuariosClass();
            try
            {
                ObtenerDatos(Usuario);
                if (Usuario.Buscar(Usuario.UsuarioId))
                {
                    if (Usuario.Eliminar())
                    {
                        Limpiar();
                        EliminarButton.Visible = false;
                        GuardarButton.Text = "Guardar";
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
            UsuariosClass Usuario = new UsuariosClass();
            int id = Utilities.intConvertir(UsuarioIdTextBox.Text);
            if (id < 0)
            {
                Utilities.ShowToastr(this, "error", "error", "error");
            }
            else
            {
                if (Usuario.Buscar(id))
                {
                    EliminarButton.Visible = true;
                    GuardarButton.Text = "Modificar";
                    DevolverDatos(Usuario);
                }
                else
                {
                    Utilities.ShowToastr(this, "error", "error", "error");
                }
            }
        }
    }
}