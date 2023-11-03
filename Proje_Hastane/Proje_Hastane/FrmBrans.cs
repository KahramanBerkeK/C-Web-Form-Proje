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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmBrans_Load(object sender, EventArgs e)
        {

            DataTable tb = new DataTable();

            SqlDataAdapter da = new SqlDataAdapter("Select * from Tbl_Branslar", bgl.baglanti());

            da.Fill(tb);

            dataGridView1.DataSource = tb;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            Txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();

        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Branslar (BransAd) values (@b2)", bgl.baglanti());

            komut.Parameters.AddWithValue("@b2", TxtAd.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Brans Eklenildi.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Delete from Tbl_Branslar where Bransid=@b1", bgl.baglanti());

            komut2.Parameters.AddWithValue("@b1", Txtid.Text);

            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Brans Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update Tbl_branslar set BransAd=@k1 where Bransid=@k2", bgl.baglanti());

            komut3.Parameters.AddWithValue("@k1", TxtAd.Text);
            komut3.Parameters.AddWithValue("@k2", Txtid.Text);

            komut3.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show("Brans Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
