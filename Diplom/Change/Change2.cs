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
    public partial class Change2 : Form
    {
        public Change2()
        {
            InitializeComponent();
        }
        public string s1 = "";

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
            sql.Open();
            try
            {
                SQLiteCommand sc = new SQLiteCommand(@"update Касса set Дата='" + textBox1.Text + "',Номер_Комнаты='" + textBox2.Text + "',ФИО_Гостя='" + textBox3.Text + "',Итого='" + textBox4.Text + "'where id='" + Convert.ToInt32(s1) + "'", sql);
                sc.ExecuteNonQuery();
            }
            catch { MessageBox.Show("Для измененния строки из таблицы, выберите на нужной строке ячейку ID"); }
            sql.Close();
            Close();
        }
    }
}
