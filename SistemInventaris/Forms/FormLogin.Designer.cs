// ============================================================
// FormLogin.Designer.cs - Layout form login
// ============================================================
using MaterialSkin.Controls;

namespace SistemInventaris.Forms
{
    partial class FormLogin
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialLabel lblTitle;
        private MaterialLabel lblSubtitle;
        private MaterialTextBox2 txtUsername;
        private MaterialTextBox2 txtPassword;
        private MaterialButton btnLogin;
        private MaterialButton btnKeluar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new MaterialLabel();
            this.lblSubtitle = new MaterialLabel();
            this.txtUsername = new MaterialTextBox2();
            this.txtPassword = new MaterialTextBox2();
            this.btnLogin = new MaterialButton();
            this.btnKeluar = new MaterialButton();

            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = false;
            this.lblTitle.Depth = 0;
            this.lblTitle.Font = new System.Drawing.Font("Roboto", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.FontType = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTitle.Location = new System.Drawing.Point(25, 75);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(400, 38);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SISTEM INVENTARIS BARANG";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblSubtitle
            this.lblSubtitle.AutoSize = false;
            this.lblSubtitle.Depth = 0;
            this.lblSubtitle.Font = new System.Drawing.Font("Roboto", 10F);
            this.lblSubtitle.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblSubtitle.Location = new System.Drawing.Point(25, 115);
            this.lblSubtitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(400, 24);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Silakan login untuk melanjutkan";
            this.lblSubtitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // txtUsername
            this.txtUsername.AnimateReadOnly = false;
            this.txtUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtUsername.Depth = 0;
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtUsername.Hint = "Username";
            this.txtUsername.LeadingIcon = null;
            this.txtUsername.Location = new System.Drawing.Point(75, 155);
            this.txtUsername.MaxLength = 50;
            this.txtUsername.MouseState = MaterialSkin.MouseState.OUT;
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 48);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Text = "";
            this.txtUsername.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsername_KeyPress);

            // txtPassword
            this.txtPassword.AnimateReadOnly = false;
            this.txtPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtPassword.Depth = 0;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtPassword.Hint = "Password";
            this.txtPassword.LeadingIcon = null;
            this.txtPassword.Location = new System.Drawing.Point(75, 215);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.MouseState = MaterialSkin.MouseState.OUT;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Size = new System.Drawing.Size(300, 48);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.Text = "";
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);

            // btnLogin
            this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogin.Density = MaterialButton.MaterialButtonDensity.Default;
            this.btnLogin.Depth = 0;
            this.btnLogin.HighEmphasis = true;
            this.btnLogin.Icon = null;
            this.btnLogin.Location = new System.Drawing.Point(75, 280);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLogin.Size = new System.Drawing.Size(300, 36);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.Type = MaterialButton.MaterialButtonType.Contained;
            this.btnLogin.UseAccentColor = true;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);

            // btnKeluar
            this.btnKeluar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnKeluar.Density = MaterialButton.MaterialButtonDensity.Default;
            this.btnKeluar.Depth = 0;
            this.btnKeluar.HighEmphasis = false;
            this.btnKeluar.Icon = null;
            this.btnKeluar.Location = new System.Drawing.Point(75, 328);
            this.btnKeluar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnKeluar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnKeluar.Name = "btnKeluar";
            this.btnKeluar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnKeluar.Size = new System.Drawing.Size(300, 36);
            this.btnKeluar.TabIndex = 5;
            this.btnKeluar.Text = "KELUAR";
            this.btnKeluar.Type = MaterialButton.MaterialButtonType.Outlined;
            this.btnKeluar.UseAccentColor = false;
            this.btnKeluar.UseVisualStyleBackColor = true;
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);

            // FormLogin
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 390);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSubtitle);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnKeluar);
            this.FormStyle = MaterialSkin.Controls.MaterialForm.FormStyles.ActionBar_None;
            this.MaximizeBox = false;
            this.Name = "FormLogin";
            this.Padding = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login - Sistem Inventaris";

            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
