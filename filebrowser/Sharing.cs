using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace filebrowser
{
    public partial class Sharing : Form
    {
        public Sharing()
        {
            InitializeComponent();
        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Add_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = listBox1.SelectedItem.ToString();

            if (curItem == "jonas.becher@stud.hn.de")
            {
                checkBox_Read.Checked = true;
                checkBox_Write.Checked = true;
            }

            else if (curItem == "eg.pldv@gmail.com")
            {
                checkBox_Read.Checked = true;
                checkBox_Write.Checked = false;
            }

            else 
            {
                checkBox_Read.Checked = false;
                checkBox_Write.Checked = false;
            }

        }
    }
}
