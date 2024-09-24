namespace PsCafeAutomation
{
	partial class Drinks
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
			txtIcecekAdi = new TextBox();
			label1 = new Label();
			label2 = new Label();
			txtFiyat = new TextBox();
			btnIcecekEkle = new Button();
			dataGridViewDrink = new DataGridView();
			IcecekIsmi = new DataGridViewTextBoxColumn();
			Fiyat = new DataGridViewTextBoxColumn();
			Sil = new DataGridViewButtonColumn();
			((System.ComponentModel.ISupportInitialize)dataGridViewDrink).BeginInit();
			SuspendLayout();
			// 
			// txtIcecekAdi
			// 
			txtIcecekAdi.Location = new Point(99, 42);
			txtIcecekAdi.Name = "txtIcecekAdi";
			txtIcecekAdi.Size = new Size(228, 27);
			txtIcecekAdi.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(18, 45);
			label1.Name = "label1";
			label1.Size = new Size(77, 20);
			label1.TabIndex = 1;
			label1.Text = "İçecek Adı";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(348, 45);
			label2.Name = "label2";
			label2.Size = new Size(44, 20);
			label2.TabIndex = 2;
			label2.Text = "Fiyatı";
			// 
			// txtFiyat
			// 
			txtFiyat.Location = new Point(411, 42);
			txtFiyat.Name = "txtFiyat";
			txtFiyat.Size = new Size(146, 27);
			txtFiyat.TabIndex = 3;
			txtFiyat.KeyPress += txtFiyat_KeyPress;
			// 
			// btnIcecekEkle
			// 
			btnIcecekEkle.Location = new Point(594, 42);
			btnIcecekEkle.Name = "btnIcecekEkle";
			btnIcecekEkle.Size = new Size(94, 30);
			btnIcecekEkle.TabIndex = 4;
			btnIcecekEkle.Text = "Ekle";
			btnIcecekEkle.UseVisualStyleBackColor = true;
			btnIcecekEkle.Click += btnIcecekEkle_Click;
			// 
			// dataGridViewDrink
			// 
			dataGridViewDrink.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewDrink.Columns.AddRange(new DataGridViewColumn[] { IcecekIsmi, Fiyat, Sil });
			dataGridViewDrink.Location = new Point(26, 107);
			dataGridViewDrink.Name = "dataGridViewDrink";
			dataGridViewDrink.RowHeadersWidth = 51;
			dataGridViewDrink.RowTemplate.Height = 29;
			dataGridViewDrink.Size = new Size(731, 367);
			dataGridViewDrink.TabIndex = 5;
			dataGridViewDrink.CellContentClick += dataGridViewDrink_CellContentClick;
			// 
			// IcecekIsmi
			// 
			IcecekIsmi.HeaderText = "İçecek Adı";
			IcecekIsmi.MinimumWidth = 6;
			IcecekIsmi.Name = "IcecekIsmi";
			IcecekIsmi.Width = 300;
			// 
			// Fiyat
			// 
			Fiyat.HeaderText = "Fiyat";
			Fiyat.MinimumWidth = 6;
			Fiyat.Name = "Fiyat";
			Fiyat.Width = 125;
			// 
			// Sil
			// 
			Sil.HeaderText = "Sil";
			Sil.MinimumWidth = 6;
			Sil.Name = "Sil";
			Sil.Width = 125;
			// 
			// Drinks
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(790, 486);
			Controls.Add(dataGridViewDrink);
			Controls.Add(btnIcecekEkle);
			Controls.Add(txtFiyat);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(txtIcecekAdi);
			Name = "Drinks";
			Text = "Drinks";
			FormClosed += Drinks_FormClosed;
			Load += Drinks_Load;
			((System.ComponentModel.ISupportInitialize)dataGridViewDrink).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox txtIcecekAdi;
		private Label label1;
		private Label label2;
		private TextBox txtFiyat;
		private Button btnIcecekEkle;
		private DataGridView dataGridViewDrink;
		private DataGridViewTextBoxColumn IcecekIsmi;
		private DataGridViewTextBoxColumn Fiyat;
		private DataGridViewButtonColumn Sil;
	}
}