using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    class Editor : TabControl
    {
        public RecentList recentList { get; }
        public void NewDocument(string fileName)
        {
            Document newDocum = new Document();

            if(fileName.Equals(""))
            {
                newDocum.Text = "new page";
            }
            else
            {
                newDocum.Text = Path.GetFileName(fileName);
                newDocum.FileName = fileName;
            }

            newDocum.Open();

            Controls.Add(newDocum);
        }

        public void CloseActiveDocument()
        {
            Document docum = Controls.OfType<Document>().ElementAt(this.SelectedIndex);

            if (!docum.Modified)
            {
                Controls.Remove(docum);
            }
            else
            {
                MessageBox.Show("Save file before closing", "Warning Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void SaveDocument()
        {
            Controls.OfType<Document>().ElementAt(this.SelectedIndex).SaveAs();
        }

        public void SaveDocumentAs(string fileName)
        {
            Document docum = Controls.OfType<Document>().ElementAt(this.SelectedIndex);

            if (docum.FileName == null || docum.FileName != fileName)
            {
                docum.FileName = fileName;
            }

            docum.SaveAs();
        }

        public void OpenDocByRecentIndex(int index)
        {
            
        }

        public bool DocumentOpened(string fileName)
        {
            foreach (Document doc in Controls)
            {
                if (doc.FileName == null) continue;

                if (doc.FileName.Equals(fileName))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
