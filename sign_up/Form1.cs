using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sign_up
{
    public partial class Form1 : Form
    {
        public static string Firstname { get;  set; }
        public string user;
        public string password;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            bool flag = false;
            int idx = 0;
            Login old_user = new Login(email_txt.Text, pass_txt.Text, ref flag,ref idx);
            if (flag)
            {
                //Form6 form = new Form6();
                //form.UserName= User.dynamicArray.GetFirstname(idx);
                this.Hide();
                Form3 form3 = new Form3();
                form3.UserName = User.dynamicArray.GetFirstname(idx);
                form3.ShowDialog();
                this.Close();
            }
            else
            {
                email_txt.Text = "";
                pass_txt.Text = "";
            }
        }

        private void signup_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 form5 = new Form5(this);
            form5.ShowDialog();
            this.Show();
        }

        private void email_txt_TextChanged(object sender, EventArgs e)
        {

            User email= new User();
            email.Username = email_txt.Text;
           
        }

        private void pass_txt_TextChanged(object sender, EventArgs e)
        {
            User pass = new User();
            pass.Password = pass_txt.Text;
        }

        public void getdata(string username, string password, string firstname)
        {
            user = username;
            this.password = password;
            Firstname = firstname;
        }
        private void show_btn_Click_1(object sender, EventArgs e)
        {
            pass_txt.UseSystemPasswordChar = !pass_txt.UseSystemPasswordChar;
        }
    }

    class DynamicArray
    {
        private string[] array;
        private string[] array2;
        private int last_index;

        public DynamicArray(int size)
        {
            array = new string[size];
            array2 = new string[size];
            last_index = -1;
        }
        public void Add(string data,string first)
        {
            if (last_index == array.Length - 1)
            {
                Resize();
            }
            last_index++;
            array[last_index] = data;
            array2[last_index] = first; 
        }

        public void Resize()
        {
            string[] newArray = new string[array.Length * 2];
            string[] newArray2 = new string[array.Length * 2];
            for (int i = 0; i <= last_index; i++)
            {
                newArray[i] = array[i];
                newArray2[i] = array2[i];
            }
            array = newArray;
            array2 = newArray2;
        }
        public string GetFirstname(int index)
        {
            if (index >= 0 && index <= last_index)
            {
                return array2[index];
            }
            return null; // or throw an exception, depending on your requirements
        }
        public int Search(string data)
        {
            for (int i = 0; i <= last_index; i++)
            {
                if (array[i] == data)
                {
                    return i;
                }
            }
            return -1;
        }
    }

    class User
    {
        public static DynamicArray dynamicArray = new DynamicArray(100);

        public string Firstname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void Signup()
        {
            string userData = Username + Password;
            string fn = Firstname;
            if (dynamicArray.Search(userData) != -1)
            {
                MessageBox.Show("User already exists");
                return;
            }
            dynamicArray.Add(userData,fn);
        }
    }

    class Login : User
    { 
        public Login(string username, string password, ref bool flag,ref int idx)
        {
            string userData = username + password;
            int index = dynamicArray.Search(userData);
            if (index != -1)
            {
                flag = true;
                idx = index;
                return;
            }

            MessageBox.Show("User Not found");
        }
    }
}
