﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_up
{
    public partial class Form5 : Form
    {
        private Form1 form1Reference;
        public Form5(Form1 form1)
        {
            InitializeComponent();
            form1Reference = form1;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            label6.Size = new Size(66, 50);
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            string firstname = "", secondname = "", email = "", pass = "", check = "";
            //save first name
            firstname = firstname_txt.Text;
            //save second name
            secondname = secondname_txt.Text;
            //save email
            email = email_txt.Text;
            //save pass
            pass = pass_txt.Text;
            // check the pass
            check = conf_txt.Text;
            if (firstname != "" && secondname != "" && email != "" && pass != "")
            {
                if (pass == check)
                {
                    User userr = new User();
                    userr.Username = email;
                    userr.Password = pass;
                    userr.Firstname = firstname;
                    userr.Signup();
                    form1Reference.getdata(email, pass, firstname);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("the Password is wrong");
                    pass_txt.Text = "";
                    conf_txt.Text = "";
                }
            }
            else
            {
                MessageBox.Show("There are blanks that need to be completed.");
            }
            
            
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }

}
