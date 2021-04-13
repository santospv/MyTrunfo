using MyTrunfo.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyTrunfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            picThumb21Player1.Visible = false;
            this.picCarPlayer1.Image = Resources.Saveiro_Surf;
            this.picCarPlayer1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btn02_Click(object sender, EventArgs e)
        {

        }
    }
}
