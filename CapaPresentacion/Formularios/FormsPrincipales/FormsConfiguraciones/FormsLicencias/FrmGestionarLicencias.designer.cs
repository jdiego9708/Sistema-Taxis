namespace CapaPresentacion.Formularios.FormsPrincipales.FormsConfiguraciones.FormsLicencias
{
    partial class FrmGestionarLicencias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGestionarLicencias));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDiasRestantes = new System.Windows.Forms.Label();
            this.txtLicenciaActual = new System.Windows.Forms.TextBox();
            this.btnCambiarLicencia = new System.Windows.Forms.Button();
            this.gbLicenciasLista = new System.Windows.Forms.GroupBox();
            this.rdLicenciaCompleta = new System.Windows.Forms.RadioButton();
            this.rd8dias = new System.Windows.Forms.RadioButton();
            this.rd10dias = new System.Windows.Forms.RadioButton();
            this.rd20dias = new System.Windows.Forms.RadioButton();
            this.rd30dias = new System.Windows.Forms.RadioButton();
            this.gbActivarLicencia = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblDiasRestantesNuevaLicencia = new System.Windows.Forms.Label();
            this.txtNuevaLicencia = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.gbLicenciasLista.SuspendLayout();
            this.gbActivarLicencia.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblDiasRestantes);
            this.groupBox1.Controls.Add(this.txtLicenciaActual);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(358, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Licencia actual";
            // 
            // lblDiasRestantes
            // 
            this.lblDiasRestantes.AutoSize = true;
            this.lblDiasRestantes.Location = new System.Drawing.Point(6, 52);
            this.lblDiasRestantes.Name = "lblDiasRestantes";
            this.lblDiasRestantes.Size = new System.Drawing.Size(90, 17);
            this.lblDiasRestantes.TabIndex = 1;
            this.lblDiasRestantes.Text = "Días restantes";
            // 
            // txtLicenciaActual
            // 
            this.txtLicenciaActual.BackColor = System.Drawing.Color.White;
            this.txtLicenciaActual.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLicenciaActual.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtLicenciaActual.Location = new System.Drawing.Point(6, 24);
            this.txtLicenciaActual.Name = "txtLicenciaActual";
            this.txtLicenciaActual.ReadOnly = true;
            this.txtLicenciaActual.Size = new System.Drawing.Size(346, 25);
            this.txtLicenciaActual.TabIndex = 0;
            this.txtLicenciaActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCambiarLicencia
            // 
            this.btnCambiarLicencia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCambiarLicencia.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnCambiarLicencia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnCambiarLicencia.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCambiarLicencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCambiarLicencia.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCambiarLicencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnCambiarLicencia.Image = ((System.Drawing.Image)(resources.GetObject("btnCambiarLicencia.Image")));
            this.btnCambiarLicencia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCambiarLicencia.Location = new System.Drawing.Point(101, 101);
            this.btnCambiarLicencia.Name = "btnCambiarLicencia";
            this.btnCambiarLicencia.Size = new System.Drawing.Size(165, 38);
            this.btnCambiarLicencia.TabIndex = 21;
            this.btnCambiarLicencia.Text = "Cambiar licencia";
            this.btnCambiarLicencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCambiarLicencia.UseVisualStyleBackColor = true;
            // 
            // gbLicenciasLista
            // 
            this.gbLicenciasLista.Controls.Add(this.rdLicenciaCompleta);
            this.gbLicenciasLista.Controls.Add(this.rd8dias);
            this.gbLicenciasLista.Controls.Add(this.rd10dias);
            this.gbLicenciasLista.Controls.Add(this.rd20dias);
            this.gbLicenciasLista.Controls.Add(this.rd30dias);
            this.gbLicenciasLista.Enabled = false;
            this.gbLicenciasLista.Location = new System.Drawing.Point(12, 145);
            this.gbLicenciasLista.Name = "gbLicenciasLista";
            this.gbLicenciasLista.Size = new System.Drawing.Size(358, 113);
            this.gbLicenciasLista.TabIndex = 23;
            this.gbLicenciasLista.TabStop = false;
            this.gbLicenciasLista.Text = "Licencias en lista";
            // 
            // rdLicenciaCompleta
            // 
            this.rdLicenciaCompleta.AutoSize = true;
            this.rdLicenciaCompleta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdLicenciaCompleta.Location = new System.Drawing.Point(9, 78);
            this.rdLicenciaCompleta.Name = "rdLicenciaCompleta";
            this.rdLicenciaCompleta.Size = new System.Drawing.Size(129, 21);
            this.rdLicenciaCompleta.TabIndex = 4;
            this.rdLicenciaCompleta.TabStop = true;
            this.rdLicenciaCompleta.Tag = "LicenciaCompleta";
            this.rdLicenciaCompleta.Text = "Licencia completa";
            this.rdLicenciaCompleta.UseVisualStyleBackColor = true;
            // 
            // rd8dias
            // 
            this.rd8dias.AutoSize = true;
            this.rd8dias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd8dias.Location = new System.Drawing.Point(157, 51);
            this.rd8dias.Name = "rd8dias";
            this.rd8dias.Size = new System.Drawing.Size(135, 21);
            this.rd8dias.TabIndex = 3;
            this.rd8dias.TabStop = true;
            this.rd8dias.Tag = "Licencia8Dias";
            this.rd8dias.Text = "Licencia por 8 días";
            this.rd8dias.UseVisualStyleBackColor = true;
            // 
            // rd10dias
            // 
            this.rd10dias.AutoSize = true;
            this.rd10dias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd10dias.Location = new System.Drawing.Point(9, 51);
            this.rd10dias.Name = "rd10dias";
            this.rd10dias.Size = new System.Drawing.Size(142, 21);
            this.rd10dias.TabIndex = 2;
            this.rd10dias.TabStop = true;
            this.rd10dias.Tag = "Licencia10Dias";
            this.rd10dias.Text = "Licencia por 10 días";
            this.rd10dias.UseVisualStyleBackColor = true;
            // 
            // rd20dias
            // 
            this.rd20dias.AutoSize = true;
            this.rd20dias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd20dias.Location = new System.Drawing.Point(157, 24);
            this.rd20dias.Name = "rd20dias";
            this.rd20dias.Size = new System.Drawing.Size(142, 21);
            this.rd20dias.TabIndex = 1;
            this.rd20dias.TabStop = true;
            this.rd20dias.Tag = "Licencia20Dias";
            this.rd20dias.Text = "Licencia por 20 días";
            this.rd20dias.UseVisualStyleBackColor = true;
            // 
            // rd30dias
            // 
            this.rd30dias.AutoSize = true;
            this.rd30dias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rd30dias.Location = new System.Drawing.Point(9, 24);
            this.rd30dias.Name = "rd30dias";
            this.rd30dias.Size = new System.Drawing.Size(142, 21);
            this.rd30dias.TabIndex = 0;
            this.rd30dias.TabStop = true;
            this.rd30dias.Tag = "Licencia30Dias";
            this.rd30dias.Text = "Licencia por 30 días";
            this.rd30dias.UseVisualStyleBackColor = true;
            // 
            // gbActivarLicencia
            // 
            this.gbActivarLicencia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbActivarLicencia.Controls.Add(this.btnGuardar);
            this.gbActivarLicencia.Controls.Add(this.lblDiasRestantesNuevaLicencia);
            this.gbActivarLicencia.Controls.Add(this.txtNuevaLicencia);
            this.gbActivarLicencia.Location = new System.Drawing.Point(12, 264);
            this.gbActivarLicencia.Name = "gbActivarLicencia";
            this.gbActivarLicencia.Size = new System.Drawing.Size(358, 172);
            this.gbActivarLicencia.TabIndex = 24;
            this.gbActivarLicencia.TabStop = false;
            this.gbActivarLicencia.Text = "Digite la clave de licencia";
            this.gbActivarLicencia.Visible = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(103, 97);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(140, 56);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // lblDiasRestantesNuevaLicencia
            // 
            this.lblDiasRestantesNuevaLicencia.AutoSize = true;
            this.lblDiasRestantesNuevaLicencia.Location = new System.Drawing.Point(6, 52);
            this.lblDiasRestantesNuevaLicencia.Name = "lblDiasRestantesNuevaLicencia";
            this.lblDiasRestantesNuevaLicencia.Size = new System.Drawing.Size(90, 17);
            this.lblDiasRestantesNuevaLicencia.TabIndex = 1;
            this.lblDiasRestantesNuevaLicencia.Text = "Días restantes";
            // 
            // txtNuevaLicencia
            // 
            this.txtNuevaLicencia.BackColor = System.Drawing.Color.White;
            this.txtNuevaLicencia.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaLicencia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNuevaLicencia.Location = new System.Drawing.Point(6, 24);
            this.txtNuevaLicencia.Name = "txtNuevaLicencia";
            this.txtNuevaLicencia.Size = new System.Drawing.Size(346, 25);
            this.txtNuevaLicencia.TabIndex = 0;
            this.txtNuevaLicencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmGestionarLicencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(374, 448);
            this.Controls.Add(this.gbActivarLicencia);
            this.Controls.Add(this.gbLicenciasLista);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCambiarLicencia);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGestionarLicencias";
            this.Text = "Gestionar licencias";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbLicenciasLista.ResumeLayout(false);
            this.gbLicenciasLista.PerformLayout();
            this.gbActivarLicencia.ResumeLayout(false);
            this.gbActivarLicencia.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLicenciaActual;
        private System.Windows.Forms.Button btnCambiarLicencia;
        private System.Windows.Forms.Label lblDiasRestantes;
        private System.Windows.Forms.GroupBox gbLicenciasLista;
        private System.Windows.Forms.RadioButton rdLicenciaCompleta;
        private System.Windows.Forms.RadioButton rd8dias;
        private System.Windows.Forms.RadioButton rd10dias;
        private System.Windows.Forms.RadioButton rd20dias;
        private System.Windows.Forms.RadioButton rd30dias;
        private System.Windows.Forms.GroupBox gbActivarLicencia;
        private System.Windows.Forms.Label lblDiasRestantesNuevaLicencia;
        private System.Windows.Forms.TextBox txtNuevaLicencia;
        private System.Windows.Forms.Button btnGuardar;
    }
}