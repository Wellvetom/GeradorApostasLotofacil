namespace GeradorApostasLotofacil
{
    partial class FormMenuPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenuPrincipal));
            btn_restaurar = new Button();
            panel_principal = new Panel();
            label1 = new Label();
            btn_maximizar = new Button();
            btn_fechar = new Button();
            panel_formularios = new Panel();
            panel_menu = new Panel();
            linklogoff = new LinkLabel();
            btn_Dashboard = new Button();
            btn_DashboardAdmin = new Button();
            btn_ImportarApostas = new Button();
            btn_FormListarApostas = new Button();
            btn_FormVerificarAposta = new Button();
            btn_FormIncluirAposta = new Button();
            btnFormLoginCadastro = new Button();
            panel_principal.SuspendLayout();
            panel_menu.SuspendLayout();
            SuspendLayout();
            // 
            // panel_principal (title bar)
            // 
            panel_principal.BackColor = Color.FromArgb(20, 20, 35);
            panel_principal.Controls.Add(label1);
            panel_principal.Controls.Add(btn_restaurar);
            panel_principal.Controls.Add(btn_maximizar);
            panel_principal.Controls.Add(btn_fechar);
            panel_principal.Dock = DockStyle.Top;
            panel_principal.Location = new Point(0, 0);
            panel_principal.Name = "panel_principal";
            panel_principal.Size = new Size(1300, 44);
            panel_principal.TabIndex = 0;
            panel_principal.MouseMove += panel_principal_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(14, 10);
            label1.Name = "label1";
            label1.Size = new Size(280, 25);
            label1.TabIndex = 3;
            label1.Text = "🎯 Gerador de Apostas Lotofácil";
            // 
            // btn_restaurar
            // 
            btn_restaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_restaurar.FlatAppearance.BorderSize = 0;
            btn_restaurar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 80);
            btn_restaurar.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 70);
            btn_restaurar.FlatStyle = FlatStyle.Flat;
            btn_restaurar.Font = new Font("Segoe UI", 10F);
            btn_restaurar.ForeColor = Color.White;
            btn_restaurar.Location = new Point(1167, 0);
            btn_restaurar.Name = "btn_restaurar";
            btn_restaurar.Size = new Size(44, 44);
            btn_restaurar.TabIndex = 2;
            btn_restaurar.Text = "◻";
            btn_restaurar.UseVisualStyleBackColor = false;
            btn_restaurar.BackColor = Color.FromArgb(20, 20, 35);
            btn_restaurar.Click += btn_restaurar_Click;
            // 
            // btn_maximizar
            // 
            btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_maximizar.FlatAppearance.BorderSize = 0;
            btn_maximizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 80);
            btn_maximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 70);
            btn_maximizar.FlatStyle = FlatStyle.Flat;
            btn_maximizar.Font = new Font("Segoe UI", 10F);
            btn_maximizar.ForeColor = Color.White;
            btn_maximizar.Location = new Point(1211, 0);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(44, 44);
            btn_maximizar.TabIndex = 1;
            btn_maximizar.Text = "▢";
            btn_maximizar.UseVisualStyleBackColor = false;
            btn_maximizar.BackColor = Color.FromArgb(20, 20, 35);
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_fechar
            // 
            btn_fechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_fechar.FlatAppearance.BorderSize = 0;
            btn_fechar.FlatAppearance.MouseDownBackColor = Color.FromArgb(200, 50, 50);
            btn_fechar.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 60, 60);
            btn_fechar.FlatStyle = FlatStyle.Flat;
            btn_fechar.Font = new Font("Segoe UI", 10F);
            btn_fechar.ForeColor = Color.White;
            btn_fechar.Location = new Point(1255, 0);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(44, 44);
            btn_fechar.TabIndex = 0;
            btn_fechar.Text = "✕";
            btn_fechar.UseVisualStyleBackColor = false;
            btn_fechar.BackColor = Color.FromArgb(20, 20, 35);
            btn_fechar.Click += btn_fechar_Click;
            // 
            // panel_formularios
            // 
            panel_formularios.BackColor = Color.FromArgb(30, 30, 46);
            panel_formularios.Dock = DockStyle.Fill;
            panel_formularios.Location = new Point(240, 44);
            panel_formularios.Name = "panel_formularios";
            panel_formularios.Size = new Size(1060, 556);
            panel_formularios.TabIndex = 2;
            // 
            // panel_menu
            // 
            panel_menu.BackColor = Color.FromArgb(25, 27, 40);
            panel_menu.Controls.Add(btn_DashboardAdmin);
            panel_menu.Controls.Add(btn_Dashboard);
            panel_menu.Controls.Add(btn_ImportarApostas);
            panel_menu.Controls.Add(linklogoff);
            panel_menu.Controls.Add(btn_FormVerificarAposta);
            panel_menu.Controls.Add(btn_FormListarApostas);
            panel_menu.Controls.Add(btn_FormIncluirAposta);
            panel_menu.Controls.Add(btnFormLoginCadastro);
            panel_menu.Dock = DockStyle.Left;
            panel_menu.Location = new Point(0, 44);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(240, 556);
            panel_menu.TabIndex = 1;
            // 
            // btnFormLoginCadastro
            // 
            btnFormLoginCadastro.Dock = DockStyle.Top;
            btnFormLoginCadastro.FlatAppearance.BorderSize = 0;
            btnFormLoginCadastro.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btnFormLoginCadastro.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btnFormLoginCadastro.FlatStyle = FlatStyle.Flat;
            btnFormLoginCadastro.Font = new Font("Segoe UI", 11F);
            btnFormLoginCadastro.ForeColor = Color.FromArgb(210, 210, 230);
            btnFormLoginCadastro.Location = new Point(0, 0);
            btnFormLoginCadastro.Name = "btnFormLoginCadastro";
            btnFormLoginCadastro.Padding = new Padding(15, 0, 0, 0);
            btnFormLoginCadastro.Size = new Size(240, 55);
            btnFormLoginCadastro.TabIndex = 0;
            btnFormLoginCadastro.Text = "🔐  Login / Cadastro";
            btnFormLoginCadastro.TextAlign = ContentAlignment.MiddleLeft;
            btnFormLoginCadastro.UseVisualStyleBackColor = false;
            btnFormLoginCadastro.BackColor = Color.FromArgb(25, 27, 40);
            btnFormLoginCadastro.Click += btnFormLoginCadastro_Click;
            // 
            // btn_FormIncluirAposta
            // 
            btn_FormIncluirAposta.Dock = DockStyle.Top;
            btn_FormIncluirAposta.FlatAppearance.BorderSize = 0;
            btn_FormIncluirAposta.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btn_FormIncluirAposta.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_FormIncluirAposta.FlatStyle = FlatStyle.Flat;
            btn_FormIncluirAposta.Font = new Font("Segoe UI", 11F);
            btn_FormIncluirAposta.ForeColor = Color.FromArgb(210, 210, 230);
            btn_FormIncluirAposta.Location = new Point(0, 55);
            btn_FormIncluirAposta.Name = "btn_FormIncluirAposta";
            btn_FormIncluirAposta.Padding = new Padding(15, 0, 0, 0);
            btn_FormIncluirAposta.Size = new Size(240, 55);
            btn_FormIncluirAposta.TabIndex = 1;
            btn_FormIncluirAposta.Text = "🎲  Incluir Aposta";
            btn_FormIncluirAposta.TextAlign = ContentAlignment.MiddleLeft;
            btn_FormIncluirAposta.UseVisualStyleBackColor = false;
            btn_FormIncluirAposta.BackColor = Color.FromArgb(25, 27, 40);
            btn_FormIncluirAposta.Click += btn_incluirAposta_Click;
            // 
            // btn_FormListarApostas
            // 
            btn_FormListarApostas.Dock = DockStyle.Top;
            btn_FormListarApostas.FlatAppearance.BorderSize = 0;
            btn_FormListarApostas.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btn_FormListarApostas.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_FormListarApostas.FlatStyle = FlatStyle.Flat;
            btn_FormListarApostas.Font = new Font("Segoe UI", 11F);
            btn_FormListarApostas.ForeColor = Color.FromArgb(210, 210, 230);
            btn_FormListarApostas.Location = new Point(0, 110);
            btn_FormListarApostas.Name = "btn_FormListarApostas";
            btn_FormListarApostas.Padding = new Padding(15, 0, 0, 0);
            btn_FormListarApostas.Size = new Size(240, 55);
            btn_FormListarApostas.TabIndex = 2;
            btn_FormListarApostas.Text = "📋  Listar Apostas";
            btn_FormListarApostas.TextAlign = ContentAlignment.MiddleLeft;
            btn_FormListarApostas.UseVisualStyleBackColor = false;
            btn_FormListarApostas.BackColor = Color.FromArgb(25, 27, 40);
            btn_FormListarApostas.Click += btn_FormListarApostas_Click;
            // 
            // btn_FormVerificarAposta
            // 
            btn_FormVerificarAposta.Dock = DockStyle.Top;
            btn_FormVerificarAposta.FlatAppearance.BorderSize = 0;
            btn_FormVerificarAposta.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btn_FormVerificarAposta.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_FormVerificarAposta.FlatStyle = FlatStyle.Flat;
            btn_FormVerificarAposta.Font = new Font("Segoe UI", 11F);
            btn_FormVerificarAposta.ForeColor = Color.FromArgb(210, 210, 230);
            btn_FormVerificarAposta.Location = new Point(0, 165);
            btn_FormVerificarAposta.Name = "btn_FormVerificarAposta";
            btn_FormVerificarAposta.Padding = new Padding(15, 0, 0, 0);
            btn_FormVerificarAposta.Size = new Size(240, 55);
            btn_FormVerificarAposta.TabIndex = 3;
            btn_FormVerificarAposta.Text = "🔎  Verificar Aposta";
            btn_FormVerificarAposta.TextAlign = ContentAlignment.MiddleLeft;
            btn_FormVerificarAposta.UseVisualStyleBackColor = false;
            btn_FormVerificarAposta.BackColor = Color.FromArgb(25, 27, 40);
            btn_FormVerificarAposta.Click += btn_FormVerificarAposta_Click;
            // 
            // btn_ImportarApostas
            // 
            btn_ImportarApostas.Dock = DockStyle.Top;
            btn_ImportarApostas.FlatAppearance.BorderSize = 0;
            btn_ImportarApostas.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btn_ImportarApostas.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_ImportarApostas.FlatStyle = FlatStyle.Flat;
            btn_ImportarApostas.Font = new Font("Segoe UI", 11F);
            btn_ImportarApostas.ForeColor = Color.FromArgb(210, 210, 230);
            btn_ImportarApostas.Location = new Point(0, 220);
            btn_ImportarApostas.Name = "btn_ImportarApostas";
            btn_ImportarApostas.Padding = new Padding(15, 0, 0, 0);
            btn_ImportarApostas.Size = new Size(240, 55);
            btn_ImportarApostas.TabIndex = 4;
            btn_ImportarApostas.Text = "📥  Importar Apostas";
            btn_ImportarApostas.TextAlign = ContentAlignment.MiddleLeft;
            btn_ImportarApostas.UseVisualStyleBackColor = false;
            btn_ImportarApostas.BackColor = Color.FromArgb(25, 27, 40);
            btn_ImportarApostas.Click += btn_ImportarApostas_Click;
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.Dock = DockStyle.Top;
            btn_Dashboard.FlatAppearance.BorderSize = 0;
            btn_Dashboard.FlatAppearance.MouseDownBackColor = Color.FromArgb(63, 81, 181);
            btn_Dashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_Dashboard.FlatStyle = FlatStyle.Flat;
            btn_Dashboard.Font = new Font("Segoe UI", 11F);
            btn_Dashboard.ForeColor = Color.FromArgb(210, 210, 230);
            btn_Dashboard.Location = new Point(0, 275);
            btn_Dashboard.Name = "btn_Dashboard";
            btn_Dashboard.Padding = new Padding(15, 0, 0, 0);
            btn_Dashboard.Size = new Size(240, 55);
            btn_Dashboard.TabIndex = 5;
            btn_Dashboard.Text = "📊  Dashboard";
            btn_Dashboard.TextAlign = ContentAlignment.MiddleLeft;
            btn_Dashboard.UseVisualStyleBackColor = false;
            btn_Dashboard.BackColor = Color.FromArgb(25, 27, 40);
            btn_Dashboard.Click += btn_Dashboard_Click;
            // 
            // btn_DashboardAdmin
            // 
            btn_DashboardAdmin.Dock = DockStyle.Top;
            btn_DashboardAdmin.FlatAppearance.BorderSize = 0;
            btn_DashboardAdmin.FlatAppearance.MouseDownBackColor = Color.FromArgb(183, 28, 28);
            btn_DashboardAdmin.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 44, 62);
            btn_DashboardAdmin.FlatStyle = FlatStyle.Flat;
            btn_DashboardAdmin.Font = new Font("Segoe UI", 11F);
            btn_DashboardAdmin.ForeColor = Color.FromArgb(255, 180, 180);
            btn_DashboardAdmin.Location = new Point(0, 330);
            btn_DashboardAdmin.Name = "btn_DashboardAdmin";
            btn_DashboardAdmin.Padding = new Padding(15, 0, 0, 0);
            btn_DashboardAdmin.Size = new Size(240, 55);
            btn_DashboardAdmin.TabIndex = 6;
            btn_DashboardAdmin.Text = "🛡️  Painel Admin";
            btn_DashboardAdmin.TextAlign = ContentAlignment.MiddleLeft;
            btn_DashboardAdmin.UseVisualStyleBackColor = false;
            btn_DashboardAdmin.BackColor = Color.FromArgb(25, 27, 40);
            btn_DashboardAdmin.Click += btn_DashboardAdmin_Click;
            // 
            // linklogoff
            // 
            linklogoff.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            linklogoff.AutoSize = true;
            linklogoff.Font = new Font("Segoe UI", 9F);
            linklogoff.LinkColor = Color.FromArgb(120, 140, 200);
            linklogoff.ActiveLinkColor = Color.FromArgb(160, 180, 240);
            linklogoff.Location = new Point(18, 525);
            linklogoff.Name = "linklogoff";
            linklogoff.Size = new Size(100, 20);
            linklogoff.TabIndex = 3;
            linklogoff.TabStop = true;
            linklogoff.Text = "🚪 Sair da conta";
            linklogoff.LinkClicked += linklogoff_LinkClicked;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1300, 600);
            Controls.Add(panel_formularios);
            Controls.Add(panel_menu);
            Controls.Add(panel_principal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Apostas Lotofacil";
            panel_principal.ResumeLayout(false);
            panel_principal.PerformLayout();
            panel_menu.ResumeLayout(false);
            panel_menu.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_principal;
        private Button btn_fechar;
        private Button btn_maximizar;
        private Label label1;
        private Panel panel_menu;
        private Button btn_FormListarApostas;
        private Button btn_FormVerificarAposta;
        private Button btn_FormIncluirAposta;
        private Panel panel_formularios;
        private Button btn_restaurar;
        private Button btnFormLoginCadastro;
        private LinkLabel linklogoff;
        private Button btn_ImportarApostas;
        private Button btn_Dashboard;
        private Button btn_DashboardAdmin;
    }
}
