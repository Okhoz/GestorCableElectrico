using System.Threading.Tasks;

namespace ViewForms
{
    partial class VMenu
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
        private async Task InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VMenu));
            this.textoTitulo = new System.Windows.Forms.TextBox();
            this.bTAñadir = new System.Windows.Forms.Button();
            this.bTBorrar = new System.Windows.Forms.Button();
            this.lBListaDeTodo = new System.Windows.Forms.ListBox();
            this.bTCambiar = new System.Windows.Forms.Button();
            this.cBListaDeFiltros = new System.Windows.Forms.ComboBox();
            this.bTFiltrar = new System.Windows.Forms.Button();
            this.bTMostrarTodo = new System.Windows.Forms.Button();
            this.lbCabecera = new System.Windows.Forms.Label();
            this.lBFiltros = new System.Windows.Forms.Label();
            this.pBCargando = new System.Windows.Forms.PictureBox();
            this.lBCarga = new System.Windows.Forms.Label();
            this.bTNServidorHTTP = new System.Windows.Forms.Button();
            this.tBLog = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bTNLog = new System.Windows.Forms.Button();
            this.bTNServidorAPI = new System.Windows.Forms.Button();
            this.btnProcedimientoAlmacenado = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBCargando)).BeginInit();
            this.SuspendLayout();
            // 
            // textoTitulo
            // 
            this.textoTitulo.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.textoTitulo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textoTitulo.CausesValidation = false;
            this.textoTitulo.Enabled = false;
            this.textoTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textoTitulo.ForeColor = System.Drawing.Color.White;
            this.textoTitulo.Location = new System.Drawing.Point(-7, -2);
            this.textoTitulo.Margin = new System.Windows.Forms.Padding(4);
            this.textoTitulo.Multiline = true;
            this.textoTitulo.Name = "textoTitulo";
            this.textoTitulo.ReadOnly = true;
            this.textoTitulo.Size = new System.Drawing.Size(868, 52);
            this.textoTitulo.TabIndex = 0;
            this.textoTitulo.Text = "\r\nGESTOR DE CABLE";
            this.textoTitulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bTAñadir
            // 
            this.bTAñadir.BackColor = System.Drawing.Color.AliceBlue;
            this.bTAñadir.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTAñadir.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTAñadir.Location = new System.Drawing.Point(17, 140);
            this.bTAñadir.Margin = new System.Windows.Forms.Padding(4);
            this.bTAñadir.Name = "bTAñadir";
            this.bTAñadir.Size = new System.Drawing.Size(160, 28);
            this.bTAñadir.TabIndex = 2;
            this.bTAñadir.Text = "Añadir un cable";
            this.bTAñadir.UseVisualStyleBackColor = false;
            this.bTAñadir.Click += new System.EventHandler(this.bTAñadir_Click);
            // 
            // bTBorrar
            // 
            this.bTBorrar.BackColor = System.Drawing.Color.AliceBlue;
            this.bTBorrar.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTBorrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTBorrar.Location = new System.Drawing.Point(17, 176);
            this.bTBorrar.Margin = new System.Windows.Forms.Padding(4);
            this.bTBorrar.Name = "bTBorrar";
            this.bTBorrar.Size = new System.Drawing.Size(160, 28);
            this.bTBorrar.TabIndex = 3;
            this.bTBorrar.Text = "Borrar un cable";
            this.bTBorrar.UseVisualStyleBackColor = false;
            this.bTBorrar.Click += new System.EventHandler(this.bTBorrar_Click);
            // 
            // lBListaDeTodo
            // 
            this.lBListaDeTodo.Font = new System.Drawing.Font("Calibri", 13.25F);
            this.lBListaDeTodo.FormattingEnabled = true;
            this.lBListaDeTodo.ItemHeight = 22;
            this.lBListaDeTodo.Location = new System.Drawing.Point(233, 84);
            this.lBListaDeTodo.Margin = new System.Windows.Forms.Padding(4);
            this.lBListaDeTodo.Name = "lBListaDeTodo";
            this.lBListaDeTodo.Size = new System.Drawing.Size(601, 268);
            this.lBListaDeTodo.TabIndex = 8;
            // 
            // bTCambiar
            // 
            this.bTCambiar.BackColor = System.Drawing.Color.AliceBlue;
            this.bTCambiar.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTCambiar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTCambiar.Location = new System.Drawing.Point(17, 212);
            this.bTCambiar.Margin = new System.Windows.Forms.Padding(4);
            this.bTCambiar.Name = "bTCambiar";
            this.bTCambiar.Size = new System.Drawing.Size(160, 64);
            this.bTCambiar.TabIndex = 9;
            this.bTCambiar.Text = "Cambiar datos del cable";
            this.bTCambiar.UseVisualStyleBackColor = false;
            this.bTCambiar.Click += new System.EventHandler(this.bTCambiar_Click);
            // 
            // cBListaDeFiltros
            // 
            this.cBListaDeFiltros.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBListaDeFiltros.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cBListaDeFiltros.FormattingEnabled = true;
            this.cBListaDeFiltros.Location = new System.Drawing.Point(17, 345);
            this.cBListaDeFiltros.Margin = new System.Windows.Forms.Padding(4);
            this.cBListaDeFiltros.Name = "cBListaDeFiltros";
            this.cBListaDeFiltros.Size = new System.Drawing.Size(160, 29);
            this.cBListaDeFiltros.TabIndex = 10;
            // 
            // bTFiltrar
            // 
            this.bTFiltrar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bTFiltrar.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTFiltrar.Location = new System.Drawing.Point(185, 345);
            this.bTFiltrar.Margin = new System.Windows.Forms.Padding(4);
            this.bTFiltrar.Name = "bTFiltrar";
            this.bTFiltrar.Size = new System.Drawing.Size(40, 28);
            this.bTFiltrar.TabIndex = 12;
            this.bTFiltrar.Text = " ✔";
            this.bTFiltrar.UseVisualStyleBackColor = false;
            this.bTFiltrar.Click += new System.EventHandler(this.bTFiltrar_Click);
            // 
            // bTMostrarTodo
            // 
            this.bTMostrarTodo.BackColor = System.Drawing.Color.AliceBlue;
            this.bTMostrarTodo.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTMostrarTodo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTMostrarTodo.Location = new System.Drawing.Point(17, 288);
            this.bTMostrarTodo.Margin = new System.Windows.Forms.Padding(4);
            this.bTMostrarTodo.Name = "bTMostrarTodo";
            this.bTMostrarTodo.Size = new System.Drawing.Size(160, 28);
            this.bTMostrarTodo.TabIndex = 13;
            this.bTMostrarTodo.Text = "Mostrar todo";
            this.bTMostrarTodo.UseVisualStyleBackColor = false;
            this.bTMostrarTodo.Click += new System.EventHandler(this.bTMostrarTodo_Click);
            // 
            // lbCabecera
            // 
            this.lbCabecera.AutoSize = true;
            this.lbCabecera.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.lbCabecera.Location = new System.Drawing.Point(230, 63);
            this.lbCabecera.Name = "lbCabecera";
            this.lbCabecera.Size = new System.Drawing.Size(42, 17);
            this.lbCabecera.TabIndex = 14;
            this.lbCabecera.Text = "label1";
            // 
            // lBFiltros
            // 
            this.lBFiltros.AutoSize = true;
            this.lBFiltros.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBFiltros.Location = new System.Drawing.Point(72, 320);
            this.lBFiltros.Name = "lBFiltros";
            this.lBFiltros.Size = new System.Drawing.Size(54, 21);
            this.lBFiltros.TabIndex = 15;
            this.lBFiltros.Text = "Filtros";
            // 
            // pBCargando
            // 
            this.pBCargando.Image = ((System.Drawing.Image)(resources.GetObject("pBCargando.Image")));
            this.pBCargando.Location = new System.Drawing.Point(484, 154);
            this.pBCargando.Name = "pBCargando";
            this.pBCargando.Size = new System.Drawing.Size(96, 102);
            this.pBCargando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBCargando.TabIndex = 16;
            this.pBCargando.TabStop = false;
            this.pBCargando.Visible = false;
            // 
            // lBCarga
            // 
            this.lBCarga.AutoSize = true;
            this.lBCarga.BackColor = System.Drawing.SystemColors.Window;
            this.lBCarga.Font = new System.Drawing.Font("Calibri", 10.25F);
            this.lBCarga.Location = new System.Drawing.Point(502, 259);
            this.lBCarga.Name = "lBCarga";
            this.lBCarga.Size = new System.Drawing.Size(0, 17);
            this.lBCarga.TabIndex = 17;
            this.lBCarga.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lBCarga.Visible = false;
            // 
            // bTNServidorHTTP
            // 
            this.bTNServidorHTTP.BackColor = System.Drawing.Color.Red;
            this.bTNServidorHTTP.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTNServidorHTTP.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTNServidorHTTP.Location = new System.Drawing.Point(17, 64);
            this.bTNServidorHTTP.Margin = new System.Windows.Forms.Padding(4);
            this.bTNServidorHTTP.Name = "bTNServidorHTTP";
            this.bTNServidorHTTP.Size = new System.Drawing.Size(158, 28);
            this.bTNServidorHTTP.TabIndex = 18;
            this.bTNServidorHTTP.Text = "ServidorHTTP";
            this.bTNServidorHTTP.UseVisualStyleBackColor = false;
            this.bTNServidorHTTP.Click += new System.EventHandler(this.bTNServidorHTTP_Click);
            // 
            // tBLog
            // 
            this.tBLog.Location = new System.Drawing.Point(233, 412);
            this.tBLog.Multiline = true;
            this.tBLog.Name = "tBLog";
            this.tBLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBLog.Size = new System.Drawing.Size(593, 105);
            this.tBLog.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 396);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Log del servidor";
            // 
            // bTNLog
            // 
            this.bTNLog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bTNLog.Location = new System.Drawing.Point(182, 62);
            this.bTNLog.Name = "bTNLog";
            this.bTNLog.Size = new System.Drawing.Size(42, 30);
            this.bTNLog.TabIndex = 21;
            this.bTNLog.Text = "LOG";
            this.bTNLog.UseVisualStyleBackColor = false;
            this.bTNLog.Click += new System.EventHandler(this.bTNLog_Click);
            // 
            // bTNServidorAPI
            // 
            this.bTNServidorAPI.BackColor = System.Drawing.Color.Red;
            this.bTNServidorAPI.Font = new System.Drawing.Font("Calibri", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTNServidorAPI.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bTNServidorAPI.Location = new System.Drawing.Point(17, 100);
            this.bTNServidorAPI.Margin = new System.Windows.Forms.Padding(4);
            this.bTNServidorAPI.Name = "bTNServidorAPI";
            this.bTNServidorAPI.Size = new System.Drawing.Size(113, 28);
            this.bTNServidorAPI.TabIndex = 22;
            this.bTNServidorAPI.Text = "ServidorAPI";
            this.bTNServidorAPI.UseVisualStyleBackColor = false;
            this.bTNServidorAPI.Click += new System.EventHandler(this.bTNServidorAPI_Click);
            // 
            // btnProcedimientoAlmacenado
            // 
            this.btnProcedimientoAlmacenado.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcedimientoAlmacenado.Location = new System.Drawing.Point(137, 100);
            this.btnProcedimientoAlmacenado.Name = "btnProcedimientoAlmacenado";
            this.btnProcedimientoAlmacenado.Size = new System.Drawing.Size(89, 28);
            this.btnProcedimientoAlmacenado.TabIndex = 23;
            this.btnProcedimientoAlmacenado.Text = "Procedimiento";
            this.btnProcedimientoAlmacenado.UseVisualStyleBackColor = false;
            this.btnProcedimientoAlmacenado.Click += new System.EventHandler(this.btnProcedimientoAlmacenado_Click);
            // 
            // VMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1075, 675);
            this.Controls.Add(this.btnProcedimientoAlmacenado);
            this.Controls.Add(this.bTNServidorAPI);
            this.Controls.Add(this.bTNLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tBLog);
            this.Controls.Add(this.bTNServidorHTTP);
            this.Controls.Add(this.lBCarga);
            this.Controls.Add(this.pBCargando);
            this.Controls.Add(this.lBFiltros);
            this.Controls.Add(this.lbCabecera);
            this.Controls.Add(this.bTMostrarTodo);
            this.Controls.Add(this.bTFiltrar);
            this.Controls.Add(this.cBListaDeFiltros);
            this.Controls.Add(this.bTCambiar);
            this.Controls.Add(this.lBListaDeTodo);
            this.Controls.Add(this.bTBorrar);
            this.Controls.Add(this.bTAñadir);
            this.Controls.Add(this.textoTitulo);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "VMenu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.VMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBCargando)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion 

        private System.Windows.Forms.TextBox textoTitulo;
        private System.Windows.Forms.Button bTAñadir;
        private System.Windows.Forms.Button bTBorrar;
        private System.Windows.Forms.ListBox lBListaDeTodo;
        private System.Windows.Forms.Button bTCambiar;
        private System.Windows.Forms.ComboBox cBListaDeFiltros;
        private System.Windows.Forms.Button bTFiltrar;
        private System.Windows.Forms.Button bTMostrarTodo;
        private System.Windows.Forms.Label lbCabecera;
        private System.Windows.Forms.Label lBFiltros;
        private System.Windows.Forms.PictureBox pBCargando;
        private System.Windows.Forms.Label lBCarga;
        private System.Windows.Forms.Button bTNServidorHTTP;
        private System.Windows.Forms.TextBox tBLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTNLog;
        private System.Windows.Forms.Button bTNServidorAPI;
        private System.Windows.Forms.Button btnProcedimientoAlmacenado;
    }
}