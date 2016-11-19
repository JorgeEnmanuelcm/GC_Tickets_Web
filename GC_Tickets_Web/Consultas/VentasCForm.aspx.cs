using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace GC_Tickets_Web.Consultas
{
    public partial class VentasCForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private string Buscar(VentasClass Venta)
        {
            string filtro = "";
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                filtro = "1=1";
            }
            else
            {
                if (CamposDropDownList.SelectedIndex == 0)
                {
                    filtro = "VentaId = " + BuscarTextBox.Text;
                }
                else
                {
                    filtro = CamposDropDownList.SelectedValue + " like '%" + BuscarTextBox.Text + "%'";
                }
            }
            ConsultaGridView.DataSource = Venta.Listado("*", filtro, "");
            ConsultaGridView.DataBind();
            return filtro;
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            VentasClass Venta = new VentasClass();
            Buscar(Venta);       
        }
    }
}