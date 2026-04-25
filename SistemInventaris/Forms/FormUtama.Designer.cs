// ============================================================
// FormUtama.Designer.cs - Layout form dashboard utama
// ============================================================
namespace SistemInventaris.Forms
{
    partial class FormUtama
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialLabel  lblWelcome;
        private System.Windows.Forms.DataGridView    dgvBarang;
        private System.Windows.Forms.Panel           panelBottom;
        private MaterialSkin.Controls.MaterialButton btnTambah;
        private MaterialSkin.Controls.MaterialButton btnEdit;
        private MaterialSkin.Controls.MaterialButton btnHapus;
        private MaterialSkin.Controls.MaterialButton btnRefresh;
        private MaterialSkin.Controls.MaterialButton btnPencarian;
        private MaterialSkin.Controls.MaterialButton btnLogout;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWelcome   = new MaterialSkin.Controls.MaterialLabel();
            this.dgvBarang    = new System.Windows.Forms.DataGridView();
            this.panelBottom  = new System.Windows.Forms.Panel();
            this.btnTambah    = new MaterialSkin.Controls.MaterialButton();
            this.btnEdit      = new MaterialSkin.Controls.MaterialButton();
            this.btnHapus     = new MaterialSkin.Controls.MaterialButton();
            this.btnRefresh   = new MaterialSkin.Controls.MaterialButton();
            this.btnPencarian = new MaterialSkin.Controls.MaterialButton();
            this.btnLogout    = new MaterialSkin.Controls.MaterialButton();

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.AutoSize   = false;
            this.lblWelcome.Depth      = 0;
            this.lblWelcome.Font       = new System.Drawing.Font("Roboto", 13F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.FontType   = MaterialSkin.MaterialSkinManager.fontType.H6;
            this.lblWelcome.Location   = new System.Drawing.Point(25, 75);
            this.lblWelcome.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblWelcome.Name       = "lblWelcome";
            this.lblWelcome.Size       = new System.Drawing.Size(950, 32);
            this.lblWelcome.TabIndex   = 0;
            this.lblWelcome.Text       = "Dashboard Inventaris Barang";

            // dgvBarang
            this.dgvBarang.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvBarang.BackgroundColor              = System.Drawing.Color.White;
            this.dgvBarang.BorderStyle                  = System.Windows.Forms.BorderStyle.None;
            this.dgvBarang.ColumnHeadersHeightSizeMode  = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBarang.Location                     = new System.Drawing.Point(25, 115);
            this.dgvBarang.Name                         = "dgvBarang";
            this.dgvBarang.RowHeadersVisible            = false;
            this.dgvBarang.SelectionMode                = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBarang.Size                         = new System.Drawing.Size(950, 390);
            this.dgvBarang.TabIndex                     = 1;

            // panelBottom
            this.panelBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Controls.Add(this.btnTambah);
            this.panelBottom.Controls.Add(this.btnEdit);
            this.panelBottom.Controls.Add(this.btnHapus);
            this.panelBottom.Controls.Add(this.btnRefresh);
            this.panelBottom.Controls.Add(this.btnPencarian);
            this.panelBottom.Controls.Add(this.btnLogout);
            this.panelBottom.Location = new System.Drawing.Point(25, 515);
            this.panelBottom.Name     = "panelBottom";
            this.panelBottom.Size     = new System.Drawing.Size(950, 55);
            this.panelBottom.TabIndex = 2;

            // btnTambah
            this.btnTambah.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnTambah.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnTambah.Depth        = 0;
            this.btnTambah.HighEmphasis = true;
            this.btnTambah.Icon         = null;
            this.btnTambah.Location     = new System.Drawing.Point(0, 8);
            this.btnTambah.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnTambah.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnTambah.Name         = "btnTambah";
            this.btnTambah.Size         = new System.Drawing.Size(110, 36);
            this.btnTambah.TabIndex     = 0;
            this.btnTambah.Text         = "Tambah";
            this.btnTambah.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click       += new System.EventHandler(this.btnTambah_Click);

            // btnEdit
            this.btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnEdit.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnEdit.Depth        = 0;
            this.btnEdit.HighEmphasis = true;
            this.btnEdit.Icon         = null;
            this.btnEdit.Location     = new System.Drawing.Point(122, 8);
            this.btnEdit.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnEdit.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnEdit.Name         = "btnEdit";
            this.btnEdit.Size         = new System.Drawing.Size(90, 36);
            this.btnEdit.TabIndex     = 1;
            this.btnEdit.Text         = "Edit";
            this.btnEdit.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click       += new System.EventHandler(this.btnEdit_Click);

            // btnHapus
            this.btnHapus.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnHapus.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnHapus.Depth        = 0;
            this.btnHapus.HighEmphasis = true;
            this.btnHapus.Icon         = null;
            this.btnHapus.Location     = new System.Drawing.Point(224, 8);
            this.btnHapus.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnHapus.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnHapus.Name         = "btnHapus";
            this.btnHapus.Size         = new System.Drawing.Size(100, 36);
            this.btnHapus.TabIndex     = 2;
            this.btnHapus.Text         = "Hapus";
            this.btnHapus.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnHapus.UseVisualStyleBackColor = true;
            this.btnHapus.Click       += new System.EventHandler(this.btnHapus_Click);

            // btnRefresh
            this.btnRefresh.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRefresh.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnRefresh.Depth        = 0;
            this.btnRefresh.HighEmphasis = false;
            this.btnRefresh.Icon         = null;
            this.btnRefresh.Location     = new System.Drawing.Point(336, 8);
            this.btnRefresh.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRefresh.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnRefresh.Name         = "btnRefresh";
            this.btnRefresh.Size         = new System.Drawing.Size(100, 36);
            this.btnRefresh.TabIndex     = 3;
            this.btnRefresh.Text         = "Refresh";
            this.btnRefresh.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click       += new System.EventHandler(this.btnRefresh_Click);

            // btnPencarian
            this.btnPencarian.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnPencarian.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnPencarian.Depth        = 0;
            this.btnPencarian.HighEmphasis = false;
            this.btnPencarian.Icon         = null;
            this.btnPencarian.Location     = new System.Drawing.Point(448, 8);
            this.btnPencarian.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnPencarian.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnPencarian.Name         = "btnPencarian";
            this.btnPencarian.Size         = new System.Drawing.Size(120, 36);
            this.btnPencarian.TabIndex     = 4;
            this.btnPencarian.Text         = "Pencarian";
            this.btnPencarian.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnPencarian.UseVisualStyleBackColor = true;
            this.btnPencarian.Click       += new System.EventHandler(this.btnPencarian_Click);

            // btnLogout
            this.btnLogout.Anchor       = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right));
            this.btnLogout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLogout.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLogout.Depth        = 0;
            this.btnLogout.HighEmphasis = false;
            this.btnLogout.Icon         = null;
            this.btnLogout.Location     = new System.Drawing.Point(848, 8);
            this.btnLogout.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLogout.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnLogout.Name         = "btnLogout";
            this.btnLogout.Size         = new System.Drawing.Size(100, 36);
            this.btnLogout.TabIndex     = 5;
            this.btnLogout.Text         = "Logout";
            this.btnLogout.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Text;
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click       += new System.EventHandler(this.btnLogout_Click);

            // FormUtama
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(1000, 620);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.dgvBarang);
            this.Controls.Add(this.panelBottom);
            this.Name            = "FormUtama";
            this.Padding         = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Sistem Inventaris Barang";
            this.Load           += new System.EventHandler(this.FormUtama_Load);
            this.FormClosing    += new System.Windows.Forms.FormClosingEventHandler(this.FormUtama_FormClosing);

            ((System.ComponentModel.ISupportInitialize)(this.dgvBarang)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.panelBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
