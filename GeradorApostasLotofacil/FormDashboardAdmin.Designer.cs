namespace GeradorApostasLotofacil
{
    partial class FormDashboardAdmin
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
            cardTotalSorteios = new Panel();
            lblTotalSorteios = new Label();
            lblTituloTotalSorteios = new Label();
            cardUltimoSorteio = new Panel();
            lblUltimoSorteio = new Label();
            lblTituloUltimoSorteio = new Label();
            cardDataUltimo = new Panel();
            lblDataUltimo = new Label();
            lblTituloDataUltimo = new Label();
            cardJogosRepetidos = new Panel();
            lblJogosRepetidos = new Label();
            lblTituloJogosRepetidos = new Label();
            panelGrids = new Panel();
            panelMaisSairam = new Panel();
            lblTituloMaisSairam = new Label();
            dgvMaisSairam = new DataGridView();
            panelMenosSairam = new Panel();
            lblTituloMenosSairam = new Label();
            dgvMenosSairam = new DataGridView();
            panelUltimosSorteios = new Panel();
            lblTituloUltimosSorteios = new Label();
            dgvUltimosSorteios = new DataGridView();
            lblTitulo = new Label();
            lblStatus = new Label();

            panelCards.SuspendLayout();
            cardTotalSorteios.SuspendLayout();
            cardUltimoSorteio.SuspendLayout();
            cardDataUltimo.SuspendLayout();
            cardJogosRepetidos.SuspendLayout();
            panelGrids.SuspendLayout();
            panelMaisSairam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMaisSairam).BeginInit();
            panelMenosSairam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMenosSairam).BeginInit();
            panelUltimosSorteios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosSorteios).BeginInit();
            SuspendLayout();

            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Padding = new Padding(15, 10, 0, 0);
            lblTitulo.Size = new Size(1050, 50);
            lblTitulo.Text = "🛡️ Painel Administrativo — Sorteios Importados";

            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(20, 55);
            lblStatus.Text = "";
            lblStatus.Visible = false;

            // 
            // panelCards
            // 
            panelCards.Controls.Add(cardTotalSorteios);
            panelCards.Controls.Add(cardUltimoSorteio);
            panelCards.Controls.Add(cardDataUltimo);
            panelCards.Controls.Add(cardJogosRepetidos);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(0, 50);
            panelCards.Size = new Size(1050, 110);

            // 
            // cardTotalSorteios
            // 
            cardTotalSorteios.BackColor = Color.FromArgb(183, 28, 28);
            cardTotalSorteios.Controls.Add(lblTotalSorteios);
            cardTotalSorteios.Controls.Add(lblTituloTotalSorteios);
            cardTotalSorteios.Location = new Point(15, 10);
            cardTotalSorteios.Size = new Size(230, 85);
            // 
            lblTituloTotalSorteios.Font = new Font("Segoe UI", 9F);
            lblTituloTotalSorteios.ForeColor = Color.FromArgb(255, 200, 200);
            lblTituloTotalSorteios.Location = new Point(15, 10);
            lblTituloTotalSorteios.Size = new Size(200, 20);
            lblTituloTotalSorteios.Text = "SORTEIOS IMPORTADOS";
            // 
            lblTotalSorteios.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTotalSorteios.ForeColor = Color.White;
            lblTotalSorteios.Location = new Point(15, 35);
            lblTotalSorteios.Size = new Size(200, 42);
            lblTotalSorteios.Text = "0";

            // 
            // cardUltimoSorteio
            // 
            cardUltimoSorteio.BackColor = Color.FromArgb(230, 81, 0);
            cardUltimoSorteio.Controls.Add(lblUltimoSorteio);
            cardUltimoSorteio.Controls.Add(lblTituloUltimoSorteio);
            cardUltimoSorteio.Location = new Point(260, 10);
            cardUltimoSorteio.Size = new Size(230, 85);
            // 
            lblTituloUltimoSorteio.Font = new Font("Segoe UI", 9F);
            lblTituloUltimoSorteio.ForeColor = Color.FromArgb(255, 224, 178);
            lblTituloUltimoSorteio.Location = new Point(15, 10);
            lblTituloUltimoSorteio.Size = new Size(200, 20);
            lblTituloUltimoSorteio.Text = "ÚLTIMO SORTEIO";
            // 
            lblUltimoSorteio.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblUltimoSorteio.ForeColor = Color.White;
            lblUltimoSorteio.Location = new Point(15, 35);
            lblUltimoSorteio.Size = new Size(200, 42);
            lblUltimoSorteio.Text = "—";

            // 
            // cardDataUltimo
            // 
            cardDataUltimo.BackColor = Color.FromArgb(46, 125, 50);
            cardDataUltimo.Controls.Add(lblDataUltimo);
            cardDataUltimo.Controls.Add(lblTituloDataUltimo);
            cardDataUltimo.Location = new Point(505, 10);
            cardDataUltimo.Size = new Size(230, 85);
            // 
            lblTituloDataUltimo.Font = new Font("Segoe UI", 9F);
            lblTituloDataUltimo.ForeColor = Color.FromArgb(200, 255, 200);
            lblTituloDataUltimo.Location = new Point(15, 10);
            lblTituloDataUltimo.Size = new Size(200, 20);
            lblTituloDataUltimo.Text = "DATA ÚLTIMO SORTEIO";
            // 
            lblDataUltimo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblDataUltimo.ForeColor = Color.White;
            lblDataUltimo.Location = new Point(15, 35);
            lblDataUltimo.Size = new Size(200, 42);
            lblDataUltimo.Text = "—";

            // 
            // cardJogosRepetidos
            // 
            cardJogosRepetidos.BackColor = Color.FromArgb(74, 20, 140);
            cardJogosRepetidos.Controls.Add(lblJogosRepetidos);
            cardJogosRepetidos.Controls.Add(lblTituloJogosRepetidos);
            cardJogosRepetidos.Location = new Point(750, 10);
            cardJogosRepetidos.Size = new Size(230, 85);
            // 
            lblTituloJogosRepetidos.Font = new Font("Segoe UI", 9F);
            lblTituloJogosRepetidos.ForeColor = Color.FromArgb(220, 200, 255);
            lblTituloJogosRepetidos.Location = new Point(15, 10);
            lblTituloJogosRepetidos.Size = new Size(200, 20);
            lblTituloJogosRepetidos.Text = "JOGOS REPETIDOS";
            // 
            lblJogosRepetidos.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblJogosRepetidos.ForeColor = Color.White;
            lblJogosRepetidos.Location = new Point(15, 35);
            lblJogosRepetidos.Size = new Size(200, 42);
            lblJogosRepetidos.Text = "0";

            // 
            // panelGrids
            // 
            panelGrids.Controls.Add(panelUltimosSorteios);
            panelGrids.Controls.Add(panelMenosSairam);
            panelGrids.Controls.Add(panelMaisSairam);
            panelGrids.Dock = DockStyle.Fill;
            panelGrids.Location = new Point(0, 160);

            // 
            // panelMaisSairam
            // 
            panelMaisSairam.BackColor = Color.FromArgb(45, 55, 72);
            panelMaisSairam.Controls.Add(dgvMaisSairam);
            panelMaisSairam.Controls.Add(lblTituloMaisSairam);
            panelMaisSairam.Dock = DockStyle.Left;
            panelMaisSairam.Padding = new Padding(8);
            panelMaisSairam.Size = new Size(250, 400);
            // 
            lblTituloMaisSairam.Dock = DockStyle.Top;
            lblTituloMaisSairam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloMaisSairam.ForeColor = Color.FromArgb(100, 255, 100);
            lblTituloMaisSairam.Padding = new Padding(5);
            lblTituloMaisSairam.Size = new Size(234, 30);
            lblTituloMaisSairam.Text = "🔥 Mais Sorteados";
            // 
            dgvMaisSairam.AllowUserToAddRows = false;
            dgvMaisSairam.AllowUserToDeleteRows = false;
            dgvMaisSairam.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvMaisSairam.BorderStyle = BorderStyle.None;
            dgvMaisSairam.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            dgvMaisSairam.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            dgvMaisSairam.Dock = DockStyle.Fill;
            dgvMaisSairam.EnableHeadersVisualStyles = false;
            dgvMaisSairam.GridColor = Color.FromArgb(70, 80, 95);
            dgvMaisSairam.ReadOnly = true;
            dgvMaisSairam.RowHeadersVisible = false;
            dgvMaisSairam.RowTemplate.Height = 28;

            // 
            // panelMenosSairam
            // 
            panelMenosSairam.BackColor = Color.FromArgb(45, 55, 72);
            panelMenosSairam.Controls.Add(dgvMenosSairam);
            panelMenosSairam.Controls.Add(lblTituloMenosSairam);
            panelMenosSairam.Dock = DockStyle.Left;
            panelMenosSairam.Padding = new Padding(8);
            panelMenosSairam.Size = new Size(250, 400);
            // 
            lblTituloMenosSairam.Dock = DockStyle.Top;
            lblTituloMenosSairam.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloMenosSairam.ForeColor = Color.FromArgb(255, 150, 150);
            lblTituloMenosSairam.Padding = new Padding(5);
            lblTituloMenosSairam.Size = new Size(234, 30);
            lblTituloMenosSairam.Text = "❄️ Menos Sorteados";
            // 
            dgvMenosSairam.AllowUserToAddRows = false;
            dgvMenosSairam.AllowUserToDeleteRows = false;
            dgvMenosSairam.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvMenosSairam.BorderStyle = BorderStyle.None;
            dgvMenosSairam.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            dgvMenosSairam.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 10F, FontStyle.Bold) };
            dgvMenosSairam.Dock = DockStyle.Fill;
            dgvMenosSairam.EnableHeadersVisualStyles = false;
            dgvMenosSairam.GridColor = Color.FromArgb(70, 80, 95);
            dgvMenosSairam.ReadOnly = true;
            dgvMenosSairam.RowHeadersVisible = false;
            dgvMenosSairam.RowTemplate.Height = 28;

            // 
            // panelUltimosSorteios
            // 
            panelUltimosSorteios.BackColor = Color.FromArgb(45, 55, 72);
            panelUltimosSorteios.Controls.Add(dgvUltimosSorteios);
            panelUltimosSorteios.Controls.Add(lblTituloUltimosSorteios);
            panelUltimosSorteios.Dock = DockStyle.Fill;
            panelUltimosSorteios.Padding = new Padding(8);
            // 
            lblTituloUltimosSorteios.Dock = DockStyle.Top;
            lblTituloUltimosSorteios.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTituloUltimosSorteios.ForeColor = Color.White;
            lblTituloUltimosSorteios.Padding = new Padding(5);
            lblTituloUltimosSorteios.Size = new Size(500, 30);
            lblTituloUltimosSorteios.Text = "🏆 Últimos 10 Sorteios Oficiais";
            // 
            dgvUltimosSorteios.AllowUserToAddRows = false;
            dgvUltimosSorteios.AllowUserToDeleteRows = false;
            dgvUltimosSorteios.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvUltimosSorteios.BorderStyle = BorderStyle.None;
            dgvUltimosSorteios.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            dgvUltimosSorteios.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 10F) };
            dgvUltimosSorteios.Dock = DockStyle.Fill;
            dgvUltimosSorteios.EnableHeadersVisualStyles = false;
            dgvUltimosSorteios.GridColor = Color.FromArgb(70, 80, 95);
            dgvUltimosSorteios.ReadOnly = true;
            dgvUltimosSorteios.RowHeadersVisible = false;
            dgvUltimosSorteios.RowTemplate.Height = 32;

            // 
            // FormDashboardAdmin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1050, 600);
            Controls.Add(panelGrids);
            Controls.Add(panelCards);
            Controls.Add(lblStatus);
            Controls.Add(lblTitulo);
            Name = "FormDashboardAdmin";
            Text = "Dashboard Admin";
            Load += FormDashboardAdmin_Load;

            panelCards.ResumeLayout(false);
            cardTotalSorteios.ResumeLayout(false);
            cardUltimoSorteio.ResumeLayout(false);
            cardDataUltimo.ResumeLayout(false);
            cardJogosRepetidos.ResumeLayout(false);
            panelGrids.ResumeLayout(false);
            panelMaisSairam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMaisSairam).EndInit();
            panelMenosSairam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvMenosSairam).EndInit();
            panelUltimosSorteios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimosSorteios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelCards;
        private Panel cardTotalSorteios;
        private Label lblTotalSorteios;
        private Label lblTituloTotalSorteios;
        private Panel cardUltimoSorteio;
        private Label lblUltimoSorteio;
        private Label lblTituloUltimoSorteio;
        private Panel cardDataUltimo;
        private Label lblDataUltimo;
        private Label lblTituloDataUltimo;
        private Panel cardJogosRepetidos;
        private Label lblJogosRepetidos;
        private Label lblTituloJogosRepetidos;
        private Panel panelGrids;
        private Panel panelMaisSairam;
        private Label lblTituloMaisSairam;
        private DataGridView dgvMaisSairam;
        private Panel panelMenosSairam;
        private Label lblTituloMenosSairam;
        private DataGridView dgvMenosSairam;
        private Panel panelUltimosSorteios;
        private Label lblTituloUltimosSorteios;
        private DataGridView dgvUltimosSorteios;
        private Label lblTitulo;
        private Label lblStatus;
    }
}
