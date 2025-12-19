using System.Diagnostics;
using System.IO;
using static System.Windows.Forms.LinkLabel;

namespace ScrapeUIusingGalleryDL
{
    public partial class ScrapeUI : Form
    {
        static readonly string AppdataFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData); //i used it this much i put it here to save time :P


        public ScrapeUI()
        {
            InitializeComponent();
        }

        private void Folder_Location_Browse_Button_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DownloadFolderLoaction.Text = dialog.SelectedPath;
                MessageBox.Show($"Downloaded Content will be put into {dialog.SelectedPath}\\gallery-dl", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Start_Scrape_Button_Click(object sender, EventArgs e)
        {

            if (!Link_to_Scape.Text.Contains("http"))
            {
                Status_State.Text = "Error: No link found or incomplete link";
                return;
            }
            if (!Directory.Exists(DownloadFolderLoaction.Text))
            {
                Status_State.Text = "Error: The Folder that you entered doesnt appear to exist";
                return;
            }
            if (!File.Exists("Bin\\Dependencies\\gallery-dl.exe"))
            {
                Status_State.Text = "Error: Could not find gallery-dl executable Scrape Aborted";
                return;
            }
            if (!File.Exists("Bin\\Memory\\ScrapedLinks.txt"))
            {
                File.Create("Bin\\Memory\\ScrapedLinks.txt").Close();
            }


            bool CookiesFromBrowser = false;
            bool EmulatedFireFox = false;
            if (Import_Cookies_From_browser_CheckBox.Checked)
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
                        Status_State.Text = "Error: No FireFox Directory Found Scrape Aborted";
                        return;
                    }


                }
                CookiesFromBrowser = true;
            }


            if (!Save_Option.Checked)
            {
                if (!File.ReadAllText("Bin\\Memory\\ScrapedLinks.txt").Contains(Link_to_Scape.Text))
                {
                    using (StreamWriter sw = new StreamWriter("Bin\\Memory\\ScrapedLinks.txt", true))
                    {
                        sw.WriteLine(Link_to_Scape.Text);
                    }
                }
            }




            if (CookieNeededDetection(Link_to_Scape.Text) && !CookiesFromBrowser) //If URL needs Cookies but User is not importing from browser
            {
                Status_State.Text = "Link requires Cookies searching Cookies Folder";
                foreach (string file in Directory.EnumerateFiles(Directory.GetCurrentDirectory() + "\\Bin\\Cookies"))
                {
                    string host = new Uri(Link_to_Scape.Text).Host.Replace("www.", "", StringComparison.OrdinalIgnoreCase); //Get host from URl so if input is https://x.com/elonmusk host will be x.com
                    if (file.Contains(host))
                    {
                        Status_State.Text = "Cookies for website Found";
                        StartGalleryDL($"--cookies \"{Path.GetFullPath(file)}\" \"{Link_to_Scape.Text}\"");

                        break;
                    }
                    Status_State.Text = $"Error: Could not Find cookies for domain {host}";
                }
            }
            else if (CookiesFromBrowser) //If user is importing cookies from browser
            {
                StartGalleryDL($"--cookies-from-browser firefox \"{Link_to_Scape.Text}\" ");
                if (EmulatedFireFox)
                {

                    ChangeStatus("Info: Sleeping for 5 seconds to give GalleryDl a head start");
                    
                    Thread.Sleep(5000);

                    ChangeStatus("Info: Deleting FireFox emulated Folder");
                  
                    Directory.Delete($"{AppdataFilePath}\\Mozilla\\Firefox\\", true);

                    ChangeStatus("Info: FireFox emulated Folder Deleted");
                   
                }
            }
            else //No cookies needed
            {
                StartGalleryDL(Link_to_Scape.Text);

            }
        }



        private void ScrapeUI_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists("Bin"))
            {
                Directory.CreateDirectory("Bin");
            }
            if (!Directory.Exists("Bin\\Cookies"))
            {
                Directory.CreateDirectory("Bin\\Cookies");
            }
            if (!Directory.Exists("Bin\\Memory"))
            {
                Directory.CreateDirectory("Bin\\Memory");
            }

            if (!File.Exists("Bin\\Memory\\CookieRequiredLinks.txt"))
            {
                string[] DefaultDomains = { "x.com", "twitter.com", "furaffinity.net", "pinterest.com" };
                File.Create("Bin\\Memory\\CookieRequiredLinks.txt").Close();
                foreach (string domain in DefaultDomains)
                {
                    File.AppendAllLines("Bin\\Memory\\CookieRequiredLinks.txt", new[] { domain });
                }
            }
            if (!File.Exists("Bin\\Memory\\SavedFilePath.txt")) //Have this check always last
            {
                Status_State.Text = "     Error: No Saved Path exists";
                return;
            }
            DownloadFolderLoaction.Text = File.ReadAllText("Bin\\Memory\\SavedFilePath.txt");
            Status_State.Text = $"Path: {File.ReadAllText("Bin\\Memory\\SavedFilePath.txt")} Loaded From SavedFilePath.txt";
        }
        private void Status_State_Click(object sender, EventArgs e)
        {

        }
        private void Save_Path_To_File_Button_Click(object sender, EventArgs e)
        {
            DialogResult Response = MessageBox.Show("Save and OverWrite Path?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Response == DialogResult.Yes)
            {
                if (!File.Exists("Bin\\Memory\\SavedFilePath.txt"))
                {
                    File.Create("Bin\\Memory\\SavedFilePath.txt").Close();
                }
                File.WriteAllText("Bin\\Memory\\SavedFilePath.txt", DownloadFolderLoaction.Text);
                Status_State.Text = $"Path: {DownloadFolderLoaction.Text} Saved to SavedFilePath.txt";
                return;
            }
            Status_State.Text = "                     Save Cancelled";

        }
        private void Load_Path_From_File_Button_Click(object sender, EventArgs e)
        {
            if (!File.Exists("Bin\\Memory\\SavedFilePath.txt"))
            {
                Status_State.Text = "Error: No Saved Path exists";
                return;
            }
            DownloadFolderLoaction.Text = File.ReadAllText("Bin\\Memory\\SavedFilePath.txt");
            Status_State.Text = $"Path: {File.ReadAllText("Bin\\Memory\\SavedFilePath.txt")} Loaded From SavedFilePath.txt";
        }


        private void Link_From_ClipBoard_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                Link_to_Scape.Text = Clipboard.GetText();
            }
            else
            {
                Status_State.Text = "      ClipBoard does not contain text data";

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

        private void button1_Click(object sender, EventArgs e)
        {
            EXTRA_Window EXTRA_Window = new EXTRA_Window(this);
            EXTRA_Window.Show();
            EXTRA_Window.BringToFront();
        }


        private void StartGalleryDL(string arguments)
        {
            using (Process GalleryDl = new Process())
            {
                GalleryDl.StartInfo.FileName = "Bin\\Dependencies\\gallery-dl.exe";
                GalleryDl.StartInfo.Arguments = arguments;
                GalleryDl.StartInfo.WorkingDirectory = DownloadFolderLoaction.Text;
                GalleryDl.Start();
                Status_State.Text = "                     Gallery-dl Started";


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", Directory.GetCurrentDirectory());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(DownloadFolderLoaction.Text))
            {
                Process.Start("explorer.exe", DownloadFolderLoaction.Text);

            }
            else
            {
                Status_State.Text = "            Download Folder Does not exist";
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

        private void Import_Cookies_From_browser_CheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void ChangeStatus(string status)
        {
            Invoke(new Action(() =>
            {
                Status_State.Text = status;
            }));
        }
    }
}
