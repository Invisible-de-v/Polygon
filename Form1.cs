using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Многоугольники_3._0
{
    public partial class Form : System.Windows.Forms.Form
    {
        float animx, animy;//Для сдвига в анимации
        int vibor;//Какая фигура
        float delx;//расстояние для сдвига 
        float dely;
        bool Draw;//пустой ли лист
        bool pol; //Есть ли полигон
        bool figureGrab;
        List<Vershina> Vershiny; // фигуры на листе
        static Random rnd = new Random();
        public Form()
        {
            InitializeComponent();
            animx = 0;
            animy = 0;
            delx = 0;
            dely = 0;
            Vershiny = new List<Vershina>();
            vibor = 0;
        }
        
        public bool InFig(int x, int y, List<Vershina> ver) //Проверка полигона
        {
            if (ver.Count() > 2)
            {
                List<Vershina> fig = new List<Vershina>();
                Vershina fg = new Square(x, y, 15);
                ver.Add(fg);
                for (int c = 0; c < ver.Count(); c++)
                {
                    for (int b = c + 1; b < ver.Count(); b++)
                    {
                        bool Up = true;//под и над линией
                        bool Down = true;
                        for (int a = 0; a < ver.Count(); a++)
                        {
                            if (a != b && a != c && c != b)//Три точки
                            {

                                if ((ver[c].Y1 - ver[b].Y1) * ver[a].X1 + (ver[b].X1 - ver[c].X1) * ver[a].Y1 + (ver[c].X1 * ver[b].Y1 - ver[b].X1 * ver[c].Y1) >= 0)
                                {
                                    Down = false;
                                }
                                else
                                {
                                    Up = false;
                                }
                            }
                        }
                        if (Down == true || Up == true)
                        {
                            fig.Add(ver[c]);
                            fig.Add(ver[b]);
                        }

                    }
                }
                if (fig.Contains(fg) == false)//Если оказалась внутри
                {
                    ver.Remove(fg);
                    return true;
                }
                ver.Remove(fg);
            }
            return false;
        }

      
        //Выбор фигуры
        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vibor = 1;
        }

        private void кругToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vibor = 0;
        }

        private void треугольникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vibor = 2;
        }

        private void Timer_Tick(object sender, EventArgs e)//Движение полигона
        {
            if (animx <= 15 && animy <= 15 && animx >= -15 && animy >= -15)
            {
                delx = rnd.Next(-5, 5);
                dely = rnd.Next(-5, 5);
                animx += delx;
                animy += dely;
                foreach (Vershina i in Vershiny)
                {
                    i.X1 += delx;
                    i.Y1 += dely;
                }
            }
            else
            {
                if (animx > 15)
                {   
                    animx += delx;
                    delx += -5;
                    
                    foreach (Vershina i in Vershiny)
                    {
                        i.X1 += delx;
                    }
                }
                if (animy > 15)
                {   
                    animy += delx;
                    dely += -5;
                    
                    foreach (Vershina i in Vershiny)
                    {
                        i.Y1 += dely;
                    }
                }
                if (animx < -15)
                {   
                    animx += delx;
                    delx += 5;
                    foreach (Vershina i in Vershiny)
                    {
                        i.X1 += delx;
                    }
                }
               
                if (animy < -15)
                {   
                    dely += 5;
                    animy += dely;
                    foreach (Vershina i in Vershiny)
                    {
                        i.Y1 += dely;
                    }
                }
            }
            Refresh();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (Vershina i in Vershiny)
            {
                i.Draw(g);
            }
            if (Draw)
            {
                if (Vershiny.Count > 2)
                {
                    Pen pen = new Pen(Color.Pink);
                    for (int i = 0; i < Vershiny.Count; i++)
                    {
                        Vershiny[i].Ins = false;
                    }
                    for (int i = 0; i < Vershiny.Count; i++)
                    {
                        for (int j = i + 1; j < Vershiny.Count; j++)
                        {
                            bool Up = true;
                            bool Down = true;
                            for (int k = 0; k < Vershiny.Count; k++)
                            {
                                if (k != i && k != j && i != j)
                                {
                                    if ((Vershiny[i].Y1 - Vershiny[j].Y1) * Vershiny[k].X1 + (Vershiny[j].X1 - Vershiny[i].X1) * Vershiny[k].Y1 + (Vershiny[i].X1 * Vershiny[j].Y1 - Vershiny[j].X1 * Vershiny[i].Y1) >= 0)
                                        Down = false;
                                    if ((Vershiny[i].Y1 - Vershiny[j].Y1) * Vershiny[k].X1 + (Vershiny[j].X1 - Vershiny[i].X1) * Vershiny[k].Y1 + (Vershiny[i].X1 * Vershiny[j].Y1 - Vershiny[j].X1 * Vershiny[i].Y1) < 0)
                                        Up = false;
                                }
                            }
                            if (Down == true || Up == true)
                            {
                                Vershiny[i].Ins = true;
                                Vershiny[j].Ins = true;
                                e.Graphics.DrawLine(pen, Vershiny[i].X1, Vershiny[i].Y1, Vershiny[j].X1, Vershiny[j].Y1);
                            }
                        }
                    }
                }
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            pol = false;
            Draw = false;
            for (int j = 0; j < Vershiny.Count; j++) Draw = true;
            if (Draw)
            {
                foreach (Vershina i in Vershiny)
                {
                    if (i.Check(e.X, e.Y))
                    {
                        if (e.Button == MouseButtons.Left)
                        {
                            i.Delx = e.X - i.X1;
                            i.Dely = e.Y - i.Y1;
                            i.Drag = true;
                            pol = true;
                        }
                        if (e.Button == MouseButtons.Right)
                        {
                            Vershiny.Remove(i);
                            pol = true;
                            Refresh();
                            break;
                        }
                    }
                }
                if (!pol)
                {
                   
                    if (InFig(e.X, e.Y, Vershiny))
                    {
                        for (int i = 0; i < Vershiny.Count(); i++)
                        {
                            Vershiny[i].Delx = e.X - Vershiny[i].X1;
                            Vershiny[i].Dely = e.Y - Vershiny[i].Y1;
                            Vershiny[i].Drag = true;
                        }
                    }
                    else
                    {
                        
                        switch (vibor)
                        {
                            case 0: Vershiny.Add(new Circle(e.X, e.Y, 20)); break;
                            case 1: Vershiny.Add(new Square(e.X, e.Y, 20)); break;
                            case 2: Vershiny.Add(new Triangle(e.X, e.Y, 20)); break;
                            default:
                                Vershiny.Add(new Circle(e.X, e.Y, 20)); break;
                        }
                        Refresh();
                    }
                }
            }
            else
            {
                switch (vibor)
                {
                    case 0: Vershiny.Add(new Circle(e.X, e.Y, 20)); break;
                    case 1: Vershiny.Add(new Square(e.X, e.Y, 20)); break;
                    case 2: Vershiny.Add(new Triangle(e.X, e.Y, 20)); break;
                    default:
                        Vershiny.Add(new Circle(e.X, e.Y, 20)); break;
                }

            }
            Refresh();
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (Vershina i in Vershiny)
            {

                if (i.Drag)
                {
                    i.X1 = e.X - i.Delx;
                    i.Y1 = e.Y - i.Dely;
                }
            }
            Refresh();
        }

        private void Interval_Scroll(object sender, EventArgs e)
        {
            if (Interval.Value != 0)
                Timer.Interval = Interval.Value * 10;
            else
                Timer.Interval = 10;
        }

        private void Form_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Timer.Start();
            Refresh();
        }

        private void Stop_Click(object sender, EventArgs e)
        {
            Timer.Stop();
            Refresh();
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Vershina i in Vershiny)
            {
                if (i.Drag)
                {
                    i.Drag = false;
                    Refresh();
                }
            }
            if (Vershiny.Count > 2)
                for (int i = 0; i < Vershiny.Count; i++)
                {
                    if (Vershiny[i].Ins == false)
                        Vershiny.Remove(Vershiny[i]);
                }
            if (figureGrab)
            {
                for (int i = 0; i < Vershiny.Count; i++)
                {
                    Vershiny[i].Drag = false;
                }
                figureGrab = false;
            }
            Refresh();
        }
    

        

    }
}

