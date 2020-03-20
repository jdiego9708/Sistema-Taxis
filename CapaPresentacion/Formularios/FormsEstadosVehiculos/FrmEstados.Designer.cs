namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    partial class FrmEstados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstados));
            this.btnAgregarEstado = new System.Windows.Forms.Button();
            this.panelEstados = new CapaPresentacion.CustomGridPanel();
            this.SuspendLayout();
            // 
            // btnAgregarEstado
            // 
            this.btnAgregarEstado.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarEstado.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarEstado.BackgroundImage")));
            this.btnAgregarEstado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarEstado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarEstado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregarEstado.FlatAppearance.BorderSize = 0;
            this.btnAgregarEstado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregarEstado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregarEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarEstado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarEstado.Location = new System.Drawing.Point(12, 12);
            this.btnAgregarEstado.Name = "btnAgregarEstado";
            this.btnAgregarEstado.Size = new System.Drawing.Size(31, 30);
            this.btnAgregarEstado.TabIndex = 39;
            this.btnAgregarEstado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarEstado.UseVisualStyleBackColor = false;
            // 
            // panelEstados
            // 
            this.panelEstados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelEstados.AutoScroll = true;
            this.panelEstados.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panelEstados.BackgroundImage")));
            this.panelEstados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelEstados.Location = new System.Drawing.Point(12, 48);
            this.panelEstados.Name = "panelEstados";
            this.panelEstados.PageSize = 10;
            this.panelEstados.Size = new System.Drawing.Size(459, 296);
            this.panelEstados.TabIndex = 40;
            // 
            // FrmEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(483, 356);
            this.Controls.Add(this.panelEstados);
            this.Controls.Add(this.btnAgregarEstado);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEstados";
            this.Text = "Estados";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregarEstado;
        private CustomGridPanel panelEstados;
    }
}