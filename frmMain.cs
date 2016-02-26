using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoL_Helper
{
    public partial class frmMain : LoL_Helper.CustomForm
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private const string template = "{\"name\":\"hola\",\"championname\":\"Aatrox\",\"phases\":[{\"name\":\"Inicial\",\"items\":[2,3,76]},{\"name\":\"First back\",\"items\":[4,32,56]}]}";

        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = ChampBuilds.ChampBuild.FromJSON(template);
            f = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new frmGameScouter().ShowDialog();
            this.Show();
        }
    }
}
