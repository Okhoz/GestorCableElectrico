using Businees;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ViewForms
{
    public partial class VMenu : Form
    {
        //private BCableElectrico bCableElectrico;
        private BCableElectricoAsync bCableElectricoAsync;
        private BServidorHTTTP servidorHTTTP;
        private BServidorAPIRest bServidorAPIRest;
        private bool arrancarServidor = false;
        private bool arrancarServidorAPI = false;
        private bool mostrarLog = false;
        public VMenu()
        {
            InitializeComponent();
            this.Size = new Size(876, 421);
            //bCableElectrico = new BCableElectrico();
            this.bCableElectricoAsync = new BCableElectricoAsync();
            this.servidorHTTTP = new BServidorHTTTP((info) => AñadirInfoLog(info));
            this.bServidorAPIRest = new BServidorAPIRest();
            cBListaDeFiltros.Items.Add("Numero de serie");
            cBListaDeFiltros.Items.Add("Fecha de  compra");
            cBListaDeFiltros.Items.Add("Cantidad de metros");
            lbCabecera.Text = "" +
                                "Numero Serie|" +
                                "conductores|" +
                                "Marca|" +
                                "Metros|" +
                                "Seccion|" +
                                "halogenos|" +
                                "Fachada o Vivienda|" +
                                "F.compra|" +
                                "F.vencimiento";
        }
        private void VMenu_Load(object sender, EventArgs e)
        {
            this.MostrarTodosLosCables();

        }
        private async void bTCambiar_Click(object sender, EventArgs e)
        {

            CableElectrico cable = new CableElectrico();
            CableElectrico cableCambiado = new CableElectrico();
            cable = (CableElectrico)lBListaDeTodo.SelectedItem;
            if (cable != null && cable.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  1000-01-01  |  1000-01-01".Trim())
            {

                VFiltros vFiltros = new VFiltros(cable);
                vFiltros.ShowDialog();
                cableCambiado = vFiltros.Cable;
                if (cableCambiado != null && cableCambiado.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  1000-01-01  |  1000-01-01".Trim() && cable.ToString() != cableCambiado.ToString())
                {
                    pBCargando.Visible = true;
                    lBCarga.Text = "Cargando";
                    lBCarga.Visible = true;
                    lBListaDeTodo.Items.Clear();
                    await this.bCableElectricoAsync.ModificarCable(cableCambiado);
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Exclamation;
                    MessageBox.Show("Cambio efectuado", "Cambiado", botones, icono);
                    this.MostrarTodosLosCables();
                }
            }
            else
            {
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Exclamation;
                MessageBox.Show("Selecciona un cable primero", "Cambiado", botones, icono);
            }
        }


        private void bTMostrarTodo_Click(object sender, EventArgs e)
        {
            this.MostrarTodosLosCables();
        }


        private async void MostrarTodosLosCables()
        {
            lBListaDeTodo.Items.Clear();
            pBCargando.Visible = true;
            lBCarga.Text = "Cargando";
            lBCarga.Visible = true;
            List<CableElectrico> listaDeCable = await bCableElectricoAsync.MostrarTodoElCable();
            pBCargando.Visible = false;
            lBCarga.Visible = false;
            lBListaDeTodo.Items.Clear();

            for (int i = 0; i < listaDeCable.Count; i++)
            {
                lBListaDeTodo.Items.Add(listaDeCable[i]);
            }


        }

        private async void bTFiltrar_Click(object sender, EventArgs e)
        {
            int numeroDeserie = 11111;
            DateTime fecha = DateTime.Parse("1000-01-01");
            int cantidadDeMetros;
            List<CableElectrico> listaCables = new List<CableElectrico>();
            CableElectrico cable = new CableElectrico();

            if (cBListaDeFiltros.Text == "Numero de serie")
            {
                VFiltros vFiltros = new VFiltros(1);
                vFiltros.ShowDialog();
                if (vFiltros.NumeroDeSerie != -200)
                {
                    numeroDeserie = vFiltros.NumeroDeSerie;
                    lBListaDeTodo.Items.Clear();
                    lBCarga.Text = "Filtrando...";
                    lBCarga.Visible = true;
                    pBCargando.Visible = true;
                    cable = await bCableElectricoAsync.MostrarPorNumeroDeSerie(numeroDeserie);
                    pBCargando.Visible = false;
                    lBCarga.Visible = false;
                    lBListaDeTodo.Items.Clear();
                    if (cable.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  01-01-1000  |  01-01-1000".Trim())
                    {
                        lBListaDeTodo.Items.Add(cable);
                    }
                    else
                    {
                        this.MostrarTodosLosCables();
                        MessageBoxButtons botones = MessageBoxButtons.OK;
                        MessageBoxIcon icono = MessageBoxIcon.Error;
                        MessageBox.Show("Error Falta Informacion", "Error", botones, icono);
                    }
                }

            }
            else if (cBListaDeFiltros.Text == "Fecha de  compra")
            {
                VFiltros vFiltros = new VFiltros(DateTime.Parse("12/12/9999"));
                vFiltros.ShowDialog();
                if (vFiltros.Fecha.ToString().Length <= 19)
                {
                    if (DateTime.TryParse(vFiltros.Fecha, out fecha))
                    {
                        lBListaDeTodo.Items.Clear();
                        lBCarga.Text = "Filtrando...";
                        lBCarga.Visible = true;
                        pBCargando.Visible = true;
                        listaCables = await bCableElectricoAsync.MostrarCableEnBaseAUnCriterioDeFecha(fecha);
                        pBCargando.Visible = false;
                        lBCarga.Visible = false;
                        lBListaDeTodo.Items.Clear();
                        if (listaCables.Count > 0)
                        {
                            listaCables.ForEach(c => lBListaDeTodo.Items.Add(c));
                        }
                        else
                        {
                            this.MostrarTodosLosCables();
                            MessageBoxButtons botones = MessageBoxButtons.OK;
                            MessageBoxIcon icono = MessageBoxIcon.Warning;
                            MessageBox.Show("Error Fecha fuera de rango", "Error", botones, icono);
                        }
                    }
                    else
                    {

                        MessageBoxButtons botones = MessageBoxButtons.OK;
                        MessageBoxIcon icono = MessageBoxIcon.Error;
                        MessageBox.Show("Error Falta Informacion", "Error", botones, icono);
                    }
                }

            }
            else if (cBListaDeFiltros.Text == "Cantidad de metros")
            {
                VFiltros vFiltros = new VFiltros("a");
                vFiltros.ShowDialog();
                if (int.TryParse(vFiltros.Metros, out cantidadDeMetros))
                {
                    lBListaDeTodo.Items.Clear();
                    lBCarga.Text = "Filtrando...";
                    lBCarga.Visible = true;
                    pBCargando.Visible = true;
                    listaCables = await bCableElectricoAsync.MostrarPorCantidadDeMetros(cantidadDeMetros);
                    pBCargando.Visible = false;
                    lBCarga.Visible = false;
                    lBListaDeTodo.Items.Clear();
                    if (listaCables.Count > 0)
                    {
                        listaCables.ForEach(c => lBListaDeTodo.Items.Add(c));
                    }
                    else
                    {
                        this.MostrarTodosLosCables();
                        MessageBoxButtons botones = MessageBoxButtons.OK;
                        MessageBoxIcon icono = MessageBoxIcon.Warning;
                        MessageBox.Show("Error cantida de metros fuera de rango", "Error", botones, icono);
                    }
                }
                else
                {
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Error;
                    MessageBox.Show("Error Falta Informacion", "Error", botones, icono);
                }
            }
        }


        private async void bTBorrar_Click(object sender, EventArgs e)
        {

            CableElectrico cable = new CableElectrico();
            cable = (CableElectrico)lBListaDeTodo.SelectedItem;
            if (cable != null && cable.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  1000-01-01  |  1000-01-01")
            {
                lBListaDeTodo.Items.Clear();
                pBCargando.Visible = true;
                lBCarga.Text = "Borrando";
                lBCarga.Visible = true;
                await this.bCableElectricoAsync.BorrarCable(cable.NumeroDeSerie);
                lBListaDeTodo.Items.Clear();
                List<CableElectrico> listaDeCable = await bCableElectricoAsync.MostrarTodoElCable();
                pBCargando.Visible = false;
                lBCarga.Visible = false;
                for (int i = 0; i < listaDeCable.Count; i++)
                {
                    lBListaDeTodo.Items.Add(listaDeCable[i]);
                }
            }
            else
            {
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Warning;
                MessageBox.Show("Selecciona el cable a borrar", "Warning", botones, icono);
            }

        }

        private async void bTAñadir_Click(object sender, EventArgs e)
        {
            CableElectrico cableElectrico;
            VFiltros vFiltros = new VFiltros(true);
            vFiltros.ShowDialog();
            cableElectrico = vFiltros.Cable;
            lBListaDeTodo.Items.Clear();
            pBCargando.Visible = true;
            lBCarga.Text = "Añadiendo";
            lBCarga.Visible = true;
            if (cableElectrico.ToString().Trim() != "0  |  0  |    |  0  |  -  |  No  |  No  |  1000-01-01  |  1000-01-01".Trim())
            {
                if (await this.bCableElectricoAsync.AñadirCable(cableElectrico) == true)
                {
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Warning;
                    MessageBox.Show("Cable añadido exitosamente", "Añadido", botones, icono);
                    this.MostrarTodosLosCables();
                }
                else
                {
                    MessageBoxButtons botones = MessageBoxButtons.OK;
                    MessageBoxIcon icono = MessageBoxIcon.Warning;
                    MessageBox.Show("No se pudo añadir el cable", "Error", botones, icono);
                    this.MostrarTodosLosCables();

                }

            }
            else
            {
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Warning;
                MessageBox.Show("No se pudo añadir el cable", "Error", botones, icono);
                this.MostrarTodosLosCables();

            }
        }

        private void bTNServidorHTTP_Click(object sender, EventArgs e)
        {

            if (this.arrancarServidor == false)
            {
                servidorHTTTP.IniciarServior();
                bTNServidorHTTP.BackColor = Color.Green;

            }
            else
            {
                servidorHTTTP.ParrarServidor();
                bTNServidorHTTP.BackColor = Color.Red;

            }
            this.arrancarServidor = !this.arrancarServidor;
        }
        private void bTNServidorAPI_Click(object sender, EventArgs e)
        {
            if (this.arrancarServidorAPI == false)
            {
                bServidorAPIRest.IniciarServior();
                bTNServidorAPI.BackColor = Color.Green;
            }
            else
            {
                bServidorAPIRest.ParrarServidor();
                bTNServidorAPI.BackColor = Color.Red;
            }
            this.arrancarServidorAPI = !this.arrancarServidorAPI;
        }

        private void bTNLog_Click(object sender, EventArgs e)
        {
            if (mostrarLog == false)
            {
                this.Size = new Size(876, 568);

            }
            else
            {
                this.Size = new Size(876, 421);
            }

            this.mostrarLog = !this.mostrarLog;
        }

        private void AñadirInfoLog(String informacion)
        {
            this.Invoke(new Action(() => tBLog.Text += informacion));
        }

        private void btnProcedimientoAlmacenado_Click(object sender, EventArgs e)
        {
            VFiltros filtros = new VFiltros('1');
            filtros.ShowDialog();
            string[] mensaje = bCableElectricoAsync.MostrarProcedimientoAlmacenado(filtros.PalabraProcedimientoAlmcenadoSalida).Result.Split('-');
            if (!string.IsNullOrEmpty(filtros.PalabraProcedimientoAlmcenadoSalida))
            {
                MessageBoxButtons botones = MessageBoxButtons.OK;
                MessageBoxIcon icono = MessageBoxIcon.Exclamation;
                DialogResult resultado = MessageBox.Show(mensaje[0], "Procedimieto almacenado", botones, icono);
                if (resultado == DialogResult.OK)
                {
                    botones = MessageBoxButtons.OK;
                    icono = MessageBoxIcon.Exclamation;
                    MessageBox.Show(mensaje[1], "Procedimieto almacenado", botones, icono);
                }
            }

        }
    }
}
