namespace TraktDesktop.Dialogs
{
    partial class KiesArchief
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
            this.btnSelecteer = new System.Windows.Forms.Button();
            this.lstArchieven = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtsSeriesAfleveringen1
            // 
            this.dtsSeriesAfleveringen1.DataSetName = "dtsSeriesAfleveringen";
            this.dtsSeriesAfleveringen1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnSelecteer
            // 
            this.btnSelecteer.Location = new System.Drawing.Point(77, 165);
            this.btnSelecteer.Name = "btnSelecteer";
            this.btnSelecteer.Size = new System.Drawing.Size(115, 23);
            this.btnSelecteer.TabIndex = 3;
            this.btnSelecteer.Text = "Selecteer";
            this.btnSelecteer.UseVisualStyleBackColor = true;
            this.btnSelecteer.Click += new System.EventHandler(this.btnSelecteer_Click);
            // 
            // lstSeries
            // 
            this.lstArchieven.FormattingEnabled = true;
            this.lstArchieven.Location = new System.Drawing.Point(12, 12);
            this.lstArchieven.Name = "lstSeries";
            this.lstArchieven.Size = new System.Drawing.Size(180, 147);
            this.lstArchieven.TabIndex = 2;
            this.lstArchieven.DoubleClick += new System.EventHandler(this.lstSeries_DoubleClick);
            // 
            // KiesArchief
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 197);
            this.Controls.Add(this.btnSelecteer);
            this.Controls.Add(this.lstArchieven);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "KiesArchief";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kies Archief";
            this.Load += new System.EventHandler(this.KiesArchief_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtsSeriesAfleveringen1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private dtsSeriesAfleveringen dtsSeriesAfleveringen1;
        private System.Windows.Forms.Button btnSelecteer;
        private System.Windows.Forms.ListBox lstArchieven;
    }
}