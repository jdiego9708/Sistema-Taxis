namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsPersonalizacion
{
    partial class FrmPersonalizarAplicacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPersonalizarAplicacion));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardarNombre = new System.Windows.Forms.Button();
            this.txtNombreEmpresa = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gbNuevaBase = new System.Windows.Forms.GroupBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreBD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveBD = new System.Windows.Forms.Button();
            this.btnNuevaBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listaBases = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnGuardarTiempo = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbNuevaBase.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardarNombre);
            this.groupBox1.Controls.Add(this.txtNombreEmpresa);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(470, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nombre de la empresa";
            // 
            // btnGuardarNombre
            // 
            this.btnGuardarNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarNombre.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardarNombre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardarNombre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNombre.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardarNombre.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarNombre.Image")));
            this.btnGuardarNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarNombre.Location = new System.Drawing.Point(6, 55);
            this.btnGuardarNombre.Name = "btnGuardarNombre";
            this.btnGuardarNombre.Size = new System.Drawing.Size(112, 40);
            this.btnGuardarNombre.TabIndex = 22;
            this.btnGuardarNombre.Text = "Guardar";
            this.btnGuardarNombre.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarNombre.UseVisualStyleBackColor = true;
            // 
            // txtNombreEmpresa
            // 
            this.txtNombreEmpresa.Location = new System.Drawing.Point(6, 24);
            this.txtNombreEmpresa.Name = "txtNombreEmpresa";
            this.txtNombreEmpresa.Size = new System.Drawing.Size(456, 25);
            this.txtNombreEmpresa.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbNuevaBase);
            this.groupBox2.Controls.Add(this.btnNuevaBase);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.listaBases);
            this.groupBox2.Location = new System.Drawing.Point(12, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(470, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Administrar bases de datos de clientes";
            // 
            // gbNuevaBase
            // 
            this.gbNuevaBase.Controls.Add(this.txtAlias);
            this.gbNuevaBase.Controls.Add(this.label3);
            this.gbNuevaBase.Controls.Add(this.txtNombreBD);
            this.gbNuevaBase.Controls.Add(this.label2);
            this.gbNuevaBase.Controls.Add(this.btnSaveBD);
            this.gbNuevaBase.Location = new System.Drawing.Point(9, 80);
            this.gbNuevaBase.Name = "gbNuevaBase";
            this.gbNuevaBase.Size = new System.Drawing.Size(426, 126);
            this.gbNuevaBase.TabIndex = 26;
            this.gbNuevaBase.TabStop = false;
            this.gbNuevaBase.Text = "Datos de nueva base";
            this.gbNuevaBase.Visible = false;
            // 
            // txtAlias
            // 
            this.txtAlias.Location = new System.Drawing.Point(237, 41);
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(68, 25);
            this.txtAlias.TabIndex = 28;
            this.txtAlias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(252, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 17);
            this.label3.TabIndex = 27;
            this.label3.Text = "Alias";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNombreBD
            // 
            this.txtNombreBD.Location = new System.Drawing.Point(6, 41);
            this.txtNombreBD.Name = "txtNombreBD";
            this.txtNombreBD.Size = new System.Drawing.Size(225, 25);
            this.txtNombreBD.TabIndex = 26;
            this.txtNombreBD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 25;
            this.label2.Text = "Nombre";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSaveBD
            // 
            this.btnSaveBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveBD.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSaveBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSaveBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveBD.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSaveBD.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBD.Image")));
            this.btnSaveBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveBD.Location = new System.Drawing.Point(9, 72);
            this.btnSaveBD.Name = "btnSaveBD";
            this.btnSaveBD.Size = new System.Drawing.Size(112, 40);
            this.btnSaveBD.TabIndex = 22;
            this.btnSaveBD.Text = "Guardar";
            this.btnSaveBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveBD.UseVisualStyleBackColor = true;
            // 
            // btnNuevaBase
            // 
            this.btnNuevaBase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevaBase.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnNuevaBase.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnNuevaBase.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnNuevaBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaBase.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaBase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnNuevaBase.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevaBase.Image")));
            this.btnNuevaBase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaBase.Location = new System.Drawing.Point(235, 34);
            this.btnNuevaBase.Name = "btnNuevaBase";
            this.btnNuevaBase.Size = new System.Drawing.Size(134, 40);
            this.btnNuevaBase.TabIndex = 25;
            this.btnNuevaBase.Text = "Nueva base";
            this.btnNuevaBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevaBase.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Bases de datos registradas";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listaBases
            // 
            this.listaBases.BackColor = System.Drawing.Color.White;
            this.listaBases.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listaBases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaBases.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.listaBases.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaBases.FormattingEnabled = true;
            this.listaBases.Location = new System.Drawing.Point(6, 41);
            this.listaBases.Name = "listaBases";
            this.listaBases.Size = new System.Drawing.Size(223, 28);
            this.listaBases.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnGuardarTiempo);
            this.groupBox3.Controls.Add(this.numericUpDown1);
            this.groupBox3.Location = new System.Drawing.Point(12, 347);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(470, 73);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tiempo de carreras predeterminado";
            // 
            // btnGuardarTiempo
            // 
            this.btnGuardarTiempo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarTiempo.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardarTiempo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardarTiempo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarTiempo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTiempo.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarTiempo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardarTiempo.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarTiempo.Image")));
            this.btnGuardarTiempo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarTiempo.Location = new System.Drawing.Point(135, 24);
            this.btnGuardarTiempo.Name = "btnGuardarTiempo";
            this.btnGuardarTiempo.Size = new System.Drawing.Size(112, 40);
            this.btnGuardarTiempo.TabIndex = 23;
            this.btnGuardarTiempo.Text = "Guardar";
            this.btnGuardarTiempo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarTiempo.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.BackColor = System.Drawing.Color.White;
            this.numericUpDown1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDown1.Location = new System.Drawing.Point(9, 24);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown1.TabIndex = 0;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // FrmPersonalizarAplicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(486, 426);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmPersonalizarAplicacion";
            this.Text = "Personalizar aplicación";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbNuevaBase.ResumeLayout(false);
            this.gbNuevaBase.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtNombreEmpresa;
        private System.Windows.Forms.Button btnGuardarNombre;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSaveBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox listaBases;
        private System.Windows.Forms.Button btnNuevaBase;
        private System.Windows.Forms.GroupBox gbNuevaBase;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreBD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button btnGuardarTiempo;
    }
}