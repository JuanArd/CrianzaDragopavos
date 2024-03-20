using CrianzaMonturas.Dal.Contratos;
using CrianzaMonturas.Dal.Dao;
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

        readonly MonturaDao monturaDao = new();

        public CrearCria(Tipo tipo, Montura padre, Montura madre)
        {
            InitializeComponent();

            pureza = CalcularPureza(tipo.Id, padre, madre, 1);

            nombre = monturaDao.ObtenerUltimoNombre(tipo);
            var idxGuionExtra = nombre.IndexOf('-', 6);
            nombre = idxGuionExtra == -1 ? nombre : nombre[..idxGuionExtra];

            var idMontura = Convert.ToInt32(nombre.Substring(nombre.IndexOf('-') + 1));
            nombre = nombre.Replace(idMontura.ToString(), (idMontura + 1).ToString());
            nombre = pureza == 32 ? nombre + "-PUR" : nombre;

            sexo = string.Empty;

            txtTipo.Text = tipo.Nombre;
            txtNombre.Text = nombre;
            txtPureza.Text = pureza.ToString();
        }

        #region Events

        private void BtnCrear_Click(object sender, EventArgs e)
        {
            string message = string.Format("Desea crear la cria [{0}] como resultado de la reproduccion?", txtNombre.Text);

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
            txtPureza.ReadOnly = !chkModificar.Checked;
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
