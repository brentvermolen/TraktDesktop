using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraktDesktop.Dialogs
{
    public partial class KiesArchief : Form
    {
        public DataAccessClass DAC;
        public dtsAlles dtsAlles1;

        public int ArchiefID;

        public KiesArchief(DataAccessClass DAC, dtsAlles dtsAlles)
        {
            InitializeComponent();

            this.DAC = DAC;
            dtsAlles1 = dtsAlles;
        }

        private void KiesArchief_Load(object sender, EventArgs e)
        {
            lstArchieven.DataSource = DAC.ArchiefTA.GetData().OrderBy(a => a.Naam).ToList();
            lstArchieven.DisplayMember = "Naam";
            lstArchieven.ValueMember = "ID";
        }

        private void lstSeries_DoubleClick(object sender, EventArgs e)
        {
            Selecteer();
        }

        private void btnSelecteer_Click(object sender, EventArgs e)
        {
            Selecteer();
        }

        private void Selecteer()
        {
            this.ArchiefID = (int)lstArchieven.SelectedValue;
            this.DialogResult = DialogResult.OK;
        }
    }
}
