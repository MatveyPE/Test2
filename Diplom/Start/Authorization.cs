using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Diplom
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Authorization.ActiveForm.Close();
        }
        User user = new User();
        private void button1_Click(object sender, EventArgs e)
        {
            Registration registration = new Registration();
            string s = textBox1.Text + " " + textBox2.Text;
            string a = "";
                    for (int i = 0; i < listBox1.Items.Count; i++)
                    {
                        a = listBox1.Items[i].ToString();
                        if (s == a)
                        {
                            Main form1 = new Main();
                            Authorization.ActiveForm.Close();
                            form1.Show();
                    break;
                        }
                    }
            if (s != a)
            {
                MessageBox.Show("Не верный логин или пароль");
            }
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            if (File.Exists("Registration.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                FileStream fs = new FileStream("Registration.xml", FileMode.Open);
                using (StreamReader sw = new StreamReader(fs))
                {
                    user = xmlSerializer.Deserialize(sw) as User;
                }
                if (user != null)
                {
                    listBox1.Items.Clear();
                    foreach (Users i in user.list)
                        listBox1.Items.Add(i);
                }
                else user = new User();
            }
        }   
    }
}
