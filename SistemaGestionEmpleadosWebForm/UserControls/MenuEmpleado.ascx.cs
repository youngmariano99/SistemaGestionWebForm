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
    public partial class MenuEmpleado : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTablaProductosDelEmpleado();

                Empleado empleadoActual = SesionHelper.ObtenerEmpleado(Session);
                if (empleadoActual != null)
                {
                    lblBienvenida.Text = $"Bienvenido {empleadoActual.Nombre} al sistema de gestión de productos";
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }

            }
            else
            {
                // Vuelve a cargar la lista usando Session (si ya la guardás)
                var productos = Session["TablaProducto"] as List<Producto>;
                if (productos != null)
                {
                    TablaProducto.DataSource = productos;
                    TablaProducto.DataBind();
                }
            }

        }

        public void LlenarTablaProductosDelEmpleado()
        {
            Empleado emp = SesionHelper.ObtenerEmpleado(Session);
            if (emp == null)
            {
                //lblMensaje.Text = "⚠️ Sesión expirada.";
                return;
            }

            List<Producto> productos = EmpleadoController.ObtenerProductosPorEmpleado(emp.Id);

            if (productos.Count > 0)
            {
                TablaProducto.DataSource = productos;
                TablaProducto.DataBind();

                Session["TablaProducto"] = productos;
            }
            else
            {
                //lblMensaje.Text = "No tenés productos cargados aún.";
                TablaProducto.DataSource = null;
                TablaProducto.DataBind();
            }
        }
        


        protected void TablaProducto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(TablaProducto.DataKeys[e.RowIndex].Value);

            bool eliminado = EmpleadoController.EliminarProductoPorId(id);

            if (eliminado)
            {
                LlenarTablaProductosDelEmpleado(); // 🔁 Ya tenés este método para recargar
            }
            else
            {
                //lblMensaje.Text = "❌ No se pudo eliminar el producto.";
            }
        }



        
        protected void TablaProducto_RowEditing(object sender, GridViewEditEventArgs e)
        {

            TablaProducto.EditIndex = e.NewEditIndex; // Cambia la fila a modo edición
            LlenarTablaProductosDelEmpleado(); // Recarga la tabla con la nueva vista

        }


        protected void TablaProducto_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow fila = TablaProducto.Rows[e.RowIndex];

            Producto productoActualizado = new Producto
            {
                Id = Convert.ToInt32(TablaProducto.DataKeys[e.RowIndex].Value),
                Nombre = ((TextBox)fila.FindControl("txtEditNombre")).Text,
                Categoria = ((TextBox)fila.FindControl("txtEditCategoria")).Text,
                Stock = int.Parse(((TextBox)fila.FindControl("txtEditStock")).Text),
                Precio = decimal.Parse(((TextBox)fila.FindControl("txtEditPrecio")).Text),
                
            };

            bool actualizado = EmpleadoController.ActualizarProducto(productoActualizado);

            if (!actualizado)
                lblMensajes.Text = "❌ Error al actualizar el producto.";

            TablaProducto.EditIndex = -1;
            LlenarTablaProductosDelEmpleado();
        }


        protected void TablaProducto_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            TablaProducto.EditIndex = -1;
            LlenarTablaProductosDelEmpleado();
            
        }




        //METODO PARA CREAR EMPLEADOS EN EL MODAL

        //Método del evento del botón para crear un nuevo Producto
        protected void btnCrearProducto_Click(object sender, EventArgs e)
        {
            Empleado emp = SesionHelper.ObtenerEmpleado(Session);
            if (emp == null)
            {
                lblMensajeErrorCrearEmpleado.Text = "⚠️ No hay sesión activa.";
                return;
            }

            Producto nuevoProducto = new Producto
            {
                Nombre = txtboxNombreCrearProducto.Text,
                Categoria = txtboxCategoriaCrearProducto.Text,
                Stock = int.Parse(txtboxStockCrearProducto.Text),
                Precio = decimal.Parse(txtboxPrecioCrearProducto.Text),
                EmpleadoResponsableId = emp.Id
            };

            bool creado = EmpleadoController.AgregarProducto(nuevoProducto);

            if (creado)
            {
                LlenarTablaProductosDelEmpleado();
            }
            else
            {
                lblMensajeErrorCrearEmpleado.Text = "❌ No se pudo agregar el producto.";
            }
        }

        protected void btnCerrarSesionEmpleado_Click(object sender, EventArgs e)
        {
            SesionHelper.CerrarSesion(Session);
            NavegacionHelper.RedirigirAVista(this.Page, VistaActual.Login);
        }


    }
}
    
