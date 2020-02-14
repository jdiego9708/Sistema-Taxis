namespace CapaPresentacion.Formularios.FormsCarreras
{
    partial class FrmCarreras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCarreras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbVehiculos = new System.Windows.Forms.GroupBox();
            this.panelVehiculos = new CapaPresentacion.CustomGridPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.gbClientes = new System.Windows.Forms.GroupBox();
            this.panelClientes = new CapaPresentacion.CustomGridPanel();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.gbCarreras = new System.Windows.Forms.GroupBox();
            this.dgvCarreras = new CapaPresentacion.CustomDataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.btnCarrerasTerminadas = new System.Windows.Forms.Button();
            this.btnCarrerasEnCurso = new System.Windows.Forms.Button();
            this.btnCarrerasCanceladas = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnFinalizarTurno = new System.Windows.Forms.Button();
            this.gbVehiculos.SuspendLayout();
            this.panelVehiculos.SuspendLayout();
            this.gbClientes.SuspendLayout();
            this.gbCarreras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbVehiculos
            // 
            this.gbVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbVehiculos.Controls.Add(this.panelVehiculos);
            this.gbVehiculos.Location = new System.Drawing.Point(12, 12);
            this.gbVehiculos.Name = "gbVehiculos";
            this.gbVehiculos.Size = new System.Drawing.Size(1236, 160);
            this.gbVehiculos.TabIndex = 0;
            this.gbVehiculos.TabStop = false;
            this.gbVehiculos.Text = "Vehículos";
            // 
            // panelVehiculos
            // 
            this.panelVehiculos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelVehiculos.AutoScroll = true;
            this.panelVehiculos.Controls.Add(this.button1);
            this.panelVehiculos.Location = new System.Drawing.Point(6, 24);
            this.panelVehiculos.Name = "panelVehiculos";
            this.panelVehiculos.PageSize = 10;
            this.panelVehiculos.Size = new System.Drawing.Size(1224, 130);
            this.panelVehiculos.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(246)))), ((int)(((byte)(64)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(92)))), ((int)(((byte)(92)))));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Código";
            this.button1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnReporte
            // 
            this.btnReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReporte.BackColor = System.Drawing.Color.Transparent;
            this.btnReporte.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReporte.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReporte.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReporte.Location = new System.Drawing.Point(779, 14);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(97, 42);
            this.btnReporte.TabIndex = 42;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnReporte, "Reporte de carreras hasta la fecha");
            this.btnReporte.UseVisualStyleBackColor = false;
            // 
            // gbClientes
            // 
            this.gbClientes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbClientes.Controls.Add(this.btnFinalizarTurno);
            this.gbClientes.Controls.Add(this.btnReporte);
            this.gbClientes.Controls.Add(this.panelClientes);
            this.gbClientes.Controls.Add(this.btnAgregarCliente);
            this.gbClientes.Location = new System.Drawing.Point(12, 178);
            this.gbClientes.Name = "gbClientes";
            this.gbClientes.Size = new System.Drawing.Size(994, 398);
            this.gbClientes.TabIndex = 2;
            this.gbClientes.TabStop = false;
            this.gbClientes.Text = "Clientes";
            // 
            // panelClientes
            // 
            this.panelClientes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelClientes.AutoScroll = true;
            this.panelClientes.Location = new System.Drawing.Point(6, 60);
            this.panelClientes.Name = "panelClientes";
            this.panelClientes.PageSize = 10;
            this.panelClientes.Size = new System.Drawing.Size(982, 332);
            this.panelClientes.TabIndex = 39;
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarCliente.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCliente.BackgroundImage")));
            this.btnAgregarCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAgregarCliente.FlatAppearance.BorderSize = 0;
            this.btnAgregarCliente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregarCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarCliente.Location = new System.Drawing.Point(6, 24);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(31, 30);
            this.btnAgregarCliente.TabIndex = 38;
            this.btnAgregarCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregarCliente.UseVisualStyleBackColor = false;
            // 
            // gbCarreras
            // 
            this.gbCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCarreras.Controls.Add(this.dgvCarreras);
            this.gbCarreras.Controls.Add(this.bindingNavigator1);
            this.gbCarreras.Controls.Add(this.btnCarrerasTerminadas);
            this.gbCarreras.Controls.Add(this.btnCarrerasEnCurso);
            this.gbCarreras.Controls.Add(this.btnCarrerasCanceladas);
            this.gbCarreras.Location = new System.Drawing.Point(1012, 178);
            this.gbCarreras.Name = "gbCarreras";
            this.gbCarreras.Size = new System.Drawing.Size(236, 398);
            this.gbCarreras.TabIndex = 3;
            this.gbCarreras.TabStop = false;
            this.gbCarreras.Text = "Carreras";
            // 
            // dgvCarreras
            // 
            this.dgvCarreras.AllowUserToAddRows = false;
            this.dgvCarreras.AllowUserToDeleteRows = false;
            this.dgvCarreras.AllowUserToResizeColumns = false;
            this.dgvCarreras.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            this.dgvCarreras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCarreras.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCarreras.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCarreras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCarreras.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCarreras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvCarreras.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Bisque;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCarreras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCarreras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ScrollBar;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCarreras.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCarreras.IsTextCenter = true;
            this.dgvCarreras.Location = new System.Drawing.Point(7, 65);
            this.dgvCarreras.Name = "dgvCarreras";
            this.dgvCarreras.PageSize = 10;
            this.dgvCarreras.ReadOnly = true;
            this.dgvCarreras.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvCarreras.RowHeadersVisible = false;
            this.dgvCarreras.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Bisque;
            this.dgvCarreras.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCarreras.RowTemplate.Height = 30;
            this.dgvCarreras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCarreras.Size = new System.Drawing.Size(204, 299);
            this.dgvCarreras.TabIndex = 7;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(7, 367);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(205, 25);
            this.bindingNavigator1.TabIndex = 42;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 22);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // btnCarrerasTerminadas
            // 
            this.btnCarrerasTerminadas.BackColor = System.Drawing.Color.Transparent;
            this.btnCarrerasTerminadas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCarrerasTerminadas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrerasTerminadas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCarrerasTerminadas.FlatAppearance.BorderSize = 0;
            this.btnCarrerasTerminadas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCarrerasTerminadas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCarrerasTerminadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarrerasTerminadas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarrerasTerminadas.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrerasTerminadas.Image")));
            this.btnCarrerasTerminadas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarrerasTerminadas.Location = new System.Drawing.Point(232, 17);
            this.btnCarrerasTerminadas.Name = "btnCarrerasTerminadas";
            this.btnCarrerasTerminadas.Size = new System.Drawing.Size(109, 42);
            this.btnCarrerasTerminadas.TabIndex = 39;
            this.btnCarrerasTerminadas.Text = "Carreras \r\nterminadas";
            this.btnCarrerasTerminadas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCarrerasTerminadas, "Muestra las carreras terminadas del día actual");
            this.btnCarrerasTerminadas.UseVisualStyleBackColor = false;
            // 
            // btnCarrerasEnCurso
            // 
            this.btnCarrerasEnCurso.BackColor = System.Drawing.Color.Transparent;
            this.btnCarrerasEnCurso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCarrerasEnCurso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrerasEnCurso.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCarrerasEnCurso.FlatAppearance.BorderSize = 0;
            this.btnCarrerasEnCurso.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCarrerasEnCurso.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCarrerasEnCurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarrerasEnCurso.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarrerasEnCurso.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrerasEnCurso.Image")));
            this.btnCarrerasEnCurso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarrerasEnCurso.Location = new System.Drawing.Point(7, 17);
            this.btnCarrerasEnCurso.Name = "btnCarrerasEnCurso";
            this.btnCarrerasEnCurso.Size = new System.Drawing.Size(98, 42);
            this.btnCarrerasEnCurso.TabIndex = 41;
            this.btnCarrerasEnCurso.Text = "Carreras \r\nen curso";
            this.btnCarrerasEnCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCarrerasEnCurso, "Muestra las carreras en curso");
            this.btnCarrerasEnCurso.UseVisualStyleBackColor = false;
            // 
            // btnCarrerasCanceladas
            // 
            this.btnCarrerasCanceladas.BackColor = System.Drawing.Color.Transparent;
            this.btnCarrerasCanceladas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCarrerasCanceladas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCarrerasCanceladas.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCarrerasCanceladas.FlatAppearance.BorderSize = 0;
            this.btnCarrerasCanceladas.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCarrerasCanceladas.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCarrerasCanceladas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCarrerasCanceladas.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCarrerasCanceladas.Image = ((System.Drawing.Image)(resources.GetObject("btnCarrerasCanceladas.Image")));
            this.btnCarrerasCanceladas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCarrerasCanceladas.Location = new System.Drawing.Point(111, 17);
            this.btnCarrerasCanceladas.Name = "btnCarrerasCanceladas";
            this.btnCarrerasCanceladas.Size = new System.Drawing.Size(115, 42);
            this.btnCarrerasCanceladas.TabIndex = 40;
            this.btnCarrerasCanceladas.Text = "Carreras \r\ncanceladas";
            this.btnCarrerasCanceladas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnCarrerasCanceladas, "Muestra las carreras canceladas del día actual");
            this.btnCarrerasCanceladas.UseVisualStyleBackColor = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            // 
            // btnFinalizarTurno
            // 
            this.btnFinalizarTurno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizarTurno.BackColor = System.Drawing.Color.Transparent;
            this.btnFinalizarTurno.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFinalizarTurno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizarTurno.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFinalizarTurno.FlatAppearance.BorderSize = 0;
            this.btnFinalizarTurno.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFinalizarTurno.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnFinalizarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizarTurno.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizarTurno.Image = ((System.Drawing.Image)(resources.GetObject("btnFinalizarTurno.Image")));
            this.btnFinalizarTurno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFinalizarTurno.Location = new System.Drawing.Point(882, 14);
            this.btnFinalizarTurno.Name = "btnFinalizarTurno";
            this.btnFinalizarTurno.Size = new System.Drawing.Size(105, 42);
            this.btnFinalizarTurno.TabIndex = 43;
            this.btnFinalizarTurno.Text = "Finalizar \r\nturno";
            this.btnFinalizarTurno.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnFinalizarTurno, "Finaliza el turno actual");
            this.btnFinalizarTurno.UseVisualStyleBackColor = false;
            // 
            // FrmCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1260, 588);
            this.Controls.Add(this.gbCarreras);
            this.Controls.Add(this.gbClientes);
            this.Controls.Add(this.gbVehiculos);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmCarreras";
            this.Text = "Carreras";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.gbVehiculos.ResumeLayout(false);
            this.panelVehiculos.ResumeLayout(false);
            this.gbClientes.ResumeLayout(false);
            this.gbCarreras.ResumeLayout(false);
            this.gbCarreras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarreras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbVehiculos;
        private System.Windows.Forms.Button button1;
        private CustomGridPanel panelVehiculos;
        private System.Windows.Forms.GroupBox gbClientes;
        private System.Windows.Forms.GroupBox gbCarreras;
        private System.Windows.Forms.Button btnAgregarCliente;
        private CustomGridPanel panelClientes;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnCarrerasTerminadas;
        private System.Windows.Forms.Button btnCarrerasCanceladas;
        private System.Windows.Forms.Button btnCarrerasEnCurso;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private CustomDataGridView dgvCarreras;
        private System.Windows.Forms.Button btnFinalizarTurno;
    }
}