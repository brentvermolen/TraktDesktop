namespace TraktDesktop
{
    partial class FilmZoeken
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
            this.pnlResultaten = new System.Windows.Forms.Panel();
            this.grpLoading = new System.Windows.Forms.GroupBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.dtsFilmTags1 = new TraktDesktop.dtsFilmTags();
            this.pnlResultaten.SuspendLayout();
            this.grpLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsFilmTags1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlResultaten
            // 
            this.pnlResultaten.AutoScroll = true;
            this.pnlResultaten.Controls.Add(this.grpLoading);
            this.pnlResultaten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlResultaten.Location = new System.Drawing.Point(0, 0);
            this.pnlResultaten.Name = "pnlResultaten";
            this.pnlResultaten.Size = new System.Drawing.Size(509, 450);
            this.pnlResultaten.TabIndex = 0;
            // 
            // grpLoading
            // 
            this.grpLoading.Controls.Add(this.lblLoading);
            this.grpLoading.Controls.Add(this.picLoading);
            this.grpLoading.Location = new System.Drawing.Point(0, 0);
            this.grpLoading.Name = "grpLoading";
            this.grpLoading.Size = new System.Drawing.Size(509, 450);
            this.grpLoading.TabIndex = 9;
            this.grpLoading.TabStop = false;
            this.grpLoading.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Location = new System.Drawing.Point(11, 348);
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
            this.picLoading.Size = new System.Drawing.Size(503, 431);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // dtsFilmTags1
            // 
            this.dtsFilmTags1.DataSetName = "dtsFilmTags";
            this.dtsFilmTags1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FilmZoeken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 450);
            this.Controls.Add(this.pnlResultaten);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FilmZoeken";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Film Zoeken";
            this.Load += new System.EventHandler(this.FilmZoeken_Load);
            this.pnlResultaten.ResumeLayout(false);
            this.grpLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsFilmTags1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlResultaten;
        private System.Windows.Forms.GroupBox grpLoading;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox picLoading;
        private dtsFilmTags dtsFilmTags1;
    }
}