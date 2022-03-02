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
    public partial class giris_Form : Form
    {
        public static string userid, pass;
        MySqlConnection connection = new MySqlConnection();
        MySqlCommand command;
        MySqlDataAdapter data_A;
        MySqlDataReader data_R;
        DataTable data_T;
        DataSet data_S;

        int id_kontrol = 1,sifre_kontrol=1;
        public giris_Form()
        {
            InitializeComponent();
        }

        void connect()
        {
            connection = new MySqlConnection("Server = localhost; Database = meeeczaneotomasyonu; Uid = root; Pwd = '166455';");
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();           
                
            }
        }

        bool checkPass()
        {

            userid = txt_giris_personelid.Text;
            pass = txt_giris_sifre.Text;

            command = new MySqlCommand();
            connect();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM personel where pID='" + userid + "' AND sifre='" + pass + "'";
            data_R = command.ExecuteReader();
            if (data_R.Read())

            {
                return true;
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre", "EMM Eczanesi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

        }
        bool userControl()
        {
            connect();
            command = new MySqlCommand("select pUnvanı from personel where pID='" + txt_giris_personelid.Text + "'", connection);
            data_A = new MySqlDataAdapter(command);
            data_T = new DataTable();
            data_A.Fill(data_T);
            
            try
            {
                string a = data_T.Rows[0]["pUnvanı"].ToString();
                if (a == "Müdür" || a == "müdür")
                {
                    return true;
                    
                }
                else
                {
                    MessageBox.Show("Yetkiniz yok", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen bilgilerinizi doğru giriniz.","UYARI",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            

           
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tmr_giris.Interval = 100;
            tmr_giris.Enabled = true;
        }

        private void giris_giris_Click(object sender, EventArgs e)
        {
            if (checkPass()==true)
            {
                anasayfa_Form girisForm = new anasayfa_Form();
                girisForm.Show();
                this.Hide();
            }    
        }

        private void giris_Kayitol_Click(object sender, EventArgs e)
        {           

            if (checkPass() == true && userControl() == true)
            {
                kayit_Form kayitForm = new kayit_Form();
                kayitForm.Show();
                this.Hide();
            }
        }

        private void giris_Ad_MarginChanged(object sender, EventArgs e)
        {
            
        }

        private void giris_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txt_giris_sifre_MouseClick(object sender, MouseEventArgs e)
        {
            while (sifre_kontrol == 1)
            {
                txt_giris_sifre.Clear();
                txt_giris_sifre.PasswordChar = '*';
                sifre_kontrol++;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_sifrekontrol.Checked)
            {
                txt_giris_sifre.PasswordChar = '\0';
            }
            else
            {
                txt_giris_sifre.PasswordChar = '*';

            }
        }

        private void giris_Form_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txt_giris_sifre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
            {
                if (checkPass() == true)
                {
                    anasayfa_Form girisForm = new anasayfa_Form();
                    girisForm.Show();
                    this.Hide();
                }
            }
        }

        private void txt_giris_personelid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (checkPass() == true)
                {
                    anasayfa_Form girisForm = new anasayfa_Form();
                    girisForm.Show();
                    this.Hide();
                }
            }
           
        }

        private void tmr_giris_Tick(object sender, EventArgs e)
        {
            
        }

        private void giris_Ad_MouseClick(object sender, MouseEventArgs e)
        {
            while (id_kontrol == 1)
            {
                txt_giris_personelid.Clear();
                txt_giris_sifre.PasswordChar = '*';
                
                id_kontrol++;
            }
        }
    }
}
