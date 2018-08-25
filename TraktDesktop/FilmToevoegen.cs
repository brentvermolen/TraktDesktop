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

        DataAccessClass DAC;
        dtsAlles dtsAlles1;

        public FilmToevoegen(DataAccessClass DAC, dtsAlles dtsAlles, int filmId)
        {
            InitializeComponent();

            this.DAC = DAC;
            this.dtsAlles1 = dtsAlles;

            this.filmId = filmId;
        }

        private void FilmToevoegen_Load(object sender, EventArgs e)
        {
            
        }
    }
}
