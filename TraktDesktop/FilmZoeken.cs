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
    public partial class FilmZoeken : Form
    {
        public string titel;
        public int jaartal;

        public FilmZoeken(string titel, int jaartal)
        {
            InitializeComponent();

            this.titel = titel;
            this.jaartal = jaartal;
        }

        private void FilmZoeken_Load(object sender, EventArgs e)
        {
            grpLoading.BringToFront();

            BackgroundWorker bw = new BackgroundWorker();

            List<GroupBox> toAdd = new List<GroupBox>();

            grpLoading.Visible = true;
            lblLoading.Text = "Film Zoeken";

            bw.DoWork += new DoWorkEventHandler((obj, args) =>
            {
                string request = string.Format("https://api.themoviedb.org/3/search/movie?api_key={0}&query={1}&year={2}", ApiKey.MovieDB, titel, jaartal);

                using (WebClient client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var obje = client.DownloadString(request);
                    var json = JObject.Parse(obje);

                    int startX = 6;
                    int startY = 6;

                    foreach (var result in json.SelectToken("results"))
                    {
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
                            Text = "'" + result.SelectToken("original_title") + "' Toevoegen",
                            Name = result.SelectToken("id").ToString(),
                            Location = new Point(166, 226),
                            Size = new Size(310, 23)
                        };

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
        }
    }
}
