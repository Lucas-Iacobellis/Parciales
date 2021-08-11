namespace Formularios
{
    partial class FrmVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVentas));
            this.dataGridViewPedidosIniciales = new System.Windows.Forms.DataGridView();
            this.Nombre_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProducto_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdCliente_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEmpleado_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdVenta_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delivery_Pedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCliente = new System.Windows.Forms.Label();
            this.comboBoxNombreCliente = new System.Windows.Forms.ComboBox();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.txtEmpleado = new System.Windows.Forms.TextBox();
            this.comboBoxApellidoCliente = new System.Windows.Forms.ComboBox();
            this.dataGridViewVentas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidosIniciales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPedidosIniciales
            // 
            this.dataGridViewPedidosIniciales.AllowUserToDeleteRows = false;
            this.dataGridViewPedidosIniciales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPedidosIniciales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewPedidosIniciales.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewPedidosIniciales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPedidosIniciales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre_Pedido,
            this.Precio_Pedido,
            this.Cantidad_Pedido,
            this.IdProducto_Pedido,
            this.Marca_Pedido,
            this.IdCliente_Pedido,
            this.IdEmpleado_Pedido,
            this.IdVenta_Pedido,
            this.Estado_Pedido,
            this.Delivery_Pedido});
            this.dataGridViewPedidosIniciales.Location = new System.Drawing.Point(37, 86);
            this.dataGridViewPedidosIniciales.Name = "dataGridViewPedidosIniciales";
            this.dataGridViewPedidosIniciales.Size = new System.Drawing.Size(359, 669);
            this.dataGridViewPedidosIniciales.TabIndex = 0;
            this.dataGridViewPedidosIniciales.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridViewPedidosIniciales_MouseDown);
            // 
            // Nombre_Pedido
            // 
            this.Nombre_Pedido.HeaderText = "Nombre";
            this.Nombre_Pedido.Name = "Nombre_Pedido";
            // 
            // Precio_Pedido
            // 
            this.Precio_Pedido.HeaderText = "Precio";
            this.Precio_Pedido.Name = "Precio_Pedido";
            // 
            // Cantidad_Pedido
            // 
            this.Cantidad_Pedido.HeaderText = "Cantidad";
            this.Cantidad_Pedido.Name = "Cantidad_Pedido";
            // 
            // IdProducto_Pedido
            // 
            this.IdProducto_Pedido.HeaderText = "IdProducto";
            this.IdProducto_Pedido.Name = "IdProducto_Pedido";
            // 
            // Marca_Pedido
            // 
            this.Marca_Pedido.HeaderText = "Marca";
            this.Marca_Pedido.Name = "Marca_Pedido";
            // 
            // IdCliente_Pedido
            // 
            this.IdCliente_Pedido.HeaderText = "IdCliente";
            this.IdCliente_Pedido.Name = "IdCliente_Pedido";
            // 
            // IdEmpleado_Pedido
            // 
            this.IdEmpleado_Pedido.HeaderText = "IdEmpleado";
            this.IdEmpleado_Pedido.Name = "IdEmpleado_Pedido";
            // 
            // IdVenta_Pedido
            // 
            this.IdVenta_Pedido.HeaderText = "IdVenta";
            this.IdVenta_Pedido.Name = "IdVenta_Pedido";
            // 
            // Estado_Pedido
            // 
            this.Estado_Pedido.HeaderText = "Estado";
            this.Estado_Pedido.Name = "Estado_Pedido";
            // 
            // Delivery_Pedido
            // 
            this.Delivery_Pedido.HeaderText = "Delivery";
            this.Delivery_Pedido.Name = "Delivery_Pedido";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCliente.Location = new System.Drawing.Point(34, 18);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(52, 19);
            this.lblCliente.TabIndex = 3;
            this.lblCliente.Text = "Cliente";
            // 
            // comboBoxNombreCliente
            // 
            this.comboBoxNombreCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxNombreCliente.FormattingEnabled = true;
            this.comboBoxNombreCliente.Location = new System.Drawing.Point(140, 15);
            this.comboBoxNombreCliente.Name = "comboBoxNombreCliente";
            this.comboBoxNombreCliente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxNombreCliente.TabIndex = 4;
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(721, 8);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(100, 28);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "Atras";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.Location = new System.Drawing.Point(34, 57);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(68, 19);
            this.lblVendedor.TabIndex = 6;
            this.lblVendedor.Text = "Vendedor";
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Location = new System.Drawing.Point(140, 57);
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.ReadOnly = true;
            this.txtEmpleado.Size = new System.Drawing.Size(121, 20);
            this.txtEmpleado.TabIndex = 7;
            // 
            // comboBoxApellidoCliente
            // 
            this.comboBoxApellidoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxApellidoCliente.FormattingEnabled = true;
            this.comboBoxApellidoCliente.Location = new System.Drawing.Point(275, 14);
            this.comboBoxApellidoCliente.Name = "comboBoxApellidoCliente";
            this.comboBoxApellidoCliente.Size = new System.Drawing.Size(121, 21);
            this.comboBoxApellidoCliente.TabIndex = 8;
            // 
            // dataGridViewVentas
            // 
            this.dataGridViewVentas.AllowUserToDeleteRows = false;
            this.dataGridViewVentas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewVentas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dataGridViewVentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridViewVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dataGridViewVentas.Location = new System.Drawing.Point(425, 86);
            this.dataGridViewVentas.Name = "dataGridViewVentas";
            this.dataGridViewVentas.Size = new System.Drawing.Size(359, 669);
            this.dataGridViewVentas.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Precio";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Cantidad";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "IdProducto";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Marca";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "IdCliente";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "IdEmpleado";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "IdVenta";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "Estado";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "Delivery";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // FrmVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(822, 749);
            this.Controls.Add(this.dataGridViewVentas);
            this.Controls.Add(this.comboBoxApellidoCliente);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.comboBoxNombreCliente);
            this.Controls.Add(this.lblCliente);
            this.Controls.Add(this.dataGridViewPedidosIniciales);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmVentas_FormClosing);
            this.Load += new System.EventHandler(this.FrmVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPedidosIniciales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPedidosIniciales;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox comboBoxNombreCliente;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.TextBox txtEmpleado;
        private System.Windows.Forms.ComboBox comboBoxApellidoCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProducto_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdCliente_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEmpleado_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVenta_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado_Pedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Delivery_Pedido;
        private System.Windows.Forms.DataGridView dataGridViewVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
    }
}