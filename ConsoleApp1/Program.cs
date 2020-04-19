using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    interface IFigure
    {
        double GetPerimeter();
        double GetArea();
    }

    class Rectangle : IFigure
    {
        private double a;
        private double b;
        private double A
        {
            get => a;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                a = value;
            }
        }
        private double B
        {
            get => b;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                b = value;
            }
        }
        public string Name { get; }

        public Rectangle()
        {

        }

        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }

        public Rectangle(string name)
        {
            Name = name;
        }
        public string ShowDetails()
        {
            return $"Rectangle's A = {A}, B = {B}";
        }
        public double GetPerimeter()
        {
            return 2 * A + 2 * B;
        }
        public double GetArea()
        {
            return A * B;
        }
    }

    class Circle : IFigure
    {
        private double r;
        private double R
        {
            get => r;
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                r = value;
            }
        }

        public string Name { get; }
        public Circle()
        {

        }
        public Circle(double r)
        {
            R = r;
        }

        public Circle(string name)
        {
            Name = name;
        }
        public string ShowDetails()
        {
            return $"Circle's radius: {R}";
        }
        public double GetPerimeter()
        {
            return 2 * 3.14 * R;
        }
        public double GetArea()
        {
            return 3.14 * Math.Pow(R, 2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IFigure> figures = new List<IFigure>();

            var rectangle1 = new Rectangle();
            var rectangle2 = new Rectangle("Custom rectangle");
            var rectangle3 = new Rectangle(2, 3);
            var rectangle4 = new Rectangle(-2, 1);
            var circle1 = new Circle();
            var circle2 = new Circle("Custom circle");
            var circle3 = new Circle(4);
            var circle4 = new Circle(-4);
            figures.AddRange(new List<IFigure> { rectangle1, rectangle2, rectangle3, rectangle4, circle1, circle2, circle3, circle4 });
            using (StreamWriter writer = new StreamWriter("result.txt"))
            {
                foreach (IFigure figure in figures)
                {
                    if (figure is Rectangle rectangle)
                    {
                        Console.WriteLine($"Rectangle name: {rectangle.Name}");
                        Console.WriteLine(rectangle.ShowDetails());
                        writer.WriteLine(rectangle.ShowDetails());
                        Console.WriteLine($"Rectangle perimeter: {rectangle.GetPerimeter()}");
                        writer.WriteLine(rectangle.GetPerimeter());
                        Console.WriteLine($"Rectangle area: {rectangle.GetArea()}");
                        writer.WriteLine(rectangle.GetArea());
                        writer.WriteLine();
                    }
                    else if (figure is Circle circle)
                    {
                        Console.WriteLine($"Circle name: {circle.Name}");
                        Console.WriteLine(circle.ShowDetails());
                        writer.WriteLine(circle.ShowDetails());
                        Console.WriteLine($"Circle perimeter: {circle.GetPerimeter()}");
                        writer.WriteLine(circle.GetPerimeter());
                        Console.WriteLine($"Circle area: {circle.GetArea()}");
                        writer.WriteLine(circle.GetArea());
                        writer.WriteLine();
                    }
                    Console.WriteLine();
                }
            }

            Console.ReadKey();
        }
    }
}
