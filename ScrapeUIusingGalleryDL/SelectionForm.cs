using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScrapeUIusingGalleryDL
{
    public partial class SelectionForm : Form
    {


        private ScrapeUI Scrapeui;
        public SelectionForm(string[] links)
        {
            InitializeComponent();
            listLinks.Items.AddRange(links);
        }
        public SelectionForm(ScrapeUI form1) // All of this BS is so i can change and access shit from the main window
        {
            InitializeComponent();
            Scrapeui = form1;
        }


        private void SelectionForm_Load(object sender, EventArgs e)
        {
            string filePath = @"Bin\Memory\Favs.txt";
            if (File.Exists(filePath))
            {
                string[] FavLinks = File.ReadAllLines(filePath);
                listLinks.DataSource = FavLinks;
            }
            else
            {
                MessageBox.Show("Favs.txt not found in Bin/Memory!");
            }
        }




        private void btnOk_Click_1(object sender, EventArgs e)
        {
            if (listLinks.SelectedItem != null)
            {
                string selectedLink = listLinks.SelectedItem.ToString();

                // Debugging: This will tell us if the SelectionForm actually 'sees' the link
                

                if (Scrapeui != null)
                {
                    Scrapeui.Link_to_Scape.Text = selectedLink;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: Main Form reference is null!");
                }
            }
            else
            {
                MessageBox.Show("Please select a link first!");
            }
        }
    }
}
