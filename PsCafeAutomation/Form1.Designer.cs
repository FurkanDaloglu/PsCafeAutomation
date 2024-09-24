namespace PsCafeAutomation
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			btngreen = new Button();
			ımageList1 = new ImageList(components);
			btndark = new Button();
			btnblue = new Button();
			btnorange = new Button();
			btnyellow = new Button();
			btnamerican = new Button();
			btn3ball = new Button();
			listView1 = new ListView();
			HareketID = new ColumnHeader();
			Masa = new ColumnHeader();
			_Tutar = new ColumnHeader();
			Aciklama = new ColumnHeader();
			Tarih = new ColumnHeader();
			KullaniciID = new ColumnHeader();
			dataGridView1 = new DataGridView();
			ID = new DataGridViewTextBoxColumn();
			Masa_ID = new DataGridViewTextBoxColumn();
			_Masa = new DataGridViewTextBoxColumn();
			AcilisTuru = new DataGridViewTextBoxColumn();
			BaslamaSaati = new DataGridViewTextBoxColumn();
			BitisSaati = new DataGridViewTextBoxColumn();
			Sure = new DataGridViewTextBoxColumn();
			Tutar = new DataGridViewTextBoxColumn();
			_Tarih = new DataGridViewTextBoxColumn();
			Hesapla = new DataGridViewButtonColumn();
			MasaKapat = new DataGridViewButtonColumn();
			comboBosMasalar = new ComboBox();
			label1 = new Label();
			panel1 = new Panel();
			radioButton120 = new RadioButton();
			radioButton90 = new RadioButton();
			radioButton60 = new RadioButton();
			radioButton30 = new RadioButton();
			radioButton15 = new RadioButton();
			radioButtonSuresiz = new RadioButton();
			btnMasaAc = new Button();
			comboSaatUcreti = new ComboBox();
			label2 = new Label();
			timer1 = new System.Windows.Forms.Timer(components);
			comboBoxGünler = new ComboBox();
			label3 = new Label();
			label4 = new Label();
			txtCiro = new TextBox();
			label5 = new Label();
			comboBoxIcecek = new ComboBox();
			label6 = new Label();
			comboBoxIcecekMasa = new ComboBox();
			buttonIcecek = new Button();
			btnDrinks = new Button();
			((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// btngreen
			// 
			btngreen.Anchor = AnchorStyles.None;
			btngreen.BackColor = Color.FromArgb(128, 255, 128);
			btngreen.FlatStyle = FlatStyle.Flat;
			btngreen.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btngreen.ImageAlign = ContentAlignment.TopCenter;
			btngreen.ImageKey = "976605_appliances_console_controller_dualshock_gamepad_icon.png";
			btngreen.ImageList = ımageList1;
			btngreen.Location = new Point(28, 12);
			btngreen.Name = "btngreen";
			btngreen.Size = new Size(136, 109);
			btngreen.TabIndex = 0;
			btngreen.Text = "GREEN ZONE";
			btngreen.TextAlign = ContentAlignment.BottomCenter;
			btngreen.UseVisualStyleBackColor = false;
			btngreen.MouseDown += SecileneGore;
			// 
			// ımageList1
			// 
			ımageList1.ColorDepth = ColorDepth.Depth32Bit;
			ımageList1.ImageStream = (ImageListStreamer)resources.GetObject("ımageList1.ImageStream");
			ımageList1.TransparentColor = Color.Transparent;
			ımageList1.Images.SetKeyName(0, "976605_appliances_console_controller_dualshock_gamepad_icon.png");
			ımageList1.Images.SetKeyName(1, "4843016_ball_billiard_game_pool_sport_icon.png");
			ımageList1.Images.SetKeyName(2, "9517505_ball_billiard_championship_competition_play_icon.png");
			// 
			// btndark
			// 
			btndark.Anchor = AnchorStyles.None;
			btndark.BackColor = Color.Gray;
			btndark.FlatStyle = FlatStyle.Flat;
			btndark.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btndark.ImageAlign = ContentAlignment.TopCenter;
			btndark.ImageKey = "976605_appliances_console_controller_dualshock_gamepad_icon.png";
			btndark.ImageList = ımageList1;
			btndark.Location = new Point(216, 12);
			btndark.Name = "btndark";
			btndark.Size = new Size(136, 109);
			btndark.TabIndex = 0;
			btndark.Text = "DARK ZONE";
			btndark.TextAlign = ContentAlignment.BottomCenter;
			btndark.UseVisualStyleBackColor = false;
			btndark.MouseDown += SecileneGore;
			// 
			// btnblue
			// 
			btnblue.Anchor = AnchorStyles.None;
			btnblue.BackColor = Color.Cyan;
			btnblue.FlatStyle = FlatStyle.Flat;
			btnblue.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btnblue.ImageAlign = ContentAlignment.TopCenter;
			btnblue.ImageKey = "976605_appliances_console_controller_dualshock_gamepad_icon.png";
			btnblue.ImageList = ımageList1;
			btnblue.Location = new Point(401, 12);
			btnblue.Name = "btnblue";
			btnblue.Size = new Size(136, 109);
			btnblue.TabIndex = 0;
			btnblue.Text = "BLUE ZONE";
			btnblue.TextAlign = ContentAlignment.BottomCenter;
			btnblue.UseVisualStyleBackColor = false;
			btnblue.MouseDown += SecileneGore;
			// 
			// btnorange
			// 
			btnorange.Anchor = AnchorStyles.None;
			btnorange.BackColor = Color.FromArgb(255, 128, 0);
			btnorange.FlatStyle = FlatStyle.Flat;
			btnorange.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btnorange.ImageAlign = ContentAlignment.TopCenter;
			btnorange.ImageKey = "976605_appliances_console_controller_dualshock_gamepad_icon.png";
			btnorange.ImageList = ımageList1;
			btnorange.Location = new Point(578, 12);
			btnorange.Name = "btnorange";
			btnorange.Size = new Size(136, 109);
			btnorange.TabIndex = 0;
			btnorange.Text = "ORANGE ZONE";
			btnorange.TextAlign = ContentAlignment.BottomCenter;
			btnorange.UseVisualStyleBackColor = false;
			btnorange.MouseDown += SecileneGore;
			// 
			// btnyellow
			// 
			btnyellow.Anchor = AnchorStyles.None;
			btnyellow.BackColor = Color.FromArgb(255, 255, 128);
			btnyellow.FlatStyle = FlatStyle.Flat;
			btnyellow.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btnyellow.ImageAlign = ContentAlignment.TopCenter;
			btnyellow.ImageKey = "976605_appliances_console_controller_dualshock_gamepad_icon.png";
			btnyellow.ImageList = ımageList1;
			btnyellow.Location = new Point(752, 12);
			btnyellow.Name = "btnyellow";
			btnyellow.Size = new Size(136, 109);
			btnyellow.TabIndex = 0;
			btnyellow.Text = "YELLOW ZONE";
			btnyellow.TextAlign = ContentAlignment.BottomCenter;
			btnyellow.UseVisualStyleBackColor = false;
			btnyellow.MouseDown += SecileneGore;
			// 
			// btnamerican
			// 
			btnamerican.Anchor = AnchorStyles.None;
			btnamerican.FlatStyle = FlatStyle.Flat;
			btnamerican.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btnamerican.ImageAlign = ContentAlignment.TopCenter;
			btnamerican.ImageKey = "4843016_ball_billiard_game_pool_sport_icon.png";
			btnamerican.ImageList = ımageList1;
			btnamerican.Location = new Point(1014, 12);
			btnamerican.Name = "btnamerican";
			btnamerican.Size = new Size(136, 109);
			btnamerican.TabIndex = 0;
			btnamerican.Text = "AMERICAN B.";
			btnamerican.TextAlign = ContentAlignment.BottomCenter;
			btnamerican.UseVisualStyleBackColor = true;
			btnamerican.MouseDown += SecileneGore;
			// 
			// btn3ball
			// 
			btn3ball.Anchor = AnchorStyles.None;
			btn3ball.FlatStyle = FlatStyle.Flat;
			btn3ball.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			btn3ball.ImageAlign = ContentAlignment.TopCenter;
			btn3ball.ImageKey = "9517505_ball_billiard_championship_competition_play_icon.png";
			btn3ball.ImageList = ımageList1;
			btn3ball.Location = new Point(1190, 12);
			btn3ball.Name = "btn3ball";
			btn3ball.Size = new Size(136, 109);
			btn3ball.TabIndex = 0;
			btn3ball.Text = "3 BALLS B.";
			btn3ball.TextAlign = ContentAlignment.BottomCenter;
			btn3ball.UseVisualStyleBackColor = true;
			btn3ball.MouseDown += SecileneGore;
			// 
			// listView1
			// 
			listView1.Anchor = AnchorStyles.None;
			listView1.Columns.AddRange(new ColumnHeader[] { HareketID, Masa, _Tutar, Aciklama, Tarih, KullaniciID });
			listView1.Location = new Point(24, 139);
			listView1.Name = "listView1";
			listView1.Size = new Size(903, 202);
			listView1.TabIndex = 1;
			listView1.UseCompatibleStateImageBehavior = false;
			listView1.View = View.Details;
			// 
			// HareketID
			// 
			HareketID.Tag = "HareketID";
			HareketID.Text = "İstek ID";
			HareketID.Width = 100;
			// 
			// Masa
			// 
			Masa.Tag = "Masa";
			Masa.Text = "Masa";
			Masa.Width = 150;
			// 
			// _Tutar
			// 
			_Tutar.Tag = "_Tutar";
			_Tutar.Text = "Tutar";
			// 
			// Aciklama
			// 
			Aciklama.Tag = "Aciklama";
			Aciklama.Text = "Açıklama";
			Aciklama.Width = 150;
			// 
			// Tarih
			// 
			Tarih.Tag = "Tarih";
			Tarih.Text = "Tarih";
			Tarih.Width = 150;
			// 
			// KullaniciID
			// 
			KullaniciID.Tag = "KullaniciID";
			KullaniciID.Text = "Kullanıcı ID";
			KullaniciID.Width = 150;
			// 
			// dataGridView1
			// 
			dataGridView1.AllowUserToAddRows = false;
			dataGridView1.AllowUserToDeleteRows = false;
			dataGridView1.Anchor = AnchorStyles.None;
			dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ID, Masa_ID, _Masa, AcilisTuru, BaslamaSaati, BitisSaati, Sure, Tutar, _Tarih, Hesapla, MasaKapat });
			dataGridView1.Location = new Point(24, 419);
			dataGridView1.Name = "dataGridView1";
			dataGridView1.ReadOnly = true;
			dataGridView1.RowHeadersWidth = 51;
			dataGridView1.RowTemplate.Height = 29;
			dataGridView1.Size = new Size(903, 198);
			dataGridView1.TabIndex = 2;
			dataGridView1.CellClick += dataGridView1_CellClick;
			dataGridView1.CellFormatting += dataGridView1_CellFormatting;
			// 
			// ID
			// 
			ID.DataPropertyName = "SepetID";
			ID.HeaderText = "ID";
			ID.MinimumWidth = 6;
			ID.Name = "ID";
			ID.ReadOnly = true;
			// 
			// Masa_ID
			// 
			Masa_ID.DataPropertyName = "MasaID";
			Masa_ID.HeaderText = "Masa ID";
			Masa_ID.MinimumWidth = 6;
			Masa_ID.Name = "Masa_ID";
			Masa_ID.ReadOnly = true;
			// 
			// _Masa
			// 
			_Masa.DataPropertyName = "Masa";
			_Masa.HeaderText = "Masa";
			_Masa.MinimumWidth = 6;
			_Masa.Name = "_Masa";
			_Masa.ReadOnly = true;
			// 
			// AcilisTuru
			// 
			AcilisTuru.DataPropertyName = "AcilisTuru";
			AcilisTuru.HeaderText = "Açılış Türü";
			AcilisTuru.MinimumWidth = 6;
			AcilisTuru.Name = "AcilisTuru";
			AcilisTuru.ReadOnly = true;
			// 
			// BaslamaSaati
			// 
			BaslamaSaati.DataPropertyName = "Baslangic";
			BaslamaSaati.HeaderText = "Başlama Saati";
			BaslamaSaati.MinimumWidth = 6;
			BaslamaSaati.Name = "BaslamaSaati";
			BaslamaSaati.ReadOnly = true;
			// 
			// BitisSaati
			// 
			BitisSaati.DataPropertyName = "Bitis";
			BitisSaati.HeaderText = "Bitiş Saati";
			BitisSaati.MinimumWidth = 6;
			BitisSaati.Name = "BitisSaati";
			BitisSaati.ReadOnly = true;
			// 
			// Sure
			// 
			Sure.HeaderText = "Süre(Saat)";
			Sure.MinimumWidth = 6;
			Sure.Name = "Sure";
			Sure.ReadOnly = true;
			// 
			// Tutar
			// 
			Tutar.DataPropertyName = "_Tutar";
			Tutar.HeaderText = "Tutar";
			Tutar.MinimumWidth = 6;
			Tutar.Name = "Tutar";
			Tutar.ReadOnly = true;
			// 
			// _Tarih
			// 
			_Tarih.DataPropertyName = "Tarih";
			_Tarih.HeaderText = "Tarih";
			_Tarih.MinimumWidth = 6;
			_Tarih.Name = "_Tarih";
			_Tarih.ReadOnly = true;
			// 
			// Hesapla
			// 
			Hesapla.HeaderText = "Hesapla";
			Hesapla.MinimumWidth = 6;
			Hesapla.Name = "Hesapla";
			Hesapla.ReadOnly = true;
			Hesapla.Text = "Hesapla";
			Hesapla.ToolTipText = "Hesaplama Yapar";
			Hesapla.UseColumnTextForButtonValue = true;
			// 
			// MasaKapat
			// 
			MasaKapat.HeaderText = "Masa Kapat";
			MasaKapat.MinimumWidth = 6;
			MasaKapat.Name = "MasaKapat";
			MasaKapat.ReadOnly = true;
			MasaKapat.Text = "Masa Kapat";
			MasaKapat.ToolTipText = "Masayı Kapatır";
			MasaKapat.UseColumnTextForButtonValue = true;
			// 
			// comboBosMasalar
			// 
			comboBosMasalar.Anchor = AnchorStyles.None;
			comboBosMasalar.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBosMasalar.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			comboBosMasalar.FormattingEnabled = true;
			comboBosMasalar.Location = new Point(946, 248);
			comboBosMasalar.Name = "comboBosMasalar";
			comboBosMasalar.Size = new Size(168, 28);
			comboBosMasalar.TabIndex = 3;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label1.Location = new Point(950, 225);
			label1.Name = "label1";
			label1.Size = new Size(115, 20);
			label1.TabIndex = 4;
			label1.Text = "BOŞ MASALAR";
			// 
			// panel1
			// 
			panel1.Anchor = AnchorStyles.None;
			panel1.Controls.Add(radioButton120);
			panel1.Controls.Add(radioButton90);
			panel1.Controls.Add(radioButton60);
			panel1.Controls.Add(radioButton30);
			panel1.Controls.Add(radioButton15);
			panel1.Controls.Add(radioButtonSuresiz);
			panel1.Location = new Point(946, 323);
			panel1.Name = "panel1";
			panel1.Size = new Size(204, 113);
			panel1.TabIndex = 5;
			// 
			// radioButton120
			// 
			radioButton120.AutoSize = true;
			radioButton120.Location = new Point(122, 74);
			radioButton120.Name = "radioButton120";
			radioButton120.Size = new Size(54, 24);
			radioButton120.TabIndex = 1;
			radioButton120.TabStop = true;
			radioButton120.Text = "120";
			radioButton120.UseVisualStyleBackColor = true;
			radioButton120.CheckedChanged += RadioButtonSecili;
			// 
			// radioButton90
			// 
			radioButton90.AutoSize = true;
			radioButton90.Location = new Point(20, 74);
			radioButton90.Name = "radioButton90";
			radioButton90.Size = new Size(46, 24);
			radioButton90.TabIndex = 1;
			radioButton90.TabStop = true;
			radioButton90.Text = "60";
			radioButton90.UseVisualStyleBackColor = true;
			radioButton90.CheckedChanged += RadioButtonSecili;
			// 
			// radioButton60
			// 
			radioButton60.AutoSize = true;
			radioButton60.Location = new Point(122, 44);
			radioButton60.Name = "radioButton60";
			radioButton60.Size = new Size(46, 24);
			radioButton60.TabIndex = 1;
			radioButton60.TabStop = true;
			radioButton60.Text = "45";
			radioButton60.UseVisualStyleBackColor = true;
			radioButton60.CheckedChanged += RadioButtonSecili;
			// 
			// radioButton30
			// 
			radioButton30.AutoSize = true;
			radioButton30.Location = new Point(20, 44);
			radioButton30.Name = "radioButton30";
			radioButton30.Size = new Size(46, 24);
			radioButton30.TabIndex = 1;
			radioButton30.TabStop = true;
			radioButton30.Text = "30";
			radioButton30.UseVisualStyleBackColor = true;
			radioButton30.CheckedChanged += RadioButtonSecili;
			// 
			// radioButton15
			// 
			radioButton15.AutoSize = true;
			radioButton15.Location = new Point(122, 14);
			radioButton15.Name = "radioButton15";
			radioButton15.Size = new Size(46, 24);
			radioButton15.TabIndex = 0;
			radioButton15.TabStop = true;
			radioButton15.Text = "15";
			radioButton15.UseVisualStyleBackColor = true;
			radioButton15.CheckedChanged += RadioButtonSecili;
			// 
			// radioButtonSuresiz
			// 
			radioButtonSuresiz.AutoSize = true;
			radioButtonSuresiz.Location = new Point(20, 14);
			radioButtonSuresiz.Name = "radioButtonSuresiz";
			radioButtonSuresiz.Size = new Size(86, 24);
			radioButtonSuresiz.TabIndex = 0;
			radioButtonSuresiz.TabStop = true;
			radioButtonSuresiz.Text = "SÜRESİZ";
			radioButtonSuresiz.UseVisualStyleBackColor = true;
			radioButtonSuresiz.CheckedChanged += RadioButtonSecili;
			// 
			// btnMasaAc
			// 
			btnMasaAc.Anchor = AnchorStyles.None;
			btnMasaAc.BackColor = Color.FromArgb(0, 192, 192);
			btnMasaAc.Location = new Point(946, 534);
			btnMasaAc.Name = "btnMasaAc";
			btnMasaAc.Size = new Size(376, 83);
			btnMasaAc.TabIndex = 6;
			btnMasaAc.Text = "MASA AÇ";
			btnMasaAc.UseVisualStyleBackColor = false;
			btnMasaAc.Click += btnMasaAc_Click;
			// 
			// comboSaatUcreti
			// 
			comboSaatUcreti.Anchor = AnchorStyles.None;
			comboSaatUcreti.DropDownStyle = ComboBoxStyle.DropDownList;
			comboSaatUcreti.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			comboSaatUcreti.FormattingEnabled = true;
			comboSaatUcreti.Location = new Point(759, 385);
			comboSaatUcreti.Name = "comboSaatUcreti";
			comboSaatUcreti.Size = new Size(168, 28);
			comboSaatUcreti.TabIndex = 3;
			// 
			// label2
			// 
			label2.Anchor = AnchorStyles.None;
			label2.AutoSize = true;
			label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label2.Location = new Point(24, 367);
			label2.Name = "label2";
			label2.Size = new Size(69, 20);
			label2.TabIndex = 4;
			label2.Text = "GÜNLER";
			// 
			// comboBoxGünler
			// 
			comboBoxGünler.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxGünler.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			comboBoxGünler.FormattingEnabled = true;
			comboBoxGünler.Location = new Point(94, 367);
			comboBoxGünler.Name = "comboBoxGünler";
			comboBoxGünler.Size = new Size(278, 28);
			comboBoxGünler.TabIndex = 7;
			comboBoxGünler.SelectedIndexChanged += comboBoxGünler_SelectedIndexChanged;
			// 
			// label3
			// 
			label3.Anchor = AnchorStyles.None;
			label3.AutoSize = true;
			label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label3.Location = new Point(421, 367);
			label3.Name = "label3";
			label3.Size = new Size(144, 20);
			label3.TabIndex = 4;
			label3.Text = "TOPLAM KAZANÇ :";
			// 
			// label4
			// 
			label4.Anchor = AnchorStyles.None;
			label4.AutoSize = true;
			label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label4.Location = new Point(759, 353);
			label4.Name = "label4";
			label4.Size = new Size(121, 20);
			label4.TabIndex = 4;
			label4.Text = "SAATLİK ÜCRET";
			// 
			// txtCiro
			// 
			txtCiro.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			txtCiro.Location = new Point(554, 366);
			txtCiro.Name = "txtCiro";
			txtCiro.Size = new Size(160, 27);
			txtCiro.TabIndex = 8;
			// 
			// label5
			// 
			label5.Anchor = AnchorStyles.None;
			label5.AutoSize = true;
			label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label5.Location = new Point(1175, 216);
			label5.Name = "label5";
			label5.Size = new Size(87, 20);
			label5.TabIndex = 4;
			label5.Text = "İÇECEK SEÇ";
			// 
			// comboBoxIcecek
			// 
			comboBoxIcecek.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxIcecek.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			comboBoxIcecek.FormattingEnabled = true;
			comboBoxIcecek.Location = new Point(1175, 248);
			comboBoxIcecek.Name = "comboBoxIcecek";
			comboBoxIcecek.Size = new Size(151, 28);
			comboBoxIcecek.TabIndex = 9;
			// 
			// label6
			// 
			label6.Anchor = AnchorStyles.None;
			label6.AutoSize = true;
			label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			label6.Location = new Point(1175, 294);
			label6.Name = "label6";
			label6.Size = new Size(82, 20);
			label6.TabIndex = 4;
			label6.Text = "MASA SEÇ";
			// 
			// comboBoxIcecekMasa
			// 
			comboBoxIcecekMasa.DropDownStyle = ComboBoxStyle.DropDownList;
			comboBoxIcecekMasa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
			comboBoxIcecekMasa.FormattingEnabled = true;
			comboBoxIcecekMasa.Location = new Point(1175, 328);
			comboBoxIcecekMasa.Name = "comboBoxIcecekMasa";
			comboBoxIcecekMasa.Size = new Size(151, 28);
			comboBoxIcecekMasa.TabIndex = 9;
			// 
			// buttonIcecek
			// 
			buttonIcecek.Anchor = AnchorStyles.None;
			buttonIcecek.BackColor = Color.FromArgb(0, 192, 192);
			buttonIcecek.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			buttonIcecek.Location = new Point(1175, 377);
			buttonIcecek.Name = "buttonIcecek";
			buttonIcecek.Size = new Size(151, 59);
			buttonIcecek.TabIndex = 6;
			buttonIcecek.Text = "İÇECEĞİ MASAYA EKLE";
			buttonIcecek.UseVisualStyleBackColor = false;
			buttonIcecek.Click += buttonIcecek_Click;
			// 
			// btnDrinks
			// 
			btnDrinks.BackColor = Color.FromArgb(128, 128, 255);
			btnDrinks.Location = new Point(1028, 147);
			btnDrinks.Name = "btnDrinks";
			btnDrinks.Size = new Size(298, 47);
			btnDrinks.TabIndex = 10;
			btnDrinks.Text = "MEŞRUBATLAR";
			btnDrinks.UseVisualStyleBackColor = false;
			btnDrinks.Click += btnDrinks_Click;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1366, 641);
			Controls.Add(btnDrinks);
			Controls.Add(comboBoxIcecekMasa);
			Controls.Add(comboBoxIcecek);
			Controls.Add(txtCiro);
			Controls.Add(comboBoxGünler);
			Controls.Add(buttonIcecek);
			Controls.Add(btnMasaAc);
			Controls.Add(panel1);
			Controls.Add(label3);
			Controls.Add(label6);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(comboSaatUcreti);
			Controls.Add(comboBosMasalar);
			Controls.Add(dataGridView1);
			Controls.Add(btn3ball);
			Controls.Add(btnyellow);
			Controls.Add(btnorange);
			Controls.Add(btnblue);
			Controls.Add(btnamerican);
			Controls.Add(btndark);
			Controls.Add(btngreen);
			Controls.Add(listView1);
			Name = "Form1";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Satış Safyası";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button btngreen;
		private Button btndark;
		private Button btnblue;
		private Button btnorange;
		private Button btnyellow;
		private Button btnamerican;
		private Button btn3ball;
		public ListView listView1;
		public DataGridView dataGridView1;
		private ComboBox comboBosMasalar;
		private Label label1;
		private Panel panel1;
		private RadioButton radioButton120;
		private RadioButton radioButton90;
		private RadioButton radioButton60;
		private RadioButton radioButton30;
		private RadioButton radioButtonSuresiz;
		private Button btnMasaAc;
		private ImageList ımageList1;
		private RadioButton radioButton15;
		private ColumnHeader HareketID;
		private ColumnHeader MasaID;
		private ColumnHeader Masa;
		private ColumnHeader IstekTuru;
		private ColumnHeader Aciklama;
		private ColumnHeader Tarih;
		private ColumnHeader KullaniciID;
		private ComboBox comboSaatUcreti;
		private Label label2;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Masa_ID;
		private DataGridViewTextBoxColumn _Masa;
		private DataGridViewTextBoxColumn AcilisTuru;
		private DataGridViewTextBoxColumn BaslamaSaati;
		private DataGridViewTextBoxColumn BitisSaati;
		private DataGridViewTextBoxColumn Sure;
		private DataGridViewTextBoxColumn Tutar;
		private DataGridViewTextBoxColumn _Tarih;
		private DataGridViewButtonColumn Hesapla;
		private DataGridViewButtonColumn MasaKapat;
		private System.Windows.Forms.Timer timer1;
		private ColumnHeader _Tutar;
		private ComboBox comboBoxGünler;
		private Label label3;
		private Label label4;
		private TextBox txtCiro;
		private Label label5;
		private ComboBox comboBoxIcecek;
		private Label label6;
		private ComboBox comboBoxIcecekMasa;
		private Button buttonIcecek;
		private Button btnDrinks;
	}
}
