namespace eczaneOtomasyon
{
    partial class giris_Form
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
            this.components = new System.ComponentModel.Container();
            this.txt_giris_personelid = new System.Windows.Forms.TextBox();
            this.giris_giris = new System.Windows.Forms.Button();
            this.giris_Kayitol = new System.Windows.Forms.Button();
            this.txt_giris_sifre = new System.Windows.Forms.TextBox();
            this.chk_sifrekontrol = new System.Windows.Forms.CheckBox();
            this.tmr_giris = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_giris_personelid
            // 
            this.txt_giris_personelid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_giris_personelid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_giris_personelid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_giris_personelid.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_giris_personelid.ForeColor = System.Drawing.Color.White;
            this.txt_giris_personelid.Location = new System.Drawing.Point(92, 212);
            this.txt_giris_personelid.Name = "txt_giris_personelid";
            this.txt_giris_personelid.Size = new System.Drawing.Size(159, 25);
            this.txt_giris_personelid.TabIndex = 0;
            this.txt_giris_personelid.Text = "Personel İD";
            this.txt_giris_personelid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.giris_Ad_MouseClick);
            this.txt_giris_personelid.MarginChanged += new System.EventHandler(this.giris_Ad_MarginChanged);
            this.txt_giris_personelid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_giris_personelid_KeyDown);
            // 
            // giris_giris
            // 
            this.giris_giris.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.giris_giris.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(78)))), ((int)(((byte)(91)))));
            this.giris_giris.FlatAppearance.BorderSize = 0;
            this.giris_giris.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giris_giris.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giris_giris.ForeColor = System.Drawing.Color.White;
            this.giris_giris.Location = new System.Drawing.Point(91, 328);
            this.giris_giris.Name = "giris_giris";
            this.giris_giris.Size = new System.Drawing.Size(146, 33);
            this.giris_giris.TabIndex = 2;
            this.giris_giris.Text = "GİRİŞ";
            this.giris_giris.UseVisualStyleBackColor = false;
            this.giris_giris.Click += new System.EventHandler(this.giris_giris_Click);
            // 
            // giris_Kayitol
            // 
            this.giris_Kayitol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.giris_Kayitol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(22)))), ((int)(((byte)(31)))));
            this.giris_Kayitol.FlatAppearance.BorderSize = 0;
            this.giris_Kayitol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.giris_Kayitol.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.giris_Kayitol.ForeColor = System.Drawing.Color.White;
            this.giris_Kayitol.Location = new System.Drawing.Point(91, 381);
            this.giris_Kayitol.Name = "giris_Kayitol";
            this.giris_Kayitol.Size = new System.Drawing.Size(146, 33);
            this.giris_Kayitol.TabIndex = 3;
            this.giris_Kayitol.Text = "KAYIT EKLE";
            this.giris_Kayitol.UseVisualStyleBackColor = false;
            this.giris_Kayitol.Click += new System.EventHandler(this.giris_Kayitol_Click);
            // 
            // txt_giris_sifre
            // 
            this.txt_giris_sifre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_giris_sifre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(46)))), ((int)(((byte)(43)))));
            this.txt_giris_sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_giris_sifre.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_giris_sifre.ForeColor = System.Drawing.Color.White;
            this.txt_giris_sifre.Location = new System.Drawing.Point(92, 276);
            this.txt_giris_sifre.Name = "txt_giris_sifre";
            this.txt_giris_sifre.Size = new System.Drawing.Size(159, 25);
            this.txt_giris_sifre.TabIndex = 1;
            this.txt_giris_sifre.Text = "Şifre";
            this.txt_giris_sifre.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_giris_sifre_MouseClick);
            this.txt_giris_sifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_giris_sifre_KeyDown);
            // 
            // chk_sifrekontrol
            // 
            this.chk_sifrekontrol.AutoSize = true;
            this.chk_sifrekontrol.Location = new System.Drawing.Point(247, 280);
            this.chk_sifrekontrol.Name = "chk_sifrekontrol";
            this.chk_sifrekontrol.Size = new System.Drawing.Size(15, 14);
            this.chk_sifrekontrol.TabIndex = 4;
            this.chk_sifrekontrol.UseVisualStyleBackColor = true;
            this.chk_sifrekontrol.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tmr_giris
            // 
            this.tmr_giris.Tick += new System.EventHandler(this.tmr_giris_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::eczaneOtomasyon.Properties.Resources.arkaplan;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 440);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // giris_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(46)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(263, 440);
            this.Controls.Add(this.chk_sifrekontrol);
            this.Controls.Add(this.giris_Kayitol);
            this.Controls.Add(this.giris_giris);
            this.Controls.Add(this.txt_giris_sifre);
            this.Controls.Add(this.txt_giris_personelid);
            this.Controls.Add(this.pictureBox1);
            this.HelpButton = true;
            this.Name = "giris_Form";
            this.Text = "MEE Eczanesi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.giris_Form_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.giris_Form_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txt_giris_personelid;
        private System.Windows.Forms.Button giris_giris;
        private System.Windows.Forms.Button giris_Kayitol;
        private System.Windows.Forms.TextBox txt_giris_sifre;
        private System.Windows.Forms.CheckBox chk_sifrekontrol;
        private System.Windows.Forms.Timer tmr_giris;
    }
}

