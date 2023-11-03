using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.CodeDom.Compiler;

namespace Proje_Hastane
{
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BtnKayit_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Insert into Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@h1, @h2, @h3, @h4, @h5, @h6)", bgl.baglanti());

            komut.Parameters.AddWithValue("@h1", TxtAd.Text);
            komut.Parameters.AddWithValue("@h2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@h3", MtxtTC.Text);
            komut.Parameters.AddWithValue("@h4", MtxtTel.Text);
            komut.Parameters.AddWithValue("@h5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@h6", CmbCinsiyet.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Yapıldı, Şifreniz: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            





        }
    }
}
