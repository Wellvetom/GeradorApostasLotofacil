namespace GeradorApostasLotofacil
{
    partial class FormListarApostas
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
            btnListasApostas = new Button();
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
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).BeginInit();
            SuspendLayout();
            // 
            // btnListasApostas
            // 
            btnListasApostas.BackColor = Color.SpringGreen;
            btnListasApostas.FlatStyle = FlatStyle.Flat;
            btnListasApostas.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnListasApostas.Location = new Point(12, 31);
            btnListasApostas.Name = "btnListasApostas";
            btnListasApostas.Size = new Size(125, 43);
            btnListasApostas.TabIndex = 10;
            btnListasApostas.Text = "Listar Apostas";
            btnListasApostas.UseVisualStyleBackColor = false;
            btnListasApostas.Click += btnListasApostas_Click;
            // 
            // dgv_listaApostas
            // 
            dgv_listaApostas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_listaApostas.Columns.AddRange(new DataGridViewColumn[] { PrimeiroNumero, SegundoNumero, TerceiroNumero, QuartoNumero, QuintoNumero, SextoNumero, SetimoNumero, OitavoNumero, NonoNumero, DecimoNumero, DecimoPrimeiroNumero, DecimoSegundoNumero, DecimoTerceiroNumero, DecimoQuartoNumero, DecimoQuintoNumero });
            dgv_listaApostas.Location = new Point(12, 98);
            dgv_listaApostas.Name = "dgv_listaApostas";
            dgv_listaApostas.RowHeadersWidth = 51;
            dataGridViewCellStyle1.BackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Azure;
            dataGridViewCellStyle1.SelectionBackColor = Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = Color.Azure;
            dgv_listaApostas.RowsDefaultCellStyle = dataGridViewCellStyle1;
            dgv_listaApostas.Size = new Size(912, 333);
            dgv_listaApostas.TabIndex = 9;
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
            // FormListarApostas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(948, 525);
            Controls.Add(btnListasApostas);
            Controls.Add(dgv_listaApostas);
            Name = "FormListarApostas";
            Text = "FormListarApostas";
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnListasApostas;
        private DataGridView dgv_listaApostas;
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