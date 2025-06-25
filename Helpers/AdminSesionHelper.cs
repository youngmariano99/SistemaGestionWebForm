using modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.SessionState;

namespace Helpers
{
    public static class SesionAdminHelper
    {
        public static void GuardarAdministrador(HttpSessionState session, Administrador admin)
        {
            session["AdministradorLogueado"] = admin;
        }

        public static Administrador ObtenerAdministrador(HttpSessionState session)
        {
            return session["AdministradorLogueado"] as Administrador;
        }

        public static bool EstaAdministradorLogueado(HttpSessionState session)
        {
            return session["AdministradorLogueado"] is Administrador;
        }

        public static void CerrarSesion(HttpSessionState session)
        {
            session.Clear();
        }
    }
}
