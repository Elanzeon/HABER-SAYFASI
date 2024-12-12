namespace NewsApp
{
    partial class MainForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstNews = new System.Windows.Forms.ListBox();
            this.btnFetchNews = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstNews
            // 
            this.lstNews.FormattingEnabled = true;
            this.lstNews.Location = new System.Drawing.Point(132, 73);
            this.lstNews.Name = "lstNews";
            this.lstNews.Size = new System.Drawing.Size(510, 251);
            this.lstNews.TabIndex = 0;
            this.lstNews.Click += new System.EventHandler(this.btnFetchNews_Click);
            this.lstNews.SelectedIndexChanged += new System.EventHandler(this.lstNews_SelectedIndexChanged);
            // 
            // btnFetchNews
            // 
            this.btnFetchNews.Location = new System.Drawing.Point(39, 286);
            this.btnFetchNews.Name = "btnFetchNews";
            this.btnFetchNews.Size = new System.Drawing.Size(69, 38);
            this.btnFetchNews.TabIndex = 1;
            this.btnFetchNews.Text = "Haberleri Getir";
            this.btnFetchNews.UseVisualStyleBackColor = true;
            this.btnFetchNews.Click += new System.EventHandler(this.btnFetchNews_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.BackColor = System.Drawing.SystemColors.Control;
            this.lblError.Location = new System.Drawing.Point(12, 367);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(0, 13);
            this.lblError.TabIndex = 2;
            this.lblError.Click += new System.EventHandler(this.lblError_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btnFetchNews);
            this.Controls.Add(this.lstNews);
            this.ForeColor = System.Drawing.Color.Red;
            this.Name = "MainForm";
            this.Text = "Haber Sayfası";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstNews;
        private System.Windows.Forms.Button btnFetchNews;
        private System.Windows.Forms.Label lblError;
    }
}

