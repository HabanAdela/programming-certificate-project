namespace Joc
{
    partial class StatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.dgwStatus = new System.Windows.Forms.DataGridView();
            this.btnRejoaca = new System.Windows.Forms.Button();
            this.btnIesi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // dgwStatus
            // 
            this.dgwStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgwStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwStatus.Location = new System.Drawing.Point(70, 24);
            this.dgwStatus.Name = "dgwStatus";
            this.dgwStatus.Size = new System.Drawing.Size(323, 150);
            this.dgwStatus.TabIndex = 0;
            // 
            // btnRejoaca
            // 
            this.btnRejoaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRejoaca.Location = new System.Drawing.Point(82, 198);
            this.btnRejoaca.Name = "btnRejoaca";
            this.btnRejoaca.Size = new System.Drawing.Size(111, 56);
            this.btnRejoaca.TabIndex = 1;
            this.btnRejoaca.Text = "Rejoaca";
            this.btnRejoaca.UseVisualStyleBackColor = true;
            this.btnRejoaca.Click += new System.EventHandler(this.btnRejoaca_Click);
            // 
            // btnIesi
            // 
            this.btnIesi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnIesi.Location = new System.Drawing.Point(263, 198);
            this.btnIesi.Name = "btnIesi";
            this.btnIesi.Size = new System.Drawing.Size(111, 56);
            this.btnIesi.TabIndex = 2;
            this.btnIesi.Text = "Iesi";
            this.btnIesi.UseVisualStyleBackColor = true;
            this.btnIesi.Click += new System.EventHandler(this.btnIesi_Click);
            // 
            // StatusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(460, 262);
            this.Controls.Add(this.btnIesi);
            this.Controls.Add(this.btnRejoaca);
            this.Controls.Add(this.dgwStatus);
            this.Name = "StatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StatusForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgwStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgwStatus;
        private System.Windows.Forms.Button btnRejoaca;
        private System.Windows.Forms.Button btnIesi;
    }
}