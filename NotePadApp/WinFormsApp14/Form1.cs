﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp14
{
    public partial class Form1 : Form
    {
        bool isChanged = false;
        bool isCurrentFileSaved = false;
        string filename = "New File";
        string filePath = "";
        public Form1()
        {
            InitializeComponent();
            this.Text = filename;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult r = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if (isCurrentFileSaved)
                    {
                        File.WriteAllText(filePath, richTextBox1.Text);
                        isCurrentFileSaved = true;
                    }
                    else
                    {
                        SaveFileDialog f = new SaveFileDialog();
                        f.Filter = "Text File|*.txt";
                        f.ShowDialog();
                        File.WriteAllText(f.FileName, richTextBox1.Text);
                        isCurrentFileSaved = true;

                        filename = f.FileName;
                        filePath = f.FileName;
                    }
                    isChanged = false;
                    this.Text = filename;
                    this.Close();
                }
                else if (r == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult r = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if (isCurrentFileSaved)
                    {
                        File.WriteAllText(filePath, richTextBox1.Text);
                        isCurrentFileSaved = true;
                    }
                    else
                    {
                        SaveFileDialog f = new SaveFileDialog();
                        f.Filter = "Text File|*.txt";
                        f.ShowDialog();
                        File.WriteAllText(f.FileName, richTextBox1.Text);
                        isCurrentFileSaved = true;

                        filename = f.FileName;
                        filePath = f.FileName;
                    }
                    isChanged = false;
                    this.Text = filename;
                }
                else if (r == DialogResult.No)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.ShowDialog();
                    string text = File.ReadAllText(ofd.FileName);
                    richTextBox1.Text = text;
                    this.Name = ofd.FileName;
                    filename = ofd.FileName;
                    filePath = ofd.FileName;
                    isCurrentFileSaved = true;
                    this.Text = filename;
                    isChanged = false;
                }

            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                string text = File.ReadAllText(ofd.FileName);
                richTextBox1.Text = text;
                this.Name = ofd.FileName;
                filename = ofd.FileName;
                filePath = ofd.FileName;
                isCurrentFileSaved = true;
                this.Text = filename;
                isChanged = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isChanged)
            {
                DialogResult r = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                if (r == DialogResult.Yes)
                {
                    if (isCurrentFileSaved)
                    {
                        File.WriteAllText(filePath, richTextBox1.Text);
                        isCurrentFileSaved = true;
                    }
                    else
                    {
                        SaveFileDialog f = new SaveFileDialog();
                        f.Filter = "Text File|*.txt";
                        f.ShowDialog();
                        File.WriteAllText(f.FileName, richTextBox1.Text);
                        isCurrentFileSaved = true;

                        filename = f.FileName;
                        filePath = f.FileName;
                    }
                    isChanged = false;
                    this.Text = filename;

                }
                else if (r == DialogResult.No)
                {
                    richTextBox1.Text = "";
                }
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isChanged = true;
            this.Text = filename + "*";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isCurrentFileSaved)
            {
                File.WriteAllText(filePath, richTextBox1.Text);
                isCurrentFileSaved = true;
            }
            else
            {
                SaveFileDialog f = new SaveFileDialog();
                f.Filter = "Text File|*.txt";
                f.ShowDialog();
                File.WriteAllText(f.FileName, richTextBox1.Text);
                isCurrentFileSaved = true;

                filename = f.FileName;
                filePath = f.FileName;
            }
            isChanged = false;
            this.Text = filename;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog f = new SaveFileDialog();
            f.Filter = "Text File|*.txt";
            f.ShowDialog();
            File.WriteAllText(f.FileName, richTextBox1.Text);
            filename = f.FileName;
            filePath = f.FileName;
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDialog a = new PrintDialog();
            a.ShowDialog();

        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog a = new PrintPreviewDialog();
            a.ShowDialog();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog();
            f.ShowDialog();
            richTextBox1.Font = f.Font;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (isChanged)
                {
                    DialogResult r = MessageBox.Show("Do you want to save your changes?", "Unsaved Changes", MessageBoxButtons.YesNoCancel);
                    if (r == DialogResult.Yes)
                    {
                        if (isCurrentFileSaved)
                        {
                            File.WriteAllText(filePath, richTextBox1.Text);
                            isCurrentFileSaved = true;
                        }
                        else
                        {
                            SaveFileDialog f = new SaveFileDialog();
                            f.Filter = "Text File|*.txt";
                            f.ShowDialog();
                            File.WriteAllText(f.FileName, richTextBox1.Text);
                            isCurrentFileSaved = true;

                            filename = f.FileName;
                            filePath = f.FileName;
                        }
                        isChanged = false;
                        this.Text = filename;
                        this.Close();
                    }
                    else if (r == DialogResult.No)
                    {
                        this.Close();
                    }
                }
                else
                {
                    this.Close();
                }
            } else if (e.KeyCode == Keys.Left)
            {
                richTextBox1.RightToLeft = RightToLeft.No;
            } else if ((e.KeyCode == Keys.Right))
            {
                richTextBox1.RightToLeft = RightToLeft.Yes;
            }
        }
    }
}
