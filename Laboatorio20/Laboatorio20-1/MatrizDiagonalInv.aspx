<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MatrizDiagonalInv.aspx.cs" Inherits="MatrizDiagonalInv" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Matriz Diagonal Inversa</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Matriz N × N (Diagonal Inversa = 1)</h2>

        Ingresa N:
        <asp:TextBox ID="txtN" runat="server" />

        <asp:Button ID="btnGenerar" runat="server"
            Text="Generar Matriz" OnClick="btnGenerar_Click" />

        <br /><br />

        <asp:Panel ID="pnlMatriz" runat="server" Visible="false"></asp:Panel>

    </form>
</body>
</html>
