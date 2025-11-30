using System;
using System.Data;
using System.Data.SqlClient;

public partial class Laboratorio14Replica : System.Web.UI.Page
{
    // TU CADENA DE CONEXIÓN REAL
    string connectionString = @"Server=.\SQLEXPRESS;Database=productos;Trusted_Connection=True;";

    // Guardamos si estamos en modo Nuevo dentro del ViewState (ASP.NET no guarda variables normales)
    bool nuevo
    {
        get { return (bool)(ViewState["nuevo"] ?? false); }
        set { ViewState["nuevo"] = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            nuevo = false;
            CargarTodos();
        }
    }

    // ===========================
    // CARGAR TODAS LAS LAPTOPS
    // ===========================
    void CargarTodos()
    {
        using (SqlConnection cn = new SqlConnection(connectionString))
        using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.Laptops", cn))
        {
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvLaptops.DataSource = dt;
            gvLaptops.DataBind();
        }
    }

    // ===========================
    // LIMPIAR CAMPOS
    // ===========================
    void Limpiar()
    {
        txtId.Text = "";
        txtNombre.Text = "";
        txtPrecio.Text = "";
        txtStock.Text = "";
        txtBuscarId.Text = "";
    }

    // ===========================
    // BOTÓN NUEVO
    // ===========================
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        nuevo = true;
        Limpiar();
    }

    // ===========================
    // GUARDAR (INSERT / UPDATE)
    // ===========================
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text))
        {
            Response.Write("<script>alert('El nombre es obligatorio');</script>");
            return;
        }

        decimal precio = 0;
        double stock = 0;

        decimal.TryParse(txtPrecio.Text, out precio);
        double.TryParse(txtStock.Text, out stock);

        if (nuevo)
        {
            // INSERTAR
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO dbo.Laptops (nombre, precio, stock) VALUES (@n, @p, @s)";
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Registro insertado correctamente');</script>");
        }
        else
        {
            // ACTUALIZAR
            using (SqlConnection cn = new SqlConnection(connectionString))
            {
                string sql = "UPDATE dbo.Laptops SET nombre=@n, precio=@p, stock=@s WHERE id=@id";
                SqlCommand cmd = new SqlCommand(sql, cn);

                cmd.Parameters.AddWithValue("@id", txtId.Text);
                cmd.Parameters.AddWithValue("@n", txtNombre.Text);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

            Response.Write("<script>alert('Registro actualizado');</script>");
        }

        nuevo = false;
        CargarTodos();
        Limpiar();
    }

    // ===========================
    // BUSCAR POR ID
    // ===========================
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtBuscarId.Text))
        {
            Response.Write("<script>alert('Ingrese un ID válido');</script>");
            return;
        }

        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            string sql = "SELECT * FROM dbo.Laptops WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", txtBuscarId.Text);

            cn.Open();
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.Read())
                {
                    txtId.Text = dr["id"].ToString();
                    txtNombre.Text = dr["nombre"].ToString();
                    txtPrecio.Text = dr["precio"].ToString();
                    txtStock.Text = dr["stock"].ToString();

                    nuevo = false;
                }
                else
                {
                    Response.Write("<script>alert('Registro no encontrado');</script>");
                }
            }
        }
    }

    // ===========================
    // ELIMINAR
    // ===========================
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtId.Text))
        {
            Response.Write("<script>alert('Debe seleccionar un registro');</script>");
            return;
        }

        using (SqlConnection cn = new SqlConnection(connectionString))
        {
            string sql = "DELETE FROM dbo.Laptops WHERE id=@id";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@id", txtId.Text);

            cn.Open();
            cmd.ExecuteNonQuery();
        }

        Response.Write("<script>alert('Registro eliminado');</script>");

        CargarTodos();
        Limpiar();
    }

    // ===========================
    // CANCELAR
    // ===========================
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        nuevo = false;
        Limpiar();
    }
}
