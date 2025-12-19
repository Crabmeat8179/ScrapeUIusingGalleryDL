namespace ScrapeUIusingGalleryDL
{
    partial class ScrapeUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DownloadFolderLoaction = new TextBox();
            Folder_Location_Browse_Button = new Button();
            Start_Scrape_Button = new Button();
            Link_to_Scape = new TextBox();
            StatusStatic = new Label();
            Status_State = new Label();
            Load_Path_From_File_Button = new Button();
            Save_Path_To_File_Button = new Button();
            label1 = new Label();
            Link_From_ClipBoard = new Button();
            Save_Option = new CheckBox();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            Import_Cookies_From_browser_CheckBox = new CheckBox();
            SuspendLayout();
            // 
            // DownloadFolderLoaction
            // 
            DownloadFolderLoaction.Location = new Point(88, 111);
            DownloadFolderLoaction.Name = "DownloadFolderLoaction";
            DownloadFolderLoaction.Size = new Size(519, 23);
            DownloadFolderLoaction.TabIndex = 0;
            DownloadFolderLoaction.Text = "Folder location";
            // 
            // Folder_Location_Browse_Button
            // 
            Folder_Location_Browse_Button.Location = new Point(628, 111);
            Folder_Location_Browse_Button.Name = "Folder_Location_Browse_Button";
            Folder_Location_Browse_Button.Size = new Size(75, 23);
            Folder_Location_Browse_Button.TabIndex = 1;
            Folder_Location_Browse_Button.Text = "Browse";
            Folder_Location_Browse_Button.UseVisualStyleBackColor = true;
            Folder_Location_Browse_Button.Click += Folder_Location_Browse_Button_Click;
            // 
            // Start_Scrape_Button
            // 
            Start_Scrape_Button.Location = new Point(345, 275);
            Start_Scrape_Button.Name = "Start_Scrape_Button";
            Start_Scrape_Button.Size = new Size(75, 23);
            Start_Scrape_Button.TabIndex = 2;
            Start_Scrape_Button.Text = "Start";
            Start_Scrape_Button.UseVisualStyleBackColor = true;
            Start_Scrape_Button.Click += Start_Scrape_Button_Click;
            // 
            // Link_to_Scape
            // 
            Link_to_Scape.Location = new Point(88, 193);
            Link_to_Scape.Name = "Link_to_Scape";
            Link_to_Scape.Size = new Size(519, 23);
            Link_to_Scape.TabIndex = 3;
            Link_to_Scape.Text = "Link";
            // 
            // StatusStatic
            // 
            StatusStatic.AutoSize = true;
            StatusStatic.Location = new Point(359, 308);
            StatusStatic.Name = "StatusStatic";
            StatusStatic.Size = new Size(42, 15);
            StatusStatic.TabIndex = 4;
            StatusStatic.Text = "Status:";
            // 
            // Status_State
            // 
            Status_State.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Status_State.AutoEllipsis = true;
            Status_State.ImageAlign = ContentAlignment.MiddleRight;
            Status_State.Location = new Point(267, 335);
            Status_State.Name = "Status_State";
            Status_State.Size = new Size(304, 15);
            Status_State.TabIndex = 5;
            Status_State.Text = "                              Waiting";
            Status_State.Click += Status_State_Click;
            // 
            // Load_Path_From_File_Button
            // 
            Load_Path_From_File_Button.Location = new Point(713, 124);
            Load_Path_From_File_Button.Name = "Load_Path_From_File_Button";
            Load_Path_From_File_Button.Size = new Size(75, 23);
            Load_Path_From_File_Button.TabIndex = 6;
            Load_Path_From_File_Button.Text = "Load";
            Load_Path_From_File_Button.UseVisualStyleBackColor = true;
            Load_Path_From_File_Button.Click += Load_Path_From_File_Button_Click;
            // 
            // Save_Path_To_File_Button
            // 
            Save_Path_To_File_Button.Location = new Point(713, 98);
            Save_Path_To_File_Button.Name = "Save_Path_To_File_Button";
            Save_Path_To_File_Button.Size = new Size(75, 23);
            Save_Path_To_File_Button.TabIndex = 7;
            Save_Path_To_File_Button.Text = "Save";
            Save_Path_To_File_Button.UseVisualStyleBackColor = true;
            Save_Path_To_File_Button.Click += Save_Path_To_File_Button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(709, 75);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 8;
            label1.Text = "Load from File";
            // 
            // Link_From_ClipBoard
            // 
            Link_From_ClipBoard.Location = new Point(628, 193);
            Link_From_ClipBoard.Name = "Link_From_ClipBoard";
            Link_From_ClipBoard.Size = new Size(104, 23);
            Link_From_ClipBoard.TabIndex = 10;
            Link_From_ClipBoard.Text = "From ClipBoard";
            Link_From_ClipBoard.UseVisualStyleBackColor = true;
            Link_From_ClipBoard.Click += Link_From_ClipBoard_Click;
            // 
            // Save_Option
            // 
            Save_Option.AutoSize = true;
            Save_Option.Location = new Point(88, 222);
            Save_Option.Name = "Save_Option";
            Save_Option.Size = new Size(155, 19);
            Save_Option.TabIndex = 12;
            Save_Option.Text = "DO NOT SAVE THIS LINK";
            Save_Option.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(716, 331);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 13;
            button1.Text = "EXTRA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 331);
            button2.Name = "button2";
            button2.Size = new Size(110, 23);
            button2.TabIndex = 14;
            button2.Text = "Open WorkSpace";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 304);
            button3.Name = "button3";
            button3.Size = new Size(110, 23);
            button3.TabIndex = 15;
            button3.Text = "Open Downloads";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Import_Cookies_From_browser_CheckBox
            // 
            Import_Cookies_From_browser_CheckBox.AutoSize = true;
            Import_Cookies_From_browser_CheckBox.Location = new Point(426, 278);
            Import_Cookies_From_browser_CheckBox.Name = "Import_Cookies_From_browser_CheckBox";
            Import_Cookies_From_browser_CheckBox.Size = new Size(183, 19);
            Import_Cookies_From_browser_CheckBox.TabIndex = 16;
            Import_Cookies_From_browser_CheckBox.Text = "Import Cookies From Browser";
            Import_Cookies_From_browser_CheckBox.UseVisualStyleBackColor = true;
            Import_Cookies_From_browser_CheckBox.CheckedChanged += Import_Cookies_From_browser_CheckBox_CheckedChanged;
            // 
            // ScrapeUI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 359);
            Controls.Add(Import_Cookies_From_browser_CheckBox);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Save_Option);
            Controls.Add(Link_From_ClipBoard);
            Controls.Add(label1);
            Controls.Add(Save_Path_To_File_Button);
            Controls.Add(Load_Path_From_File_Button);
            Controls.Add(Status_State);
            Controls.Add(StatusStatic);
            Controls.Add(Link_to_Scape);
            Controls.Add(Start_Scrape_Button);
            Controls.Add(Folder_Location_Browse_Button);
            Controls.Add(DownloadFolderLoaction);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ScrapeUI";
            Text = "ScrapeUI";
            Load += ScrapeUI_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox DownloadFolderLoaction;
        private Button Folder_Location_Browse_Button;
        private Button Start_Scrape_Button;
        public TextBox Link_to_Scape;
        private Label StatusStatic;
        public Label Status_State;
        private Button Load_Path_From_File_Button;
        private Button Save_Path_To_File_Button;
        private Label label1;
        private Button Link_From_ClipBoard;
        private CheckBox Save_Option;
        private Button button1;
        private Button button2;
        private Button button3;
        public CheckBox Import_Cookies_From_browser_CheckBox;
    }
}
