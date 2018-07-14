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
    public partial class KiesSerie : Form
    {
        public int SerieID = 0;

        public KiesSerie()
        {
            InitializeComponent();
        }

        private void KiesSerie_Load(object sender, EventArgs e)
        {
            dtsSeriesAfleveringenTableAdapters.SeriesTableAdapter adapter = new dtsSeriesAfleveringenTableAdapters.SeriesTableAdapter();
            adapter.Fill(dtsSeriesAfleveringen1.Series);

            lstSeries.DataSource = adapter.GetData().OrderBy(s => s.Naam).ToList();
            lstSeries.DisplayMember = "Naam";
            lstSeries.ValueMember = "ID";
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {

            SerieID = int.Parse(lstSeries.SelectedValue.ToString());
            this.Close();
        }
    }
}
