using Controllers;
using Helpers;
using modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaGestionEmpleadosWebForm.UserControls
{
    public partial class uc_ControlDeAccesos : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnFiltrarAccesos_Click(object sender, EventArgs e)
        {
            int dias = int.Parse(ddlRangoFechas.SelectedValue);

            DateTime hasta = DateTime.Now;
            DateTime desde = hasta.AddDays(-dias);

            List<RegistroAccesoEmpleado> accesos = AdminController.ObtenerAccesosPorRango(desde, hasta);

            if (accesos != null && accesos.Count > 0)
            {
                lblSinDatos.Visible = false;
                TablaAccesos.DataSource = accesos;
                TablaAccesos.DataBind();
            }
            else
            {
                TablaAccesos.DataSource = null;
                TablaAccesos.DataBind();

                lblSinDatos.Text = "No se encontraron accesos en el período seleccionado.";
                lblSinDatos.Visible = true;
            }
        }

        protected void btnVolverMenu_Click(object sender, EventArgs e)
        {
            NavegacionHelper.RedirigirAVista(this.Page, VistaActual.MenuPrincipal);
        }
    }
}