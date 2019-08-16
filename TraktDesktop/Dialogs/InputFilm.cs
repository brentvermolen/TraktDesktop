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
    public partial class InputFilm : Form
    {
        public string Titel;
        public int Jaartal;

        public InputFilm()
        {
            InitializeComponent();
        }

        private void InputFilm_Load(object sender, EventArgs e)
        {
            txtTitel.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Titel = txtTitel.Text;
            if (!int.TryParse(txtJaartal.Text, out Jaartal))
            {
                this.DialogResult = DialogResult.Cancel;
            }

            if (txtTitel.Text.Length > 0 /*&& Jaartal > 1900 && Jaartal <= DateTime.Now.Year*/)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
