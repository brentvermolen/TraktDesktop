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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        public dtsAlles dtsAlles1 = new dtsAlles();

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            BackgroundWorker bw = new BackgroundWorker();
            bw.WorkerReportsProgress = true;

            DataAccessClass DAC = new DataAccessClass();            

            bw.DoWork += new DoWorkEventHandler((obj, args) =>
            {
                dtsAlles1 = DAC.VulAdapters(bw, dtsAlles1);
            });

            bw.ProgressChanged += new ProgressChangedEventHandler((obj, args) =>
            {
                prgLoading.Value = args.ProgressPercentage;
                lblInfo.Text = args.UserState.ToString() + " inladen";
            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler((obj, args) =>
            {
                Dashboard dashboard = new Dashboard(DAC, dtsAlles1);

                this.Hide();
                dashboard.FormClosing += (o, a) => this.Close();
                dashboard.Show();
            });

            bw.RunWorkerAsync();
        }
    }
}
