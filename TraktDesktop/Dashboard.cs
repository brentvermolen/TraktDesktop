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
using System.Net;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using TraktDesktop.Dialogs;

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
        /*private dtsSeriesAfleveringenTableAdapters.SeriesTableAdapter SeriesAdapter;
        private dtsSeriesAfleveringenTableAdapters.AfleveringsTableAdapter AfleveringenAdpater;

        private dtsFilmTagsTableAdapters.FilmsTableAdapter FilmsAdapter;
        private dtsFilmTagsTableAdapters.FilmTagsTableAdapter FilmTagsAdapter;
        private dtsFilmTagsTableAdapters.TagsTableAdapter TagsAdapter;*/
        
        private DataAccessClass DAC;
        private dtsAlles dtsAlles1;

        public Dashboard(DataAccessClass DAC, dtsAlles dtsAlles)
        {
            InitializeComponent();

            this.DAC = DAC;
            this.dtsAlles1 = dtsAlles;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            grpLoading.BringToFront();
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

                /*if (AfleveringenAdpater == null)
                {
                    AfleveringenAdpater = new dtsSeriesAfleveringenTableAdapters.AfleveringsTableAdapter();
                    AfleveringenAdpater.Fill(dtsSeriesAfleveringen1.Afleverings);
                }*/

                worker.ReportProgress(0, "Serie kiezen");

                KiesSerie frm = new KiesSerie();
                frm.ShowDialog();

                int serieId = frm.SerieID;

                worker.ReportProgress(0, "Afleveringen zoeken");

                var afleveringen = DAC.AfleveringenTA.GetData().Where(a => a.SerieID == serieId);

                worker.ReportProgress(0, "Bestanden wijzigen");

                SearchInFolder(dirFolder, serieId, afleveringen);
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

        private void SearchInFolder(DirectoryInfo dirFolder, int serieId, EnumerableRowCollection<dtsAlles.AfleveringsRow> afleveringen)
        {
            foreach (var folder in dirFolder.GetDirectories())
            {
                SearchInFolder(folder, serieId, afleveringen);
            }

            foreach (var file in dirFolder.GetFiles())
            {
                string regex = "[sS]{0,1}([0-9]{1,2})[eExX]{1}([0-9]{1,2})";
                string regex2 = "([0-9]{1})([0-9]{2})";
                string regex3 = "[sS]{1}([0-9]{1,2})[eExX]{1}[ ][(]([0-9]{1,2})[)]";

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
                    else if (Regex.IsMatch(bestand.Name, regex3))
                    {
                        Match match = Regex.Match(bestand.Name, regex3);

                        MoveBestand(afleveringen, bestand, match);
                    }
                }
            }
        }

        private void MoveBestand(EnumerableRowCollection<dtsAlles.AfleveringsRow> afleveringen, FileInfo bestand, Match match)
        {
            int seizoen = int.Parse(match.Groups[1].Value);
            int afl = int.Parse(match.Groups[2].Value);

            var aflevering = afleveringen.FirstOrDefault(a => a.Seizoen == seizoen && a.Nummer == afl);

            if (aflevering != null)
            {
                string newName = "Afl. " + aflevering.Nummer + " - " + aflevering.Naam.Replace(":", " -");
                string fullName = bestand.FullName.Replace(bestand.Name, newName + bestand.Extension);

                if (File.Exists(fullName) == false)
                {
                    bestand.MoveTo(fullName);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker worker = new BackgroundWorker();

            grpLoading.Visible = true;

            worker.WorkerReportsProgress = true;
            worker.DoWork += new DoWorkEventHandler((obj, d) =>
            {
                worker.ReportProgress(0, "Films inladen");

                /*if (FilmsAdapter == null)
                {
                    FilmsAdapter = new dtsFilmTagsTableAdapters.FilmsTableAdapter();
                    FilmsAdapter.Fill(dtsFilmTags1.Films);
                }*/

                worker.ReportProgress(0, "Tags inladen");

                /*if (TagsAdapter == null)
                {
                    TagsAdapter = new dtsFilmTagsTableAdapters.TagsTableAdapter();
                    TagsAdapter.Fill(dtsFilmTags1.Tags);
                }*/

                worker.ReportProgress(0, "Film Tags inladen");

                /*if (FilmTagsAdapter == null)
                {
                    FilmTagsAdapter = new dtsFilmTagsTableAdapters.FilmTagsTableAdapter();
                    FilmTagsAdapter.Fill(dtsFilmTags1.FilmTags);
                }*/

                foreach (var film in DAC.FilmsTA.GetData().OrderBy(f => f.Naam))
                {
                    worker.ReportProgress(0, film.Naam);

                    var filmTagList = DAC.FilmTagsTA.GetData().Where(t => t.Film_ID == film.ID);

                    using (WebClient client = new WebClient())
                    {
                        client.Encoding = Encoding.UTF8;

                        var success = false;

                        do
                        {
                            try
                            {
                                var json = client.DownloadString(string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=nl-BE", film.ID, ApiKey.MovieDB));
                                var jobject = JObject.Parse(json);

                                success = true;

                                foreach (var genre in jobject.SelectToken("genres"))
                                {
                                    var naam = genre.SelectToken("name").ToString();
                                    worker.ReportProgress(0, film.Naam + " - " + naam);

                                    var tag = DAC.TagsTA.GetData().FirstOrDefault(t => t.Naam.Equals(naam));
                                    if (tag == null)
                                    {
                                        var maxId = DAC.TagsTA.GetData().Max(t => t.ID) + 1;
                                        dtsAlles.TagsRow tagsRow = dtsAlles1.Tags.NewTagsRow();
                                        tagsRow.ID = maxId;
                                        tagsRow.Naam = naam;

                                        tag = tagsRow;
                                        dtsFilmTags1.Tags.Rows.Add(tagsRow);
                                    }

                                    if (filmTagList.FirstOrDefault(t => t.Tag_ID == tag.ID) == null)
                                    {
                                        dtsFilmTags.FilmTagsRow filmTagsRow = dtsFilmTags1.FilmTags.NewFilmTagsRow();
                                        filmTagsRow.Film_ID = film.ID;
                                        filmTagsRow.Tag_ID = tag.ID;

                                        dtsFilmTags1.FilmTags.Rows.Add(filmTagsRow);
                                    }
                                }

                                worker.ReportProgress(0, film.Naam + " opslaan");

                                DAC.TagsTA.Update(dtsAlles1);
                                DAC.FilmTagsTA.Update(dtsAlles1);
                            }
                            catch (Exception)
                            {
                                success = false;
                                System.Threading.Thread.Sleep(1000);
                            }
                        } while (success == false);
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

        private void btnOmzettenMKV_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                BackgroundWorker worker = new BackgroundWorker();

                grpLoading.Visible = true;
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler((obj, d) =>
                {
                    leesFolder(new DirectoryInfo(fbd.SelectedPath), worker);
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

        private void leesFolder(DirectoryInfo folder, BackgroundWorker worker)
        {
            FileInfo ondertitelFile = folder.GetFiles().Where(f => f.Extension.ToLower().Equals(".srt")).FirstOrDefault();
            if (folder.GetFiles().Length == 2 && folder.GetDirectories().Length == 0 && ondertitelFile != null)
            {
                FileInfo movieFile = folder.GetFiles().Where(f => !f.Extension.ToLower().Equals(".srt")).FirstOrDefault();
                worker.ReportProgress(0, movieFile.Name);

                if (movieFile != null)
                {
                    try
                    {
                        string nieuwBestand = movieFile.DirectoryName + "//" + movieFile.Name.Replace(movieFile.Extension, "") + ".mkv";

                        if (movieFile.Extension.Equals(".mkv"))
                        {
                            movieFile.MoveTo(movieFile.DirectoryName + "//" + movieFile.Name.Replace(movieFile.Extension, "") + " - kopie" + movieFile.Extension);
                        }

                        string oudBestand = movieFile.FullName;

                        string ondertitels = ondertitelFile.FullName;

                        string command = string.Format("-o \"{0}\" \"(\" \"{1}\" \")\" \"-S\" \"(\" \"{2}\" \")\"", nieuwBestand, ondertitels, oudBestand);
                        runCmd(command);
                    }
                    catch (Exception)
                    {
                        using (StreamWriter writer = File.AppendText(@"C:\Users\Brent\Documents\errors.txt"))
                        {
                            writer.WriteLine(movieFile.Name + ": Omzetten naar MKV");
                        }
                    }

                    try
                    {
                        movieFile.Delete();
                    }
                    catch (Exception)
                    {
                        using (StreamWriter writer = File.AppendText(@"C:\Users\Brent\Documents\errors.txt"))
                        {
                            writer.WriteLine(movieFile.Name + ": Verwijderen van originele");
                        }
                    }


                    using (StreamWriter writer = File.AppendText(@"C:\Users\Brent\Documents\done.txt"))
                    {
                        writer.WriteLine(movieFile.Name);
                    }
                }
            }
            else
            {
                if (folder.GetDirectories().Length == 0 && folder.GetFiles().Length != 0)
                {
                    using (StreamWriter writer = File.AppendText(@"C:\Users\Brent\Documents\errors.txt"))
                    {
                        writer.WriteLine(folder.Name + ": Iets mis met inhoud van de map");
                    }
                }
            }

            foreach (var map in folder.GetDirectories())
            {
                leesFolder(map, worker);
            }
        }

        private void runCmd(string command)
        {
            using (Process pProcess = new Process())
            {
                pProcess.StartInfo.FileName = @"C:\Program Files (x86)\MKVToolNix\mkvmerge.exe";
                pProcess.StartInfo.Arguments = command; //argument
                pProcess.StartInfo.UseShellExecute = false;
                pProcess.StartInfo.RedirectStandardOutput = true;
                pProcess.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                pProcess.StartInfo.CreateNoWindow = true; //not diplay a windows
                pProcess.Start();
                string output = pProcess.StandardOutput.ReadToEnd(); //The output result
                pProcess.WaitForExit();
            }
        }

        private void btnFilmUpdaten_Click(object sender, EventArgs e)
        {

        }

        private void btnTags_Click(object sender, EventArgs e)
        {
            frmTags frm = new frmTags(DAC, dtsAlles1);
            frm.ShowDialog();
        }

        private void btnExporteren_Click(object sender, EventArgs e)
        {

        }

        private void btnFilmToevoegen_Click(object sender, EventArgs e)
        {
            InputFilm inputFilm = new InputFilm();
            inputFilm.ShowDialog();

            if (inputFilm.DialogResult == DialogResult.OK)
            {
                FilmZoeken filmToevoegen = new FilmZoeken(DAC, dtsAlles1, inputFilm.Titel, inputFilm.Jaartal);
                filmToevoegen.ShowDialog();
            }
        }
    }
}
