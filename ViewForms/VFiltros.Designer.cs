namespace ViewForms
{
    partial class VFiltros
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
            this.textoTitulo = new System.Windows.Forms.TextBox();
            this.tBDatosDeEntrada = new System.Windows.Forms.TextBox();
            this.bTEnviar = new System.Windows.Forms.Button();
            this.bTCancelar = new System.Windows.Forms.Button();
            this.lBNumeroDeSerie = new System.Windows.Forms.Label();
            this.gBDatos = new System.Windows.Forms.GroupBox();
            this.gBLibreDeHalogenos = new System.Windows.Forms.GroupBox();
            this.rBNoLibre = new System.Windows.Forms.RadioButton();
            this.rBLibre = new System.Windows.Forms.RadioButton();
            this.gBFachadaOVivienda = new System.Windows.Forms.GroupBox();
            this.rBVivienda = new System.Windows.Forms.RadioButton();
            this.rBFachada = new System.Windows.Forms.RadioButton();
            this.nUDNumeroDeSerie = new System.Windows.Forms.NumericUpDown();
            this.lBNumero = new System.Windows.Forms.Label();
            this.lBCantidadDeConducotores = new System.Windows.Forms.Label();
            this.nUDCantidadDeConductores = new System.Windows.Forms.NumericUpDown();
            this.tBMarca = new System.Windows.Forms.TextBox();
            this.lBMarca = new System.Windows.Forms.Label();
            this.lBNumeroMetros = new System.Windows.Forms.Label();
            this.nUDNumeroDeMetros = new System.Windows.Forms.NumericUpDown();
            this.lBSeccion = new System.Windows.Forms.Label();
            this.tBSeccion = new System.Windows.Forms.TextBox();
            this.lBFechaDeVenta = new System.Windows.Forms.Label();
            this.tBFechaDeVenta = new System.Windows.Forms.TextBox();
            this.lBFechaDeCompra = new System.Windows.Forms.Label();
            this.tBFechaDeCompra = new System.Windows.Forms.TextBox();
            this.gBAñadir = new System.Windows.Forms.GroupBox();
            this.bTAñadir = new System.Windows.Forms.Button();
            this.bTCancelarAñadir = new System.Windows.Forms.Button();
            this.gBDatos.SuspendLayout();
            this.gBLibreDeHalogenos.SuspendLayout();
            this.gBFachadaOVivienda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroDeSerie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCantidadDeConductores)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroDeMetros)).BeginInit();
            this.gBAñadir.SuspendLayout();
            this.SuspendLayout();
            // 
            // textoTitulo
            // 
            this.textoTitulo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textoTitulo.CausesValidation = false;
            this.textoTitulo.Enabled = false;
            this.textoTitulo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.textoTitulo.Location = new System.Drawing.Point(-11, -2);
            this.textoTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.textoTitulo.Multiline = true;
            this.textoTitulo.Name = "textoTitulo";
            this.textoTitulo.Size = new System.Drawing.Size(356, 52);
            this.textoTitulo.TabIndex = 1;
            this.textoTitulo.Text = "\r\nINTRODUCE LOS DATOS";
            this.textoTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tBDatosDeEntrada
            // 
            this.tBDatosDeEntrada.CausesValidation = false;
            this.tBDatosDeEntrada.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tBDatosDeEntrada.Location = new System.Drawing.Point(46, 69);
            this.tBDatosDeEntrada.Margin = new System.Windows.Forms.Padding(4);
            this.tBDatosDeEntrada.Name = "tBDatosDeEntrada";
            this.tBDatosDeEntrada.Size = new System.Drawing.Size(183, 22);
            this.tBDatosDeEntrada.TabIndex = 2;
            this.tBDatosDeEntrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tBDatosDeEntrada.TextChanged += new System.EventHandler(this.tBDatosDeEntrada_TextChanged);
            // 
            // bTEnviar
            // 
            this.bTEnviar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bTEnviar.Location = new System.Drawing.Point(177, 121);
            this.bTEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.bTEnviar.Name = "bTEnviar";
            this.bTEnviar.Size = new System.Drawing.Size(100, 28);
            this.bTEnviar.TabIndex = 3;
            this.bTEnviar.Text = "Enviar";
            this.bTEnviar.UseVisualStyleBackColor = false;
            this.bTEnviar.Click += new System.EventHandler(this.bTEnviar_Click);
            // 
            // bTCancelar
            // 
            this.bTCancelar.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.bTCancelar.Location = new System.Drawing.Point(17, 121);
            this.bTCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.bTCancelar.Name = "bTCancelar";
            this.bTCancelar.Size = new System.Drawing.Size(100, 28);
            this.bTCancelar.TabIndex = 4;
            this.bTCancelar.Text = "Cancelar";
            this.bTCancelar.UseVisualStyleBackColor = false;
            this.bTCancelar.Click += new System.EventHandler(this.bTCancelar_Click);
            // 
            // lBNumeroDeSerie
            // 
            this.lBNumeroDeSerie.AutoSize = true;
            this.lBNumeroDeSerie.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBNumeroDeSerie.Location = new System.Drawing.Point(84, 26);
            this.lBNumeroDeSerie.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBNumeroDeSerie.Name = "lBNumeroDeSerie";
            this.lBNumeroDeSerie.Size = new System.Drawing.Size(142, 23);
            this.lBNumeroDeSerie.TabIndex = 6;
            this.lBNumeroDeSerie.Text = "Numero de serie:";
            // 
            // gBDatos
            // 
            this.gBDatos.Controls.Add(this.bTEnviar);
            this.gBDatos.Controls.Add(this.tBDatosDeEntrada);
            this.gBDatos.Controls.Add(this.lBNumeroDeSerie);
            this.gBDatos.Controls.Add(this.bTCancelar);
            this.gBDatos.Location = new System.Drawing.Point(42, 57);
            this.gBDatos.Name = "gBDatos";
            this.gBDatos.Size = new System.Drawing.Size(286, 156);
            this.gBDatos.TabIndex = 8;
            this.gBDatos.TabStop = false;
            // 
            // gBLibreDeHalogenos
            // 
            this.gBLibreDeHalogenos.Controls.Add(this.rBNoLibre);
            this.gBLibreDeHalogenos.Controls.Add(this.rBLibre);
            this.gBLibreDeHalogenos.Location = new System.Drawing.Point(10, 221);
            this.gBLibreDeHalogenos.Name = "gBLibreDeHalogenos";
            this.gBLibreDeHalogenos.Size = new System.Drawing.Size(118, 70);
            this.gBLibreDeHalogenos.TabIndex = 9;
            this.gBLibreDeHalogenos.TabStop = false;
            this.gBLibreDeHalogenos.Text = "Libre de Halogenos";
            // 
            // rBNoLibre
            // 
            this.rBNoLibre.AutoSize = true;
            this.rBNoLibre.Location = new System.Drawing.Point(12, 42);
            this.rBNoLibre.Name = "rBNoLibre";
            this.rBNoLibre.Size = new System.Drawing.Size(83, 21);
            this.rBNoLibre.TabIndex = 10;
            this.rBNoLibre.TabStop = true;
            this.rBNoLibre.Text = "No Libre";
            this.rBNoLibre.UseVisualStyleBackColor = true;
            this.rBNoLibre.CheckedChanged += new System.EventHandler(this.rBNoLibre_CheckedChanged);
            // 
            // rBLibre
            // 
            this.rBLibre.AutoSize = true;
            this.rBLibre.Location = new System.Drawing.Point(12, 19);
            this.rBLibre.Name = "rBLibre";
            this.rBLibre.Size = new System.Drawing.Size(61, 21);
            this.rBLibre.TabIndex = 11;
            this.rBLibre.TabStop = true;
            this.rBLibre.Text = "Libre";
            this.rBLibre.UseVisualStyleBackColor = true;
            this.rBLibre.CheckedChanged += new System.EventHandler(this.rBLibre_CheckedChanged);
            // 
            // gBFachadaOVivienda
            // 
            this.gBFachadaOVivienda.Controls.Add(this.rBVivienda);
            this.gBFachadaOVivienda.Controls.Add(this.rBFachada);
            this.gBFachadaOVivienda.Location = new System.Drawing.Point(150, 221);
            this.gBFachadaOVivienda.Name = "gBFachadaOVivienda";
            this.gBFachadaOVivienda.Size = new System.Drawing.Size(118, 70);
            this.gBFachadaOVivienda.TabIndex = 12;
            this.gBFachadaOVivienda.TabStop = false;
            this.gBFachadaOVivienda.Text = "Fachada o vivienda";
            // 
            // rBVivienda
            // 
            this.rBVivienda.AutoSize = true;
            this.rBVivienda.Location = new System.Drawing.Point(12, 42);
            this.rBVivienda.Name = "rBVivienda";
            this.rBVivienda.Size = new System.Drawing.Size(83, 21);
            this.rBVivienda.TabIndex = 10;
            this.rBVivienda.TabStop = true;
            this.rBVivienda.Text = "Vivienda";
            this.rBVivienda.UseVisualStyleBackColor = true;
            this.rBVivienda.CheckedChanged += new System.EventHandler(this.rBVivienda_CheckedChanged);
            // 
            // rBFachada
            // 
            this.rBFachada.AutoSize = true;
            this.rBFachada.Location = new System.Drawing.Point(12, 19);
            this.rBFachada.Name = "rBFachada";
            this.rBFachada.Size = new System.Drawing.Size(84, 21);
            this.rBFachada.TabIndex = 11;
            this.rBFachada.TabStop = true;
            this.rBFachada.Text = "Fachada";
            this.rBFachada.UseVisualStyleBackColor = true;
            this.rBFachada.CheckedChanged += new System.EventHandler(this.rBFachada_CheckedChanged);
            // 
            // nUDNumeroDeSerie
            // 
            this.nUDNumeroDeSerie.Enabled = false;
            this.nUDNumeroDeSerie.Location = new System.Drawing.Point(139, 22);
            this.nUDNumeroDeSerie.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nUDNumeroDeSerie.Name = "nUDNumeroDeSerie";
            this.nUDNumeroDeSerie.Size = new System.Drawing.Size(120, 22);
            this.nUDNumeroDeSerie.TabIndex = 13;
            this.nUDNumeroDeSerie.ValueChanged += new System.EventHandler(this.nUDNumeroDeSerie_ValueChanged);
            // 
            // lBNumero
            // 
            this.lBNumero.AutoSize = true;
            this.lBNumero.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBNumero.Location = new System.Drawing.Point(7, 21);
            this.lBNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBNumero.Name = "lBNumero";
            this.lBNumero.Size = new System.Drawing.Size(142, 23);
            this.lBNumero.TabIndex = 8;
            this.lBNumero.Text = "Numero de serie:";
            // 
            // lBCantidadDeConducotores
            // 
            this.lBCantidadDeConducotores.AutoSize = true;
            this.lBCantidadDeConducotores.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBCantidadDeConducotores.Location = new System.Drawing.Point(7, 50);
            this.lBCantidadDeConducotores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBCantidadDeConducotores.Name = "lBCantidadDeConducotores";
            this.lBCantidadDeConducotores.Size = new System.Drawing.Size(146, 23);
            this.lBCantidadDeConducotores.TabIndex = 14;
            this.lBCantidadDeConducotores.Text = "C. contuductores:";
            // 
            // nUDCantidadDeConductores
            // 
            this.nUDCantidadDeConductores.Location = new System.Drawing.Point(139, 48);
            this.nUDCantidadDeConductores.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUDCantidadDeConductores.Name = "nUDCantidadDeConductores";
            this.nUDCantidadDeConductores.Size = new System.Drawing.Size(120, 22);
            this.nUDCantidadDeConductores.TabIndex = 15;
            this.nUDCantidadDeConductores.ValueChanged += new System.EventHandler(this.nUDCantidadDeConductores_ValueChanged);
            // 
            // tBMarca
            // 
            this.tBMarca.Location = new System.Drawing.Point(139, 78);
            this.tBMarca.Name = "tBMarca";
            this.tBMarca.Size = new System.Drawing.Size(120, 22);
            this.tBMarca.TabIndex = 16;
            this.tBMarca.TextChanged += new System.EventHandler(this.tBMarca_TextChanged);
            // 
            // lBMarca
            // 
            this.lBMarca.AutoSize = true;
            this.lBMarca.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBMarca.Location = new System.Drawing.Point(7, 81);
            this.lBMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBMarca.Name = "lBMarca";
            this.lBMarca.Size = new System.Drawing.Size(135, 23);
            this.lBMarca.TabIndex = 17;
            this.lBMarca.Text = "Marca del cable:";
            // 
            // lBNumeroMetros
            // 
            this.lBNumeroMetros.AutoSize = true;
            this.lBNumeroMetros.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBNumeroMetros.Location = new System.Drawing.Point(7, 107);
            this.lBNumeroMetros.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBNumeroMetros.Name = "lBNumeroMetros";
            this.lBNumeroMetros.Size = new System.Drawing.Size(160, 23);
            this.lBNumeroMetros.TabIndex = 18;
            this.lBNumeroMetros.Text = "Numero de metros:";
            // 
            // nUDNumeroDeMetros
            // 
            this.nUDNumeroDeMetros.Location = new System.Drawing.Point(139, 105);
            this.nUDNumeroDeMetros.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUDNumeroDeMetros.Name = "nUDNumeroDeMetros";
            this.nUDNumeroDeMetros.Size = new System.Drawing.Size(120, 22);
            this.nUDNumeroDeMetros.TabIndex = 19;
            this.nUDNumeroDeMetros.ValueChanged += new System.EventHandler(this.nUDNumeroDeMetros_ValueChanged);
            // 
            // lBSeccion
            // 
            this.lBSeccion.AutoSize = true;
            this.lBSeccion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBSeccion.Location = new System.Drawing.Point(7, 134);
            this.lBSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBSeccion.Name = "lBSeccion";
            this.lBSeccion.Size = new System.Drawing.Size(144, 23);
            this.lBSeccion.TabIndex = 21;
            this.lBSeccion.Text = "Seccion del cable:";
            // 
            // tBSeccion
            // 
            this.tBSeccion.Location = new System.Drawing.Point(139, 131);
            this.tBSeccion.Name = "tBSeccion";
            this.tBSeccion.Size = new System.Drawing.Size(120, 22);
            this.tBSeccion.TabIndex = 20;
            this.tBSeccion.TextChanged += new System.EventHandler(this.tBSeccion_TextChanged);
            // 
            // lBFechaDeVenta
            // 
            this.lBFechaDeVenta.AutoSize = true;
            this.lBFechaDeVenta.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBFechaDeVenta.Location = new System.Drawing.Point(7, 188);
            this.lBFechaDeVenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBFechaDeVenta.Name = "lBFechaDeVenta";
            this.lBFechaDeVenta.Size = new System.Drawing.Size(126, 23);
            this.lBFechaDeVenta.TabIndex = 23;
            this.lBFechaDeVenta.Text = "F. Vencimiento:";
            // 
            // tBFechaDeVenta
            // 
            this.tBFechaDeVenta.Location = new System.Drawing.Point(139, 185);
            this.tBFechaDeVenta.Name = "tBFechaDeVenta";
            this.tBFechaDeVenta.Size = new System.Drawing.Size(120, 22);
            this.tBFechaDeVenta.TabIndex = 22;
            this.tBFechaDeVenta.TextChanged += new System.EventHandler(this.tBFechaDeVenta_TextChanged);
            // 
            // lBFechaDeCompra
            // 
            this.lBFechaDeCompra.AutoSize = true;
            this.lBFechaDeCompra.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBFechaDeCompra.Location = new System.Drawing.Point(7, 162);
            this.lBFechaDeCompra.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lBFechaDeCompra.Name = "lBFechaDeCompra";
            this.lBFechaDeCompra.Size = new System.Drawing.Size(146, 23);
            this.lBFechaDeCompra.TabIndex = 25;
            this.lBFechaDeCompra.Text = "Fecha de compra:";
            // 
            // tBFechaDeCompra
            // 
            this.tBFechaDeCompra.Location = new System.Drawing.Point(139, 159);
            this.tBFechaDeCompra.Name = "tBFechaDeCompra";
            this.tBFechaDeCompra.Size = new System.Drawing.Size(120, 22);
            this.tBFechaDeCompra.TabIndex = 24;
            this.tBFechaDeCompra.TextChanged += new System.EventHandler(this.tBFechaDeCompra_TextChanged);
            // 
            // gBAñadir
            // 
            this.gBAñadir.Controls.Add(this.bTAñadir);
            this.gBAñadir.Controls.Add(this.bTCancelarAñadir);
            this.gBAñadir.Controls.Add(this.lBNumero);
            this.gBAñadir.Controls.Add(this.lBFechaDeCompra);
            this.gBAñadir.Controls.Add(this.gBLibreDeHalogenos);
            this.gBAñadir.Controls.Add(this.tBFechaDeCompra);
            this.gBAñadir.Controls.Add(this.gBFachadaOVivienda);
            this.gBAñadir.Controls.Add(this.lBFechaDeVenta);
            this.gBAñadir.Controls.Add(this.nUDNumeroDeSerie);
            this.gBAñadir.Controls.Add(this.tBFechaDeVenta);
            this.gBAñadir.Controls.Add(this.nUDCantidadDeConductores);
            this.gBAñadir.Controls.Add(this.lBSeccion);
            this.gBAñadir.Controls.Add(this.lBCantidadDeConducotores);
            this.gBAñadir.Controls.Add(this.tBSeccion);
            this.gBAñadir.Controls.Add(this.tBMarca);
            this.gBAñadir.Controls.Add(this.lBNumeroMetros);
            this.gBAñadir.Controls.Add(this.lBMarca);
            this.gBAñadir.Controls.Add(this.nUDNumeroDeMetros);
            this.gBAñadir.Location = new System.Drawing.Point(28, 57);
            this.gBAñadir.Name = "gBAñadir";
            this.gBAñadir.Size = new System.Drawing.Size(274, 341);
            this.gBAñadir.TabIndex = 26;
            this.gBAñadir.TabStop = false;
            // 
            // bTAñadir
            // 
            this.bTAñadir.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTAñadir.Location = new System.Drawing.Point(162, 297);
            this.bTAñadir.Name = "bTAñadir";
            this.bTAñadir.Size = new System.Drawing.Size(89, 38);
            this.bTAñadir.TabIndex = 27;
            this.bTAñadir.Text = "Añadir";
            this.bTAñadir.UseVisualStyleBackColor = true;
            this.bTAñadir.Click += new System.EventHandler(this.bTAñadir_Click);
            // 
            // bTCancelarAñadir
            // 
            this.bTCancelarAñadir.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTCancelarAñadir.Location = new System.Drawing.Point(14, 297);
            this.bTCancelarAñadir.Name = "bTCancelarAñadir";
            this.bTCancelarAñadir.Size = new System.Drawing.Size(98, 38);
            this.bTCancelarAñadir.TabIndex = 26;
            this.bTCancelarAñadir.Text = "Cancelar";
            this.bTCancelarAñadir.UseVisualStyleBackColor = true;
            this.bTCancelarAñadir.Click += new System.EventHandler(this.bTCancelarAñadir_Click);
            // 
            // VFiltros
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(538, 410);
            this.Controls.Add(this.gBAñadir);
            this.Controls.Add(this.gBDatos);
            this.Controls.Add(this.textoTitulo);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VFiltros";
            this.Text = "VFiltros";
            this.gBDatos.ResumeLayout(false);
            this.gBDatos.PerformLayout();
            this.gBLibreDeHalogenos.ResumeLayout(false);
            this.gBLibreDeHalogenos.PerformLayout();
            this.gBFachadaOVivienda.ResumeLayout(false);
            this.gBFachadaOVivienda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroDeSerie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDCantidadDeConductores)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDNumeroDeMetros)).EndInit();
            this.gBAñadir.ResumeLayout(false);
            this.gBAñadir.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textoTitulo;
        private System.Windows.Forms.TextBox tBDatosDeEntrada;
        private System.Windows.Forms.Button bTEnviar;
        private System.Windows.Forms.Button bTCancelar;
        private System.Windows.Forms.Label lBNumeroDeSerie;
        private System.Windows.Forms.GroupBox gBDatos;
        private System.Windows.Forms.GroupBox gBLibreDeHalogenos;
        private System.Windows.Forms.RadioButton rBNoLibre;
        private System.Windows.Forms.RadioButton rBLibre;
        private System.Windows.Forms.GroupBox gBFachadaOVivienda;
        private System.Windows.Forms.RadioButton rBVivienda;
        private System.Windows.Forms.RadioButton rBFachada;
        private System.Windows.Forms.NumericUpDown nUDNumeroDeSerie;
        private System.Windows.Forms.Label lBNumero;
        private System.Windows.Forms.Label lBCantidadDeConducotores;
        private System.Windows.Forms.NumericUpDown nUDCantidadDeConductores;
        private System.Windows.Forms.TextBox tBMarca;
        private System.Windows.Forms.Label lBMarca;
        private System.Windows.Forms.Label lBNumeroMetros;
        private System.Windows.Forms.NumericUpDown nUDNumeroDeMetros;
        private System.Windows.Forms.Label lBSeccion;
        private System.Windows.Forms.TextBox tBSeccion;
        private System.Windows.Forms.Label lBFechaDeVenta;
        private System.Windows.Forms.TextBox tBFechaDeVenta;
        private System.Windows.Forms.Label lBFechaDeCompra;
        private System.Windows.Forms.TextBox tBFechaDeCompra;
        private System.Windows.Forms.GroupBox gBAñadir;
        private System.Windows.Forms.Button bTAñadir;
        private System.Windows.Forms.Button bTCancelarAñadir;
    }
}