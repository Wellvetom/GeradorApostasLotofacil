namespace GeradorApostasLotofacil
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Login = new Button();
            label1 = new Label();
            txtbox_usuario = new TextBox();
            label2 = new Label();
            txtbox_senha = new MaskedTextBox();
            linkLbl_nao_possui_cadastro = new LinkLabel();
            label3 = new Label();
            SuspendLayout();
            // 
            // label3 (Título)
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(370, 80);
            label3.Name = "label3";
            label3.Size = new Size(140, 37);
            label3.TabIndex = 10;
            label3.Text = "\U0001f510 Login";
            label3.Anchor = AnchorStyles.Top;
            // 
            // label1 (Usuário)
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(300, 160);
            label1.Name = "label1";
            label1.Size = new Size(80, 25);
            label1.TabIndex = 4;
            label1.Text = "Usuário:";
            label1.Anchor = AnchorStyles.Top;
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.BackColor = Color.FromArgb(55, 65, 82);
            txtbox_usuario.BorderStyle = BorderStyle.FixedSingle;
            txtbox_usuario.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_usuario.ForeColor = Color.White;
            txtbox_usuario.Location = new Point(300, 190);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.Size = new Size(280, 32);
            txtbox_usuario.TabIndex = 5;
            txtbox_usuario.Anchor = AnchorStyles.Top;
            // 
            // label2 (Senha)
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(300, 240);
            label2.Name = "label2";
            label2.Size = new Size(65, 25);
            label2.TabIndex = 6;
            label2.Text = "Senha:";
            label2.Anchor = AnchorStyles.Top;
            // 
            // txtbox_senha
            // 
            txtbox_senha.BackColor = Color.FromArgb(55, 65, 82);
            txtbox_senha.BorderStyle = BorderStyle.FixedSingle;
            txtbox_senha.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtbox_senha.ForeColor = Color.White;
            txtbox_senha.Location = new Point(300, 270);
            txtbox_senha.Name = "txtbox_senha";
            txtbox_senha.PasswordChar = '*';
            txtbox_senha.Size = new Size(280, 32);
            txtbox_senha.TabIndex = 8;
            txtbox_senha.Anchor = AnchorStyles.Top;
            // 
            // btn_Login
            // 
            btn_Login.BackColor = Color.FromArgb(63, 81, 181);
            btn_Login.FlatAppearance.BorderSize = 0;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_Login.ForeColor = Color.White;
            btn_Login.Location = new Point(300, 330);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(280, 45);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Entrar";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Cursor = Cursors.Hand;
            btn_Login.Anchor = AnchorStyles.Top;
            btn_Login.Click += btn_Login_Click;
            // 
            // linkLbl_nao_possui_cadastro
            // 
            linkLbl_nao_possui_cadastro.AutoSize = true;
            linkLbl_nao_possui_cadastro.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLbl_nao_possui_cadastro.LinkColor = Color.FromArgb(100, 150, 255);
            linkLbl_nao_possui_cadastro.ActiveLinkColor = Color.FromArgb(150, 180, 255);
            linkLbl_nao_possui_cadastro.VisitedLinkColor = Color.FromArgb(100, 150, 255);
            linkLbl_nao_possui_cadastro.Location = new Point(350, 390);
            linkLbl_nao_possui_cadastro.Name = "linkLbl_nao_possui_cadastro";
            linkLbl_nao_possui_cadastro.Size = new Size(170, 23);
            linkLbl_nao_possui_cadastro.TabIndex = 9;
            linkLbl_nao_possui_cadastro.TabStop = true;
            linkLbl_nao_possui_cadastro.Text = "Não possui cadastro?";
            linkLbl_nao_possui_cadastro.Anchor = AnchorStyles.Top;
            linkLbl_nao_possui_cadastro.LinkClicked += linkLbl_nao_possui_cadastro_LinkClicked;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(924, 494);
            Controls.Add(label3);
            Controls.Add(linkLbl_nao_possui_cadastro);
            Controls.Add(txtbox_senha);
            Controls.Add(label2);
            Controls.Add(txtbox_usuario);
            Controls.Add(label1);
            Controls.Add(btn_Login);
            Name = "FormLogin";
            Text = "LoginCadastroForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_Login;
        private Label label1;
        private TextBox txtbox_usuario;
        private Label label2;
        private MaskedTextBox txtbox_senha;
        private LinkLabel linkLbl_nao_possui_cadastro;
        private Label label3;
    }
}
