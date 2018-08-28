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
    public partial class InputText : Form
    {
        public string Tekst;

        public InputText()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Tekst = txtTekst.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
