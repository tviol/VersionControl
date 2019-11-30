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
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        public Form1()
        {
            InitializeComponent();

            label1.Text = Resource1.FullName; // label1
            btnAdd.Text = Resource1.Add; // button1
            button2.Text = Resource1.SaveFile;
            button3.Text = Resource1.Delete;

            //listbox1
            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var u = new User()
            {
                FullName = textBox1.Text
                
            };
            users.Add(u);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
                {
                StreamWriter sw = new StreamWriter(sfd.FileName);

                    foreach (User u in users)
                    {
                        sw.Write(u.ID);
                        sw.Write(";");
                        sw.Write(u.FullName);
                        sw.WriteLine();
                    }
                sw.Close();
                }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            users.Remove((User)listUsers.SelectedItem);
        }
    }
}
