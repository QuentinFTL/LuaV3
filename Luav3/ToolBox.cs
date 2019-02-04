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
    public partial class ToolBox : MaterialForm
    {
        public static PictureBox PosFormx;
        public static PictureBox CurrentHudOrWidget;
        public static PictureBox CurrentElement;
        public static int MaxComboBoxRegHOW;
        public static int CurComboBoxRegHOW;
        public static bool NeedWhile;
        public static ComboBox GetWidgets;
        public static ComboBox GetTexts;
        public static ComboBox GetElem;
        public static MaterialFlatButton ImgBut;
        public static MaterialFlatButton WidBut;
        public static bool isHidden;
        public static bool[,] ImageAnchors = new bool[100, 5];
        public static bool[,] WidgetsAnchors = new bool[100, 5];
        public static bool[,] TextsAnchors = new bool[100, 5];
        public static MaterialLabel[,] ImageClientfields = new MaterialLabel[100, 5];
        public static MaterialLabel[,] WidgetsClientfields = new MaterialLabel[100, 5];
        public static string[] ImageMaterial = new string [100];

        public static MaterialRadioButton Button1;
        public static MaterialRadioButton Button2;
        public static MaterialRadioButton Button3;
        public static MaterialRadioButton Button4;
        public static MaterialRadioButton Button5;
        public static MaterialRadioButton Button6;

        private string UIMaterial { get; set; }

        public static Form SetiOption;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20;
                return cp;
            }
        }



        public ToolBox(Form PosForm, PictureBox pb, int CurrentBG)
        {
            InitializeComponent();
            //PosForm.pb = ;
            setMainForm = pb;
            CurrentElement = pb;
            comboBox1.Items.Add(pb);
            GetWidgets = comboBox1;
            GetTexts = comboBox2;
            GetElem = comboBox3;
            textBox1.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            //updateBar();
            ImgBut = ImageButton;
            WidBut = materialFlatButton1;
            Button1 = materialRadioButton1;
            Button2 = materialRadioButton2;
            Button3 = materialRadioButton3;
            Button4 = materialRadioButton4;
            Button5 = materialRadioButton5;
            Button6 = materialRadioButton6;
    }

        private void ToolBox_Load(object sender, EventArgs e)
        {
            
        }

        public void updateBar()
        {
            while (NeedWhile == true)
            {
                CurrentHudOrWidget = comboBox1.Items[CurComboBoxRegHOWx] as PictureBox;
                NeedWhile = false;
            }
        }

        public PictureBox setMainForm
        {
            get
            {
                return PosFormx;
            }
            set
            {
                PosFormx = value;
            }
        }

        public int UpdateInt( string type )
        {
            int current = 0;
            if (type == "Widget")
                current = 1;
            
            for (int i = 0; i < comboBox3.Items.Count; i++)
            {
                if((comboBox3.Items[i] as PictureBox).Text == type)
                {
                    current += 1;
                }
                if( i == comboBox3.Items.Count -1 )
                {
                    return current;
                }
            }
            return current;
        }

        private void ImageButton_Click(object sender, EventArgs e)
        {
            //Form1 form = new Form1();
            //form.Show();
            {
                int p = 0;
                p = UpdateInt("Image");
                PictureBox Element = new PictureBox();
                Element.Text = "Image";
                Element.Name = "Image" + p;
                Element.AutoSize = true;
                Element.BackgroundImageLayout = ImageLayout.Stretch;
                Element.BackgroundImage = Luav3.Properties.Resources.CSBG;
                Element.BackColor = Color.Transparent;
                Element.BorderStyle = BorderStyle.FixedSingle;
                Element.Cursor = Cursors.Hand;
                ImageMaterial[p] = "";

                Point o = new Point(50 + p, 30 * p);
                Element.Location = o;
                Element.Height = 50;
                Element.Width = 50;

                ImageAnchors[p, 1] = PropertiesLua.LeftAnchorCurrent;//Left Anchor
                ImageAnchors[p, 2] = PropertiesLua.RightAnchorCurrent;//Left Anchor
                ImageAnchors[p, 3] = PropertiesLua.TopAnchorCurrent;//Left Anchor
                ImageAnchors[p, 4] = PropertiesLua.BottomAnchorCurrent;//Left Anchor

                comboBox3.Items.Add(Element);

                //p++;
                //MaxComboBoxRegHOW++;
                PictureBox ElementWidgetPictureBox = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox);

                ElementWidgetPictureBox.Controls.Add(Element);

                //comboBox1.Items.Add(Element);
                //ControlExtension.Draggable(Element, true);

                Element.MouseDown += (ss, ee) =>
                {
                    try
                    {
                        Luav3.Form1.oldPropx.Close();
                        PropertiesLua prop = new PropertiesLua();
                        prop.Show();
                        prop.IsSelectedPb = Element;
                        //IsSelectedLb = materialLabel2;
                        prop.UpdateProps();
                        Form1.oldPropx = prop;
                        //Point oldPoint = ;
                        if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            isButtonPressed = true;
                            Element.BringToFront();
                            if (SetiOption != null)
                            {
                                SetiOption.Close();
                                SetiOption = null;
                            }
                            CurrentElement = Element;
                        }
                        else if (ee.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            if (SetiOption == null)
                            {
                                ImageOptions iOptions = new ImageOptions();
                                SetiOption = iOptions;
                                iOptions.Show();
                                iOptions.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                            }
                            else
                            {
                                try
                                {
                                    if (SetiOption != null)
                                        SetiOption.Close();
                                }
                                finally
                                {
                                    Console.WriteLine("close done with error ???");
                                }
                                ImageOptions iOptions = new ImageOptions();
                                SetiOption = iOptions;
                                iOptions.Show();
                                iOptions.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                            }
                            isButtonPressed = false;
                        }
                        else
                        {
                            isButtonPressed = false;
                            /*if (SetiOption != null)
                            {
                                SetiOption.Close();
                                SetiOption = null;
                            }*/
                        }
                    }
                    finally
                    {
                        if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                        {
                            isButtonPressed = true;
                            if (SetiOption != null)
                            {
                                SetiOption.Close();
                                SetiOption = null;
                            }
                        }
                        else if (ee.Button == System.Windows.Forms.MouseButtons.Right)
                        {
                            if (SetiOption == null)
                            {
                                ImageOptions iOptions = new ImageOptions();
                                SetiOption = iOptions;
                                iOptions.Show();
                                iOptions.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                            }
                            isButtonPressed = false;
                        }
                        else
                        {
                            isButtonPressed = false;
                            if (SetiOption != null)
                            {
                                SetiOption.Close();
                                SetiOption = null;
                            }
                        }
                    

                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                    }
                };
                Element.MouseMove += (ss, ee) =>
                {
                    try
                    {
                        if (isButtonPressed && (ee.Button == System.Windows.Forms.MouseButtons.Left) && materialRadioButton6.Checked == false && PropertiesLua.CurrentPictureBoxSelected == Element)
                        {
                            if (materialRadioButton1.Checked == true)//Left
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Width = Element.Right - (Cursor.Position.X - Form1.currentMainForm.Left);
                                Element.Left = (Cursor.Position.X - Form1.currentMainForm.Left);
                            }
                            if (materialRadioButton2.Checked == true)//Right
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Width = (Cursor.Position.X - Form1.currentMainForm.Left) - Element.Left;
                            }
                            if (materialRadioButton3.Checked == true)//Top
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Element.Height = Element.Bottom - (((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top)));
                                Element.Top = ((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top));
                            }
                            if (materialRadioButton4.Checked == true)
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Height = (((Cursor.Position.Y - 63) - Form1.currentMainForm.Top)) - Element.Top;
                            }
                            if (materialRadioButton5.Checked == true)
                            {
                                ControlExtension.Draggable(Element, true);
                            }
                            if (materialRadioButton6.Checked == true)
                            {
                                ControlExtension.Draggable(Element, false);
                            }
                        }
                    }
                    finally
                    {
                        // Report that the finally block is run, and show that the value of
                        // i has not been changed.
                        Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                    }
                    //ControlExtension.Draggable(Element, false);
                };
                Element.MouseUp += (ss, ee) =>
                {
                    try
                    {
                        Luav3.Form1.oldPropx.Close();
                        PropertiesLua prop = new PropertiesLua();
                        prop.Show();
                        prop.IsSelectedPb = Element;
                        //IsSelectedLb = materialLabel2;
                        prop.UpdateProps();
                        Form1.oldPropx = prop;
                    }
                    finally
                    {
                        // Report that the finally block is run, and show that the value of
                        // i has not been changed.
                        Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                    }
                };
                /*Element.MouseClick += (ss, ee) =>
                {
                    Luav3.Form1.oldPropx.Close();
                    PropertiesLua prop = new PropertiesLua();
                    prop.Show();
                    prop.IsSelectedPb = Element;
                    //IsSelectedLb = materialLabel2;
                    prop.UpdateProps();
                    Form1.oldPropx = prop;
                };*/
            }
        }

        public static void BlendPictures(Bitmap bg, Bitmap front, int deltaX, int deltaY)
        {
            for (int y = 0; y < front.Height; y++)
            {
                for (int x = 0; x < front.Width; x++)
                {
                    if (front.GetPixel(x, y).A < 255)
                    {
                        Color newColor = bg.GetPixel(x + deltaX, y + deltaY);
                        front.SetPixel(x, y, newColor);
                    }
                }
            }
        }

        public static void BlendPictures(PictureBox back, PictureBox front)
        {
            int leftDifference = Math.Abs(back.Left - front.Left);
            int topDifference = Math.Abs(back.Top - front.Top);
            //back.Image = new Bitmap(LuaAnchorViewer.Properties.Resources.background);
            BlendPictures((Bitmap)back.BackgroundImage, (Bitmap)front.Image, leftDifference, topDifference);
            //back.Image = null;
        }

        //public int x = 1;
        public bool isButtonPressed = false;
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            int x = 0;
            x = UpdateInt("Widget");
            PictureBox Element = new PictureBox();
            Element.Text = "Widget";
            Element.Name = "Widget" + x;
            Element.AutoSize = true;
            Element.BackgroundImageLayout = ImageLayout.Stretch;
            Element.Image = Luav3.Properties.Resources.transparent_img;
                        
            Element.BackColor = Color.Transparent;
            Element.BorderStyle = BorderStyle.FixedSingle;
            Element.Cursor = Cursors.Hand;
            //BlendPictures(Form1.StartBG, Element);

            Point p = new Point(20 + x, 30 * x);
            Element.Location = p;
            Element.Height = 50;
            Element.Width = 50;
            comboBox3.Items.Add(Element);
            //x++;
            MaxComboBoxRegHOW = comboBox1.Items.Count;
            PictureBox ElementWidgetPictureBox = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox);
            ElementWidgetPictureBox.Controls.Add(Element);

            comboBox1.Items.Add(Element);
            //ControlExtension.Draggable(Element, true);

            Element.MouseDown += (ss, ee) =>
            {
                //Point oldPoint = ;
                try
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        isButtonPressed = true;
                        Element.BringToFront();
                        CurrentElement = Element;
                    }
                    else
                    {
                        isButtonPressed = false;
                    }
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
            Element.MouseMove += (ss, ee) =>
            {
                try
                {
                    if (isButtonPressed && (ee.Button == System.Windows.Forms.MouseButtons.Left) && materialRadioButton6.Checked == false && PropertiesLua.CurrentPictureBoxSelected == Element)
                    {
                        //if()
                        if (materialRadioButton1.Checked == true)//Left
                        {
                            Console.WriteLine("lol func");
                            ControlExtension.Draggable(Element, false);
                            Console.WriteLine("lol");
                            Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                            Element.Width = Element.Right - (Cursor.Position.X - Form1.currentMainForm.Left);
                            Element.Left = (Cursor.Position.X - Form1.currentMainForm.Left);
                        }
                        if (materialRadioButton2.Checked == true)//Right
                        {
                            Console.WriteLine("lol func");
                            ControlExtension.Draggable(Element, false);
                            Console.WriteLine("lol");
                            Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                            Element.Width = (Cursor.Position.X - Form1.currentMainForm.Left) - Element.Left;
                        }
                        if (materialRadioButton3.Checked == true)//Top
                        {
                            Console.WriteLine("lol func");
                            ControlExtension.Draggable(Element, false);
                            Console.WriteLine("lol");
                            Element.Height = Element.Bottom - (((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top)));
                            Element.Top = ((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top));
                        }
                        if (materialRadioButton4.Checked == true)
                        {
                            materialRadioButton5.Checked = false;
                            Console.WriteLine("lol func");
                            ControlExtension.Draggable(Element, false);
                            Console.WriteLine("lol");
                            Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                            Element.Height = (((Cursor.Position.Y - 63) - Form1.currentMainForm.Top)) - Element.Top;
                        }
                        if (materialRadioButton5.Checked == true)
                        {
                            ControlExtension.Draggable(Element, true);
                        }
                        if (materialRadioButton6.Checked == true)
                        {
                            ControlExtension.Draggable(Element, false);
                        }
                    }
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
                //ControlExtension.Draggable(Element, false);
            };
            Element.MouseUp += (ss, ee) =>
            {
                try
                {
                    Luav3.Form1.oldPropx.Close();
                    PropertiesLua prop = new PropertiesLua();
                    prop.Show();
                    prop.IsSelectedPb = Element;
                    //IsSelectedLb = materialLabel2;
                    prop.UpdateProps();
                    Form1.oldPropx = prop;
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
            Element.MouseClick += (ss, ee) =>
            {
                try
                {
                    Luav3.Form1.oldPropx.Close();
                    PropertiesLua prop = new PropertiesLua();
                    prop.Show();
                    prop.IsSelectedPb = Element;
                    //IsSelectedLb = materialLabel2;
                    prop.UpdateProps();
                    Form1.oldPropx = prop;
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
        }

        int s = 0;
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            TextBox Element = new TextBox();
            Element.Text = "Text";
            Element.Name = "Text" + s;
            Element.AutoSize = true;
            //Element.BackColor = Color.FromArgb(50, 0, 0, 0);
            Element.TextAlign = HorizontalAlignment.Center;
            Element.Multiline = true;
            //Element.BackgroundImageLayout = ImageLayout.Stretch;
            //Element.Image = Luav3.Properties.Resources.transparent_img;

            //Element.BackColor = Color.Transparent;
            Element.BorderStyle = BorderStyle.FixedSingle;
            Element.Cursor = Cursors.Hand;
            //BlendPictures(Form1.StartBG, Element);

            Point p = new Point(20 + s, 30 * s);
            Element.Location = p;
            Element.Height = 50;
            Element.Width = 50;

            s++;
            //MaxComboBoxRegHOW++;
            PictureBox ElementWidgetPictureBox = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox);
            ElementWidgetPictureBox.Controls.Add(Element);

            comboBox2.Items.Add(Element);

            TextsAnchors[s, 1] = PropertiesLua.LeftAnchorCurrent;//Left Anchor
            TextsAnchors[s, 2] = PropertiesLua.RightAnchorCurrent;//Left Anchor
            TextsAnchors[s, 3] = PropertiesLua.TopAnchorCurrent;//Left Anchor
            TextsAnchors[s, 4] = PropertiesLua.BottomAnchorCurrent;//Left Anchor
            //ControlExtension.Draggable(Element, true);

            Element.MouseDown += (ss, ee) =>
            {
                //Point oldPoint = ;
                try
                {
                    if (ee.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        isButtonPressed = true;
                        Element.BringToFront();
                        PropertiesLua.CurrentRTextBoxSelected = Element;
                    }
                    else
                    {
                        isButtonPressed = false;
                    }
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
            Element.MouseMove += (ss, ee) =>
            {
                try
                {
                    if (isButtonPressed && (ee.Button == System.Windows.Forms.MouseButtons.Left) && materialRadioButton6.Checked == false && PropertiesLua.CurrentRTextBoxSelected == Element)
                    {
                        //if()
                        if (materialRadioButton1.Checked == true)//Left
                        {
                            try
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Width = Element.Right - (Cursor.Position.X - Form1.currentMainForm.Left);
                                Element.Left = (Cursor.Position.X - Form1.currentMainForm.Left);
                            }
                            finally
                            {
                                Console.WriteLine("stop");
                            }
                        }
                        if (materialRadioButton2.Checked == true)//Right
                        {
                            try
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Width = (Cursor.Position.X - Form1.currentMainForm.Left) - Element.Left;
                            }
                            finally
                            {
                                Console.WriteLine("stop");
                            }
                        }
                        if (materialRadioButton3.Checked == true)//Top
                        {
                            try
                            {
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Element.Height = Element.Bottom - (((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top)));
                                Element.Top = ((Cursor.Position.Y - 63) - (Form1.currentMainForm.Top));
                            }
                            finally
                            {
                                Console.WriteLine("stop");
                            }
                        }
                        if (materialRadioButton4.Checked == true)
                        {
                            try
                            {
                                materialRadioButton5.Checked = false;
                                Console.WriteLine("lol func");
                                ControlExtension.Draggable(Element, false);
                                Console.WriteLine("lol");
                                Console.WriteLine(Convert.ToString(Control.MousePosition.X) + ", " + Element.Right + ", " + Form1.currentMainForm.Left);
                                Element.Height = (((Cursor.Position.Y - 63) - Form1.currentMainForm.Top)) - Element.Top;
                            }
                            finally
                            {
                                Console.WriteLine("stop");
                            }
                        }
                        if (materialRadioButton5.Checked == true)
                        {
                            try
                            {
                                ControlExtension.Draggable(Element, true);
                            }finally
                            {
                                //
                            }
                        }
                        if (materialRadioButton6.Checked == true)
                        {
                            ControlExtension.Draggable(Element, false);
                        }
                    }
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
                //ControlExtension.Draggable(Element, false);
            };
            Element.MouseUp += (ss, ee) =>
            {
                try
                {
                    Luav3.Form1.oldPropx.Close();
                    PropertiesLua prop = new PropertiesLua();
                    prop.Show();
                    prop.IsSelectedText = Element;
                    //IsSelectedLb = materialLabel2;
                    prop.UpdateProps();
                    Form1.oldPropx = prop;
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
            Element.MouseClick += (ss, ee) =>
            {
                try
                {
                    Luav3.Form1.oldPropx.Close();
                    PropertiesLua prop = new PropertiesLua();
                    prop.Show();
                    prop.IsSelectedText = Element;
                    //IsSelectedLb = materialLabel2;
                    prop.UpdateProps();
                    Form1.oldPropx = prop;
                }
                finally
                {
                    // Report that the finally block is run, and show that the value of
                    // i has not been changed.
                    Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", Element);
                }
            };
        }

        public int MaxComboBoxRegHOWx
        {
            get
            {
                return MaxComboBoxRegHOW;
            }
            set
            {
                MaxComboBoxRegHOW = value;
            }
        }

        public int CurComboBoxRegHOWx
        {
            get
            {
                return CurComboBoxRegHOW;
            }
            set
            {
                CurComboBoxRegHOW = value;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void materialRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //materialRadioButton2.Checked = false;
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void materialRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //materialRadioButton1.Checked = false;
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void materialRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void materialRadioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void materialRadioButton6_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (isHidden)
            {
                materialFlatButton2.Left = 133;
                isHidden = false;
                materialFlatButton2.Text = "<";
            }
            else
            {
                materialFlatButton2.Left = 0;
                isHidden = true;
                materialFlatButton2.Text = ">";
            }
            //x = 133;
        }

        private void materialRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            ControlExtension.Draggable(CurrentElement, false);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}