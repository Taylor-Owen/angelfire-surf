using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace angelfire_surf
{
    public partial class Form1 : Form
    {
        usersList users_list = new usersList();

        public Form1()
        {
            InitializeComponent();
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
                users_list.fileLoaded = true;
                MessageBox.Show("Loaded: " + file.FileName.ToString());
          
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            if (users_list.fileLoaded == true)
            {
                String tmp = users_list.users[rng.Next(0, users_list.users.Length)];
                System.Diagnostics.Process.Start("http://angelfire.com/" + tmp);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
