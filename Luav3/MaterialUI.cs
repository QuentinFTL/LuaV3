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
    public partial class MaterialUI : Form
    {
        public MaterialUI()
        {
            InitializeComponent();
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            PictureBox current = PropertiesLua.CurrentPictureBoxSelected;
            ToolBox.ImageMaterial[GetImageIndex(current)] = comboBox1.SelectedItem as string;
            this.Hide();
        }

        public int GetImageIndex(PictureBox image)
        {
            return int.Parse(image.Name.ToString().Replace("I", "").Replace("m", "").Replace("a", "").Replace("g", "").Replace("e", ""));
        }
    }
}
