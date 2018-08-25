using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraktDesktop
{
    public partial class frmTags : Form
    {
        DataAccessClass DAC;
        dtsAlles dtsAlles1;

        public frmTags(DataAccessClass DAC, dtsAlles dtsAlles)
        {
            InitializeComponent();

            this.DAC = DAC;
            this.dtsAlles1 = dtsAlles;
        }

        /*private dtsFilmTagsTableAdapters.TagsTableAdapter TagsAdapter;
        private dtsFilmTagsTableAdapters.FilmsTableAdapter FilmsAdapter;
        private dtsFilmTagsTableAdapters.FilmTagsTableAdapter FilmTagAdapter;*/

        private void frmTags_Load(object sender, EventArgs e)
        {
            grpLoading.BringToFront();
            grpLoading.Visible = true;

            BackgroundWorker worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler((obj, d) =>
            {
                /*worker.ReportProgress(0, "Tags inladen");
                TagsAdapter = new dtsFilmTagsTableAdapters.TagsTableAdapter();
                TagsAdapter.Fill(dtsFilmTags1.Tags);

                worker.ReportProgress(0, "Films inladen");
                FilmsAdapter = new dtsFilmTagsTableAdapters.FilmsTableAdapter();
                FilmsAdapter.Fill(dtsFilmTags1.Films);

                worker.ReportProgress(0, "Films bij juiste tag plaatsen");
                FilmTagAdapter = new dtsFilmTagsTableAdapters.FilmTagsTableAdapter();
                FilmTagAdapter.Fill(dtsFilmTags1.FilmTags);*/
            });

            worker.ProgressChanged += new ProgressChangedEventHandler((obj, p) =>
            {
                lblLoading.Text = p.UserState.ToString();
            });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, r) =>
            {
                grpLoading.Visible = false;

                lstTags.DataSource = DAC.TagsTA.GetData().OrderBy(t => t.Naam).ToList();
                lstTags.DisplayMember = "Naam";
                lstTags.ValueMember = "ID";

                try
                {
                    lstTags.SelectedIndex = 1;
                    lstTags.SelectedIndex = 0;
                }
                catch (Exception xe) { MessageBox.Show(xe.ToString()); }
            });

            worker.RunWorkerAsync();
        }

        private void lstTags_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(lstTags.SelectedValue.ToString(), out int intId) == true)
            {
                lblTag.Text = ((dtsAlles.TagsRow)lstTags.SelectedItem).Naam;

                lblAantal.Text = DAC.FilmTagsTA.GetData().Where(f => f.Tag_ID == intId).Count().ToString() + " films";
            }
        }
    }
}
