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
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }
        public User User = new User();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "") 
            {
                User.list.Add(new Users(Convert.ToString(textBox1.Text), Convert.ToString(textBox2.Text)));
                listBox1.Items.Clear();
                foreach (Users i in User.list)
                    listBox1.Items.Add(i);
                MessageBox.Show("Пользователь зарегестрирован");
                ActiveForm.Close();
            }
            else
            {
                MessageBox.Show("Логин или пароль не введён");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        
        private void Registration_Load(object sender, EventArgs e)
        {
            if (File.Exists("Registration.xml"))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
                FileStream fs = new FileStream("Registration.xml", FileMode.Open);
                using (StreamReader sw = new StreamReader(fs))
                {
                    User = xmlSerializer.Deserialize(sw) as User;
                }
                if (User != null) {
                    listBox1.Items.Clear();
                    foreach (Users i in User.list)
                        listBox1.Items.Add(i);
                } 
                else User = new User();
            }
        }

        private void Registration_FormClosing(object sender, FormClosingEventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(User));
            FileStream fs = new FileStream("Registration.xml", FileMode.Create);
            using (StreamWriter sw = new StreamWriter(fs))
            {
                xmlSerializer.Serialize(sw, User);
            }
        }
    }
}
