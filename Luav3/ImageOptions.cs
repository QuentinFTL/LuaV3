using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Luav3
{
    public partial class ImageOptions : Form
    {
        public static Form setMaterialForm;
        public ImageOptions()
        {
            InitializeComponent();
            MaterialUI mtl = new MaterialUI();
            setMaterialForm = mtl;

            this.FormClosing += (ss, ee) =>
            {
                mtl.Close();
            };
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {

        }

        private void ImageOptions_Load(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            setMaterialForm.Show();
        }
    }
}
