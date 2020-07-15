using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.SQLite;
using Excel = Microsoft.Office.Interop.Excel;

namespace Diplom
{
    public partial class Settlement : Form
    {
        public Settlement()
        {
            InitializeComponent();
        }
         public string[] months = { "01", "02", "03", "04", "05","06", "07", "08", "09", "10", "11", "12" };
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] years = new string[100];
            int a = 0;
            for (int i = 2020; i < 2101; i++)
            {
                years[a] = i.ToString();
                a++;
            }
            listBox2.Items.AddRange(years);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Excel.Application ex = new Microsoft.Office.Interop.Excel.Application();
            ex.Visible = true;
            ex.SheetsInNewWorkbook = 12;
            Excel.Workbook workBook = ex.Workbooks.Add(Type.Missing);
            ex.DisplayAlerts = false;
            var currentYear1 = DateTime.Now.Year;
            for (int i =0; i < 12; i++)
            {
                Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(i+1);
                sheet.StandardWidth = 3;
                sheet.Name = months[i];
                sheet.Cells[1, 1] = String.Format("Номер отеля | День");
                if (months[i] == "01" || months[i] == "03" || months[i] == "05" || months[i] == "07" || months[i] == "08" || months[i] == "10" || months[i] == "12")
                {
                    
                    for (int j = 2; j < 33; j++)
                        sheet.Cells[j] = String.Format("{0}", j - 1);
                    for (int j = 2; j < 17; j++)
                        sheet.Cells[j, 1] = String.Format("{0}", j - 1);
                }
                if (months[i] == "02")
                {
                   
                    for (int j = 2; j < 31; j++)
                        sheet.Cells[j] = String.Format("{0}", j - 1);
                    for (int j = 2; j < 17; j++)
                        sheet.Cells[j, 1] = String.Format("{0}", j - 1);
                }
                if (months[i] == "04"|| months[i] == "06" || months[i] == "09" || months[i] == "11")
                {
                    
                    for (int j = 2; j < 32; j++)
                        sheet.Cells[j] = String.Format("{0}", j - 1);
                    for (int j = 2; j < 17; j++)
                        sheet.Cells[j, 1] = String.Format("{0}", j - 1);
                }
            }
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
            sql.Open();
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
            string Date1, Date2, Number = "";
            for (int j = 0; j < count; j++)
            {
                SQLiteCommand sc = new SQLiteCommand("select Дата_Заезда from Гости where id='" + b[j] + "'", sql);
                SQLiteCommand sc1 = new SQLiteCommand("select Дата_Выезда from Гости where id='" + b[j] + "'", sql);
                SQLiteCommand sc2 = new SQLiteCommand("select Номер_Комнаты from Гости where id= '" + b[j] + "'", sql);
                Date1 = sc.ExecuteScalar().ToString();
                Date2 = sc1.ExecuteScalar().ToString();
                Number = sc2.ExecuteScalar().ToString();
                var currentYear = DateTime.Now.Date;

                string[] words = Date1.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries); //разделение даты
                string Day = words[0]; string Month = words[1]; string Year = words[2];

                words = Date2.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string Day1 = words[0]; string Month1 = words[1]; string Year1 = words[2];
                Excel.Worksheet sheet = (Excel.Worksheet)ex.Worksheets.get_Item(Month);
                if (listBox2.SelectedItem.ToString() == currentYear1.ToString())
                {
                    if (Month == Month1)
                    {
                        ((Excel.Worksheet)ex.Application.ActiveWorkbook.Sheets[Month]).Select();
                        Excel.Range range2 = ex.get_Range(ex.Cells[Convert.ToInt32(Number) + 1, Convert.ToInt32(Day) + 1], ex.Cells[Convert.ToInt32(Number) + 1, Convert.ToInt32(Day1) + 1]);
                        range2.Interior.Color = ColorTranslator.ToOle(Color.Blue);
                    }
                    else
                    {
                        string h = Day1;
                        for (int a =Convert.ToInt32(Month); a <= Convert.ToInt32(Month1); a++)
                        {
                            if (a != Convert.ToInt32(Month1))
                            {
                                if (a == 01 || a == 03 || a == 05 || a == 07 || a == 08 || a == 10 || a == 12) { Day1 = "31"; }
                                else if (a == 02) { Day1 = "29"; }
                                else if (a == 04 || a == 06 || a == 09 || a == 11) { Day1 = "30"; }
                            }
                            ((Excel.Worksheet)ex.Application.ActiveWorkbook.Sheets[a]).Select();
                            Excel.Range range2 = ex.get_Range(ex.Cells[Convert.ToInt32(Number) + 1, Convert.ToInt32(Day) + 1], ex.Cells[Convert.ToInt32(Number) + 1, Convert.ToInt32(Day1) + 1]);
                            range2.Interior.Color = ColorTranslator.ToOle(Color.Blue);
                            Day1 = h;
                        }
                    }
                }
            }
            sql.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
    }
}

