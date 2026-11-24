using Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ViewForms
{
    public partial class VFiltros : Form
    {

        private int serie;
        private int cantidadDeConductores;
        private String marcaDelCable;
        private float cambiar;
        private char seccionDelCable;
        private bool libreDeHalogenos;
        private bool fachadaOVivienda;
        private string fechaDeCompra;
        private string fechaDeVencimiento;
        CableElectrico cable;
        private char palabraProcedimientoAlmcenadoEntrada;
        private String palabraProcedimientoAlmcenadoSalida = "";

        private string metros = "";
        private int numeroDeSerie = -200;
        private string fecha = "01/01/0001";
        private long cambiarMetros = 0;
        public VFiltros(int numeroDeserie)
        {
            InitializeComponent();
            this.Size = new Size(357, 260);
            this.NumeroDeSerie = numeroDeserie;
            lBNumeroDeSerie.Text = "Numero de serie:";
            gBAñadir.Visible = false;
        }
        public VFiltros(bool añadir)
        {
            InitializeComponent();
            this.Size = new Size(357, 449);
            gBDatos.Visible = false;
            rBFachada.Checked = true;
            rBLibre.Checked = true;
            Cable = new CableElectrico();
        }
        public VFiltros(DateTime fecha)
        {
            InitializeComponent();
            this.Size = new Size(357, 260);
            this.Fecha = fecha.ToString();
            lBNumeroDeSerie.Text = "Fecha de compra:";
            gBAñadir.Visible = false;


        }
        public VFiltros(string informacion)
        {
            InitializeComponent();
            this.Size = new Size(357, 260);
            this.metros = informacion;
            lBNumeroDeSerie.Text = "Numero de metros:";
            gBAñadir.Visible = false;


        }
        public VFiltros(char informacion)
        {
            InitializeComponent();
            this.Size = new Size(357, 260);
            lBNumeroDeSerie.Text = "Introduce una palabra:";
            this.palabraProcedimientoAlmcenadoEntrada = informacion;
            gBAñadir.Visible = false;


        }
        public VFiltros(CableElectrico cable)
        {
            InitializeComponent();
            this.Cable1 = cable;
            this.Size = new Size(357, 449);
            gBDatos.Visible = false;
            rBFachada.Checked = true;
            rBLibre.Checked = true;
            Cable = cable;
            nUDNumeroDeSerie.Enabled = false;
            serie = (int)(nUDNumeroDeSerie.Value = cable.NumeroDeSerie);
            cantidadDeConductores = (int)(nUDCantidadDeConductores.Value = cable.CantidadDeConductores);
            marcaDelCable = (tBMarca.Text = cable.MarcaDelCable);
            cambiar = (float)(nUDNumeroDeMetros.Value = (int)cable.Metros);
            seccionDelCable = char.Parse(tBSeccion.Text = cable.SeccionDelCable.ToString());
            fechaDeCompra = tBFechaDeCompra.Text = cable.FechaDeCompra.ToString("dd-MM-yyyy");
            fechaDeVencimiento = tBFechaDeVenta.Text = cable.FechaDeVencimiento.ToString("dd-MM-yyyy");
            if (libreDeHalogenos = cable.LibreDeHalogenos == true)
            {
                rBLibre.Checked = true;
            }
            else
            {
                rBNoLibre.Checked = true;
            }
            if (this.fachadaOVivienda = cable.FachadaOVivienda == true)
            {
                rBFachada.Checked = true;
            }
            else
            {
                rBVivienda.Checked = true;
            }
        }

        public string Metros { get => metros; set => metros = value; }
        public int NumeroDeSerie { get => numeroDeSerie; set => numeroDeSerie = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public long CambiarMetros { get => cambiarMetros; set => cambiarMetros = value; }
        public CableElectrico Cable { get => Cable1; set => Cable1 = value; }
        public CableElectrico Cable1 { get => cable; set => cable = value; }
        public string PalabraProcedimientoAlmcenadoSalida { get => palabraProcedimientoAlmcenadoSalida; set => palabraProcedimientoAlmcenadoSalida = value; }

        private void bTCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            metros = "";
            numeroDeSerie = -200;
            fecha = "01/01/0001";
            CambiarMetros = 0;
        }

        private void tBDatosDeEntrada_TextChanged(object sender, EventArgs e)
        {
            if (this.fecha != "01/01/0001")
            {
                fecha = tBDatosDeEntrada.Text;
            }
            if (!string.IsNullOrEmpty(metros))
            {
                this.metros = tBDatosDeEntrada.Text;
            }
            else if (int.TryParse(tBDatosDeEntrada.Text, out this.numeroDeSerie) == false)
            {
                this.numeroDeSerie = -200;
            }

        }

        private void bTEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tBDatosDeEntrada.Text))
            {
                this.palabraProcedimientoAlmcenadoSalida = tBDatosDeEntrada.Text;
            }
            this.Close();
        }

        private void tBCambiarMetros_TextChanged(object sender, EventArgs e)
        {

        }

        private void bTCancelarAñadir_Click(object sender, EventArgs e)
        {
            Cable = new CableElectrico();
            this.Close();
        }

        private void nUDNumeroDeSerie_ValueChanged(object sender, EventArgs e)
        {
            this.serie = (int)nUDNumeroDeSerie.Value;
        }

        private void nUDCantidadDeConductores_ValueChanged(object sender, EventArgs e)
        {
            this.cantidadDeConductores = (int)nUDCantidadDeConductores.Value;
        }

        private void tBMarca_TextChanged(object sender, EventArgs e)
        {
            this.marcaDelCable = tBMarca.Text;
        }

        private void nUDNumeroDeMetros_ValueChanged(object sender, EventArgs e)
        {
            int numero = (int)nUDNumeroDeMetros.Value;
            this.cambiar = (float)numero;
        }

        private void tBSeccion_TextChanged(object sender, EventArgs e)
        {
            if (Char.TryParse(tBSeccion.Text, out this.seccionDelCable))
            {

            }
            else
            {
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Error;
                MessageBox.Show("Dato no apto introduce un caracter", "Error", botones, icono);
            }
        }

        private void tBFechaDeCompra_TextChanged(object sender, EventArgs e)
        {
            this.fechaDeCompra = tBFechaDeCompra.Text;
        }

        private void tBFechaDeVenta_TextChanged(object sender, EventArgs e)
        {
            this.fechaDeVencimiento = tBFechaDeVenta.Text;
        }

        private void rBLibre_CheckedChanged(object sender, EventArgs e)
        {
            this.libreDeHalogenos = true;
        }

        private void rBNoLibre_CheckedChanged(object sender, EventArgs e)
        {
            this.libreDeHalogenos = false;
        }

        private void rBFachada_CheckedChanged(object sender, EventArgs e)
        {
            this.fachadaOVivienda = true;
        }

        private void rBVivienda_CheckedChanged(object sender, EventArgs e)
        {
            this.fachadaOVivienda = false;
        }

        private void bTAñadir_Click(object sender, EventArgs e)
        {
            DateTime compra;
            DateTime venta;
            MessageBoxButtons botones = MessageBoxButtons.YesNo;
            MessageBoxIcon icono = MessageBoxIcon.Warning;
            DialogResult resultado = MessageBox.Show("Estas seguro que deseas añadir este cable", "Atencion", botones, icono);
            if (resultado == DialogResult.Yes)
            {
                if (this.serie.ToString() != null)
                {
                    if (this.cantidadDeConductores != 0)
                    {
                        if (!string.IsNullOrEmpty(this.marcaDelCable))
                        {
                            if (this.cambiar != 0)
                            {
                                if (seccionDelCable.ToString().Length == 1)
                                {
                                    if (DateTime.TryParse(this.fechaDeCompra, out compra))
                                    {
                                        if (DateTime.TryParse(this.fechaDeVencimiento, out venta))
                                        {
                                            this.Cable = new CableElectrico(this.serie, this.cantidadDeConductores, this.marcaDelCable, this.cambiar, this.seccionDelCable, this.libreDeHalogenos, this.fachadaOVivienda, compra, venta);
                                            this.Close();
                                        }
                                        else
                                        {
                                            botones = MessageBoxButtons.OK;
                                            MessageBox.Show("Fecha de venta no valido", "Error", botones, icono);
                                        }
                                    }
                                    else
                                    {
                                        botones = MessageBoxButtons.OK;
                                        MessageBox.Show("Fecha de compra no valido", "Error", botones, icono);
                                    }
                                }
                                else
                                {
                                    botones = MessageBoxButtons.OK;
                                    MessageBox.Show("Seccion no valido", "Error", botones, icono);
                                }
                            }
                            else
                            {
                                botones = MessageBoxButtons.OK;
                                MessageBox.Show("Cantida de metros no valido", "Error", botones, icono);
                            }
                        }
                        else
                        {
                            botones = MessageBoxButtons.OK;
                            MessageBox.Show("Introduce una marca", "Error", botones, icono);
                        }
                    }
                    else
                    {
                        botones = MessageBoxButtons.OK;
                        MessageBox.Show("Cantida de conductores no valido", "Error", botones, icono);
                    }
                }
                else
                {
                    botones = MessageBoxButtons.OK;
                    MessageBox.Show("Numero de Serie no valido", "Error", botones, icono);
                }
            }
            else
            {
                this.Cable = new CableElectrico();
                this.Close();
            }

        }
    }
}
