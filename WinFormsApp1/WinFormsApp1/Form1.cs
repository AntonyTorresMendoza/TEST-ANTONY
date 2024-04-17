using AccesoDatos;
using AccesoDatosLayer;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public dalVenta dalVenta;
        public Form1()
        {
            InitializeComponent();
            dalVenta = new dalVenta();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                CVenta nuevaVenta = new CVenta
                {
                    id = Convert.ToInt32(textID.Text), // Asegúrate de que este campo también se maneje correctamente en la base de datos.
                    idcliente = Convert.ToInt32(txtIDCLiente.Text),
                    idruta = Convert.ToInt32(txtIDRuta.Text),
                    cantidadpersonas = Convert.ToInt32(txtCantidadPersonas.Text)
                };

                dalVenta.InsertarVenta(nuevaVenta);
                MessageBox.Show("Venta insertada correctamente.");
            }
            catch (FormatException fe)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos en todos los campos.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error al insertar la venta: " + ex.Message);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
