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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select * From Tbl_Doktorlar where DoktorTC=@p1 and DoktorSifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", MtxtTC.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);


            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())


            {

                
                FrmDoktorDetay fr = new FrmDoktorDetay();

                fr.tc = MtxtTC.Text;

                fr.Show();


            }
            else
            {
                MessageBox.Show("TC yada şifre Haatalı.");
            }

            bgl.baglanti().Close();


        }
    }
}
