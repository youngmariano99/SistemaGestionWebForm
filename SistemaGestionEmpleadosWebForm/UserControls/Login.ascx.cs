
using modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using SistemaGestionEmpleadosWebForm.UserControls;
using Helpers;
using Controllers;

namespace SistemaGestionEmpleadosWebForm.UserControls
{
    public partial class LoginAdmin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Método del click login
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            DataRow adminRow;
            bool validoAdmin = AdminController.ValidarAdmin(txtboxEmail.Text, txtboxContraseña.Text, out adminRow);

            if (validoAdmin)
            {
                Administrador admin = new Administrador
                {
                    Id = Convert.ToInt32(adminRow["Id"]),
                    Nombre = adminRow["Nombre"].ToString(),
                    Email = adminRow["Email"].ToString()
                    
                };

                SesionAdminHelper.GuardarAdministrador(Session, admin);

                // Redirigimos al menú del administrador
                NavegacionHelper.RedirigirAVista(this.Page, VistaActual.MenuPrincipal);
                return; 
            }

            Empleado emp = EmpleadoController.ValidarEmpleado(txtboxEmail.Text, txtboxContraseña.Text);

            if (emp != null)
            {
                SesionHelper.GuardarEmpleado(Session, emp);
                EmpleadoController.RegistrarAcceso(emp.Id);

                NavegacionHelper.RedirigirAVista(this.Page, VistaActual.MenuEmpleado);
                return;
            }

            lblMensaje.Text = "❌ Credenciales inválidas.";
        }
    }
}
