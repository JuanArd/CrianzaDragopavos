namespace CrianzaMonturas.Core.Vista
{
    partial class CrearCria
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTipo = new Label();
            chkPredispuesto = new CheckBox();
            btnCrear = new Button();
            cmbSexo = new ComboBox();
            txtTipo = new TextBox();
            txtNombre = new TextBox();
            lblNombre = new Label();
            lblSexo = new Label();
            lblPureza = new Label();
            txtPureza = new TextBox();
            chkModificar = new CheckBox();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(12, 9);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(36, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo: ";
            // 
            // chkPredispuesto
            // 
            chkPredispuesto.AutoSize = true;
            chkPredispuesto.Location = new Point(155, 68);
            chkPredispuesto.Name = "chkPredispuesto";
            chkPredispuesto.Size = new Size(94, 19);
            chkPredispuesto.TabIndex = 3;
            chkPredispuesto.Text = "Predispuesto";
            chkPredispuesto.UseVisualStyleBackColor = true;
            // 
            // btnCrear
            // 
            btnCrear.Location = new Point(101, 126);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(75, 23);
            btnCrear.TabIndex = 6;
            btnCrear.Text = "Crear";
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += BtnCrear_Click;
            // 
            // cmbSexo
            // 
            cmbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSexo.FormattingEnabled = true;
            cmbSexo.Items.AddRange(new object[] { "F", "M" });
            cmbSexo.Location = new Point(73, 64);
            cmbSexo.Name = "cmbSexo";
            cmbSexo.Size = new Size(62, 23);
            cmbSexo.TabIndex = 2;
            // 
            // txtTipo
            // 
            txtTipo.Enabled = false;
            txtTipo.Location = new Point(73, 6);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(176, 23);
            txtTipo.TabIndex = 0;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(73, 35);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(176, 23);
            txtNombre.TabIndex = 1;
            txtNombre.Leave += TxtNombre_Leave;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 38);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Location = new Point(12, 67);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(35, 15);
            lblSexo.TabIndex = 6;
            lblSexo.Text = "Sexo:";
            // 
            // lblPureza
            // 
            lblPureza.AutoSize = true;
            lblPureza.Location = new Point(12, 96);
            lblPureza.Name = "lblPureza";
            lblPureza.Size = new Size(45, 15);
            lblPureza.TabIndex = 7;
            lblPureza.Text = "Pureza:";
            // 
            // txtPureza
            // 
            txtPureza.Location = new Point(73, 93);
            txtPureza.Name = "txtPureza";
            txtPureza.ReadOnly = true;
            txtPureza.ScrollBars = ScrollBars.Vertical;
            txtPureza.Size = new Size(62, 23);
            txtPureza.TabIndex = 5;
            txtPureza.KeyPress += TxtPureza_KeyPress;
            // 
            // chkModificar
            // 
            chkModificar.AutoSize = true;
            chkModificar.Location = new Point(155, 95);
            chkModificar.Name = "chkModificar";
            chkModificar.Size = new Size(77, 19);
            chkModificar.TabIndex = 4;
            chkModificar.Text = "Modificar";
            chkModificar.UseVisualStyleBackColor = true;
            chkModificar.CheckedChanged += ChkModificar_CheckedChanged;
            // 
            // CrearCria
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(281, 161);
            Controls.Add(chkModificar);
            Controls.Add(txtPureza);
            Controls.Add(lblPureza);
            Controls.Add(lblSexo);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(txtTipo);
            Controls.Add(cmbSexo);
            Controls.Add(btnCrear);
            Controls.Add(chkPredispuesto);
            Controls.Add(lblTipo);
            Name = "CrearCria";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CrearCria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private CheckBox chkPredispuesto;
        private Button btnCrear;
        private ComboBox cmbSexo;
        private TextBox txtTipo;
        private TextBox txtNombre;
        private Label lblNombre;
        private Label lblSexo;
        private Label lblPureza;
        private TextBox txtPureza;
        private CheckBox chkModificar;
    }
}