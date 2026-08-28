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
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(15);
            panelTop.Size = new Size(948, 70);
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
            btnListasApostas.Location = new Point(620, 15);
            btnListasApostas.Name = "btnListasApostas";
            btnListasApostas.Size = new Size(150, 38);
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
            btn_exportarApostas.Location = new Point(785, 15);
            btn_exportarApostas.Name = "btn_exportarApostas";
            btn_exportarApostas.Size = new Size(145, 38);
            btn_exportarApostas.Text = "📥 Exportar CSV";
            btn_exportarApostas.Cursor = Cursors.Hand;
            btn_exportarApostas.Click += btn_exportarApostas_Click;
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
            dgv_listaApostas.Columns.AddRange(new DataGridViewColumn[] { colData, PrimeiroNumero, SegundoNumero, TerceiroNumero, QuartoNumero, QuintoNumero, SextoNumero, SetimoNumero, OitavoNumero, NonoNumero, DecimoNumero, DecimoPrimeiroNumero, DecimoSegundoNumero, DecimoTerceiroNumero, DecimoQuartoNumero, DecimoQuintoNumero, colAcertos });
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
            dgv_listaApostas.Location = new Point(0, 70);
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
    }
}
