using Helpers;
using SistemaGestionEmpleadosWebForm.UserControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
// Assuming this is the correct namespace for Empleado model

namespace SistemaGestionEmpleadosWebForm
{
    public partial class Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            CargarVistaDinamica();
        }

        private void CargarVistaDinamica()
        {
            PlaceHolder phContenido = (PlaceHolder)Page.FindControl("phContenido");
            phContenido.Controls.Clear();

            VistaActual? vista = NavegacionHelper.ObtenerVista(Session);

            if (SesionAdminHelper.EstaAdministradorLogueado(Session))
            {
                switch (vista)
                {
                    case VistaActual.ControlDeAccesos:
                        phContenido.Controls.Add(LoadControl("~/UserControls/uc_ControlDeAccesos.ascx"));
                        break;

                    case VistaActual.ABMProductos:
                        phContenido.Controls.Add(LoadControl("~/UserControls/uc_ABMProductos.ascx"));
                        break;

                    case VistaActual.MenuPrincipal:
                    default:
                        phContenido.Controls.Add(LoadControl("~/UserControls/uc_MenuPrincipal.ascx"));
                        break;
                }
            }
            else if (SesionHelper.EstaEmpleadoLogueado(Session))
            {
                phContenido.Controls.Add(LoadControl("~/UserControls/MenuEmpleado.ascx"));
            }
            else
            {
                phContenido.Controls.Add(LoadControl("~/UserControls/Login.ascx"));
            }
        }

        public void CargarUserControl(string nombre)
        {
            phContenido.Controls.Clear(); // 🔹 Borra TODOS los controles actuales del PlaceHolder
            Control ctrl = Page.LoadControl($"~/UserControls/{nombre}.ascx"); // 🔹 Carga el nuevo UserControl
            phContenido.Controls.Add(ctrl); // 🔹 Lo agrega al contenedor dinámico
        }


    }
}
