using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using modelos;
using System.Web.SessionState;

namespace Helpers
{
    public static class SesionHelper
    {

        public static bool EstaEmpleadoLogueado(HttpSessionState session)
        {
            return session["EmpleadoLogueado"] is Empleado;
        }

        public static Empleado ObtenerEmpleado(HttpSessionState session)
        {
            return session["EmpleadoLogueado"] as Empleado;
        }

        public static void GuardarEmpleado(HttpSessionState session, Empleado empleado)
        {
            session["EmpleadoLogueado"] = empleado;
        }

        public static void CerrarSesion(HttpSessionState session)
        {
            session.Clear();
        }

    }
}
