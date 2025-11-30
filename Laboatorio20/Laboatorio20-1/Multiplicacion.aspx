<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Multiplicacion.aspx.cs" Inherits="Multiplicacion" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Multiplicación</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:TextBox ID="txtNumero" runat="server" />
        <asp:Button ID="btnGenerar" runat="server" Text="Generar" OnClick="btnGenerar_Click" />
        <asp:Panel ID="pnlResultado" runat="server" Visible="false">
            <asp:Label ID="lblResultado" runat="server" />
            <asp:GridView ID="gvTabla" runat="server" AutoGenerateColumns="true" />
        </asp:Panel>
    </form>
</body>
</html>
