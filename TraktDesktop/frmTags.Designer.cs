namespace TraktDesktop
{
    partial class frmTags
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
            this.lstTags = new System.Windows.Forms.ListBox();
            this.grpLoading = new System.Windows.Forms.GroupBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblAantal = new System.Windows.Forms.Label();
            this.lblTag = new System.Windows.Forms.Label();
            this.grpLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(12, 12);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(212, 264);
            this.lstTags.TabIndex = 0;
            this.lstTags.SelectedIndexChanged += new System.EventHandler(this.lstTags_SelectedIndexChanged);
            // 
            // grpLoading
            // 
            this.grpLoading.Controls.Add(this.lblLoading);
            this.grpLoading.Controls.Add(this.picLoading);
            this.grpLoading.Location = new System.Drawing.Point(0, 2);
            this.grpLoading.Name = "grpLoading";
            this.grpLoading.Size = new System.Drawing.Size(559, 289);
            this.grpLoading.TabIndex = 9;
            this.grpLoading.TabStop = false;
            this.grpLoading.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Location = new System.Drawing.Point(31, 244);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(502, 23);
            this.lblLoading.TabIndex = 12;
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLoading
            // 
            this.picLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picLoading.Image = global::TraktDesktop.Properties.Resources.loading;
            this.picLoading.Location = new System.Drawing.Point(3, 16);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(553, 270);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.lblAantal);
            this.panel1.Controls.Add(this.lblTag);
            this.panel1.Location = new System.Drawing.Point(230, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(317, 265);
            this.panel1.TabIndex = 10;
            // 
            // lblAantal
            // 
            this.lblAantal.AutoSize = true;
            this.lblAantal.Location = new System.Drawing.Point(12, 32);
            this.lblAantal.Name = "lblAantal";
            this.lblAantal.Size = new System.Drawing.Size(59, 13);
            this.lblAantal.TabIndex = 2;
            this.lblAantal.Text = "aantal films";
            // 
            // lblTag
            // 
            this.lblTag.AutoSize = true;
            this.lblTag.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTag.Location = new System.Drawing.Point(8, 6);
            this.lblTag.Name = "lblTag";
            this.lblTag.Size = new System.Drawing.Size(66, 22);
            this.lblTag.TabIndex = 1;
            this.lblTag.Text = "lblTag";
            // 
            // frmTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 292);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.grpLoading);
            this.Name = "frmTags";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tags";
            this.Load += new System.EventHandler(this.frmTags_Load);
            this.grpLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.GroupBox grpLoading;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTag;
        private System.Windows.Forms.Label lblAantal;
    }
}