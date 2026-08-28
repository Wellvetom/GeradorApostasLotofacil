namespace GeradorApostasLotofacil
{
    partial class FormListarApostas
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
            lblTitulo = new Label();
            btnListasApostas = new Button();
            btn_exportarApostas = new Button();
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
            colAcertos = new DataGridViewTextBoxColumn();
            colData = new DataGridViewTextBoxColumn();
            colResortear = new DataGridViewButtonColumn();
            colDuplicar = new DataGridViewButtonColumn();
            colExcluir = new DataGridViewButtonColumn();
            btn_exportarPdf = new Button();
            lblPeriodo = new Label();
            dtpDe = new DateTimePicker();
            lblAte = new Label();
            dtpAte = new DateTimePicker();
            panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(37, 38, 54);
            panelTop.Controls.Add(lblTitulo);
            panelTop.Controls.Add(btnListasApostas);
            panelTop.Controls.Add(btn_exportarApostas);
            panelTop.Controls.Add(btn_exportarPdf);
            panelTop.Controls.Add(lblPeriodo);
            panelTop.Controls.Add(dtpDe);
            panelTop.Controls.Add(lblAte);
            panelTop.Controls.Add(dtpAte);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(948, 115);
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(18, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Text = "📋 Minhas Apostas";
            // 
            // btnListasApostas
            // 
            btnListasApostas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnListasApostas.BackColor = Color.FromArgb(63, 81, 181);
            btnListasApostas.FlatAppearance.BorderSize = 0;
            btnListasApostas.FlatStyle = FlatStyle.Flat;
            btnListasApostas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnListasApostas.ForeColor = Color.White;
            btnListasApostas.Location = new Point(480, 15);
            btnListasApostas.Name = "btnListasApostas";
            btnListasApostas.Size = new Size(140, 38);
            btnListasApostas.Text = "🔄 Carregar";
            btnListasApostas.Cursor = Cursors.Hand;
            btnListasApostas.Click += btnListasApostas_Click;
            // 
            // btn_exportarApostas
            // 
            btn_exportarApostas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_exportarApostas.BackColor = Color.FromArgb(0, 150, 136);
            btn_exportarApostas.FlatAppearance.BorderSize = 0;
            btn_exportarApostas.FlatStyle = FlatStyle.Flat;
            btn_exportarApostas.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_exportarApostas.ForeColor = Color.White;
            btn_exportarApostas.Location = new Point(635, 15);
            btn_exportarApostas.Name = "btn_exportarApostas";
            btn_exportarApostas.Size = new Size(145, 38);
            btn_exportarApostas.Text = "📥 Exportar CSV";
            btn_exportarApostas.Cursor = Cursors.Hand;
            btn_exportarApostas.Click += btn_exportarApostas_Click;
            // 
            // btn_exportarPdf
            // 
            btn_exportarPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_exportarPdf.BackColor = Color.FromArgb(183, 28, 28);
            btn_exportarPdf.FlatAppearance.BorderSize = 0;
            btn_exportarPdf.FlatStyle = FlatStyle.Flat;
            btn_exportarPdf.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn_exportarPdf.ForeColor = Color.White;
            btn_exportarPdf.Location = new Point(795, 15);
            btn_exportarPdf.Name = "btn_exportarPdf";
            btn_exportarPdf.Size = new Size(138, 38);
            btn_exportarPdf.Text = "📄 Exportar PDF";
            btn_exportarPdf.Cursor = Cursors.Hand;
            btn_exportarPdf.Click += btn_exportarPdf_Click;
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPeriodo.ForeColor = Color.White;
            lblPeriodo.Location = new Point(18, 78);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Text = "Período:";
            // 
            // dtpDe
            // 
            dtpDe.Format = DateTimePickerFormat.Short;
            dtpDe.Location = new Point(100, 74);
            dtpDe.Name = "dtpDe";
            dtpDe.Size = new Size(130, 27);
            dtpDe.Value = DateTime.Now.AddDays(-30);
            dtpDe.CalendarMonthBackground = Color.FromArgb(55, 65, 82);
            dtpDe.CalendarForeColor = Color.White;
            // 
            // lblAte
            // 
            lblAte.AutoSize = true;
            lblAte.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAte.ForeColor = Color.White;
            lblAte.Location = new Point(240, 78);
            lblAte.Name = "lblAte";
            lblAte.Text = "até";
            // 
            // dtpAte
            // 
            dtpAte.Format = DateTimePickerFormat.Short;
            dtpAte.Location = new Point(275, 74);
            dtpAte.Name = "dtpAte";
            dtpAte.Size = new Size(130, 27);
            dtpAte.Value = DateTime.Now;
            dtpAte.CalendarMonthBackground = Color.FromArgb(55, 65, 82);
            dtpAte.CalendarForeColor = Color.White;
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
            dgv_listaApostas.Columns.AddRange(new DataGridViewColumn[] { colData, PrimeiroNumero, SegundoNumero, TerceiroNumero, QuartoNumero, QuintoNumero, SextoNumero, SetimoNumero, OitavoNumero, NonoNumero, DecimoNumero, DecimoPrimeiroNumero, DecimoSegundoNumero, DecimoTerceiroNumero, DecimoQuartoNumero, DecimoQuintoNumero, colAcertos, colResortear, colDuplicar, colExcluir });
            cellStyle.BackColor = Color.FromArgb(40, 42, 58);
            cellStyle.ForeColor = Color.White;
            cellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            cellStyle.SelectionBackColor = Color.FromArgb(63, 81, 181);
            cellStyle.SelectionForeColor = Color.White;
            cellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            cellStyle.Padding = new Padding(0, 5, 0, 5);
            dgv_listaApostas.DefaultCellStyle = cellStyle;
            dgv_listaApostas.Dock = DockStyle.Fill;
            dgv_listaApostas.EnableHeadersVisualStyles = false;
            dgv_listaApostas.GridColor = Color.FromArgb(55, 58, 78);
            dgv_listaApostas.Location = new Point(0, 115);
            dgv_listaApostas.Name = "dgv_listaApostas";
            dgv_listaApostas.ReadOnly = true;
            dgv_listaApostas.RowHeadersVisible = false;
            dgv_listaApostas.RowTemplate.Height = 40;
            dgv_listaApostas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_listaApostas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv_listaApostas.MultiSelect = false;
            dgv_listaApostas.ScrollBars = ScrollBars.Vertical;
            // 
            // colData
            // 
            colData.DataPropertyName = "DataInclusao";
            colData.HeaderText = "Data";
            colData.Name = "colData";
            colData.FillWeight = 80;
            // 
            // PrimeiroNumero
            // 
            PrimeiroNumero.DataPropertyName = "PrimeiroNumero";
            PrimeiroNumero.HeaderText = "1º";
            PrimeiroNumero.Name = "PrimeiroNumero";
            PrimeiroNumero.FillWeight = 45;
            // 
            // SegundoNumero
            // 
            SegundoNumero.DataPropertyName = "SegundoNumero";
            SegundoNumero.HeaderText = "2º";
            SegundoNumero.Name = "SegundoNumero";
            SegundoNumero.FillWeight = 45;
            // 
            // TerceiroNumero
            // 
            TerceiroNumero.DataPropertyName = "TerceiroNumero";
            TerceiroNumero.HeaderText = "3º";
            TerceiroNumero.Name = "TerceiroNumero";
            TerceiroNumero.FillWeight = 45;
            // 
            // QuartoNumero
            // 
            QuartoNumero.DataPropertyName = "QuartoNumero";
            QuartoNumero.HeaderText = "4º";
            QuartoNumero.Name = "QuartoNumero";
            QuartoNumero.FillWeight = 45;
            // 
            // QuintoNumero
            // 
            QuintoNumero.DataPropertyName = "QuintoNumero";
            QuintoNumero.HeaderText = "5º";
            QuintoNumero.Name = "QuintoNumero";
            QuintoNumero.FillWeight = 45;
            // 
            // SextoNumero
            // 
            SextoNumero.DataPropertyName = "SextoNumero";
            SextoNumero.HeaderText = "6º";
            SextoNumero.Name = "SextoNumero";
            SextoNumero.FillWeight = 45;
            // 
            // SetimoNumero
            // 
            SetimoNumero.DataPropertyName = "SetimoNumero";
            SetimoNumero.HeaderText = "7º";
            SetimoNumero.Name = "SetimoNumero";
            SetimoNumero.FillWeight = 45;
            // 
            // OitavoNumero
            // 
            OitavoNumero.DataPropertyName = "OitavoNumero";
            OitavoNumero.HeaderText = "8º";
            OitavoNumero.Name = "OitavoNumero";
            OitavoNumero.FillWeight = 45;
            // 
            // NonoNumero
            // 
            NonoNumero.DataPropertyName = "NonoNumero";
            NonoNumero.HeaderText = "9º";
            NonoNumero.Name = "NonoNumero";
            NonoNumero.FillWeight = 45;
            // 
            // DecimoNumero
            // 
            DecimoNumero.DataPropertyName = "DecimoNumero";
            DecimoNumero.HeaderText = "10º";
            DecimoNumero.Name = "DecimoNumero";
            DecimoNumero.FillWeight = 45;
            // 
            // DecimoPrimeiroNumero
            // 
            DecimoPrimeiroNumero.DataPropertyName = "DecimoPrimeiroNumero";
            DecimoPrimeiroNumero.HeaderText = "11º";
            DecimoPrimeiroNumero.Name = "DecimoPrimeiroNumero";
            DecimoPrimeiroNumero.FillWeight = 45;
            // 
            // DecimoSegundoNumero
            // 
            DecimoSegundoNumero.DataPropertyName = "DecimoSegundoNumero";
            DecimoSegundoNumero.HeaderText = "12º";
            DecimoSegundoNumero.Name = "DecimoSegundoNumero";
            DecimoSegundoNumero.FillWeight = 45;
            // 
            // DecimoTerceiroNumero
            // 
            DecimoTerceiroNumero.DataPropertyName = "DecimoTerceiroNumero";
            DecimoTerceiroNumero.HeaderText = "13º";
            DecimoTerceiroNumero.Name = "DecimoTerceiroNumero";
            DecimoTerceiroNumero.FillWeight = 45;
            // 
            // DecimoQuartoNumero
            // 
            DecimoQuartoNumero.DataPropertyName = "DecimoQuartoNumero";
            DecimoQuartoNumero.HeaderText = "14º";
            DecimoQuartoNumero.Name = "DecimoQuartoNumero";
            DecimoQuartoNumero.FillWeight = 45;
            // 
            // DecimoQuintoNumero
            // 
            DecimoQuintoNumero.DataPropertyName = "DecimoQuintoNumero";
            DecimoQuintoNumero.HeaderText = "15º";
            DecimoQuintoNumero.Name = "DecimoQuintoNumero";
            DecimoQuintoNumero.FillWeight = 45;
            // 
            // colAcertos
            // 
            colAcertos.DataPropertyName = "Acertos";
            colAcertos.HeaderText = "Acertos";
            colAcertos.Name = "colAcertos";
            colAcertos.FillWeight = 60;
            // 
            // colResortear
            // 
            colResortear.HeaderText = "";
            colResortear.Name = "colResortear";
            colResortear.Text = "🔄 Resortear";
            colResortear.UseColumnTextForButtonValue = true;
            colResortear.FillWeight = 90;
            colResortear.FlatStyle = FlatStyle.Flat;
            colResortear.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(63, 81, 181),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            // 
            // colDuplicar
            // 
            colDuplicar.HeaderText = "";
            colDuplicar.Name = "colDuplicar";
            colDuplicar.Text = "📋 Duplicar";
            colDuplicar.UseColumnTextForButtonValue = true;
            colDuplicar.FillWeight = 90;
            colDuplicar.FlatStyle = FlatStyle.Flat;
            colDuplicar.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(255, 152, 0),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(255, 152, 0),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            // 
            // colExcluir
            // 
            colExcluir.HeaderText = "";
            colExcluir.Name = "colExcluir";
            colExcluir.Text = "❌";
            colExcluir.UseColumnTextForButtonValue = true;
            colExcluir.FillWeight = 50;
            colExcluir.FlatStyle = FlatStyle.Flat;
            colExcluir.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(183, 28, 28),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                SelectionBackColor = Color.FromArgb(183, 28, 28),
                SelectionForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter
            };
            // 
            // FormListarApostas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(948, 525);
            Controls.Add(dgv_listaApostas);
            Controls.Add(panelTop);
            Name = "FormListarApostas";
            Text = "FormListarApostas";
            dgv_listaApostas.CellContentClick += dgv_listaApostas_CellContentClick;
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_listaApostas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private Label lblTitulo;
        private Button btnListasApostas;
        private DataGridView dgv_listaApostas;
        private Button btn_exportarApostas;
        private Button btn_exportarPdf;
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
        private DataGridViewTextBoxColumn colAcertos;
        private DataGridViewTextBoxColumn colData;
        private DataGridViewButtonColumn colResortear;
        private DataGridViewButtonColumn colDuplicar;
        private DataGridViewButtonColumn colExcluir;
        private Label lblPeriodo;
        private DateTimePicker dtpDe;
        private Label lblAte;
        private DateTimePicker dtpAte;
    }
}
