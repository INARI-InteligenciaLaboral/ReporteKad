namespace ReporteKad
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.clbEmpleados = new System.Windows.Forms.CheckedListBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.pbxLogo = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbxEmpleados = new System.Windows.Forms.PictureBox();
            this.pbxFinCal = new System.Windows.Forms.PictureBox();
            this.pbxINICal = new System.Windows.Forms.PictureBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cbxAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEmpleados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFinCal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxINICal)).BeginInit();
            this.SuspendLayout();
            // 
            // clbEmpleados
            // 
            this.clbEmpleados.CheckOnClick = true;
            this.clbEmpleados.FormattingEnabled = true;
            this.clbEmpleados.Location = new System.Drawing.Point(12, 64);
            this.clbEmpleados.Name = "clbEmpleados";
            this.clbEmpleados.Size = new System.Drawing.Size(410, 409);
            this.clbEmpleados.TabIndex = 0;
            this.clbEmpleados.SelectedIndexChanged += new System.EventHandler(this.clbEmpleados_SelectedIndexChanged);
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.BackColor = System.Drawing.Color.Transparent;
            this.lblEmployee.Font = new System.Drawing.Font("Iskoola Pota", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblEmployee.Location = new System.Drawing.Point(82, 23);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(105, 23);
            this.lblEmployee.TabIndex = 1;
            this.lblEmployee.Text = "Empleados";
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.BackColor = System.Drawing.Color.Transparent;
            this.lblFiltros.Font = new System.Drawing.Font("Iskoola Pota", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblFiltros.Location = new System.Drawing.Point(506, 150);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(67, 23);
            this.lblFiltros.TabIndex = 2;
            this.lblFiltros.Text = "Filtros";
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(494, 207);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 3;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(494, 289);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 4;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(485, 246);
            this.dtpFechaInicio.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(110, 20);
            this.dtpFechaInicio.TabIndex = 5;
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(486, 327);
            this.dtpFechaFin.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(110, 20);
            this.dtpFechaFin.TabIndex = 6;
            // 
            // pbxLogo
            // 
            this.pbxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pbxLogo.Image = global::ReporteKad.Properties.Resources.KadensaLogo;
            this.pbxLogo.Location = new System.Drawing.Point(428, 9);
            this.pbxLogo.Name = "pbxLogo";
            this.pbxLogo.Size = new System.Drawing.Size(184, 62);
            this.pbxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxLogo.TabIndex = 12;
            this.pbxLogo.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ReporteKad.Properties.Resources.lista5;
            this.pictureBox1.Location = new System.Drawing.Point(449, 136);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 49);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // pbxEmpleados
            // 
            this.pbxEmpleados.BackColor = System.Drawing.Color.Transparent;
            this.pbxEmpleados.Image = global::ReporteKad.Properties.Resources.guests;
            this.pbxEmpleados.Location = new System.Drawing.Point(25, 9);
            this.pbxEmpleados.Name = "pbxEmpleados";
            this.pbxEmpleados.Size = new System.Drawing.Size(51, 49);
            this.pbxEmpleados.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxEmpleados.TabIndex = 10;
            this.pbxEmpleados.TabStop = false;
            // 
            // pbxFinCal
            // 
            this.pbxFinCal.BackColor = System.Drawing.Color.Transparent;
            this.pbxFinCal.Image = global::ReporteKad.Properties.Resources._3D_Calendar_red;
            this.pbxFinCal.Location = new System.Drawing.Point(439, 327);
            this.pbxFinCal.Name = "pbxFinCal";
            this.pbxFinCal.Size = new System.Drawing.Size(40, 43);
            this.pbxFinCal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxFinCal.TabIndex = 9;
            this.pbxFinCal.TabStop = false;
            // 
            // pbxINICal
            // 
            this.pbxINICal.BackColor = System.Drawing.Color.Transparent;
            this.pbxINICal.Image = global::ReporteKad.Properties.Resources._3D_Calendar_red;
            this.pbxINICal.Location = new System.Drawing.Point(439, 246);
            this.pbxINICal.Name = "pbxINICal";
            this.pbxINICal.Size = new System.Drawing.Size(40, 43);
            this.pbxINICal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxINICal.TabIndex = 8;
            this.pbxINICal.TabStop = false;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Image = global::ReporteKad.Properties.Resources.Graphicloads_Filetype_Excel_xls;
            this.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerar.Location = new System.Drawing.Point(486, 399);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnGenerar.Size = new System.Drawing.Size(90, 41);
            this.btnGenerar.TabIndex = 7;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cbxAll
            // 
            this.cbxAll.AutoSize = true;
            this.cbxAll.Location = new System.Drawing.Point(449, 96);
            this.cbxAll.Name = "cbxAll";
            this.cbxAll.Size = new System.Drawing.Size(111, 17);
            this.cbxAll.TabIndex = 13;
            this.cbxAll.Text = "Seleccionar todos";
            this.cbxAll.UseVisualStyleBackColor = true;
            this.cbxAll.CheckedChanged += new System.EventHandler(this.cbxAll_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 482);
            this.Controls.Add(this.cbxAll);
            this.Controls.Add(this.pbxLogo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pbxEmpleados);
            this.Controls.Add(this.pbxFinCal);
            this.Controls.Add(this.pbxINICal);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.lblFiltros);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.clbEmpleados);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Reporte - Kadensa";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxEmpleados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFinCal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxINICal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbEmpleados;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblFiltros;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.PictureBox pbxINICal;
        private System.Windows.Forms.PictureBox pbxFinCal;
        private System.Windows.Forms.PictureBox pbxEmpleados;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pbxLogo;
        private System.Windows.Forms.CheckBox cbxAll;
    }
}

