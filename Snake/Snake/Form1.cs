using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Panel parca;
        Panel elma = new Panel();
        List<Panel> yilan = new List<Panel>();

        string yon = "sag";

        private void label3_Click(object sender, EventArgs e)
        {
            label2.Text = "0";
            PanelTemizle();
            parca = new Panel();
            parca.Location = new Point(200, 200);
            parca.Size = new Size(20, 20);
            parca.BackColor = Color.Gray;
            yilan.Add(parca);
            panel1.Controls.Add(yilan[0]);
            timer1.Start();
            ElmaOlustur();
            
        
        }

        void CarpismaKontrol()
        {
            for (int i = 2; i < yilan.Count; i++)
            {
                if (yilan[i].Location == yilan[0].Location)
                {
                    label4.Visible = true;
                    label4.Text = "Kaybettin :(";
                    timer1.Stop();
                }
            }
        }

        void PuanKontrol()
        {
            int puan = int.Parse(label2.Text);
            if(puan == 1000)
            {
                label4.Visible = true;
                label4.Text = "Kazandın :)";
                timer1.Stop();
            }
        }

        void PanelTemizle()
        {
            panel1.Controls.Clear();
            yilan.Clear();
            label4.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        
            ElmaYendimi();
            Hareket();
            CarpismaKontrol();
            PuanKontrol();

            int locX = yilan[0].Location.X;
            int locY = yilan[0].Location.Y;

            if(yon == "sag")
            {
                if (locX < 580)
                {
                    locX += 20;
                }
                else
                    locX = 0;
            }

            if (yon == "sol")
            {
                if (locX > 0)
                {
                    locX -= 20;
                }
                else
                    locX = 580;
            }

            if (yon == "asagi")
            {
                if (locY < 580)
                {
                    locY += 20;
                }
                else
                    locY = 0;
            }

            if (yon == "yukari")
            {
                if (locY > 0)
                {
                    locY -= 20;
                }
                else
                    locY = 580;
            }

            yilan[0].Location = new Point(locX, locY);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Right && yon != "sol")
            {
                yon = "sag";
            }
            if (e.KeyCode == Keys.Left && yon != "sag")
            {
                yon = "sol";
            }
            if (e.KeyCode == Keys.Up && yon != "asagi")
            {
                yon = "yukari";
            }
            if (e.KeyCode == Keys.Down && yon != "yukari")
            {
                yon = "asagi";
            }
        }

        void ElmaOlustur()
        {
            Random rnd = new Random();
            int elmaX, elmaY;
            elmaX = rnd.Next(500);
            elmaY = rnd.Next(500);

            elmaX -= elmaX % 20;
            elmaY -= elmaY % 20;


            elma.Size = new Size(20, 20);
            elma.Location = new Point(elmaX, elmaY);
            elma.BackColor = Color.Red;
            panel1.Controls.Add(elma);
        }

        void ElmaYendimi()
        {
            int puan = int.Parse(label2.Text);

            if (yilan[0].Location == elma.Location)
            {
                panel1.Controls.Remove(elma);
                puan += 50;
                label2.Text = puan.ToString();
                ElmaOlustur();
                ParcaEkle();
            }
        }

        void ParcaEkle()
        {
            Panel ekparca = new Panel();
            ekparca.Size = new Size(20, 20);
            ekparca.BackColor = Color.Gray;
            yilan.Add(ekparca);
            panel1.Controls.Add(ekparca);

        }

        void Hareket()
        {
            for (int i = yilan.Count-1; i > 0 ; i--)
            {
                yilan[i].Location = yilan[i - 1].Location;
            }
        }
    }
}
