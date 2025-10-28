using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace parcial2
{
    public partial class Form1 : Form
    {
        // Cadena de conexión
        string connectionString = "server=localhost;database=ConversorDB;uid=root;pwd=G30rg365180706;";

        public Form1()
        {
            InitializeComponent();
            CargarHistorial();
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que el TextBox no esté vacío
                if (string.IsNullOrWhiteSpace(txtValor.Text))
                {
                    MessageBox.Show("Por favor ingrese un valor numérico.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Intentar convertir a número
                double valor = double.Parse(txtValor.Text);
                double resultado = 0;
                string conversion = "";

                // Verificar qué tipo de conversión se seleccionó
                if (rdbMetrosAYardas.Checked)
                {
                    resultado = valor * 1.0936;
                    conversion = $"{valor} metros = {resultado:F4} yardas";
                }
                else if (rdbYardasAMetros.Checked)
                {
                    resultado = valor * 0.9144;
                    conversion = $"{valor} yardas = {resultado:F4} metros";
                }
                else
                {
                    MessageBox.Show("Seleccione una opción de conversión.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Mostrar resultado en pantalla
                lblResultado.Text = "Resultado: " + conversion;

                // Agregar al ListBox local
                lstHistorial.Items.Add(conversion);

                // Guardar en la base de datos MySQL
                GuardarEnBaseDatos(valor, resultado, conversion);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un número válido (use punto para decimales).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void GuardarEnBaseDatos(double valorOriginal, double resultado, string conversion)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO HistorialConversion (ValorOriginal, Conversion, TipoConversion, Resultado) " +
                                   "VALUES (@valorOriginal, @conversion, @tipo, @resultado)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@valorOriginal", valorOriginal);
                        cmd.Parameters.AddWithValue("@conversion", conversion);
                        cmd.Parameters.AddWithValue("@tipo", rdbMetrosAYardas.Checked ? "Metros a Yardas" : "Yardas a Metros");
                        cmd.Parameters.AddWithValue("@resultado", resultado);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar en la base de datos: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorial()
        {
            lstHistorial.Items.Clear();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT Conversion FROM HistorialConversion ORDER BY FechaHora";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lstHistorial.Items.Add(reader["Conversion"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar historial: " + ex.Message, "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtValor.Clear();
            lblResultado.Text = "Resultado:";
            lstHistorial.Items.Clear();
        }
    }
}
