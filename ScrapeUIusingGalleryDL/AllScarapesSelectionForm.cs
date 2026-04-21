namespace ScrapeUIusingGalleryDL
{
    public partial class AllScarapesSelectionForm : Form
    {
        private ScrapeUI Scrapeui;

        public AllScarapesSelectionForm(ScrapeUI form1)
        {
            InitializeComponent();
            Scrapeui = form1;
        }

        

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ListLinks.SelectedItem != null)
            {
                string selectedLink = ListLinks.SelectedItem.ToString();

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

        private void ListLinks_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AllScarapesSelectionForm_Load_1(object sender, EventArgs e)
        {
            string filePath = @"Bin\Memory\ScrapedLinks.txt";
            string fullPath = Path.GetFullPath(filePath);

            //MessageBox.Show($"Looking for file at:\n{fullPath}");

            if (File.Exists(filePath))
            {
                string[] allLinks = File.ReadAllLines(filePath);
                //MessageBox.Show($"Found {allLinks.Length} links:\n{string.Join("\n", allLinks.Take(5))}");

                ListLinks.DataSource = null;
                ListLinks.DataSource = allLinks;
                //MessageBox.Show($"ListBox item count after setting: {ListLinks.Items.Count}");
            }
            else
            {
                MessageBox.Show($"FILE NOT FOUND at:\n{fullPath}");
            }
        }
    }
}