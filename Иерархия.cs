﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многоугольники_3._0
{

    public abstract class Vershina
    {
        protected float x, delx;
        protected float y, dely;
        protected float height;
        protected bool ins, drag;
        public Vershina(float x, float y, float height)
        {
            this.x = x;
            this.y = y;
            delx = 0;
            dely = 0;
            this.height = height;
            ins = false;
            drag = false;
        }
        public abstract void Draw(Graphics g);
        public float X1
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public float Y1
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public bool Drag { get => drag; set { drag = value; } }
        public float Height { get; set; }
        public bool Ins { get => ins; set { ins = value; } }
        public float Delx { get => delx; set { delx = value; } }
        public float Dely { get => dely; set { dely = value; } }
        public abstract bool Check(float X, float Y);
    }
    public class Square : Vershina
    {
        public Square(float x, float y, float height) : base(x, y, height) { }

        public override void Draw(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Chocolate), x, y, height, height);
        }
        override public bool Check(float X, float Y)
        {

            if (((X - x) * ((x + height) - X) >= 0) && ((Y - y) * ((y + height) - Y) >= 0)) return true;
            else return false;
        }
    }
    public class Triangle : Vershina
    {
        public Triangle(float x, float y, float height) : base(x, y, height) { }

        public override void Draw(Graphics g)
        {
            Point point1 = new Point((int)x + (int)height, (int)y + (int)height / 2);
            Point point2 = new Point((int)x + (int)height / 2, (int)y - (int)height / 2);
            Point point3 = new Point((int)x, (int)y + (int)height / 2);
            Point[] trig = { point1, point2, point3 };
            g.FillPolygon(new SolidBrush(Color.Cyan), trig);
        }
        public override bool Check(float X, float Y)
        {
            return ((X >= x) && (X <= x + height) && (Y <= y + height / 2) && (Y >= (y + height / 2 - 2 * (X - x))) && (Y >= (y + height / 2 - 2 * (x + height - X))));
        }
    }
    public class Circle : Vershina
    {
        public Circle(float x, float y, float height) : base(x, y, height) { }

        public override void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.DarkCyan), x, y, height, height);
        }
        override public bool Check(float X, float Y)
        {
            float cx = x + height / 2;
            float cy = y + height / 2;
            float rx = Math.Abs(X - cx);
            float ry = Math.Abs(Y - cy);
            if ((rx * rx + ry * ry) <= height * height / 4) return true;
            else return false;
        }
    }
}
