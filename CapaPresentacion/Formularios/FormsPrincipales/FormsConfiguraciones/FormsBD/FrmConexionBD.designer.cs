namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsBD
{
    partial class FrmConexionBD
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConexionBD));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConnect = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listaBD = new System.Windows.Forms.ComboBox();
            this.btnGuardarBD = new System.Windows.Forms.Button();
            this.btnSeleccionarBD = new System.Windows.Forms.Button();
            this.txtBDPrincipal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.chkRecordarDestino = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDestino = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkConnect);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.listaBD);
            this.groupBox1.Controls.Add(this.btnGuardarBD);
            this.groupBox1.Controls.Add(this.btnSeleccionarBD);
            this.groupBox1.Controls.Add(this.txtBDPrincipal);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 145);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Archivo de base de datos principal";
            // 
            // chkConnect
            // 
            this.chkConnect.AutoSize = true;
            this.chkConnect.Checked = true;
            this.chkConnect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConnect.Location = new System.Drawing.Point(307, 93);
            this.chkConnect.Name = "chkConnect";
            this.chkConnect.Size = new System.Drawing.Size(139, 38);
            this.chkConnect.TabIndex = 19;
            this.chkConnect.Text = "Conectarse a \r\nesta base de datos";
            this.chkConnect.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(168, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Bases de datos disponibles";
            // 
            // listaBD
            // 
            this.listaBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listaBD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.listaBD.FormattingEnabled = true;
            this.listaBD.Location = new System.Drawing.Point(185, 19);
            this.listaBD.Name = "listaBD";
            this.listaBD.Size = new System.Drawing.Size(285, 25);
            this.listaBD.TabIndex = 17;
            // 
            // btnGuardarBD
            // 
            this.btnGuardarBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardarBD.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardarBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardarBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarBD.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardarBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardarBD.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarBD.Image")));
            this.btnGuardarBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardarBD.Location = new System.Drawing.Point(152, 83);
            this.btnGuardarBD.Name = "btnGuardarBD";
            this.btnGuardarBD.Size = new System.Drawing.Size(140, 56);
            this.btnGuardarBD.TabIndex = 16;
            this.btnGuardarBD.Text = "Guardar";
            this.btnGuardarBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardarBD.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionarBD
            // 
            this.btnSeleccionarBD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionarBD.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnSeleccionarBD.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSeleccionarBD.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSeleccionarBD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionarBD.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionarBD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnSeleccionarBD.Image = ((System.Drawing.Image)(resources.GetObject("btnSeleccionarBD.Image")));
            this.btnSeleccionarBD.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionarBD.Location = new System.Drawing.Point(6, 83);
            this.btnSeleccionarBD.Name = "btnSeleccionarBD";
            this.btnSeleccionarBD.Size = new System.Drawing.Size(140, 56);
            this.btnSeleccionarBD.TabIndex = 15;
            this.btnSeleccionarBD.Text = "Seleccionar archivo";
            this.btnSeleccionarBD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSeleccionarBD.UseVisualStyleBackColor = true;
            // 
            // txtBDPrincipal
            // 
            this.txtBDPrincipal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBDPrincipal.BackColor = System.Drawing.Color.White;
            this.txtBDPrincipal.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtBDPrincipal.Location = new System.Drawing.Point(6, 50);
            this.txtBDPrincipal.Name = "txtBDPrincipal";
            this.txtBDPrincipal.ReadOnly = true;
            this.txtBDPrincipal.Size = new System.Drawing.Size(464, 27);
            this.txtBDPrincipal.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNombreArchivo);
            this.groupBox2.Controls.Add(this.chkRecordarDestino);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtDestino);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnGenerarBackup);
            this.groupBox2.Controls.Add(this.txtOrigen);
            this.groupBox2.Location = new System.Drawing.Point(12, 163);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 254);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Copia de seguridad";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nombre archivo";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreArchivo.BackColor = System.Drawing.Color.White;
            this.txtNombreArchivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreArchivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreArchivo.Location = new System.Drawing.Point(6, 161);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(244, 27);
            this.txtNombreArchivo.TabIndex = 23;
            // 
            // chkRecordarDestino
            // 
            this.chkRecordarDestino.AutoSize = true;
            this.chkRecordarDestino.Checked = true;
            this.chkRecordarDestino.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRecordarDestino.Location = new System.Drawing.Point(6, 121);
            this.chkRecordarDestino.Name = "chkRecordarDestino";
            this.chkRecordarDestino.Size = new System.Drawing.Size(128, 21);
            this.chkRecordarDestino.TabIndex = 22;
            this.chkRecordarDestino.Text = "Recordar destino";
            this.chkRecordarDestino.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Destino";
            // 
            // txtDestino
            // 
            this.txtDestino.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDestino.BackColor = System.Drawing.Color.White;
            this.txtDestino.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDestino.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDestino.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtDestino.Location = new System.Drawing.Point(6, 90);
            this.txtDestino.Name = "txtDestino";
            this.txtDestino.ReadOnly = true;
            this.txtDestino.Size = new System.Drawing.Size(464, 25);
            this.txtDestino.TabIndex = 18;
            this.txtDestino.Text = "Seleccione";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Origen";
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarBackup.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGenerarBackup.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGenerarBackup.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGenerarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarBackup.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarBackup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGenerarBackup.Image = ((System.Drawing.Image)(resources.GetObject("btnGenerarBackup.Image")));
            this.btnGenerarBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGenerarBackup.Location = new System.Drawing.Point(6, 192);
            this.btnGenerarBackup.Name = "btnGenerarBackup";
            this.btnGenerarBackup.Size = new System.Drawing.Size(116, 56);
            this.btnGenerarBackup.TabIndex = 16;
            this.btnGenerarBackup.Text = "Generar\r\nbackup";
            this.btnGenerarBackup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenerarBackup.UseVisualStyleBackColor = true;
            // 
            // txtOrigen
            // 
            this.txtOrigen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOrigen.BackColor = System.Drawing.Color.White;
            this.txtOrigen.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOrigen.Location = new System.Drawing.Point(6, 41);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(464, 27);
            this.txtOrigen.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // FrmConexionBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(500, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConexionBD";
            this.Text = "Conexión base de datos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBDPrincipal;
        private System.Windows.Forms.Button btnSeleccionarBD;
        private System.Windows.Forms.Button btnGuardarBD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnGenerarBackup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox listaBD;
        private System.Windows.Forms.CheckBox chkConnect;
        private System.Windows.Forms.CheckBox chkRecordarDestino;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombreArchivo;
    }
}