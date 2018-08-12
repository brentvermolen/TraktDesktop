namespace TraktDesktop
{
    partial class Dashboard
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
            this.dtsSeriesAfleveringen1 = new TraktDesktop.dtsSeriesAfleveringen();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.btnArchiefVerwijderen = new System.Windows.Forms.Button();
            this.btnBekijkArchief = new System.Windows.Forms.Button();
            this.btnWijzigNamen = new System.Windows.Forms.Button();
            this.btnExporteren = new System.Windows.Forms.Button();
            this.btnTags = new System.Windows.Forms.Button();
            this.btnArchiefToevoegen = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAfleveringenToevoegen = new System.Windows.Forms.Button();
            this.btnSeriesToevoegen = new System.Windows.Forms.Button();
            this.btnFilmToevoegen = new System.Windows.Forms.Button();
            this.btnFilmsToevoegen = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOmzettenMKV = new System.Windows.Forms.Button();
            this.btnCollectieUpdaten = new System.Windows.Forms.Button();
            this.btnAfleveringToevoegen = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpLoading = new System.Windows.Forms.GroupBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dtsFilmTags1 = new TraktDesktop.dtsFilmTags();
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpLoading.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsFilmTags1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtsSeriesAfleveringen1
            // 
            this.dtsSeriesAfleveringen1.DataSetName = "dtsSeriesAfleveringen";
            this.dtsSeriesAfleveringen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // btnArchiefVerwijderen
            // 
            this.btnArchiefVerwijderen.Location = new System.Drawing.Point(22, 132);
            this.btnArchiefVerwijderen.Margin = new System.Windows.Forms.Padding(2);
            this.btnArchiefVerwijderen.Name = "btnArchiefVerwijderen";
            this.btnArchiefVerwijderen.Size = new System.Drawing.Size(214, 30);
            this.btnArchiefVerwijderen.TabIndex = 17;
            this.btnArchiefVerwijderen.Text = "Archief Verwijderen";
            this.btnArchiefVerwijderen.UseVisualStyleBackColor = true;
            // 
            // btnBekijkArchief
            // 
            this.btnBekijkArchief.Location = new System.Drawing.Point(22, 21);
            this.btnBekijkArchief.Margin = new System.Windows.Forms.Padding(2);
            this.btnBekijkArchief.Name = "btnBekijkArchief";
            this.btnBekijkArchief.Size = new System.Drawing.Size(214, 30);
            this.btnBekijkArchief.TabIndex = 15;
            this.btnBekijkArchief.Text = "Archief Wijzigen";
            this.btnBekijkArchief.UseVisualStyleBackColor = true;
            // 
            // btnWijzigNamen
            // 
            this.btnWijzigNamen.Location = new System.Drawing.Point(26, 132);
            this.btnWijzigNamen.Margin = new System.Windows.Forms.Padding(2);
            this.btnWijzigNamen.Name = "btnWijzigNamen";
            this.btnWijzigNamen.Size = new System.Drawing.Size(214, 30);
            this.btnWijzigNamen.TabIndex = 18;
            this.btnWijzigNamen.Text = "Wijzig Bestandnamen";
            this.btnWijzigNamen.UseVisualStyleBackColor = true;
            this.btnWijzigNamen.Click += new System.EventHandler(this.btnWijzigNamen_Click);
            // 
            // btnExporteren
            // 
            this.btnExporteren.Location = new System.Drawing.Point(26, 175);
            this.btnExporteren.Margin = new System.Windows.Forms.Padding(2);
            this.btnExporteren.Name = "btnExporteren";
            this.btnExporteren.Size = new System.Drawing.Size(214, 30);
            this.btnExporteren.TabIndex = 13;
            this.btnExporteren.Text = "Exporteren + Uploaden";
            this.btnExporteren.UseVisualStyleBackColor = true;
            this.btnExporteren.Click += new System.EventHandler(this.btnExporteren_Click);
            // 
            // btnTags
            // 
            this.btnTags.Location = new System.Drawing.Point(26, 21);
            this.btnTags.Margin = new System.Windows.Forms.Padding(2);
            this.btnTags.Name = "btnTags";
            this.btnTags.Size = new System.Drawing.Size(214, 30);
            this.btnTags.TabIndex = 11;
            this.btnTags.Text = "Tags";
            this.btnTags.UseVisualStyleBackColor = true;
            this.btnTags.Click += new System.EventHandler(this.btnTags_Click);
            // 
            // btnArchiefToevoegen
            // 
            this.btnArchiefToevoegen.Location = new System.Drawing.Point(22, 68);
            this.btnArchiefToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnArchiefToevoegen.Name = "btnArchiefToevoegen";
            this.btnArchiefToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnArchiefToevoegen.TabIndex = 14;
            this.btnArchiefToevoegen.Text = "Archief Toevoegen";
            this.btnArchiefToevoegen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnWijzigNamen);
            this.groupBox3.Controls.Add(this.btnExporteren);
            this.groupBox3.Controls.Add(this.btnTags);
            this.groupBox3.Location = new System.Drawing.Point(274, 225);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(258, 210);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Beheer";
            // 
            // btnAfleveringenToevoegen
            // 
            this.btnAfleveringenToevoegen.Location = new System.Drawing.Point(26, 117);
            this.btnAfleveringenToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnAfleveringenToevoegen.Name = "btnAfleveringenToevoegen";
            this.btnAfleveringenToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnAfleveringenToevoegen.TabIndex = 8;
            this.btnAfleveringenToevoegen.Text = "Afleveringen Toevoegen";
            this.btnAfleveringenToevoegen.UseVisualStyleBackColor = true;
            // 
            // btnSeriesToevoegen
            // 
            this.btnSeriesToevoegen.Location = new System.Drawing.Point(26, 17);
            this.btnSeriesToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeriesToevoegen.Name = "btnSeriesToevoegen";
            this.btnSeriesToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnSeriesToevoegen.TabIndex = 4;
            this.btnSeriesToevoegen.Text = "Series Toevoegen";
            this.btnSeriesToevoegen.UseVisualStyleBackColor = true;
            // 
            // btnFilmToevoegen
            // 
            this.btnFilmToevoegen.Location = new System.Drawing.Point(22, 65);
            this.btnFilmToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilmToevoegen.Name = "btnFilmToevoegen";
            this.btnFilmToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnFilmToevoegen.TabIndex = 1;
            this.btnFilmToevoegen.Text = "Film Toevoegen";
            this.btnFilmToevoegen.UseVisualStyleBackColor = true;
            // 
            // btnFilmsToevoegen
            // 
            this.btnFilmsToevoegen.Location = new System.Drawing.Point(22, 17);
            this.btnFilmsToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnFilmsToevoegen.Name = "btnFilmsToevoegen";
            this.btnFilmsToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnFilmsToevoegen.TabIndex = 0;
            this.btnFilmsToevoegen.Text = "Films Toevoegen";
            this.btnFilmsToevoegen.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnArchiefVerwijderen);
            this.groupBox4.Controls.Add(this.btnBekijkArchief);
            this.groupBox4.Controls.Add(this.btnArchiefToevoegen);
            this.groupBox4.Location = new System.Drawing.Point(11, 225);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox4.Size = new System.Drawing.Size(258, 210);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Archief";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOmzettenMKV);
            this.groupBox1.Controls.Add(this.btnCollectieUpdaten);
            this.groupBox1.Controls.Add(this.btnFilmToevoegen);
            this.groupBox1.Controls.Add(this.btnFilmsToevoegen);
            this.groupBox1.Location = new System.Drawing.Point(11, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(258, 210);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Films";
            // 
            // btnOmzettenMKV
            // 
            this.btnOmzettenMKV.Location = new System.Drawing.Point(22, 117);
            this.btnOmzettenMKV.Name = "btnOmzettenMKV";
            this.btnOmzettenMKV.Size = new System.Drawing.Size(214, 30);
            this.btnOmzettenMKV.TabIndex = 10;
            this.btnOmzettenMKV.Text = "Omzetten naar MKV";
            this.btnOmzettenMKV.UseVisualStyleBackColor = true;
            this.btnOmzettenMKV.Click += new System.EventHandler(this.btnOmzettenMKV_Click);
            // 
            // btnCollectieUpdaten
            // 
            this.btnCollectieUpdaten.Location = new System.Drawing.Point(22, 167);
            this.btnCollectieUpdaten.Margin = new System.Windows.Forms.Padding(2);
            this.btnCollectieUpdaten.Name = "btnCollectieUpdaten";
            this.btnCollectieUpdaten.Size = new System.Drawing.Size(214, 30);
            this.btnCollectieUpdaten.TabIndex = 3;
            this.btnCollectieUpdaten.Text = "Collectie Updaten";
            this.btnCollectieUpdaten.UseVisualStyleBackColor = true;
            // 
            // btnAfleveringToevoegen
            // 
            this.btnAfleveringToevoegen.Location = new System.Drawing.Point(26, 167);
            this.btnAfleveringToevoegen.Margin = new System.Windows.Forms.Padding(2);
            this.btnAfleveringToevoegen.Name = "btnAfleveringToevoegen";
            this.btnAfleveringToevoegen.Size = new System.Drawing.Size(214, 30);
            this.btnAfleveringToevoegen.TabIndex = 6;
            this.btnAfleveringToevoegen.Text = "Aflevering Toevoegen";
            this.btnAfleveringToevoegen.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnAfleveringenToevoegen);
            this.groupBox2.Controls.Add(this.btnSeriesToevoegen);
            this.groupBox2.Controls.Add(this.btnAfleveringToevoegen);
            this.groupBox2.Location = new System.Drawing.Point(274, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(258, 210);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Series";
            // 
            // grpLoading
            // 
            this.grpLoading.Controls.Add(this.lblLoading);
            this.grpLoading.Controls.Add(this.picLoading);
            this.grpLoading.Location = new System.Drawing.Point(11, 6);
            this.grpLoading.Name = "grpLoading";
            this.grpLoading.Size = new System.Drawing.Size(521, 429);
            this.grpLoading.TabIndex = 8;
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
            this.picLoading.Size = new System.Drawing.Size(515, 410);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 11;
            this.picLoading.TabStop = false;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(590, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Effe alle tags laden";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dtsFilmTags1
            // 
            this.dtsFilmTags1.DataSetName = "dtsFilmTags";
            this.dtsFilmTags1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 449);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpLoading);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpLoading.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtsFilmTags1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private dtsSeriesAfleveringen dtsSeriesAfleveringen1;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button btnArchiefVerwijderen;
        private System.Windows.Forms.Button btnBekijkArchief;
        private System.Windows.Forms.Button btnWijzigNamen;
        private System.Windows.Forms.Button btnExporteren;
        private System.Windows.Forms.Button btnTags;
        private System.Windows.Forms.Button btnArchiefToevoegen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAfleveringenToevoegen;
        private System.Windows.Forms.Button btnSeriesToevoegen;
        private System.Windows.Forms.Button btnFilmToevoegen;
        private System.Windows.Forms.Button btnFilmsToevoegen;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnAfleveringToevoegen;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox grpLoading;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Button button1;
        private dtsFilmTags dtsFilmTags1;
        private System.Windows.Forms.Button btnOmzettenMKV;
        private System.Windows.Forms.Button btnCollectieUpdaten;
    }
}

