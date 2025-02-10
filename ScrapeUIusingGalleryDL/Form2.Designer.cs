namespace ScrapeUIusingGalleryDL
{
    partial class EXTRA_Window
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
            ReScrape_Previous = new Button();
            ReScape_From_Specific_Domain = new Button();
            New_Cookie_Needed_Domain = new TextBox();
            Add_New_Cookie_Domain_Button = new Button();
            One_Scrape_CheckBox = new CheckBox();
            Delay_trackbar = new TrackBar();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            Domain_ComboBox = new ComboBox();
            Refresh_Domain_ComboBox = new Button();
            ((System.ComponentModel.ISupportInitialize)Delay_trackbar).BeginInit();
            SuspendLayout();
            // 
            // ReScrape_Previous
            // 
            ReScrape_Previous.Location = new Point(52, 22);
            ReScrape_Previous.Name = "ReScrape_Previous";
            ReScrape_Previous.Size = new Size(205, 52);
            ReScrape_Previous.TabIndex = 12;
            ReScrape_Previous.Text = "ReScrape all Previous links";
            ReScrape_Previous.UseVisualStyleBackColor = true;
            ReScrape_Previous.Click += ReScrape_Previous_Click;
            // 
            // ReScape_From_Specific_Domain
            // 
            ReScape_From_Specific_Domain.Location = new Point(52, 201);
            ReScape_From_Specific_Domain.Name = "ReScape_From_Specific_Domain";
            ReScape_From_Specific_Domain.Size = new Size(205, 51);
            ReScape_From_Specific_Domain.TabIndex = 14;
            ReScape_From_Specific_Domain.Text = "ReScrape Previous Links From Specific Domain";
            ReScape_From_Specific_Domain.UseVisualStyleBackColor = true;
            ReScape_From_Specific_Domain.Click += button1_Click;
            // 
            // New_Cookie_Needed_Domain
            // 
            New_Cookie_Needed_Domain.Location = new Point(393, 172);
            New_Cookie_Needed_Domain.Name = "New_Cookie_Needed_Domain";
            New_Cookie_Needed_Domain.Size = new Size(205, 23);
            New_Cookie_Needed_Domain.TabIndex = 16;
            New_Cookie_Needed_Domain.Text = "example.com";
            // 
            // Add_New_Cookie_Domain_Button
            // 
            Add_New_Cookie_Domain_Button.Location = new Point(393, 201);
            Add_New_Cookie_Domain_Button.Name = "Add_New_Cookie_Domain_Button";
            Add_New_Cookie_Domain_Button.Size = new Size(205, 51);
            Add_New_Cookie_Domain_Button.TabIndex = 17;
            Add_New_Cookie_Domain_Button.Text = "Add New Required Cookie Domain";
            Add_New_Cookie_Domain_Button.UseVisualStyleBackColor = true;
            Add_New_Cookie_Domain_Button.Click += Add_New_Cookie_Domain_Button_Click;
            // 
            // One_Scrape_CheckBox
            // 
            One_Scrape_CheckBox.AutoSize = true;
            One_Scrape_CheckBox.Checked = true;
            One_Scrape_CheckBox.CheckState = CheckState.Checked;
            One_Scrape_CheckBox.Location = new Point(414, 78);
            One_Scrape_CheckBox.Name = "One_Scrape_CheckBox";
            One_Scrape_CheckBox.Size = new Size(135, 19);
            One_Scrape_CheckBox.TabIndex = 19;
            One_Scrape_CheckBox.Text = "One Scrape at a time";
            One_Scrape_CheckBox.UseVisualStyleBackColor = true;
            One_Scrape_CheckBox.CheckedChanged += One_Scrape_CheckBox_CheckedChanged;
            // 
            // Delay_trackbar
            // 
            Delay_trackbar.LargeChange = 1;
            Delay_trackbar.Location = new Point(407, 27);
            Delay_trackbar.Name = "Delay_trackbar";
            Delay_trackbar.Size = new Size(194, 45);
            Delay_trackbar.TabIndex = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(439, 9);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 21;
            label1.Text = "Delay Between Scrapes";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(414, 57);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 22;
            label2.Text = "0";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(579, 58);
            label3.Name = "label3";
            label3.Size = new Size(19, 15);
            label3.TabIndex = 23;
            label3.Text = "60";
            // 
            // Domain_ComboBox
            // 
            Domain_ComboBox.FormattingEnabled = true;
            Domain_ComboBox.Location = new Point(52, 172);
            Domain_ComboBox.Name = "Domain_ComboBox";
            Domain_ComboBox.Size = new Size(124, 23);
            Domain_ComboBox.TabIndex = 24;
            Domain_ComboBox.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // Refresh_Domain_ComboBox
            // 
            Refresh_Domain_ComboBox.Location = new Point(182, 172);
            Refresh_Domain_ComboBox.Name = "Refresh_Domain_ComboBox";
            Refresh_Domain_ComboBox.Size = new Size(75, 23);
            Refresh_Domain_ComboBox.TabIndex = 25;
            Refresh_Domain_ComboBox.Text = "Refresh";
            Refresh_Domain_ComboBox.UseVisualStyleBackColor = true;
            Refresh_Domain_ComboBox.Click += Refresh_Domain_ComboBox_Click;
            // 
            // EXTRA_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 299);
            Controls.Add(Refresh_Domain_ComboBox);
            Controls.Add(Domain_ComboBox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Delay_trackbar);
            Controls.Add(One_Scrape_CheckBox);
            Controls.Add(Add_New_Cookie_Domain_Button);
            Controls.Add(New_Cookie_Needed_Domain);
            Controls.Add(ReScape_From_Specific_Domain);
            Controls.Add(ReScrape_Previous);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EXTRA_Window";
            Text = "Extra";
            Load += EXTRA_Window_Load;
            ((System.ComponentModel.ISupportInitialize)Delay_trackbar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button ReScrape_Previous;
        private Button ReScape_From_Specific_Domain;
        private TextBox New_Cookie_Needed_Domain;
        private Button Add_New_Cookie_Domain_Button;
        private CheckBox One_Scrape_CheckBox;
        private TrackBar Delay_trackbar;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox Domain_ComboBox;
        private Button Refresh_Domain_ComboBox;
    }
}