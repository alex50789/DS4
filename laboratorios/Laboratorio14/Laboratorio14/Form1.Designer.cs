namespace Laboratorio14
{
    partial class frmProductos
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductos));
            lbl_Id = new Label();
            txtId = new TextBox();
            lbl_Nombre = new Label();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            lbl_Precio = new Label();
            lbl_Stock = new Label();
            txtStock = new TextBox();
            btnSalir = new Button();
            pictureBox1 = new PictureBox();
            tsbNuevo = new PictureBox();
            tsbGuardar = new PictureBox();
            tsbCancelar = new PictureBox();
            tsbEliminar = new PictureBox();
            label5 = new Label();
            tstId = new TextBox();
            tsbBuscar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbNuevo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbGuardar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbCancelar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbEliminar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tsbBuscar).BeginInit();
            SuspendLayout();
            // 
            // lbl_Id
            // 
            lbl_Id.AutoSize = true;
            lbl_Id.Location = new Point(25, 67);
            lbl_Id.Name = "lbl_Id";
            lbl_Id.Size = new Size(17, 15);
            lbl_Id.TabIndex = 0;
            lbl_Id.Text = "Id";
            // 
            // txtId
            // 
            txtId.Location = new Point(25, 88);
            txtId.Margin = new Padding(3, 2, 3, 2);
            txtId.Name = "txtId";
            txtId.Size = new Size(110, 23);
            txtId.TabIndex = 1;
            // 
            // lbl_Nombre
            // 
            lbl_Nombre.AutoSize = true;
            lbl_Nombre.Location = new Point(189, 67);
            lbl_Nombre.Name = "lbl_Nombre";
            lbl_Nombre.Size = new Size(51, 15);
            lbl_Nombre.TabIndex = 2;
            lbl_Nombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(189, 88);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(332, 23);
            txtNombre.TabIndex = 3;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(25, 157);
            txtPrecio.Margin = new Padding(3, 2, 3, 2);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(110, 23);
            txtPrecio.TabIndex = 4;
            // 
            // lbl_Precio
            // 
            lbl_Precio.AutoSize = true;
            lbl_Precio.Location = new Point(25, 129);
            lbl_Precio.Name = "lbl_Precio";
            lbl_Precio.Size = new Size(40, 15);
            lbl_Precio.TabIndex = 5;
            lbl_Precio.Text = "Precio";
            // 
            // lbl_Stock
            // 
            lbl_Stock.AutoSize = true;
            lbl_Stock.Location = new Point(189, 129);
            lbl_Stock.Name = "lbl_Stock";
            lbl_Stock.Size = new Size(36, 15);
            lbl_Stock.TabIndex = 6;
            lbl_Stock.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(189, 157);
            txtStock.Margin = new Padding(3, 2, 3, 2);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(110, 23);
            txtStock.TabIndex = 7;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(25, 259);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(82, 22);
            btnSalir.TabIndex = 8;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(155, 88);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(0, 0);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = (Image)resources.GetObject("tsbNuevo.Image");
            tsbNuevo.Location = new Point(0, -1);
            tsbNuevo.Margin = new Padding(3, 2, 3, 2);
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(28, 15);
            tsbNuevo.SizeMode = PictureBoxSizeMode.Zoom;
            tsbNuevo.TabIndex = 10;
            tsbNuevo.TabStop = false;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbGuardar
            // 
            tsbGuardar.Image = (Image)resources.GetObject("tsbGuardar.Image");
            tsbGuardar.Location = new Point(25, -1);
            tsbGuardar.Name = "tsbGuardar";
            tsbGuardar.Size = new Size(30, 15);
            tsbGuardar.SizeMode = PictureBoxSizeMode.Zoom;
            tsbGuardar.TabIndex = 11;
            tsbGuardar.TabStop = false;
            tsbGuardar.Click += tsbGuardar_Click;
            // 
            // tsbCancelar
            // 
            tsbCancelar.Image = (Image)resources.GetObject("tsbCancelar.Image");
            tsbCancelar.Location = new Point(50, -1);
            tsbCancelar.Name = "tsbCancelar";
            tsbCancelar.Size = new Size(26, 15);
            tsbCancelar.SizeMode = PictureBoxSizeMode.Zoom;
            tsbCancelar.TabIndex = 12;
            tsbCancelar.TabStop = false;
            tsbCancelar.Click += tsbCancelar_Click;
            // 
            // tsbEliminar
            // 
            tsbEliminar.Image = (Image)resources.GetObject("tsbEliminar.Image");
            tsbEliminar.Location = new Point(72, -1);
            tsbEliminar.Name = "tsbEliminar";
            tsbEliminar.Size = new Size(26, 15);
            tsbEliminar.SizeMode = PictureBoxSizeMode.Zoom;
            tsbEliminar.TabIndex = 13;
            tsbEliminar.TabStop = false;
            tsbEliminar.Click += tsbEliminar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(104, 2);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 14;
            label5.Text = "Buscar por id:";
            // 
            // tstId
            // 
            tstId.Location = new Point(189, -1);
            tstId.Name = "tstId";
            tstId.Size = new Size(100, 23);
            tstId.TabIndex = 15;
            // 
            // tsbBuscar
            // 
            tsbBuscar.Image = (Image)resources.GetObject("tsbBuscar.Image");
            tsbBuscar.Location = new Point(286, -1);
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(24, 18);
            tsbBuscar.SizeMode = PictureBoxSizeMode.Zoom;
            tsbBuscar.TabIndex = 16;
            tsbBuscar.TabStop = false;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // frmProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(tsbBuscar);
            Controls.Add(tstId);
            Controls.Add(label5);
            Controls.Add(tsbEliminar);
            Controls.Add(tsbCancelar);
            Controls.Add(tsbGuardar);
            Controls.Add(tsbNuevo);
            Controls.Add(pictureBox1);
            Controls.Add(btnSalir);
            Controls.Add(txtStock);
            Controls.Add(lbl_Stock);
            Controls.Add(lbl_Precio);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(lbl_Nombre);
            Controls.Add(txtId);
            Controls.Add(lbl_Id);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmProductos";
            Text = "Productos";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbNuevo).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbGuardar).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbCancelar).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbEliminar).EndInit();
            ((System.ComponentModel.ISupportInitialize)tsbBuscar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Id;
        private TextBox txtId;
        private Label lbl_Nombre;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private Label lbl_Precio;
        private Label lbl_Stock;
        private TextBox txtStock;
        private Button btnSalir;
        private PictureBox pictureBox1;
        private PictureBox tsbNuevo;
        private PictureBox tsbGuardar;
        private PictureBox tsbCancelar;
        private PictureBox tsbEliminar;
        private Label label5;
        private TextBox tstId;
        private PictureBox tsbBuscar;
    }
}
