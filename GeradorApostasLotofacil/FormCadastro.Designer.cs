namespace GeradorApostasLotofacil
{
    partial class FormCadastro
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
            txtbox_Email = new MaskedTextBox();
            label2 = new Label();
            txtbox_usuario = new TextBox();
            label1 = new Label();
            btn_Cadastrar = new Button();
            maskedtxtbox_senha = new MaskedTextBox();
            label3 = new Label();
            lblPerfil = new Label();
            cmbBox_Perfil = new ComboBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtbox_Email
            // 
            txtbox_Email.Location = new Point(561, 94);
            txtbox_Email.Name = "txtbox_Email";
            txtbox_Email.Size = new Size(130, 27);
            txtbox_Email.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(486, 90);
            label2.Name = "label2";
            label2.Size = new Size(69, 28);
            label2.TabIndex = 12;
            label2.Text = "Email:";
            // 
            // txtbox_usuario
            // 
            txtbox_usuario.Location = new Point(112, 91);
            txtbox_usuario.Name = "txtbox_usuario";
            txtbox_usuario.Size = new Size(130, 27);
            txtbox_usuario.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(17, 87);
            label1.Name = "label1";
            label1.Size = new Size(89, 28);
            label1.TabIndex = 10;
            label1.Text = "Usuario:";
            // 
            // btn_Cadastrar
            // 
            btn_Cadastrar.BackColor = Color.RoyalBlue;
            btn_Cadastrar.FlatStyle = FlatStyle.Flat;
            btn_Cadastrar.Location = new Point(804, 149);
            btn_Cadastrar.Name = "btn_Cadastrar";
            btn_Cadastrar.Size = new Size(125, 43);
            btn_Cadastrar.TabIndex = 9;
            btn_Cadastrar.Text = "Cadastrar";
            btn_Cadastrar.UseVisualStyleBackColor = false;
            btn_Cadastrar.Click += btn_Cadastrar_Click;
            // 
            // maskedtxtbox_senha
            // 
            maskedtxtbox_senha.Location = new Point(337, 91);
            maskedtxtbox_senha.Name = "maskedtxtbox_senha";
            maskedtxtbox_senha.PasswordChar = '*';
            maskedtxtbox_senha.Size = new Size(130, 27);
            maskedtxtbox_senha.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(257, 87);
            label3.Name = "label3";
            label3.Size = new Size(74, 28);
            label3.TabIndex = 14;
            label3.Text = "Senha:";
            // 
            // lblPerfil
            // 
            lblPerfil.AutoSize = true;
            lblPerfil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPerfil.ForeColor = Color.White;
            lblPerfil.Location = new Point(710, 94);
            lblPerfil.Name = "lblPerfil";
            lblPerfil.Size = new Size(67, 28);
            lblPerfil.TabIndex = 16;
            lblPerfil.Text = "Perfil:";
            // 
            // cmbBox_Perfil
            // 
            cmbBox_Perfil.FormattingEnabled = true;
            cmbBox_Perfil.Items.AddRange(new object[] { "Usuario", "Administrador" });
            cmbBox_Perfil.Location = new Point(794, 96);
            cmbBox_Perfil.Name = "cmbBox_Perfil";
            cmbBox_Perfil.Size = new Size(151, 28);
            cmbBox_Perfil.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(17, 24);
            label4.Name = "label4";
            label4.Size = new Size(204, 31);
            label4.TabIndex = 18;
            label4.Text = "Cadastrar Usuario";
            // 
            // FormCadastro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSlateBlue;
            ClientSize = new Size(988, 450);
            Controls.Add(label4);
            Controls.Add(cmbBox_Perfil);
            Controls.Add(lblPerfil);
            Controls.Add(maskedtxtbox_senha);
            Controls.Add(label3);
            Controls.Add(txtbox_Email);
            Controls.Add(label2);
            Controls.Add(txtbox_usuario);
            Controls.Add(label1);
            Controls.Add(btn_Cadastrar);
            Name = "FormCadastro";
            Text = "FormCadastro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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