using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication21
{
    public partial class Form1 : Form
    {
        int numred = 0;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Button btn in panel1.Controls)
            {
                if (r.Next(0, 2) == 1)
                {
                    btn.BackColor = Color.Red;
                    numred += 1;
                }
            }
            label1.Text = numred.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            timer1.Enabled = true;

            Button btn = (Button)sender;
            if (btn.BackColor == Color.Red)
            {
                btn.Visible = false;
                numred -= 1;
                label1.Text = numred.ToString();

            }
            else
            {
                label1.Text = "0";
                timer1.Enabled = false;
                count = 0;
                label2.Text = "0";
                MessageBox.Show("you lose");
                numred = 0;

                foreach (Button btnnn in panel1.Controls)
                {
                    btnnn.Visible = true;
                    btnnn.BackColor = Color.White;
                    if (r.Next(0, 2) == 1)
                    {
                        btnnn.BackColor = Color.Red;
                        numred += 1;
                    }
                }
                label1.Text = numred.ToString();
            }
            if (numred == 0)
            {
                label1.Text = "0";
                timer1.Enabled = false;
                count = 0;
                label2.Text = "0";
                MessageBox.Show("you win");
                

                foreach (Button btnn in panel1.Controls)
                {
                    btnn.Visible = true;
                    btnn.BackColor = Color.White;
                    if (r.Next(0, 2) == 1)
                    {
                        btnn.BackColor = Color.Red;
                        numred += 1;
                    }
                }
                label1.Text = numred.ToString();

            }
        }

        int count;
        private void timer1_Tick(object sender, EventArgs e)
        {
            count+= 100;
            label2.Text = count.ToString();

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Button btn = (Button)sender;
                if (btn.BackColor == Color.Red)
                {
                    btn.Visible = false;
                    numred -= 1;
                    label1.Text = numred.ToString();

                }
                else
                {
                    label1.Text = "0";
                    timer1.Enabled = false;
                    count = 0;
                    label2.Text = "0";
                    MessageBox.Show("you lose");
                    numred = 0;

                    foreach (Button btnnn in panel1.Controls)
                    {
                        btnnn.Visible = true;
                        btnnn.BackColor = Color.White;
                        if (r.Next(0, 2) == 1)
                        {
                            btnnn.BackColor = Color.Red;
                            numred += 1;
                        }
                    }
                    label1.Text = numred.ToString();
                }
                if (numred == 0)
                {
                    label1.Text = "0";
                    timer1.Enabled = false;
                    count = 0;
                    label2.Text = "0";
                    MessageBox.Show("you win");


                    foreach (Button btnn in panel1.Controls)
                    {
                        btnn.Visible = true;
                        btnn.BackColor = Color.White;
                        if (r.Next(0, 2) == 1)
                        {
                            btnn.BackColor = Color.Red;
                            numred += 1;
                        }
                    }
                    label1.Text = numred.ToString();

                }
            }
        }
    }
}
