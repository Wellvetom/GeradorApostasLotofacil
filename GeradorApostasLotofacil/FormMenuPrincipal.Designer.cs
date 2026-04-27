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
            btn_FormListarApostas = new Button();
            btn_FormIncluirAposta = new Button();
            btnFormLoginCadastro = new Button();
            btn_ImportarApostas = new Button();
            panel_principal.SuspendLayout();
            panel_menu.SuspendLayout();
            SuspendLayout();
            // 
            // btn_restaurar
            // 
            btn_restaurar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_restaurar.FlatAppearance.BorderColor = Color.White;
            btn_restaurar.FlatAppearance.BorderSize = 0;
            btn_restaurar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn_restaurar.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_restaurar.FlatStyle = FlatStyle.Flat;
            btn_restaurar.Image = (Image)resources.GetObject("btn_restaurar.Image");
            btn_restaurar.Location = new Point(1067, 3);
            btn_restaurar.Name = "btn_restaurar";
            btn_restaurar.Size = new Size(74, 54);
            btn_restaurar.TabIndex = 2;
            btn_restaurar.UseVisualStyleBackColor = true;
            btn_restaurar.Click += btn_restaurar_Click;
            // 
            // panel_principal
            // 
            panel_principal.BackColor = Color.Indigo;
            panel_principal.Controls.Add(label1);
            panel_principal.Controls.Add(btn_restaurar);
            panel_principal.Controls.Add(btn_maximizar);
            panel_principal.Controls.Add(btn_fechar);
            panel_principal.Dock = DockStyle.Top;
            panel_principal.Location = new Point(0, 0);
            panel_principal.Name = "panel_principal";
            panel_principal.Size = new Size(1300, 56);
            panel_principal.TabIndex = 0;
            panel_principal.MouseMove += panel_principal_MouseMove;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(330, 28);
            label1.TabIndex = 3;
            label1.Text = "Gerador de Apostas Lotofácil";
            // 
            // btn_maximizar
            // 
            btn_maximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_maximizar.FlatAppearance.BorderColor = Color.White;
            btn_maximizar.FlatAppearance.BorderSize = 0;
            btn_maximizar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn_maximizar.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_maximizar.FlatStyle = FlatStyle.Flat;
            btn_maximizar.Image = Properties.Resources.fullscreen;
            btn_maximizar.Location = new Point(1147, 0);
            btn_maximizar.Name = "btn_maximizar";
            btn_maximizar.Size = new Size(75, 54);
            btn_maximizar.TabIndex = 1;
            btn_maximizar.UseVisualStyleBackColor = true;
            btn_maximizar.Click += btn_maximizar_Click;
            // 
            // btn_fechar
            // 
            btn_fechar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btn_fechar.FlatAppearance.BorderColor = Color.White;
            btn_fechar.FlatAppearance.BorderSize = 0;
            btn_fechar.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
            btn_fechar.FlatAppearance.MouseOverBackColor = Color.Red;
            btn_fechar.FlatStyle = FlatStyle.Flat;
            btn_fechar.Image = (Image)resources.GetObject("btn_fechar.Image");
            btn_fechar.Location = new Point(1228, 0);
            btn_fechar.Name = "btn_fechar";
            btn_fechar.Size = new Size(72, 54);
            btn_fechar.TabIndex = 0;
            btn_fechar.UseVisualStyleBackColor = true;
            btn_fechar.Click += btn_fechar_Click;
            // 
            // panel_formularios
            // 
            panel_formularios.BackColor = Color.DarkSlateBlue;
            panel_formularios.Dock = DockStyle.Fill;
            panel_formularios.Location = new Point(250, 56);
            panel_formularios.Name = "panel_formularios";
            panel_formularios.Size = new Size(1050, 544);
            panel_formularios.TabIndex = 2;
            // 
            // panel_menu
            // 
            panel_menu.AllowDrop = true;
            panel_menu.BackColor = Color.FromArgb(37, 46, 59);
            panel_menu.Controls.Add(btn_ImportarApostas);
            panel_menu.Controls.Add(linklogoff);
            panel_menu.Controls.Add(btn_FormListarApostas);
            panel_menu.Controls.Add(btn_FormIncluirAposta);
            panel_menu.Controls.Add(btnFormLoginCadastro);
            panel_menu.Dock = DockStyle.Left;
            panel_menu.Location = new Point(0, 56);
            panel_menu.Name = "panel_menu";
            panel_menu.Size = new Size(250, 544);
            panel_menu.TabIndex = 1;
            // 
            // linklogoff
            // 
            linklogoff.AutoSize = true;
            linklogoff.Location = new Point(12, 515);
            linklogoff.Name = "linklogoff";
            linklogoff.Size = new Size(86, 20);
            linklogoff.TabIndex = 3;
            linklogoff.TabStop = true;
            linklogoff.Text = "deseja sair?";
            linklogoff.LinkClicked += linklogoff_LinkClicked;
            // 
            // btn_FormListarApostas
            // 
            btn_FormListarApostas.FlatAppearance.BorderColor = Color.White;
            btn_FormListarApostas.FlatAppearance.BorderSize = 0;
            btn_FormListarApostas.FlatAppearance.MouseDownBackColor = Color.White;
            btn_FormListarApostas.FlatAppearance.MouseOverBackColor = Color.Indigo;
            btn_FormListarApostas.FlatStyle = FlatStyle.Flat;
            btn_FormListarApostas.Font = new Font("Segoe UI", 15F);
            btn_FormListarApostas.ForeColor = SystemColors.ControlLightLight;
            btn_FormListarApostas.Image = (Image)resources.GetObject("btn_FormListarApostas.Image");
            btn_FormListarApostas.ImageAlign = ContentAlignment.MiddleLeft;
            btn_FormListarApostas.Location = new Point(3, 150);
            btn_FormListarApostas.Name = "btn_FormListarApostas";
            btn_FormListarApostas.Size = new Size(244, 69);
            btn_FormListarApostas.TabIndex = 2;
            btn_FormListarApostas.Text = "Listar Apostas";
            btn_FormListarApostas.UseVisualStyleBackColor = true;
            btn_FormListarApostas.Click += btn_FormListarApostas_Click;
            // 
            // btn_FormIncluirAposta
            // 
            btn_FormIncluirAposta.FlatAppearance.BorderColor = Color.White;
            btn_FormIncluirAposta.FlatAppearance.BorderSize = 0;
            btn_FormIncluirAposta.FlatAppearance.MouseDownBackColor = Color.White;
            btn_FormIncluirAposta.FlatAppearance.MouseOverBackColor = Color.Indigo;
            btn_FormIncluirAposta.FlatStyle = FlatStyle.Flat;
            btn_FormIncluirAposta.Font = new Font("Segoe UI", 15F);
            btn_FormIncluirAposta.ForeColor = SystemColors.ControlLightLight;
            btn_FormIncluirAposta.Image = (Image)resources.GetObject("btn_FormIncluirAposta.Image");
            btn_FormIncluirAposta.ImageAlign = ContentAlignment.MiddleLeft;
            btn_FormIncluirAposta.Location = new Point(3, 75);
            btn_FormIncluirAposta.Name = "btn_FormIncluirAposta";
            btn_FormIncluirAposta.Size = new Size(244, 69);
            btn_FormIncluirAposta.TabIndex = 1;
            btn_FormIncluirAposta.Text = "  Incluir Aposta";
            btn_FormIncluirAposta.UseVisualStyleBackColor = true;
            btn_FormIncluirAposta.Click += btn_incluirAposta_Click;
            // 
            // btnFormLoginCadastro
            // 
            btnFormLoginCadastro.FlatAppearance.BorderColor = Color.White;
            btnFormLoginCadastro.FlatAppearance.BorderSize = 0;
            btnFormLoginCadastro.FlatAppearance.MouseDownBackColor = Color.White;
            btnFormLoginCadastro.FlatAppearance.MouseOverBackColor = Color.Indigo;
            btnFormLoginCadastro.FlatStyle = FlatStyle.Flat;
            btnFormLoginCadastro.Font = new Font("Segoe UI", 15F);
            btnFormLoginCadastro.ForeColor = SystemColors.ControlLightLight;
            btnFormLoginCadastro.Image = (Image)resources.GetObject("btnFormLoginCadastro.Image");
            btnFormLoginCadastro.ImageAlign = ContentAlignment.MiddleLeft;
            btnFormLoginCadastro.Location = new Point(0, 0);
            btnFormLoginCadastro.Name = "btnFormLoginCadastro";
            btnFormLoginCadastro.Size = new Size(250, 69);
            btnFormLoginCadastro.TabIndex = 0;
            btnFormLoginCadastro.Text = "  Login\\Cadastro";
            btnFormLoginCadastro.UseVisualStyleBackColor = true;
            btnFormLoginCadastro.Click += btnFormLoginCadastro_Click;
            // 
            // btn_ImportarApostas
            // 
            btn_ImportarApostas.FlatAppearance.BorderColor = Color.White;
            btn_ImportarApostas.FlatAppearance.BorderSize = 0;
            btn_ImportarApostas.FlatAppearance.MouseDownBackColor = Color.White;
            btn_ImportarApostas.FlatAppearance.MouseOverBackColor = Color.Indigo;
            btn_ImportarApostas.FlatStyle = FlatStyle.Flat;
            btn_ImportarApostas.Font = new Font("Segoe UI", 15F);
            btn_ImportarApostas.ForeColor = SystemColors.ControlLightLight;
            btn_ImportarApostas.Image = (Image)resources.GetObject("btn_ImportarApostas.Image");
            btn_ImportarApostas.ImageAlign = ContentAlignment.MiddleLeft;
            btn_ImportarApostas.Location = new Point(3, 216);
            btn_ImportarApostas.Name = "btn_ImportarApostas";
            btn_ImportarApostas.Size = new Size(244, 69);
            btn_ImportarApostas.TabIndex = 4;
            btn_ImportarApostas.Text = "   Importar Apostas";
            btn_ImportarApostas.UseVisualStyleBackColor = true;
            btn_ImportarApostas.Click += btn_ImportarApostas_Click;
            // 
            // FormMenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 600);
            Controls.Add(panel_formularios);
            Controls.Add(panel_menu);
            Controls.Add(panel_principal);
            Name = "FormMenuPrincipal";
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
        private Button btnGerarApostas;
        private Button btn_FormListarApostas;
        private Button btn_FormIncluirAposta;
        private Panel panel_formularios;
        private Button btn_restaurar;
        private Button btnFormLoginCadastro;
        private LinkLabel linklogoff;
        private Button btn_ImportarApostas;
    }
}
