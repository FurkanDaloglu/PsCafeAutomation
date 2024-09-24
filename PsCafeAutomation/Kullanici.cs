using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PsCafeAutomation
{
	class Kullanici
	{
		public static int KullaniciID = 0;
		public static bool durum = false;
		public static string KullaniciAdSoyad = "";

		public static SqlDataReader KullaniciGirisi(TextBox KullaniciAdi, TextBox Sifre)
		{
			try
			{
				Veritabani.baglanti.Open();

				// Parametre kullanarak SQL sorgusu
				string query = "SELECT * FROM tblkullanici WHERE KullaniciAdi = @KullaniciAdi AND Sifre = @Sifre";
				SqlCommand cmd = new SqlCommand(query, Veritabani.baglanti);
				cmd.Parameters.AddWithValue("@KullaniciAdi", KullaniciAdi.Text);
				cmd.Parameters.AddWithValue("@Sifre", Sifre.Text);

				SqlDataReader dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					durum = true;
					KullaniciID = int.Parse(dr["KullaniciID"].ToString()); // Kullanıcı ID'sini al
					KullaniciAdSoyad = dr["AdiSoyadi"].ToString(); // Ad Soyad bilgisini al
				}
				else
				{
					durum = false;
				}

				return dr;
			}
			catch (Exception ex)
			{
				MessageBox.Show("Bir hata oluştu: " + ex.Message);
				return null;
			}
			finally
			{
				Veritabani.baglanti.Close();
			}
		}
	}
}
