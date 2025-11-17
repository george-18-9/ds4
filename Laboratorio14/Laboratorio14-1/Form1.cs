using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Laboratorio14_1
{
    public partial class frmProductos : Form
    {
        string connectionString = @"Server=.\SQLEXPRESS;Database=productos;Trusted_Connection=True;";
        bool nuevo = false;

        private void LimpiarCampos()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }

        private void HabilitarCampos(bool estado)
        {
            // si estado = true -> habilita para edición/entrada
            txtNombre.Enabled = estado;
            txtPrecio.Enabled = estado;
            txtStock.Enabled = estado;
            // Id normalmente readonly
            txtId.ReadOnly = true;
            tsbGuardar.Enabled = estado;
            tsbCancelar.Enabled = estado;
            tsbNuevo.Enabled = !estado;
            tsbEliminar.Enabled = !estado;
        }

        private void CargarTodos()
        {
            // Opcional: carga al DataGridView
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Precio, Stock FROM dbo.Laptops", cn))
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (this.Controls.Find("dgvProductos", true).Length > 0)
                    {
                        var dgv = (DataGridView)this.Controls["dgvProductos"];
                        dgv.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar productos: " + ex.Message);
            }
        }


        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            // obtener valor desde ToolStripTextBox
            string sId = tstId.Text.Trim();
            int id;
            if (!int.TryParse(sId, out id))
            {
                MessageBox.Show("Ingrese un Id válido en la caja de búsqueda.");
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre, Precio, Stock FROM dbo.Laptops WHERE Id = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            txtId.Text = dr["Id"].ToString();
                            txtNombre.Text = dr["Nombre"].ToString();
                            txtPrecio.Text = dr["Precio"].ToString();
                            txtStock.Text = dr["Stock"].ToString();

                            // Habilitar edición si desea permitir editar directamente
                            nuevo = false;
                            HabilitarCampos(true); // si quieres editar inmediatamente
                        }
                        else
                        {
                            MessageBox.Show("Registro no encontrado.");
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en búsqueda: " + ex.Message);
            }
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            nuevo = true;
            LimpiarCampos();
            HabilitarCampos(true);
            txtNombre.Focus();
        }


        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.");
                txtNombre.Focus();
                return;
            }

            decimal precio;
            int stock;
            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio inválido.");
                txtPrecio.Focus();
                return;
            }
            if (!int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Stock inválido.");
                txtStock.Focus();
                return;
            }

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    cn.Open();

                    if (nuevo)
                    {
                        string insertSql = "INSERT INTO dbo.Laptops (Nombre, Precio, Stock) VALUES (@nombre, @precio, @stock);";
                        using (SqlCommand cmd = new SqlCommand(insertSql, cn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@stock", stock);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Registro guardado (insert).");
                    }
                    else
                    {
                        // editar
                        int id;
                        if (!int.TryParse(txtId.Text, out id))
                        {
                            MessageBox.Show("Id inválido.");
                            return;
                        }

                        string updateSql = "UPDATE dbo.Laptops SET Nombre=@nombre, Precio=@precio, Stock=@stock WHERE Id=@id;";
                        using (SqlCommand cmd = new SqlCommand(updateSql, cn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@precio", precio);
                            cmd.Parameters.AddWithValue("@stock", stock);
                            cmd.Parameters.AddWithValue("@id", id);
                            int afect = cmd.ExecuteNonQuery();
                            if (afect > 0)
                                MessageBox.Show("Registro actualizado.");
                            else
                                MessageBox.Show("No se encontró el registro para actualizar.");
                        }
                    }

                    cn.Close();
                }

                // después de guardar
                nuevo = false;
                HabilitarCampos(false);
                LimpiarCampos();
                CargarTodos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }


        private void tsbCancelar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Ingrese un Id válido para eliminar.");
                return;
            }

            var r = MessageBox.Show("¿Seguro que desea eliminar el registro con Id " + id + "?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (r != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("DELETE FROM dbo.Laptops WHERE Id = @id", cn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cn.Open();
                    int afect = cmd.ExecuteNonQuery();
                    cn.Close();

                    if (afect > 0)
                    {
                        MessageBox.Show("Registro eliminado.");
                    }
                    else
                    {
                        MessageBox.Show("No se encontró registro con ese Id.");
                    }
                    LimpiarCampos();
                    CargarTodos();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }


        private void frmProductos_Load(object sender, EventArgs e)
        {
            LimpiarCampos();
            HabilitarCampos(false);
            CargarTodos();
        }

    }
}
