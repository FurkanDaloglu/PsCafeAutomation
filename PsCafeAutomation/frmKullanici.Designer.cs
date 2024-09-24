namespace PsCafeAutomation
{
	partial class frmKullanici
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullanici));
			txtKullaniciAdi = new TextBox();
			txtSifre = new TextBox();
			label1 = new Label();
			label2 = new Label();
			pictureBox1 = new PictureBox();
			btnGiris = new Button();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// txtKullaniciAdi
			// 
			txtKullaniciAdi.Location = new Point(44, 210);
			txtKullaniciAdi.Name = "txtKullaniciAdi";
			txtKullaniciAdi.Size = new Size(344, 27);
			txtKullaniciAdi.TabIndex = 0;
			// 
			// txtSifre
			// 
			txtSifre.Location = new Point(44, 292);
			txtSifre.Name = "txtSifre";
			txtSifre.Size = new Size(344, 27);
			txtSifre.TabIndex = 0;
			txtSifre.UseSystemPasswordChar = true;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label1.Location = new Point(44, 172);
			label1.Name = "label1";
			label1.Size = new Size(117, 25);
			label1.TabIndex = 1;
			label1.Text = "Kullanıcı Adı";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
			label2.Location = new Point(44, 258);
			label2.Name = "label2";
			label2.Size = new Size(50, 25);
			label2.TabIndex = 1;
			label2.Text = "Şifre";
			// 
			// pictureBox1
			// 
			pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
			pictureBox1.Location = new Point(104, 12);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(208, 145);
			pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
			pictureBox1.TabIndex = 2;
			pictureBox1.TabStop = false;
			// 
			// btnGiris
			// 
			btnGiris.BackColor = Color.FromArgb(0, 192, 0);
			btnGiris.Location = new Point(44, 365);
			btnGiris.Name = "btnGiris";
			btnGiris.Size = new Size(344, 59);
			btnGiris.TabIndex = 4;
			btnGiris.Text = "Giriş";
			btnGiris.UseVisualStyleBackColor = false;
			btnGiris.Click += btnGiris_Click;
			// 
			// frmKullanici
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.White;
			ClientSize = new Size(436, 507);
			Controls.Add(btnGiris);
			Controls.Add(pictureBox1);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(txtSifre);
			Controls.Add(txtKullaniciAdi);
			KeyPreview = true;
			Name = "frmKullanici";
			Opacity = 0.8D;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Kullanıcı İşlemleri";
			KeyDown += frmKullanici_KeyDown;
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtKullaniciAdi;
		private TextBox txtSifre;
		private Label label1;
		private Label label2;
		private PictureBox pictureBox1;
		private Button btnGiris;
	}
}