using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Sreda.Init(this);
        }
    }

    public static class Sreda
    {
        static Form1 sreda;
        static Timer nextDay = new Timer();

        public static List<Kletka> Travoidnue { get; set; }
        public static List<Kletka> Hishniki { get; set; }

        static Sreda()
        {
            Travoidnue = new List<Kletka>();
            Hishniki = new List<Kletka>();
        }

        public static void GenerateKletka()
        {
            Kletka newKletka = new Kletka(sreda);
            Travoidnue.Add(newKletka);
        }

        public static void MoveKletkaTravoiadnuh()
        {
            foreach(Kletka kletki in Travoidnue)
            {
                kletki.Move();
            }
        }

        public static void NextDay(object sender, EventArgs e)
        {
            GenerateKletka();
            foreach (Kletka kletki in Hishniki)
            {
                kletki.Jut();
            }
        }

        public static void Init(Form1 form)
        {
            sreda = form;

            Kletka newKletka = new Kletka(sreda);
            Hishniki.Add(newKletka);

            nextDay.Interval = 1000;
            nextDay.Tick += NextDay;
            nextDay.Start();
        }
    }

    public class Kletka
    {
        Random random = new Random();
        Color travoiadnue = Color.FromArgb(0, 80, 80);

        public Label View { get; set; }
        public int Yroven { get; set; }
        public int Energy { get; set; }

        public void Bonus()
        {
            Energy++;
            int raz = Energy + 13;
            View.Text = Energy.ToString();
            View.Size = new Size(raz, raz);
        }

        public Kletka(Form1 sreda)
        {
            
            int maxX = sreda.Size.Width - 30;
            int maxY = sreda.Size.Height - 30;

            Label view = new Label();
            view.Size = new Size(20, 20);
            view.BackColor = travoiadnue;
            view.Location = new Point(random.Next(0, maxX), random.Next(0, maxY));
            view.Font = new Font("Arial", 15);
            view.Text = "7";

            sreda.Controls.Add(view);

            View = view;
            Yroven = 1;
            Energy = 7;


            ProcessJuzni += Golod;
        }

        public void Move()
        {
            int x = random.Next(-10, 10) + View.Location.X;
            int y = random.Next(-10, 10) + View.Location.Y;
            View.Location = new Point(x, y);
        }

        void Golod()
        {
            Energy--;
            View.Text = Energy.ToString();
        }

        public event EventDelegate ProcessJuzni = null;

        public void Jut()
        {
            ProcessJuzni();
        }
    }

    public delegate void EventDelegate();
}



















//static double Distance(Label hish, Label trav)
//{
//    int x1 = hish.Location.X;
//    int y1 = hish.Location.Y;

//    int x2 = trav.Location.X;
//    int y2 = trav.Location.Y;

//    double result = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
//    return result;
//}








//foreach (Kletka kletki in Hishniki)
//{
//    Label view = kletki.View;
//    int x = 0;
//    int y = 0;

//    if (Travoidnue.Count == 0)
//    {
//        x = random.Next(-10, 10) + view.Location.X;
//        y = random.Next(-10, 10) + view.Location.Y;
//    }
//    else
//    {
//        double minimum = 100;
//        int index = -1;
//        for (int i = 0; i < Travoidnue.Count; i++)
//        {
//            if (index == -1)
//            {
//                index = i;
//                minimum = Distance(view, Travoidnue[i].View);
//            }
//            else if (Distance(view, Travoidnue[i].View) < minimum)
//            {
//                index = i;
//                minimum = Distance(view, Travoidnue[i].View);
//            }
//        }

//        if (view.Location.X > Travoidnue[index].View.Location.X)
//        {
//            x = view.Location.X - 10;
//        }
//        else
//        {
//            x = view.Location.X + 10;
//        }

//        if (view.Location.Y > Travoidnue[index].View.Location.Y)
//        {
//            y = view.Location.Y - 10;
//        }
//        else
//        {
//            y = view.Location.Y + 10;
//        }

//        if (Distance(view, Travoidnue[index].View) < 20)
//        {

//            sreda.Controls.Remove(Travoidnue[index].View);
//            Travoidnue.Remove(Travoidnue[index]);
//        }
//    }


//    view.Location = new Point(x, y);
//}