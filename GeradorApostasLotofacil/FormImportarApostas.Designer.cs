namespace GeradorApostasLotofacil
{
    partial class FormImportarApostas
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
            label1 = new Label();
            label_dadosApostas = new Label();
            btn_importarApostas = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(21, 29);
            label1.Name = "label1";
            label1.Size = new Size(476, 28);
            label1.TabIndex = 0;
            label1.Text = "Importar apostas vencedoras via legado lotofacil";
            // 
            // label_dadosApostas
            // 
            label_dadosApostas.AutoSize = true;
            label_dadosApostas.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_dadosApostas.ForeColor = Color.White;
            label_dadosApostas.Location = new Point(21, 87);
            label_dadosApostas.Name = "label_dadosApostas";
            label_dadosApostas.Size = new Size(243, 23);
            label_dadosApostas.TabIndex = 1;
            label_dadosApostas.Text = "Ultimo sorteio realizado em: ";
            // 
            // btn_importarApostas
            // 
            btn_importarApostas.BackColor = Color.Crimson;
            btn_importarApostas.FlatStyle = FlatStyle.Flat;
            btn_importarApostas.Location = new Point(560, 25);
            btn_importarApostas.Name = "btn_importarApostas";
            btn_importarApostas.Size = new Size(152, 43);
            btn_importarApostas.TabIndex = 3;
            btn_importarApostas.Text = "Importar apostas";
            btn_importarApostas.UseVisualStyleBackColor = false;
            btn_importarApostas.Click += btn_importarApostas_Click;
            // 
            // FormImportarApostas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_importarApostas);
            Controls.Add(label_dadosApostas);
            Controls.Add(label1);
            Name = "FormImportarApostas";
            Text = "FormImportarApostas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label_dadosApostas;
        private Button btn_importarApostas;
    }
}