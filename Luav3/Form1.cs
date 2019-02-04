using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Luav3
{
    public partial class Form1 : MaterialForm
    {
        public static Form currentMainForm;
        public static Form oldPropx;
        public static Form oldToolx;
        public static PictureBox StartBG;

        public static Bo3.Lua Bo3Lua;

        public static int LeftDraw;
        public static int RightDraw;
        public static int TopDraw;
        public static int BottomDraw;

        public static bool LeftAnchor;
        public static bool RightAnchor;
        public static bool TopAnchor;
        public static bool BottomAnchor;

        public Form1()
        {
            InitializeComponent();
            currentMainForm = this;
            Bo3.Lua bo3 = new Bo3.Lua();
            Bo3Lua = bo3;


            StartBG = HudGrid;
            ToolBox tb = new ToolBox(this, HudGrid, 0);
            tb.Show();
            PropertiesLua prop = new PropertiesLua();
            prop.Show();
            oldProp = prop;
            oldToolx = tb;
            this.MouseMove += (ss, ee) =>
            {
                updatePosWins();
            };
            this.Click += (ss, ee) =>
            {

            };
            this.FormClosed += (ss, ee) =>
            {
                oldProp.Close();
                oldToolx.Close();
                MainMenu.SetMainMenu.Show();
                try
                {
                    if (ToolBox.SetiOption != null)
                        ToolBox.SetiOption.Close();
                    else
                        Console.WriteLine("nope");
                }
                finally
                {
                    Console.WriteLine("close done with error ???");
                }
            };
            
        }

        public void updatePosWins()
        {
            if (PropertiesLua.isHidden)
            {
                oldProp.Left = this.Left - 19;
                oldProp.Width = 19;
                oldProp.Height = this.Height;
                oldProp.Top = this.Top;
                oldProp.Show();
            }
            if (PropertiesLua.isHidden == false)
            {
                oldProp.Left = this.Left - oldProp.Width;
                oldProp.Width = 284;
                oldProp.Height = this.Height;
                oldProp.Top = this.Top;
                oldProp.Show();
            }

            if (ToolBox.isHidden)
            {
                oldToolx.Left = this.Right;
                oldToolx.Width = 19;
                oldToolx.Height = this.Height;
                oldToolx.Top = this.Top;
                oldToolx.Show();
            }
            if (ToolBox.isHidden == false)
            {
                oldToolx.Left = this.Right;
                oldToolx.Width = 152;
                oldToolx.Height = this.Height;
                oldToolx.Top = this.Top;
                oldToolx.Show();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public Form oldProp
        {
            get
            {
                return oldPropx;
            }
            set
            {
                oldPropx = value;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            oldProp.Close();

            PropertiesLua prop = new PropertiesLua();
            prop.Show();
            prop.IsSelectedPb = null;
            //IsSelectedLb = materialLabel2;
            prop.UpdateProps();
            oldProp = prop;

        }
    }
}
