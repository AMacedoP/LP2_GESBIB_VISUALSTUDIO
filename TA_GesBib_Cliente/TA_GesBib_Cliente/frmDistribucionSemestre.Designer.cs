namespace TA_GesBib_Cliente
{
    partial class frmDistribucionSemestre
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
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvDitribucion = new System.Windows.Forms.DataGridView();
            this.PuntoAtencion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.btnGuardarDistribucion = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblFechaIni = new System.Windows.Forms.Label();
            this.dtpInicioSem = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFinSem = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDitribucion)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.Image = global::TA_GesBib_Cliente.Properties.Resources.icono_regresar;
            this.btnCerrar.Location = new System.Drawing.Point(37, 28);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(87, 49);
            this.btnCerrar.TabIndex = 147;
            this.btnCerrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.label6.Location = new System.Drawing.Point(127, 70);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(467, 17);
            this.label6.TabIndex = 146;
            this.label6.Text = "___________________________________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(37)))), ((int)(((byte)(42)))));
            this.label9.Location = new System.Drawing.Point(132, 30);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(442, 42);
            this.label9.TabIndex = 145;
            this.label9.Text = "Distribución del Semestre";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDitribucion
            // 
            this.dgvDitribucion.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.dgvDitribucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDitribucion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PuntoAtencion,
            this.hora8,
            this.hora9,
            this.hora10,
            this.hora11,
            this.hora12,
            this.hora13,
            this.hora14,
            this.hora15,
            this.hora16,
            this.hora17,
            this.hora18,
            this.hora19,
            this.hora20,
            this.hora21,
            this.hora22});
            this.dgvDitribucion.Location = new System.Drawing.Point(37, 342);
            this.dgvDitribucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDitribucion.Name = "dgvDitribucion";
            this.dgvDitribucion.RowTemplate.Height = 24;
            this.dgvDitribucion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDitribucion.Size = new System.Drawing.Size(1291, 335);
            this.dgvDitribucion.TabIndex = 148;
            this.dgvDitribucion.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDitribucion_CellMouseDoubleClick);
            // 
            // PuntoAtencion
            // 
            this.PuntoAtencion.HeaderText = "Punto de Atención";
            this.PuntoAtencion.Name = "PuntoAtencion";
            // 
            // hora8
            // 
            this.hora8.HeaderText = "8:00";
            this.hora8.Name = "hora8";
            this.hora8.Width = 55;
            // 
            // hora9
            // 
            this.hora9.HeaderText = "9:00";
            this.hora9.Name = "hora9";
            this.hora9.Width = 55;
            // 
            // hora10
            // 
            this.hora10.HeaderText = "10:00";
            this.hora10.Name = "hora10";
            this.hora10.Width = 55;
            // 
            // hora11
            // 
            this.hora11.HeaderText = "11:00";
            this.hora11.Name = "hora11";
            this.hora11.Width = 55;
            // 
            // hora12
            // 
            this.hora12.HeaderText = "12:00";
            this.hora12.Name = "hora12";
            this.hora12.Width = 55;
            // 
            // hora13
            // 
            this.hora13.HeaderText = "13:00";
            this.hora13.Name = "hora13";
            this.hora13.Width = 55;
            // 
            // hora14
            // 
            this.hora14.HeaderText = "14:00";
            this.hora14.Name = "hora14";
            this.hora14.Width = 55;
            // 
            // hora15
            // 
            this.hora15.HeaderText = "15:00";
            this.hora15.Name = "hora15";
            this.hora15.Width = 55;
            // 
            // hora16
            // 
            this.hora16.HeaderText = "16:00";
            this.hora16.Name = "hora16";
            this.hora16.Width = 55;
            // 
            // hora17
            // 
            this.hora17.HeaderText = "17:00";
            this.hora17.Name = "hora17";
            this.hora17.Width = 55;
            // 
            // hora18
            // 
            this.hora18.HeaderText = "18:00";
            this.hora18.Name = "hora18";
            this.hora18.Width = 55;
            // 
            // hora19
            // 
            this.hora19.HeaderText = "19:00";
            this.hora19.Name = "hora19";
            this.hora19.Width = 55;
            // 
            // hora20
            // 
            this.hora20.HeaderText = "20:00";
            this.hora20.Name = "hora20";
            this.hora20.Width = 55;
            // 
            // hora21
            // 
            this.hora21.HeaderText = "21:00";
            this.hora21.Name = "hora21";
            this.hora21.Width = 55;
            // 
            // hora22
            // 
            this.hora22.HeaderText = "22:00";
            this.hora22.Name = "hora22";
            this.hora22.Width = 55;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFinSem);
            this.groupBox1.Controls.Add(this.lblFechaIni);
            this.groupBox1.Controls.Add(this.dtpInicioSem);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.lblSemestre);
            this.groupBox1.Controls.Add(this.btnGuardarDistribucion);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(37, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1291, 177);
            this.groupBox1.TabIndex = 149;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Distribución";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 148;
            this.label1.Text = "-";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.textBox1.Location = new System.Drawing.Point(328, 38);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 32);
            this.textBox1.TabIndex = 147;
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Bahnschrift Light", 12F);
            this.txtNombre.Location = new System.Drawing.Point(164, 38);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(132, 32);
            this.txtNombre.TabIndex = 146;
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(24, 46);
            this.lblSemestre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(86, 20);
            this.lblSemestre.TabIndex = 145;
            this.lblSemestre.Text = "Semestre:";
            // 
            // btnGuardarDistribucion
            // 
            this.btnGuardarDistribucion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(175)))), ((int)(((byte)(169)))));
            this.btnGuardarDistribucion.FlatAppearance.BorderSize = 0;
            this.btnGuardarDistribucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarDistribucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardarDistribucion.Image = global::TA_GesBib_Cliente.Properties.Resources.icono_guardar;
            this.btnGuardarDistribucion.Location = new System.Drawing.Point(935, 117);
            this.btnGuardarDistribucion.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardarDistribucion.Name = "btnGuardarDistribucion";
            this.btnGuardarDistribucion.Size = new System.Drawing.Size(348, 46);
            this.btnGuardarDistribucion.TabIndex = 142;
            this.btnGuardarDistribucion.Text = "GUARDAR DISTRIBUCION";
            this.btnGuardarDistribucion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardarDistribucion.UseVisualStyleBackColor = false;
            this.btnGuardarDistribucion.Click += new System.EventHandler(this.btnGuardarDistribucion_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(175)))), ((int)(((byte)(169)))));
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.Image = global::TA_GesBib_Cliente.Properties.Resources.icono_guardar;
            this.btnGuardar.Location = new System.Drawing.Point(955, 720);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(373, 52);
            this.btnGuardar.TabIndex = 150;
            this.btnGuardar.Text = "GUARDAR DISTRIBUCIÓN";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // lblFechaIni
            // 
            this.lblFechaIni.AutoSize = true;
            this.lblFechaIni.Location = new System.Drawing.Point(24, 98);
            this.lblFechaIni.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaIni.Name = "lblFechaIni";
            this.lblFechaIni.Size = new System.Drawing.Size(130, 20);
            this.lblFechaIni.TabIndex = 150;
            this.lblFechaIni.Text = "Inicio Semestre:";
            // 
            // dtpInicioSem
            // 
            this.dtpInicioSem.Location = new System.Drawing.Point(162, 93);
            this.dtpInicioSem.Margin = new System.Windows.Forms.Padding(4);
            this.dtpInicioSem.Name = "dtpInicioSem";
            this.dtpInicioSem.Size = new System.Drawing.Size(339, 26);
            this.dtpInicioSem.TabIndex = 149;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 152;
            this.label2.Text = "Fin Semestre:";
            // 
            // dtpFinSem
            // 
            this.dtpFinSem.Location = new System.Drawing.Point(162, 127);
            this.dtpFinSem.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFinSem.Name = "dtpFinSem";
            this.dtpFinSem.Size = new System.Drawing.Size(339, 26);
            this.dtpFinSem.TabIndex = 151;
            // 
            // frmDistribucionSemestre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(242)))), ((int)(((byte)(241)))));
            this.ClientSize = new System.Drawing.Size(1369, 817);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvDitribucion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDistribucionSemestre";
            this.Text = "frmDistribucionSemestre";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDitribucion)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvDitribucion;
        private System.Windows.Forms.DataGridViewTextBoxColumn PuntoAtencion;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora8;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora9;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora10;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora11;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora12;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora13;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora14;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora15;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora16;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora17;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora18;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora19;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora20;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora21;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora22;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Button btnGuardarDistribucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFinSem;
        private System.Windows.Forms.Label lblFechaIni;
        private System.Windows.Forms.DateTimePicker dtpInicioSem;
    }
}