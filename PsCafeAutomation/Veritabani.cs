using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsCafeAutomation
{
	class Veritabani
	{
		public static SqlConnection baglanti = new SqlConnection("Your_ConnectionString");
		public static DataTable SepetListele(DataGridView gridView)
		{
			SqlDataAdapter adtr = new SqlDataAdapter("select * from tblsepet", baglanti);
			DataTable tbl = new();
			adtr.Fill(tbl);
			gridView.DataSource = tbl;
			return tbl;
		}
		public static DataTable ComboyaBosMasaGetir(ComboBox combo)
		{
			baglanti.Open();
			SqlDataAdapter adtr = new SqlDataAdapter("select * from tblmasalar where durumu='BOŞ'", baglanti);
			DataTable tbl = new();
			adtr.Fill(tbl);
			combo.DataSource = tbl;
			combo.DisplayMember = "Masalar";
			combo.ValueMember = "MasaID";
			baglanti.Close();
			return tbl;
		}
		public static void ESG(SqlCommand command, string sorgu)
		{
			using (SqlConnection baglanti = new SqlConnection("Your_ConnectionString"))
			{
				baglanti.Open();
				command.Connection = baglanti;
				command.CommandText = sorgu;
				command.ExecuteNonQuery();
			}
		}
		//public static void ESG(SqlCommand command, string sorgu)
		//{
		//	baglanti.Open();
		//	command.Connection = baglanti;
		//	command.CommandText = sorgu;
		//	command.ExecuteNonQuery();
		//	baglanti.Close();
		//}
		//public static SqlDataReader ListViewdeKayitlariGoster(ListView list)
		//{
		//	baglanti.Open();
		//	SqlCommand cmd = new SqlCommand("select * from tblhareketler where tarih >= @Tarih", baglanti);
		//	cmd.Parameters.AddWithValue("@Tarih", DateTime.Now.Date);  // Bugünün tarihi
		//	SqlDataReader dr = cmd.ExecuteReader();

		//	while (dr.Read())
		//	{
		//		ListViewItem ekle = new ListViewItem();
		//		ekle.Text = dr["Masa"].ToString();  // Masa adı
		//		ekle.SubItems.Add(dr["Tutar"].ToString());
		//		ekle.SubItems.Add(dr["Tarih"].ToString());
		//		ekle.SubItems.Add(dr["KullaniciID"].ToString());  // KullanıcıID
		//		ekle.SubItems.Add(dr["Aciklama"].ToString());  // Açıklama
		//		list.Items.Add(ekle);
		//	}

		//	baglanti.Close();
		//	return dr;
		//	//baglanti.Open();
		//	//SqlCommand cmd = new SqlCommand("select* from tblhareketler where tarih>=@Tarih", baglanti);
		//	//cmd.Parameters.AddWithValue("@Tarih", DateTime.Parse(DateTime.Now.ToShortDateString()));
		//	//SqlDataReader dr = cmd.ExecuteReader();
		//	//while(dr.Read())
		//	//{
		//	//	ListViewItem ekle = new ListViewItem();
		//	//	ekle.Text = dr[0].ToString();
		//	//	ekle.SubItems.Add(dr[1].ToString());
		//	//	ekle.SubItems.Add(dr[2].ToString());
		//	//	ekle.SubItems.Add(dr[3].ToString());
		//	//	ekle.SubItems.Add(dr[4].ToString());
		//	//	ekle.SubItems.Add(dr[5].ToString());
		//	//	ekle.SubItems.Add(dr[6].ToString());
		//	//	list.Items.Add(ekle);
		//	//}
		//	//baglanti.Close();
		//	//return dr;
		//}
	}
}
