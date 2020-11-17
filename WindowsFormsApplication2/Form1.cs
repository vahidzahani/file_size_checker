using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
namespace WindowsFormsApplication2
{
   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            string path = textBox1.Text;
            if (File.Exists(path))
            {
                long length = new System.IO.FileInfo(path).Length;
                textBox2.Text = (length/1024/1024).ToString();
            }
            else
            {
                button1_Click(sender, e);
                MessageBox.Show ("NOTFIND");
                return;
                
            }
            if (textBox3.Text == "") textBox3.Text = "0";
            
            
            if (Convert.ToInt32(textBox2.Text)>=Convert.ToInt32(textBox3.Text))
            {
                //MessageBox.Show("is BIG");
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"C:\wait.wav");
                //player.Play();
                Console.Beep();
                //this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            try
            {
                progressBar1.Maximum = Convert.ToInt32(textBox3.Text);
                progressBar1.Value = Convert.ToInt32(textBox2.Text);
                                
            }
            catch (Exception)
            {               
                
            }
            

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text=="START")
            {
                timer1.Enabled = true;
                button1.Text = "STOP";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "START";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");

            //storing the values  
            key.SetValue("Setting1", textBox1.Text);
            key.Close(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");

            //storing the values  
            textBox1.Text=key.GetValue("Setting1", "INPUT ADDRESS").ToString();
            key.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                textBox1.Text = openFileDialog1.FileName;
            }
            
        }
    }
}
