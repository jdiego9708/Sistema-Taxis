namespace CapaPresentacion.Formularios.FormsCarreras
{
    partial class ConfigTime
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbMensaje = new System.Windows.Forms.GroupBox();
            this.numericMinutos = new System.Windows.Forms.NumericUpDown();
            this.gbMensaje.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutos)).BeginInit();
            this.SuspendLayout();
            // 
            // gbMensaje
            // 
            this.gbMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMensaje.Controls.Add(this.numericMinutos);
            this.gbMensaje.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMensaje.Location = new System.Drawing.Point(7, 3);
            this.gbMensaje.Name = "gbMensaje";
            this.gbMensaje.Size = new System.Drawing.Size(118, 68);
            this.gbMensaje.TabIndex = 0;
            this.gbMensaje.TabStop = false;
            this.gbMensaje.Text = "Mensaje";
            // 
            // numericMinutos
            // 
            this.numericMinutos.BackColor = System.Drawing.Color.White;
            this.numericMinutos.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericMinutos.ForeColor = System.Drawing.Color.Gray;
            this.numericMinutos.Location = new System.Drawing.Point(6, 24);
            this.numericMinutos.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericMinutos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericMinutos.Name = "numericMinutos";
            this.numericMinutos.Size = new System.Drawing.Size(106, 33);
            this.numericMinutos.TabIndex = 0;
            this.numericMinutos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericMinutos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ConfigTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.gbMensaje);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigTime";
            this.Size = new System.Drawing.Size(128, 74);
            this.gbMensaje.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericMinutos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbMensaje;
        private System.Windows.Forms.NumericUpDown numericMinutos;
    }
}
