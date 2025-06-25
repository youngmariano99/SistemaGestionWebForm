using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Web.UI;

namespace Helpers
{
    public static class NavegacionHelper
    {
        private const string claveVista = "VistaActual";

        public static void RedirigirAVista(Page page, VistaActual vista)
        {
            page.Session[claveVista] = vista;
            page.Response.Redirect("Default.aspx");
        }

        public static VistaActual? ObtenerVista(HttpSessionState session)
        {
            return session[claveVista] as VistaActual?;
        }

        public static void LimpiarVista(HttpSessionState session)
        {
            session.Remove(claveVista);
        }
    }
}
