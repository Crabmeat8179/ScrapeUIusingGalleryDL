namespace ScrapeUIusingGalleryDL
{
    partial class SelectionForm
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
            listLinks = new ListBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // listLinks
            // 
            listLinks.FormattingEnabled = true;
            listLinks.ItemHeight = 15;
            listLinks.Location = new Point(12, 25);
            listLinks.Name = "listLinks";
            listLinks.Size = new Size(362, 514);
            listLinks.TabIndex = 0;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(380, 25);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(108, 23);
            btnOk.TabIndex = 1;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click_1;
            // 
            // SelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 553);
            Controls.Add(btnOk);
            Controls.Add(listLinks);
            Name = "SelectionForm";
            Text = "Favs";
            Load += SelectionForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listLinks;
        private Button btnOk;
    }
}