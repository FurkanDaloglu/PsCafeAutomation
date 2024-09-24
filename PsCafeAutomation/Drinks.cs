using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsCafeAutomation
{
	public partial class Drinks : Form
	{
		private Form1 _form1; // Form1 referansı
		SqlConnection baglanti = new SqlConnection("Your_ConnectionString");
		public Drinks(Form1 form1)
		{
			InitializeComponent();
			_form1 = form1; // Form1 referansını al
							// Form yüklenirken verileri getir
			this.Load += new EventHandler(Drinks_Load);

			// Form kapatıldığında Yenile metodunu çağır
			this.FormClosed += new FormClosedEventHandler(Drinks_FormClosed);
			txtFiyat.KeyPress += new KeyPressEventHandler(txtFiyat_KeyPress);
		}

		private void Drinks_Load(object sender, EventArgs e)
		{
			VerileriGetir();
		}
		private void VerileriGetir()
		{
			try
			{
				// SQL'den verileri getir
				string query = "SELECT IcecekIsmi, Fiyat FROM TBLIcecekler";
				SqlDataAdapter da = new SqlDataAdapter(query, baglanti);
				DataTable dt = new DataTable();
				baglanti.Open();
				da.Fill(dt);
				baglanti.Close();

				// DataGridView'deki satırları temizle
				dataGridViewDrink.Rows.Clear();

				// DataGridView'in her satırına SQL'den gelen veriyi ekleyin
				foreach (DataRow row in dt.Rows)
				{
					int rowIndex = dataGridViewDrink.Rows.Add();
					dataGridViewDrink.Rows[rowIndex].Cells["IcecekIsmi"].Value = row["IcecekIsmi"] ?? DBNull.Value;
					dataGridViewDrink.Rows[rowIndex].Cells["Fiyat"].Value = row["Fiyat"] ?? DBNull.Value;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Veriler getirilirken bir hata oluştu: " + ex.Message);
			}
		}

		
		private void Drinks_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Mevcut Form1 örneğinin Yenile metodunu çağır
			_form1?.LoadIcecekler();
		}
		private bool _isDeleting = false; // Silme işleminin devam edip etmediğini kontrol etmek için
		private void dataGridViewDrink_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			// Silme butonuna tıklanıp tıklanmadığını kontrol et
			if (e.ColumnIndex == dataGridViewDrink.Columns["Sil"].Index && e.RowIndex >= 0)
			{
				if (_isDeleting) return; // Eğer zaten silme işlemi devam ediyorsa, işlemi tekrar başlatma

				_isDeleting = true; // Silme işlemini başlat

				var icecekIsmiCell = dataGridViewDrink.Rows[e.RowIndex].Cells["IcecekIsmi"].Value;

				if (icecekIsmiCell == null)
				{
					MessageBox.Show("Seçilen içeceğin adı boş.");
					_isDeleting = false; // Silme işlemini bitir
					return;
				}

				string icecekIsmi = icecekIsmiCell.ToString();

				DialogResult result = MessageBox.Show(icecekIsmi + " adlı içeceği silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (result == DialogResult.Yes)
				{
					try
					{
						// İlk olarak IcecekID'yi alalım
						string selectQuery = "SELECT IcecekID FROM TBLIcecekler WHERE IcecekIsmi = @IcecekIsmi";
						SqlCommand selectCmd = new SqlCommand(selectQuery, baglanti);
						selectCmd.Parameters.AddWithValue("@IcecekIsmi", icecekIsmi);

						baglanti.Open();
						int icecekID = Convert.ToInt32(selectCmd.ExecuteScalar());
						baglanti.Close();

						// 1. Adım: İlişkili tablodan silme (TBLMasaIcecekler)
						string deleteMasaIceceklerQuery = "DELETE FROM TBLMasaIcecekler WHERE IcecekID = @IcecekID";
						SqlCommand deleteMasaIceceklerCmd = new SqlCommand(deleteMasaIceceklerQuery, baglanti);
						deleteMasaIceceklerCmd.Parameters.AddWithValue("@IcecekID", icecekID);

						baglanti.Open();
						deleteMasaIceceklerCmd.ExecuteNonQuery();
						baglanti.Close();

						// 2. Adım: Asıl içeceği TBLIcecekler tablosundan silme
						string deleteQuery = "DELETE FROM TBLIcecekler WHERE IcecekIsmi = @IcecekIsmi";
						SqlCommand cmd = new SqlCommand(deleteQuery, baglanti);
						cmd.Parameters.AddWithValue("@IcecekIsmi", icecekIsmi);

						baglanti.Open();
						cmd.ExecuteNonQuery();
						baglanti.Close();

						// Verileri tekrar getir
						VerileriGetir();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
					}
				}

				_isDeleting = false; // Silme işlemini bitir
			}
		}

		private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
		{
			// Sayı veya ondalık nokta girmeye izin ver
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
			{
				e.Handled = true;
			}

			// Ondalık nokta sadece bir kez girilebilir
			if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
			{
				e.Handled = true;
			}
		}

		private void btnIcecekEkle_Click(object sender, EventArgs e)
		{
			string icecekIsmi = txtIcecekAdi.Text.Trim();
			string fiyatText = txtFiyat.Text.Trim();

			// Fiyatın geçerli bir sayı olup olmadığını kontrol et
			if (!decimal.TryParse(fiyatText, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal fiyat))
			{
				MessageBox.Show("Geçerli bir fiyat girin.");
				return;
			}

			// İçeriğin zaten mevcut olup olmadığını kontrol et
			try
			{
				string checkQuery = "SELECT COUNT(*) FROM TBLIcecekler WHERE IcecekIsmi = @IcecekIsmi";
				SqlCommand checkCmd = new SqlCommand(checkQuery, baglanti);
				checkCmd.Parameters.AddWithValue("@IcecekIsmi", icecekIsmi);

				baglanti.Open();
				int count = (int)checkCmd.ExecuteScalar();
				baglanti.Close();

				if (count > 0)
				{
					MessageBox.Show("Aynı içecek zaten mevcut.");
					return;
				}

				// Veritabanına ekleme işlemi
				string insertQuery = "INSERT INTO TBLIcecekler (IcecekIsmi, Fiyat) VALUES (@IcecekIsmi, @Fiyat)";
				SqlCommand insertCmd = new SqlCommand(insertQuery, baglanti);
				insertCmd.Parameters.AddWithValue("@IcecekIsmi", icecekIsmi);
				insertCmd.Parameters.AddWithValue("@Fiyat", fiyat);

				baglanti.Open();
				insertCmd.ExecuteNonQuery();
				baglanti.Close();

				MessageBox.Show("İçecek başarıyla eklendi.");
				// TextBox'ları temizleyin (isteğe bağlı)
				txtIcecekAdi.Clear();
				txtFiyat.Clear();

				VerileriGetir();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Veri ekleme sırasında bir hata oluştu: " + ex.Message);
			}
		}
	}
}
