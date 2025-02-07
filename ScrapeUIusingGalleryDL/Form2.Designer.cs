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
            Delay_Between_Scrapes = new CheckBox();
            ReScrape_Previous = new Button();
            ReScape_From_Specific_Domain = new Button();
            Domain_Of_Choice = new TextBox();
            New_Cookie_Needed_Domain = new TextBox();
            Add_New_Cookie_Domain_Button = new Button();
            Delay_between_scrapes_seconds = new TextBox();
            One_Scrape_CheckBox = new CheckBox();
            SuspendLayout();
            // 
            // Delay_Between_Scrapes
            // 
            Delay_Between_Scrapes.AutoSize = true;
            Delay_Between_Scrapes.Location = new Point(393, 22);
            Delay_Between_Scrapes.Name = "Delay_Between_Scrapes";
            Delay_Between_Scrapes.Size = new Size(216, 19);
            Delay_Between_Scrapes.TabIndex = 13;
            Delay_Between_Scrapes.Text = "Delay between Scrapes         seconds";
            Delay_Between_Scrapes.UseVisualStyleBackColor = true;
            Delay_Between_Scrapes.CheckedChanged += Delay_Between_Scrapes_CheckedChanged;
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
            // Domain_Of_Choice
            // 
            Domain_Of_Choice.Location = new Point(52, 172);
            Domain_Of_Choice.Name = "Domain_Of_Choice";
            Domain_Of_Choice.Size = new Size(205, 23);
            Domain_Of_Choice.TabIndex = 15;
            Domain_Of_Choice.Text = "example.com";
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
            // Delay_between_scrapes_seconds
            // 
            Delay_between_scrapes_seconds.Location = new Point(536, 14);
            Delay_between_scrapes_seconds.Name = "Delay_between_scrapes_seconds";
            Delay_between_scrapes_seconds.Size = new Size(20, 23);
            Delay_between_scrapes_seconds.TabIndex = 18;
            Delay_between_scrapes_seconds.Text = "5";
            // 
            // One_Scrape_CheckBox
            // 
            One_Scrape_CheckBox.AutoSize = true;
            One_Scrape_CheckBox.Checked = true;
            One_Scrape_CheckBox.CheckState = CheckState.Checked;
            One_Scrape_CheckBox.Location = new Point(393, 55);
            One_Scrape_CheckBox.Name = "One_Scrape_CheckBox";
            One_Scrape_CheckBox.Size = new Size(135, 19);
            One_Scrape_CheckBox.TabIndex = 19;
            One_Scrape_CheckBox.Text = "One Scrape at a time";
            One_Scrape_CheckBox.UseVisualStyleBackColor = true;
            One_Scrape_CheckBox.CheckedChanged += One_Scrape_CheckBox_CheckedChanged;
            // 
            // EXTRA_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(649, 299);
            Controls.Add(One_Scrape_CheckBox);
            Controls.Add(Delay_between_scrapes_seconds);
            Controls.Add(Add_New_Cookie_Domain_Button);
            Controls.Add(New_Cookie_Needed_Domain);
            Controls.Add(Domain_Of_Choice);
            Controls.Add(ReScape_From_Specific_Domain);
            Controls.Add(Delay_Between_Scrapes);
            Controls.Add(ReScrape_Previous);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "EXTRA_Window";
            Text = "Extra";
            Load += EXTRA_Window_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox Delay_Between_Scrapes;
        private Button ReScrape_Previous;
        private Button ReScape_From_Specific_Domain;
        private TextBox Domain_Of_Choice;
        private TextBox New_Cookie_Needed_Domain;
        private Button Add_New_Cookie_Domain_Button;
        private TextBox Delay_between_scrapes_seconds;
        private CheckBox One_Scrape_CheckBox;
    }
}