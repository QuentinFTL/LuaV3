using System;
using MaterialSkin;
using MaterialSkin.Controls;
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
    public partial class ElementPlace : Form
    {
        public ElementPlace()
        {
            InitializeComponent();
            this.Name = "ElementPlace";
        }

        private void ElementPlace_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            this.TransparencyKey = Color.White;
            
        }
    }
}
