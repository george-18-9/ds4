using System;
using System.Windows.Forms;

namespace Laboratorio12_1
{
    public partial class Form1 : Form
    {
        Calculos calc = new Calculos();

        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                double velocidad = double.Parse(txtVelocidad.Text);
                double tiempo = double.Parse(txtTiempo.Text);

                Calculos calc = new Calculos();
                double distancia = calc.CalcularDistancia(velocidad, tiempo);

                lblResultado.Text = $"{distancia:F2} km";
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingrese solo números válidos.", "Error de formato",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}




