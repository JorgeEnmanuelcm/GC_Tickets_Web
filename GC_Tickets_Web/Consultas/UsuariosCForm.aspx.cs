using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GC_Tickets_Web.Consultas
{
    public partial class UsuariosCForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condicion = "";
            UsuariosClass Usuario = new UsuariosClass();
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Condicion = "1=1";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(BuscarTextBox.Text))
                {
                    Condicion = CamposDropDownList.SelectedValue + " like '%" + BuscarTextBox.Text + "%'";
                }
            }
            ConsultaGridView.DataSource = Usuario.Listado("Nombres, Apellidos, Telefono, Email, Direccion, NombreUsuario, Contrasenia", Condicion, "");
            ConsultaGridView.DataBind();
        }
    }
}