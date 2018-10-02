using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraktDesktop.dtsFilmTagsTableAdapters;

namespace TraktDesktop
{
    public partial class FilmZoeken : Form
    {
        public string titel;
        public int jaartal;

        DataAccessClass DAC;
        dtsAlles dtsAlles1;

        //public FilmsTableAdapter FilmsAdapter;

        public FilmZoeken(DataAccessClass DAC, dtsAlles dtsAlles, string titel, int jaartal)
        {
            InitializeComponent();

            this.DAC = DAC;
            this.dtsAlles1 = dtsAlles;

            this.titel = titel;
            this.jaartal = jaartal;
        }

        private void FilmZoeken_Load(object sender, EventArgs e)
        {
            grpLoading.BringToFront();

            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            List<GroupBox> toAdd = new List<GroupBox>();

            grpLoading.Visible = true;

            bw.ProgressChanged += new ProgressChangedEventHandler((obj, args) =>
            {
                lblLoading.Text = args.UserState.ToString();
            });

            bw.DoWork += new DoWorkEventHandler((obj, args) =>
            {
                //if (FilmsAdapter == null)
                //{
                //    bw.ReportProgress(0, "Films Inladden");
                //    FilmsAdapter = new dtsFilmTagsTableAdapters.FilmsTableAdapter();
                //    FilmsAdapter.Fill(dtsFilmTags1.Films);
                //}

                bw.ReportProgress(0, "Films Zoeken");
                string request = string.Format("https://api.themoviedb.org/3/search/movie?api_key={0}&query={1}&year={2}", ApiKey.MovieDB, titel, jaartal);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var obje = client.DownloadString(request);
                    var json = JObject.Parse(obje);

                    int startX = 6;
                    int startY = 6;

                    int aantal = json.SelectToken("results").Count();
                    int tel = 1;

                    foreach (var result in json.SelectToken("results"))
                    {
                        bw.ReportProgress(0, "Films Zoeken (" + tel++ + "/" + aantal + ")");

                        GroupBox groupBox = new GroupBox()
                        {
                            Text = result.SelectToken("original_title").ToString(),
                            Size = new Size(482, 256),
                            Location = new Point(startX, startY)
                        };
                        startY += 256 + 6;

                        PictureBox picBox = new PictureBox()
                        {
                            ImageLocation = "http://image.tmdb.org/t/p/w154" + result.SelectToken("poster_path").ToString(),
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(154, 230),
                            Location = new Point(6, 19)
                        };
                        groupBox.Controls.Add(picBox);

                        Label lblTitel = new Label()
                        {
                            Text = result.SelectToken("original_title").ToString(),
                            AutoSize = true,
                            Font = new Font("", 12, FontStyle.Bold),
                            Location = new Point(166, 19)
                        };
                        groupBox.Controls.Add(lblTitel);

                        DateTime releaseDate = DateTime.Parse(result.SelectToken("release_date").ToString());
                        Label lblRelease = new Label()
                        {
                            Text = releaseDate.ToString("dd/MM/yyyy"),
                            Location = new Point(166, 45)
                        };
                        groupBox.Controls.Add(lblRelease);

                        Label lblOverview = new Label()
                        {
                            Text = result.SelectToken("overview").ToString(),
                            AutoSize = false,
                            Size = new Size(309, 157),
                            Location = new Point(166, 66)
                        };
                        groupBox.Controls.Add(lblOverview);

                        Button btnToevoegen = new Button()
                        {
                            Name = result.SelectToken("id").ToString(),
                            Location = new Point(166, 226),
                            Size = new Size(310, 23)
                        };

                        if (DAC.FilmsTA.GetData().FirstOrDefault(f => f.ID == int.Parse(btnToevoegen.Name)) == null)
                        {
                            btnToevoegen.Text = "'" + result.SelectToken("original_title") + "' Toevoegen";
                            btnToevoegen.Enabled = true;
                        }
                        else
                        {
                            btnToevoegen.Text = "'" + result.SelectToken("original_title") + "' is al toegevoegd";
                            btnToevoegen.Enabled = false;
                        }

                        btnToevoegen.Click += BtnToevoegen_Click;

                        groupBox.Controls.Add(btnToevoegen);
                        toAdd.Add(groupBox);   
                    }
                }
            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, args) =>
            {
                grpLoading.Visible = false;

                foreach(var group in toAdd)
                {
                    pnlResultaten.Controls.Add(group);
                }
            });

