namespace GeradorApostasLotofacil
{
    partial class FormVerificarAposta
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
            panelTop = new Panel();
            lblTitulo = new Label();
            lblInstrucao = new Label();
            flowNumeros = new FlowLayoutPanel();
            btnVerificar = new Button();
            btnLimpar = new Button();
            panelResultado = new Panel();
            panelCards = new Panel();
            cardJaApostou = new Panel();
            lblTituloJaApostou = new Label();
            lblJaApostou = new Label();
            cardJaSorteado = new Panel();
            lblTituloJaSorteado = new Label();
            lblJaSorteado = new Label();
            lblTituloSorteios = new Label();
            dgvSorteios = new DataGridView();
            colFaixa = new DataGridViewTextBoxColumn();
            colConcurso = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            colNumeros = new DataGridViewTextBoxColumn();
            panelTop.SuspendLayout();
            panelResultado.SuspendLayout();
            panelCards.SuspendLayout();
            cardJaApostou.SuspendLayout();
            cardJaSorteado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSorteios).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 38, 54);
            panelTop.Controls.Add(btnLimpar);
            panelTop.Controls.Add(btnVerificar);
            panelTop.Controls.Add(flowNumeros);
            panelTop.Controls.Add(lblInstrucao);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(1060, 260);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(18, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "🔎 Verificar Aposta";
            // 
            // lblInstrucao
            // 
            lblInstrucao.AutoSize = true;
            lblInstrucao.Font = new Font("Segoe UI", 10F);
            lblInstrucao.ForeColor = Color.FromArgb(180, 180, 200);
            lblInstrucao.Location = new Point(20, 48);
            lblInstrucao.Name = "lblInstrucao";
            lblInstrucao.Text = "Selecione 15 números (1 a 25) e clique em Verificar.  Selecionados: 0/15";
            // 
            // flowNumeros
            // 
            flowNumeros.Location = new Point(20, 78);
            flowNumeros.Name = "flowNumeros";
            flowNumeros.Size = new Size(720, 170);
            flowNumeros.WrapContents = true;
            // 
            // btnVerificar
            // 
            btnVerificar.BackColor = Color.FromArgb(63, 81, 181);
            btnVerificar.FlatAppearance.BorderSize = 0;
            btnVerificar.FlatStyle = FlatStyle.Flat;
            btnVerificar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnVerificar.ForeColor = Color.White;
            btnVerificar.Location = new Point(770, 90);
            btnVerificar.Name = "btnVerificar";
            btnVerificar.Size = new Size(145, 40);
            btnVerificar.Text = "🔎 Verificar";
            btnVerificar.Cursor = Cursors.Hand;
            btnVerificar.UseVisualStyleBackColor = false;
            btnVerificar.Click += btnVerificar_Click;
            // 
            // btnLimpar
            // 
            btnLimpar.BackColor = Color.FromArgb(70, 75, 95);
            btnLimpar.FlatAppearance.BorderSize = 0;
            btnLimpar.FlatStyle = FlatStyle.Flat;
            btnLimpar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLimpar.ForeColor = Color.White;
            btnLimpar.Location = new Point(770, 135);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(145, 34);
            btnLimpar.Text = "🧹 Limpar";
            btnLimpar.Cursor = Cursors.Hand;
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // panelResultado
            // 
            panelResultado.BackColor = Color.FromArgb(30, 30, 46);
            panelResultado.Controls.Add(dgvSorteios);
            panelResultado.Controls.Add(lblTituloSorteios);
            panelResultado.Controls.Add(panelCards);
            panelResultado.Dock = DockStyle.Fill;
            panelResultado.Location = new Point(0, 260);
            panelResultado.Name = "panelResultado";
            panelResultado.Padding = new Padding(15);
            panelResultado.Size = new Size(1060, 420);
            // 
            // panelCards
            // 
            panelCards.Controls.Add(cardJaSorteado);
            panelCards.Controls.Add(cardJaApostou);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(15, 15);
            panelCards.Name = "panelCards";
            panelCards.Size = new Size(1030, 110);
            // 
            // cardJaApostou
            // 
            cardJaApostou.BackColor = Color.FromArgb(45, 55, 72);
            cardJaApostou.Controls.Add(lblJaApostou);
            cardJaApostou.Controls.Add(lblTituloJaApostou);
            cardJaApostou.Location = new Point(5, 10);
            cardJaApostou.Name = "cardJaApostou";
            cardJaApostou.Size = new Size(480, 90);
            // 
            // lblTituloJaApostou
            // 
            lblTituloJaApostou.Font = new Font("Segoe UI", 9F);
            lblTituloJaApostou.ForeColor = Color.FromArgb(200, 200, 255);
            lblTituloJaApostou.Location = new Point(15, 10);
            lblTituloJaApostou.Size = new Size(450, 20);
            lblTituloJaApostou.Text = "VOCÊ JÁ APOSTOU ESSES NÚMEROS?";
            // 
            // lblJaApostou
            // 
            lblJaApostou.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblJaApostou.ForeColor = Color.White;
            lblJaApostou.Location = new Point(15, 34);
            lblJaApostou.Size = new Size(455, 48);
            lblJaApostou.Text = "—";
            // 
            // cardJaSorteado
            // 
            cardJaSorteado.BackColor = Color.FromArgb(45, 55, 72);
            cardJaSorteado.Controls.Add(lblJaSorteado);
            cardJaSorteado.Controls.Add(lblTituloJaSorteado);
            cardJaSorteado.Location = new Point(505, 10);
            cardJaSorteado.Name = "cardJaSorteado";
            cardJaSorteado.Size = new Size(500, 90);
            // 
            // lblTituloJaSorteado
            // 
            lblTituloJaSorteado.Font = new Font("Segoe UI", 9F);
            lblTituloJaSorteado.ForeColor = Color.FromArgb(200, 255, 240);
            lblTituloJaSorteado.Location = new Point(15, 10);
            lblTituloJaSorteado.Size = new Size(475, 20);
            lblTituloJaSorteado.Text = "JÁ FOI SORTEADO (12+ ACERTOS)?";
            // 
            // lblJaSorteado
            // 
            lblJaSorteado.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblJaSorteado.ForeColor = Color.White;
            lblJaSorteado.Location = new Point(15, 34);
            lblJaSorteado.Size = new Size(475, 48);
            lblJaSorteado.Text = "—";
            // 
            // lblTituloSorteios
            // 
            lblTituloSorteios.Dock = DockStyle.Top;
            lblTituloSorteios.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTituloSorteios.ForeColor = Color.White;
            lblTituloSorteios.Location = new Point(15, 125);
            lblTituloSorteios.Name = "lblTituloSorteios";
            lblTituloSorteios.Padding = new Padding(5, 8, 0, 4);
            lblTituloSorteios.Size = new Size(1030, 34);
            lblTituloSorteios.Text = "🏆 Sorteios com 12+ acertos";
            // 
            // dgvSorteios
            // 
            dgvSorteios.AllowUserToAddRows = false;
            dgvSorteios.AllowUserToDeleteRows = false;
            dgvSorteios.AllowUserToResizeRows = false;
            dgvSorteios.BackgroundColor = Color.FromArgb(40, 42, 58);
            dgvSorteios.BorderStyle = BorderStyle.None;
            dgvSorteios.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvSorteios.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(50, 55, 75),
                ForeColor = Color.FromArgb(160, 170, 200),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvSorteios.ColumnHeadersHeight = 34;
            dgvSorteios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvSorteios.Columns.AddRange(new DataGridViewColumn[] { colFaixa, colConcurso, colData, colNumeros });
            dgvSorteios.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(40, 42, 58),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                SelectionBackColor = Color.FromArgb(63, 81, 181),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            dgvSorteios.Dock = DockStyle.Fill;
            dgvSorteios.EnableHeadersVisualStyles = false;
            dgvSorteios.GridColor = Color.FromArgb(55, 58, 78);
            dgvSorteios.Location = new Point(15, 159);
            dgvSorteios.Name = "dgvSorteios";
            dgvSorteios.ReadOnly = true;
            dgvSorteios.RowHeadersVisible = false;
            dgvSorteios.RowTemplate.Height = 38;
            dgvSorteios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSorteios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSorteios.MultiSelect = false;
            // 
            // colFaixa
            // 
            colFaixa.DataPropertyName = "Faixa";
            colFaixa.HeaderText = "Acertos";
            colFaixa.Name = "colFaixa";
            colFaixa.FillWeight = 60;
            // 
            // colConcurso
            // 
            colConcurso.DataPropertyName = "Concurso";
            colConcurso.HeaderText = "Concurso";
            colConcurso.Name = "colConcurso";
            colConcurso.FillWeight = 70;
            // 
            // colData
            // 
            colData.DataPropertyName = "Data";
            colData.HeaderText = "Data do Sorteio";
            colData.Name = "colData";
            colData.FillWeight = 90;
            // 
            // colNumeros
            // 
            colNumeros.DataPropertyName = "Numeros";
            colNumeros.HeaderText = "Números acertados";
            colNumeros.Name = "colNumeros";
            colNumeros.FillWeight = 220;
            // 
            // FormVerificarAposta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1060, 600);
            Controls.Add(panelResultado);
            Controls.Add(panelTop);
            Name = "FormVerificarAposta";
            Text = "Verificar Aposta";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelResultado.ResumeLayout(false);
            panelCards.ResumeLayout(false);
            cardJaApostou.ResumeLayout(false);
            cardJaSorteado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSorteios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Label lblInstrucao;
        private FlowLayoutPanel flowNumeros;
        private Button btnVerificar;
        private Button btnLimpar;
        private Panel panelResultado;
        private Panel panelCards;
        private Panel cardJaApostou;
        private Label lblTituloJaApostou;
        private Label lblJaApostou;
        private Panel cardJaSorteado;
        private Label lblTituloJaSorteado;
        private Label lblJaSorteado;
        private Label lblTituloSorteios;
        private DataGridView dgvSorteios;
        private DataGridViewTextBoxColumn colFaixa;
        private DataGridViewTextBoxColumn colConcurso;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewTextBoxColumn colNumeros;
    }
}
