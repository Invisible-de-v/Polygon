using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Многоугольники_2._1
{
    public partial class Форма : Form
    {
        bool Draw;//нарисована фигура или нет
        int vibor; //Выборка фигуры
        float del_x;
        float del_y;
        bool drag; //зацеплена фигура или нет
        int kolvo; //количество фигур на листе
        List<int> Indeks;
        List<float> dX;
        List<float> dY;
        List<float> Polygon;//Список для мнооугольника
        List<Vershina> Vershiny; // фигуры на листе
        bool odna; // Есть ли хотя бы одна вершина
        int storony;//Количество сторон
        public Форма()
        {
            del_x = 0;
            del_y = 0;
            Draw = false;
            drag = false;
            Vershiny = new List<Vershina>();
            Indeks = new List<int>();
            dX = new List<float>();
            dY = new List<float>();
            Polygon = new List<float>();
            storony = 0;
            InitializeComponent();
        }
        private bool CheckMn(float x, float y)
        {
            if (Vershiny.Count >= 3)
            {
                int Tup = 0, Tun = 0, inmn = 0;
                for (int i = 0; i < Vershiny.Count; i++)
                {
                    for (int j = i + 1; j < Vershiny.Count; j++)
                    {

                        for (int k = 0; k < Vershiny.Count; k++)
                        {
                            if (k != i && k != j)
                            {
                                if ((Vershiny[k].Y1 - Vershiny[i].Y1) * (Vershiny[j].X1 - Vershiny[i].X1) >= (Vershiny[k].X1 - Vershiny[i].X1) * (Vershiny[j].Y1 - Vershiny[i].Y1))
                                {
                                    Tup++;
                                }
                                else Tun++;
                            }
                        }
                        if (Tup == 0)
                        {
                            if ((y - Vershiny[i].Y1) * (Vershiny[j].X1 - Vershiny[i].X1) < (x - Vershiny[i].X1) * (Vershiny[j].Y1 - Vershiny[i].Y1)) inmn++;
                        }
                        if (Tun == 0)
                        {
                            if ((y - Vershiny[i].Y1) * (Vershiny[j].X1 - Vershiny[i].X1) > (x - Vershiny[i].X1) * (Vershiny[j].Y1 - Vershiny[i].Y1)) inmn++;
                        }
                        Tun = 0; Tup = 0;
                    }
                }

                if (inmn == storony && inmn != 0) return true;
                else return false;
            }
            else return false;
        }
        private void Форма_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (Draw == true)
            {
                for (int j = 0; j < Vershiny.Count; j++)
                {
                    Vershiny[j].Draw(e.Graphics);
                }
            }
            int up = 0;
            int un = 0;
            if (Vershiny.Count >= 3)
            { 
               
                for (int i = 0; i < Vershiny.Count; i++)
                {
                    for (int j = i + 1; j < Vershiny.Count; j++)
                    {

                        for (int k = 0; k < Vershiny.Count; k++)
                        {
                            if (k != i && k != j)
                            {
                                if ((Vershiny[k].Y1 - Vershiny[i].Y1) * (Vershiny[j].X1 - Vershiny[i].X1) >= (Vershiny[k].X1 - Vershiny[i].X1) * (Vershiny[j].Y1 - Vershiny[i].Y1))
                                {
                                    up++;
                                }
                                else un++;
                            }
                            
                        }
                        if (up == 0 || un == 0)
                        {
                            g.DrawLine(new Pen(Color.Aquamarine), Vershiny[i].X1, Vershiny[i].Y1, Vershiny[j].X1, Vershiny[j].Y1);
                        }
                        un = 0; up = 0;
                    }
                    
                }
                
            }
        }
        private void Форма_MouseDown(object sender, MouseEventArgs e)
        {
            Indeks.Clear();
            dX.Clear();
            dY.Clear();
            for (int i = 0; i < Vershiny.Count; i++)

                if (Vershiny[i].Check(e.X, e.Y))
                {
                    kolvo = i; odna = true;
                    if (MouseButtons.Left == e.Button)
                    {
                        if (CheckMn(e.X, e.Y) == true)
                        {
                        del_x = e.X - Vershiny[kolvo].X1;
                        del_y = e.Y - Vershiny[kolvo].Y1;
                        drag = true;
                        Indeks.Add(kolvo);
                        dX.Add(del_x);
                        dY.Add(del_y);
                        }
                        
                    } 
                }
            if (odna == true)
            { 
                if (MouseButtons.Right == e.Button)
                {
                    Vershiny.RemoveAt(kolvo);
                    if (Vershiny.Count == 0) Draw = false;
                }
                odna = false;
            }

            else
            {
                switch (vibor)
                {
                    case (2):
                        Vershiny.Add(new Triangle(e.X, e.Y, ClientSize.Height / 10));
                        break;
                    case (0):
                        Vershiny.Add(new Square(e.X, e.Y, ClientSize.Height / 10));
                        break;
                    case (1):
                        Vershiny.Add(new Circle(e.X, e.Y, ClientSize.Height / 10));
                        break;    
                }
                Draw = true;
            }
            Refresh();
        }

        private void Форма_MouseMove(object sender, MouseEventArgs e)
        {

            if (MouseButtons.Left == e.Button && drag)
            {
                for(int i = 0; i < Indeks.Count; i++)
                {
                    Vershiny[Indeks[i]].X1 = e.X - dX[i];
                    Vershiny[Indeks[i]].Y1 = e.Y - dY[i];
                }
               
                Refresh();
            }
            
        }

        private void Форма_MouseUp(object sender, MouseEventArgs e)
        {
            if (drag) { drag = false; Refresh(); }
        }

        private void Форма_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
        }
        private void Квадрат_Click(object sender, EventArgs e)
        {
            Круг.Checked = false;
            Треугольник.Checked = false;
            vibor = 0;
        }

        private void Круг_Click(object sender, EventArgs e)
        {
            Квадрат.Checked = false;
            Треугольник.Checked = false;
            vibor = 1;
        }

        private void Треугольник_Click(object sender, EventArgs e)
        {
            Квадрат.Checked = false;
            Треугольник.Checked = false;
            vibor = 2;
        }
    }
}
