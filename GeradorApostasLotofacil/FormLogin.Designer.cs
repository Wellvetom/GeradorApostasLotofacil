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
            // btn_Login
            // 
            btn_Login.BackColor = Color.RoyalBlue;
            btn_Login.FlatStyle = FlatStyle.Flat;
            btn_Login.Location = new Point(504, 84);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(151, 43);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Logar";
            btn_Login.UseVisualStyleBackColor = false;
            btn_Login.Click += btn_Login_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(43, 89);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 4;
            label1.Text = "Usuario:";
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.Location = new Point(138, 92);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.Size = new Size(125, 27);
            txtbox_usuario.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(283, 91);
            label2.Name = "label2";
            label2.Size = new Size(74, 28);
            label2.TabIndex = 6;
            label2.Text = "Senha:";
            // 
            // txtbox_senha
            // 
            txtbox_senha.Location = new Point(363, 93);
            txtbox_senha.Name = "txtbox_senha";
            txtbox_senha.PasswordChar = '*';
            txtbox_senha.Size = new Size(125, 27);
            txtbox_senha.TabIndex = 8;
            // 
            // linkLbl_nao_possui_cadastro
            // 
            linkLbl_nao_possui_cadastro.AutoSize = true;
            linkLbl_nao_possui_cadastro.Location = new Point(504, 142);
            linkLbl_nao_possui_cadastro.Name = "linkLbl_nao_possui_cadastro";
            linkLbl_nao_possui_cadastro.Size = new Size(151, 20);
            linkLbl_nao_possui_cadastro.TabIndex = 9;
            linkLbl_nao_possui_cadastro.TabStop = true;
            linkLbl_nao_possui_cadastro.Text = "Não possui cadastro?";
            linkLbl_nao_possui_cadastro.LinkClicked += linkLbl_nao_possui_cadastro_LinkClicked;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(28, 33);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.No;
            label3.Size = new Size(196, 31);
            label3.TabIndex = 10;
            label3.Text = "Login de Usuario";
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
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