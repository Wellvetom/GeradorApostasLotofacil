namespace GeradorApostasLotofacil
{
    partial class FormDashboard
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
            panelCards = new Panel();
            cardTotalApostas = new Panel();
            lblTotalApostas = new Label();
            lblTituloTotalApostas = new Label();
            cardTotalJogos = new Panel();
            lblTotalJogos = new Label();
            lblTituloTotalJogos = new Label();
            cardMelhorAcerto = new Panel();
            lblMelhorAcerto = new Label();
            lblTituloMelhorAcerto = new Label();
            cardUltimaAposta = new Panel();
            lblUltimaAposta = new Label();
            lblTituloUltimaAposta = new Label();
            cardTaxaAcerto = new Panel();
            lblTaxaAcerto = new Label();
            lblTituloTaxaAcerto = new Label();
            cardNumeroSorte = new Panel();
            lblNumeroSorte = new Label();
            lblTituloNumeroSorte = new Label();
            panelGraficoAcertos = new Panel();
            panelInferior = new Panel();
            panelNumerosFrequentes = new Panel();
            lblTituloNumeros = new Label();
            dgvNumerosFrequentes = new DataGridView();
            panelUltimasApostas = new Panel();
            lblTituloUltimasApostas = new Label();
            dgvUltimasApostas = new DataGridView();
            lblStatus = new Label();
            lblTituloDashboard = new Label();

            panelCards.SuspendLayout();
            cardTotalApostas.SuspendLayout();
            cardTotalJogos.SuspendLayout();
            cardMelhorAcerto.SuspendLayout();
            cardUltimaAposta.SuspendLayout();
            cardTaxaAcerto.SuspendLayout();
            cardNumeroSorte.SuspendLayout();
            panelInferior.SuspendLayout();
            panelNumerosFrequentes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvNumerosFrequentes).BeginInit();
            panelUltimasApostas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimasApostas).BeginInit();
            SuspendLayout();

            // 
            // lblTituloDashboard
            // 
            lblTituloDashboard.Dock = DockStyle.Top;
            lblTituloDashboard.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTituloDashboard.ForeColor = Color.White;
            lblTituloDashboard.Location = new Point(0, 0);
            lblTituloDashboard.Name = "lblTituloDashboard";
            lblTituloDashboard.Padding = new Padding(15, 10, 0, 0);
            lblTituloDashboard.Size = new Size(1050, 50);
            lblTituloDashboard.Text = "📊 Dashboard";

            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(20, 55);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(150, 20);
            lblStatus.Text = "";
            lblStatus.Visible = false;

            // 
            // panelCards
            // 
            panelCards.Controls.Add(cardTotalApostas);
            panelCards.Controls.Add(cardTotalJogos);
            panelCards.Controls.Add(cardMelhorAcerto);
            panelCards.Controls.Add(cardUltimaAposta);
            panelCards.Controls.Add(cardTaxaAcerto);
            panelCards.Controls.Add(cardNumeroSorte);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(0, 50);
            panelCards.Name = "panelCards";
            panelCards.Padding = new Padding(10, 10, 10, 5);
            panelCards.Size = new Size(1050, 230);

            // 
            // cardTotalApostas
            // 
            cardTotalApostas.BackColor = Color.FromArgb(63, 81, 181);
            cardTotalApostas.Controls.Add(lblTotalApostas);
            cardTotalApostas.Controls.Add(lblTituloTotalApostas);
            cardTotalApostas.Location = new Point(15, 15);
            cardTotalApostas.Name = "cardTotalApostas";
            cardTotalApostas.Size = new Size(230, 90);

            // 
            // lblTituloTotalApostas
            // 
            lblTituloTotalApostas.Font = new Font("Segoe UI", 9F);
            lblTituloTotalApostas.ForeColor = Color.FromArgb(200, 200, 255);
            lblTituloTotalApostas.Location = new Point(15, 10);
            lblTituloTotalApostas.Size = new Size(200, 20);
            lblTituloTotalApostas.Text = "TOTAL DE APOSTAS";

            // 
            // lblTotalApostas
            // 
            lblTotalApostas.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalApostas.ForeColor = Color.White;
            lblTotalApostas.Location = new Point(15, 35);
            lblTotalApostas.Size = new Size(200, 45);
            lblTotalApostas.Text = "0";

            // 
            // cardTotalJogos
            // 
            cardTotalJogos.BackColor = Color.FromArgb(0, 150, 136);
            cardTotalJogos.Controls.Add(lblTotalJogos);
            cardTotalJogos.Controls.Add(lblTituloTotalJogos);
            cardTotalJogos.Location = new Point(260, 15);
            cardTotalJogos.Name = "cardTotalJogos";
            cardTotalJogos.Size = new Size(230, 90);

            // 
            // lblTituloTotalJogos
            // 
            lblTituloTotalJogos.Font = new Font("Segoe UI", 9F);
            lblTituloTotalJogos.ForeColor = Color.FromArgb(200, 255, 240);
            lblTituloTotalJogos.Location = new Point(15, 10);
            lblTituloTotalJogos.Size = new Size(200, 20);
            lblTituloTotalJogos.Text = "TOTAL DE JOGOS";

            // 
            // lblTotalJogos
            // 
            lblTotalJogos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalJogos.ForeColor = Color.White;
            lblTotalJogos.Location = new Point(15, 35);
            lblTotalJogos.Size = new Size(200, 45);
            lblTotalJogos.Text = "0";

            // 
            // cardMelhorAcerto
            // 
            cardMelhorAcerto.BackColor = Color.FromArgb(255, 152, 0);
            cardMelhorAcerto.Controls.Add(lblMelhorAcerto);
            cardMelhorAcerto.Controls.Add(lblTituloMelhorAcerto);
            cardMelhorAcerto.Location = new Point(505, 15);
            cardMelhorAcerto.Name = "cardMelhorAcerto";
            cardMelhorAcerto.Size = new Size(230, 90);

            // 
            // lblTituloMelhorAcerto
            // 
            lblTituloMelhorAcerto.Font = new Font("Segoe UI", 9F);
            lblTituloMelhorAcerto.ForeColor = Color.FromArgb(255, 240, 200);
            lblTituloMelhorAcerto.Location = new Point(15, 10);
            lblTituloMelhorAcerto.Size = new Size(200, 20);
            lblTituloMelhorAcerto.Text = "MELHOR ACERTO";

            // 
            // lblMelhorAcerto
            // 
            lblMelhorAcerto.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblMelhorAcerto.ForeColor = Color.White;
            lblMelhorAcerto.Location = new Point(15, 35);
            lblMelhorAcerto.Size = new Size(200, 45);
            lblMelhorAcerto.Text = "—";

            // 
            // cardUltimaAposta
            // 
            cardUltimaAposta.BackColor = Color.FromArgb(156, 39, 176);
            cardUltimaAposta.Controls.Add(lblUltimaAposta);
            cardUltimaAposta.Controls.Add(lblTituloUltimaAposta);
            cardUltimaAposta.Location = new Point(750, 15);
            cardUltimaAposta.Name = "cardUltimaAposta";
            cardUltimaAposta.Size = new Size(230, 90);

            // 
            // lblTituloUltimaAposta
            // 
            lblTituloUltimaAposta.Font = new Font("Segoe UI", 9F);
            lblTituloUltimaAposta.ForeColor = Color.FromArgb(230, 200, 255);
            lblTituloUltimaAposta.Location = new Point(15, 10);
            lblTituloUltimaAposta.Size = new Size(200, 20);
            lblTituloUltimaAposta.Text = "ÚLTIMA APOSTA";

            // 
            // lblUltimaAposta
            // 
            lblUltimaAposta.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUltimaAposta.ForeColor = Color.White;
            lblUltimaAposta.Location = new Point(15, 38);
            lblUltimaAposta.Size = new Size(200, 40);
            lblUltimaAposta.Text = "—";

            // 
            // cardTaxaAcerto
            // 
            cardTaxaAcerto.BackColor = Color.FromArgb(45, 55, 72);
            cardTaxaAcerto.Controls.Add(lblTaxaAcerto);
            cardTaxaAcerto.Controls.Add(lblTituloTaxaAcerto);
            cardTaxaAcerto.Location = new Point(15, 115);
            cardTaxaAcerto.Name = "cardTaxaAcerto";
            cardTaxaAcerto.Size = new Size(230, 90);

            // 
            // lblTituloTaxaAcerto
            // 
            lblTituloTaxaAcerto.Font = new Font("Segoe UI", 9F);
            lblTituloTaxaAcerto.ForeColor = Color.FromArgb(180, 130, 255);
            lblTituloTaxaAcerto.Location = new Point(15, 10);
            lblTituloTaxaAcerto.Size = new Size(200, 20);
            lblTituloTaxaAcerto.Text = "TAXA 11+";

            // 
            // lblTaxaAcerto
            // 
            lblTaxaAcerto.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTaxaAcerto.ForeColor = Color.White;
            lblTaxaAcerto.Location = new Point(15, 35);
            lblTaxaAcerto.Size = new Size(200, 45);
            lblTaxaAcerto.Text = "—";

            // 
            // cardNumeroSorte
            // 
            cardNumeroSorte.BackColor = Color.FromArgb(45, 55, 72);
            cardNumeroSorte.Controls.Add(lblNumeroSorte);
            cardNumeroSorte.Controls.Add(lblTituloNumeroSorte);
            cardNumeroSorte.Location = new Point(260, 115);
            cardNumeroSorte.Name = "cardNumeroSorte";
            cardNumeroSorte.Size = new Size(230, 90);

            // 
            // lblTituloNumeroSorte
            // 
            lblTituloNumeroSorte.Font = new Font("Segoe UI", 9F);
            lblTituloNumeroSorte.ForeColor = Color.FromArgb(255, 215, 0);
            lblTituloNumeroSorte.Location = new Point(15, 10);
            lblTituloNumeroSorte.Size = new Size(200, 20);
            lblTituloNumeroSorte.Text = "Nº DA SORTE";

            // 
            // lblNumeroSorte
            // 
            lblNumeroSorte.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblNumeroSorte.ForeColor = Color.White;
            lblNumeroSorte.Location = new Point(15, 35);
            lblNumeroSorte.Size = new Size(200, 45);
            lblNumeroSorte.Text = "—";

            // 
            // panelGraficoAcertos
            // 
            panelGraficoAcertos.BackColor = Color.FromArgb(45, 55, 72);
            panelGraficoAcertos.Dock = DockStyle.Top;
            panelGraficoAcertos.Location = new Point(0, 280);
            panelGraficoAcertos.Name = "panelGraficoAcertos";
            panelGraficoAcertos.Size = new Size(1050, 180);
            panelGraficoAcertos.Paint += panelGraficoAcertos_Paint;

            // 
            // panelInferior
            // 
            panelInferior.Controls.Add(panelUltimasApostas);
            panelInferior.Controls.Add(panelNumerosFrequentes);
            panelInferior.Dock = DockStyle.Fill;
            panelInferior.Location = new Point(0, 460);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1050, 250);

            // 
            // panelNumerosFrequentes
            // 
            panelNumerosFrequentes.BackColor = Color.FromArgb(45, 55, 72);
            panelNumerosFrequentes.Controls.Add(dgvNumerosFrequentes);
            panelNumerosFrequentes.Controls.Add(lblTituloNumeros);
            panelNumerosFrequentes.Dock = DockStyle.Left;
            panelNumerosFrequentes.Location = new Point(0, 0);
            panelNumerosFrequentes.Name = "panelNumerosFrequentes";
            panelNumerosFrequentes.Padding = new Padding(10);
            panelNumerosFrequentes.Size = new Size(350, 250);

            // 
            // lblTituloNumeros
            // 
            lblTituloNumeros.Dock = DockStyle.Top;
            lblTituloNumeros.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloNumeros.ForeColor = Color.White;
            lblTituloNumeros.Location = new Point(10, 10);
            lblTituloNumeros.Name = "lblTituloNumeros";
            lblTituloNumeros.Padding = new Padding(5);
            lblTituloNumeros.Size = new Size(330, 30);
            lblTituloNumeros.Text = "🔢 Top 10 Números Mais Usados";

            // 
            // dgvNumerosFrequentes
            // 
            dgvNumerosFrequentes.AllowUserToAddRows = false;
            dgvNumerosFrequentes.AllowUserToDeleteRows = false;
            dgvNumerosFrequentes.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvNumerosFrequentes.BorderStyle = BorderStyle.None;
            dgvNumerosFrequentes.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            dgvNumerosFrequentes.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(55, 65, 82),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(75, 85, 102),
                SelectionForeColor = Color.White
            };
            dgvNumerosFrequentes.Dock = DockStyle.Fill;
            dgvNumerosFrequentes.EnableHeadersVisualStyles = false;
            dgvNumerosFrequentes.GridColor = Color.FromArgb(70, 80, 95);
            dgvNumerosFrequentes.Location = new Point(10, 40);
            dgvNumerosFrequentes.Name = "dgvNumerosFrequentes";
            dgvNumerosFrequentes.ReadOnly = true;
            dgvNumerosFrequentes.RowHeadersVisible = false;
            dgvNumerosFrequentes.Size = new Size(330, 200);

            // 
            // panelUltimasApostas
            // 
            panelUltimasApostas.BackColor = Color.FromArgb(45, 55, 72);
            panelUltimasApostas.Controls.Add(dgvUltimasApostas);
            panelUltimasApostas.Controls.Add(lblTituloUltimasApostas);
            panelUltimasApostas.Dock = DockStyle.Fill;
            panelUltimasApostas.Location = new Point(350, 0);
            panelUltimasApostas.Name = "panelUltimasApostas";
            panelUltimasApostas.Padding = new Padding(10);
            panelUltimasApostas.Size = new Size(700, 250);

            // 
            // lblTituloUltimasApostas
            // 
            lblTituloUltimasApostas.Dock = DockStyle.Top;
            lblTituloUltimasApostas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloUltimasApostas.ForeColor = Color.White;
            lblTituloUltimasApostas.Location = new Point(10, 10);
            lblTituloUltimasApostas.Name = "lblTituloUltimasApostas";
            lblTituloUltimasApostas.Padding = new Padding(5);
            lblTituloUltimasApostas.Size = new Size(680, 30);
            lblTituloUltimasApostas.Text = "🕐 Últimos 10 Jogos";

            // 
            // dgvUltimasApostas
            // 
            dgvUltimasApostas.AllowUserToAddRows = false;
            dgvUltimasApostas.AllowUserToDeleteRows = false;
            dgvUltimasApostas.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvUltimasApostas.BorderStyle = BorderStyle.None;
            dgvUltimasApostas.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            dgvUltimasApostas.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(55, 65, 82),
                ForeColor = Color.White,
                SelectionBackColor = Color.FromArgb(75, 85, 102),
                SelectionForeColor = Color.White
            };
            dgvUltimasApostas.Dock = DockStyle.Fill;
            dgvUltimasApostas.EnableHeadersVisualStyles = false;
            dgvUltimasApostas.GridColor = Color.FromArgb(70, 80, 95);
            dgvUltimasApostas.Location = new Point(10, 40);
            dgvUltimasApostas.Name = "dgvUltimasApostas";
            dgvUltimasApostas.ReadOnly = true;
            dgvUltimasApostas.RowHeadersVisible = false;
            dgvUltimasApostas.Size = new Size(680, 200);

            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1050, 600);
            Controls.Add(panelInferior);
            Controls.Add(panelGraficoAcertos);
            Controls.Add(panelCards);
            Controls.Add(lblStatus);
            Controls.Add(lblTituloDashboard);
            Name = "FormDashboard";
            Text = "Dashboard";
            Load += FormDashboard_Load;

            panelCards.ResumeLayout(false);
            cardTotalApostas.ResumeLayout(false);
            cardTotalJogos.ResumeLayout(false);
            cardMelhorAcerto.ResumeLayout(false);
            cardUltimaAposta.ResumeLayout(false);
            cardTaxaAcerto.ResumeLayout(false);
            cardNumeroSorte.ResumeLayout(false);
            panelInferior.ResumeLayout(false);
            panelNumerosFrequentes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvNumerosFrequentes).EndInit();
            panelUltimasApostas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimasApostas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCards;
        private Panel cardTotalApostas;
        private Label lblTotalApostas;
        private Label lblTituloTotalApostas;
        private Panel cardTotalJogos;
        private Label lblTotalJogos;
        private Label lblTituloTotalJogos;
        private Panel cardMelhorAcerto;
        private Label lblMelhorAcerto;
        private Label lblTituloMelhorAcerto;
        private Panel cardUltimaAposta;
        private Label lblUltimaAposta;
        private Label lblTituloUltimaAposta;
        private Panel cardTaxaAcerto;
        private Label lblTaxaAcerto;
        private Label lblTituloTaxaAcerto;
        private Panel cardNumeroSorte;
        private Label lblNumeroSorte;
        private Label lblTituloNumeroSorte;
        private Panel panelGraficoAcertos;
        private Panel panelInferior;
        private Panel panelNumerosFrequentes;
        private Label lblTituloNumeros;
        private DataGridView dgvNumerosFrequentes;
        private Panel panelUltimasApostas;
        private Label lblTituloUltimasApostas;
        private DataGridView dgvUltimasApostas;
        private Label lblStatus;
        private Label lblTituloDashboard;
    }
}
