namespace GeradorApostasLotofacil
{
    partial class FormCadastro
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
            panelCard = new Panel();
            label4 = new Label();
            label1 = new Label();
            txtbox_usuario = new TextBox();
            label3 = new Label();
            maskedtxtbox_senha = new MaskedTextBox();
            label2 = new Label();
            txtbox_Email = new MaskedTextBox();
            lblPerfil = new Label();
            cmbBox_Perfil = new ComboBox();
            btn_Cadastrar = new Button();
            panelCard.SuspendLayout();
            SuspendLayout();
            // 
            // panelCard
            // 
            panelCard.BackColor = Color.FromArgb(37, 38, 54);
            panelCard.Controls.Add(label4);
            panelCard.Controls.Add(label1);
            panelCard.Controls.Add(txtbox_usuario);
            panelCard.Controls.Add(label3);
            panelCard.Controls.Add(maskedtxtbox_senha);
            panelCard.Controls.Add(label2);
            panelCard.Controls.Add(txtbox_Email);
            panelCard.Controls.Add(lblPerfil);
            panelCard.Controls.Add(cmbBox_Perfil);
            panelCard.Controls.Add(btn_Cadastrar);
            panelCard.Location = new Point(200, 60);
            panelCard.Name = "panelCard";
            panelCard.Padding = new Padding(30);
            panelCard.Size = new Size(500, 380);
            panelCard.Anchor = AnchorStyles.None;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label4.ForeColor = Color.White;
            label4.Location = new Point(30, 20);
            label4.Name = "label4";
            label4.Size = new Size(440, 40);
            label4.Text = "📝 Cadastrar Usuário";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(180, 180, 200);
            label1.Location = new Point(35, 80);
            label1.Name = "label1";
            label1.Text = "Usuário";
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.BackColor = Color.FromArgb(55, 65, 82);
            txtbox_usuario.BorderStyle = BorderStyle.FixedSingle;
            txtbox_usuario.Font = new Font("Segoe UI", 11F);
            txtbox_usuario.ForeColor = Color.White;
            txtbox_usuario.Location = new Point(35, 105);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.Size = new Size(430, 32);
            txtbox_usuario.PlaceholderText = "Digite seu nome de usuário";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(180, 180, 200);
            label3.Location = new Point(35, 150);
            label3.Name = "label3";
            label3.Text = "Senha";
            // 
            // maskedtxtbox_senha
            // 
            maskedtxtbox_senha.BackColor = Color.FromArgb(55, 65, 82);
            maskedtxtbox_senha.BorderStyle = BorderStyle.FixedSingle;
            maskedtxtbox_senha.Font = new Font("Segoe UI", 11F);
            maskedtxtbox_senha.ForeColor = Color.White;
            maskedtxtbox_senha.Location = new Point(35, 175);
            maskedtxtbox_senha.Name = "maskedtxtbox_senha";
            maskedtxtbox_senha.PasswordChar = '●';
            maskedtxtbox_senha.Size = new Size(430, 32);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(180, 180, 200);
            label2.Location = new Point(35, 220);
            label2.Name = "label2";
            label2.Text = "E-mail";
            // 
            // txtbox_Email
            // 
            txtbox_Email.BackColor = Color.FromArgb(55, 65, 82);
            txtbox_Email.BorderStyle = BorderStyle.FixedSingle;
            txtbox_Email.Font = new Font("Segoe UI", 11F);
            txtbox_Email.ForeColor = Color.White;
            txtbox_Email.Location = new Point(35, 245);
            txtbox_Email.Name = "txtbox_Email";
            txtbox_Email.Size = new Size(430, 32);
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPerfil.ForeColor = Color.FromArgb(180, 180, 200);
            lblPerfil.Location = new Point(35, 290);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Text = "Perfil";
            // 
            // cmbBox_Perfil
            // 
            cmbBox_Perfil.BackColor = Color.FromArgb(55, 65, 82);
            cmbBox_Perfil.ForeColor = Color.White;
            cmbBox_Perfil.FlatStyle = FlatStyle.Flat;
            cmbBox_Perfil.Font = new Font("Segoe UI", 11F);
            cmbBox_Perfil.FormattingEnabled = true;
            cmbBox_Perfil.Items.AddRange(new object[] { "Usuario", "Administrador", "Admin" });
            cmbBox_Perfil.Location = new Point(35, 315);
            cmbBox_Perfil.Name = "cmbBox_Perfil";
            cmbBox_Perfil.Size = new Size(210, 33);
            cmbBox_Perfil.DropDownStyle = ComboBoxStyle.DropDownList;
            // 
            // btn_Cadastrar
            // 
            btn_Cadastrar.BackColor = Color.FromArgb(63, 81, 181);
            btn_Cadastrar.FlatAppearance.BorderSize = 0;
            btn_Cadastrar.FlatStyle = FlatStyle.Flat;
            btn_Cadastrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn_Cadastrar.ForeColor = Color.White;
            btn_Cadastrar.Location = new Point(265, 310);
            btn_Cadastrar.Name = "btn_Cadastrar";
            btn_Cadastrar.Size = new Size(200, 40);
            btn_Cadastrar.Text = "✅ Cadastrar";
            btn_Cadastrar.Cursor = Cursors.Hand;
            btn_Cadastrar.Click += btn_Cadastrar_Click;
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(988, 450);
            Controls.Add(panelCard);
            Name = "FormCadastro";
            Text = "FormCadastro";
            panelCard.ResumeLayout(false);
            panelCard.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelCard;
        private MaskedTextBox txtbox_Email;
        private Label label2;
        private TextBox txtbox_usuario;
        private Label label1;
        private Button btn_Cadastrar;
        private MaskedTextBox maskedtxtbox_senha;
        private Label label3;
        private Label lblPerfil;
        private ComboBox cmbBox_Perfil;
        private Label label4;
    }
}
