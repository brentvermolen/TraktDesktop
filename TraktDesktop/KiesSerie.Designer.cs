namespace TraktDesktop
{
    partial class KiesSerie
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
            this.lstSeries = new System.Windows.Forms.ListBox();
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.dtsSeriesAfleveringen1 = new TraktDesktop.dtsSeriesAfleveringen();
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstSeries
            // 
            this.lstSeries.FormattingEnabled = true;
            this.lstSeries.Location = new System.Drawing.Point(12, 12);
            this.lstSeries.Name = "lstSeries";
            this.lstSeries.Size = new System.Drawing.Size(269, 407);
            this.lstSeries.TabIndex = 0;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.Location = new System.Drawing.Point(166, 428);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(115, 23);
            this.btnSelecteer.TabIndex = 1;
            this.btnSelecteer.Text = "Selecteer";
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // dtsSeriesAfleveringen1
            // 
            this.dtsSeriesAfleveringen1.DataSetName = "dtsSeriesAfleveringen";
            this.dtsSeriesAfleveringen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // KiesSerie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 463);
            this.Controls.Add(this.btnSelecteer);
            this.Controls.Add(this.lstSeries);
            this.Name = "KiesSerie";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kies Serie";
            this.Load += new System.EventHandler(this.KiesSerie_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstSeries;
        private System.Windows.Forms.Button btnSelecteer;
        private dtsSeriesAfleveringen dtsSeriesAfleveringen1;
    }
}