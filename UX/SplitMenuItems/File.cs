using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UX
{
    public partial class Form1 : Form
    {
        private void файлToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = System.IO.File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void проэктToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                judgment.Nodes.Clear();
                FillTreeNode(judgment.Nodes, folderBrowserDialog1.SelectedPath);
            }
        }

        private void FillTreeNode(TreeNodeCollection nodes, string path)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            TreeNode node = nodes.Add(directory.Name);
            node.Tag = directory.FullName;

            foreach (var file in directory.GetFiles())
            {
                TreeNode fileNode = node.Nodes.Add(file.Name);
                fileNode.Tag = file.FullName;
            }
            foreach (var subdir in directory.GetDirectories())
            {
                FillTreeNode(node.Nodes, subdir.FullName);
            }
        }

        private void сохронитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
