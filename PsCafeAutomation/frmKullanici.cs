using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PsCafeAutomation
{
	public partial class frmKullanici : Form
	{
		public frmKullanici()
		{
			InitializeComponent();
		}

		private void btnGiris_Click(object sender, EventArgs e)
		{
			Kullanici.KullaniciGirisi(txtKullaniciAdi, txtSifre);
			if (Kullanici.durum == true)
			{
				Form1 frm = new Form1();
				frm.Show();
				this.Hide();
			}
			else if (Kullanici.durum == false)
			{
				MessageBox.Show("Kullanıcı adı veya şifre yanlış.!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		private void frmKullanici_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				// Butonun adını değiştirin (örneğin, button1)
				btnGiris.PerformClick();
			}
		}
	}
}
