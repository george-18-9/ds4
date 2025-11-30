using System;
using System.Data;

public partial class Multiplicacion : System.Web.UI.Page
{
    protected void btnGenerar_Click(object sender, EventArgs e)
    {
        int n;
        if (!int.TryParse(txtNumero.Text.Trim(), out n))
        {
            pnlResultado.Visible = false;
            return;
        }

        DataTable dt = new DataTable();
        dt.Columns.Add("Multiplicador", typeof(int));
        dt.Columns.Add("Resultado", typeof(long));

        for (int i = 1; i <= 25; i++)
        {
            dt.Rows.Add(i, (long)n * i);
        }

        gvTabla.DataSource = dt;
        gvTabla.DataBind();
        pnlResultado.Visible = true;
        lblResultado.Text = $"Tabla de multiplicar del {n}:";
    }
}
