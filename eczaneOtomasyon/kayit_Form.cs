using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace eczaneOtomasyon
{
    public partial class kayit_Form : Form
    {

        int sifrei=1;
        
        MySqlConnection connection = new MySqlConnection();
        

        void connect()
        {
            connection = new MySqlConnection("Server = localhost; Database = meeeczaneotomasyonu; Uid = root; Pwd = '166455';");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();          
            }
        }

        void add()
        {
            connect();
            try
            {
                string ekle_sorgu = "insert into personel(pID,pAdi,pSoyadi,pUnvanı,eID,sifre,ePosta,telNo) values ('" + txt_id.Text + "','" + txt_ad.Text + "','" + txt_soyad.Text + "','" + cmb_kayit_unvan.SelectedItem + "','" + txt_eczaneid.Text + "','" + txt_sifre.Text + "','"+txt_giris_eposta.Text+"','"+txt_giris_telefon.Text+"')";
                MySqlCommand komut = new MySqlCommand(ekle_sorgu, connection);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kayıt Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                giris_Form girisForm = new giris_Form();
                girisForm.Show();
                this.Hide();
            }
            catch (Exception e)
            {
                MessageBox.Show("Kayıt Başarısız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public kayit_Form()
        {
            InitializeComponent();
        }

        private void giris_Kayitol_Click(object sender, EventArgs e)
        {
            add();
        }

        private void txt_id_MouseClick(object sender, MouseEventArgs e)
        {
            txt_id.Clear();
            
        }

        private void txt_soyad_MouseClick(object sender, MouseEventArgs e)
        {
            txt_soyad.Clear();
        }

        private void txt_ad_MouseClick(object sender, MouseEventArgs e)
        {
            txt_ad.Clear();
        }

        private void txt_eczaneid_MouseClick(object sender, MouseEventArgs e)
        {
            txt_eczaneid.Clear();
        }

        private void txt_sifre_MouseClick(object sender, MouseEventArgs e)
        {
           
            while (sifrei == 1)
            {
                txt_sifre.Clear();
                txt_sifre.PasswordChar = '*';
                sifrei++; 
            }
        }

        private void chk_sifrekontrol_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sifrekontrol.Checked)
            {
                txt_sifre.PasswordChar = '\0';
            }
            else
            {
                txt_sifre.PasswordChar = '*';

            }
        }

        private void kayit_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txt_giris_eposta_MouseClick(object sender, MouseEventArgs e)
        {
            txt_giris_eposta.Clear();
        }

        private void txt_giris_telefon_MouseClick(object sender, MouseEventArgs e)
        {
            txt_giris_telefon.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris_Form girisForm = new giris_Form();
            girisForm.Show();
            this.Hide();
        }
    }
}
