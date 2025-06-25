<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_ControlDeAccesos.ascx.cs" Inherits="SistemaGestionEmpleadosWebForm.UserControls.uc_ControlDeAccesos" %>

        <header>
           <nav class="w-full bg-gradient-to-r from-gray-800 to-gray-900 shadow-xl py-4 px-6 sticky top-0 z-50">
    <div class="max-w-7xl mx-auto flex justify-between items-center text-white">
        <!-- Logo y nombre del sistema -->
        <div class="flex items-center space-x-3">
             
                <img src="img/AppyLogoSV.svg" class="w-32 h-auto max-w-full" alt="Icono de navegación">
                    
            
            <h1 class="text-xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-indigo-300 to-indigo-100">Gestión de Empleados</h1>
        </div>

        <!-- Links de navegación -->
      <ul class="hidden md:flex items-center space-x-2">
           <li>
                <asp:Button ID="btnVolverMenu" runat="server" Text="← Volver al menú principal"
                CssClass="mt-6 bg-gray-500 hover:bg-gray-600 text-white font-medium px-4 py-2 rounded-lg transition shadow"
                OnClick="btnVolverMenu_Click" />
            </li>
       </ul>

        <!--  móvil (ícono) -->
        <button class="md:hidden text-gray-300 hover:text-white focus:outline-none">
            <svg class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
            </svg>
        </button>
    </div>
</nav>

        </header>

                
<div class="max-w-6xl mx-auto p-4 mt-8 bg-white shadow-md border border-gray-300 rounded-lg">
    <h2 class="text-2xl font-bold text-gray-700 mb-4 text-center">🔍 Registro de accesos de empleados</h2>

    <!-- Filtros -->
    <div class="flex flex-col md:flex-row items-center justify-between gap-4 mb-6">
        <asp:DropDownList ID="ddlRangoFechas" runat="server" CssClass="px-4 py-2 border border-gray-300 rounded-lg shadow-sm text-gray-700">
            <asp:ListItem Text="Últimos 7 días" Value="7" />
            <asp:ListItem Text="Últimos 30 días" Value="30" Selected="True" />
            <asp:ListItem Text="Últimos 90 días" Value="90" />
        </asp:DropDownList>

        <asp:Button ID="btnFiltrarAccesos" runat="server" Text="Filtrar"
            CssClass="bg-blue-500 hover:bg-blue-600 text-white font-semibold px-4 py-2 rounded-lg transition duration-150 shadow-md"
            OnClick="btnFiltrarAccesos_Click" />
    </div>

    <!-- Tabla de resultados -->
    <div class="overflow-x-auto">
        <asp:GridView ID="TablaAccesos" runat="server" AutoGenerateColumns="False"
            CssClass="min-w-full divide-y divide-gray-200 rounded-lg overflow-hidden shadow-md border border-gray-300 bg-white text-sm"
            HeaderStyle-CssClass="bg-gray-700 text-white uppercase tracking-wider text-sm font-semibold"
            RowStyle-CssClass="bg-white hover:bg-gray-100 align-middle transition duration-150">

            <Columns>
                <asp:TemplateField HeaderText="Empleado">
                    <ItemStyle CssClass="align-middle" />
                    <ItemTemplate>
                        <span class="px-4 py-2 font-medium text-gray-800 inline-block w-full">
                            <%# Eval("Empleado.Nombre") + " " + Eval("Empleado.Apellido") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Accesos registrados">
                    <ItemStyle CssClass="align-middle text-center" />
                    <ItemTemplate>
                        <span class="px-4 py-2 text-gray-700 inline-block w-full">
                            <%# Eval("CantidadAccesos") %>
                        </span>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

    <asp:Label ID="lblSinDatos" runat="server" CssClass="block text-center text-red-500 font-medium mt-4" Visible="false" />
</div>