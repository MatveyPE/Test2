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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.SpringGreen;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = true;
            dataGridView1.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            label1.Visible = false;

            try
            {
                if (button7.BackColor == Color.SpringGreen) // отображение бд Касса
                {
                    SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
                    SQLiteCommand sc = new SQLiteCommand("select * from Касса", sql);
                    DataTable dt = new DataTable();
                    sql.Open();
                    SQLiteDataReader sdr = sc.ExecuteReader();
                    dt.Load(sdr);
                    dataGridView1.DataSource = dt;
                    sdr.Close();
                    sql.Close();
                }
            }
            catch { MessageBox.Show("База Данных не создана"); }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.SpringGreen;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = false;

            Clear clear = new Clear();
            clear.Show();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.SpringGreen;
            button5.BackColor = Color.White;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = false;

            Report report = new Report();
            report.Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.SpringGreen;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = true;

        }
        private void button6_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.SpringGreen;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = true;
            dataGridView1.Visible = true;
            button11.Visible = true;
            button12.Visible = true;
            button13.Visible = true;
            label1.Visible = false;

            try
            {
                if (button6.BackColor == Color.SpringGreen) //отображение бд Гости
                {
                    SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
                    SQLiteCommand sc = new SQLiteCommand("select * from Гости", sql);
                    DataTable dt = new DataTable();
                    sql.Open();
                    SQLiteDataReader sdr = sc.ExecuteReader();
                    dt.Load(sdr);
                    dataGridView1.DataSource = dt;
                    sdr.Close();
                    sql.Close();
                }
            }
            catch { MessageBox.Show("База Данных не создана"); }
        }
        private void button10_Click(object sender, EventArgs e)// создание таблицы для бд Гости (А)
        {
            try
            {
                if (button6.BackColor == Color.SpringGreen)
                {
                    SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
                    SQLiteCommand sc = new SQLiteCommand("create table Гости(id integer primary key autoincrement,ФИО text,Номер_Комнаты text,Серия_И_Номер_Паспорта text,Дата_Заезда string,Дата_Выезда string)", sql);
                    sql.Open();
                    sc.ExecuteNonQuery();
                    sql.Close();
                }
                else if (button7.BackColor == Color.SpringGreen) // создание таблицы для бд Касса (B)
                {
                    SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
                    SQLiteCommand sc = new SQLiteCommand("create table Касса(id integer primary key autoincrement,Дата string,Номер_Комнаты text,ФИО_Гостя text,Итого real)", sql);
                    sql.Open();
                    sc.ExecuteNonQuery();
                    sql.Close();
                }
            }
            catch { MessageBox.Show("База Данных уже создана"); }

        }
        private void button11_Click(object sender, EventArgs e) 
        {
            if (button6.BackColor == Color.SpringGreen) //Добавление (A)
            {
                Add1 d1 = new Add1();
                d1.Show();
            }
            else if (button7.BackColor == Color.SpringGreen) //Добавление (B)
            {
                Add2 d2 = new Add2();
                d2.Show();
            }
        }
        private void button12_Click(object sender, EventArgs e) 
        { if (button6.BackColor == Color.SpringGreen)// Удаление (A)
            {
                SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
                sql.Open();
                try
                {
                    string s = dataGridView1.CurrentCell.Value.ToString();
                    SQLiteCommand sc = new SQLiteCommand("delete from Гости where id='" + Convert.ToInt32(s) + "'", sql); sc.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Для удаления строки из таблицы, выделите всю строку"); }
                sql.Close();
            }
            else if (button7.BackColor == Color.SpringGreen) // Удаление (B)
            {
                
                
                SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
                sql.Open();
                try
                {
                    string s1 = dataGridView1.CurrentCell.Value.ToString();
                    SQLiteCommand sc = new SQLiteCommand("delete from Касса where id='" + Convert.ToInt32(s1) + "'", sql); sc.ExecuteNonQuery();
                }
                catch { MessageBox.Show("Для удаления строки из таблицы, Выделите всю строку"); }
                sql.Close();
            }
            
        }
        public void button13_Click(object sender, EventArgs e)
        {
            if (button6.BackColor == Color.SpringGreen)  //Изменение (А)
            {
                try
                {
                    string s = dataGridView1.CurrentCell.Value.ToString();
                    Change1 change1 = new Change1();
                    change1.Show();
                    change1.s1 = s;
                }
                catch { MessageBox.Show("Для изменения строки, выделите всю нужную строку"); }

            }
            if (button7.BackColor == Color.SpringGreen) //Изменение (B)
            {
                try
                {
                    string s = dataGridView1.CurrentCell.Value.ToString();
                    Change2 change2 = new Change2();
                    change2.Show();
                    change2.s1 = s;
                }
                catch { MessageBox.Show("Для изменения строки, выделите всю нужную строку"); }
            }
        }
        public void button2_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.White;
            button2.BackColor = Color.SpringGreen;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = false;

            Settlement settlement = new Settlement();
            settlement.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
            button1.BackColor = Color.SpringGreen;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = false;
            int z = 0;
            int s = 15;

            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
            sql.Open();
            var currentYear = DateTime.Now.Date;
            try
            {
                int count = 0;
                SQLiteCommand sc4 = new SQLiteCommand("select count (*) as '" + count + "'from Гости", sql); //кол-во строк в таблице
                count = Convert.ToInt32(sc4.ExecuteScalar());

                int[] b = new int[count]; //получение id
                int o = 0;
                SQLiteCommand sc3 = new SQLiteCommand("select id from Гости", sql);
                var mas1 = sc3.ExecuteReader();
                while (mas1.Read())
                {
                    b[o] = Convert.ToInt32(mas1["id"]);
                    o++;
                }
                for (int j = 0; j < count; j++)
                {
                    SQLiteCommand sc = new SQLiteCommand("select Дата_Заезда from Гости where id='" + b[j] + "'", sql);
                    SQLiteCommand sc1 = new SQLiteCommand("select Дата_Выезда from Гости where id='" + b[j] + "'", sql);
                    var Date1 = sc.ExecuteScalar().ToString();
                    var Date2 = sc1.ExecuteScalar().ToString();
                    DateTime dt1 = new DateTime();
                    DateTime dt2 = new DateTime();
                    dt1 =Convert.ToDateTime(Date1);
                    dt2 = Convert.ToDateTime(Date2);

                    if (currentYear >= dt1 && currentYear <= dt2)
                    {
                        z++; s--;
                    }
                }
                MessageBox.Show("Номеров занято: " + z + " Номеров свободно: " + s);
                sql.Close();
            }
            catch { MessageBox.Show("Ошибка"); };
        }
        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.SpringGreen;
            button1.BackColor = Color.White;
            button2.BackColor = Color.White;
            button6.BackColor = Color.White;
            button7.BackColor = Color.White;
            button8.BackColor = Color.White;
            button4.BackColor = Color.White;
            button5.BackColor = Color.White;

            button10.Visible = false;
            dataGridView1.Visible = false;
            button11.Visible = false;
            button12.Visible = false;
            button13.Visible = false;
            label1.Visible = false;
            try
            {
                System.Diagnostics.Process.Start(@"D:\VS\Diplom\Diplom\bin\Debug\YFMS.docx");
            }
            catch { MessageBox.Show("Файл не найден"); }
        }
    }
}
