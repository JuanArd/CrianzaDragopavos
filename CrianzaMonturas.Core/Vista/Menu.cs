using CrianzaDragopavos.Modelo;
using CrianzaDragopavos.Controlador;
using System.Data;
using CrianzaDragopavos.Vista;

namespace CrianzaDragopavos
{
    public partial class Menu : Form
    {
        int tipoMontura;
        readonly List<Montura> monturasHembra = new();
        readonly List<Montura> monturasMacho = new();

        List<Cruce> cruces = new();
        List<Tipo> clases = new();
        List<TipoMontura> tiposMontura = new();

        #region Inicializadores

        public Menu()
        {
            InitializeComponent();
            InicializarCombo();
        }

        private void InicializarCombo()
        {
            tiposMontura = CargarTiposMontura();

            cmbTipoMontura.DataSource = tiposMontura;
            cmbTipoMontura.DisplayMember = "Nombre";
            cmbTipoMontura.ValueMember = "Id";
            cmbTipoMontura.SelectedIndex = 0;

            tipoMontura = 1;

            CargarMonturas();
        }

        private static List<TipoMontura> CargarTiposMontura()
        {
            DataTable dt = new();
            List<TipoMontura> tipoMonturas = new();

            CrianzaMonturas.ObtenerTiposMontura(ref dt);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                int id = Convert.ToInt32(dt.Rows[r][0].ToString());
                string nombre = dt.Rows[r][1].ToString() ?? string.Empty;

                tipoMonturas.Add(new TipoMontura
                {
                    Id = id,
                    Nombre = nombre
                });
            }

            return tipoMonturas;
        }

        private void CargarMonturas()
        {
            DataTable dt = new();
            
            CrianzaMonturas.ObtenerMonturas(ref dt, tipoMontura);

            monturasMacho.Clear();
            monturasMacho.Add(new Montura { Id = 0, Nombre = "", TipoId = 0, Padre = null, Madre = null });
            monturasHembra.Clear();
            monturasHembra.Add(new Montura { Id = 0, Nombre = "", TipoId = 0, Padre = null, Madre = null });

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                Montura montura = CargarMontura(Convert.ToInt32(dt.Rows[r][0].ToString()));

                if (montura.Sexo == "M")
                {
                    monturasMacho.Add(montura);
                }
                else
                {
                    monturasHembra.Add(montura);
                }
            }

            cmbPadre.DataSource = monturasMacho;
            cmbPadre.DisplayMember = "Nombre";
            cmbPadre.ValueMember = "Id";
            cmbPadre.SelectedIndex = 0;

