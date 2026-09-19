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
            label_maisSorteados = new Label();
            numMaisSorteados = new NumericUpDown();
            label_menosSorteados = new Label();
            numMenosSorteados = new NumericUpDown();
            label_aleatorios = new Label();
            btn_gerarApostas = new Button();
            btnGravarApostas = new Button();
            btnCriarManual = new Button();
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
            ((System.ComponentModel.ISupportInitialize)numMaisSorteados).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numMenosSorteados).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 38, 54);
            panelTop.Controls.Add(label_gerarAposta);
            panelTop.Controls.Add(numberBox_quantidadeApostas);
            panelTop.Controls.Add(label_maisSorteados);
            panelTop.Controls.Add(numMaisSorteados);
            panelTop.Controls.Add(label_menosSorteados);
            panelTop.Controls.Add(numMenosSorteados);
            panelTop.Controls.Add(label_aleatorios);
            panelTop.Controls.Add(btn_gerarApostas);
            panelTop.Controls.Add(btnGravarApostas);
            panelTop.Controls.Add(btnCriarManual);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(936, 170);
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
            numberBox_quantidadeApostas.Location = new Point(18, 58);
            numberBox_quantidadeApostas.Name = "numberBox_quantidadeApostas";
            numberBox_quantidadeApostas.Size = new Size(100, 34);
            numberBox_quantidadeApostas.BorderStyle = BorderStyle.FixedSingle;
            numberBox_quantidadeApostas.Minimum = 1;
            numberBox_quantidadeApostas.Maximum = 100;
            numberBox_quantidadeApostas.Value = 5;
            numberBox_quantidadeApostas.TextAlign = HorizontalAlignment.Center;
            // 
            // label_maisSorteados
            // 
            label_maisSorteados.AutoSize = true;
            label_maisSorteados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_maisSorteados.ForeColor = Color.FromArgb(130, 200, 130);
            label_maisSorteados.Location = new Point(18, 115);
            label_maisSorteados.Name = "label_maisSorteados";
            label_maisSorteados.Text = "📈 Mais sorteados:";
            // 
            // numMaisSorteados
            // 
            numMaisSorteados.BackColor = Color.FromArgb(55, 65, 82);
            numMaisSorteados.ForeColor = Color.White;
            numMaisSorteados.Font = new Font("Segoe UI", 11F);
            numMaisSorteados.Location = new Point(180, 111);
            numMaisSorteados.Name = "numMaisSorteados";
            numMaisSorteados.Size = new Size(65, 32);
            numMaisSorteados.BorderStyle = BorderStyle.FixedSingle;
            numMaisSorteados.Minimum = 0;
            numMaisSorteados.Maximum = 15;
            numMaisSorteados.Value = 10;
            numMaisSorteados.TextAlign = HorizontalAlignment.Center;
            numMaisSorteados.ValueChanged += numMaisMenos_ValueChanged;
            // 
            // label_menosSorteados
            // 
            label_menosSorteados.AutoSize = true;
            label_menosSorteados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_menosSorteados.ForeColor = Color.FromArgb(255, 150, 100);
            label_menosSorteados.Location = new Point(280, 115);
            label_menosSorteados.Name = "label_menosSorteados";
            label_menosSorteados.Text = "📉 Menos sorteados:";
            // 
            // numMenosSorteados
            // 
            numMenosSorteados.BackColor = Color.FromArgb(55, 65, 82);
            numMenosSorteados.ForeColor = Color.White;
            numMenosSorteados.Font = new Font("Segoe UI", 11F);
            numMenosSorteados.Location = new Point(460, 111);
            numMenosSorteados.Name = "numMenosSorteados";
            numMenosSorteados.Size = new Size(65, 32);
            numMenosSorteados.BorderStyle = BorderStyle.FixedSingle;
            numMenosSorteados.Minimum = 0;
            numMenosSorteados.Maximum = 15;
            numMenosSorteados.Value = 2;
            numMenosSorteados.TextAlign = HorizontalAlignment.Center;
            numMenosSorteados.ValueChanged += numMaisMenos_ValueChanged;
            // 
            // label_aleatorios
            // 
            label_aleatorios.AutoSize = true;
            label_aleatorios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label_aleatorios.ForeColor = Color.FromArgb(100, 180, 255);
            label_aleatorios.Location = new Point(560, 115);
            label_aleatorios.Name = "label_aleatorios";
            label_aleatorios.Text = "🎲 Aleatórios: 3";
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
            // btnCriarManual
            // 
            btnCriarManual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCriarManual.BackColor = Color.FromArgb(120, 80, 200);
            btnCriarManual.FlatAppearance.BorderSize = 0;
            btnCriarManual.FlatStyle = FlatStyle.Flat;
            btnCriarManual.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCriarManual.ForeColor = Color.White;
            btnCriarManual.Location = new Point(620, 60);
            btnCriarManual.Name = "btnCriarManual";
            btnCriarManual.Size = new Size(298, 38);
            btnCriarManual.Text = "✍️ Criar manualmente";
            btnCriarManual.Cursor = Cursors.Hand;
            btnCriarManual.Click += btnCriarManual_Click;
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
            dgv_listaApostas.Location = new Point(0, 170);
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
            ((System.ComponentModel.ISupportInitialize)numMaisSorteados).EndInit();
            ((System.ComponentModel.ISupportInitialize)numMenosSorteados).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private DataGridView dgv_listaApostas;
        private Label label_gerarAposta;
        private Button btn_gerarApostas;
        private NumericUpDown numberBox_quantidadeApostas;
        private Label label_maisSorteados;
        private NumericUpDown numMaisSorteados;
        private Label label_menosSorteados;
        private NumericUpDown numMenosSorteados;
        private Label label_aleatorios;
        private Button btnGravarApostas;
        private Button btnCriarManual;
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
