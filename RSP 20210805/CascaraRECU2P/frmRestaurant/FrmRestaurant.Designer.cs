
namespace frmRestaurant
{
    partial class FrmRestaurant
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
            this.DgMenu = new System.Windows.Forms.DataGridView();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnPedir = new System.Windows.Forms.Button();
            this.lblRecaudado = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            this.btnCocinar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // DgMenu
            // 
            this.DgMenu.AllowUserToAddRows = false;
            this.DgMenu.AllowUserToDeleteRows = false;
            this.DgMenu.AllowUserToResizeColumns = false;
            this.DgMenu.AllowUserToResizeRows = false;
            this.DgMenu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgMenu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            this.DgMenu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgMenu.Location = new System.Drawing.Point(26, 53);
            this.DgMenu.Margin = new System.Windows.Forms.Padding(2);
            this.DgMenu.Name = "DgMenu";
            this.DgMenu.RowHeadersWidth = 62;
            this.DgMenu.RowTemplate.Height = 28;
            this.DgMenu.Size = new System.Drawing.Size(473, 205);
            this.DgMenu.TabIndex = 0;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenu.Location = new System.Drawing.Point(22, 31);
            this.lblMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(53, 20);
            this.lblMenu.TabIndex = 1;
            this.lblMenu.Text = "Menu";
            // 
            // btnPedir
            // 
            this.btnPedir.Location = new System.Drawing.Point(262, 278);
            this.btnPedir.Margin = new System.Windows.Forms.Padding(2);
            this.btnPedir.Name = "btnPedir";
            this.btnPedir.Size = new System.Drawing.Size(108, 33);
            this.btnPedir.TabIndex = 2;
            this.btnPedir.Text = "Pedir";
            this.btnPedir.UseVisualStyleBackColor = true;
            this.btnPedir.Click += new System.EventHandler(this.btnPedir_Click);
            // 
            // lblRecaudado
            // 
            this.lblRecaudado.AutoSize = true;
            this.lblRecaudado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecaudado.Location = new System.Drawing.Point(468, 9);
            this.lblRecaudado.Name = "lblRecaudado";
            this.lblRecaudado.Size = new System.Drawing.Size(21, 24);
            this.lblRecaudado.TabIndex = 3;
            this.lblRecaudado.Text = "0";
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaja.Location = new System.Drawing.Point(317, 9);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(123, 24);
            this.lblCaja.TabIndex = 4;
            this.lblCaja.Text = "Recaudado:";
            // 
            // btnCocinar
            // 
            this.btnCocinar.Location = new System.Drawing.Point(391, 278);
            this.btnCocinar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCocinar.Name = "btnCocinar";
            this.btnCocinar.Size = new System.Drawing.Size(108, 33);
            this.btnCocinar.TabIndex = 5;
            this.btnCocinar.Text = "Cocinar";
            this.btnCocinar.UseVisualStyleBackColor = true;
            this.btnCocinar.Click += new System.EventHandler(this.btnCocinar_Click);
            // 
            // FrmRestaurant
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 322);
            this.Controls.Add(this.btnCocinar);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.lblRecaudado);
            this.Controls.Add(this.btnPedir);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.DgMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRestaurant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant UTN";
            this.Load += new System.EventHandler(this.FrmRestaurant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DgMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgMenu;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnPedir;
        private System.Windows.Forms.Label lblRecaudado;
        private System.Windows.Forms.Label lblCaja;
        private System.Windows.Forms.Button btnCocinar;
    }
}

