namespace GeradorApostasLotofacil
{
    partial class FormGerarApostas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            dgv_listaApostas = new DataGridView();
            PrimeiroNumero = new DataGridViewTextBoxColumn();
            SegundoNumero = new DataGridViewTextBoxColumn();
            TerceiroNumero = new DataGridViewTextBoxColumn();
            QuartoNumero = new DataGridViewTextBoxColumn();
            QuintoNumero = new DataGridViewTextBoxColumn();
            SextoNumero = new DataGridViewTextBoxColumn();
            SetimoNumero = new DataGridViewTextBoxColumn();
            OitavoNumero = new DataGridViewTextBoxColumn();
            NonoNumero = new DataGridViewTextBoxColumn();
            DecimoNumero = new DataGridViewTextBoxColumn();
            DecimoPrimeiroNumero = new DataGridViewTextBoxColumn();
            DecimoSegundoNumero = new DataGridViewTextBoxColumn();
            DecimoTerceiroNumero = new DataGridViewTextBoxColumn();
            DecimoQuartoNumero = new DataGridViewTextBoxColumn();
            DecimoQuintoNumero = new DataGridViewTextBoxColumn();
            label_gerarAposta = new Label();
            btn_gerarApostas = new Button();
            numberBox_quantidadeApostas = new NumericUpDown();
            label_apostasIneditas = new Label();
            radioBtn_apostasIneditas = new RadioButton();
            btnGravarApostas = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numberBox_quantidadeApostas).BeginInit();
            SuspendLayout();
            // 
            // dgv_listaApostas
            // 
            dgv_listaApostas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listaApostas.Columns.AddRange(new DataGridViewColumn[] { PrimeiroNumero, SegundoNumero, TerceiroNumero, QuartoNumero, QuintoNumero, SextoNumero, SetimoNumero, OitavoNumero, NonoNumero, DecimoNumero, DecimoPrimeiroNumero, DecimoSegundoNumero, DecimoTerceiroNumero, DecimoQuartoNumero, DecimoQuintoNumero });
            dgv_listaApostas.Location = new Point(12, 144);
            dgv_listaApostas.Name = "dgv_listaApostas";
            dgv_listaApostas.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Azure;
            dataGridViewCellStyle1.SelectionBackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Azure;
            dgv_listaApostas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_listaApostas.Size = new Size(912, 333);
            dgv_listaApostas.TabIndex = 0;
            // 
            // PrimeiroNumero
            // 
            PrimeiroNumero.DataPropertyName = "PrimeiroNumero";
            PrimeiroNumero.HeaderText = "1º Numero";
            PrimeiroNumero.MinimumWidth = 6;
            PrimeiroNumero.Name = "PrimeiroNumero";
            PrimeiroNumero.Width = 125;
            // 
            // SegundoNumero
            // 
            SegundoNumero.DataPropertyName = "SegundoNumero";
            SegundoNumero.HeaderText = "2º Numero";
            SegundoNumero.MinimumWidth = 6;
            SegundoNumero.Name = "SegundoNumero";
            SegundoNumero.Width = 125;
            // 
            // TerceiroNumero
            // 
            TerceiroNumero.DataPropertyName = "TerceiroNumero";
            TerceiroNumero.HeaderText = "3º Numero";
            TerceiroNumero.MinimumWidth = 6;
            TerceiroNumero.Name = "TerceiroNumero";
            TerceiroNumero.Width = 125;
            // 
            // QuartoNumero
            // 
            QuartoNumero.DataPropertyName = "QuartoNumero";
            QuartoNumero.HeaderText = "4º Numero";
            QuartoNumero.MinimumWidth = 6;
            QuartoNumero.Name = "QuartoNumero";
            QuartoNumero.Width = 125;
            // 
            // QuintoNumero
            // 
            QuintoNumero.DataPropertyName = "QuintoNumero";
            QuintoNumero.HeaderText = "5º Numero";
            QuintoNumero.MinimumWidth = 6;
            QuintoNumero.Name = "QuintoNumero";
            QuintoNumero.Width = 125;
            // 
            // SextoNumero
            // 
            SextoNumero.DataPropertyName = "SextoNumero";
            SextoNumero.HeaderText = "6º Numero";
            SextoNumero.MinimumWidth = 6;
            SextoNumero.Name = "SextoNumero";
            SextoNumero.Width = 125;
            // 
            // SetimoNumero
            // 
            SetimoNumero.DataPropertyName = "SetimoNumero";
            SetimoNumero.HeaderText = "7º Numero";
            SetimoNumero.MinimumWidth = 6;
            SetimoNumero.Name = "SetimoNumero";
            SetimoNumero.Width = 125;
            // 
            // OitavoNumero
            // 
            OitavoNumero.DataPropertyName = "OitavoNumero";
            OitavoNumero.HeaderText = "8º Numero";
            OitavoNumero.MinimumWidth = 6;
            OitavoNumero.Name = "OitavoNumero";
            OitavoNumero.Width = 125;
            // 
            // NonoNumero
            // 
            NonoNumero.DataPropertyName = "NonoNumero";
            NonoNumero.HeaderText = "9º Numero";
            NonoNumero.MinimumWidth = 6;
            NonoNumero.Name = "NonoNumero";
            NonoNumero.Width = 125;
            // 
            // DecimoNumero
            // 
            DecimoNumero.DataPropertyName = "DecimoNumero";
            DecimoNumero.HeaderText = "10º Numero";
            DecimoNumero.MinimumWidth = 6;
            DecimoNumero.Name = "DecimoNumero";
            DecimoNumero.Width = 125;
            // 
            // DecimoPrimeiroNumero
            // 
            DecimoPrimeiroNumero.DataPropertyName = "DecimoPrimeiroNumero";
            DecimoPrimeiroNumero.HeaderText = "11º Numero";
            DecimoPrimeiroNumero.MinimumWidth = 6;
            DecimoPrimeiroNumero.Name = "DecimoPrimeiroNumero";
            DecimoPrimeiroNumero.Width = 125;
            // 
            // DecimoSegundoNumero
            // 
            DecimoSegundoNumero.DataPropertyName = "DecimoSegundoNumero";
            DecimoSegundoNumero.HeaderText = "12º Numero";
            DecimoSegundoNumero.MinimumWidth = 6;
            DecimoSegundoNumero.Name = "DecimoSegundoNumero";
            DecimoSegundoNumero.Width = 125;
            // 
            // DecimoTerceiroNumero
            // 
            DecimoTerceiroNumero.DataPropertyName = "DecimoTerceiroNumero";
            DecimoTerceiroNumero.HeaderText = "13º Numero";
            DecimoTerceiroNumero.MinimumWidth = 6;
            DecimoTerceiroNumero.Name = "DecimoTerceiroNumero";
            DecimoTerceiroNumero.Width = 125;
            // 
            // DecimoQuartoNumero
            // 
            DecimoQuartoNumero.DataPropertyName = "DecimoQuartoNumero";
            DecimoQuartoNumero.HeaderText = "14º Numero";
            DecimoQuartoNumero.MinimumWidth = 6;
            DecimoQuartoNumero.Name = "DecimoQuartoNumero";
            DecimoQuartoNumero.Width = 125;
            // 
            // DecimoQuintoNumero
            // 
            DecimoQuintoNumero.DataPropertyName = "DecimoQuintoNumero";
            DecimoQuintoNumero.HeaderText = "15º Numero";
            DecimoQuintoNumero.MinimumWidth = 6;
            DecimoQuintoNumero.Name = "DecimoQuintoNumero";
            DecimoQuintoNumero.Width = 125;
            // 
            // label_gerarAposta
            // 
            label_gerarAposta.AutoSize = true;
            label_gerarAposta.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label_gerarAposta.ForeColor = Color.White;
            label_gerarAposta.Location = new Point(31, 27);
            label_gerarAposta.Name = "label_gerarAposta";
            label_gerarAposta.Size = new Size(520, 31);
            label_gerarAposta.TabIndex = 1;
            label_gerarAposta.Text = "Digite a quantidade de apostas a serem geradas: ";
            // 
            // btn_gerarApostas
            // 
            btn_gerarApostas.BackColor = Color.Crimson;
            btn_gerarApostas.FlatStyle = FlatStyle.Flat;
            btn_gerarApostas.Location = new Point(731, 22);
            btn_gerarApostas.Name = "btn_gerarApostas";
            btn_gerarApostas.Size = new Size(125, 43);
            btn_gerarApostas.TabIndex = 2;
            btn_gerarApostas.Text = "Gerar apostas";
            btn_gerarApostas.UseVisualStyleBackColor = false;
            btn_gerarApostas.Click += btn_gerarApostas_Click;
            // 
            // numberBox_quantidadeApostas
            // 
            numberBox_quantidadeApostas.Location = new Point(557, 31);
            numberBox_quantidadeApostas.Name = "numberBox_quantidadeApostas";
            numberBox_quantidadeApostas.Size = new Size(150, 27);
            numberBox_quantidadeApostas.TabIndex = 5;
            // 
            // label_apostasIneditas
            // 
            label_apostasIneditas.AutoSize = true;
            label_apostasIneditas.ForeColor = Color.White;
            label_apostasIneditas.Location = new Point(557, 61);
            label_apostasIneditas.Name = "label_apostasIneditas";
            label_apostasIneditas.Size = new Size(125, 20);
            label_apostasIneditas.TabIndex = 6;
            label_apostasIneditas.Text = "Apostas ineditas?";
            // 
            // radioBtn_apostasIneditas
            // 
            radioBtn_apostasIneditas.AutoSize = true;
            radioBtn_apostasIneditas.Location = new Point(688, 61);
            radioBtn_apostasIneditas.Name = "radioBtn_apostasIneditas";
            radioBtn_apostasIneditas.Size = new Size(17, 16);
            radioBtn_apostasIneditas.TabIndex = 7;
            radioBtn_apostasIneditas.TabStop = true;
            radioBtn_apostasIneditas.UseVisualStyleBackColor = true;
            // 
            // btnGravarApostas
            // 
            btnGravarApostas.BackColor = Color.SpringGreen;
            btnGravarApostas.FlatStyle = FlatStyle.Flat;
            btnGravarApostas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGravarApostas.Location = new Point(731, 80);
            btnGravarApostas.Name = "btnGravarApostas";
            btnGravarApostas.Size = new Size(125, 43);
            btnGravarApostas.TabIndex = 8;
            btnGravarApostas.Text = "Gravar apostas";
            btnGravarApostas.UseVisualStyleBackColor = false;
            btnGravarApostas.Click += btnGravarApostas_Click;
            // 
            // FormGerarApostas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(936, 489);
            Controls.Add(btnGravarApostas);
            Controls.Add(radioBtn_apostasIneditas);
            Controls.Add(label_apostasIneditas);
            Controls.Add(numberBox_quantidadeApostas);
            Controls.Add(btn_gerarApostas);
            Controls.Add(label_gerarAposta);
            Controls.Add(dgv_listaApostas);
            Name = "FormGerarApostas";
            Text = "FormGerarApostas";
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numberBox_quantidadeApostas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgv_listaApostas;
        private Label label_gerarAposta;
        private Button btn_gerarApostas;
        private NumericUpDown numberBox_quantidadeApostas;
        private Label label_apostasIneditas;
        private RadioButton radioBtn_apostasIneditas;
        private Button btnGravarApostas;
        private DataGridViewTextBoxColumn PrimeiroNumero;
        private DataGridViewTextBoxColumn SegundoNumero;
        private DataGridViewTextBoxColumn TerceiroNumero;
        private DataGridViewTextBoxColumn QuartoNumero;
        private DataGridViewTextBoxColumn QuintoNumero;
        private DataGridViewTextBoxColumn SextoNumero;
        private DataGridViewTextBoxColumn SetimoNumero;
        private DataGridViewTextBoxColumn OitavoNumero;
        private DataGridViewTextBoxColumn NonoNumero;
        private DataGridViewTextBoxColumn DecimoNumero;
        private DataGridViewTextBoxColumn DecimoPrimeiroNumero;
        private DataGridViewTextBoxColumn DecimoSegundoNumero;
        private DataGridViewTextBoxColumn DecimoTerceiroNumero;
        private DataGridViewTextBoxColumn DecimoQuartoNumero;
        private DataGridViewTextBoxColumn DecimoQuintoNumero;
    }
}