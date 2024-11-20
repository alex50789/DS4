namespace labo12
{
    partial class Form1
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
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            label2 = new Label();
            Variable1 = new TextBox();
            label3 = new Label();
            Variable2 = new TextBox();
            btCalcular = new Button();
            btLimpiar = new Button();
            btSalir = new Button();
            label4 = new Label();
            resultado = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(176, 30);
            label1.Name = "label1";
            label1.Size = new Size(120, 15);
            label1.TabIndex = 0;
            label1.Text = "Calculadora distancia";
            label1.Click += label1_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(39, 82);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(0, 15);
            linkLabel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 82);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 2;
            label2.Text = "velocidad";
            // 
            // Variable1
            // 
            Variable1.Location = new Point(155, 74);
            Variable1.Name = "Variable1";
            Variable1.Size = new Size(158, 23);
            Variable1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 140);
            label3.Name = "label3";
            label3.Size = new Size(45, 15);
            label3.TabIndex = 4;
            label3.Text = "tiempo";
            // 
            // Variable2
            // 
            Variable2.Location = new Point(155, 132);
            Variable2.Name = "Variable2";
            Variable2.Size = new Size(158, 23);
            Variable2.TabIndex = 5;
            // 
            // btCalcular
            // 
            btCalcular.Location = new Point(28, 196);
            btCalcular.Name = "btCalcular";
            btCalcular.Size = new Size(84, 36);
            btCalcular.TabIndex = 6;
            btCalcular.Text = "calcular";
            btCalcular.UseVisualStyleBackColor = true;
            btCalcular.Click += btCalcular_Click;
            // 
            // btLimpiar
            // 
            btLimpiar.Location = new Point(141, 196);
            btLimpiar.Name = "btLimpiar";
            btLimpiar.Size = new Size(84, 36);
            btLimpiar.TabIndex = 7;
            btLimpiar.Text = "limpiar";
            btLimpiar.UseVisualStyleBackColor = true;
            btLimpiar.Click += btLimpiar_Click;
            // 
            // btSalir
            // 
            btSalir.Location = new Point(258, 196);
            btSalir.Name = "btSalir";
            btSalir.Size = new Size(84, 36);
            btSalir.TabIndex = 8;
            btSalir.Text = "salir";
            btSalir.UseVisualStyleBackColor = true;
            btSalir.Click += btSalir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(39, 287);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 9;
            label4.Text = "resultado";
            // 
            // resultado
            // 
            resultado.Location = new Point(155, 287);
            resultado.Name = "resultado";
            resultado.Size = new Size(158, 23);
            resultado.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(resultado);
            Controls.Add(label4);
            Controls.Add(btSalir);
            Controls.Add(btLimpiar);
            Controls.Add(btCalcular);
            Controls.Add(Variable2);
            Controls.Add(label3);
            Controls.Add(Variable1);
            Controls.Add(label2);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private LinkLabel linkLabel1;
        private Label label2;
        private TextBox Variable1;
        private Label label3;
        private TextBox Variable2;
        private Button btCalcular;
        private Button btLimpiar;
        private Button btSalir;
        private Label label4;
        private TextBox resultado;
    }
}
