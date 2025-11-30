using System;
using System.Text;
using System.Web.UI.WebControls;

public partial class MatrizDiagonalInv : System.Web.UI.Page
{
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        int n = int.Parse(txtN.Text);

        StringBuilder sb = new StringBuilder();
        sb.Append("<table border='1' cellpadding='5'>");

        for (int i = 0; i < n; i++)
        {
            sb.Append("<tr>");
            for (int j = 0; j < n; j++)
            {
                int valor = (j == n - 1 - i) ? 1 : 0;
                sb.Append("<td>" + valor + "</td>");
            }
            sb.Append("</tr>");
        }

        sb.Append("</table>");

        pnlMatriz.Visible = true;
        pnlMatriz.Controls.Clear();
        pnlMatriz.Controls.Add(new Literal { Text = sb.ToString() });
    }
}
