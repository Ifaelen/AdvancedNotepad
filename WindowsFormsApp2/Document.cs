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
    class Document : TabPage
    {
        public string FileName { set; get; }

        public bool HasName
        {
            get
            {
                if (FileName == null)
                {
                    return false;
                }
                else
                {
                    return true;
                };
            }
        }

        public string ShortName { get { return Path.GetFileName(FileName); } }

        public bool Modified
        {
            get
            {
                if(Text.Contains("*"))
                {
                    return true;
                }
                else
                {
                    return false;
                };
            }
        }

        public TextBox textBox;

        public void Open()
        {
            textBox = new TextBox();

            textBox.Parent = this;
            textBox.Multiline = true;
            textBox.Location = new Point(0, 0);
            textBox.Size = new Size(792, 397);

            if (HasName)
            {
                textBox.Text = File.ReadAllText(FileName);
            }

            textBox.TextChanged += TextBox_TextChanged;
        }

        public void SaveAs()
        {
            Text = ShortName;

            File.WriteAllText(FileName, textBox.Text);
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if(!Text.Contains("*") && Text != "new page")
            {
                Text += "*";
            }
        }
    }
}
