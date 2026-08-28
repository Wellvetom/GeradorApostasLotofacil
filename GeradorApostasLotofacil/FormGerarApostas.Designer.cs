namespace GeradorApostasLotofacil
{
    partial class FormGerarApostas
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();
            panelTop = new Panel();
            label_gerarAposta = new Label();
            numberBox_quantidadeApostas = new NumericUpDown();
            label_apostasIneditas = new Label();
            radioBtn_apostasIneditas = new RadioButton();
            btn_gerarApostas = new Button();
            btnGravarApostas = new Button();
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
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numberBox_quantidadeApostas).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 38, 54);
            panelTop.Controls.Add(label_gerarAposta);
            panelTop.Controls.Add(numberBox_quantidadeApostas);
            panelTop.Controls.Add(label_apostasIneditas);
            panelTop.Controls.Add(radioBtn_apostasIneditas);
            panelTop.Controls.Add(btn_gerarApostas);
            panelTop.Controls.Add(btnGravarApostas);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(936, 110);
            // 
            // label_gerarAposta
            // 
            label_gerarAposta.AutoSize = true;
            label_gerarAposta.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label_gerarAposta.ForeColor = Color.White;
            label_gerarAposta.Location = new Point(18, 12);
            label_gerarAposta.Name = "label_gerarAposta";
            label_gerarAposta.Text = "🎲 Gerar Apostas Inteligentes";
            // 
            // numberBox_quantidadeApostas
            // 
            numberBox_quantidadeApostas.BackColor = Color.FromArgb(55, 65, 82);
            numberBox_quantidadeApostas.ForeColor = Color.White;
            numberBox_quantidadeApostas.Font = new Font("Segoe UI", 12F);
            numberBox_quantidadeApostas.Location = new Point(18, 55);
            numberBox_quantidadeApostas.Name = "numberBox_quantidadeApostas";
            numberBox_quantidadeApostas.Size = new Size(120, 34);
            numberBox_quantidadeApostas.BorderStyle = BorderStyle.FixedSingle;
            numberBox_quantidadeApostas.Minimum = 1;
            numberBox_quantidadeApostas.Maximum = 100;
            numberBox_quantidadeApostas.Value = 5;
            // 
            // label_apostasIneditas
            // 
            label_apostasIneditas.AutoSize = true;
            label_apostasIneditas.Font = new Font("Segoe UI", 10F);
            label_apostasIneditas.ForeColor = Color.FromArgb(180, 180, 200);
            label_apostasIneditas.Location = new Point(160, 62);
            label_apostasIneditas.Name = "label_apostasIneditas";
            label_apostasIneditas.Text = "Apenas inéditas:";
            // 
            // radioBtn_apostasIneditas
            // 
            radioBtn_apostasIneditas.AutoSize = true;
            radioBtn_apostasIneditas.ForeColor = Color.White;
            radioBtn_apostasIneditas.Location = new Point(295, 63);
            radioBtn_apostasIneditas.Name = "radioBtn_apostasIneditas";
            radioBtn_apostasIneditas.Size = new Size(17, 16);
            radioBtn_apostasIneditas.TabStop = true;
            radioBtn_apostasIneditas.UseVisualStyleBackColor = true;
            // 
            // btn_gerarApostas
            // 
            btn_gerarApostas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_gerarApostas.BackColor = Color.FromArgb(63, 81, 181);
            btn_gerarApostas.FlatAppearance.BorderSize = 0;
            btn_gerarApostas.FlatStyle = FlatStyle.Flat;
            btn_gerarApostas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_gerarApostas.ForeColor = Color.White;
            btn_gerarApostas.Location = new Point(620, 15);
            btn_gerarApostas.Name = "btn_gerarApostas";
            btn_gerarApostas.Size = new Size(145, 38);
            btn_gerarApostas.Text = "⚡ Gerar";
            btn_gerarApostas.Cursor = Cursors.Hand;
            btn_gerarApostas.Click += btn_gerarApostas_Click;
            // 
            // btnGravarApostas
            // 
            btnGravarApostas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGravarApostas.BackColor = Color.FromArgb(0, 150, 136);
            btnGravarApostas.FlatAppearance.BorderSize = 0;
            btnGravarApostas.FlatStyle = FlatStyle.Flat;
            btnGravarApostas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnGravarApostas.ForeColor = Color.White;
            btnGravarApostas.Location = new Point(780, 15);
            btnGravarApostas.Name = "btnGravarApostas";
            btnGravarApostas.Size = new Size(138, 38);
            btnGravarApostas.Text = "💾 Gravar";
            btnGravarApostas.Cursor = Cursors.Hand;
            btnGravarApostas.Click += btnGravarApostas_Click;
            // 
            // dgv_listaApostas
            // 
            dgv_listaApostas.AllowUserToAddRows = false;
            dgv_listaApostas.AllowUserToDeleteRows = false;
            dgv_listaApostas.AllowUserToResizeRows = false;
            dgv_listaApostas.BackgroundColor = Color.FromArgb(40, 42, 58);
            dgv_listaApostas.BorderStyle = BorderStyle.None;
            dgv_listaApostas.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv_listaApostas.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            headerStyle.BackColor = Color.FromArgb(50, 55, 75);
            headerStyle.ForeColor = Color.FromArgb(160, 170, 200);
            headerStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerStyle.SelectionBackColor = Color.FromArgb(50, 55, 75);
            headerStyle.SelectionForeColor = Color.FromArgb(160, 170, 200);
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Padding = new Padding(0, 4, 0, 4);
            dgv_listaApostas.ColumnHeadersDefaultCellStyle = headerStyle;
            dgv_listaApostas.ColumnHeadersHeight = 36;
            dgv_listaApostas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv_listaApostas.Columns.AddRange(new DataGridViewColumn[] { PrimeiroNumero, SegundoNumero, TerceiroNumero, QuartoNumero, QuintoNumero, SextoNumero, SetimoNumero, OitavoNumero, NonoNumero, DecimoNumero, DecimoPrimeiroNumero, DecimoSegundoNumero, DecimoTerceiroNumero, DecimoQuartoNumero, DecimoQuintoNumero });
            cellStyle.BackColor = Color.FromArgb(40, 42, 58);
            cellStyle.ForeColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181);
            cellStyle.SelectionForeColor = Color.White;
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.Padding = new Padding(0, 6, 0, 6);
            dgv_listaApostas.DefaultCellStyle = cellStyle;
            dgv_listaApostas.Dock = DockStyle.Fill;
            dgv_listaApostas.EnableHeadersVisualStyles = false;
            dgv_listaApostas.GridColor = Color.FromArgb(55, 58, 78);
            dgv_listaApostas.Location = new Point(0, 110);
            dgv_listaApostas.Name = "dgv_listaApostas";
            dgv_listaApostas.ReadOnly = true;
            dgv_listaApostas.RowHeadersVisible = false;
            dgv_listaApostas.RowTemplate.Height = 42;
            dgv_listaApostas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_listaApostas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_listaApostas.MultiSelect = false;
            dgv_listaApostas.ScrollBars = ScrollBars.Vertical;
            // 
            // PrimeiroNumero
            // 
            PrimeiroNumero.DataPropertyName = "PrimeiroNumero";
            PrimeiroNumero.HeaderText = "1º";
            PrimeiroNumero.Name = "PrimeiroNumero";
            // 
            // SegundoNumero
            // 
            SegundoNumero.DataPropertyName = "SegundoNumero";
            SegundoNumero.HeaderText = "2º";
            SegundoNumero.Name = "SegundoNumero";
            // 
            // TerceiroNumero
            // 
            TerceiroNumero.DataPropertyName = "TerceiroNumero";
            TerceiroNumero.HeaderText = "3º";
            TerceiroNumero.Name = "TerceiroNumero";
            // 
            // QuartoNumero
            // 
            QuartoNumero.DataPropertyName = "QuartoNumero";
            QuartoNumero.HeaderText = "4º";
            QuartoNumero.Name = "QuartoNumero";
            // 
            // QuintoNumero
            // 
            QuintoNumero.DataPropertyName = "QuintoNumero";
            QuintoNumero.HeaderText = "5º";
            QuintoNumero.Name = "QuintoNumero";
            // 
            // SextoNumero
            // 
            SextoNumero.DataPropertyName = "SextoNumero";
            SextoNumero.HeaderText = "6º";
            SextoNumero.Name = "SextoNumero";
            // 
            // SetimoNumero
            // 
            SetimoNumero.DataPropertyName = "SetimoNumero";
            SetimoNumero.HeaderText = "7º";
            SetimoNumero.Name = "SetimoNumero";
            // 
            // OitavoNumero
            // 
            OitavoNumero.DataPropertyName = "OitavoNumero";
            OitavoNumero.HeaderText = "8º";
            OitavoNumero.Name = "OitavoNumero";
            // 
            // NonoNumero
            // 
            NonoNumero.DataPropertyName = "NonoNumero";
            NonoNumero.HeaderText = "9º";
            NonoNumero.Name = "NonoNumero";
            // 
            // DecimoNumero
            // 
            DecimoNumero.DataPropertyName = "DecimoNumero";
            DecimoNumero.HeaderText = "10º";
            DecimoNumero.Name = "DecimoNumero";
            // 
            // DecimoPrimeiroNumero
            // 
            DecimoPrimeiroNumero.DataPropertyName = "DecimoPrimeiroNumero";
            DecimoPrimeiroNumero.HeaderText = "11º";
            DecimoPrimeiroNumero.Name = "DecimoPrimeiroNumero";
            // 
            // DecimoSegundoNumero
            // 
            DecimoSegundoNumero.DataPropertyName = "DecimoSegundoNumero";
            DecimoSegundoNumero.HeaderText = "12º";
            DecimoSegundoNumero.Name = "DecimoSegundoNumero";
            // 
            // DecimoTerceiroNumero
            // 
            DecimoTerceiroNumero.DataPropertyName = "DecimoTerceiroNumero";
            DecimoTerceiroNumero.HeaderText = "13º";
            DecimoTerceiroNumero.Name = "DecimoTerceiroNumero";
            // 
            // DecimoQuartoNumero
            // 
            DecimoQuartoNumero.DataPropertyName = "DecimoQuartoNumero";
            DecimoQuartoNumero.HeaderText = "14º";
            DecimoQuartoNumero.Name = "DecimoQuartoNumero";
            // 
            // DecimoQuintoNumero
            // 
            DecimoQuintoNumero.DataPropertyName = "DecimoQuintoNumero";
            DecimoQuintoNumero.HeaderText = "15º";
            DecimoQuintoNumero.Name = "DecimoQuintoNumero";
            // 
            // FormGerarApostas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(936, 489);
            Controls.Add(dgv_listaApostas);
            Controls.Add(panelTop);
            Name = "FormGerarApostas";
            Text = "FormGerarApostas";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numberBox_quantidadeApostas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
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
