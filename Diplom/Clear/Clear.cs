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

namespace Diplom
{
    public partial class Clear : Form
    {
        public Clear()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            ActiveForm.Close();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label2.Visible = true;
            int point = 0;
            int point1 = 0; //31
            int point2 = 0; //29
            int point3 = 0; //30

            if (listBox1.Text == "Апрель" | listBox1.Text == "Июнь" | listBox1.Text == "Сентябрь" | listBox1.Text == "Ноябрь")
            {
                point = 31;
                point3 = 16;
            }
            else if (listBox1.Text == "Ферваль")
            {
                point = 30;
                point2 = 16;
            }
            else { point = 32; point1 = 17; };
           
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics gr = Graphics.FromImage(bm);
            Random r = new Random();

            PointF[] mas = new PointF[point];
            for (int i = 0; i < point; i++)
                mas[i] = new PointF(i, (float)Math.Round(10+5.0f, 2));
            float cdx = (pictureBox1.Width - 90) / mas.Max(x => x.X);
            float cdy = (pictureBox1.Height - 90) / mas.Max(x => x.Y);
            int max = pictureBox1.Height - 25;

            Pen p = new Pen(Brushes.Red, 3);
            p.EndCap = LineCap.ArrowAnchor;

            gr.DrawLine(p, (int)(0 * cdx) + 25, max, (int)(0 * cdx + 25), 0);
            gr.DrawLine(p, 0, (int)(max - 0 * cdy), (int)pictureBox1.Width - 25, (int)(max - 0 * cdy));

            for (float x = 1; x < mas.Max(k => k.X) + 1; x++) //ось X
            {
                gr.DrawString(x.ToString(), new Font("Arial", 10), Brushes.Black, (int)(x * cdx + 7), max + 10);
                gr.DrawLine(Pens.LightCoral, (int)(x * cdx) + 25, (int)pictureBox1.Height - 25, (int)(x * cdx) + 25, 0);
            }

            for (float x = 0; x < mas.Max(k => k.Y) + 1; x++) //ось Y
            {
                gr.DrawLine(Pens.LightCoral, 0, (int)(max - x * cdy), (int)pictureBox1.Width - 25, (int)(max - x * cdy));
            }
            Bitmap bm1 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
            Graphics gr1 = Graphics.FromImage(bm1);
            Bitmap bm2 = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics gr2 = Graphics.FromImage(bm2);
            Brush brush1 = Brushes.Blue;
            Brush brush2 = Brushes.Green;

            gr1.FillRectangle(Brushes.Blue, 10, 10, 25, 25);
            gr2.FillRectangle(Brushes.Green, 10, 10, 25, 25);

            int a = 26;
            for (int i = 1; i < point1; i++) //point1
            {
                gr.FillRectangle(brush1, a, 181, 21.7f, 19);
                gr.TranslateTransform(18.5f, 0);
                if (i < 16)
                {
                    gr.FillRectangle(brush2, a + 4, 220, 22, 19);
                    gr1.TranslateTransform(20f, 0);
                }
                
                a = a + 26;
            }
            
            for (int i = 1; i < point2; i++) //point2
            {
                gr.FillRectangle (brush2, a, 181, 22, 19);
                gr.TranslateTransform(21.7f, 0);
                if (i < 15)
                {
                    gr.FillRectangle(brush1, a + 2, 220, 22, 19);
                    gr1.TranslateTransform(21f, 0);
                }
                a = a + 26;
            }
            int a1 = 25;
            for (int i = 1; i < point3; i++) //point3
            {
                gr.FillRectangle(brush1, a1, 181, 22, 19);
                gr.TranslateTransform(21.1f, 0);
                gr.FillRectangle(brush2, a1+2, 220, 22, 19);
                gr1.TranslateTransform(20.5f, 0);
                a1 = a1 + 25; 
            }
            pictureBox1.Image = bm;
            pictureBox2.Image = bm1;
            pictureBox3.Image = bm2;
        }
        private void Clear_Load(object sender, EventArgs e)
        {
            string[] months = { "Январь", "Ферваль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };
            listBox1.Items.AddRange(months);
        }
    }
}
