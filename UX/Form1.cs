using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void judgment_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            Console.WriteLine(e.Node.Tag);
            if (File.Exists(e.Node.Tag.ToString()))
            {
                TabPage newtabPage = new TabPage(e.Node.Text);

                RichTextBox richTextBox = new RichTextBox
                {
                    Dock = DockStyle.Fill,
                    Text = File.ReadAllText(e.Node.Tag.ToString())
                };
                richTextBox.TextChanged += (s, config) =>
                {
                    Console.WriteLine("s");
                };

                newtabPage.Controls.Add(richTextBox);
                tabControl1.TabPages.Add(newtabPage);
                //tabControl1.TabPages[1].Select();
                //tabControl1.TabPages[1].Focus();
            }
            else if (Directory.Exists(e.Node.Tag.ToString()))
            {
                Console.WriteLine("dir");
            }
            else
            {
                Console.WriteLine("ошибки");
            }
        }


    }
}
