using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            editor1.NewDocument("");

            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";

            ToolStripMenuItem newToolStrip = new ToolStripMenuItem("1toolstrip");
            newToolStrip.Text = "1.";

            recentFilesList.DropDownItems.Add(newToolStrip);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void newFile_Click(object sender, EventArgs e)
        {
            editor1.NewDocument("");
        }

        private void saveFile_Click(object sender, EventArgs e)
        {
            if (editor1.Controls.OfType<Document>().ElementAt(editor1.SelectedIndex).FileName == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

                editor1.SaveDocumentAs(saveFileDialog1.FileName);
            }
            else
            {
                editor1.SaveDocument();
            }
        }

        private void saveAsFile_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            editor1.SaveDocumentAs(saveFileDialog1.FileName);
        }

        private void openFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel) return;

            if (editor1.DocumentOpened(openFileDialog1.FileName))
            {
                MessageBox.Show("This document is already open.", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                editor1.NewDocument(openFileDialog1.FileName);
            }
        }

        private void closeFile_Click(object sender, EventArgs e)
        {
            editor1.CloseActiveDocument();
        }

        private void exitFile_Click(object sender, EventArgs e)
        {
            foreach(Document doc in editor1.Controls)
            {
                if (doc.Modified)
                {
                    MessageBox.Show("Save all files before exiting program", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            Application.Exit();
        }
    }
}
