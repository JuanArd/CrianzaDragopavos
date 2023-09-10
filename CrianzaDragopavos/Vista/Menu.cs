using CrianzaDragopavos.Modelo;
using CrianzaDragopavos.Controlador;
using System.Data;
using CrianzaDragopavos.Vista;

namespace CrianzaDragopavos
{
    public partial class Menu : Form
    {
        int TipoMontura = 0;
        List<TipoMontura> tiposMontura;
        List<Tipo> tipos;
        List<Montura> monturas;
        List<Montura> monturasMacho;
        List<Montura> monturasHembra;
        List<Cruce> cruces;

        public Menu()
        {
            InitializeComponent();

            tiposMontura = CargarTiposMontura();

            cmbTipoMontura.DataSource = tiposMontura;
            cmbTipoMontura.DisplayMember = "Nombre";
            cmbTipoMontura.ValueMember = "Id";
            cmbTipoMontura.SelectedIndex = 0;
            TipoMontura = 1;
        }

        private List<TipoMontura> CargarTiposMontura()
        {
            DataTable dt = new DataTable();
            List<TipoMontura> tipoMonturas = new List<TipoMontura>();

            CrianzaMonturas cd = new CrianzaMonturas();
            cd.ObtenerTiposMontura(ref dt);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                tipoMonturas.Add(new TipoMontura
                {
                    Id = Convert.ToInt32(dt.Rows[r][0].ToString()),
                    Nombre = dt.Rows[r][1].ToString()
                });
            }

            return tipoMonturas;
        }

        private List<Montura> CargarMonturas()
        {
            DataTable dt = new DataTable();
            List<Montura> monturas = new List<Montura>();

            CrianzaMonturas cd = new CrianzaMonturas();
            cd.ObtenerMonturas(ref dt, TipoMontura);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                monturas.Add(new Montura
                {
                    Id = Convert.ToInt32(dt.Rows[r][0].ToString()),
                    Nombre = dt.Rows[r][1].ToString(),
                    Salvaje = Convert.ToBoolean(dt.Rows[r][2].ToString()),
                    Sexo = dt.Rows[r][3].ToString(),
                    TipoId = Convert.ToInt32(dt.Rows[r][5].ToString()),
                    Predispuesto = Convert.ToBoolean(dt.Rows[r][6].ToString()),
                    Padre = Convert.ToInt32(dt.Rows[r][7].ToString()) == 0 ? null : CargarMontura(Convert.ToInt32(dt.Rows[r][7].ToString())),
                    Madre = Convert.ToInt32(dt.Rows[r][8].ToString()) == 0 ? null : CargarMontura(Convert.ToInt32(dt.Rows[r][8].ToString())),
                    Reproducciones = Convert.ToInt32(dt.Rows[r][9].ToString()),
                    MaxReproducciones = Convert.ToInt32(dt.Rows[r][10].ToString()),
                    Esteril = Convert.ToBoolean(dt.Rows[r][11].ToString())
                });
            }

            monturasMacho.Clear();
            monturasMacho.Add(new Montura { Id = 0, Nombre = "", TipoId = 0, Padre = null, Madre = null });
            monturasHembra.Clear();
            monturasHembra.Add(new Montura { Id = 0, Nombre = "", TipoId = 0, Padre = null, Madre = null });

            foreach (Montura m in monturas)
            {
                Montura monturaActual = m;
                if (m.Sexo == "M")
                    monturasMacho.Add(monturaActual);
                else
                    monturasHembra.Add(monturaActual);
            }

            cmbPadre.DataSource = monturasMacho;
            cmbPadre.DisplayMember = "Nombre";
            cmbPadre.ValueMember = "Id";
            cmbPadre.SelectedIndex = 0;

            cmbMadre.DataSource = monturasHembra;
            cmbMadre.DisplayMember = "Nombre";
            cmbMadre.ValueMember = "Id";
            cmbMadre.SelectedIndex = 0;

