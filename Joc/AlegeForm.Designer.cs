namespace Joc
{
    partial class AlegeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlegeForm));
            this.rbSnake = new System.Windows.Forms.RadioButton();
            this.rbCercuri = new System.Windows.Forms.RadioButton();
            this.btnJoc = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // rbSnake
            // 
            this.rbSnake.AutoSize = true;
            this.rbSnake.BackColor = System.Drawing.Color.Transparent;
            this.rbSnake.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbSnake.Location = new System.Drawing.Point(112, 205);
            this.rbSnake.Name = "rbSnake";
            this.rbSnake.Size = new System.Drawing.Size(69, 20);
            this.rbSnake.TabIndex = 0;
            this.rbSnake.TabStop = true;
            this.rbSnake.Text = "Snake";
            this.rbSnake.UseVisualStyleBackColor = false;
            // 
            // rbCercuri
            // 
            this.rbCercuri.AutoSize = true;
            this.rbCercuri.BackColor = System.Drawing.Color.Transparent;
            this.rbCercuri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rbCercuri.Location = new System.Drawing.Point(395, 205);
            this.rbCercuri.Name = "rbCercuri";
            this.rbCercuri.Size = new System.Drawing.Size(74, 20);
            this.rbCercuri.TabIndex = 1;
            this.rbCercuri.TabStop = true;
            this.rbCercuri.Text = "Cercuri";
            this.rbCercuri.UseVisualStyleBackColor = false;
            // 
            // btnJoc
            // 
            this.btnJoc.Location = new System.Drawing.Point(230, 246);
            this.btnJoc.Name = "btnJoc";
            this.btnJoc.Size = new System.Drawing.Size(113, 33);
            this.btnJoc.TabIndex = 2;
            this.btnJoc.Text = "Incepe Jocul";
            this.btnJoc.UseVisualStyleBackColor = true;
            this.btnJoc.Click += new System.EventHandler(this.btnJoc_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 139);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(310, 35);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(242, 139);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // AlegeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(574, 302);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnJoc);
            this.Controls.Add(this.rbCercuri);
            this.Controls.Add(this.rbSnake);
            this.Name = "AlegeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AlegeForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbSnake;
        private System.Windows.Forms.RadioButton rbCercuri;
        private System.Windows.Forms.Button btnJoc;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}