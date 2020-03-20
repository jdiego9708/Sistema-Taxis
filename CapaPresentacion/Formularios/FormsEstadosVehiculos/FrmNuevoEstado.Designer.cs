﻿namespace CapaPresentacion.Formularios.FormsEstadosVehiculos
{
    partial class FrmNuevoEstado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevoEstado));
            this.gbNombre = new System.Windows.Forms.GroupBox();
            this.txtNombreEstado = new System.Windows.Forms.TextBox();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.btnColor = new System.Windows.Forms.Button();
            this.gbAlias = new System.Windows.Forms.GroupBox();
            this.txtAlias = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbNombre.SuspendLayout();
            this.gbColor.SuspendLayout();
            this.gbAlias.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbNombre
            // 
            this.gbNombre.Controls.Add(this.txtNombreEstado);
            this.gbNombre.Location = new System.Drawing.Point(12, 12);
            this.gbNombre.Name = "gbNombre";
            this.gbNombre.Size = new System.Drawing.Size(279, 56);
            this.gbNombre.TabIndex = 2;
            this.gbNombre.TabStop = false;
            this.gbNombre.Text = "Nombre del estado";
            // 
            // txtNombreEstado
            // 
            this.txtNombreEstado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombreEstado.BackColor = System.Drawing.Color.White;
            this.txtNombreEstado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreEstado.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtNombreEstado.Location = new System.Drawing.Point(7, 24);
            this.txtNombreEstado.MaxLength = 13;
            this.txtNombreEstado.Name = "txtNombreEstado";
            this.txtNombreEstado.Size = new System.Drawing.Size(266, 22);
            this.txtNombreEstado.TabIndex = 1;
            this.txtNombreEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.btnColor);
            this.gbColor.Location = new System.Drawing.Point(12, 74);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(429, 58);
            this.gbColor.TabIndex = 3;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // btnColor
            // 
            this.btnColor.BackColor = System.Drawing.Color.White;
            this.btnColor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnColor.FlatAppearance.BorderSize = 0;
            this.btnColor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColor.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnColor.Image = ((System.Drawing.Image)(resources.GetObject("btnColor.Image")));
            this.btnColor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnColor.Location = new System.Drawing.Point(7, 19);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(344, 32);
            this.btnColor.TabIndex = 9;
            this.btnColor.Text = "Seleccionar color";
            this.btnColor.UseVisualStyleBackColor = false;
            // 
            // gbAlias
            // 
            this.gbAlias.Controls.Add(this.txtAlias);
            this.gbAlias.Location = new System.Drawing.Point(297, 12);
            this.gbAlias.Name = "gbAlias";
            this.gbAlias.Size = new System.Drawing.Size(144, 56);
            this.gbAlias.TabIndex = 4;
            this.gbAlias.TabStop = false;
            this.gbAlias.Text = "Alias";
            // 
            // txtAlias
            // 
            this.txtAlias.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAlias.BackColor = System.Drawing.Color.White;
            this.txtAlias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAlias.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAlias.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAlias.Location = new System.Drawing.Point(7, 24);
            this.txtAlias.MaxLength = 13;
            this.txtAlias.Name = "txtAlias";
            this.txtAlias.Size = new System.Drawing.Size(131, 22);
            this.txtAlias.TabIndex = 1;
            this.txtAlias.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(141)))), ((int)(((byte)(163)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(320, 138);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(121, 42);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // FrmNuevoEstado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(453, 186);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.gbAlias);
            this.Controls.Add(this.gbColor);
            this.Controls.Add(this.gbNombre);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNuevoEstado";
            this.Text = "Nuevo estado";
            this.gbNombre.ResumeLayout(false);
            this.gbNombre.PerformLayout();
            this.gbColor.ResumeLayout(false);
            this.gbAlias.ResumeLayout(false);
            this.gbAlias.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbNombre;
        private System.Windows.Forms.TextBox txtNombreEstado;
        public System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.Button btnColor;
        public System.Windows.Forms.GroupBox gbAlias;
        private System.Windows.Forms.TextBox txtAlias;
        private System.Windows.Forms.Button btnGuardar;
    }
}