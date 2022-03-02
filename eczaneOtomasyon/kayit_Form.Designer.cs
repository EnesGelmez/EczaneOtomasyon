namespace eczaneOtomasyon
{
    partial class kayit_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_id = new System.Windows.Forms.TextBox();
            this.txt_ad = new System.Windows.Forms.TextBox();
            this.txt_soyad = new System.Windows.Forms.TextBox();
            this.txt_eczaneid = new System.Windows.Forms.TextBox();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.giris_Kayitol = new System.Windows.Forms.Button();
            this.chk_sifrekontrol = new System.Windows.Forms.CheckBox();
            this.txt_giris_eposta = new System.Windows.Forms.TextBox();
            this.txt_giris_telefon = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmb_kayit_unvan = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_id
            // 
            this.txt_id.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_id.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_id.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_id.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_id.ForeColor = System.Drawing.Color.White;
            this.txt_id.Location = new System.Drawing.Point(100, 84);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(159, 25);
            this.txt_id.TabIndex = 0;
            this.txt_id.Text = "Personel İD";
            this.txt_id.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_id_MouseClick);
            // 
            // txt_ad
            // 
            this.txt_ad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_ad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_ad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_ad.ForeColor = System.Drawing.Color.White;
            this.txt_ad.Location = new System.Drawing.Point(100, 126);
            this.txt_ad.Name = "txt_ad";
            this.txt_ad.Size = new System.Drawing.Size(159, 25);
            this.txt_ad.TabIndex = 1;
            this.txt_ad.Text = "Ad";
            this.txt_ad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_ad_MouseClick);
            // 
            // txt_soyad
            // 
            this.txt_soyad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_soyad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_soyad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_soyad.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_soyad.ForeColor = System.Drawing.Color.White;
            this.txt_soyad.Location = new System.Drawing.Point(100, 163);
            this.txt_soyad.Name = "txt_soyad";
            this.txt_soyad.Size = new System.Drawing.Size(159, 25);
            this.txt_soyad.TabIndex = 2;
            this.txt_soyad.Text = "Soyad";
            this.txt_soyad.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_soyad_MouseClick);
            // 
            // txt_eczaneid
            // 
            this.txt_eczaneid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_eczaneid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_eczaneid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_eczaneid.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_eczaneid.ForeColor = System.Drawing.Color.White;
            this.txt_eczaneid.Location = new System.Drawing.Point(100, 243);
            this.txt_eczaneid.Name = "txt_eczaneid";
            this.txt_eczaneid.Size = new System.Drawing.Size(159, 25);
            this.txt_eczaneid.TabIndex = 4;
            this.txt_eczaneid.Text = "Eczane İD";
            this.txt_eczaneid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_eczaneid_MouseClick);
            // 
            // txt_sifre
            // 
            this.txt_sifre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_sifre.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_sifre.ForeColor = System.Drawing.Color.White;
            this.txt_sifre.Location = new System.Drawing.Point(100, 283);
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(159, 25);
            this.txt_sifre.TabIndex = 5;
            this.txt_sifre.Text = "Şifre";
            this.txt_sifre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_sifre_MouseClick);
            // 
            // giris_Kayitol
            // 
            this.giris_Kayitol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.giris_Kayitol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(22)))), ((int)(((byte)(31)))));
            this.giris_Kayitol.FlatAppearance.BorderSize = 0;
            this.giris_Kayitol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giris_Kayitol.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giris_Kayitol.ForeColor = System.Drawing.Color.White;
            this.giris_Kayitol.Location = new System.Drawing.Point(133, 396);
            this.giris_Kayitol.Name = "giris_Kayitol";
            this.giris_Kayitol.Size = new System.Drawing.Size(122, 40);
            this.giris_Kayitol.TabIndex = 8;
            this.giris_Kayitol.Text = "KAYDET";
            this.giris_Kayitol.UseVisualStyleBackColor = false;
            this.giris_Kayitol.Click += new System.EventHandler(this.giris_Kayitol_Click);
            // 
            // chk_sifrekontrol
            // 
            this.chk_sifrekontrol.AutoSize = true;
            this.chk_sifrekontrol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(46)))), ((int)(((byte)(42)))));
            this.chk_sifrekontrol.Location = new System.Drawing.Point(249, 289);
            this.chk_sifrekontrol.Name = "chk_sifrekontrol";
            this.chk_sifrekontrol.Size = new System.Drawing.Size(15, 14);
            this.chk_sifrekontrol.TabIndex = 10;
            this.chk_sifrekontrol.UseVisualStyleBackColor = false;
            this.chk_sifrekontrol.CheckedChanged += new System.EventHandler(this.chk_sifrekontrol_CheckedChanged);
            // 
            // txt_giris_eposta
            // 
            this.txt_giris_eposta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_giris_eposta.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_giris_eposta.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_giris_eposta.ForeColor = System.Drawing.Color.White;
            this.txt_giris_eposta.Location = new System.Drawing.Point(99, 323);
            this.txt_giris_eposta.Name = "txt_giris_eposta";
            this.txt_giris_eposta.Size = new System.Drawing.Size(159, 25);
            this.txt_giris_eposta.TabIndex = 6;
            this.txt_giris_eposta.Text = "E-Posta";
            this.txt_giris_eposta.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_giris_eposta_MouseClick);
            // 
            // txt_giris_telefon
            // 
            this.txt_giris_telefon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_giris_telefon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_giris_telefon.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_giris_telefon.ForeColor = System.Drawing.Color.White;
            this.txt_giris_telefon.Location = new System.Drawing.Point(99, 363);
            this.txt_giris_telefon.Name = "txt_giris_telefon";
            this.txt_giris_telefon.Size = new System.Drawing.Size(159, 25);
            this.txt_giris_telefon.TabIndex = 7;
            this.txt_giris_telefon.Text = "Telefon";
            this.txt_giris_telefon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_giris_telefon_MouseClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(22)))), ((int)(((byte)(31)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(8, 396);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "GERİ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cmb_kayit_unvan
            // 
            this.cmb_kayit_unvan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.cmb_kayit_unvan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_kayit_unvan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmb_kayit_unvan.ForeColor = System.Drawing.Color.White;
            this.cmb_kayit_unvan.FormattingEnabled = true;
            this.cmb_kayit_unvan.Items.AddRange(new object[] {
            "Müdür",
            "Eczacı",
            "Depocu"});
            this.cmb_kayit_unvan.Location = new System.Drawing.Point(95, 201);
            this.cmb_kayit_unvan.Name = "cmb_kayit_unvan";
            this.cmb_kayit_unvan.Size = new System.Drawing.Size(163, 28);
            this.cmb_kayit_unvan.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::eczaneOtomasyon.Properties.Resources.son0000;
            this.pictureBox1.Location = new System.Drawing.Point(-4, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(266, 443);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // kayit_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 440);
            this.Controls.Add(this.cmb_kayit_unvan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_giris_telefon);
            this.Controls.Add(this.txt_giris_eposta);
            this.Controls.Add(this.chk_sifrekontrol);
            this.Controls.Add(this.giris_Kayitol);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.txt_eczaneid);
            this.Controls.Add(this.txt_soyad);
            this.Controls.Add(this.txt_ad);
            this.Controls.Add(this.txt_id);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "kayit_Form";
            this.Text = "MEE Eczanesi - Kayıt";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.kayit_Form_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.TextBox txt_ad;
        private System.Windows.Forms.TextBox txt_soyad;
        private System.Windows.Forms.TextBox txt_eczaneid;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.Button giris_Kayitol;
        private System.Windows.Forms.CheckBox chk_sifrekontrol;
        private System.Windows.Forms.TextBox txt_giris_eposta;
        private System.Windows.Forms.TextBox txt_giris_telefon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmb_kayit_unvan;
    }
}