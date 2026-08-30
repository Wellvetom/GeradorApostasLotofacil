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
            panelGridsTop = new Panel();
            panelMaisSairam = new Panel();
            lblTituloMaisSairam = new Label();
            pieMaisSairam = new Controls.PieChartControl();
            panelMenosSairam = new Panel();
            lblTituloMenosSairam = new Label();
            pieMenosSairam = new Controls.PieChartControl();
            panelUltimosSorteios = new Panel();
            lblTituloUltimosSorteios = new Label();
            dgvUltimosSorteios = new DataGridView();
            panelGridsBottom = new Panel();
            panelComum12 = new Panel();
            lblTituloComum12 = new Label();
            dgvComum12 = new DataGridView();
            panelComum13 = new Panel();
            lblTituloComum13 = new Label();
            dgvComum13 = new DataGridView();
            panelComum14 = new Panel();
            lblTituloComum14 = new Label();
            dgvComum14 = new DataGridView();
            lblTitulo = new Label();
            lblStatus = new Label();

            panelCards.SuspendLayout();
            cardTotalSorteios.SuspendLayout();
            cardUltimoSorteio.SuspendLayout();
            cardDataUltimo.SuspendLayout();
            cardJogosRepetidos.SuspendLayout();
            panelGridsTop.SuspendLayout();
            panelMaisSairam.SuspendLayout();
            panelMenosSairam.SuspendLayout();
            panelUltimosSorteios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUltimosSorteios).BeginInit();
            panelGridsBottom.SuspendLayout();
            panelComum12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComum12).BeginInit();
            panelComum13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComum13).BeginInit();
            panelComum14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvComum14).BeginInit();
            SuspendLayout();

            // lblTitulo
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Padding = new Padding(15, 10, 0, 0);
            lblTitulo.Size = new Size(1050, 50);
            lblTitulo.Text = "🛡️ Painel Administrativo — Sorteios Importados";

            // lblStatus
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F);
            lblStatus.ForeColor = Color.LightGray;
            lblStatus.Location = new Point(20, 55);
            lblStatus.Text = "";
            lblStatus.Visible = false;

            // panelCards
            panelCards.Controls.Add(cardTotalSorteios);
            panelCards.Controls.Add(cardUltimoSorteio);
            panelCards.Controls.Add(cardDataUltimo);
            panelCards.Controls.Add(cardJogosRepetidos);
            panelCards.Dock = DockStyle.Top;
            panelCards.Location = new Point(0, 50);
            panelCards.Size = new Size(1050, 100);

            // cardTotalSorteios
            cardTotalSorteios.BackColor = Color.FromArgb(183, 28, 28);
            cardTotalSorteios.Controls.Add(lblTotalSorteios);
            cardTotalSorteios.Controls.Add(lblTituloTotalSorteios);
            cardTotalSorteios.Location = new Point(15, 10);
            cardTotalSorteios.Size = new Size(230, 75);
            lblTituloTotalSorteios.Font = new Font("Segoe UI", 8F);
            lblTituloTotalSorteios.ForeColor = Color.FromArgb(255, 200, 200);
            lblTituloTotalSorteios.Location = new Point(12, 8);
            lblTituloTotalSorteios.Size = new Size(200, 18);
            lblTituloTotalSorteios.Text = "SORTEIOS IMPORTADOS";
            lblTotalSorteios.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTotalSorteios.ForeColor = Color.White;
            lblTotalSorteios.Location = new Point(12, 30);
            lblTotalSorteios.Size = new Size(200, 38);
            lblTotalSorteios.Text = "0";

            // cardUltimoSorteio
            cardUltimoSorteio.BackColor = Color.FromArgb(230, 81, 0);
            cardUltimoSorteio.Controls.Add(lblUltimoSorteio);
            cardUltimoSorteio.Controls.Add(lblTituloUltimoSorteio);
            cardUltimoSorteio.Location = new Point(260, 10);
            cardUltimoSorteio.Size = new Size(230, 75);
            lblTituloUltimoSorteio.Font = new Font("Segoe UI", 8F);
            lblTituloUltimoSorteio.ForeColor = Color.FromArgb(255, 224, 178);
            lblTituloUltimoSorteio.Location = new Point(12, 8);
            lblTituloUltimoSorteio.Size = new Size(200, 18);
            lblTituloUltimoSorteio.Text = "ÚLTIMO SORTEIO";
            lblUltimoSorteio.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblUltimoSorteio.ForeColor = Color.White;
            lblUltimoSorteio.Location = new Point(12, 30);
            lblUltimoSorteio.Size = new Size(200, 38);
            lblUltimoSorteio.Text = "—";

            // cardDataUltimo
            cardDataUltimo.BackColor = Color.FromArgb(46, 125, 50);
            cardDataUltimo.Controls.Add(lblDataUltimo);
            cardDataUltimo.Controls.Add(lblTituloDataUltimo);
            cardDataUltimo.Location = new Point(505, 10);
            cardDataUltimo.Size = new Size(230, 75);
            lblTituloDataUltimo.Font = new Font("Segoe UI", 8F);
            lblTituloDataUltimo.ForeColor = Color.FromArgb(200, 255, 200);
            lblTituloDataUltimo.Location = new Point(12, 8);
            lblTituloDataUltimo.Size = new Size(200, 18);
            lblTituloDataUltimo.Text = "DATA ÚLTIMO SORTEIO";
            lblDataUltimo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblDataUltimo.ForeColor = Color.White;
            lblDataUltimo.Location = new Point(12, 30);
            lblDataUltimo.Size = new Size(200, 38);
            lblDataUltimo.Text = "—";

            // cardJogosRepetidos
            cardJogosRepetidos.BackColor = Color.FromArgb(74, 20, 140);
            cardJogosRepetidos.Controls.Add(lblJogosRepetidos);
            cardJogosRepetidos.Controls.Add(lblTituloJogosRepetidos);
            cardJogosRepetidos.Location = new Point(750, 10);
            cardJogosRepetidos.Size = new Size(230, 75);
            lblTituloJogosRepetidos.Font = new Font("Segoe UI", 8F);
            lblTituloJogosRepetidos.ForeColor = Color.FromArgb(220, 200, 255);
            lblTituloJogosRepetidos.Location = new Point(12, 8);
            lblTituloJogosRepetidos.Size = new Size(200, 18);
            lblTituloJogosRepetidos.Text = "JOGOS REPETIDOS (15=15)";
            lblJogosRepetidos.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblJogosRepetidos.ForeColor = Color.White;
            lblJogosRepetidos.Location = new Point(12, 30);
            lblJogosRepetidos.Size = new Size(200, 38);
            lblJogosRepetidos.Text = "0";

            // panelGridsTop — Mais/Menos Sorteados + Últimos Sorteios
            panelGridsTop.Controls.Add(panelUltimosSorteios);
            panelGridsTop.Controls.Add(panelMenosSairam);
            panelGridsTop.Controls.Add(panelMaisSairam);
            panelGridsTop.Dock = DockStyle.Top;
            panelGridsTop.Location = new Point(0, 150);
            panelGridsTop.Size = new Size(1050, 220);

            // panelMaisSairam
            panelMaisSairam.BackColor = Color.FromArgb(45, 55, 72);
            panelMaisSairam.Controls.Add(pieMaisSairam);
            panelMaisSairam.Controls.Add(lblTituloMaisSairam);
            panelMaisSairam.Dock = DockStyle.Left;
            panelMaisSairam.Padding = new Padding(6);
            panelMaisSairam.Size = new Size(330, 220);
            lblTituloMaisSairam.Dock = DockStyle.Top;
            lblTituloMaisSairam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloMaisSairam.ForeColor = Color.FromArgb(100, 255, 100);
            lblTituloMaisSairam.Padding = new Padding(4);
            lblTituloMaisSairam.Size = new Size(318, 26);
            lblTituloMaisSairam.Text = "🔥 Mais Sorteados";
            pieMaisSairam.BackColor = Color.FromArgb(55, 65, 82);
            pieMaisSairam.Dock = DockStyle.Fill;
            pieMaisSairam.Name = "pieMaisSairam";

            // panelMenosSairam
            panelMenosSairam.BackColor = Color.FromArgb(45, 55, 72);
            panelMenosSairam.Controls.Add(pieMenosSairam);
            panelMenosSairam.Controls.Add(lblTituloMenosSairam);
            panelMenosSairam.Dock = DockStyle.Left;
            panelMenosSairam.Padding = new Padding(6);
            panelMenosSairam.Size = new Size(330, 220);
            lblTituloMenosSairam.Dock = DockStyle.Top;
            lblTituloMenosSairam.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloMenosSairam.ForeColor = Color.FromArgb(255, 150, 150);
            lblTituloMenosSairam.Padding = new Padding(4);
            lblTituloMenosSairam.Size = new Size(318, 26);
            lblTituloMenosSairam.Text = "❄️ Menos Sorteados";
            pieMenosSairam.BackColor = Color.FromArgb(55, 65, 82);
            pieMenosSairam.Dock = DockStyle.Fill;
            pieMenosSairam.Name = "pieMenosSairam";

            // panelUltimosSorteios
            panelUltimosSorteios.BackColor = Color.FromArgb(45, 55, 72);
            panelUltimosSorteios.Controls.Add(dgvUltimosSorteios);
            panelUltimosSorteios.Controls.Add(lblTituloUltimosSorteios);
            panelUltimosSorteios.Dock = DockStyle.Fill;
            panelUltimosSorteios.Padding = new Padding(6);
            lblTituloUltimosSorteios.Dock = DockStyle.Top;
            lblTituloUltimosSorteios.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloUltimosSorteios.ForeColor = Color.White;
            lblTituloUltimosSorteios.Padding = new Padding(4);
            lblTituloUltimosSorteios.Size = new Size(500, 26);
            lblTituloUltimosSorteios.Text = "🏆 Últimos 10 Sorteios Oficiais";
            dgvUltimosSorteios.AllowUserToAddRows = false;
            dgvUltimosSorteios.AllowUserToDeleteRows = false;
            dgvUltimosSorteios.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvUltimosSorteios.BorderStyle = BorderStyle.None;
            dgvUltimosSorteios.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 8F, FontStyle.Bold) };
            dgvUltimosSorteios.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 9F) };
            dgvUltimosSorteios.Dock = DockStyle.Fill;
            dgvUltimosSorteios.EnableHeadersVisualStyles = false;
            dgvUltimosSorteios.GridColor = Color.FromArgb(70, 80, 95);
            dgvUltimosSorteios.ReadOnly = true;
            dgvUltimosSorteios.RowHeadersVisible = false;
            dgvUltimosSorteios.RowTemplate.Height = 26;

            // panelGridsBottom — Listas de pares 12, 13, 14
            panelGridsBottom.Controls.Add(panelComum14);
            panelGridsBottom.Controls.Add(panelComum13);
            panelGridsBottom.Controls.Add(panelComum12);
            panelGridsBottom.Dock = DockStyle.Fill;
            panelGridsBottom.Location = new Point(0, 370);

            // panelComum12
            panelComum12.BackColor = Color.FromArgb(45, 55, 72);
            panelComum12.Controls.Add(dgvComum12);
            panelComum12.Controls.Add(lblTituloComum12);
            panelComum12.Dock = DockStyle.Left;
            panelComum12.Padding = new Padding(6);
            panelComum12.Size = new Size(350, 230);
            lblTituloComum12.Dock = DockStyle.Top;
            lblTituloComum12.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloComum12.ForeColor = Color.FromArgb(180, 200, 255);
            lblTituloComum12.Padding = new Padding(4);
            lblTituloComum12.Size = new Size(338, 26);
            lblTituloComum12.Text = "🔗 Pares com 12 números em comum";
            dgvComum12.AllowUserToAddRows = false;
            dgvComum12.AllowUserToDeleteRows = false;
            dgvComum12.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvComum12.BorderStyle = BorderStyle.None;
            dgvComum12.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 8F, FontStyle.Bold) };
            dgvComum12.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 9F) };
            dgvComum12.Dock = DockStyle.Fill;
            dgvComum12.EnableHeadersVisualStyles = false;
            dgvComum12.GridColor = Color.FromArgb(70, 80, 95);
            dgvComum12.ReadOnly = true;
            dgvComum12.RowHeadersVisible = false;
            dgvComum12.RowTemplate.Height = 24;

            // panelComum13
            panelComum13.BackColor = Color.FromArgb(45, 55, 72);
            panelComum13.Controls.Add(dgvComum13);
            panelComum13.Controls.Add(lblTituloComum13);
            panelComum13.Dock = DockStyle.Left;
            panelComum13.Padding = new Padding(6);
            panelComum13.Size = new Size(350, 230);
            lblTituloComum13.Dock = DockStyle.Top;
            lblTituloComum13.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloComum13.ForeColor = Color.FromArgb(220, 180, 255);
            lblTituloComum13.Padding = new Padding(4);
            lblTituloComum13.Size = new Size(338, 26);
            lblTituloComum13.Text = "🔗 Pares com 13 números em comum";
            dgvComum13.AllowUserToAddRows = false;
            dgvComum13.AllowUserToDeleteRows = false;
            dgvComum13.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvComum13.BorderStyle = BorderStyle.None;
            dgvComum13.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 8F, FontStyle.Bold) };
            dgvComum13.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 9F) };
            dgvComum13.Dock = DockStyle.Fill;
            dgvComum13.EnableHeadersVisualStyles = false;
            dgvComum13.GridColor = Color.FromArgb(70, 80, 95);
            dgvComum13.ReadOnly = true;
            dgvComum13.RowHeadersVisible = false;
            dgvComum13.RowTemplate.Height = 24;

            // panelComum14
            panelComum14.BackColor = Color.FromArgb(45, 55, 72);
            panelComum14.Controls.Add(dgvComum14);
            panelComum14.Controls.Add(lblTituloComum14);
            panelComum14.Dock = DockStyle.Fill;
            panelComum14.Padding = new Padding(6);
            lblTituloComum14.Dock = DockStyle.Top;
            lblTituloComum14.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTituloComum14.ForeColor = Color.FromArgb(255, 180, 200);
            lblTituloComum14.Padding = new Padding(4);
            lblTituloComum14.Size = new Size(338, 26);
            lblTituloComum14.Text = "🔗 Pares com 14 números em comum";
            dgvComum14.AllowUserToAddRows = false;
            dgvComum14.AllowUserToDeleteRows = false;
            dgvComum14.BackgroundColor = Color.FromArgb(55, 65, 82);
            dgvComum14.BorderStyle = BorderStyle.None;
            dgvComum14.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(50, 55, 75), ForeColor = Color.FromArgb(160, 170, 200), Font = new Font("Segoe UI", 8F, FontStyle.Bold) };
            dgvComum14.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(55, 65, 82), ForeColor = Color.White, SelectionBackColor = Color.FromArgb(75, 85, 102), SelectionForeColor = Color.White, Font = new Font("Segoe UI", 9F) };
            dgvComum14.Dock = DockStyle.Fill;
            dgvComum14.EnableHeadersVisualStyles = false;
            dgvComum14.GridColor = Color.FromArgb(70, 80, 95);
            dgvComum14.ReadOnly = true;
            dgvComum14.RowHeadersVisible = false;
            dgvComum14.RowTemplate.Height = 24;

            // FormDashboardAdmin
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1050, 600);
            Controls.Add(panelGridsBottom);
            Controls.Add(panelGridsTop);
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
            panelGridsTop.ResumeLayout(false);
            panelMaisSairam.ResumeLayout(false);
            panelMenosSairam.ResumeLayout(false);
            panelUltimosSorteios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUltimosSorteios).EndInit();
            panelGridsBottom.ResumeLayout(false);
            panelComum12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComum12).EndInit();
            panelComum13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComum13).EndInit();
            panelComum14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvComum14).EndInit();
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
        private Panel panelGridsTop;
        private Panel panelMaisSairam;
        private Label lblTituloMaisSairam;
        private Controls.PieChartControl pieMaisSairam;
        private Panel panelMenosSairam;
        private Label lblTituloMenosSairam;
        private Controls.PieChartControl pieMenosSairam;
        private Panel panelUltimosSorteios;
        private Label lblTituloUltimosSorteios;
        private DataGridView dgvUltimosSorteios;
        private Panel panelGridsBottom;
        private Panel panelComum12;
        private Label lblTituloComum12;
        private DataGridView dgvComum12;
        private Panel panelComum13;
        private Label lblTituloComum13;
        private DataGridView dgvComum13;
        private Panel panelComum14;
        private Label lblTituloComum14;
        private DataGridView dgvComum14;
        private Label lblTitulo;
        private Label lblStatus;
    }
}