            bw.RunWorkerAsync();
        }

        private void BtnToevoegen_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            int filmId = int.Parse(btnSender.Name);

            BackgroundWorker bw = new BackgroundWorker();

            btnSender.Enabled = false;
            btnSender.Text = "Bezig met toevoegen";

            bw.DoWork += new DoWorkEventHandler((obj, args) =>
            {
                string request = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-EN&append_to_response=videos", filmId, ApiKey.MovieDB);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var json = client.DownloadString(request);
                    JObject obje = JObject.Parse(json);

                    var film = dtsAlles1.Films.NewFilmsRow();
                    film.ID = filmId;
                    try
                    {
                        film.Duur = (int)obje.SelectToken("runtime");
                    }
                    catch (Exception) { film.Duur = 0; }

                    try
                    {
                        film.Tagline = (string)obje.SelectToken("tagline");
                    }
                    catch (Exception) { film.Tagline = ""; }

                    try
                    {
                        film.Omschrijving = (string)obje.SelectToken("overview");
                    }
                    catch (Exception) { film.Omschrijving = ""; }

                    try
                    {
                        film.ReleaseDate = (string)obje.SelectToken("release_date");
                    }
                    catch (Exception) { film.ReleaseDate = DateTime.Today.ToString("dd/MM/yyyy"); }

                    var CollectieID = 0;
                    try
                    {
                        CollectieID = (int)obje.SelectToken("belongs_to_collection.id");
                    }
                    catch (Exception) { }
                    film.CollectieID = CollectieID;

                    if (dtsAlles1.Collecties.FindByID(CollectieID) == null)
                    {
                        json = client.DownloadString(string.Format("https://api.themoviedb.org/3/collection/{0}?api_key={1}", CollectieID, ApiKey.MovieDB));
                        obje = JObject.Parse(json);

                        //CollectieMng.AddCollectie(collectie);
                        dtsAlles.CollectiesRow collectiesRow = dtsAlles1.Collecties.NewCollectiesRow();
                        collectiesRow.ID = CollectieID;
                        collectiesRow.Naam = obje.SelectToken("name").ToString();
                        collectiesRow.PosterPath = obje.SelectToken("poster_path").ToString();

                        dtsAlles1.Collecties.AddCollectiesRow(collectiesRow);
                        DAC.CollectiesTA.Update(dtsAlles1);

                        foreach (var f in obje.SelectToken("parts"))
                        {
                            //Film filmDb = FilmMng.ReadFilm((int)f.SelectToken("id"));
                            var filmDb = dtsAlles1.Films.FindByID((int)f.SelectToken("id"));

                            if (filmDb != null)
                            {
                                filmDb.CollectieID = CollectieID;
                                DAC.FilmsTA.Update(dtsAlles1);
                                //FilmMng.ChangeFilm(filmDb);
                            }
                        }
                    }

                    try
                    {
                        foreach (var video in obje.SelectToken("videos.results"))
                        {
                            if (((string)video.SelectToken("site")).Equals("YouTube"))
                            {
                                film.TrailerId = (string)video.SelectToken("key");

                                if (((string)video.SelectToken("type")).Equals("Trailer"))
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                    film.Toegevoegd = DateTime.Now;

                    request = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=nl-BE&append_to_response=videos", filmId, ApiKey.MovieDB);

                    json = client.DownloadString(request);
                    obje = JObject.Parse(json);

                    try
                    {
                        film.Naam = (string)obje.SelectToken("original_title");
                    }
                    catch (Exception) { }

                    string nlOmsch = (string)obje.SelectToken("overview");
                    string nlTagline = (string)obje.SelectToken("tagline");
                    string nlTrailer = null;

                    try
                    {
                        film.PosterPath = (string)obje.SelectToken("poster_path");
                    }
                    catch (Exception) { film.PosterPath = ""; }

                    foreach (var video in obje.SelectToken("videos.results"))
                    {
                        if (((string)video.SelectToken("site")).Equals("YouTube"))
                        {
                            nlTrailer = (string)video.SelectToken("key");

                            if (((string)video.SelectToken("type")).Equals("Trailer"))
                            {
                                break;
                            }
                        }
                    }

                    if (nlOmsch != null)
                    {
                        if (!nlOmsch.Equals(""))
                        {
                            film.Omschrijving = nlOmsch;
                        }
                    }
                    if (nlTagline != null)
                    {
                        if (!nlTagline.Equals(""))
                        {
                            film.Tagline = nlTagline;
                        }
                    }
                    if (nlTrailer != null)
                    {
                        if (!nlTrailer.Equals(""))
                        {
                            film.TrailerId = nlTrailer;
                        }
                    }

                    //FilmMng.AddFilm(film);
                    
                    dtsAlles1.Films.AddFilmsRow(film);
                    DAC.FilmsTA.Update(dtsAlles1);

                    var aanvraag = dtsAlles1.Aanvraags.FindByFilmId(film.ID);

                    try
                    {
                        DAC.AanvragenTA.Delete(aanvraag.FilmId, aanvraag.AangevraagOp, aanvraag.GebruikerId);
                    }
                    catch (Exception) { }

                    //film.Tags = new List<Tag>();

                    foreach (var genre in obje.SelectToken("genres"))
                    {
                        //Tag tag = FilmMng.ReadTag((string)genre.SelectToken("name"));
                        var tag = dtsAlles1.Tags.FirstOrDefault(t => t.Naam.Equals((string)genre.SelectToken("name")));

                        if (tag == null)
                        {
                            var tagRow = dtsAlles1.Tags.NewTagsRow();
                            tagRow.ID = dtsAlles1.Tags.Max(t => t.ID) + 1;
                            tagRow.Naam = genre.SelectToken("name").ToString();

                            dtsAlles1.Tags.AddTagsRow(tagRow);
                            DAC.TagsTA.Update(dtsAlles1);
                        }

                        var filmTag = dtsAlles1.FilmTags.NewFilmTagsRow();
                        filmTag.Film_ID = film.ID;
                        filmTag.Tag_ID = tag.ID;

                        dtsAlles1.FilmTags.AddFilmTagsRow(filmTag);
                    }

                    DAC.FilmTagsTA.Update(dtsAlles1);

                    using (WebClient clientActeurs = new WebClient())
                    {
                        request = string.Format("https://api.themoviedb.org/3/movie/{0}/credits?api_key={1}", film.ID, ApiKey.MovieDB);
                        clientActeurs.Encoding = Encoding.UTF8;
                        json = client.DownloadString(request);

                        obje = JObject.Parse(json);

                        //film.Acteurs = new List<ActeurFilm>();

                        foreach (var acteur in obje.SelectToken("cast"))
                        {
                            if ((int)acteur.SelectToken("order") < 15)
                            {
                                int acteurId = (int)acteur.SelectToken("id");
                                //Acteur a = ActeurMng.ReadActeur(acteurId);
                                var a = dtsAlles1.Acteurs.FindByID(acteurId);

                                if (a == null)
                                {
                                    a = dtsAlles1.Acteurs.NewActeursRow();

                                    a.ID = acteurId;
                                    a.Naam = (string)acteur.SelectToken("name");
                                    a.ImagePath = (string)acteur.SelectToken("profile_path");

                                    dtsAlles1.Acteurs.AddActeursRow(a);
                                    DAC.ActeursTA.Update(dtsAlles1);
                                }

                                var acteurFilm = dtsAlles1.ActeurFilms.NewActeurFilmsRow();

                                acteurFilm.ActeurID = acteurId;
                                acteurFilm.FilmID = film.ID;
                                acteurFilm.Sort = (int)acteur.SelectToken("order");
                                acteurFilm.Karakter = (string)acteur.SelectToken("character");

                                dtsAlles1.ActeurFilms.AddActeurFilmsRow(acteurFilm);
                                DAC.ActeursFilmsTA.Update(dtsAlles1);
                            }
                        }
                    }
                }
            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, args) =>
            {
                btnSender.Text = "Toevoegen geslaagd";
            });

            bw.RunWorkerAsync();
        }
    }
}
