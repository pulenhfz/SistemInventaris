// ============================================================
// FormPencarian.Designer.cs - Layout form pencarian barang
// ============================================================
namespace SistemInventaris.Forms
{
    partial class FormPencarian
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialLabel    lblTitle;
        private MaterialSkin.Controls.MaterialTextBox2 txtCari;
        private MaterialSkin.Controls.MaterialComboBox cmbFilterKategori;
        private MaterialSkin.Controls.MaterialButton   btnCari;
        private MaterialSkin.Controls.MaterialButton   btnReset;
        private System.Windows.Forms.DataGridView      dgvHasil;
        private MaterialSkin.Controls.MaterialLabel    lblTotal;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle          = new MaterialSkin.Controls.MaterialLabel();
            this.txtCari           = new MaterialSkin.Controls.MaterialTextBox2();
            this.cmbFilterKategori = new MaterialSkin.Controls.MaterialComboBox();
            this.btnCari           = new MaterialSkin.Controls.MaterialButton();
            this.btnReset          = new MaterialSkin.Controls.MaterialButton();
            this.dgvHasil          = new System.Windows.Forms.DataGridView();
            this.lblTotal          = new MaterialSkin.Controls.MaterialLabel();

            ((System.ComponentModel.ISupportInitialize)(this.dgvHasil)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize   = true;
            this.lblTitle.Depth      = 0;
            this.lblTitle.Font       = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.FontType   = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTitle.Location   = new System.Drawing.Point(25, 75);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name       = "lblTitle";
            this.lblTitle.TabIndex   = 0;
            this.lblTitle.Text       = "Pencarian & Laporan Barang";

            // txtCari
            this.txtCari.AnimateReadOnly       = false;
            this.txtCari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtCari.Depth                 = 0;
            this.txtCari.Font                  = new System.Drawing.Font("Roboto", 11F);
            this.txtCari.Hint                  = "Cari nama / kode barang...";
            this.txtCari.LeadingIcon           = null;
            this.txtCari.Location              = new System.Drawing.Point(25, 118);
            this.txtCari.MaxLength             = 100;
            this.txtCari.MouseState            = MaterialSkin.MouseState.OUT;
            this.txtCari.Name                  = "txtCari";
            this.txtCari.Size                  = new System.Drawing.Size(310, 48);
            this.txtCari.TabIndex              = 1;
            this.txtCari.Text                  = "";
            this.txtCari.TextChanged          += new System.EventHandler(this.txtCari_TextChanged);

            // cmbFilterKategori
            this.cmbFilterKategori.AutoResize       = false;
            this.cmbFilterKategori.Depth            = 0;
            this.cmbFilterKategori.DrawMode         = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbFilterKategori.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilterKategori.Font             = new System.Drawing.Font("Roboto", 11F);
            this.cmbFilterKategori.FormattingEnabled= true;
            this.cmbFilterKategori.Hint             = "Filter Kategori";
            this.cmbFilterKategori.IntegralHeight   = false;
            this.cmbFilterKategori.ItemHeight       = 43;
            this.cmbFilterKategori.Location         = new System.Drawing.Point(350, 118);
            this.cmbFilterKategori.MouseState       = MaterialSkin.MouseState.OUT;
            this.cmbFilterKategori.Name             = "cmbFilterKategori";
            this.cmbFilterKategori.Size             = new System.Drawing.Size(220, 49);
            this.cmbFilterKategori.TabIndex         = 2;
            this.cmbFilterKategori.SelectedIndexChanged += new System.EventHandler(this.cmbFilterKategori_SelectedIndexChanged);

            // btnCari
            this.btnCari.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnCari.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnCari.Depth        = 0;
            this.btnCari.HighEmphasis = true;
            this.btnCari.Icon         = null;
            this.btnCari.Location     = new System.Drawing.Point(585, 126);
            this.btnCari.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCari.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnCari.Name         = "btnCari";
            this.btnCari.Size         = new System.Drawing.Size(90, 36);
            this.btnCari.TabIndex     = 3;
            this.btnCari.Text         = "Cari";
            this.btnCari.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click       += new System.EventHandler(this.btnCari_Click);

            // btnReset
            this.btnReset.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnReset.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnReset.Depth        = 0;
            this.btnReset.HighEmphasis = false;
            this.btnReset.Icon         = null;
            this.btnReset.Location     = new System.Drawing.Point(690, 126);
            this.btnReset.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReset.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name         = "btnReset";
            this.btnReset.Size         = new System.Drawing.Size(90, 36);
            this.btnReset.TabIndex     = 4;
            this.btnReset.Text         = "Reset";
            this.btnReset.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click       += new System.EventHandler(this.btnReset_Click);

            // dgvHasil
            this.dgvHasil.Anchor = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right));
            this.dgvHasil.BackgroundColor             = System.Drawing.Color.White;
            this.dgvHasil.BorderStyle                 = System.Windows.Forms.BorderStyle.None;
            this.dgvHasil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHasil.Location                    = new System.Drawing.Point(25, 180);
            this.dgvHasil.Name                        = "dgvHasil";
            this.dgvHasil.RowHeadersVisible           = false;
            this.dgvHasil.SelectionMode               = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHasil.Size                        = new System.Drawing.Size(800, 300);
            this.dgvHasil.TabIndex                    = 5;

            // lblTotal
            this.lblTotal.Anchor     = ((System.Windows.Forms.AnchorStyles)(
                System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
            this.lblTotal.AutoSize   = true;
            this.lblTotal.Depth      = 0;
            this.lblTotal.Font       = new System.Drawing.Font("Roboto", 10F);
            this.lblTotal.FontType   = MaterialSkin.MaterialSkinManager.fontType.Subtitle1;
            this.lblTotal.Location   = new System.Drawing.Point(25, 492);
            this.lblTotal.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTotal.Name       = "lblTotal";
            this.lblTotal.TabIndex   = 6;
            this.lblTotal.Text       = "Total: 0 barang ditemukan";

            // FormPencarian
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(850, 550);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtCari);
            this.Controls.Add(this.cmbFilterKategori);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.dgvHasil);
            this.Controls.Add(this.lblTotal);
            this.Name          = "FormPencarian";
            this.Padding       = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text          = "Pencarian & Laporan Barang";
            this.Load         += new System.EventHandler(this.FormPencarian_Load);

            ((System.ComponentModel.ISupportInitialize)(this.dgvHasil)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
