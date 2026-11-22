namespace GeradorApostasLotofacil
{
    partial class FormShell
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
            panel_principal = new Panel();
            label1 = new Label();
            btn_restaurar = new Button();
            btn_maximizar = new Button();
            btn_fechar = new Button();
            tabControl = new TabControl();
            panel_principal.SuspendLayout();
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
            label1.Text = "🎯 Gerador de Apostas";
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
            btn_restaurar.Visible = false;
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
            // tabControl
            // 
            tabControl.BackColor = Color.FromArgb(30, 30, 46);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            tabControl.Location = new Point(0, 44);
            tabControl.Name = "tabControl";
            tabControl.Padding = new Point(16, 6);
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1300, 556);
            tabControl.TabIndex = 1;
            // 
            // FormShell
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 46);
            ClientSize = new Size(1300, 600);
            Controls.Add(tabControl);
            Controls.Add(panel_principal);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormShell";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerador de Apostas";
            panel_principal.ResumeLayout(false);
            panel_principal.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel_principal;
        private Label label1;
        private Button btn_restaurar;
        private Button btn_maximizar;
        private Button btn_fechar;
        private TabControl tabControl;
    }
}
