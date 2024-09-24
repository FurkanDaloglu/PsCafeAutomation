using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PsCafeAutomation
{
	public partial class frmMasaKapat : Form
	{
		public frmMasaKapat()
		{
			InitializeComponent();
		}

		private void btnMasaKapat_Click(object sender, EventArgs e)
		{
			try
			{
				// Masa durumunu 'BOŞ' olarak güncelle
				string sqlsorgu = "UPDATE tblmasalar SET durumu='BOŞ' WHERE MasaID=@MasaID";
				SqlCommand cmd = new SqlCommand();
				cmd.Parameters.AddWithValue("@MasaID", txtMasaID.Text);
				Veritabani.ESG(cmd, sqlsorgu);

				// Sepeti sil
				string sqlsorgu2 = "DELETE FROM tblsepet WHERE SepetID=@SepetID";
				SqlCommand komut2 = new SqlCommand();
				komut2.Parameters.AddWithValue("@SepetID", txtID.Text);
				Veritabani.ESG(komut2, sqlsorgu2);

				// Form1'deki DataGridView'deki mevcut satırı alalım
				Form1 frm = (Form1)Application.OpenForms["Form1"];
				DataGridViewRow currentRow = frm.dataGridView1.CurrentRow;

				if (currentRow == null)
				{
					MessageBox.Show("DataGridView'den veri alınamadı. Lütfen bir satır seçtiğinizden emin olun.");
					return;
				}

				// Verileri SQL'e ekleyelim (TBLHareketler tablosuna)
				string insertQuery = "INSERT INTO TBLHareketler (KullaniciID, MasaID, Masa, Aciklama, Tarih, Tutar) " +
									 "VALUES (@KullaniciID, @MasaID, @Masa, @Aciklama, @Tarih, @Tutar)";

				using (SqlCommand insertCmd = new SqlCommand(insertQuery))
				{
					insertCmd.Parameters.AddWithValue("@KullaniciID", Kullanici.KullaniciID);  // Kullanıcı ID
					insertCmd.Parameters.AddWithValue("@MasaID", currentRow.Cells["Masa_ID"].Value.ToString());  // Masa ID
					insertCmd.Parameters.AddWithValue("@Masa", currentRow.Cells["_Masa"].Value.ToString());  // Masa Adı
					insertCmd.Parameters.AddWithValue("@Aciklama", txtAciklama.Text);  // Açıklama
					insertCmd.Parameters.AddWithValue("@Tarih", DateTime.Now);  // Kapanış Tarihi
					insertCmd.Parameters.AddWithValue("@Tutar", decimal.Parse(currentRow.Cells["Tutar"].Value.ToString()));  // Tutar

					Veritabani.ESG(insertCmd, insertQuery);  // Burada da ESG metodunu çağırıyoruz
				}

				// TBLMasaIcecekler tablosundaki AKTİF içeceklerin durumunu PASİF yapalım
				string updateIcecekDurum = "UPDATE TBLMasaIcecekler SET Durum = 'PASİF' WHERE MasaID = @MasaID AND Durum = 'AKTİF'";
				using (SqlCommand cmdUpdateIcecekDurum = new SqlCommand(updateIcecekDurum))
				{
					cmdUpdateIcecekDurum.Parameters.AddWithValue("@MasaID", currentRow.Cells["Masa_ID"].Value.ToString());
					Veritabani.ESG(cmdUpdateIcecekDurum, updateIcecekDurum);  // İçeceklerin durumunu PASİF yapıyoruz
				}

				// Form1'de yenileme işlemi yap
				frm.Yenile();

				this.Close();  // Masa kapatılınca formu kapat
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Bir hata oluştu: {ex.Message}");
			}
		}

		private void btnCikis_Click(object sender, EventArgs e)
		{

			this.Close();
		}
	}
}
