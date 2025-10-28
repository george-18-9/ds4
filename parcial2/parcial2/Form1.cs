using System;
using System.Windows.Forms;

namespace parcial2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                // Mostrar resultado
                lblResultado.Text = "Resultado: " + conversion;

                // Agregar al historial
                lstHistorial.Items.Add(conversion);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese un número válido (use punto para decimales).", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message, "Error inesperado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
