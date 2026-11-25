namespace AttendanceSystem.UI
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer? components = null;
        private System.Windows.Forms.TableLayoutPanel layoutPanel = null!;
        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.Label lblUsername = null!;
        private System.Windows.Forms.Label lblPassword = null!;
        private System.Windows.Forms.TextBox txtUsername = null!;
        private System.Windows.Forms.TextBox txtPassword = null!;
        private System.Windows.Forms.Button btnLogin = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            layoutPanel = new TableLayoutPanel();
            lblTitle = new Label();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            layoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // layoutPanel
            // 
            layoutPanel.ColumnCount = 1;
            layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutPanel.Controls.Add(lblTitle, 0, 0);
            layoutPanel.Controls.Add(lblUsername, 0, 1);
            layoutPanel.Controls.Add(txtUsername, 0, 2);
            layoutPanel.Controls.Add(lblPassword, 0, 3);
            layoutPanel.Controls.Add(txtPassword, 0, 4);
            layoutPanel.Controls.Add(btnLogin, 0, 5);
            layoutPanel.Dock = DockStyle.Fill;
            layoutPanel.Location = new Point(0, 0);
            layoutPanel.Name = "layoutPanel";
            layoutPanel.Padding = new Padding(44, 34, 44, 34);
            layoutPanel.RowCount = 6;
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 33F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 67F));
            layoutPanel.Size = new Size(420, 400);
            layoutPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(31, 55, 87);
            lblTitle.Location = new Point(47, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(326, 64);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ирц бүртгэлийн систем";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblUsername
            // 
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Location = new Point(47, 98);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(326, 26);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Хэрэглэгчийн нэр";
            lblUsername.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtUsername
            // 
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(47, 127);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(326, 25);
            txtUsername.TabIndex = 0;
            // 
            // lblPassword
            // 
            lblPassword.Dock = DockStyle.Fill;
            lblPassword.Location = new Point(47, 162);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(326, 34);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Нууц үг";
            lblPassword.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtPassword
            // 
            txtPassword.Dock = DockStyle.Fill;
            txtPassword.Location = new Point(47, 199);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '●';
            txtPassword.Size = new Size(326, 25);
            txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top;
            btnLogin.BackColor = Color.FromArgb(36, 104, 173);
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(120, 256);
            btnLogin.Margin = new Padding(0, 22, 0, 0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 42);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Нэвтрэх";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(420, 400);
            Controls.Add(layoutPanel);
            Font = new Font("Segoe UI", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Нэвтрэх";
            layoutPanel.ResumeLayout(false);
            layoutPanel.PerformLayout();
            ResumeLayout(false);
        }
    }
}