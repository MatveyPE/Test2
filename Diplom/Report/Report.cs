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
using System.Data.SQLite;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Diplom
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            SQLiteConnection sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Cash.sqlite");
            DateTime dateTime = new DateTime();
            dateTime = DateTime.Now;
           // SQLiteCommand sc1 = new SQLiteCommand("select date('now')", sql);
            SQLiteCommand sc = new SQLiteCommand("select * from Касса where Дата='"+ dateTime.ToShortDateString() + "'", sql);
            DataTable dt = new DataTable();
            sql.Open();
            SQLiteDataReader sdr = sc.ExecuteReader();
            dt.Load(sdr);
            dataGridView2.DataSource = dt;
            sdr.Close();
            sql.Close();

            sql = new SQLiteConnection(@"Data Source=D:\VS\Diplom\Guest.sqlite");
            sc = new SQLiteCommand("select * from Гости where Дата_Заезда='" + dateTime.ToShortDateString() +"'", sql);
            dt = new DataTable();
            sql.Open();
            sdr = sc.ExecuteReader();
            dt.Load(sdr);
            dataGridView1.DataSource = dt;
            sdr.Close();
            sql.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(Directory.GetCurrentDirectory() + @"\Отчёт.pdf", FileMode.OpenOrCreate));
            doc.Open();
            BaseFont baseFont = BaseFont.CreateFont(@"Times New Roman.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Phrase jo = new Phrase("Наименование организации  ООО 'ЗУРО'", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLDITALIC, new BaseColor(Color.Black)));
            iTextSharp.text.Phrase jo1 = new Phrase(" ", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.BOLDITALIC, new BaseColor(Color.Black)));
            Paragraph a1 = new Paragraph(jo);
            Paragraph a2 = new Paragraph(jo1);
            doc.Add(a1);
            doc.Add(a2);
            PdfPTable table1 = new PdfPTable(5);
            PdfPTable table2 = new PdfPTable(4);

            /*
             * Заполнение таблицы №1 в отчёте
             */

            PdfPCell cell1 = new PdfPCell(new Phrase("ФИО", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table1.AddCell(cell1);
            cell1 = new PdfPCell(new Phrase("Номер Комнаты", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table1.AddCell(cell1);
            cell1 = new PdfPCell(new Phrase("Серия и Номер Паспорта", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table1.AddCell(cell1);
            cell1 = new PdfPCell(new Phrase("Дата Заезда", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table1.AddCell(cell1);
            cell1 = new PdfPCell(new Phrase("Дата Выезда", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table1.AddCell(cell1);

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 1; j < 6; j++)
                {
                    cell1 = new PdfPCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString(),
                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table1.AddCell(cell1);
                }
                
            }
            doc.Add(table1);
            doc.Add(a2);
            
           /*
            * Заполнение таблицы №2 в отчёте
            */
            PdfPCell cell2 = new PdfPCell(new Phrase("Дата", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table2.AddCell(cell2);
            cell2 = new PdfPCell(new Phrase("Номер Комнаты", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table2.AddCell(cell2);
            cell2 = new PdfPCell(new Phrase("ФИО Гостя", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table2.AddCell(cell2);
            cell2 = new PdfPCell(new Phrase("Итого", new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
            table2.AddCell(cell2);

            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                for (int j = 1; j < 5; j++)
                {
                    cell2 = new PdfPCell(new Phrase(dataGridView2.Rows[i].Cells[j].Value.ToString(),
                    new iTextSharp.text.Font(baseFont, 14, iTextSharp.text.Font.NORMAL, new BaseColor(Color.Black))));
                    table2.AddCell(cell2);
                }

            }
            doc.Add(table2);
            doc.Close();
        }
    }
}
