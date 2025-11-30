<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Laboratorio14Replica.aspx.cs" Inherits="Laboratorio14Replica" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>CRUD Laptops - Replica Lab 14</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Gestión de Laptops (Replica Lab 14)</h2>

        <!-- BUSCAR -->
        Buscar por Id:
        <asp:TextBox ID="txtBuscarId" runat="server" />
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        <br /><br />

        <!-- FORMULARIO -->
        <table>
            <tr>
                <td>Id:</td>
                <td><asp:TextBox ID="txtId" runat="server" ReadOnly="true" /></td>
            </tr>
            <tr>
                <td>Nombre:</td>
                <td><asp:TextBox ID="txtNombre" runat="server" /></td>
            </tr>
            <tr>
                <td>Precio:</td>
                <td><asp:TextBox ID="txtPrecio" runat="server" /></td>
            </tr>
            <tr>
                <td>Stock:</td>
                <td><asp:TextBox ID="txtStock" runat="server" /></td>
            </tr>
        </table>

        <br />

        <!-- BOTONES -->
        <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        
        <br /><br />

        <!-- GRID -->
        <asp:GridView ID="gvLaptops" runat="server" AutoGenerateColumns="true" />
        
    </form>
</body>
</html>
