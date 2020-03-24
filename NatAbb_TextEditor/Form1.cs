using System;
using System.IO;
using System.Windows.Forms;

namespace nathanabbanTextEditor
{
    public partial class NathanAbbanTextEditor : Form
    {
        static string fileName;
        static string sFileName;
        public NathanAbbanTextEditor()
        {
            InitializeComponent();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            fileName = null;
            sFileName = null;

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Filter = "Rich Text Files | *.rtf";
            od.DefaultExt = "rtf";
            DialogResult result = od.ShowDialog();
            if (result != DialogResult.Cancel)
            {
                fileName = od.FileName;
                richTextBox1.LoadFile(fileName);
                this.Text = sFileName = od.SafeFileName;
            }

        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
            {
                richTextBox1.SaveFile(fileName); 
                this.Text = sFileName;
            }
            else
            {
                SaveFileDialog sd = new SaveFileDialog();
                sd.Filter = "Rich Text Files | *.rtf";
                sd.DefaultExt = "rtf";
                DialogResult result = sd.ShowDialog();
                if (result != DialogResult.Cancel)
                {
                    fileName = sd.FileName;
                    richTextBox1.SaveFile(fileName);
                    this.Text = sFileName = Path.GetFileName(fileName);
                    

                }
            }

        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to save your file?", "Important Question", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel)
            {
                return;
            }
            else if (result == DialogResult.Yes) {
                SaveToolStripMenuItem_Click(sender, e);
            }
            Application.Exit();

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();

        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (sFileName != null)
            {

                this.Text = sFileName + "*";
            }
            else
            {
                this.Text = "New File";
            }

        }
        private void BoldToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily,richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ System.Drawing.FontStyle.Bold);

        }

        private void ItalicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ System.Drawing.FontStyle.Italic);

        }

        private void UnderlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ System.Drawing.FontStyle.Underline);

        }

        private void StrikeoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ System.Drawing.FontStyle.Strikeout);

        }

        private void RegularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new System.Drawing.Font(richTextBox1.SelectionFont.FontFamily, richTextBox1.SelectionFont.Size, richTextBox1.SelectionFont.Style ^ System.Drawing.FontStyle.Regular);
        }
    }
}
