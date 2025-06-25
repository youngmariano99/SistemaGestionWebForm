<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="SistemaGestionEmpleadosWebForm.UserControls.LoginAdmin" %>

<!-- Navbar del login -->
<nav class="w-full bg-gradient-to-r from-gray-800 to-gray-900 shadow-xl py-4 px-6 sticky top-0 z-50">
    <div class="max-w-7xl mx-auto flex justify-center items-center text-white">
        <div class="flex items-center space-x-3">
            <img src="img/AppyLogoSV.svg" class="w-32 h-auto max-w-full" alt="Icono de navegación">
            <h1 class="text-xl font-bold bg-clip-text text-transparent bg-gradient-to-r from-indigo-300 to-indigo-100">
                Gestión de Empleados
            </h1>
        </div>
    </div>
</nav>

<!-- Formulario de login -->
<div class="flex items-center justify-center min-h-screen bg-gray-100">
    <div class="bg-white p-8 rounded-lg shadow-lg max-w-sm w-full">
        <h1 class="text-2xl font-bold text-center text-gray-800 mb-6">
            Bienvenido administrador
        </h1>

        <asp:Label runat="server" Visible="True" ID="lblMensaje" />

        <label for="txtboxGmail" class="block text-gray-600 font-medium">Gmail</label>
        <asp:TextBox runat="server" type="email" id="txtboxEmail" placeholder="Ingrese su correo" 
            class="w-full px-4 py-2 mt-1 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-indigo-500" />

        <label for="TtxtboxContraseña" class="block text-gray-600 font-medium mt-4">Contraseña</label>
        <asp:TextBox runat="server" type="password" id="txtboxContraseña" placeholder="Ingrese su contraseña" 
            class="w-full px-4 py-2 mt-1 border border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-indigo-500" />

        <asp:Button OnClick="btnLogin_Click" runat="server" Text="Ingresar" id="btnIngresar" class="w-full bg-indigo-600 text-white mt-6 py-2 rounded-lg hover:bg-indigo-700 transition duration-200" />
           
    </div>
</div>