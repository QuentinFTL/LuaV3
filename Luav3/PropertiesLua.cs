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
    public partial class PropertiesLua : MaterialForm
    {
        public static PictureBox CurrentPictureBoxSelected;
        public static Label CurrentLabelSelected;
        public static TextBox CurrentRTextBoxSelected;
        public static bool isHidden;
        public static bool LeftAnchorCurrent;//Left Anchor
        public static bool RightAnchorCurrent;//Left Anchor
        public static bool TopAnchorCurrent;//Left Anchor
        public static bool BottomAnchorCurrent;//Left Anchor

        public PropertiesLua()
        {
            InitializeComponent();
            //Bo3.Lua bo3 = new Bo3.Lua();
            comboBox1.Items.Add(Form1.StartBG);
            comboBox1.SelectedIndex = 0;
           // materialFlatButton4.Hide();
            // IsSelectedPb = pb;
            //IsSelectedLb = materialLabel2;
            UpdateProps();
            materialCheckBox1.Checked = Form1.LeftAnchor;
            materialCheckBox2.Checked = Form1.RightAnchor;
            materialCheckBox4.Checked = Form1.TopAnchor;
            materialCheckBox3.Checked = Form1.BottomAnchor;
            materialSingleLineTextField1.Text += (Form1.LeftDraw);
            materialSingleLineTextField2.Text += (Form1.RightDraw);
            materialSingleLineTextField4.Text += (Form1.TopDraw);
            materialSingleLineTextField3.Text += (Form1.BottomDraw);
            materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;
            this.FormClosing += (ss,ee) =>
            {
                Form1.oldPropx = new PropertiesLua();
            };

            
            materialSingleLineTextField3.Leave += (ss, ee) =>
            {
                try
                {
                    //Bo3.Lua bo3 = new Bo3.Lua();
                    Form1.BottomDraw = int.Parse(materialSingleLineTextField3.Text);
                    IsSelectedPb.Height = ConvertTextToPosition(IsSelectedPb.Parent as PictureBox, int.Parse(materialSingleLineTextField3.Text), "Bottom", IsSelectedPb);
                }
                finally
                {
                    Console.WriteLine("no errors");
                }
            };
            materialSingleLineTextField4.Leave += (ss, ee) =>
            {
                try
                {
                    // Bo3.Lua bo3 = new Bo3.Lua();
                    Form1.TopDraw = int.Parse(materialSingleLineTextField4.Text);
                    IsSelectedPb.Top = ConvertTextToPosition(IsSelectedPb.Parent as PictureBox, int.Parse(materialSingleLineTextField4.Text), "Top", IsSelectedPb);
                }
                finally
                {
                    Console.WriteLine("no errors");
                }
            };
            materialSingleLineTextField2.Leave += (ss, ee) =>
            {
                try
                {
                    //   Bo3.Lua bo3 = new Bo3.Lua();
                    Form1.RightDraw = int.Parse(materialSingleLineTextField2.Text);
                    IsSelectedPb.Width = ConvertTextToPosition(IsSelectedPb.Parent as PictureBox, int.Parse(materialSingleLineTextField2.Text), "Right", IsSelectedPb);
                }
                finally
                {
                    Console.WriteLine("no errors");
                }
            };
            materialSingleLineTextField1.Leave += (ss, ee) =>
            {
                try
                {
                    //Bo3.Lua bo3 = new Bo3.Lua();
                    Form1.LeftDraw = int.Parse(materialSingleLineTextField1.Text);//change the Left value of the Elem
                    IsSelectedPb.Left = ConvertTextToPosition(IsSelectedPb.Parent as PictureBox, int.Parse(materialSingleLineTextField1.Text), "Left", IsSelectedPb);
                }
                finally
                {
                    Console.WriteLine("no errors");
                }
            };     
            
        }


        public int ConvertTextToPosition( PictureBox Parent, int position, string Side, PictureBox Element)
        {
            try
            {
                int Pos = position;
                if (Side == "Left")
                {
                    if (materialCheckBox1.Checked == true && materialCheckBox2.Checked == false)
                    {
                        return Pos;
                    }
                    if (materialCheckBox1.Checked == false && materialCheckBox2.Checked == false)
                    {
                        return -((Parent.Width / 2) - (Pos));
                    }
                    else
                    {
                        return (-(Parent.Width - Pos));
                    }
                }
                if (Side == "Right")
                {
                    if (materialCheckBox4.Checked == true && materialCheckBox3.Checked == true)
                    {
                        return ((Parent.Width - Element.Left) + (Pos));
                    }
                    if (materialCheckBox2.Checked == true && materialCheckBox3.Checked == false)
                    {
                        return -(Parent.Width - (Parent.Width - Pos));
                    }
                    if (materialCheckBox1.Checked == false && materialCheckBox2.Checked == false)
                    {
                        return -((Parent.Width / 2) - (Pos));
                    }
                    else
                    {
                        return ((Pos-Element.Left));
                    }
                }
                if (Side == "Top")
                {
                    if (materialCheckBox4.Checked == true)
                    {
                        return Pos;
                    }
                    if (materialCheckBox4.Checked == false && materialCheckBox3.Checked == false)
                    {
                        return -(((Parent.Height / 2)) - (Pos));
                    }
                    else
                    {
                        return (-(Parent.Height - Pos));
                    }
                }
                if (Side == "Bottom")
                {
                    if (materialCheckBox4.Checked == true && materialCheckBox3.Checked == true)
                    {
                        return ((Parent.Height - Element.Top) + (Pos));
                    }
                    if (materialCheckBox3.Checked == true)
                    {
                        return -(Parent.Height - (Parent.Height - Pos));
                    }
                    if (materialCheckBox4.Checked == false && materialCheckBox3.Checked == false)
                    {
                        return -((Parent.Height / 2) - (Pos));
                    }
                    else
                    {
                        return ((Pos-Element.Top));
                    }
                }
                else
                    return Pos;
            }
            finally
            {
                //  return 0;
                Console.WriteLine("no errors");
            }
        }
/*      public float GetDraw(string pos, bool[] anchors)
        {




            return 
        }*/

        public float ConvertPositionFromElement(PictureBox Parent, int Pos, string Side, bool useAnchors, bool write = false)
        {
            if (useAnchors == true)
            {
                if (Side == "Left")
                {
                    if (materialCheckBox1.Checked == true)
                    {
                        return Pos;
                    }
                    if (materialCheckBox1.Checked == false && materialCheckBox2.Checked == false)
                    {
                        return -((Parent.Width/2) - (Pos));
                    }
                    else
                    {
                        return (-(Parent.Width - Pos));
                    }
                }
                if (Side == "Right")
                {
                    if (materialCheckBox2.Checked == true)
                    {
                        return -(Parent.Width - Pos);
                    }
                    if (materialCheckBox1.Checked == false && materialCheckBox2.Checked == false)
                    {
                        return -((Parent.Width / 2) - (Pos));
                    }
                    else
                    {
                        return ((Pos));
                    }
                }
                if (Side == "Top")
                {
                    if (materialCheckBox4.Checked == true)
                    {
                        return Pos;
                    }
                    if (materialCheckBox4.Checked == false && materialCheckBox3.Checked == false)
                    {
                        return -(((Parent.Height / 2)) - (Pos));
                    }
                    else
                    {
                        return (-(Parent.Height - Pos));
                    }
                }
                if (Side == "Bottom")
                {
                    if (materialCheckBox3.Checked == true)
                    {
                        return -(Parent.Height - Pos);
                    }
                    if (materialCheckBox4.Checked == false && materialCheckBox3.Checked == false)
                    {
                        return -((Parent.Height / 2) - (Pos));
                    }
                    else
                    {
                        return ((Pos));
                    }
                }
                return Pos;
            }
            else
                return Pos;
        }

        public PictureBox IsSelectedPb
        {
            get
            {
                return CurrentPictureBoxSelected;
            }
            set
            {
                if (value != null)
                {
                    CurrentPictureBoxSelected = value;
                    comboBox1.Items[comboBox1.SelectedIndex] = value;
                }
            }
        }

        public Label IsSelectedLb
        {
            get
            {
                return CurrentLabelSelected;
            }
            set
            {
                CurrentLabelSelected = value;
                comboBox1.Items[comboBox1.SelectedIndex] = value;
            }
        }


        public TextBox IsSelectedText
        {
            get
            {
                return CurrentRTextBoxSelected;
            }
            set
            {
                if (value != null)
                {
                    CurrentRTextBoxSelected = value;
                    comboBox1.Items[comboBox1.SelectedIndex] = value;
                }
            }
        }

        public void UpdateProps()
        {

            //PictureBox pb = 
            //TypeSelected = PictureBox;
            //Console.WriteLine(TypeSelected);
            PictureBox pb = comboBox1.SelectedItem as PictureBox;
            TextBox lb = comboBox1.SelectedItem as TextBox;

            //TODO: add image in widget pos.

            //
            if ((comboBox1.SelectedItem as PictureBox).Name.ToString() != "HudGrid")
            {
                if (comboBox1.SelectedItem == pb)
                {
                    if ((comboBox1.SelectedItem as PictureBox).Name.ToString() != "HudGrid")
                    {
                        //materialLabel1.Text = "Create New Element...";
                        materialCheckBox1.Enabled = true;
                        materialCheckBox2.Enabled = true;
                        materialCheckBox3.Enabled = true;
                        materialCheckBox4.Enabled = true;

                        materialSingleLineTextField1.Enabled = true;
                        materialSingleLineTextField2.Enabled = true;
                        materialSingleLineTextField3.Enabled = true;
                        materialSingleLineTextField4.Enabled = true;

                        materialFlatButton4.Enabled = true;

                        materialSingleLineTextField5.Enabled = true;
                        materialFlatButton8.Enabled = true;

                        ToolBox.Button1.Enabled = true;
                        ToolBox.Button2.Enabled = true;
                        ToolBox.Button3.Enabled = true;
                        ToolBox.Button4.Enabled = true;
                        ToolBox.Button5.Enabled = true;
                        ToolBox.Button6.Enabled = true;


                        ToolBox.Button1.Show();
                        ToolBox.Button2.Show();
                        ToolBox.Button3.Show();
                        ToolBox.Button4.Show();
                        ToolBox.Button5.Show();
                        ToolBox.Button6.Show();

                        if (comboBox1.SelectedItem == pb)
                        {
                            materialSingleLineTextField1.Text = "";
                            materialSingleLineTextField2.Text = "";
                            materialSingleLineTextField4.Text = "";
                            materialSingleLineTextField3.Text = "";
                            if (pb.Parent.Name.ToString() == "HudGrid")
                            {
                                materialSingleLineTextField1.Text += ConvertPositionFromElement(Form1.StartBG, pb.Left, "Left", true);
                                materialSingleLineTextField2.Text += ConvertPositionFromElement(Form1.StartBG, pb.Right, "Right", true);
                                materialSingleLineTextField4.Text += ConvertPositionFromElement(Form1.StartBG, pb.Top, "Top", true);
                                materialSingleLineTextField3.Text += ConvertPositionFromElement(Form1.StartBG, pb.Bottom, "Bottom", true);
                            }
                            else if (pb.Name.ToString() == "HudGrid")
                            {
                                materialSingleLineTextField1.Text += ConvertPositionFromElement(pb as PictureBox, pb.Left, "Left", true);
                                materialSingleLineTextField2.Text += ConvertPositionFromElement(pb as PictureBox, pb.Right, "Right", true);
                                materialSingleLineTextField4.Text += ConvertPositionFromElement(pb as PictureBox, pb.Top, "Top", true);
                                materialSingleLineTextField3.Text += ConvertPositionFromElement(pb as PictureBox, pb.Bottom, "Bottom", true);
                            }
                            else
                            {
                                materialSingleLineTextField1.Text += ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", true);
                                materialSingleLineTextField2.Text += ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", true);
                                materialSingleLineTextField4.Text += ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", true);
                                materialSingleLineTextField3.Text += ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", true);
                            }
                            if (pb.Text == "Widget")
                            {
                                materialLabel10.Text = "";
                                materialLabel1.Text = IsSelectedPb.Name.ToString() + " : Widget";
                                materialFlatButton4.Text = "Set Widget Name";
                                materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;
                                for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
                                {
                                    if (pb == (ToolBox.GetWidgets.Items[i] as PictureBox))
                                    {
                                        materialCheckBox1.Checked = ToolBox.WidgetsAnchors[i, 1];
                                        materialCheckBox2.Checked = ToolBox.WidgetsAnchors[i, 2];
                                        materialCheckBox4.Checked = ToolBox.WidgetsAnchors[i, 3];
                                        materialCheckBox3.Checked = ToolBox.WidgetsAnchors[i, 4];
                                        Console.WriteLine(i);
                                    }

                                }

                                StreamWriter widget = new StreamWriter(MainMenu.SetFolderToWrite + "/" + IsSelectedPb.Name.ToString() + ".lui_element", false);
                                widget.WriteLine("Type : Widget");
                                widget.WriteLine("Name : " + IsSelectedPb.Name.ToString());
                                widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", false));
                                widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", false));
                                widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", false));
                                widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", false));
                                widget.WriteLine("Parent : " + (pb.Parent as PictureBox).Name.ToString());
                                widget.WriteLine("\n---INFOS FOR LUA WRITE---\n");
                                widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", true));
                                widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", true));
                                widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", true));
                                widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", true));
                                widget.WriteLine("Left Anchor : " + materialCheckBox1.Checked);
                                widget.WriteLine("Right Anchor : " + materialCheckBox2.Checked);
                                widget.WriteLine("Top Anchor : " + materialCheckBox4.Checked);
                                widget.WriteLine("Bottom Anchor : " + materialCheckBox3.Checked);
                                widget.Close();
                            }
                            else if (pb.Text == "Image")
                            {
                                materialLabel1.Text = IsSelectedPb.Name.ToString() + " : Image";
                                materialFlatButton4.Text = "Set Image";
                                materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;
                                if (IsSelectedPb.Name.ToString() != "HudGrid")
                                {
                                    materialLabel10.Text = "Material : " + ToolBox.ImageMaterial[GetImageIndex(pb)];
                                    materialCheckBox1.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 1];
                                    materialCheckBox2.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 2];
                                    materialCheckBox4.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 3];
                                    materialCheckBox3.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 4];
                                    StreamWriter widget = new StreamWriter(MainMenu.SetFolderToWrite + "/" + IsSelectedPb.Name.ToString() + ".lui_element", false);
                                    widget.WriteLine("Type : Image");
                                    widget.WriteLine("Name : " + IsSelectedPb.Name.ToString());
                                    widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", false));
                                    widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", false));
                                    widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", false));
                                    widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", false));
                                    widget.WriteLine("Parent : " + (pb.Parent as PictureBox).Name.ToString());
                                    widget.WriteLine("\n---INFOS FOR LUA WRITE---\n");
                                    widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", true));
                                    widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", true));
                                    widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", true));
                                    widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", true));
                                    widget.WriteLine("Left Anchor : " + materialCheckBox1.Checked);
                                    widget.WriteLine("Right Anchor : " + materialCheckBox2.Checked);
                                    widget.WriteLine("Top Anchor : " + materialCheckBox4.Checked);
                                    widget.WriteLine("Bottom Anchor : " + materialCheckBox3.Checked);
                                    widget.WriteLine("Material : " + ToolBox.ImageMaterial[GetImageIndex(pb)]);

                                    widget.Close();
                                }
                            }
                        }
                        // StreamWriter
                        /*if (comboBox1.SelectedItem == lb)
                        {
                            materialLabel1.Text = IsSelectedLb.Name.ToString() + " : Text";
                            materialFlatButton4.Text = "Text";
                            materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;

                        }*/
                    }
                }
                else if (comboBox1.SelectedItem == lb)
                {
                    //materialLabel1.Text = "Create New Element...";
                    materialCheckBox1.Enabled = true;
                    materialCheckBox2.Enabled = true;
                    materialCheckBox3.Enabled = true;
                    materialCheckBox4.Enabled = true;

                    materialSingleLineTextField1.Enabled = true;
                    materialSingleLineTextField2.Enabled = true;
                    materialSingleLineTextField3.Enabled = true;
                    materialSingleLineTextField4.Enabled = true;

                    materialFlatButton4.Enabled = true;
                    materialFlatButton8.Enabled = true;

                    materialSingleLineTextField5.Enabled = true;
                    if (comboBox1.SelectedItem == lb)
                    {
                        materialSingleLineTextField1.Text = "";
                        materialSingleLineTextField2.Text = "";
                        materialSingleLineTextField4.Text = "";
                        materialSingleLineTextField3.Text = "";
                        if (lb.Parent.Name.ToString() == "HudGrid")
                        {
                            materialSingleLineTextField1.Text += ConvertPositionFromElement(Form1.StartBG, lb.Left, "Left", true);
                            materialSingleLineTextField2.Text += ConvertPositionFromElement(Form1.StartBG, lb.Right, "Right", true);
                            materialSingleLineTextField4.Text += ConvertPositionFromElement(Form1.StartBG, lb.Top, "Top", true);
                            materialSingleLineTextField3.Text += ConvertPositionFromElement(Form1.StartBG, lb.Bottom, "Bottom", true);
                        }
                        else
                        {
                            materialSingleLineTextField1.Text += ConvertPositionFromElement(lb.Parent as PictureBox, lb.Left, "Left", true);
                            materialSingleLineTextField2.Text += ConvertPositionFromElement(lb.Parent as PictureBox, lb.Right, "Right", true);
                            materialSingleLineTextField4.Text += ConvertPositionFromElement(lb.Parent as PictureBox, lb.Top, "Top", true);
                            materialSingleLineTextField3.Text += ConvertPositionFromElement(lb.Parent as PictureBox, lb.Bottom, "Bottom", true);
                        }
                        materialLabel10.Text = "";
                        materialLabel1.Text = CurrentRTextBoxSelected.Name.ToString() + " : Text";
                        materialFlatButton4.Text = "Set Text";
                        materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;
                        for (int i = 0; i < ToolBox.GetTexts.Items.Count; i++)
                        {
                            if (lb == (ToolBox.GetTexts.Items[i] as TextBox))
                            {
                                materialCheckBox1.Checked = ToolBox.TextsAnchors[i, 1];
                                materialCheckBox2.Checked = ToolBox.TextsAnchors[i, 2];
                                materialCheckBox4.Checked = ToolBox.TextsAnchors[i, 3];
                                materialCheckBox3.Checked = ToolBox.TextsAnchors[i, 4];
                                Console.WriteLine(i);
                            }

                        }

                        StreamWriter widget = new StreamWriter(MainMenu.SetFolderToWrite + "/" + CurrentRTextBoxSelected.Name.ToString() + ".lui_element", false);
                        widget.WriteLine("Type : Text");
                        widget.WriteLine("Name : " + CurrentRTextBoxSelected.Name.ToString());
                        widget.WriteLine("Left : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Left, "Left", false));
                        widget.WriteLine("Right : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Right, "Right", false));
                        widget.WriteLine("Top : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Top, "Top", false));
                        widget.WriteLine("Bottom : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Bottom, "Bottom", false));
                        widget.WriteLine("Parent : " + (lb.Parent as PictureBox).Name.ToString());
                        widget.WriteLine("\n---INFOS FOR LUA WRITE---\n");
                        widget.WriteLine("Left : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Left, "Left", true));
                        widget.WriteLine("Right : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Right, "Right", true));
                        widget.WriteLine("Top : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Top, "Top", true));
                        widget.WriteLine("Bottom : " + ConvertPositionFromElement(lb.Parent as PictureBox, lb.Bottom, "Bottom", true));
                        widget.WriteLine("Left Anchor : " + materialCheckBox1.Checked);
                        widget.WriteLine("Right Anchor : " + materialCheckBox2.Checked);
                        widget.WriteLine("Top Anchor : " + materialCheckBox4.Checked);
                        widget.WriteLine("Bottom Anchor : " + materialCheckBox3.Checked);
                        widget.Close();
                    }
                    /*  else if (lb.Text == "Image")
                      {
                          materialLabel1.Text = IsSelectedPb.Name.ToString() + " : Image";
                          materialFlatButton4.Text = "Set Image";
                          materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;
                          if (IsSelectedPb.Name.ToString() != "HudGrid")
                          {
                              materialLabel10.Text = "Material : " + ToolBox.ImageMaterial[GetImageIndex(pb)];
                              materialCheckBox1.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 1];
                              materialCheckBox2.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 2];
                              materialCheckBox4.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 3];
                              materialCheckBox3.Checked = ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 4];
                              StreamWriter widget = new StreamWriter(MainMenu.SetFolderToWrite + "/" + IsSelectedPb.Name.ToString() + ".lui_element", false);
                              widget.WriteLine("Type : Image");
                              widget.WriteLine("Name : " + IsSelectedPb.Name.ToString());
                              widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", false));
                              widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", false));
                              widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", false));
                              widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", false));
                              widget.WriteLine("Parent : " + (pb.Parent as PictureBox).Name.ToString());
                              widget.WriteLine("\n---INFOS FOR LUA WRITE---\n");
                              widget.WriteLine("Left : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Left, "Left", true));
                              widget.WriteLine("Right : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Right, "Right", true));
                              widget.WriteLine("Top : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Top, "Top", true));
                              widget.WriteLine("Bottom : " + ConvertPositionFromElement(pb.Parent as PictureBox, pb.Bottom, "Bottom", true));
                              widget.WriteLine("Left Anchor : " + materialCheckBox1.Checked);
                              widget.WriteLine("Right Anchor : " + materialCheckBox2.Checked);
                              widget.WriteLine("Top Anchor : " + materialCheckBox4.Checked);
                              widget.WriteLine("Bottom Anchor : " + materialCheckBox3.Checked);
                              widget.Close();
                          }
                      }*/

                    // StreamWriter
                    /*if (comboBox1.SelectedItem == lb)
                    {
                        materialLabel1.Text = IsSelectedLb.Name.ToString() + " : Text";
                        materialFlatButton4.Text = "Text";
                        materialFlatButton4.Left = this.Width / 2 - materialFlatButton4.Width / 2;

                    }*/
                }
            }
            else
            {
                materialLabel1.Text = "Create New Element\n Or click on Element\n to edit it";
                materialCheckBox1.Enabled = false;
                materialCheckBox2.Enabled = false;
                materialCheckBox3.Enabled = false;
                materialCheckBox4.Enabled = false;

                materialSingleLineTextField1.Enabled = false;
                materialSingleLineTextField2.Enabled = false;
                materialSingleLineTextField3.Enabled = false;
                materialSingleLineTextField4.Enabled = false;

                ToolBox.Button1.Enabled = false;
                ToolBox.Button2.Enabled = false;
                ToolBox.Button3.Enabled = false;
                ToolBox.Button4.Enabled = false;
                ToolBox.Button5.Enabled = false;
                ToolBox.Button6.Enabled = false;
                materialFlatButton8.Enabled = false;

                ToolBox.Button1.Hide();
                ToolBox.Button2.Hide();
                ToolBox.Button3.Hide();
                ToolBox.Button4.Hide();
                ToolBox.Button5.Hide();
                ToolBox.Button6.Hide();

                materialFlatButton4.Text = "Change BackGround";

                materialSingleLineTextField5.Enabled = false;

            }
        }

        public int GetImageIndex(PictureBox image)
        {
            return int.Parse(image.Name.ToString().Replace("I", "").Replace("m", "").Replace("a", "").Replace("g", "").Replace("e", ""));
        }

        private void Properties_Load(object sender, EventArgs e)
        {
            materialLabel5.Text = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox).Name.ToString();
            materialLabel2.Hide();
            comboBox1.Hide();
            comboBox2.Hide();
            comboBox3.Hide();
        }

        private void materialLabel1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialLabel2_Click(object sender, EventArgs e)
        {
          //  IsSelectedPb = pb;
            IsSelectedLb = materialLabel2;
            UpdateProps();
        }

        private void materialLabel5_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            //Button  >
            if (ToolBox.CurComboBoxRegHOW < ToolBox.MaxComboBoxRegHOW)
            {
                ToolBox.CurComboBoxRegHOW = ToolBox.CurComboBoxRegHOW + 1;
            }
            else if(ToolBox.CurComboBoxRegHOW == ToolBox.MaxComboBoxRegHOW)
            {
                ToolBox.CurComboBoxRegHOW = 0;
            }
            Form1.oldToolx.Update();
            materialLabel5.Text = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox).Name.ToString();
        }

        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            if (ToolBox.CurComboBoxRegHOW > 0)
            {
                ToolBox.CurComboBoxRegHOW = ToolBox.CurComboBoxRegHOW - 1;
            }
            else if (ToolBox.CurComboBoxRegHOW == 0)
            {
                ToolBox.CurComboBoxRegHOW = ToolBox.MaxComboBoxRegHOW;
            }
            Form1.oldToolx.Update();
            materialLabel5.Text = (ToolBox.GetWidgets.Items[ToolBox.CurComboBoxRegHOW] as PictureBox).Name.ToString();
        }

        private void materialFlatButton4_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            if(isHidden)
            {
                materialFlatButton3.Text = ">";
                isHidden = false;
            }
            else
            {
                materialFlatButton3.Text = "<";
                isHidden = true;
            }
        }

        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            Form1.LeftAnchor = materialCheckBox1.Checked;
            Form1.Bo3Lua.AnchorLeft= Form1.LeftAnchor;
            //  LeftAnchorCurrent = Form1.Bo3Lua.AnchorLeft;
            if (IsSelectedPb.Name.ToString() != "HudGrid" || IsSelectedPb != null)
            {
                if (IsSelectedPb.Text == "Widget")
                {
                    for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
                    {
                        if (IsSelectedPb == (ToolBox.GetWidgets.Items[i] as PictureBox))
                        {
                            ToolBox.WidgetsAnchors[i, 1] = materialCheckBox1.Checked;
                        }
                    }
                }
                else
                {
                    if (IsSelectedPb.Name.ToString() != "HudGrid")
                        ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 1] = materialCheckBox1.Checked;
                }
                UpdateProps();
            }
        }

        private void materialCheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            Form1.RightAnchor = materialCheckBox2.Checked;
            Form1.Bo3Lua.AnchorRight = Form1.RightAnchor;
            //RightAnchorCurrent = Form1.Bo3Lua.AnchorRight;
            if (IsSelectedPb.Name.ToString() != "HudGrid" || IsSelectedPb != null)
            {
                if (IsSelectedPb.Text == "Widget")
                {
                    for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
                    {
                        if (IsSelectedPb == (ToolBox.GetWidgets.Items[i] as PictureBox))
                        {
                            ToolBox.WidgetsAnchors[i, 2] = materialCheckBox2.Checked;
                        }
                    }
                }
                else
                {
                    if (IsSelectedPb.Name.ToString() != "HudGrid")
                        ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 2] = materialCheckBox2.Checked;
                }
                UpdateProps();
            }
        }

        private void materialCheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            Form1.TopAnchor = materialCheckBox4.Checked;
            Form1.Bo3Lua.AnchorTop = Form1.TopAnchor;
            TopAnchorCurrent = Form1.Bo3Lua.AnchorTop;
            if (IsSelectedPb.Name.ToString() != "HudGrid" || IsSelectedPb != null)
            {
                if (IsSelectedPb.Text == "Widget")
                {
                    for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
                    {
                        if (IsSelectedPb == (ToolBox.GetWidgets.Items[i] as PictureBox))
                        {
                            ToolBox.WidgetsAnchors[i, 3] = materialCheckBox4.Checked;
                        }
                    }
                }
                else
                {
                    if (IsSelectedPb.Name.ToString() != "HudGrid")
                        ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 3] = materialCheckBox4.Checked;
                }
                UpdateProps();
            }
        }

        private void materialCheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            Form1.BottomAnchor = materialCheckBox3.Checked;
            Form1.Bo3Lua.AnchorBottom = Form1.BottomAnchor;
            BottomAnchorCurrent = Form1.Bo3Lua.AnchorBottom;
            if (IsSelectedPb.Name.ToString() != "HudGrid" || IsSelectedPb != null)
            {
                if (IsSelectedPb.Text == "Widget")
                {
                    for (int i = 0; i < ToolBox.GetWidgets.Items.Count; i++)
                    {
                        if (IsSelectedPb == (ToolBox.GetWidgets.Items[i] as PictureBox))
                        {
                            ToolBox.WidgetsAnchors[i, 4] = materialCheckBox3.Checked;
                        }
                    }
                }
                else
                {
                    if (IsSelectedPb.Name.ToString() != "HudGrid")
                        ToolBox.ImageAnchors[GetImageIndex(IsSelectedPb), 4] = materialCheckBox3.Checked;
                }
                UpdateProps();
            }
        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
                
        }

        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField4_Click(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField3_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton4_Click_1(object sender, EventArgs e)
        {
            if (materialFlatButton4.Text == "Set Widget Name")
            {
                (comboBox1.SelectedItem as PictureBox).Name = materialSingleLineTextField5.Text;
                materialLabel1.Text = IsSelectedPb.Name.ToString() + " : Widget";

            }
            else
            {
                if (comboBox1.SelectedItem as PictureBox == comboBox1.SelectedItem && (materialFlatButton4.Text != "Set Widget Name"))
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "All files (*) | *.*";
                    ofd.InitialDirectory = "C:/";
                    //ofd.ShowDialog();
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        (comboBox1.SelectedItem as PictureBox).BackgroundImage = new Bitmap(ofd.FileName);
                    }
                }
                else if (comboBox1.SelectedItem as TextBox == comboBox1.SelectedItem)
                {
                    (comboBox1.SelectedItem as TextBox).Text = materialSingleLineTextField5.Text;
                }
            }
        }

        private void materialSingleLineTextField5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            //UIModels uim = new UIModels(CurrentPictureBoxSelected);
            //uim.Show();
        }

        private void materialLabel10_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton8_Click(object sender, EventArgs e)
        {
            //IsSelectedPb
            PictureBox oldSelected = IsSelectedPb;
            for (int i = 0; i < ToolBox.GetElem.Items.Count; i++)
            {
                if(ToolBox.GetElem.Items[i] == oldSelected)
                {
                    if (oldSelected.Text == "Widget")
                    {
                        ToolBox.WidBut.PerformClick();
                        PictureBox newWid = ToolBox.GetElem.Items[ToolBox.GetElem.Items.Count - 1] as PictureBox;
                        if (oldSelected.HasChildren)
                        {
                            for (int x = 0; x < ToolBox.GetElem.Items.Count; x++)
                            {
                                if((ToolBox.GetElem.Items[x] as PictureBox).Parent == oldSelected)
                                {
                                    if((ToolBox.GetElem.Items[x] as PictureBox).Text == "Image")
                                    {
                                        ToolBox.ImgBut.PerformClick();
                                        PictureBox newPic = ToolBox.GetElem.Items[ToolBox.GetElem.Items.Count - 1] as PictureBox;
                                        newPic.Left = (ToolBox.GetElem.Items[x] as PictureBox).Left;
                                        newPic.Top = (ToolBox.GetElem.Items[x] as PictureBox).Top;
                                        newPic.BackgroundImage = (ToolBox.GetElem.Items[x] as PictureBox).BackgroundImage;
                                        newPic.Width = (ToolBox.GetElem.Items[x] as PictureBox).Width;
                                        newPic.Height = (ToolBox.GetElem.Items[x] as PictureBox).Height;
                                        newPic.Parent = newWid;
                                       //TODO(replace name arrays)// newPic.Name = (ToolBox.GetElem.Items[x] as PictureBox).Name;
                                    }
                                    else
                                    {
                                        //Widget
                                        ToolBox.WidBut.PerformClick();
                                        PictureBox newPic = ToolBox.GetElem.Items[ToolBox.GetElem.Items.Count - 1] as PictureBox;
                                        newPic.Left = (ToolBox.GetElem.Items[x] as PictureBox).Left;
                                        newPic.Top = (ToolBox.GetElem.Items[x] as PictureBox).Top;
                                        newPic.BackgroundImage = (ToolBox.GetElem.Items[x] as PictureBox).BackgroundImage;
                                        newPic.Width = (ToolBox.GetElem.Items[x] as PictureBox).Width;
                                        newPic.Height = (ToolBox.GetElem.Items[x] as PictureBox).Height;
                                        newPic.Parent = newWid;
                                        newPic.Name = (ToolBox.GetElem.Items[x] as PictureBox).Name;
                                    }
                                }
                            }
                        }
                        newWid.Left = oldSelected.Left + 10;
                        newWid.Top = oldSelected.Top + 10;
                        newWid.BackgroundImage = oldSelected.BackgroundImage;
                        newWid.Width = oldSelected.Width;
                        newWid.Height = oldSelected.Height;
                        newWid.Parent = oldSelected.Parent;
                    }
                    else
                    {
                        ToolBox.ImgBut.PerformClick();
                        PictureBox newPic = ToolBox.GetElem.Items[ToolBox.GetElem.Items.Count - 1] as PictureBox;
                        newPic.Left = IsSelectedPb.Left + 10;
                        newPic.Top = IsSelectedPb.Top + 10;
                        newPic.BackgroundImage = IsSelectedPb.BackgroundImage;
                        newPic.Width = IsSelectedPb.Width;
                        newPic.Height = IsSelectedPb.Height;
                        newPic.Parent = IsSelectedPb.Parent;
                    }
                }
            }

            
        }

        public void SetLastName(PictureBox i)
        {
            for (int x = ToolBox.GetElem.Items.Count-1; x > 0; x--)
            {
                if ((ToolBox.GetElem.Items[x] as PictureBox).Text == "Image" && ToolBox.GetElem.Items[x] as PictureBox != i)
                {
                    Console.WriteLine((ToolBox.GetElem.Items[x] as PictureBox).Name + " = " + i.Name.ToString());
                    (ToolBox.GetElem.Items[x] as PictureBox).Name = i.Name.ToString();
                    break;
                }
            }
        }

        public void RemoveWidgetFromProps(int i)
        {
            for (int x = ToolBox.GetWidgets.Items.Count-1; x > 0; x--)
            {
                Console.WriteLine("Rewrite Codddddedeee vruh first");
                if ((ToolBox.GetWidgets.Items[x] as PictureBox).Text == "Widget" && (ToolBox.GetWidgets.Items[x] as PictureBox) == (ToolBox.GetWidgets.Items[i]) as PictureBox)
                {
                    //Array pb = new Array();
                    Console.WriteLine("Rewrite Codddddedeee vruh");
                    ToolBox.GetWidgets.Items[i] = ToolBox.GetWidgets.Items[x];
                    ToolBox.GetWidgets.Items.RemoveAt(x);
                    ToolBox.MaxComboBoxRegHOW = ToolBox.MaxComboBoxRegHOW-1;
                    ToolBox.CurComboBoxRegHOW = 0;
                    //Console.WriteLine((ToolBox.GetWidgets.Items[x] as PictureBox).Name + " = " + i.Name.ToString());
                    //(ToolBox.GetWidgets.Items[x] as PictureBox).Name = i.Name.ToString();
                    break;
                }
            }
        }


        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            PictureBox oldSelected = IsSelectedPb;
            for (int i = 0; i < ToolBox.GetElem.Items.Count; i++)
            {
                //TODO: 
                //1 : get current Index of GetElem (and GetWidgets if Widget)
                //2 : set the Name of the Last image 
                if((ToolBox.GetElem.Items[i] as PictureBox).Text == "Image" && (ToolBox.GetElem.Items[i] as PictureBox) == IsSelectedPb)
                {
                    SetLastName(oldSelected);
                    PictureBox oldPb = (ToolBox.GetElem.Items[i] as PictureBox);
                    ToolBox.GetElem.Items.RemoveAt(i);
                    oldPb.Parent.Controls.Remove(oldPb);

                }
                else if ((ToolBox.GetElem.Items[i] as PictureBox).Text == "Widget" && (ToolBox.GetElem.Items[i] as PictureBox) == IsSelectedPb && (ToolBox.GetElem.Items[i] as PictureBox).Name.ToString() != "HudGrid")
                {
                    PictureBox oldPb = (ToolBox.GetElem.Items[i] as PictureBox);
                    if (oldSelected.HasChildren)
                    {
                        for (int x = 0; x < ToolBox.GetElem.Items.Count; x++)
                        {
                            if((ToolBox.GetElem.Items[x] as PictureBox).Parent == ToolBox.GetElem.Items[i] as PictureBox)
                            {
                                PictureBox oldChild = ToolBox.GetElem.Items[x] as PictureBox;
                                if( oldChild.Text == "Image")
                                {
                                    IsSelectedPb = oldChild;
                                    materialFlatButton9.PerformClick();

                                    /*SetLastName(oldChild);
                                    ToolBox.GetElem.Items.RemoveAt(x);
                                    oldChild.Parent.Controls.Remove(oldChild);*/
                                }
                                else
                                {
                                    IsSelectedPb = oldChild;
                                    materialFlatButton9.PerformClick();

                                    for (int o = 0; o < ToolBox.GetWidgets.Items.Count; o++)
                                    {
                                        if (oldChild == (ToolBox.GetWidgets.Items[o] as PictureBox))
                                        {
                                            RemoveWidgetFromProps(o);
                                            //
                                            Form1.oldToolx.Update(); //UpdateProps();
                                        }
                                    }

                                }

                                //ToolBox.GetElem.Items.RemoveAt(x-1);
                                //oldPb.Controls.Remove(oldChild);
                                //ToolBox.GetElem.Items[x]
                            }
                        }
                    }
                    ToolBox.GetElem.Items.RemoveAt(i);
                    for (int f = 0; f < ToolBox.GetWidgets.Items.Count; f++)
                    {
                        if (oldSelected == (ToolBox.GetWidgets.Items[f] as PictureBox))
                        {
                            RemoveWidgetFromProps(f);
                            //
                            Form1.oldToolx.Update(); //UpdateProps();
                        }
                    }
                    oldSelected.Parent.Controls.Remove(oldSelected);
                    try
                    {
                        Luav3.Form1.oldPropx.Close();
                        PropertiesLua prop = new PropertiesLua();
                        prop.Show();
                        //prop.IsSelectedPb = Element;
                        //IsSelectedLb = materialLabel2;
                        prop.UpdateProps();
                        Form1.oldPropx = prop;
                    }
                    finally
                    {
                        // Report that the finally block is run, and show that the value of
                        // i has not been changed.
                        Console.WriteLine("\nIn the finally block in TryCast, i = {0}.\n", IsSelectedPb);
                    }
                }
            }
        }

        private void materialFlatButton10_Click(object sender, EventArgs e)
        {
            if(IsSelectedPb != null)
                IsSelectedPb.SendToBack();
        }

        private void materialFlatButton11_Click(object sender, EventArgs e)
        {
            if (IsSelectedPb != null)
                IsSelectedPb.BringToFront();
        }
    }
}
