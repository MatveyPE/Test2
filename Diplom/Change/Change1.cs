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
    public partial class Change1 : Form
    {
        public Change1()
        {
            InitializeComponent();
        }
        public string s1="";
        public void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
            sql.Open();
            try 
            {
                SQLiteCommand sc = new SQLiteCommand(@"update Гости set ФИО='" + textBox1.Text + "',Номер_Комнаты='" + textBox2.Text + "',Серия_И_Номер_Паспорта='" + textBox3.Text + "',Дата_Заезда='" + textBox4.Text + "',Дата_Выезда='" + textBox5.Text + "'where id='" + Convert.ToInt32(s1) + "'", sql);
                sc.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Для измененния строки из таблицы, выберите на нужной строке ячейку ID"); }
            sql.Close();
            Close();
        }
    }
}
