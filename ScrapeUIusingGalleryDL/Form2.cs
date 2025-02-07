
using System.Diagnostics;
using static System.Windows.Forms.DataFormats;

namespace ScrapeUIusingGalleryDL
{
    public partial class EXTRA_Window : Form
    {
        private ScrapeUI Scrapeui;
        public EXTRA_Window()
        {
            InitializeComponent();
        }
        public EXTRA_Window(ScrapeUI form1) // All of this BS is so i can change and access shit from the main window
        {
            InitializeComponent();
            Scrapeui = form1;
        }
        private void EXTRA_Window_Load(object sender, EventArgs e)
        {

        }

        private void ReScrape_Previous_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Bin\\Memory\\ScrapedLinks.txt"))
            {
                Scrapeui.Status_State.Text = "Error: No Link List Exists";
                return;
            }
            if (!Directory.Exists(Scrapeui.DownloadFolderLoaction.Text))
            {
                Scrapeui.Status_State.Text = "Error: The Folder that you entered doesnt appear to exist";
                return;
            }

            string[] Links = File.ReadAllLines("Bin\\Memory\\ScrapedLinks.txt");
            DialogResult Response = MessageBox.Show($"Are you sure you want to ReScrape all your links? You have {Links.Length} Saved", "Are you sure", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Response == DialogResult.No)
            {
                Scrapeui.Status_State.Text = $"                     ReScrape Cancelled";

                return;
            }
            Scrapeui.Status_State.Text = $"                     Links 0/{Links.Length} Complete";

            for (int i = 0; i < Links.Length; i++)
            {
                if (Delay_Between_Scrapes.Checked)
                {
                    Thread.Sleep(Int32.Parse(Delay_between_scrapes_seconds.Text) * 1000);
                }

                if (CookieNeededDetection(Scrapeui.Link_to_Scape.Text))
                {
                    Invoke(new Action(() =>
                    {
                        Scrapeui.Status_State.Text = "Link requires Cookies searching Cookies Folder";
                    }));
                    foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\Cookies"))
                    {
                        Uri uri = new Uri(Scrapeui.Link_to_Scape.Text);
                        string host = uri.Host;
                        if (host.StartsWith("www."))
                        {
                            host = host.Substring(4);
                        }
                        if (file.Contains(host))
                        {
                            Invoke(new Action(() =>
                            {
                                Scrapeui.Status_State.Text = "Cookies for website Found";
                            }));
                            StartGalleryDL($"--cookies \"{Path.GetFullPath(file)}\" \"{Links[i]}\"");

                            Invoke(new Action(() =>
                            {
                                Scrapeui.Status_State.Text = $"                     Links {i + 1}/{Links.Length} Complete";
                            }));
                            break;
                        }
                    }
                }
                else
                {
                    StartGalleryDL(Links[i]);


                    //Status_State.Text = $"                     Links {i + 1}/{Links.Length} Complete";
                    Invoke(new Action(() =>
                    {
                        Scrapeui.Status_State.Text = $"                     Links {i + 1}/{Links.Length} Complete";
                    }));
                }
            }
        }

        private void StartGalleryDL(string arguments)
        {
            using (Process GalleryDl = new Process())
            {
                GalleryDl.StartInfo.FileName = "Bin\\Dependencies\\gallery-dl.exe";
                GalleryDl.StartInfo.Arguments = arguments;
                GalleryDl.StartInfo.WorkingDirectory = Scrapeui.DownloadFolderLoaction.Text;
                GalleryDl.Start();
                if (One_Scrape_CheckBox.Checked)
                {
                    GalleryDl.WaitForExit();
                }
            }
        }

        public static bool CookieNeededDetection(string URL)
        {
            string[] Cookie_Needed_Domains = File.ReadAllLines("Bin\\Memory\\CookieRequiredLinks.txt");

            foreach (string domain in Cookie_Needed_Domains)
            {
                if (URL.Contains(domain))
                {
                    return true;
                }
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e) //ReScape_From_Specific_Domain
        {
            if (!File.Exists("Bin\\Memory\\ScrapedLinks.txt"))
            {
                Scrapeui.Status_State.Text = "Error: No Link List Exists";
                return;
            }
            DialogResult Response = MessageBox.Show($"Are you sure you want to rescrape all your saved links for {Domain_Of_Choice.Text}", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Response == DialogResult.No)
            {
                Scrapeui.Status_State.Text = $"                     ReScrape Cancelled";

                return;
            }
            string[] Links = File.ReadAllLines("Bin\\Memory\\ScrapedLinks.txt");
            Invoke(new Action(() =>
            {
                Scrapeui.Status_State.Text = $"                     Links 0/{Links.Length} Complete";
            }));
            bool CookiesNeededForDomain = CookieNeededDetection(Domain_Of_Choice.Text);
            for (int i = 0; i < Links.Length; i++)
            {
                if (Delay_Between_Scrapes.Checked)
                {
                    Thread.Sleep(Int32.Parse(Delay_between_scrapes_seconds.Text) * 1000);
                }
                if (Links[i].Contains(Domain_Of_Choice.Text))
                {
                    //MessageBox.Show($"{Links[i]} is on the domain {Domain_Of_Choice.Text}");
                    if (CookiesNeededForDomain)
                    {
                        foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\Cookies"))
                        {
                            if (file.Contains(Domain_Of_Choice.Text))
                            {
                                StartGalleryDL($"--cookies \"{Path.GetFullPath(file)}\" \"{Links[i]}\"");
                            }
                        }
                    }
                    else
                    {
                        StartGalleryDL(Links[i]);
                    }
                }
                else { }
                Invoke(new Action(() =>
                {
                    Scrapeui.Status_State.Text = $"                     Links {i + 1}/{Links.Length} Complete";
                }));
            }
        }
        private void Delay_Between_Scrapes_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Add_New_Cookie_Domain_Button_Click(object sender, EventArgs e)
        {
            DialogResult Response = MessageBox.Show($"Add {New_Cookie_Needed_Domain.Text} to list of cookie required domains?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Response == DialogResult.No)
            {
                Scrapeui.Status_State.Text = $"                     Add Domain Cancelled";
                return;
            }
            string[] CurrentLinks = File.ReadAllLines("Bin\\Memory\\CookieRequiredLinks.txt");
            if (CurrentLinks.Contains(Domain_Of_Choice.Text))
            {
                Scrapeui.Status_State.Text = $"         {New_Cookie_Needed_Domain.Text} Already exists in Domain list";
                return;
            }
            File.AppendAllLines("Bin\\Memory\\CookieRequiredLinks.txt", new[] { New_Cookie_Needed_Domain.Text });
            Scrapeui.Status_State.Text = $"           {New_Cookie_Needed_Domain.Text} added to Cookies Required domains list";

        }

        private void One_Scrape_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!One_Scrape_CheckBox.Checked)
            {
                MessageBox.Show("Doing this will allow every scrape to run at once, which could cause issues. Some sites might reject or ban you, and if you're using authentication, your accounts could be affected due to the high volume of requests", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
