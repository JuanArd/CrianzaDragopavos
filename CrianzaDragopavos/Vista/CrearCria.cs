using CrianzaDragopavos.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrianzaDragopavos.Vista
{
    public partial class CrearCria : Form
    {
        public string Nombre;
        public string Sexo;
        public bool Predispuesto;
        
        public CrearCria(Tipo tipo)
        {
            InitializeComponent();
            
            Nombre = tipo.Nombre;
            Sexo = string.Empty;

            txtTipo.Text = Nombre;
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
