
using System.Diagnostics;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.LinkLabel;

namespace ScrapeUIusingGalleryDL
{
    public partial class EXTRA_Window : Form
    {
        static readonly string AppdataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //i used it this much i put it here to save time :P

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
            this.Delay_trackbar.Maximum = 12;
            Refresh_Domain_ComboBox_Click(e,e);
            Domain_ComboBox.SelectedIndex = 0;

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

            bool CookiesFromBrowser = false;
            bool EmulatedFireFox = false;
            if (Scrapeui.Import_Cookies_From_browser_CheckBox.Checked)
            {
                CookiesFromBrowser = CheckForCompatibleBrowser();
                if (!CookiesFromBrowser)
                {
                    var browserProfiles = new Dictionary<string, string>
                    {
                        {"Zen", $"{AppdataFilePath}\\zen\\Profiles"},
                        {"LibreWolf", $"{AppdataFilePath}\\librewolf\\Profiles"}
                    };
                    foreach (var Browser in browserProfiles)
                    {
                        if (Directory.Exists(Browser.Value))
                        {
                            DialogResult Reponse = MessageBox.Show($"You do not have Firefox installed but you have {Browser.Key} browser installed, Would you like to attempt to use {Browser.Key} Browsers cookies", $"Try {Browser.Key}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Reponse == DialogResult.Yes)
                            {
                                EmulateFireFox(Browser.Value);
                                EmulatedFireFox = true;
                            }
                        }
                    }
                    if (!EmulatedFireFox) //If no browser is found or user presses no on prompts abort the scrape
                    {
                        ChangeStatus("Error: No FireFox Directory Found Scrape Aborted");
                        return;
                    }


                }
                CookiesFromBrowser = true;
            }

            for (int i = 0; i < Links.Length; i++)
            {
                if (this.Delay_trackbar.Value > 0)
                {
                    Thread.Sleep((this.Delay_trackbar.Value * 5) * 1000);
                }
                if (CookieNeededDetection(Scrapeui.Link_to_Scape.Text) && !EmulatedFireFox)
                {
                    ChangeStatus("Link requires Cookies searching Cookies Folder");
                    foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\Cookies"))
                    {
                        string host = new Uri(Scrapeui.Link_to_Scape.Text).Host.Replace("www.", "", StringComparison.OrdinalIgnoreCase);
                        if (file.Contains(host))
                        {
                            ChangeStatus("Cookies for website Found");
                            StartGalleryDL($"--cookies \"{Path.GetFullPath(file)}\" \"{Links[i]}\"");
                            ChangeStatus($"                     Links {i + 1}/{Links.Length} Complete");
                            break;
                        }
                    }
                }
                else if(CookiesFromBrowser)
                {
                    StartGalleryDL($"--cookies-from-browser firefox \"{Links[i]}\" ");
                    ChangeStatus($"                     Links {i + 1}/{Links.Length} Complete");
                }
                else
                {
                    StartGalleryDL(Links[i]);
                    ChangeStatus($"                     Links {i + 1}/{Links.Length} Complete");
                }
            }
            if (EmulatedFireFox)
            {
                Directory.Delete($"{AppdataFilePath}\\Mozilla\\Firefox\\", true);
                ChangeStatus("Info: FireFox emulated Folder Deleted");
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
            DialogResult Response = MessageBox.Show($"Are you sure you want to rescrape all your saved links for {Domain_ComboBox.GetItemText(Domain_ComboBox.SelectedItem)}", "Are you Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Response == DialogResult.No)
            {
                Scrapeui.Status_State.Text = $"                     ReScrape Cancelled";
                return;
            }
            string[] Links = File.ReadAllLines("Bin\\Memory\\ScrapedLinks.txt");
            ChangeStatus($"                     Links 0/{Links.Length} Complete");



            bool CookiesFromBrowser = false;
            bool EmulatedFireFox = false;
            if (Scrapeui.Import_Cookies_From_browser_CheckBox.Checked)
            {
                CookiesFromBrowser = CheckForCompatibleBrowser();
                if (!CookiesFromBrowser)
                {
                    var browserProfiles = new Dictionary<string, string>
                    {
                        {"Zen", $"{AppdataFilePath}\\zen\\Profiles"},
                        {"LibreWolf", $"{AppdataFilePath}\\librewolf\\Profiles"}
                    };
                    foreach (var Browser in browserProfiles)
                    {
                        if (Directory.Exists(Browser.Value))
                        {
                            DialogResult Reponse = MessageBox.Show($"You do not have Firefox installed but you have {Browser.Key} browser installed, Would you like to attempt to use {Browser.Key} Browsers cookies", $"Try {Browser.Key}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Reponse == DialogResult.Yes)
                            {
                                EmulateFireFox(Browser.Value);
                                EmulatedFireFox = true;
                            }
                        }
                    }
                    if (!EmulatedFireFox) //If no browser is found or user presses no on prompts abort the scrape
                    {
                        ChangeStatus("Error: No FireFox Directory Found Scrape Aborted");
                        return;
                    }
                }
                CookiesFromBrowser = true;
            }

            bool CookiesNeededForDomain = CookieNeededDetection(Domain_ComboBox.GetItemText(Domain_ComboBox.SelectedItem));
            for (int i = 0; i < Links.Length; i++)
            {
                if (this.Delay_trackbar.Value > 0)
                {
                    Thread.Sleep((this.Delay_trackbar.Value * 5) * 1000);
                }
                if (Links[i].Contains(Domain_ComboBox.GetItemText(Domain_ComboBox.SelectedItem)))
                {
                    //MessageBox.Show($"{Links[i]} is on the domain {Domain_Of_Choice.Text}");
                    if (CookiesNeededForDomain && !CookiesFromBrowser)
                    {
                        foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\Cookies"))
                        {
                            if (file.Contains(Domain_ComboBox.GetItemText(Domain_ComboBox.SelectedItem)))
                            {
                                StartGalleryDL($"--cookies \"{Path.GetFullPath(file)}\" \"{Links[i]}\"");
                                break;
                            }
                        }
                    }
                    else if(CookiesFromBrowser)
                    {
                        StartGalleryDL($"--cookies-from-browser firefox \"{Links[i]}\" ");
                        ChangeStatus($"                     Links {i + 1}/{Links.Length} Complete");
                    }
                    else
                    {
                        StartGalleryDL(Links[i]);
                    }
                }
                else { }

                ChangeStatus($"                     Links {i + 1}/{Links.Length} Complete");

            }
            if (EmulatedFireFox)
            {
                Directory.Delete($"{AppdataFilePath}\\Mozilla\\Firefox\\", true);
                ChangeStatus("Info: FireFox emulated Folder Deleted");
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
            if (CurrentLinks.Contains(New_Cookie_Needed_Domain.Text))
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

        private void ChangeStatus(string status)
        {
            Invoke(new Action(() =>
            {
                Scrapeui.Status_State.Text = status;
            }));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Refresh_Domain_ComboBox_Click(object sender, EventArgs e)
        {
            Domain_ComboBox.Items.Clear();
            string[] Links = File.ReadAllLines("Bin\\Memory\\ScrapedLinks.txt");
            string[] LinksInComboBox = new string[Links.Length];
            for(int i = 0; i < Links.Length; i++)
            {
                string host = new Uri(Links[i]).Host.Replace("www.", "", StringComparison.OrdinalIgnoreCase);
                if (!LinksInComboBox.Contains(host))
                {
                    Domain_ComboBox.Items.Add(host);
                    LinksInComboBox[i] = host;
                }
            }           
        }
        public static bool CheckForCompatibleBrowser()
        {
            if (Directory.Exists($"{AppdataFilePath}\\Mozilla\\Firefox\\Profiles"))
            {
                return true;
            }
            return false;
        }

        public static void EmulateFireFox(string BrowserProfilesPath) //passing in browser path so its easier to implment more in the future
        {

            Directory.CreateDirectory($"{AppdataFilePath}\\Mozilla\\Firefox\\Profiles\\ScrapeUIEmualtedFireFox");
            string[] dirs = Directory.GetDirectories(BrowserProfilesPath);
            foreach (string dir in dirs)
            {
                DirectoryInfo FoldersInFolder = new DirectoryInfo(dir);
                FileInfo[] files = FoldersInFolder.GetFiles("*.sqlite");
                foreach (FileInfo file in files)
                {
                    if (file.FullName.Contains("cookies.sqlite"))
                    {
                        File.Copy(file.FullName, $"{AppdataFilePath}\\Mozilla\\Firefox\\Profiles\\ScrapeUIEmualtedFireFox\\cookies.sqlite");
                        break;
                    }
                }
            }
        }
    }
}
