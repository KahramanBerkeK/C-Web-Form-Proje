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

namespace Proje_Hastane
{
    public partial class FrmBilgiDüzenle : Form
    {
        public FrmBilgiDüzenle()
        {
            InitializeComponent();
        }

        public string Tcno;

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmBilgiDüzenle_Load(object sender, EventArgs e)
        {

            MtxtTC.Text = Tcno;

            SqlCommand komut = new SqlCommand("Select * From Tbl_Hastalar where HastaTC=@p1", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", MtxtTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();  
                MtxtTel.Text = dr[4].ToString();
                TxtSifre.Text = dr[5].ToString();
                CmbCinsiyet.Text = dr[6].ToString();
            }

            bgl.baglanti().Close();


        }

        private void BtnBilgiGüncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1,HastaSoyad=@p2, HastaCinsiyet=@p3,HastaTelefon=@p4, HastaSifre=@p5 where HastaTC=@p6 ", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p4", MtxtTel.Text);
            komut.Parameters.AddWithValue("@p5", TxtSifre.Text);
            komut.Parameters.AddWithValue("@p6", MtxtTC.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Güncellemeler Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }
    }
}
