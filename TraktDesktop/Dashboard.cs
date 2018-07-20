using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace TraktDesktop
{
    public partial class Dashboard : Form
    {
        /*
           BackgroundWorker worker = new BackgroundWorker();

            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler((obj, d) =>
            {

            });

            worker.ProgressChanged += new ProgressChangedEventHandler((obj, p) =>
            {

            });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, r) =>
            {

            });

            worker.RunWorkerAsync();
         */
        private dtsSeriesAfleveringenTableAdapters.SeriesTableAdapter SeriesAdapter;
        private dtsSeriesAfleveringenTableAdapters.AfleveringsTableAdapter AfleveringenAdpater;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            grpLoading.BringToFront();

            //SeriesAdapter = new dtsSeriesAfleveringenTableAdapters.SeriesTableAdapter();
            //SeriesAdapter.Fill(dtsSeriesAfleveringen1.Series);
        }

        private void MoveBestand(EnumerableRowCollection<dtsSeriesAfleveringen.AfleveringsRow> afleveringen, FileInfo bestand, Match match)
        {
            int seizoen = int.Parse(match.Groups[1].Value);
            int afl = int.Parse(match.Groups[2].Value);

            var aflevering = afleveringen.FirstOrDefault(a => a.Seizoen == seizoen && a.Nummer == afl);

            if (aflevering != null)
            {
                string newName = "Afl. " + aflevering.Nummer + " - " + aflevering.Naam;
                string fullName = bestand.FullName.Replace(bestand.Name, newName + bestand.Extension);

                if (File.Exists(fullName) == false)
                {
                    bestand.MoveTo(fullName);
                }
            }
        }

        private void btnWijzigNamen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            DirectoryInfo dirFolder = new DirectoryInfo(fbd.SelectedPath);

            BackgroundWorker worker = new BackgroundWorker();

            grpLoading.Visible = true;
            worker.WorkerReportsProgress = true;

            worker.DoWork += new DoWorkEventHandler((obj, w) =>
            {
                worker.ReportProgress(0, "Gegevens inladen");

                if (AfleveringenAdpater == null)
                {
                    AfleveringenAdpater = new dtsSeriesAfleveringenTableAdapters.AfleveringsTableAdapter();
                    AfleveringenAdpater.Fill(dtsSeriesAfleveringen1.Afleverings);
                }

                worker.ReportProgress(0, "Serie kiezen");

                KiesSerie frm = new KiesSerie();
                frm.ShowDialog();

                int serieId = frm.SerieID;

                worker.ReportProgress(0, "Afleveringen zoeken");

                var afleveringen = AfleveringenAdpater.GetData().Where(a => a.SerieID == serieId);

                string regex = "[sS]{0,1}([0-9]{1,2})[eExX]{1}([0-9]{1,2})";
                string regex2 = "([0-9]{1})([0-9]{2})";
                string regex3 = "[sS]{1}([0-9]{1,2})[eExX]{1}[ ][(]([0-9]{1,2})[)]";

                worker.ReportProgress(0, "Bestanden wijzigen");

                foreach (FileInfo bestand in dirFolder.GetFiles())
                {
                    if (Regex.IsMatch(bestand.Name, regex))
                    {
                        Match match = Regex.Match(bestand.Name, regex);

                        MoveBestand(afleveringen, bestand, match);
                    }
                    else if (Regex.IsMatch(bestand.Name, regex2))
                    {
                        Match match = Regex.Match(bestand.Name, regex2);

                        MoveBestand(afleveringen, bestand, match);
                    }
                    else if(Regex.IsMatch(bestand.Name, regex3))
                    {
                        Match match = Regex.Match(bestand.Name, regex3);

                        MoveBestand(afleveringen, bestand, match);
                    }
                }
            });

            worker.ProgressChanged += new ProgressChangedEventHandler((obj, p) =>
            {
                lblLoading.Text = p.UserState.ToString();
            });

            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, r) =>
            {
                grpLoading.Visible = false;
            });

            worker.RunWorkerAsync();
        }
    }
}
