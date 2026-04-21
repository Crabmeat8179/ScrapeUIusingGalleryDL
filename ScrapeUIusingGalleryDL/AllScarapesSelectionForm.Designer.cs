namespace ScrapeUIusingGalleryDL
{
    partial class AllScarapesSelectionForm
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
            ListLinks = new ListBox();
            btnOk = new Button();
            SuspendLayout();
            // 
            // ListLinks
            // 
            ListLinks.FormattingEnabled = true;
            ListLinks.ItemHeight = 15;
            ListLinks.Location = new Point(12, 12);
            ListLinks.Name = "ListLinks";
            ListLinks.Size = new Size(362, 514);
            ListLinks.TabIndex = 1;
            ListLinks.SelectedIndexChanged += ListLinks_SelectedIndexChanged;
            // 
            // btnOk
            // 
            btnOk.Location = new Point(389, 21);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(108, 23);
            btnOk.TabIndex = 2;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // AllScarapesSelectionForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(519, 549);
            Controls.Add(btnOk);
            Controls.Add(ListLinks);
            Name = "AllScarapesSelectionForm";
            Text = "AllScarapesSelectionForm";
            Load += AllScarapesSelectionForm_Load_1;
            ResumeLayout(false);
        }

        #endregion

        private ListBox ListLinks;
        private Button btnOk;
    }
}