            return monturas;
        }

        private Montura CargarMontura(int id)
        {
            DataTable dt = new DataTable();

            CrianzaMonturas cd = new CrianzaMonturas();
            cd.ObtenerMontura(ref dt, id);

            Montura montura = new Montura
            {
                Id = Convert.ToInt32(dt.Rows[0][0].ToString()),
                Nombre = dt.Rows[0][1].ToString(),
                Salvaje = Convert.ToBoolean(dt.Rows[0][2].ToString()),
                Sexo = dt.Rows[0][3].ToString(),
                TipoId = Convert.ToInt32(dt.Rows[0][5].ToString()),
                Predispuesto = Convert.ToBoolean(dt.Rows[0][6].ToString()),
                Padre = Convert.ToInt32(dt.Rows[0][7].ToString()) == 0 ? null : CargarMontura(Convert.ToInt32(dt.Rows[0][7].ToString())),
                Madre = Convert.ToInt32(dt.Rows[0][8].ToString()) == 0 ? null : CargarMontura(Convert.ToInt32(dt.Rows[0][8].ToString())),
                Reproducciones = Convert.ToInt32(dt.Rows[0][9].ToString()),
                MaxReproducciones = Convert.ToInt32(dt.Rows[0][10].ToString()),
                Esteril = Convert.ToBoolean(dt.Rows[0][11].ToString())
            };

            return montura;
        }

        private List<Tipo> CargarTipos()
        {
            DataTable dt = new DataTable();
            List<Tipo> tipos = new List<Tipo>();

            CrianzaMonturas cd = new CrianzaMonturas();
            cd.ObtenerTipo(ref dt, TipoMontura);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                if (Convert.ToInt32(dt.Rows[r][1].ToString()) == 0)
                {
                    tipos.Add(new Tipo
                    {
                        Id = Convert.ToInt32(dt.Rows[r][1].ToString())
                    });
                }
                else
                {
                    tipos.Add(new Tipo
                    {
                        Id = Convert.ToInt32(dt.Rows[r][1].ToString()),
                        Alias = dt.Rows[r][2].ToString(),
                        Nombre = dt.Rows[r][3].ToString(),
                        Imagen = (Byte[])dt.Rows[r][4],
                        Sigla = dt.Rows[r][5].ToString(),
                        Generacion = Convert.ToInt32(dt.Rows[r][6].ToString())
                    });
                }
            }

            return tipos;
        }

        private List<Cruce> CargarCruces()
        {
            DataTable dt = new DataTable();
            List<Cruce> cruces = new List<Cruce>();

            CrianzaMonturas cd = new CrianzaMonturas();
            cd.ObtenerCruces(ref dt, TipoMontura);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                cruces.Add(new Cruce
                {
                    Tipo1 = Convert.ToInt32(dt.Rows[r][2].ToString()),
                    Tipo2 = Convert.ToInt32(dt.Rows[r][3].ToString()),
                    TipoResultado = Convert.ToInt32(dt.Rows[r][4].ToString())
                });
            }

            return cruces;
        }

        private int ObtenerCruce(int tipo1, int tipo2)
        {
            int resultado = 0;
            Cruce? cruce = cruces.Find(x => x.Tipo1 == tipo1 && x.Tipo2 == tipo2);

            if (cruce != null)
                resultado = cruce.TipoResultado;

            return resultado;
        }

        private void cmbTipoMontura_SelectedIndexChanged(object sender, EventArgs e)
        {

            monturasHembra = new List<Montura>();
            monturasMacho = new List<Montura>();

            TipoMontura = ((TipoMontura)cmbTipoMontura.SelectedItem).Id;
            tipos = CargarTipos();
            cruces = CargarCruces();
            monturas = CargarMonturas();
        }

        private void cmbPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarArbol("P");
            Montura padre = (Montura)cmbPadre.SelectedItem;

            if (padre != null)
            {
                CargarPadres(padre, "P", 3);
                RellenarPbx("P");
            }
        }

        private void cmbMadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarArbol("M");
            Montura madre = (Montura)cmbMadre.SelectedItem;

            if (madre != null)
            {
                CargarPadres(madre, "M", 3);
                RellenarPbx("M");
            }
        }

        private void CargarPadres(Montura pRaiz, string pPrefix, int generacion)
        {
            Montura raiz = pRaiz;

            if (raiz.Id != 0)
            {
                string pbxPrefix = pPrefix;

                if (pPrefix == "P" && generacion == 3)
                    lblReproduccionesPadre.Text = raiz.Reproducciones.ToString() + " / " + raiz.MaxReproducciones;
                else if (pPrefix == "M" && generacion == 3)
                    lblReproduccionesMadre.Text = raiz.Reproducciones.ToString() + " / " + raiz.MaxReproducciones;

                CargarImagen(raiz, pbxPrefix);

                if (raiz.Padre != null && generacion > 1)
                {
                    pbxPrefix += "P";
                    CargarPadres(raiz.Padre, pbxPrefix, generacion - 1);
                }
                else if (raiz.Padre != null && generacion == 1)
                {
                    pbxPrefix += "P";
                    CargarImagen(raiz.Padre, pbxPrefix);
                }

                pbxPrefix = pPrefix;

                if (raiz.Madre != null && generacion > 1)
                {
                    pbxPrefix += "M";
                    CargarPadres(raiz.Madre, pbxPrefix, generacion - 1);
                }
                else if (raiz.Madre != null && generacion == 1)
                {
                    pbxPrefix += "M";
                    CargarImagen(raiz.Madre, pbxPrefix);
                }
            }

        }

        private void CargarImagen(Montura montura, string sufixPbx)
        {
            string nombrePbx = "pbx" + sufixPbx;
            PictureBox pbx = (PictureBox)this.Controls[nombrePbx];
            pbx.Tag = montura.TipoId;

            if (montura.TipoId != 0)
            {
                Byte[] image = tipos.Find(x => x.Id == montura.TipoId).Imagen;
                MemoryStream ms = new MemoryStream(image);
                pbx.Image = Image.FromStream(ms);
            }
            else
            {
                pbx.Image = null;
            }

        }

        private void LimpiarArbol(string pPrefix)
        {
            string prefix = "pbx" + pPrefix;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                {
                    PictureBox pbx = (PictureBox)ctrl;

                    if (pbx.Name.StartsWith(prefix) && pbx.Name != prefix)
                    {
                        pbx.Tag = null;
                        pbx.Image = null;
                    }
                }
            }
        }

        private void RellenarPbx(string pPrefix)
        {
            string prefix = "pbx" + pPrefix;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                {
                    PictureBox pbx = (PictureBox)ctrl;

                    if (pbx.Name.StartsWith(prefix) && pbx.Tag == null)
                    {
                        pbx.Tag = 0;
                    }
                }
            }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            
            Montura madre = (Montura)cmbMadre.SelectedItem;
            Montura padre = (Montura)cmbPadre.SelectedItem;

            if (madre.Id != 0 && padre.Id != 0)
            {
                //
                Dictionary<int, double> cantTiposPadre = new Dictionary<int, double>();
                Dictionary<int, double> cantTiposMadre = new Dictionary<int, double>();
                Dictionary<int, double> cantTiposTotal = new Dictionary<int, double>();
                Dictionary<int, double> cantTiposPorcentaje = new Dictionary<int, double>();
                double totalTiposPadres = 0;
                double totalTiposMadres = 0;
                double totalTipos = 0;
                double porcentajeMayor = 0;

                //
                List<Resultado> resultados = new List<Resultado>();
                int posiblesResultados = 0;

                foreach (Tipo tipo in tipos)
                {
                    cantTiposPadre.Add(tipo.Id, 0);
                    cantTiposMadre.Add(tipo.Id, 0);
                    cantTiposTotal.Add(tipo.Id, 0);
                    cantTiposPorcentaje.Add(tipo.Id, 0);
                }

                // Aumentando cantidad dependiendo jerarquia y predisposicion
                if (madre.Predispuesto)
                    cantTiposPadre[madre.TipoId] += 10;

                if (padre.Predispuesto)
                    cantTiposMadre[padre.TipoId] += 10;

                CargarPuntosJerarquia(ref cantTiposPadre, ref cantTiposMadre);

                // Total de puntos Madre / Padre
                for (int k = 1; k < 67; k++)
                {
                    totalTiposPadres += cantTiposPadre[k];
                    totalTiposMadres += cantTiposMadre[k];
                }

                // Total porcentaje Madre / Padre
                for (int k = 1; k < 67; k++)
                {
                    cantTiposPadre[k] = cantTiposPadre[k] / totalTiposPadres;
                    cantTiposMadre[k] = cantTiposMadre[k] / totalTiposMadres;
                }

                // Calculando probabilidad total
                for (int k1 = 1; k1 < 67; k1++)
                {
                    for (int k2 = 1; k2 < 67; k2++)
                    {
                        cantTiposTotal[k1] += (0.45) * cantTiposPadre[k1] * cantTiposMadre[k2];
                        cantTiposTotal[k2] += (0.45) * cantTiposPadre[k1] * cantTiposMadre[k2];
                        cantTiposTotal[ObtenerCruce(k1, k2)] += (0.1) * cantTiposPadre[k1] * cantTiposMadre[k2];
                    }
                }

                // Total de puntos Total
                for (int k = 1; k < 67; k++)
                {
                    totalTipos += cantTiposTotal[k];
                }

                // Porcentaje del Total
                for (int k = 1; k < 67; k++)
                {
                    cantTiposTotal[k] = cantTiposTotal[k] / totalTipos;
                }

                // Cantidad de posibles resultados y ordenamiento por procentaje
                for (int k = 1; k < 67; k++)
                {
                    cantTiposPorcentaje[k] = Math.Round(cantTiposTotal[k] * 10000) / 100;

                    if (cantTiposPorcentaje[k] > 0)
                        posiblesResultados++;

                    if (cantTiposPorcentaje[k] > porcentajeMayor)
                        porcentajeMayor = cantTiposPorcentaje[k];
                }

                // Mostrando Resultados
                int i = 0;
                string resultado = string.Empty;
                string frmt = "{0}: {1}{2}";
                double porcAnterior = 0;

                while (i < posiblesResultados)
                {
                    for (int c = 1; c < 67; c++)
                    {
                        if (cantTiposPorcentaje[c] == porcentajeMayor)
                        {
                            Tipo Tipo = tipos.Find(x => x.Id == c) ?? tipos.First();
                            resultados.Add(new Resultado { Tipo = Tipo, Porcentaje = cantTiposPorcentaje[c] });
                            //resultado += string.Format("{0}{1}: {2} %", Environment.NewLine, Tipo.Nombre, cantTiposPorcentaje[c]);
                            i++;
                        }
                    }

                    porcAnterior = porcentajeMayor;
                    porcentajeMayor = 0;

                    for (int c = 1; c < 67; c++)
                    {
                        if ((cantTiposPorcentaje[c] > porcentajeMayor) && (cantTiposPorcentaje[c] < porcAnterior))
                        {
                            porcentajeMayor = cantTiposPorcentaje[c];
                        }
                    }
                }

                MostrarResultados(resultados);
                //MessageBox.Show(resultado, "Resultados");
            }

        }

        private void CargarPuntosJerarquia(ref Dictionary<int, double> puntosPadre, ref Dictionary<int, double> puntosMadre)
        {
            string prefix = "pbx";
            int puntos = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox)
                {
                    PictureBox pbx = (PictureBox)ctrl;
                    string sufix = pbx.Name.Replace("pbx", "");
                    int tipoMontura = (int)pbx.Tag;

                    switch (sufix.Length)
                    {
                        case 1:
                            puntos = 10;
                            break;
                        case 2:
                            puntos = 6;
                            break;
                        case 3:
                            puntos = 3;
                            break;
                        case 4:
                            puntos = 1;
                            break;
                        default:
                            break;
                    }

                    if (sufix.StartsWith("P"))
                        puntosPadre[tipoMontura] += puntos;
                    else
                        puntosMadre[tipoMontura] += puntos;
                }
            }
        }

        private void MostrarResultados(List<Resultado> pResultados)
        {
            try
            {
                int consecutivo = 0;
                pnlResultados.Visible = true;
                pnlResultados.Dock = DockStyle.Fill;
                pnlResultados.BringToFront();
                flpResultados.Visible = true;
                flpResultados.BringToFront();

                foreach (Resultado res in pResultados)
                {
                    Label lblNombre = new Label();
                    Label lblPorcentaje = new Label();
                    PictureBox pbxImagen = new PictureBox();
                    Panel pnlResultado = new Panel();

                    lblNombre.Text = res.Tipo.Nombre;
                    lblNombre.Name = "lblNombre" + consecutivo.ToString();
                    lblNombre.Size = new Size(100, 25);
                    lblNombre.AutoSize = false;
                    lblNombre.Font = new Font("Segoe UI", 7);
                    lblNombre.Dock = DockStyle.Bottom;
                    lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                    lblNombre.Cursor = Cursors.Hand;
                    //lblNombre.BorderStyle = BorderStyle.FixedSingle;

                    lblPorcentaje.Text = res.Porcentaje.ToString() + " %";
                    lblPorcentaje.Name = "lblPorcentaje" + consecutivo.ToString();
                    lblPorcentaje.Size = new Size(100, 25);
                    lblNombre.Font = new Font("Segoe UI", 7);
                    lblPorcentaje.Dock = DockStyle.Bottom;
                    lblPorcentaje.TextAlign = ContentAlignment.MiddleLeft;
                    lblPorcentaje.Cursor = Cursors.Hand;

                    pbxImagen.Size = new Size(100, 100);
                    pbxImagen.Dock = DockStyle.Top;
                    pbxImagen.BackgroundImage = null;
                    MemoryStream ms = new MemoryStream(res.Tipo.Imagen);
                    pbxImagen.Image = Image.FromStream(ms);
                    pbxImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    pbxImagen.Cursor = Cursors.Hand;
                    pbxImagen.BorderStyle = BorderStyle.FixedSingle;
                    pbxImagen.Tag = res.Tipo;
                    pbxImagen.Click += pbxResultado_Click;

                    pnlResultado.Size = new Size(100, 150);

                    pnlResultado.Controls.Add(lblPorcentaje);
                    pnlResultado.Controls.Add(lblNombre);
                    pnlResultado.Controls.Add(pbxImagen);
                    pnlResultado.Margin = new Padding(21);

                    flpResultados.Controls.Add(pnlResultado);

                    consecutivo++;
                }
            }
            catch { }
        }

        private void pbxResultado_Click(object sender, EventArgs e)
        {
            PictureBox res = (PictureBox)sender;
            GenerarCria((Tipo)res.Tag, (Montura)cmbPadre.SelectedItem, (Montura)cmbMadre.SelectedItem);
        }

        private void GenerarCria(Tipo pCria, Montura pPadre, Montura pMadre)
        {
            int idCria;

            CrearCria frmCrear = new CrearCria(pCria);
            DialogResult frmCria = frmCrear.ShowDialog();

            if (frmCria == DialogResult.OK)
            {
                CrianzaMonturas cm = new CrianzaMonturas();
                bool inserted = cm.InsertarCria(frmCrear.Nombre, frmCrear.Sexo, TipoMontura, pCria.Id, frmCrear.Predispuesto, pPadre.Id, pMadre.Id, out idCria);

                if (inserted)
                {
                    bool updated = cm.ActualizarReproduccion(idCria, pPadre.Id, pMadre.Id);

                    if (updated)
                    {
                        string mensaje = string.Format("Cria generada con Exito!{0}¿Desea cerrar la reproducción?", Environment.NewLine);

                        DialogResult cerrarCria = MessageBox.Show(mensaje, "Generacion de cria", MessageBoxButtons.YesNo);

                        if (cerrarCria == DialogResult.Yes)
                        {
                            CerrarReproduccion();
                        }
                    }
                }
            }
        }

        private void pbx_Click(object sender, EventArgs e)
        {
            PictureBox pbx = (PictureBox)sender;
            GrillaTipos frmGrilla = new GrillaTipos(tipos);
            DialogResult result = frmGrilla.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (frmGrilla.ValueSelected["Id"].Value.ToString() != "0")
                {
                    Byte[] image = (byte[])frmGrilla.ValueSelected["Imagen"].Value;
                    MemoryStream ms = new MemoryStream(image);
                    pbx.Image = Image.FromStream(ms);
                }
                else
                {
                    pbx.Image = null;
                }

                pbx.Tag = Convert.ToInt32(frmGrilla.ValueSelected["Id"].Value.ToString());
            }
        }

        private void mnuCalculadora_Click(object sender, EventArgs e)
        {
            LimpiarCalculadora();
        }

        private void LimpiarCalculadora()
        {
            flpResultados.Controls.Clear();
            pnlResultados.SendToBack();
            pnlResultados.Visible = false;
            LimpiarArbol(string.Empty);
            cmbPadre.DataSource = null;
            cmbMadre.DataSource = null;
            CargarMonturas();
            lblReproduccionesMadre.Text = "";
            lblReproduccionesPadre.Text = "";
            pbxP.Image = null;
            pbxM.Image = null;
        }

        private void btnReproducir_Click(object sender, EventArgs e)
        {
            Montura padre = (Montura)cmbPadre.SelectedItem;
            Montura madre = (Montura)cmbMadre.SelectedItem;

            string message = string.Format("Desea aparear estas Monturas?:{0}Padre: [{1}]{0}Madre: [{2}]", Environment.NewLine, padre.Nombre, madre.Nombre);

            DialogResult msg = MessageBox.Show(message, "Aparear Monturas", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (msg == DialogResult.Yes)
            {
                AparearMonturas(padre, madre);
                LimpiarCalculadora();
            }
        }

        private void AparearMonturas(Montura pPadre, Montura pMadre)
        {
            CrianzaMonturas cm = new CrianzaMonturas();
            bool inserted = cm.InsertarReproduccion(pPadre.Id, pMadre.Id);

            if (inserted)
            {
                MessageBox.Show("Monturas apareadas con Exito!", "Apareacion de Monturas");
            }
        }

        private void btnCerrarReproduccion_Click(object sender, EventArgs e)
        {
            CerrarReproduccion();
        }

        private void CerrarReproduccion()
        {
            Montura padre = (Montura)cmbPadre.SelectedItem;
            Montura madre = (Montura)cmbMadre.SelectedItem;

            CrianzaMonturas cm = new CrianzaMonturas();
            bool updated = cm.CerrarReproduccion(padre.Id, madre.Id);

            if (updated)
            {
                MessageBox.Show("Se generaron crias con Exito!", "Generacion de crias");
                LimpiarCalculadora();
            }
        }
    }
}