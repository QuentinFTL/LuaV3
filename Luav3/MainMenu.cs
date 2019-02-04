using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using Bo3;

namespace Luav3
{
    public partial class MainMenu : MaterialForm
    {
        public static Form SetMainMenu;
        public static StreamWriter SetFileToWrite;
        public static string SetFolderToWrite;

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            materialLabel1.Text = "Files available in directory : \n" + @System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/";
        }

        private void CreateProjText_Click(object sender, EventArgs e)
        {
            CreateProjText.TextChanged += (ss, ee) =>
            {
                materialLabel1.Text = "Files available in directory : \n"+ @System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/ \n" + CreateProjText.Text;
                if (CreateProjText.Text == "")
                    CreateBut.Enabled = false;
                else
                    CreateBut.Enabled = true;
            };

        }

        private void CreateBut_Click(object sender, EventArgs e)
        {
            if (CreateProjText.Text == "")
                CreateBut.Enabled = false;
            else
                CreateBut.Enabled = true;

            Form1 form = new Form1();
            form.Show();
            Directory.CreateDirectory(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/" + CreateProjText.Text); ;
            SetFolderToWrite = @System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "/" + CreateProjText.Text;
           // SetFileToWrite = new StreamWriter(@System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) +"/" +CreateProjText.Text + ".lui");
            SetMainMenu = this;
            this.Hide();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
