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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }

        
        public string tc;

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_Duyurular (Duyuru) values (@k1)", bgl.baglanti());

            komut2.Parameters.AddWithValue("@k1", RchDuyuru.Text);

            komut2.ExecuteNonQuery();


            bgl.baglanti().Close();


            MessageBox.Show("Duyuru Oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {

            
            LblTC.Text = tc;

            //ADSoyad

            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad from Tbl_Sekreter where SekreterTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", LblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                LblAdSoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();

            //Branşları Data Gride Aktarma

            DataTable dt1 = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select BransAd from Tbl_Branslar", bgl.baglanti());

            da.Fill(dt1);

            dataGridView1.DataSource = dt1;

            //Doktorları Listeye Aktarma


            DataTable dt2 = new DataTable();

            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Doktorlar',DoktorBrans from Tbl_Doktorlar", bgl.baglanti());

            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            //Branşları Getirme

            SqlCommand komut4 = new SqlCommand("Select * from Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr4 = komut4.ExecuteReader();

            while (dr4.Read())
            {
                CmbBrans.Items.Add(dr4[1].ToString());
            }

            bgl.baglanti().Close();

        








        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komutkaydet = new SqlCommand("insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor) values (@s1,@s2,@s3,@s4)", bgl.baglanti());

            komutkaydet.Parameters.AddWithValue("@s1", MskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@s2", MskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@s3", CmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@s4", CmbDoktor.Text);

            komutkaydet.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Randevu Oluşturuldu.");



        }

        private void CmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {

            CmbDoktor.Items.Clear();
            SqlCommand komut5 = new SqlCommand("Select (DoktorAd +DoktorSoyad) as Doktorlar, DoktorBrans from Tbl_Doktorlar where DoktorBrans=@l1", bgl.baglanti());

            komut5.Parameters.AddWithValue("@l1", CmbBrans.Text);

            SqlDataReader dr5 = komut5.ExecuteReader();

            while (dr5.Read())
            {
                CmbDoktor.Items.Add(dr5[0].ToString());
            }

            bgl.baglanti().Close();
        }

        private void BtnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli sr = new FrmDoktorPaneli();

            sr.Show();
        }

        private void BtnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans br = new FrmBrans();

            br.Show();
            this.Hide();
        }

        private void BtnListe_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi rl = new FrmRandevuListesi();

            rl.Show();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmDuyurular dyr = new FrmDuyurular();

            dyr.Show();
            
        }
    }
}
