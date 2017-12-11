namespace Emlakci
{
    partial class Form1
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
            this.btnSite = new System.Windows.Forms.Button();
            this.yoneticibtn = new System.Windows.Forms.Button();
            this.DaireSahibibtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSite
            // 
            this.btnSite.Location = new System.Drawing.Point(147, 90);
            this.btnSite.Name = "btnSite";
            this.btnSite.Size = new System.Drawing.Size(310, 92);
            this.btnSite.TabIndex = 0;
            this.btnSite.Text = "Siteler";
            this.btnSite.UseVisualStyleBackColor = true;
            this.btnSite.Click += new System.EventHandler(this.button1_Click);
            // 
            // yoneticibtn
            // 
            this.yoneticibtn.Location = new System.Drawing.Point(147, 188);
            this.yoneticibtn.Name = "yoneticibtn";
            this.yoneticibtn.Size = new System.Drawing.Size(310, 102);
            this.yoneticibtn.TabIndex = 1;
            this.yoneticibtn.Text = "Yöneticiler";
            this.yoneticibtn.UseVisualStyleBackColor = true;
            this.yoneticibtn.Click += new System.EventHandler(this.yoneticibtn_Click);
            // 
            // DaireSahibibtn
            // 
            this.DaireSahibibtn.Location = new System.Drawing.Point(147, 296);
            this.DaireSahibibtn.Name = "DaireSahibibtn";
            this.DaireSahibibtn.Size = new System.Drawing.Size(310, 102);
            this.DaireSahibibtn.TabIndex = 2;
            this.DaireSahibibtn.Text = "Daire Sahipleri";
            this.DaireSahibibtn.UseVisualStyleBackColor = true;
            this.DaireSahibibtn.Click += new System.EventHandler(this.DaireSahibibtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 546);
            this.Controls.Add(this.DaireSahibibtn);
            this.Controls.Add(this.yoneticibtn);
            this.Controls.Add(this.btnSite);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSite;
        private System.Windows.Forms.Button yoneticibtn;
        private System.Windows.Forms.Button DaireSahibibtn;
    }
}

