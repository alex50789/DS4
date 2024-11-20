namespace Lab12._3
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
            btSemi = new Button();
            btTriangulo = new Button();
            Limpiar = new Button();
            Salir = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            LadoA = new TextBox();
            LadoC = new TextBox();
            Semi = new TextBox();
            Triangulo = new TextBox();
            LadoB = new TextBox();
            label6 = new Label();
            SuspendLayout();
            // 
            // btSemi
            // 
            btSemi.Location = new Point(24, 198);
            btSemi.Name = "btSemi";
            btSemi.Size = new Size(102, 37);
            btSemi.TabIndex = 0;
            btSemi.Text = "Semiperimetro";
            btSemi.UseVisualStyleBackColor = true;
            btSemi.Click += btSemi_Click;
            // 
            // btTriangulo
            // 
            btTriangulo.Location = new Point(132, 198);
            btTriangulo.Name = "btTriangulo";
            btTriangulo.Size = new Size(80, 37);
            btTriangulo.TabIndex = 1;
            btTriangulo.Text = "Area";
            btTriangulo.UseVisualStyleBackColor = true;
            btTriangulo.Click += btTriangulo_Click;
            // 
            // Limpiar
            // 
            Limpiar.Location = new Point(218, 198);
            Limpiar.Name = "Limpiar";
            Limpiar.Size = new Size(90, 37);
            Limpiar.TabIndex = 2;
            Limpiar.Text = "Reset";
            Limpiar.UseVisualStyleBackColor = true;
            Limpiar.Click += Limpiar_Click;
            // 
            // Salir
            // 
            Salir.Location = new Point(314, 198);
            Salir.Name = "Salir";
            Salir.Size = new Size(82, 37);
            Salir.TabIndex = 3;
            Salir.Text = "Salir";
            Salir.UseVisualStyleBackColor = true;
            Salir.Click += Salir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(151, 25);
            label1.Name = "label1";
            label1.Size = new Size(102, 15);
            label1.TabIndex = 4;
            label1.Text = "Calcular Triangulo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(37, 80);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 5;
            label2.Text = "Lado A";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(37, 117);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 6;
            label3.Text = "Lado B";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 154);
            label4.Name = "label4";
            label4.Size = new Size(44, 15);
            label4.TabIndex = 7;
            label4.Text = "Lado C";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 276);
            label5.Name = "label5";
            label5.Size = new Size(85, 15);
            label5.TabIndex = 8;
            label5.Text = "Semiperimetro";
            // 
            // LadoA
            // 
            LadoA.Location = new Point(131, 72);
            LadoA.Name = "LadoA";
            LadoA.Size = new Size(100, 23);
            LadoA.TabIndex = 9;
            // 
            // LadoC
            // 
            LadoC.Location = new Point(131, 146);
            LadoC.Name = "LadoC";
            LadoC.Size = new Size(100, 23);
            LadoC.TabIndex = 10;
            // 
            // Semi
            // 
            Semi.Location = new Point(131, 268);
            Semi.Name = "Semi";
            Semi.Size = new Size(100, 23);
            Semi.TabIndex = 11;
            // 
            // Triangulo
            // 
            Triangulo.Location = new Point(131, 321);
            Triangulo.Name = "Triangulo";
            Triangulo.Size = new Size(100, 23);
            Triangulo.TabIndex = 12;
            // 
            // LadoB
            // 
            LadoB.Location = new Point(131, 109);
            LadoB.Name = "LadoB";
            LadoB.Size = new Size(100, 23);
            LadoB.TabIndex = 13;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 329);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 14;
            label6.Text = "Triangulo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(LadoB);
            Controls.Add(Triangulo);
            Controls.Add(Semi);
            Controls.Add(LadoC);
            Controls.Add(LadoA);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Salir);
            Controls.Add(Limpiar);
            Controls.Add(btTriangulo);
            Controls.Add(btSemi);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btSemi;
        private Button btTriangulo;
        private Button Limpiar;
        private Button Salir;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox LadoA;
        private TextBox LadoC;
        private TextBox Semi;
        private TextBox Triangulo;
        private TextBox LadoB;
        private Label label6;
    }
}
