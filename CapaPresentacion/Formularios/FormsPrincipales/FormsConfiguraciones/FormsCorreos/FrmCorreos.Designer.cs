namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsCorreos
{
    partial class FrmCorreos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCorreos));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCorreoEnvio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClaveEnvio = new System.Windows.Forms.Button();
            this.txtPass1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCorreoReceptor = new System.Windows.Forms.TextBox();
            this.gbPrincipal = new System.Windows.Forms.GroupBox();
            this.chkCopia = new System.Windows.Forms.CheckBox();
            this.gbCopia = new System.Windows.Forms.GroupBox();
            this.txtCopia = new System.Windows.Forms.TextBox();
            this.rdReportes = new System.Windows.Forms.RadioButton();
            this.rdErrores = new System.Windows.Forms.RadioButton();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelarEdicion = new System.Windows.Forms.Button();
            this.chkCorreoTurno = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbPrincipal.SuspendLayout();
            this.gbCopia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCorreoEnvio);
            this.groupBox1.Location = new System.Drawing.Point(6, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Correo electrónico de envío";
            // 
            // txtCorreoEnvio
            // 
            this.txtCorreoEnvio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoEnvio.BackColor = System.Drawing.Color.White;
            this.txtCorreoEnvio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoEnvio.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoEnvio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreoEnvio.Location = new System.Drawing.Point(7, 25);
            this.txtCorreoEnvio.Name = "txtCorreoEnvio";
            this.txtCorreoEnvio.Size = new System.Drawing.Size(261, 20);
            this.txtCorreoEnvio.TabIndex = 0;
            this.txtCorreoEnvio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClaveEnvio);
            this.groupBox2.Controls.Add(this.txtPass1);
            this.groupBox2.Location = new System.Drawing.Point(286, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(321, 56);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contraseña";
            // 
            // btnClaveEnvio
            // 
            this.btnClaveEnvio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClaveEnvio.FlatAppearance.BorderSize = 0;
            this.btnClaveEnvio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClaveEnvio.Image = ((System.Drawing.Image)(resources.GetObject("btnClaveEnvio.Image")));
            this.btnClaveEnvio.Location = new System.Drawing.Point(3, 24);
            this.btnClaveEnvio.Name = "btnClaveEnvio";
            this.btnClaveEnvio.Size = new System.Drawing.Size(21, 21);
            this.btnClaveEnvio.TabIndex = 2;
            this.btnClaveEnvio.UseVisualStyleBackColor = true;
            this.btnClaveEnvio.Visible = false;
            // 
            // txtPass1
            // 
            this.txtPass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPass1.BackColor = System.Drawing.Color.White;
            this.txtPass1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPass1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPass1.Location = new System.Drawing.Point(29, 24);
            this.txtPass1.Name = "txtPass1";
            this.txtPass1.PasswordChar = '*';
            this.txtPass1.Size = new System.Drawing.Size(286, 22);
            this.txtPass1.TabIndex = 0;
            this.txtPass1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPass1.UseSystemPasswordChar = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCorreoReceptor);
            this.groupBox3.Location = new System.Drawing.Point(6, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 56);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Correo electrónico de quien recibe";
            // 
            // txtCorreoReceptor
            // 
            this.txtCorreoReceptor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCorreoReceptor.BackColor = System.Drawing.Color.White;
            this.txtCorreoReceptor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCorreoReceptor.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCorreoReceptor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCorreoReceptor.Location = new System.Drawing.Point(7, 25);
            this.txtCorreoReceptor.Name = "txtCorreoReceptor";
            this.txtCorreoReceptor.Size = new System.Drawing.Size(261, 20);
            this.txtCorreoReceptor.TabIndex = 0;
            this.txtCorreoReceptor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbPrincipal
            // 
            this.gbPrincipal.Controls.Add(this.chkCorreoTurno);
            this.gbPrincipal.Controls.Add(this.chkCopia);
            this.gbPrincipal.Controls.Add(this.gbCopia);
            this.gbPrincipal.Controls.Add(this.groupBox1);
            this.gbPrincipal.Controls.Add(this.groupBox2);
            this.gbPrincipal.Controls.Add(this.groupBox3);
            this.gbPrincipal.Enabled = false;
            this.gbPrincipal.Location = new System.Drawing.Point(12, 39);
            this.gbPrincipal.Name = "gbPrincipal";
            this.gbPrincipal.Size = new System.Drawing.Size(613, 214);
            this.gbPrincipal.TabIndex = 11;
            this.gbPrincipal.TabStop = false;
            this.gbPrincipal.Text = "Información";
            // 
            // chkCopia
            // 
            this.chkCopia.AutoSize = true;
            this.chkCopia.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCopia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkCopia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCopia.Location = new System.Drawing.Point(289, 121);
            this.chkCopia.Name = "chkCopia";
            this.chkCopia.Size = new System.Drawing.Size(115, 21);
            this.chkCopia.TabIndex = 4;
            this.chkCopia.Text = "Envío de copia";
            this.chkCopia.UseVisualStyleBackColor = true;
            // 
            // gbCopia
            // 
            this.gbCopia.Controls.Add(this.txtCopia);
            this.gbCopia.Enabled = false;
            this.gbCopia.Location = new System.Drawing.Point(280, 148);
            this.gbCopia.Name = "gbCopia";
            this.gbCopia.Size = new System.Drawing.Size(321, 56);
            this.gbCopia.TabIndex = 3;
            this.gbCopia.TabStop = false;
            this.gbCopia.Text = "Correo electrónico para envío de copia";
            // 
            // txtCopia
            // 
            this.txtCopia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCopia.BackColor = System.Drawing.Color.White;
            this.txtCopia.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCopia.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCopia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtCopia.Location = new System.Drawing.Point(7, 25);
            this.txtCopia.Name = "txtCopia";
            this.txtCopia.Size = new System.Drawing.Size(308, 20);
            this.txtCopia.TabIndex = 0;
            this.txtCopia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // rdReportes
            // 
            this.rdReportes.AutoSize = true;
            this.rdReportes.Checked = true;
            this.rdReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdReportes.Location = new System.Drawing.Point(12, 12);
            this.rdReportes.Name = "rdReportes";
            this.rdReportes.Size = new System.Drawing.Size(130, 21);
            this.rdReportes.TabIndex = 12;
            this.rdReportes.TabStop = true;
            this.rdReportes.Text = "Envío de reportes";
            this.rdReportes.UseVisualStyleBackColor = true;
            // 
            // rdErrores
            // 
            this.rdErrores.AutoSize = true;
            this.rdErrores.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdErrores.Location = new System.Drawing.Point(148, 12);
            this.rdErrores.Name = "rdErrores";
            this.rdErrores.Size = new System.Drawing.Size(123, 21);
            this.rdErrores.TabIndex = 13;
            this.rdErrores.Text = "Envío de errores";
            this.rdErrores.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(229)))), ((int)(((byte)(217)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(12, 259);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(125, 53);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Habilitar edición";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelarEdicion
            // 
            this.btnCancelarEdicion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnCancelarEdicion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelarEdicion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnCancelarEdicion.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(198)))), ((int)(((byte)(188)))));
            this.btnCancelarEdicion.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(229)))), ((int)(((byte)(217)))));
            this.btnCancelarEdicion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarEdicion.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarEdicion.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarEdicion.Image")));
            this.btnCancelarEdicion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelarEdicion.Location = new System.Drawing.Point(500, 259);
            this.btnCancelarEdicion.Name = "btnCancelarEdicion";
            this.btnCancelarEdicion.Size = new System.Drawing.Size(125, 53);
            this.btnCancelarEdicion.TabIndex = 15;
            this.btnCancelarEdicion.Text = "Cancelar edición";
            this.btnCancelarEdicion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarEdicion.UseVisualStyleBackColor = false;
            this.btnCancelarEdicion.Visible = false;
            // 
            // chkCorreoTurno
            // 
            this.chkCorreoTurno.AutoSize = true;
            this.chkCorreoTurno.Checked = true;
            this.chkCorreoTurno.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCorreoTurno.Location = new System.Drawing.Point(6, 172);
            this.chkCorreoTurno.Name = "chkCorreoTurno";
            this.chkCorreoTurno.Size = new System.Drawing.Size(268, 21);
            this.chkCorreoTurno.TabIndex = 16;
            this.chkCorreoTurno.Text = "Enviar reporte de turno automáticamente";
            this.chkCorreoTurno.UseVisualStyleBackColor = true;
            // 
            // FrmCorreos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(637, 317);
            this.Controls.Add(this.btnCancelarEdicion);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.rdErrores);
            this.Controls.Add(this.rdReportes);
            this.Controls.Add(this.gbPrincipal);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCorreos";
            this.Text = "Configuración de envío de correos";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbPrincipal.ResumeLayout(false);
            this.gbPrincipal.PerformLayout();
            this.gbCopia.ResumeLayout(false);
            this.gbCopia.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCorreoEnvio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtPass1;
        private System.Windows.Forms.Button btnClaveEnvio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtCorreoReceptor;
        private System.Windows.Forms.GroupBox gbPrincipal;
        private System.Windows.Forms.RadioButton rdReportes;
        private System.Windows.Forms.RadioButton rdErrores;
        private System.Windows.Forms.GroupBox gbCopia;
        private System.Windows.Forms.TextBox txtCopia;
        private System.Windows.Forms.CheckBox chkCopia;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelarEdicion;
        private System.Windows.Forms.CheckBox chkCorreoTurno;
    }
}