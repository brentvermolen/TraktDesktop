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
        public DataAccessClass DAC;
        public dtsAlles dtsAlles1;

        public int SerieID = 0;

        public KiesSerie(DataAccessClass DAC, dtsAlles dtsAlles)
        {
            InitializeComponent();

            this.DAC = DAC;
            dtsAlles1 = dtsAlles;
        }

        private void KiesSerie_Load(object sender, EventArgs e)
        {
            lstSeries.DataSource = DAC.SeriesTA.GetData().OrderBy(s => s.Naam).ToList();
            lstSeries.DisplayMember = "Naam";
            lstSeries.ValueMember = "ID";
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            Selecteer();
        }

        private void lstSeries_DoubleClick(object sender, EventArgs e)
        {
            Selecteer();
        }

        private void Selecteer()
        {
            SerieID = int.Parse(lstSeries.SelectedValue.ToString());
            this.DialogResult = DialogResult.OK;
        }
    }
}
