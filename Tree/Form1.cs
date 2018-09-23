using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tree
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add(CreateDirectoryInNode(new DirectoryInfo(@"C:\Users\davom")));
        }

        static List<TreeNode> listNode = new List<TreeNode>();

        private static TreeNode CreateDirectoryInNode(DirectoryInfo directory)
        {
            var treeNode = new TreeNode(directory.Name);
            try
            {
                foreach (var dir in directory.GetDirectories())
                    treeNode.Nodes.Add(CreateDirectoryInNode(dir));

                foreach (var file in directory.GetFiles())
                    treeNode.Nodes.Add(new TreeNode(file.Name));
            }
            catch(Exception ex)
            {

            }

            return treeNode;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
