using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;


namespace Diplom
{
    public partial class Add2 : Form
    {
        public Add2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
            SQLiteCommand sc = new SQLiteCommand(@"insert into Касса(Дата,Номер_Комнаты,ФИО_Гостя,Итого) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"+ textBox4.Text +"')", sql);
            sql.Open();
            sc.ExecuteNonQuery();
            sql.Close();
            Close();
        }
    }
}
