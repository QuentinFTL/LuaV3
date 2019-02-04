namespace Luav3
{
    partial class MainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CreateBut = new MaterialSkin.Controls.MaterialFlatButton();
            this.CreateProjText = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // CreateBut
            // 
            this.CreateBut.AutoSize = true;
            this.CreateBut.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CreateBut.Depth = 0;
            this.CreateBut.Enabled = false;
            this.CreateBut.Location = new System.Drawing.Point(35, 118);
            this.CreateBut.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.CreateBut.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateBut.Name = "CreateBut";
            this.CreateBut.Primary = false;
            this.CreateBut.Size = new System.Drawing.Size(125, 36);
            this.CreateBut.TabIndex = 0;
            this.CreateBut.Text = "Create Project";
            this.CreateBut.UseVisualStyleBackColor = true;
            this.CreateBut.Click += new System.EventHandler(this.CreateBut_Click);
            // 
            // CreateProjText
            // 
            this.CreateProjText.Depth = 0;
            this.CreateProjText.Hint = "Project Name";
            this.CreateProjText.Location = new System.Drawing.Point(35, 86);
            this.CreateProjText.MouseState = MaterialSkin.MouseState.HOVER;
            this.CreateProjText.Name = "CreateProjText";
            this.CreateProjText.PasswordChar = '\0';
            this.CreateProjText.SelectedText = "";
            this.CreateProjText.SelectionLength = 0;
            this.CreateProjText.SelectionStart = 0;
            this.CreateProjText.Size = new System.Drawing.Size(125, 23);
            this.CreateProjText.TabIndex = 1;
            this.CreateProjText.UseSystemPasswordChar = false;
            this.CreateProjText.Click += new System.EventHandler(this.CreateProjText_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(187, 86);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(108, 19);
            this.materialLabel1.TabIndex = 2;
            this.materialLabel1.Text = "materialLabel1";
            this.materialLabel1.Click += new System.EventHandler(this.materialLabel1_Click);
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.Enabled = false;
            this.materialFlatButton1.Location = new System.Drawing.Point(191, 118);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(110, 36);
            this.materialFlatButton1.TabIndex = 3;
            this.materialFlatButton1.Text = "Load Project";
            this.materialFlatButton1.UseVisualStyleBackColor = true;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 169);
            this.ControlBox = false;
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.CreateProjText);
            this.Controls.Add(this.CreateBut);
            this.DoubleBuffered = false;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialFlatButton CreateBut;
        private MaterialSkin.Controls.MaterialSingleLineTextField CreateProjText;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}