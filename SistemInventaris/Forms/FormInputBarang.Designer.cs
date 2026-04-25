// ============================================================
// FormInputBarang.Designer.cs - Layout form input barang
// ============================================================
namespace SistemInventaris.Forms
{
    partial class FormInputBarang
    {
        private System.ComponentModel.IContainer components = null;

        private MaterialSkin.Controls.MaterialLabel    lblTitle;
        private MaterialSkin.Controls.MaterialTextBox2 txtKodeBarang;
        private MaterialSkin.Controls.MaterialTextBox2 txtNamaBarang;
        private MaterialSkin.Controls.MaterialComboBox cmbKategori;
        private MaterialSkin.Controls.MaterialTextBox2 txtStok;
        private MaterialSkin.Controls.MaterialTextBox2 txtHargaSatuan;
        private MaterialSkin.Controls.MaterialComboBox cmbSatuan;
        private MaterialSkin.Controls.MaterialButton   btnSimpan;
        private MaterialSkin.Controls.MaterialButton   btnBatal;
        private System.Windows.Forms.ErrorProvider     errorProvider1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components    = new System.ComponentModel.Container();
            this.lblTitle      = new MaterialSkin.Controls.MaterialLabel();
            this.txtKodeBarang = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtNamaBarang = new MaterialSkin.Controls.MaterialTextBox2();
            this.cmbKategori   = new MaterialSkin.Controls.MaterialComboBox();
            this.txtStok       = new MaterialSkin.Controls.MaterialTextBox2();
            this.txtHargaSatuan= new MaterialSkin.Controls.MaterialTextBox2();
            this.cmbSatuan     = new MaterialSkin.Controls.MaterialComboBox();
            this.btnSimpan     = new MaterialSkin.Controls.MaterialButton();
            this.btnBatal      = new MaterialSkin.Controls.MaterialButton();
            this.errorProvider1= new System.Windows.Forms.ErrorProvider(this.components);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize   = true;
            this.lblTitle.Depth      = 0;
            this.lblTitle.Font       = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.FontType   = MaterialSkin.MaterialSkinManager.fontType.H5;
            this.lblTitle.Location   = new System.Drawing.Point(30, 75);
            this.lblTitle.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblTitle.Name       = "lblTitle";
            this.lblTitle.TabIndex   = 0;
            this.lblTitle.Text       = "Tambah Barang";

            // txtKodeBarang
            this.txtKodeBarang.AnimateReadOnly       = false;
            this.txtKodeBarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtKodeBarang.Depth                 = 0;
            this.txtKodeBarang.Font                  = new System.Drawing.Font("Roboto", 11F);
            this.txtKodeBarang.Hint                  = "Kode Barang";
            this.txtKodeBarang.LeadingIcon           = null;
            this.txtKodeBarang.Location              = new System.Drawing.Point(30, 120);
            this.txtKodeBarang.MaxLength             = 20;
            this.txtKodeBarang.MouseState            = MaterialSkin.MouseState.OUT;
            this.txtKodeBarang.Name                  = "txtKodeBarang";
            this.txtKodeBarang.Size                  = new System.Drawing.Size(420, 48);
            this.txtKodeBarang.TabIndex              = 1;
            this.txtKodeBarang.Text                  = "";
            this.txtKodeBarang.Validating           += new System.ComponentModel.CancelEventHandler(this.txtKodeBarang_Validating);

            // txtNamaBarang
            this.txtNamaBarang.AnimateReadOnly       = false;
            this.txtNamaBarang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtNamaBarang.Depth                 = 0;
            this.txtNamaBarang.Font                  = new System.Drawing.Font("Roboto", 11F);
            this.txtNamaBarang.Hint                  = "Nama Barang";
            this.txtNamaBarang.LeadingIcon           = null;
            this.txtNamaBarang.Location              = new System.Drawing.Point(30, 178);
            this.txtNamaBarang.MaxLength             = 150;
            this.txtNamaBarang.MouseState            = MaterialSkin.MouseState.OUT;
            this.txtNamaBarang.Name                  = "txtNamaBarang";
            this.txtNamaBarang.Size                  = new System.Drawing.Size(420, 48);
            this.txtNamaBarang.TabIndex              = 2;
            this.txtNamaBarang.Text                  = "";
            this.txtNamaBarang.Validating           += new System.ComponentModel.CancelEventHandler(this.txtNamaBarang_Validating);

            // cmbKategori
            this.cmbKategori.AutoResize       = false;
            this.cmbKategori.Depth            = 0;
            this.cmbKategori.DrawMode         = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbKategori.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKategori.Font             = new System.Drawing.Font("Roboto", 11F);
            this.cmbKategori.FormattingEnabled= true;
            this.cmbKategori.Hint             = "Kategori";
            this.cmbKategori.IntegralHeight   = false;
            this.cmbKategori.ItemHeight       = 43;
            this.cmbKategori.Location         = new System.Drawing.Point(30, 236);
            this.cmbKategori.MouseState       = MaterialSkin.MouseState.OUT;
            this.cmbKategori.Name             = "cmbKategori";
            this.cmbKategori.Size             = new System.Drawing.Size(420, 49);
            this.cmbKategori.TabIndex         = 3;

