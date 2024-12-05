namespace Lab12._2
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
            Salir = new Button();
            Calcular = new Button();
            Limpiar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            N1 = new TextBox();
            N2 = new TextBox();
            N3 = new TextBox();
            label5 = new Label();
            Resultado = new TextBox();
            SuspendLayout();
            // 
            // Salir
            // 
            Salir.Location = new Point(257, 206);
            Salir.Name = "Salir";
            Salir.Size = new Size(87, 32);
            Salir.TabIndex = 0;
            Salir.Text = "Salir";
            Salir.UseVisualStyleBackColor = true;
            Salir.Click += Salir_Click;
            // 
            // Calcular
            // 
            Calcular.Location = new Point(25, 206);
            Calcular.Name = "Calcular";
            Calcular.Size = new Size(93, 32);
            Calcular.TabIndex = 1;
            Calcular.Text = "Calcular";
            Calcular.UseVisualStyleBackColor = true;
            Calcular.Click += Calcular_Click;
            // 
            // Limpiar
            // 
            Limpiar.Location = new Point(147, 206);
            Limpiar.Name = "Limpiar";
            Limpiar.Size = new Size(85, 32);
            Limpiar.TabIndex = 2;
            Limpiar.Text = "Limpiar";
            Limpiar.UseVisualStyleBackColor = true;
            Limpiar.Click += Limpiar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(184, 35);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 3;
            label1.Text = "Calcular Nota";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 81);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 4;
            label2.Text = "Nota 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 122);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 5;
            label3.Text = "Nota 2";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 170);
            label4.Name = "label4";
            label4.Size = new Size(42, 15);
            label4.TabIndex = 6;
            label4.Text = "Nota 3";
            // 
            // N1
            // 
            N1.Location = new Point(132, 81);
            N1.Name = "N1";
            N1.Size = new Size(100, 23);
            N1.TabIndex = 7;
            // 
            // N2
            // 
            N2.Location = new Point(132, 122);
            N2.Name = "N2";
            N2.Size = new Size(100, 23);
            N2.TabIndex = 8;
            // 
            // N3
            // 
            N3.Location = new Point(132, 170);
            N3.Name = "N3";
            N3.Size = new Size(102, 23);
            N3.TabIndex = 9;
            N3.TextChanged += textBox3_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(25, 266);
            label5.Name = "label5";
            label5.Size = new Size(59, 15);
            label5.TabIndex = 10;
            label5.Text = "Resultado";
            // 
            // Resultado
            // 
            Resultado.Location = new Point(132, 266);
            Resultado.Name = "Resultado";
            Resultado.Size = new Size(100, 23);
            Resultado.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Resultado);
            Controls.Add(label5);
            Controls.Add(N3);
            Controls.Add(N2);
            Controls.Add(N1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Limpiar);
            Controls.Add(Calcular);
            Controls.Add(Salir);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Salir;
        private Button Calcular;
        private Button Limpiar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox N1;
        private TextBox N2;
        private TextBox N3;
        private Label label5;
        private TextBox Resultado;
    }
}
