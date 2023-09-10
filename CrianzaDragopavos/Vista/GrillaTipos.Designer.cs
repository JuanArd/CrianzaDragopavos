namespace CrianzaDragopavos.Vista
{
    partial class GrillaTipos
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
            dgvTipos = new DataGridView();
            txtFiltroTipos = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvTipos).BeginInit();
            SuspendLayout();
            // 
            // dgvTipos
            // 
            dgvTipos.AllowUserToAddRows = false;
            dgvTipos.AllowUserToDeleteRows = false;
            dgvTipos.AllowUserToResizeColumns = false;
            dgvTipos.AllowUserToResizeRows = false;
            dgvTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTipos.Location = new Point(12, 55);
            dgvTipos.Name = "dgvTipos";
            dgvTipos.ReadOnly = true;
            dgvTipos.RowHeadersVisible = false;
            dgvTipos.RowTemplate.Height = 25;
            dgvTipos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTipos.Size = new Size(220, 150);
            dgvTipos.TabIndex = 1;
            dgvTipos.DoubleClick += dgvTipos_DoubleClick;
            dgvTipos.KeyDown += dgvTipos_KeyDown;
            // 
            // txtFiltroTipos
            // 
            txtFiltroTipos.Location = new Point(13, 16);
            txtFiltroTipos.Name = "txtFiltroTipos";
            txtFiltroTipos.Size = new Size(219, 23);
            txtFiltroTipos.TabIndex = 0;
            txtFiltroTipos.TextChanged += txtFiltroTipos_TextChanged;
            txtFiltroTipos.KeyDown += txtFiltroTipos_KeyDown;
            // 
            // GrillaTipos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(245, 214);
            Controls.Add(txtFiltroTipos);
            Controls.Add(dgvTipos);
            Name = "GrillaTipos";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GrillaTipos";
            Load += GrillaTipos_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTipos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTipos;
        private TextBox txtFiltroTipos;
    }
}