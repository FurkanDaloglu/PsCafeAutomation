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

			// Bo� masalar combobox'�nda bu masay� ar�yoruz
			foreach (DataRowView row in comboBosMasalar.Items)
			{
				if (row["Masalar"].ToString() == masaAdi)
				{
					comboBosMasalar.SelectedItem = row;
					break;
				}
			}

			// E�er masa doluysa, uyar� ver
			if (comboBosMasalar.SelectedItem == null)
			{
				MessageBox.Show("Bu masa dolu veya kullan�lamaz durumda.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
			timer.Start(); // Timer'� ba�lat


		}
		private void buttonIcecek_Click(object sender, EventArgs e)
		{
			// Kullan�c�dan se�imin yap�lmas�n� isteyin
			if (comboBoxIcecek.SelectedItem == null)
			{
				MessageBox.Show("L�tfen bir i�ecek se�in.");
				return;
			}

			if (comboBoxIcecekMasa.SelectedItem == null)
			{
				MessageBox.Show("L�tfen bir masa se�in.");
				return;
			}

			try
			{
				// 1. Combobox'lardan se�ilen de�erleri alal�m
				string selectedIcecekIsmi = comboBoxIcecek.SelectedItem.ToString();
				string selectedMasaIsmi = comboBoxIcecekMasa.SelectedItem.ToString();

				// 2. Veritaban� ba�lant�s�n� a�al�m
				baglanti.Open();

				// 3. Se�ilen i�ecek ismine g�re IcecekID ve Fiyat alal�m
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
					MessageBox.Show("Se�ilen i�ecek veritaban�nda bulunamad�.");
					return;
				}
				readerIcecek.Close();

				// 4. Se�ilen masa ismine g�re MasaID alal�m
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
					MessageBox.Show("Se�ilen masa veritaban�nda bulunamad�.");
					return;
				}
				readerMasa.Close();

				// 5. Al�nan bilgileri TBLMasaIcecekler tablosuna ekleyelim
				string insertQuery = "INSERT INTO TBLMasaIcecekler (MasaID, IcecekID, Fiyat, Durum) VALUES (@MasaID, @IcecekID, @Fiyat, @Durum)";
				SqlCommand cmdInsert = new SqlCommand(insertQuery, baglanti);
				cmdInsert.Parameters.AddWithValue("@MasaID", masaID);
				cmdInsert.Parameters.AddWithValue("@IcecekID", icecekID);
				cmdInsert.Parameters.AddWithValue("@Fiyat", fiyat);
				cmdInsert.Parameters.AddWithValue("@Durum", "AKT�F");

				cmdInsert.ExecuteNonQuery();

				MessageBox.Show("��ecek ba�ar�yla masaya eklendi.");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Bir hata olu�tu: " + ex.Message);
			}
			finally
			{
				// Ba�lant�y� kapatma i�lemi her durumda yap�l�r
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

				comboBoxIcecekMasa.Items.Clear();  // ComboBox'� temizliyoruz

				while (reader.Read())
				{
					comboBoxIcecekMasa.Items.Add(reader["Masalar"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Masalary�klenirken hata olu�tu: " + ex.Message);
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

				comboBoxIcecek.Items.Clear();  // ComboBox'� temizliyoruz

				while (reader.Read())
				{
					comboBoxIcecek.Items.Add(reader["IcecekIsmi"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("��ecekler y�klenirken hata olu�tu: " + ex.Message);
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

				comboBoxG�nler.Items.Clear(); // ComboBox'� temizleyin

				while (dr.Read())
				{
					DateTime tarih = Convert.ToDateTime(dr["Tarih"]);
					comboBoxG�nler.Items.Add(tarih.ToString("dd.MM.yyyy")); // Tarih format� se�iminize g�re ayarlanabilir
				}

				dr.Close();
				Veritabani.baglanti.Close();
			}
		}
		private void LoadDataToListView(DateTime selectedDate)
		{
			// Se�ilen tarihe g�re ba�lang�� ve biti� tarihlerini belirleyin
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

				baglanti.Open(); // Ba�lant�y� a�
				SqlDataReader dr = selectCmd.ExecuteReader();

				listView1.Items.Clear(); // �nceki verileri temizleyin

				while (dr.Read())
				{
					ListViewItem item = new ListViewItem(dr["HareketlerID"].ToString());  // HareketlerID
					item.SubItems.Add(dr["Masa"].ToString());  // Masa
					item.SubItems.Add(dr["Tutar"].ToString());  // Tutar
					item.SubItems.Add(dr["Aciklama"].ToString());  // A��klama
					item.SubItems.Add(dr["Tarih"].ToString());  // Tarih
					item.SubItems.Add(dr["AdiSoyadi"].ToString());  // Kullan�c� Ad�

					listView1.Items.Add(item);  // ListView'a ekle
				}

				dr.Close();
				baglanti.Close(); // Ba�lant�y� kapat
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

				comboSaatUcreti.Items.Clear();  // ComboBox'� temizliyoruz

				while (reader.Read())
				{
					comboSaatUcreti.Items.Add(reader["SaatUcreti"].ToString());  // Verileri ComboBox'a ekliyoruz
				}

				baglanti.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Saat �cretleri y�klenirken hata olu�tu: " + ex.Message);
				baglanti.Close();
			}

		}

		private void btnMasaAc_Click(object sender, EventArgs e)
		{
			try
			{
				// �ncelikle bo� bir masa se�ilip se�ilmedi�ini kontrol edelim
				if (comboBosMasalar.SelectedItem == null)
				{
					MessageBox.Show("L�tfen a�mak i�in bo� bir masa se�in.");
					return;
				}

				// Se�ilen masa ad�
				DataRowView drv = comboBosMasalar.SelectedItem as DataRowView;
				string masaAdi = drv["Masalar"].ToString();

				// Ba�lang�� zaman�, �u anki zaman
				DateTime baslangicZamani = DateTime.Now;

				// E�er s�resiz mod se�iliyse (default olarak RadioButton'da s�resiz a��k)
				string acilisTuru = radioButtonSuresiz.Checked ? "S�resiz" : radio.Text;

				// S�resiz de�ilse, se�ilen s�reyi belirleyelim
				TimeSpan? secilenSure = null;
				if (!radioButtonSuresiz.Checked)
				{
					// RadioButton'dan gelen s�reyi alal�m
					if (int.TryParse(radio.Text.Replace(" dakika", ""), out int sureDakika))
					{
						secilenSure = TimeSpan.FromMinutes(sureDakika);
					}
					else
					{
						MessageBox.Show("Ge�erli bir s�re se�in.");
						return;
					}
				}

				// SQL sorgusunu yaz�yoruz (masa a�ma)
				string sqlsorgu = "INSERT INTO TBLSepet (MasaID, Masa, AcilisTuru, Baslangic, Bitis, Tarih) " +
								  "VALUES (@MasaID, @Masa, @AcilisTuru, @BaslamaSaati, @BitisSaati, @Tarih)";

				// Masan�n Durumu'nu g�ncelleyen SQL sorgusu
				string updateDurumSorgu = "UPDATE TBLMasalar SET Durumu = 'DOLU' WHERE MasaID = @MasaID";

				// Veritaban� ba�lant�s� i�inde using yap�s�n� kullan�yoruz
				using (SqlConnection baglanti = new SqlConnection("Your_ConnectionString"))
				{
					// Masan�n ID'sini veritaban�ndan alal�m
					string queryMasa = "SELECT MasaID FROM TBLMasalar WHERE Masalar = @Masalar";
					using (SqlCommand cmdMasa = new SqlCommand(queryMasa, baglanti))
					{
						cmdMasa.Parameters.AddWithValue("@Masalar", masaAdi);

						// Veritaban� ba�lant�s�n� a�
						baglanti.Open();

						// MasaID'yi �ekelim
						int masaID = Convert.ToInt32(cmdMasa.ExecuteScalar());

						// SQL komutu olu�tur (Sepet i�in)
						using (SqlCommand cmd = new SqlCommand(sqlsorgu, baglanti))
						{
							// Veritaban� i�in parametreler ekleniyor
							cmd.Parameters.AddWithValue("@MasaID", masaID);
							cmd.Parameters.AddWithValue("@Masa", masaAdi);
							cmd.Parameters.AddWithValue("@AcilisTuru", acilisTuru);
							cmd.Parameters.AddWithValue("@BaslamaSaati", baslangicZamani);
							cmd.Parameters.AddWithValue("@Tarih", DateTime.Now);

							// S�resiz de�ilse, biti� saatini hesaplayal�m
							if (secilenSure.HasValue)
							{
								DateTime bitisZamani = baslangicZamani.Add(secilenSure.Value);
								cmd.Parameters.AddWithValue("@BitisSaati", bitisZamani);
							}
							else
							{
								cmd.Parameters.AddWithValue("@BitisSaati", DBNull.Value);  // S�resiz mod i�in
							}

							// Komutu �al��t�r
							cmd.ExecuteNonQuery();
						}

						// Masan�n Durumunu 'DOLU' yap
						using (SqlCommand cmdUpdateDurum = new SqlCommand(updateDurumSorgu, baglanti))
						{
							cmdUpdateDurum.Parameters.AddWithValue("@MasaID", masaID);
							cmdUpdateDurum.ExecuteNonQuery();
						}

						// Ba�ar�l� mesaj�
						MessageBox.Show($"Masa {masaAdi} ba�ar�yla a��ld� ve durumu 'DOLU' olarak g�ncellendi.");

						// Yenile fonksiyonunu �a��r (t�m verileri g�ncellemek i�in)
						Yenile();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Masa a�ma i�leminde hata: " + ex.Message);
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
					MessageBox.Show("Saat �cretini se�in!", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
				else
				{
					string acilisTuru = dataGridView1.CurrentRow.Cells["AcilisTuru"].Value.ToString();
					DateTime BitisTarihi;
					DateTime BaslangicTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BaslamaSaati"].Value.ToString());

					// A��l�� t�r�ne g�re hesaplama
					if (acilisTuru.ToUpper() == "S�RES�Z")
					{
						// S�resiz a��lm��sa, biti� tarihi mevcut zaman� almak gereksiz
						BitisTarihi = DateTime.Now; // Veya mevcut BitisTarihi de�erini kullanabilirsiniz, ancak burada ihtiya� yok.
					}
					else
					{
						// S�reli a��lm��sa, biti� saatini kontrol et
						if (string.IsNullOrEmpty(dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString()))
						{
							BitisTarihi = DateTime.Now; // E�er BitisSaati bo�sa, �uanki zaman� kullan
						}
						else
						{
							BitisTarihi = DateTime.Parse(dataGridView1.CurrentRow.Cells["BitisSaati"].Value.ToString());
						}
					}

					// Saat fark�n� hesapl�yoruz
					TimeSpan saatFarki = BitisTarihi - BaslangicTarihi;
					int toplamDakikaFarki = (int)saatFarki.TotalMinutes; // Toplam dakika fark�

					// Saat ve dakika fark�n� hesaplama
					int saat = toplamDakikaFarki / 60; // Tam saat k�sm�
					int dakika = toplamDakikaFarki % 60; // Kalan dakika k�sm�

					// Ge�en her 15 dakikal�k dilim say�s�n� hesapl�yoruz
					int gecen15DkSayisi = (int)Math.Ceiling(toplamDakikaFarki / 15.0);

					// ComboBox'tan se�ilen �creti al�yoruz
					double secilenUcret = Convert.ToDouble(comboSaatUcreti.SelectedItem.ToString());

					// Tutar hesaplama (her 15 dakikal�k dilim ba��na �cret)
					double toplamTutar = gecen15DkSayisi * secilenUcret;

					// SQL ba�lant�s�n� a�
					baglanti.Open();

					// MasaID'sini DataGridView'den al
					int masaID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["Masa_ID"].Value);

					// TBLMasaIcecekler tablosundan AKT�F i�eceklerin fiyatlar�n� alal�m
					string queryIcecekFiyatToplam = "SELECT SUM(Fiyat) FROM TBLMasaIcecekler WHERE MasaID = @MasaID AND Durum = 'AKT�F'";
					SqlCommand cmdIcecekFiyat = new SqlCommand(queryIcecekFiyatToplam, baglanti);
					cmdIcecekFiyat.Parameters.AddWithValue("@MasaID", masaID);

					object icecekFiyatToplamObj = cmdIcecekFiyat.ExecuteScalar();
					decimal icecekFiyatToplam = icecekFiyatToplamObj != DBNull.Value ? Convert.ToDecimal(icecekFiyatToplamObj) : 0;

					// Toplam tutara i�ecek fiyatlar�n� ekleyelim
					toplamTutar += (double)icecekFiyatToplam;



					// Ba�lant�y� kapat
					baglanti.Close();

					// DataGridView'deki h�creleri g�ncelliyoruz
					dataGridView1.CurrentRow.Cells["Sure"].Value = $"{saat}:{dakika:D2}"; // S�reyi saat ve dakika olarak g�steriyoruz
					dataGridView1.CurrentRow.Cells["Tutar"].Value = toplamTutar; // Toplam tutar
					dataGridView1.CurrentRow.Cells["BitisSaati"].Value = BitisTarihi.ToString("HH:mm"); // Biti� saati
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
					item.SubItems.Add(Kullanici.KullaniciAdSoyad.ToString());  // Kullan�c� ID'den giri� yapan ad ve soyad
					item.SubItems.Add(frm.txtAciklama.Text);  // Formdaki a��klama
					listView1.Items.Add(item);
				}
				else
				{
					MessageBox.Show("�nce hesaplama yap�n.", "Uyar�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				// AcilisTuru ve BitisSaati de�erlerini kontrol et
				if (row.Cells["AcilisTuru"].Value != null && row.Cells["BitisSaati"].Value != null)
				{
					string acilisTuru = row.Cells["AcilisTuru"].Value.ToString();
					DateTime bitisSaati;

					// BitisSaati'nin ge�erli bir tarih olup olmad���n� kontrol et
					if (DateTime.TryParse(row.Cells["BitisSaati"].Value.ToString(), out bitisSaati))
					{
						// �u anki zaman� al
						DateTime simdi = DateTime.Now;

						// AcilisTuru'nun 'S�RES�Z' olup olmad���n� kontrol et
						if (acilisTuru != "S�resiz")
						{
							// Biti� saatini ge�ip ge�medi�ini kontrol et
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
							// 'S�RES�Z' ise arka plan rengini de�i�tir
							row.DefaultCellStyle.BackColor = Color.White; // veya ba�ka bir renk
						}
					}
				}
			}

		}

		private void comboBoxG�nler_SelectedIndexChanged(object sender, EventArgs e)
		{
			// ComboBox'tan se�ilen tarihi al
			string selectedDateString = comboBoxG�nler.SelectedItem.ToString();
			DateTime selectedDate = DateTime.ParseExact(selectedDateString, "dd.MM.yyyy", null);

			// Tarihe g�re toplam Tutar'� hesapla
			decimal totalTutar = GetTotalTutarByDate(selectedDate);

			// Sonucu txtCiro'ya yaz
			txtCiro.Text = totalTutar.ToString("F2"); // �ki ondal�k basama�a sahip olacak �ekilde formatlad�k

			// ListView'i se�ilen tarihe g�re g�ncelle
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
