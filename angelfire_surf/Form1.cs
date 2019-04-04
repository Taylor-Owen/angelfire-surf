using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace angelfire_surf
{
    public partial class Form1 : Form
    {
        usersList users_list = new usersList();
        Config config = new Config();
        String current_page = "";
        WebClient webClient = new WebClient();

        public Form1()
        {
            InitializeComponent();
            //this.TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Title = "Open Users List";
            file.Filter = "Users File|*.users";
            file.InitialDirectory = @"C:\";
            if (file.ShowDialog() == DialogResult.OK)
            {
                long length = new FileInfo(file.FileName.ToString()).Length;
                String extension = new FileInfo(file.FileName.ToString()).Extension;
                if (length > 20000000)
                {
                    MessageBox.Show("ERROR: Too large of a file!", "ERROR: File too large");
                    return;
                }
                else if (extension != ".users")
                {
                    MessageBox.Show("ERROR: Not a users file! Not loading!", "ERROR: Not a Users File!");
                    return;
                }
                users_list.users = users_list.FileToArray(file.FileName.ToString());
                users_list.animeUsers = users_list.FilterArray(users_list.users, "anime");
                users_list.fileLoaded = true;
                MessageBox.Show("Loaded: " + file.FileName.ToString());
          
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GotoRandomSite(users_list.users);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GotoRandomSite(users_list.animeUsers);
        }

        private void GotoRandomSite(String[] array)
        {
            Random rng = new Random();
            if (users_list.fileLoaded == true)
            {
                current_page = array[rng.Next(0, array.Length)];

                //Are we checking sites before we give it to the user?
                if (config.checkValidity)
                    while (!isPageValid("http://angelfire.com/" + current_page))
                        current_page = array[rng.Next(0, array.Length)];

                labelCurrentPage.Text = current_page;
                //Open User's Web Browser.
                System.Diagnostics.Process.Start("http://angelfire.com/" + current_page);
            }

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            alwaysontopMenuItem.Checked = !alwaysontopMenuItem.Checked;
            config.windowsAlwaysOnTop = alwaysontopMenuItem.Checked;

            if (config.windowsAlwaysOnTop == true)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void checkPagesFor404OrDefaultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            checkPagesFor404OrDefaultToolStripMenuItem.Checked = !checkPagesFor404OrDefaultToolStripMenuItem.Checked;
            config.checkValidity = checkPagesFor404OrDefaultToolStripMenuItem.Checked;
        }

        private bool isPageValid(string url)
        {
            //TODO: Not use WebClient.
            string tmp = webClient.DownloadString(url);

            //Default angelfire check and 404
            if ((tmp.Contains("My Home Page")) || (tmp.Contains("Angelfire - error 404")))
                return false;

            return true;
        }

    }
}
