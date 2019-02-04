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
using Bo3;

namespace Luav3
{
    public partial class UIModels : MaterialForm
    {
        public static int SelectedElementIndex;
        public static PictureBox SelectedElement;
        public UIModels(PictureBox selected)
        {
            //200 y
            InitializeComponent();
        }

        private void UIModels_Load(object sender, EventArgs e)
        {
            //GetImageIndex(PropertiesLua.CurrentPictureBoxSelected);

            //WidgetsClientfields[PropertiesLua.CurrentPictureBoxSelected]
            for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
            {
                for (int exists = 0; exists < 6; exists++)
                {
                    if (PropertiesLua.CurrentPictureBoxSelected == (ToolBox.GetWidgets.Items[i] as PictureBox))
                    {
                        Console.WriteLine(ToolBox.WidgetsClientfields[i, exists]);
                        SelectedElement = PropertiesLua.CurrentPictureBoxSelected;
                        SelectedElementIndex = i;
                        //
                        if (ToolBox.WidgetsClientfields[i, exists] != null)
                        {
                            MaterialLabel Element = new MaterialLabel();
                            Element.Text = "...";
                            Element.Name = "...";
                            Element.AutoSize = true;
                            //Element.BackgroundImageLayout = ImageLayout.Stretch;
                            //Element.BackgroundImage = Luav3.Properties.Resources.CSBG;
                            //Element.BackColor = Color.Transparent;
                            Point p = new Point(60 + exists, 200 + (20 * exists));
                            Element.Location = p;
                            Element.Height = 20;
                            Element.Width = 50;
                            //x++;
                            Controls.Add(Element);
                        }
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public int GetImageIndex(PictureBox image)
        {
            return int.Parse(image.Name.ToString().Replace("I", "").Replace("m", "").Replace("a", "").Replace("g", "").Replace("e", ""));
        }
        int i=0;
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            i++;
            MaterialLabel Element = new MaterialLabel();
            Element.Text = "...";
            Element.Name = "...";
            Element.AutoSize = true;
            //Element.BackgroundImageLayout = ImageLayout.Stretch;
            //Element.BackgroundImage = Luav3.Properties.Resources.CSBG;
            //Element.BackColor = Color.Transparent;
            if(SelectedElement.Name.ToString() == "Widget")
            {
                ToolBox.WidgetsClientfields[SelectedElementIndex, i] = Element;
            }
            Point p = new Point(60 + i, 200 + (20*i));
            Element.Location = p;
            Element.Height = 20;
            Element.Width = 50;
            //x++;
            Controls.Add(Element);
        }
    }
}
