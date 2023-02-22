using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WcfCoreMtomEncoder;
using ServiceReference1;

namespace CEIDGREGON
{
    public partial class ProgramOptions : Form
    {
        GetErrorFromGus gus;
        public ProgramOptions()
        {
            InitializeComponent();
            gus = new GetErrorFromGus();
            ErrorBox.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(gus.GetErrorMessage(ErrorBox.Text),"Błąd",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
