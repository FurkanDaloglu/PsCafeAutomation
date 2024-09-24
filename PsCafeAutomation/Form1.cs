using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PsCafeAutomation
{
	public partial class Form1 : Form
	{
		SqlConnection baglanti = new SqlConnection("Your_ConnectionString");
		public Form1()
		{
			InitializeComponent();
		}

		Button btn;
		private void SecileneGore(object sender, MouseEventArgs e)
		{
			btn = sender as Button;
			string masaAdi = btn.Text;

			// Boþ masalar combobox'ýnda bu masayý arýyoruz
			foreach (DataRowView row in comboBosMasalar.Items)
			{
				if (row["Masalar"].ToString() == masaAdi)
				{
					comboBosMasalar.SelectedItem = row;
					break;
				}
			}

			// Eðer masa doluysa, uyarý ver
			if (comboBosMasalar.SelectedItem == null)
			{
				MessageBox.Show("Bu masa dolu veya kullanýlamaz durumda.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		RadioButton radio;
		private void RadioButtonSecili(object sender, EventArgs e)
		{
			radio = sender as RadioButton;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			radioButtonSuresiz.Checked = true;
			Yenile();
			comboBosMasalar.Text = "";
			LoadSaatUcretleri();

			

			dataGridView1.Columns["BaslamaSaati"].DefaultCellStyle.Format = "HH:mm";
			dataGridView1.Columns["BitisSaati"].DefaultCellStyle.Format = "HH:mm";
			System.Windows.Forms.Timer timer = new();
			timer.Interval = 10000; // 1 dakika (60000 ms)
			timer.Tick += timer1_Tick;
			timer.Start(); // Timer'ý baþlat


		}
		private void buttonIcecek_Click(object sender, EventArgs e)
		{
			// Kullanýcýdan seçimin yapýlmasýný isteyin
			if (comboBoxIcecek.SelectedItem == null)
			{
				MessageBox.Show("Lütfen bir içecek seçin.");
				return;
			}

			if (comboBoxIcecekMasa.SelectedItem == null)
			{
				MessageBox.Show("Lütfen bir masa seçin.");
				return;
			}

			try
			{
				// 1. Combobox'lardan seçilen deðerleri alalým
				string selectedIcecekIsmi = comboBoxIcecek.SelectedItem.ToString();
				string selectedMasaIsmi = comboBoxIcecekMasa.SelectedItem.ToString();

				// 2. Veritabaný baðlantýsýný açalým
				baglanti.Open();

				// 3. Seçilen içecek ismine göre IcecekID ve Fiyat alalým
				string queryIcecek = "SELECT IcecekID, Fiyat FROM TBLIcecekler WHERE IcecekIsmi = @IcecekIsmi";
				SqlCommand cmdIcecek = new SqlCommand(queryIcecek, baglanti);
				cmdIcecek.Parameters.AddWithValue("@IcecekIsmi", selectedIcecekIsmi);

				SqlDataReader readerIcecek = cmdIcecek.ExecuteReader();
				int icecekID = 0;
				decimal fiyat = 0;
				if (readerIcecek.Read())
				{
					icecekID = Convert.ToInt32(readerIcecek["IcecekID"]);
					fiyat = Convert.ToDecimal(readerIcecek["Fiyat"]);
				}
				else
				{
					MessageBox.Show("Seçilen içecek veritabanýnda bulunamadý.");
					return;
				}
				readerIcecek.Close();

				// 4. Seçilen masa ismine göre MasaID alalým
				string queryMasa = "SELECT MasaID FROM TBLMasalar WHERE Masalar = @Masalar";
				SqlCommand cmdMasa = new SqlCommand(queryMasa, baglanti);
				cmdMasa.Parameters.AddWithValue("@Masalar", selectedMasaIsmi);

				SqlDataReader readerMasa = cmdMasa.ExecuteReader();
				int masaID = 0;
				if (readerMasa.Read())
				{
					masaID = Convert.ToInt32(readerMasa["MasaID"]);
				}
				else
				{
					MessageBox.Show("Seçilen masa veritabanýnda bulunamadý.");
					return;
				}
				readerMasa.Close();

				// 5. Alýnan bilgileri TBLMasaIcecekler tablosuna ekleyelim
				string insertQuery = "INSERT INTO TBLMasaIcecekler (MasaID, IcecekID, Fiyat, Durum) VALUES (@MasaID, @IcecekID, @Fiyat, @Durum)";
				SqlCommand cmdInsert = new SqlCommand(insertQuery, baglanti);
				cmdInsert.Parameters.AddWithValue("@MasaID", masaID);
				cmdInsert.Parameters.AddWithValue("@IcecekID", icecekID);
				cmdInsert.Parameters.AddWithValue("@Fiyat", fiyat);
				cmdInsert.Parameters.AddWithValue("@Durum", "AKTÝF");

				cmdInsert.ExecuteNonQuery();

				MessageBox.Show("Ýçecek baþarýyla masaya eklendi.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Bir hata oluþtu: " + ex.Message);
			}
			finally
			{
				// Baðlantýyý kapatma iþlemi her durumda yapýlýr
				if (baglanti.State == ConnectionState.Open)
				{
					baglanti.Close();
				}
				comboBoxIcecek.SelectedIndex = -1;
				comboBoxIcecekMasa.SelectedIndex = -1;
			}
		}
		private void LoadIcecekMasa()
		{
			try
			{
				string query = "SELECT Masalar FROM TBLMasalar WHERE Durumu='DOLU'";
				baglanti.Open();
				SqlCommand cmd = new SqlCommand(query, baglanti);
				SqlDataReader reader = cmd.ExecuteReader();

				comboBoxIcecekMasa.Items.Clear();  // ComboBox'ý temizliyoruz

				while (reader.Read())
				{
					comboBoxIcecekMasa.Items.Add(reader["Masalar"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Masalaryüklenirken hata oluþtu: " + ex.Message);
				baglanti.Close();
			}
		}
		public void LoadIcecekler()
		{
			try
			{
				string query = "SELECT IcecekIsmi FROM TBLIcecekler";
				baglanti.Open();
				SqlCommand cmd = new SqlCommand(query, baglanti);
				SqlDataReader reader = cmd.ExecuteReader();

				comboBoxIcecek.Items.Clear();  // ComboBox'ý temizliyoruz

				while (reader.Read())
				{
					comboBoxIcecek.Items.Add(reader["IcecekIsmi"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ýçecekler yüklenirken hata oluþtu: " + ex.Message);
				baglanti.Close();
			}
		}
		private void LoadUniqueDatesToComboBox()
		{
			string selectQuery = @"
    SELECT DISTINCT CAST(Tarih AS DATE) AS Tarih
    FROM TBLHareketler
    ORDER BY Tarih DESC;";

			using (SqlCommand selectCmd = new SqlCommand(selectQuery, Veritabani.baglanti))
			{
				Veritabani.baglanti.Open();
				SqlDataReader dr = selectCmd.ExecuteReader();

				comboBoxGünler.Items.Clear(); // ComboBox'ý temizleyin

				while (dr.Read())
				{
					DateTime tarih = Convert.ToDateTime(dr["Tarih"]);
					comboBoxGünler.Items.Add(tarih.ToString("dd.MM.yyyy")); // Tarih formatý seçiminize göre ayarlanabilir
				}

				dr.Close();
				Veritabani.baglanti.Close();
			}
		}
		private void LoadDataToListView(DateTime selectedDate)
		{
			// Seçilen tarihe göre baþlangýç ve bitiþ tarihlerini belirleyin
			DateTime startDate = selectedDate.Date;
			DateTime endDate = startDate.AddDays(1);

			string selectQuery = @"
    SELECT h.HareketlerID, h.Masa, h.Tutar, h.Aciklama, h.Tarih, k.AdiSoyadi
    FROM TBLHareketler h
    INNER JOIN TBLKullanici k ON h.KullaniciID = k.KullaniciID
    WHERE h.Tarih >= @StartDate AND h.Tarih < @EndDate ORDER BY h.HareketlerID DESC";

			using (SqlCommand selectCmd = new SqlCommand(selectQuery, baglanti))
			{
				selectCmd.Parameters.AddWithValue("@StartDate", startDate);
				selectCmd.Parameters.AddWithValue("@EndDate", endDate);

				baglanti.Open(); // Baðlantýyý aç
				SqlDataReader dr = selectCmd.ExecuteReader();

				listView1.Items.Clear(); // Önceki verileri temizleyin

				while (dr.Read())
				{
					ListViewItem item = new ListViewItem(dr["HareketlerID"].ToString());  // HareketlerID
					item.SubItems.Add(dr["Masa"].ToString());  // Masa
					item.SubItems.Add(dr["Tutar"].ToString());  // Tutar
					item.SubItems.Add(dr["Aciklama"].ToString());  // Açýklama
					item.SubItems.Add(dr["Tarih"].ToString());  // Tarih
					item.SubItems.Add(dr["AdiSoyadi"].ToString());  // Kullanýcý Adý

					listView1.Items.Add(item);  // ListView'a ekle
				}

				dr.Close();
				baglanti.Close(); // Baðlantýyý kapat
			}
		}
		public void Yenile()
		{

			Veritabani.SepetListele(dataGridView1);
			//Veritabani.ListViewdeKayitlariGoster(listView1);
			Veritabani.ComboyaBosMasaGetir(comboBosMasalar);
			DateTime defaultDate = DateTime.Now.Date;
			LoadDataToListView(defaultDate);
			LoadIcecekMasa();
			LoadIcecekler();
			LoadUniqueDatesToComboBox();
		}


		private void LoadSaatUcretleri()
		{
			try
			{
				string query = "SELECT SaatUcreti FROM TBLSaatUcreti";
				baglanti.Open();
				SqlCommand cmd = new SqlCommand(query, baglanti);
				SqlDataReader reader = cmd.ExecuteReader();

				comboSaatUcreti.Items.Clear();  // ComboBox'ý temizliyoruz

				while (reader.Read())
				{
					comboSaatUcreti.Items.Add(reader["SaatUcreti"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Saat ücretleri yüklenirken hata oluþtu: " + ex.Message);
				baglanti.Close();
			}

		}

		private void btnMasaAc_Click(object sender, EventArgs e)
		{
			try
			{
				// Öncelikle boþ bir masa seçilip seçilmediðini kontrol edelim
				if (comboBosMasalar.SelectedItem == null)
				{
					MessageBox.Show("Lütfen açmak için boþ bir masa seçin.");
					return;
				}

				// Seçilen masa adý
				DataRowView drv = comboBosMasalar.SelectedItem as DataRowView;
				string masaAdi = drv["Masalar"].ToString();

				// Baþlangýç zamaný, þu anki zaman
				DateTime baslangicZamani = DateTime.Now;

				// Eðer süresiz mod seçiliyse (default olarak RadioButton'da süresiz açýk)
				string acilisTuru = radioButtonSuresiz.Checked ? "Süresiz" : radio.Text;

				// Süresiz deðilse, seçilen süreyi belirleyelim
				TimeSpan? secilenSure = null;
				if (!radioButtonSuresiz.Checked)
				{
					// RadioButton'dan gelen süreyi alalým
					if (int.TryParse(radio.Text.Replace(" dakika", ""), out int sureDakika))
					{
						secilenSure = TimeSpan.FromMinutes(sureDakika);
					}
					else
					{
						MessageBox.Show("Geçerli bir süre seçin.");
						return;
					}
				}

				// SQL sorgusunu yazýyoruz (masa açma)
				string sqlsorgu = "INSERT INTO TBLSepet (MasaID, Masa, AcilisTuru, Baslangic, Bitis, Tarih) " +
								  "VALUES (@MasaID, @Masa, @AcilisTuru, @BaslamaSaati, @BitisSaati, @Tarih)";

				// Masanýn Durumu'nu güncelleyen SQL sorgusu
				string updateDurumSorgu = "UPDATE TBLMasalar SET Durumu = 'DOLU' WHERE MasaID = @MasaID";

				// Veritabaný baðlantýsý içinde using yapýsýný kullanýyoruz
				using (SqlConnection baglanti = new SqlConnection("Your_ConnectionString"))
				{
					// Masanýn ID'sini veritabanýndan alalým
					string queryMasa = "SELECT MasaID FROM TBLMasalar WHERE Masalar = @Masalar";
					using (SqlCommand cmdMasa = new SqlCommand(queryMasa, baglanti))
					{
						cmdMasa.Parameters.AddWithValue("@Masalar", masaAdi);

						// Veritabaný baðlantýsýný aç
						baglanti.Open();

						// MasaID'yi çekelim
						int masaID = Convert.ToInt32(cmdMasa.ExecuteScalar());

						// SQL komutu oluþtur (Sepet için)
						using (SqlCommand cmd = new SqlCommand(sqlsorgu, baglanti))
						{
							// Veritabaný için parametreler ekleniyor
							cmd.Parameters.AddWithValue("@MasaID", masaID);
							cmd.Parameters.AddWithValue("@Masa", masaAdi);
							cmd.Parameters.AddWithValue("@AcilisTuru", acilisTuru);
							cmd.Parameters.AddWithValue("@BaslamaSaati", baslangicZamani);
							cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);

							// Süresiz deðilse, bitiþ saatini hesaplayalým
							if (secilenSure.HasValue)
							{
								DateTime bitisZamani = baslangicZamani.Add(secilenSure.Value);
								cmd.Parameters.AddWithValue("@BitisSaati", bitisZamani);
							}
							else
							{
								cmd.Parameters.AddWithValue("@BitisSaati", DBNull.Value);  // Süresiz mod için
							}

							// Komutu çalýþtýr
							cmd.ExecuteNonQuery();
						}

						// Masanýn Durumunu 'DOLU' yap
						using (SqlCommand cmdUpdateDurum = new SqlCommand(updateDurumSorgu, baglanti))
						{
							cmdUpdateDurum.Parameters.AddWithValue("@MasaID", masaID);
							cmdUpdateDurum.ExecuteNonQuery();
						}

						// Baþarýlý mesajý
						MessageBox.Show($"Masa {masaAdi} baþarýyla açýldý ve durumu 'DOLU' olarak güncellendi.");

						// Yenile fonksiyonunu çaðýr (tüm verileri güncellemek için)
						Yenile();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Masa açma iþleminde hata: " + ex.Message);
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			Environment.Exit(0);
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == dataGridView1.Columns["Hesapla"].Index)
			{
				if (comboSaatUcreti.SelectedItem == null || string.IsNullOrEmpty(comboSaatUcreti.SelectedItem.ToString()))
				{
					MessageBox.Show("Saat ücretini seçin!", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					string acilisTuru = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
					DateTime BitisTarihi;
					DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString());

					// Açýlýþ türüne göre hesaplama
					if (acilisTuru.ToUpper() == "SÜRESÝZ")
					{
						// Süresiz açýlmýþsa, bitiþ tarihi mevcut zamaný almak gereksiz
						BitisTarihi = DateTime.Now; // Veya mevcut BitisTarihi deðerini kullanabilirsiniz, ancak burada ihtiyaç yok.
					}
					else
					{
						// Süreli açýlmýþsa, bitiþ saatini kontrol et
						if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString()))
						{
							BitisTarihi = DateTime.Now; // Eðer BitisSaati boþsa, þuanki zamaný kullan
						}
						else
						{
							BitisTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString());
						}
					}

					// Saat farkýný hesaplýyoruz
					TimeSpan saatFarki = BitisTarihi - BaslangicTarihi;
					int toplamDakikaFarki = (int)saatFarki.TotalMinutes; // Toplam dakika farký

					// Saat ve dakika farkýný hesaplama
					int saat = toplamDakikaFarki / 60; // Tam saat kýsmý
					int dakika = toplamDakikaFarki % 60; // Kalan dakika kýsmý

					// Geçen her 15 dakikalýk dilim sayýsýný hesaplýyoruz
					int gecen15DkSayisi = (int)Math.Ceiling(toplamDakikaFarki / 15.0);

					// ComboBox'tan seçilen ücreti alýyoruz
					double secilenUcret = Convert.ToDouble(comboSaatUcreti.SelectedItem.ToString());

					// Tutar hesaplama (her 15 dakikalýk dilim baþýna ücret)
					double toplamTutar = gecen15DkSayisi * secilenUcret;

					// SQL baðlantýsýný aç
					baglanti.Open();

					// MasaID'sini DataGridView'den al
					int masaID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Masa_ID"].Value);

					// TBLMasaIcecekler tablosundan AKTÝF içeceklerin fiyatlarýný alalým
					string queryIcecekFiyatToplam = "SELECT SUM(Fiyat) FROM TBLMasaIcecekler WHERE MasaID = @MasaID AND Durum = 'AKTÝF'";
					SqlCommand cmdIcecekFiyat = new SqlCommand(queryIcecekFiyatToplam, baglanti);
					cmdIcecekFiyat.Parameters.AddWithValue("@MasaID", masaID);

					object icecekFiyatToplamObj = cmdIcecekFiyat.ExecuteScalar();
					decimal icecekFiyatToplam = icecekFiyatToplamObj != DBNull.Value ? Convert.ToDecimal(icecekFiyatToplamObj) : 0;

					// Toplam tutara içecek fiyatlarýný ekleyelim
					toplamTutar += (double)icecekFiyatToplam;



					// Baðlantýyý kapat
					baglanti.Close();

					// DataGridView'deki hücreleri güncelliyoruz
					dataGridView1.CurrentRow.Cells["Sure"].Value = $"{saat}:{dakika:D2}"; // Süreyi saat ve dakika olarak gösteriyoruz
					dataGridView1.CurrentRow.Cells["Tutar"].Value = toplamTutar; // Toplam tutar
					dataGridView1.CurrentRow.Cells["BitisSaati"].Value = BitisTarihi.ToString("HH:mm"); // Bitiþ saati
				}
			}

			if (e.ColumnIndex == dataGridView1.Columns["MasaKapat"].Index)
			{
				if (dataGridView1.CurrentRow.Cells["Tutar"].Value != null)
				{
					frmMasaKapat frm = new frmMasaKapat();
					frm.txtID.Text = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
					frm.txtMasaID.Text = dataGridView1.CurrentRow.Cells["Masa_ID"].Value.ToString();
					frm.txtMasa.Text = dataGridView1.CurrentRow.Cells["_Masa"].Value.ToString();
					frm.txtAcilisTuru.Text = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
					frm.txtBaslamaSaati.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value).ToString("HH:mm");
					frm.txtBitisSaati.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["BitisSaati"].Value).ToString("HH:mm");
					frm.txtSaatUcreti.Text = comboSaatUcreti.Text;
					frm.txtSure.Text = dataGridView1.CurrentRow.Cells["Sure"].Value.ToString();
					frm.txtTutar.Text = dataGridView1.CurrentRow.Cells["Tutar"].Value.ToString();
					frm.txtTarih.Text = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["_Tarih"].Value).ToString("dd.MM.yyyy");

					frm.ShowDialog();
					ListViewItem item = new ListViewItem(dataGridView1.CurrentRow.Cells["_Masa"].Value.ToString());
					item.SubItems.Add(frm.txtSure.Text);
					item.SubItems.Add(frm.txtTutar.Text);
					item.SubItems.Add(frm.txtTarih.Text);
					item.SubItems.Add(Kullanici.KullaniciAdSoyad.ToString());  // Kullanýcý ID'den giriþ yapan ad ve soyad
					item.SubItems.Add(frm.txtAciklama.Text);  // Formdaki açýklama
					listView1.Items.Add(item);
				}
				else
				{
					MessageBox.Show("Önce hesaplama yapýn.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
		}

		private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{

		}



		private void timer1_Tick(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dataGridView1.Rows)
			{
				// AcilisTuru ve BitisSaati deðerlerini kontrol et
				if (row.Cells["AcilisTuru"].Value != null && row.Cells["BitisSaati"].Value != null)
				{
					string acilisTuru = row.Cells["AcilisTuru"].Value.ToString();
					DateTime bitisSaati;

					// BitisSaati'nin geçerli bir tarih olup olmadýðýný kontrol et
					if (DateTime.TryParse(row.Cells["BitisSaati"].Value.ToString(), out bitisSaati))
					{
						// Þu anki zamaný al
						DateTime simdi = DateTime.Now;

						// AcilisTuru'nun 'SÜRESÝZ' olup olmadýðýný kontrol et
						if (acilisTuru != "Süresiz")
						{
							// Bitiþ saatini geçip geçmediðini kontrol et
							if (simdi >= bitisSaati)
							{
								row.DefaultCellStyle.BackColor = Color.Red;
							}
							else
							{
								row.DefaultCellStyle.BackColor = Color.White; // Normal arka plan rengi
							}
						}
						else
						{
							// 'SÜRESÝZ' ise arka plan rengini deðiþtir
							row.DefaultCellStyle.BackColor = Color.White; // veya baþka bir renk
						}
					}
				}
			}

		}

		private void comboBoxGünler_SelectedIndexChanged(object sender, EventArgs e)
		{
			// ComboBox'tan seçilen tarihi al
			string selectedDateString = comboBoxGünler.SelectedItem.ToString();
			DateTime selectedDate = DateTime.ParseExact(selectedDateString, "dd.MM.yyyy", null);

			// Tarihe göre toplam Tutar'ý hesapla
			decimal totalTutar = GetTotalTutarByDate(selectedDate);

			// Sonucu txtCiro'ya yaz
			txtCiro.Text = totalTutar.ToString("F2"); // Ýki ondalýk basamaða sahip olacak þekilde formatladýk

			// ListView'i seçilen tarihe göre güncelle
			LoadDataToListView(selectedDate);

		}
		private decimal GetTotalTutarByDate(DateTime date)
		{
			decimal totalTutar = 0;

			string query = @"
    SELECT SUM(Tutar) AS Total
    FROM TBLHareketler
    WHERE CAST(Tarih AS DATE) = @Date";

			using (SqlCommand command = new SqlCommand(query, Veritabani.baglanti))
			{
				command.Parameters.AddWithValue("@Date", date);

				Veritabani.baglanti.Open();
				object result = command.ExecuteScalar();
				Veritabani.baglanti.Close();

				if (result != DBNull.Value)
				{
					totalTutar = Convert.ToDecimal(result);
				}
			}

			return totalTutar;
		}

		private void btnDrinks_Click(object sender, EventArgs e)
		{
			Drinks drinksForm = new Drinks(this);
			drinksForm.Show();
		}


	}
}
