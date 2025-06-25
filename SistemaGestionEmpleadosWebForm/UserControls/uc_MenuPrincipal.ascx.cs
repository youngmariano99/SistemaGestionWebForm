using Controllers;
using Helpers;
using modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaGestionEmpleadosWebForm.UserControls
{
    public partial class uc_MenuPrincipal : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
             

                LlenarTablaEmpleados();
            }
            else
            {
                // Vuelve a cargar la lista usando Session (si ya la guardás)
                var empleados = Session["TablaEmpleados"] as List<Empleado>;
                if (empleados != null)
                {
                    TablaEmpleados.DataSource = empleados;
                    TablaEmpleados.DataBind();
                }
            }


            //phContenido.Controls.Add(LoadControl("~/UserControls/Admin.ascx"));
        }




        public void LlenarTablaEmpleados()
        {
            List<Empleado> empleados = AdminController.ObtenerTodosLosEmpleados();

            if (empleados != null && empleados.Count > 0)
            {
                TablaEmpleados.DataSource = empleados;
                TablaEmpleados.DataBind();

                Session["TablaEmpleados"] = empleados;
            }
            else
            {
                lblMensaje.Text = "No se encontraron empleados.";
                TablaEmpleados.DataSource = null;
                TablaEmpleados.DataBind();
            }
        }






        // Método para eliminar un empleado
        protected void TablaEmpleados_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(TablaEmpleados.DataKeys[e.RowIndex].Value);

            if (ProductoController.EmpleadoTieneProductosAsignados(id))
            {
                // Mostrar panel y cargar el dropdown
                panelTransferencia.Visible = true;
                Session["EmpleadoAEliminar"] = id;

                // Obtener empleados excepto el actual
                var empleadosDestino = AdminController.ObtenerTodosLosEmpleados()
                .Where(emp => emp.Id != id)
                .Select(emp => new {
                    Id = emp.Id,
                    NombreCompleto = emp.Nombre + " " + emp.Apellido
                }).ToList();


                ddlEmpleadosDestino.DataSource = empleadosDestino;
                ddlEmpleadosDestino.DataTextField = "NombreCompleto";
                ddlEmpleadosDestino.DataValueField = "Id";
                ddlEmpleadosDestino.DataBind();
                

                lblMensaje.Text = "⚠️ Este empleado tiene productos asignados. Seleccioná otro empleado para transferirlos.";
                lblMensaje.ForeColor = System.Drawing.Color.Orange;
                lblMensaje.Visible = true;

                e.Cancel = true;


                TablaEmpleados.EditIndex = -1;
                LlenarTablaEmpleados();
                return;
            }

            // Si no tiene productos asignados, eliminar directamente

            try
            {
                bool rowAffected = AdminController.DesactivarEmpleadoPorId(id);

                if (!rowAffected)
                {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "❌ Error al desactivar el empleado.";
                }
                else
                {
                    LlenarTablaEmpleados(); // Refrescás la tabla si se eliminó
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "✅ Empleado desactivado correctamente.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Visible = true;
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = $"❌ Se produjo un error inesperado: {ex.Message}";

                // Opcional: para el Output de Visual Studio
                System.Diagnostics.Debug.WriteLine($"[ERROR] Al eliminar empleado {id}: {ex}");
            }
        }

        protected void btnTransferir_Click(object sender, EventArgs e)
        {
            if (Session["EmpleadoAEliminar"] != null && ddlEmpleadosDestino.SelectedValue != "")
            {
                int idOrigen = (int)Session["EmpleadoAEliminar"];
                int idDestino = Convert.ToInt32(ddlEmpleadosDestino.SelectedValue);

                ProductoController.TransferirProductos(idOrigen, idDestino);

                // Ahora sí, eliminar
                AdminController.DesactivarEmpleadoPorId(idOrigen);

                panelTransferencia.Visible = false;
                Session.Remove("EmpleadoAEliminar");

                lblMensaje.Text = "✅ Empleado desactivado y productos transferidos correctamente.";
                LlenarTablaEmpleados();
            }
        }




        protected void TablaEmpleados_RowEditing(object sender, GridViewEditEventArgs e)
        {

             TablaEmpleados.EditIndex = e.NewEditIndex; // Cambia la fila a modo edición
            LlenarTablaEmpleados(); // Recarga la tabla con la nueva vista
            
        }

        //Metodo para editar el empleado
        protected void TablaEmpleados_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = TablaEmpleados.Rows[e.RowIndex];

            Empleado emp = new Empleado
            {
                Id = Convert.ToInt32(TablaEmpleados.DataKeys[e.RowIndex].Value),
                Nombre = ((TextBox)fila.FindControl("txtEditNombre")).Text,
                Apellido = ((TextBox)fila.FindControl("txtEditApellido")).Text,
                Dni = ((TextBox)fila.FindControl("txtEditDni")).Text,
                FechaNacimiento = DateTime.Parse(((TextBox)fila.FindControl("txtEditFechaNacimiento")).Text),
                Email = ((TextBox)fila.FindControl("txtEditEmail")).Text,
                Contraseña = ((TextBox)fila.FindControl("txtEditContraseña")).Text
            };

            bool actualizado = AdminController.ActualizarEmpleado(emp);

            if (!actualizado)
                lblMensaje.Text = "❌ Error al actualizar el empleado.";

            TablaEmpleados.EditIndex = -1;
            LlenarTablaEmpleados();
        }


        //Metodo para cancelar la edición
        protected void TablaEmpleados_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TablaEmpleados.EditIndex = -1;
           LlenarTablaEmpleados(); // vuelve al modo normal
        }




        //METODO PARA CREAR EMPLEADOS EN EL MODAL

        //Método del evento del botón para crear un nuevo empleado
        protected void btnCrearEmpleado_Click(object sender, EventArgs e)
        {
            Empleado nuevo = new Empleado
            {
                Nombre = txtboxNombreCrearEmpleado.Text,
                Apellido = txtboxApellidoCrearEmpleado.Text,
                Dni = txtboxDniCrearEmpleado.Text,
                FechaNacimiento = DateTime.Parse(txtboxFechaNacimientoCrearEmpleado.Text),
                Email = txtboxEmailCrearEmpleado.Text,
                Contraseña = txtboxContraseñaCrearEmpleado.Text
            };

            bool creado = AdminController.AgregarEmpleado(nuevo);

            if (creado)
            {
                LlenarTablaEmpleados();
            }
            else
            {
               lblMensajeErrorCrearEmpleado.Text = "❌ No se pudo agregar el empleado.";
            }
        }

        protected void btnVerAccesos_Click(object sender, EventArgs e)
        {
            NavegacionHelper.RedirigirAVista(this.Page, VistaActual.ControlDeAccesos);
        }


        protected void btnCerrarSesionAdmin_Click(object sender, EventArgs e)
        {
            SesionAdminHelper.CerrarSesion(Session);
            NavegacionHelper.RedirigirAVista(this.Page, VistaActual.Login);
        }




    }
}