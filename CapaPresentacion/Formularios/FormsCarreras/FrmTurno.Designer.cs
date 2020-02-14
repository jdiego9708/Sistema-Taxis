namespace CapaPresentacion.Formularios.FormsCarreras
{
    partial class FrmTurno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTurno));
            this.btnAbrir = new System.Windows.Forms.Button();
            this.txtPrincipal = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdVistaPrevia = new System.Windows.Forms.RadioButton();
            this.rdDirecta = new System.Windows.Forms.RadioButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnContinuar = new System.Windows.Forms.Button();
            this.txtInformacion = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAbrir
            // 
            this.btnAbrir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAbrir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbrir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAbrir.FlatAppearance.BorderSize = 0;
            this.btnAbrir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnAbrir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            this.btnAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrir.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbrir.Location = new System.Drawing.Point(17, 132);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(365, 39);
            this.btnAbrir.TabIndex = 19;
            this.btnAbrir.Text = "Abrir turno";
            this.btnAbrir.UseVisualStyleBackColor = false;
            // 
            // txtPrincipal
            // 
            this.txtPrincipal.BackColor = System.Drawing.Color.White;
            this.txtPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrincipal.Enabled = false;
            this.txtPrincipal.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPrincipal.Location = new System.Drawing.Point(17, 3);
            this.txtPrincipal.Name = "txtPrincipal";
            this.txtPrincipal.ReadOnly = true;
            this.txtPrincipal.Size = new System.Drawing.Size(485, 27);
            this.txtPrincipal.TabIndex = 21;
            this.txtPrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdVistaPrevia);
            this.groupBox1.Controls.Add(this.rdDirecta);
            this.groupBox1.Location = new System.Drawing.Point(388, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(109, 84);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Impresión";
            this.groupBox1.Visible = false;
            // 
            // rdVistaPrevia
            // 
            this.rdVistaPrevia.AutoSize = true;
            this.rdVistaPrevia.Checked = true;
            this.rdVistaPrevia.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdVistaPrevia.Location = new System.Drawing.Point(6, 24);
            this.rdVistaPrevia.Name = "rdVistaPrevia";
            this.rdVistaPrevia.Size = new System.Drawing.Size(94, 21);
            this.rdVistaPrevia.TabIndex = 1;
            this.rdVistaPrevia.TabStop = true;
            this.rdVistaPrevia.Text = "Vista previa";
            this.toolTip1.SetToolTip(this.rdVistaPrevia, "Genera una vista previa del informe que se puede guardar en pdf");
            this.rdVistaPrevia.UseVisualStyleBackColor = true;
            // 
            // rdDirecta
            // 
            this.rdDirecta.AutoSize = true;
            this.rdDirecta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rdDirecta.Location = new System.Drawing.Point(6, 51);
            this.rdDirecta.Name = "rdDirecta";
            this.rdDirecta.Size = new System.Drawing.Size(67, 21);
            this.rdDirecta.TabIndex = 0;
            this.rdDirecta.Text = "Directa";
            this.toolTip1.SetToolTip(this.rdDirecta, "Imprime el reporte generado automáticamente en la impresora predeterminada");
            this.rdDirecta.UseVisualStyleBackColor = true;
            // 
            // btnContinuar
            // 
            this.btnContinuar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnContinuar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnContinuar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnContinuar.FlatAppearance.BorderSize = 0;
            this.btnContinuar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(209)))), ((int)(((byte)(218)))));
            this.btnContinuar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(218)))), ((int)(((byte)(236)))));
            this.btnContinuar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContinuar.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinuar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnContinuar.Image = ((System.Drawing.Image)(resources.GetObject("btnContinuar.Image")));
            this.btnContinuar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnContinuar.Location = new System.Drawing.Point(17, 177);
            this.btnContinuar.Name = "btnContinuar";
            this.btnContinuar.Size = new System.Drawing.Size(365, 39);
            this.btnContinuar.TabIndex = 23;
            this.btnContinuar.Text = "Continuar turno";
            this.toolTip1.SetToolTip(this.btnContinuar, "Continúa el turno abierto");
            this.btnContinuar.UseVisualStyleBackColor = false;
            // 
            // txtInformacion
            // 
            this.txtInformacion.BackColor = System.Drawing.Color.White;
            this.txtInformacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInformacion.Enabled = false;
            this.txtInformacion.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInformacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtInformacion.Location = new System.Drawing.Point(17, 36);
            this.txtInformacion.Multiline = true;
            this.txtInformacion.Name = "txtInformacion";
            this.txtInformacion.Size = new System.Drawing.Size(480, 81);
            this.txtInformacion.TabIndex = 24;
            this.txtInformacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FrmTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 219);
            this.Controls.Add(this.txtInformacion);
            this.Controls.Add(this.btnContinuar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtPrincipal);
            this.Controls.Add(this.btnAbrir);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmTurno";
            this.Text = "Turno";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAbrir;
        private System.Windows.Forms.TextBox txtPrincipal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.RadioButton rdDirecta;
        public System.Windows.Forms.RadioButton rdVistaPrevia;
        private System.Windows.Forms.Button btnContinuar;
        private System.Windows.Forms.TextBox txtInformacion;
    }
}