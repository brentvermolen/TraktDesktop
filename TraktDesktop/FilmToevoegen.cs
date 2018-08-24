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

namespace TraktDesktop
{
    public partial class FilmToevoegen : Form
    {
        public int filmId;

        public FilmToevoegen(int filmId)
        {
            InitializeComponent();

            this.filmId = filmId;
        }

        private void FilmToevoegen_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();


            /*bw.DoWork += new DoWorkEventHandler((obj, args) =>
            {
                string request = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&language=en-EN&append_to_response=videos", filmId, ApiKey.MovieDB);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var json = client.DownloadString(request);
                    JObject obje = JObject.Parse(json);
                    Film film = obje.ToObject<Film>();
                    try
                    {
                        film.CollectieID = (int)obje.SelectToken("belongs_to_collection.id");
                    }
                    catch (Exception) { film.CollectieID = 0; }

                    if (CollectieMng.ReadCollectie(film.CollectieID) == null)
                    {
                        json = client.DownloadString(string.Format("https://api.themoviedb.org/3/collection/{0}?api_key={1}", film.CollectieID, ApiKey.MovieDB));
                        obje = JObject.Parse(json);

                        Collectie collectie = obje.ToObject<Collectie>(new JsonSerializer() { NullValueHandling = NullValueHandling.Ignore });
                        CollectieMng.AddCollectie(collectie);

                        foreach (var f in obje.SelectToken("parts"))
                        {
                            Film filmDb = FilmMng.ReadFilm((int)f.SelectToken("id"));

                            if (filmDb != null)
                            {
                                filmDb.CollectieID = film.CollectieID;
                                FilmMng.ChangeFilm(filmDb);
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

                    film.Tags = new List<Tag>();

                    foreach (var genre in obje.SelectToken("genres"))
                    {
                        Tag tag = FilmMng.ReadTag((string)genre.SelectToken("name"));

                        film.Tags.Add(tag);
                    }

                    string nlOmsch = (string)obje.SelectToken("overview");
                    string nlTagline = (string)obje.SelectToken("tagline");
                    string nlTrailer = null;

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

                    FilmMng.AddFilm(film);

                    using (WebClient clientActeurs = new WebClient())
                    {
                        request = string.Format("https://api.themoviedb.org/3/movie/{0}/credits?api_key={1}", film.ID, ApiKey.MovieDB);
                        clientActeurs.Encoding = Encoding.UTF8;
                        json = client.DownloadString(request);

                        obje = JObject.Parse(json);
                        film.Acteurs = new List<ActeurFilm>();
                        foreach (var acteur in obje.SelectToken("cast"))
                        {
                            if ((int)acteur.SelectToken("order") < 15)
                            {
                                int acteurId = (int)acteur.SelectToken("id");
                                Acteur a = ActeurMng.ReadActeur(acteurId);

                                if (a == null)
                                {
                                    a = new Acteur
                                    {
                                        ID = acteurId,
                                        Naam = (string)acteur.SelectToken("name"),
                                        ImagePath = (string)acteur.SelectToken("profile_path")
                                    };

                                    ActeurMng.AddActeur(a);
                                }

                                ActeurFilm acteurFilm = new ActeurFilm()
                                {
                                    ActeurID = acteurId,
                                    FilmID = film.ID,
                                    Sort = (int)acteur.SelectToken("order"),
                                    Karakter = (string)acteur.SelectToken("character")
                                };

                                film.Acteurs.Add(acteurFilm);
                            }
                        }
                    }
                }
            });*/

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, args) =>
            {

            });

            bw.RunWorkerAsync();
        }
    }
}