            // txtStok
            this.txtStok.AnimateReadOnly       = false;
            this.txtStok.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtStok.Depth                 = 0;
            this.txtStok.Font                  = new System.Drawing.Font("Roboto", 11F);
            this.txtStok.Hint                  = "Stok";
            this.txtStok.LeadingIcon           = null;
            this.txtStok.Location              = new System.Drawing.Point(30, 298);
            this.txtStok.MaxLength             = 10;
            this.txtStok.MouseState            = MaterialSkin.MouseState.OUT;
            this.txtStok.Name                  = "txtStok";
            this.txtStok.Size                  = new System.Drawing.Size(200, 48);
            this.txtStok.TabIndex              = 4;
            this.txtStok.Text                  = "";
            this.txtStok.KeyPress             += new System.Windows.Forms.KeyPressEventHandler(this.txtStok_KeyPress);

            // txtHargaSatuan
            this.txtHargaSatuan.AnimateReadOnly       = false;
            this.txtHargaSatuan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.txtHargaSatuan.Depth                 = 0;
            this.txtHargaSatuan.Font                  = new System.Drawing.Font("Roboto", 11F);
            this.txtHargaSatuan.Hint                  = "Harga Satuan";
            this.txtHargaSatuan.LeadingIcon           = null;
            this.txtHargaSatuan.Location              = new System.Drawing.Point(250, 298);
            this.txtHargaSatuan.MaxLength             = 15;
            this.txtHargaSatuan.MouseState            = MaterialSkin.MouseState.OUT;
            this.txtHargaSatuan.Name                  = "txtHargaSatuan";
            this.txtHargaSatuan.Size                  = new System.Drawing.Size(200, 48);
            this.txtHargaSatuan.TabIndex              = 5;
            this.txtHargaSatuan.Text                  = "";
            this.txtHargaSatuan.KeyPress             += new System.Windows.Forms.KeyPressEventHandler(this.txtHargaSatuan_KeyPress);

            // cmbSatuan
            this.cmbSatuan.AutoResize       = false;
            this.cmbSatuan.Depth            = 0;
            this.cmbSatuan.DrawMode         = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSatuan.DropDownStyle    = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSatuan.Font             = new System.Drawing.Font("Roboto", 11F);
            this.cmbSatuan.FormattingEnabled= true;
            this.cmbSatuan.Hint             = "Satuan";
            this.cmbSatuan.IntegralHeight   = false;
            this.cmbSatuan.ItemHeight       = 43;
            this.cmbSatuan.Location         = new System.Drawing.Point(30, 360);
            this.cmbSatuan.MouseState       = MaterialSkin.MouseState.OUT;
            this.cmbSatuan.Name             = "cmbSatuan";
            this.cmbSatuan.Size             = new System.Drawing.Size(420, 49);
            this.cmbSatuan.TabIndex         = 6;

            // btnSimpan
            this.btnSimpan.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSimpan.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnSimpan.Depth        = 0;
            this.btnSimpan.HighEmphasis = true;
            this.btnSimpan.Icon         = null;
            this.btnSimpan.Location     = new System.Drawing.Point(30, 430);
            this.btnSimpan.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnSimpan.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnSimpan.Name         = "btnSimpan";
            this.btnSimpan.Size         = new System.Drawing.Size(200, 36);
            this.btnSimpan.TabIndex     = 7;
            this.btnSimpan.Text         = "SIMPAN";
            this.btnSimpan.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnSimpan.UseVisualStyleBackColor = true;
            this.btnSimpan.Click       += new System.EventHandler(this.btnSimpan_Click);

            // btnBatal
            this.btnBatal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnBatal.Density      = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnBatal.Depth        = 0;
            this.btnBatal.HighEmphasis = false;
            this.btnBatal.Icon         = null;
            this.btnBatal.Location     = new System.Drawing.Point(250, 430);
            this.btnBatal.Margin       = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnBatal.MouseState   = MaterialSkin.MouseState.HOVER;
            this.btnBatal.Name         = "btnBatal";
            this.btnBatal.Size         = new System.Drawing.Size(200, 36);
            this.btnBatal.TabIndex     = 8;
            this.btnBatal.Text         = "BATAL";
            this.btnBatal.Type         = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Outlined;
            this.btnBatal.UseVisualStyleBackColor = true;
            this.btnBatal.Click       += new System.EventHandler(this.btnBatal_Click);

            // errorProvider1
            this.errorProvider1.ContainerControl = this;

            // FormInputBarang
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize          = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtKodeBarang);
            this.Controls.Add(this.txtNamaBarang);
            this.Controls.Add(this.cmbKategori);
            this.Controls.Add(this.txtStok);
            this.Controls.Add(this.txtHargaSatuan);
            this.Controls.Add(this.cmbSatuan);
            this.Controls.Add(this.btnSimpan);
            this.Controls.Add(this.btnBatal);
            this.MaximizeBox     = false;
            this.Name            = "FormInputBarang";
            this.Padding         = new System.Windows.Forms.Padding(3, 64, 3, 3);
            this.StartPosition   = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text            = "Input Barang";
            this.Load           += new System.EventHandler(this.FormInputBarang_Load);

            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
