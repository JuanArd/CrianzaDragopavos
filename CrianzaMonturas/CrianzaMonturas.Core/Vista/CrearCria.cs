using CrianzaMonturas.Dal.Contratos;
using CrianzaMonturas.Dal.Modelo;

namespace CrianzaMonturas.Core.Vista
{
    public partial class CrearCria : Form
    {
        #region Properties

        private string nombre;
        private string sexo;
        private bool predispuesto;
        private int pureza;

        public string Nombre
        {
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

        public int Pureza
        {
            get { return pureza; }
            set { pureza = value; }
        }

        #endregion Properties

        public CrearCria(Tipo tipo, Montura padre, Montura madre)
        {
            InitializeComponent();

            nombre = tipo.Nombre;
            sexo = string.Empty;

            txtTipo.Text = nombre;
            txtNombre.Text = tipo.Sigla;
            txtPureza.Text = CalcularPureza(tipo.Id, padre, madre, 1).ToString();
        }

        #region Events

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string message = string.Format("Desea crear la cria [{0}] como resultado de la reproduccion?", txtTipo.Text);

            DialogResult msg = MessageBox.Show(message, "Generar Cria", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                Nombre = txtNombre.Text;
                Sexo = cmbSexo.Text;
                Predispuesto = chkPredispuesto.Checked;
                Pureza = Convert.ToInt32(txtPureza.Text);
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


        private void ChkModificar_CheckedChanged(object sender, EventArgs e)
        {
            txtPureza.ReadOnly = chkModificar.Checked;
        }

        private void TxtPureza_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        #endregion Events

        #region Methods

        private int CalcularPureza(int tipoCria, IMontura? padre, IMontura? madre, int lvl)
        {
            var pureza = 0;
            var base_pureza = lvl switch
            {
                1 => 6,
                2 => 3,
                3 => 1,
                _ => 0,
            };

            if (padre is not null && padre.TipoId == tipoCria) pureza += base_pureza;
            if (madre is not null && madre.TipoId == tipoCria) pureza += base_pureza;

            if (lvl <= 2)
            {
                var newLvl = lvl + 1;
                if (padre is not null) pureza += CalcularPureza(tipoCria, padre.Padre, padre.Madre, newLvl);
                if (madre is not null) pureza += CalcularPureza(tipoCria, madre.Padre, madre.Madre, newLvl);
            }

            return pureza;
        }

        #endregion Methods

        
    }
}