            cmbMadre.DataSource = monturasHembra;
            cmbMadre.DisplayMember = "Nombre";
            cmbMadre.ValueMember = "Id";
            cmbMadre.SelectedIndex = 0;
        }

        private List<Tipo> CargarTipos()
        {
            DataTable dt = new();
            List<Tipo> tipos = new();

            CrianzaMonturas.ObtenerTipo(ref dt, tipoMontura);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                int id = Convert.ToInt32(dt.Rows[r][1].ToString());

                string alias = dt.Rows[r][2].ToString() ?? string.Empty;
                string nombre = dt.Rows[r][3].ToString() ?? string.Empty;
                byte[] imagen = dt.Rows[r][4] != DBNull.Value ? (Byte[])dt.Rows[r][4] : Array.Empty<byte>();
                string sigla = dt.Rows[r][5].ToString() ?? string.Empty;
                int generacion = dt.Rows[r][6] != DBNull.Value ? Convert.ToInt32(dt.Rows[r][6].ToString()) : 0;

                tipos.Add(new Tipo
                {
                    Id = id,
                    Alias = alias,
                    Nombre = nombre,
                    Imagen = imagen,
                    Sigla = sigla,
                    Generacion = generacion
                }
                );

            }

            return tipos;
        }

        private List<Cruce> CargarCruces()
        {
            DataTable dt = new();
            List<Cruce> posiblesCruces = new();

            CrianzaMonturas.ObtenerCruces(ref dt, tipoMontura);

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                posiblesCruces.Add(new Cruce
                {
                    Tipo1 = Convert.ToInt32(dt.Rows[r][2].ToString()),
                    Tipo2 = Convert.ToInt32(dt.Rows[r][3].ToString()),
                    TipoResultado = Convert.ToInt32(dt.Rows[r][4].ToString())
                });
            }

            return posiblesCruces;
        }

        #endregion Inicializadores

        #region Metodos

        private Montura CargarMontura(int id)
        {
            DataTable dt = new();

            CrianzaMonturas.ObtenerMontura(ref dt, id);

            Montura montura = new()
            {
                Id = Convert.ToInt32(dt.Rows[0][0].ToString()),
                Nombre = dt.Rows[0][1].ToString() ?? string.Empty,
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

        private int ObtenerCruce(int tipo1, int tipo2)
        {
            int resultado = 0;
            Cruce? cruce = cruces.Find(x => x.Tipo1 == tipo1 && x.Tipo2 == tipo2);

            return cruce != null ? cruce.TipoResultado : resultado;
        }

        private void CargarPadresMadres(Montura raiz, string prefix, int generacion)
        {
            if (raiz.Id == 0 || raiz == null) return;

            Montura currRaiz = raiz;

            string pbxPrefix = prefix;

            CargarLabelReproducciones(prefix, generacion, currRaiz);

            CargarImagen(currRaiz, pbxPrefix);

            CargarPadre(generacion, currRaiz, pbxPrefix);

            pbxPrefix = prefix;

            CargarMadre(generacion, currRaiz, pbxPrefix);

        }

        private void CargarMadre(int generacion, Montura raiz, string pbxPrefix)
        {
            if (raiz.Madre != null && generacion > 1)
            {
                pbxPrefix += "M";
                CargarPadresMadres(raiz.Madre, pbxPrefix, generacion - 1);
            }
            else if (raiz.Madre != null && generacion == 1)
            {
                pbxPrefix += "M";
                CargarImagen(raiz.Madre, pbxPrefix);
            }
        }

        private void CargarPadre(int generacion, Montura raiz, string pbxPrefix)
        {
            if (raiz.Padre != null && generacion > 1)
            {
                pbxPrefix += "P";
                CargarPadresMadres(raiz.Padre, pbxPrefix, generacion - 1);
            }
            else if (raiz.Padre != null && generacion == 1)
            {
                pbxPrefix += "P";
                CargarImagen(raiz.Padre, pbxPrefix);
            }
        }

        private void CargarLabelReproducciones(string prefix, int generacion, Montura raiz)
        {
            if (generacion == 3)
            {
                if (prefix == "P")
                {
                    lblReproduccionesPadre.Text = raiz.Reproducciones.ToString() + " / " + raiz.MaxReproducciones;
                }
                else if (prefix == "M")
                {
                    lblReproduccionesMadre.Text = raiz.Reproducciones.ToString() + " / " + raiz.MaxReproducciones;
                }
            }
        }

        private void CargarImagen(Montura montura, string sufixPbx)
        {

            string nombrePbx = "pbx" + sufixPbx;
            PictureBox pbx = (PictureBox)this.Controls[nombrePbx]!;
            pbx.Tag = montura.TipoId;

            if (clases == null || montura.TipoId != 0)
            {
                pbx.Image = null;
            }
            else
            {
                Byte[] image = clases.Find(x => x.Id == montura.TipoId)!.Imagen;
                MemoryStream ms = new(image);
                pbx.Image = Image.FromStream(ms);
            }
        }

        private void LimpiarArbol(string prefix)
        {
            string pbxPrefix = "pbx" + prefix;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox pbx)
                {
                    if (pbx.Name.StartsWith(pbxPrefix) && pbx.Name != pbxPrefix)
                    {
                        pbx.Tag = null;
                        pbx.Image = null;
                    }
                }
            }
        }

        private void RellenarPbx(string prefix)
        {
            string pbxPrefix = "pbx" + prefix;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox pbx)
                {
                    if (pbx.Name.StartsWith(pbxPrefix) && pbx.Tag == null)
                    {
                        pbx.Tag = 0;
                    }
                }
            }
        }

        private void CargarPuntosJerarquia(ref Dictionary<int, double> puntosPadre, ref Dictionary<int, double> puntosMadre)
        {
            int puntos = 0;

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is PictureBox pbx)
                {
                    string sufix = pbx.Name.Replace("pbx", "");
                    int tipoMonturaActual = (int)pbx.Tag!;

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
                            puntos = 0;
                            break;
                    }

                    if (sufix.StartsWith("P"))
                    {
                        puntosPadre[tipoMonturaActual] += puntos;
                    }
                    else
                    {
                        puntosMadre[tipoMonturaActual] += puntos;
                    }
                }
            }
        }

        private void CrearFormsResultados(List<Resultado> resultados)
        {
            try
            {
                int consecutivo = 0;
                pnlResultados.Visible = true;
                pnlResultados.Dock = DockStyle.Fill;
                pnlResultados.BringToFront();
                flpResultados.Visible = true;
                flpResultados.BringToFront();

                foreach (Resultado res in resultados)
                {
                    Label lblNombre = new();
                    Label lblPorcentaje = new();
                    PictureBox pbxImagen = new();
                    Panel pnlResultado = new();

                    lblNombre.Text = res.Tipo.Nombre;
                    lblNombre.Name = "lblNombre" + consecutivo.ToString();
                    lblNombre.Size = new Size(100, 25);
                    lblNombre.AutoSize = false;
                    lblNombre.Font = new Font("Segoe UI", 7);
                    lblNombre.Dock = DockStyle.Bottom;
                    lblNombre.TextAlign = ContentAlignment.MiddleLeft;
                    lblNombre.Cursor = Cursors.Hand;

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
                    MemoryStream ms = new(res.Tipo.Imagen);
                    pbxImagen.Image = Image.FromStream(ms);
                    pbxImagen.SizeMode = PictureBoxSizeMode.Zoom;
                    pbxImagen.Cursor = Cursors.Hand;
                    pbxImagen.BorderStyle = BorderStyle.FixedSingle;
                    pbxImagen.Tag = res.Tipo;
                    pbxImagen.Click += PbxResultado_Click;

                    pnlResultado.Size = new Size(100, 150);

                    pnlResultado.Controls.Add(lblPorcentaje);
                    pnlResultado.Controls.Add(lblNombre);
                    pnlResultado.Controls.Add(pbxImagen);
                    pnlResultado.Margin = new Padding(21);

                    flpResultados.Controls.Add(pnlResultado);

                    consecutivo++;
                }
            }
            catch 
            {
                MessageBox.Show("No fue posible mostrar los resultados");
            }
        }

        private void CerrarReproduccion()
        {
            Montura padre = (Montura)cmbPadre.SelectedItem;
            Montura madre = (Montura)cmbMadre.SelectedItem;

            bool updated = CrianzaMonturas.CerrarReproduccion(padre.Id, madre.Id);

            if (updated)
            {
                MessageBox.Show("Se generaron crias con Exito!", "Generacion de crias");
                LimpiarCalculadora();
            }
        }

        private void CalcularReproducciones()
        {
            Montura madre = (Montura)cmbMadre.SelectedItem;
            Montura padre = (Montura)cmbPadre.SelectedItem;

            if (madre.Id == 0 || padre.Id == 0)
            {
                return;
            }

            //
            Dictionary<int, double> cantTiposPadre = new();
            Dictionary<int, double> cantTiposMadre = new();
            Dictionary<int, double> cantTiposTotal = new();
            Dictionary<int, double> cantTiposPorcentaje = new();

            double porcentajeMayor = 0;

            //
            int posiblesResultados = 0;

            CargarCantTipos(ref cantTiposPadre, ref cantTiposMadre, ref cantTiposTotal, ref cantTiposPorcentaje);

            // Aumentando cantidad dependiendo jerarquia y predisposicion
            if (madre.Predispuesto) cantTiposPadre[madre.TipoId] += 10;

            if (padre.Predispuesto) cantTiposMadre[padre.TipoId] += 10;

            CargarPuntosJerarquia(ref cantTiposPadre, ref cantTiposMadre);

            CalcularPorcentajePorPadre(ref cantTiposPadre, ref cantTiposMadre);

            CalcularPorcentajeResultados(cantTiposPadre, cantTiposMadre, ref cantTiposTotal);

            CalcularPorcentajeTotal(ref cantTiposTotal);

            ValidarOrdenarResultados(cantTiposTotal, ref cantTiposPorcentaje, ref porcentajeMayor, ref posiblesResultados);

            MostrarResultados(posiblesResultados, cantTiposPorcentaje, porcentajeMayor);

        }

        private void MostrarResultados(int posiblesResultados, Dictionary<int, double> cantTiposPorcentaje, double porcentajeMayor)
        {
            // Mostrando Resultados
            List<Resultado> resultados = new();
            int i = 0;
            double porcAnterior = 0;

            while (i < posiblesResultados)
            {
                for (int c = 1; c < 67; c++)
                {
                    if (cantTiposPorcentaje[c] == porcentajeMayor)
                    {
                        Tipo Tipo = clases.Find(x => x.Id == c) ?? clases.First();
                        resultados.Add(new Resultado(Tipo, cantTiposPorcentaje[c]));
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

            CrearFormsResultados(resultados);
        }

        private static void ValidarOrdenarResultados(Dictionary<int, double> cantTiposTotal, ref Dictionary<int, double> cantTiposPorcentaje, ref double porcentajeMayor, ref int posiblesResultados)
        {
            // Cantidad de posibles resultados y ordenamiento por procentaje
            for (int k = 1; k < 67; k++)
            {
                cantTiposPorcentaje[k] = Math.Round(cantTiposTotal[k] * 10000) / 100;

                if (cantTiposPorcentaje[k] > 0) posiblesResultados++;

                if (cantTiposPorcentaje[k] > porcentajeMayor) porcentajeMayor = cantTiposPorcentaje[k];
            }
        }

        private static void CalcularPorcentajeTotal(ref Dictionary<int, double> cantTiposTotal)
        {
            double totalTipos = 0;

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
        }

        private void CargarCantTipos(ref Dictionary<int, double> cantTiposPadre, ref Dictionary<int, double> cantTiposMadre, ref Dictionary<int, double> cantTiposTotal, ref Dictionary<int, double> cantTiposPorcentaje)
        {
            foreach (Tipo tipo in clases)
            {
                cantTiposPadre.Add(tipo.Id, 0);
                cantTiposMadre.Add(tipo.Id, 0);
                cantTiposTotal.Add(tipo.Id, 0);
                cantTiposPorcentaje.Add(tipo.Id, 0);
            }
        }

        private void CalcularPorcentajeResultados(Dictionary<int, double> cantTiposPadre, Dictionary<int, double> cantTiposMadre, ref Dictionary<int, double> cantTiposTotal)
        {
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
        }

        private static void CalcularPorcentajePorPadre(ref Dictionary<int, double> cantTiposPadre, ref Dictionary<int, double> cantTiposMadre)
        {
            double totalTiposPadres = 0;
            double totalTiposMadres = 0;

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
        }

        private static void AparearMonturas(Montura pPadre, Montura pMadre)
        {
            bool inserted = CrianzaMonturas.InsertarReproduccion(pPadre.Id, pMadre.Id);

            if (inserted)
            {
                MessageBox.Show("Monturas apareadas con Exito!", "Apareacion de Monturas");
            }
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

        private void GenerarCria(Tipo pCria, Montura pPadre, Montura pMadre)
        {
            CrearCria frmCrear = new(pCria);
            DialogResult frmCria = frmCrear.ShowDialog();

            if (frmCria == DialogResult.OK)
            {
                bool inserted = CrianzaMonturas.InsertarCria(frmCrear.Nombre, frmCrear.Sexo, tipoMontura, pCria.Id, frmCrear.Predispuesto,
                    pPadre.Id, pMadre.Id, out int idCria);

                if (inserted)
                {
                    bool updated = CrianzaMonturas.ActualizarReproduccion(idCria, pPadre.Id, pMadre.Id);

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

        #endregion Metodos

        #region Eventos

        private void CmbTipoMontura_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoMontura = ((TipoMontura)cmbTipoMontura.SelectedItem).Id;
            
            clases = CargarTipos();
            cruces = CargarCruces();
        }

        private void CmbPadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarArbol("P");
            Montura padre = (Montura)cmbPadre.SelectedItem;

            if (padre != null)
            {
                CargarPadresMadres(padre, "P", 3);
                RellenarPbx("P");
            }
        }

        private void CmbMadre_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarArbol("M");
            Montura madre = (Montura)cmbMadre.SelectedItem;

            if (madre != null)
            {
                CargarPadresMadres(madre, "M", 3);
                RellenarPbx("M");
            }
        }

        private void BtnCalcular_Click(object sender, EventArgs e)
        {
            CalcularReproducciones();
        }

        private void PbxResultado_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                PictureBox res = (PictureBox)sender;
                GenerarCria((Tipo)res.Tag, (Montura)cmbPadre.SelectedItem, (Montura)cmbMadre.SelectedItem);
            }
        }

        private void Pbx_Click(object sender, EventArgs e)
        {
            PictureBox pbx = (PictureBox)sender;
            GrillaTipos frmGrilla = new(clases);
            DialogResult result = frmGrilla.ShowDialog();

            if (result == DialogResult.OK)
            {
                if (frmGrilla.ValueSelected["Id"].Value.ToString() != "0")
                {
                    Byte[] image = (byte[])frmGrilla.ValueSelected["Imagen"].Value;
                    MemoryStream ms = new(image);
                    pbx.Image = Image.FromStream(ms);
                }
                else
                {
                    pbx.Image = null;
                }

                pbx.Tag = Convert.ToInt32(frmGrilla.ValueSelected["Id"].Value.ToString());
            }
        }

        private void MnuCalculadora_Click(object sender, EventArgs e)
        {
            LimpiarCalculadora();
        }

        private void BtnReproducir_Click(object sender, EventArgs e)
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

        private void BtnCerrarReproduccion_Click(object sender, EventArgs e)
        {
            CerrarReproduccion();
        }

        #endregion Eventos      
        
    }
}