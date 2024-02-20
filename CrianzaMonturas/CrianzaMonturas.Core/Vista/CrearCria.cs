using CrianzaDragopavos.Modelo;

namespace CrianzaDragopavos.Vista
{
    public partial class CrearCria : Form
    {
        private string nombre;
        private string sexo;
        private bool predispuesto;

        public string Nombre {
            get { return nombre; }
            set { nombre = value; } 
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public bool Predispuesto
        {
            get { return predispuesto; }
            set { predispuesto = value; }
        }

        public CrearCria(Tipo tipo)
        {
            InitializeComponent();
            
            nombre = tipo.Nombre;
            sexo = string.Empty;

            txtTipo.Text = nombre;
            txtNombre.Text = tipo.Sigla;
        }

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string message = string.Format("Desea crear la cria [{0}] como resultado de la reproduccion?", txtTipo.Text);

            DialogResult msg = MessageBox.Show(message, "Generar Cria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                Nombre = txtNombre.Text;
                Sexo = cmbSexo.Text;
                Predispuesto = chkPredispuesto.Checked;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }

            this.Close();
        }

        private void TxtNombre_Leave(object sender, EventArgs e)
        {
            Clipboard.SetText(txtNombre.Text);
        }
    }
}
