namespace overload
{
    internal class Program
    {

        partial class Square
        {
            public int A;

            public Square(int a)
            {
                if (a < 0)
                {
                    throw new ArgumentException("Side cannot be less than zero");
                }
                A = a;
            }
            public override string ToString()
            {
                return $"Square: Side - {A}, Area - {A * A}";
            }

            public override bool Equals(object obj)
            {
                Square other = obj as Square;
                if (obj == null)
                {
                    return false;
                }
                return this.A == other.A;
            }


        }

        partial class Square
        {
            public static Square operator ++(Square left)
            {
                Square square = new Square(left.A + 1);
                return square;
            }
            public static Square operator --(Square left)
            {
                int side = left.A - 1;
                if (side >= 0)
                {
                    Square square = new Square(side);
                    return square;
                }
                return left;
            }
            public static Square operator +(Square left, Square right)
            {
                return new Square(left.A + right.A);
            }
            public static Square operator -(Square left, Square right)
            {
                int side = left.A - right.A;
                if (side >= 0)
                {
                    Square square = new Square(side);
                    return square;
                }
                return left;
            }
            public static Square operator *(Square left, Square right)
            {
                return new Square(left.A * right.A);
            }

            public static Square operator /(Square left, Square right)
            {
                if (right.A == 0)
                {
                    throw new ArgumentException("Zero division");
                }
                return new Square(left.A / right.A);
            }
            public static bool operator ==(Square left, Square right)
            {
                //if (ReferenceEquals(left, null))
                //{
                //    return ReferenceEquals(right, null);
                //}
                return left.Equals(right);
            }
            public static bool operator !=(Square left, Square right)
            {
                return !left.Equals(right);
            }
            public static bool operator >(Square left, Square right)
            {
                return left.A > right.A;
            }
            public static bool operator <(Square left, Square right)
            {
                return left.A < right.A;
            }
            public static bool operator <=(Square left, Square right)
            {
                return left.A < right.A || left.Equals(right);
            }
            public static bool operator >=(Square left, Square right)
            {
                return left.A > right.A || left.Equals(right);
            }
            public static bool operator true(Square left)
            {
                return (left.A != 0);
            }
            public static bool operator false(Square left)
            {
                return (left.A == 0);
            }

            public static implicit operator Rectangle(Square square)
            {
                return new Rectangle(square.A, square.A);
            }

            public static implicit operator int(Square square)
            {
                return square.A;
            }
        }

        class Rectangle
        {
            public int A, B;

            public Rectangle(int a, int b)
            {
                if (a < 0 || b < 0)
                {
                    throw new ArgumentException("Side cannot be less than zero");
                }
                A = a;
                B = b;
            }
            public override string ToString()
            {
                return $"Rectangle: Sides - A:{A} B:{B}, Area - {A * B}";
            }


            public static Rectangle operator ++(Rectangle left)
            {
                Rectangle square = new Rectangle(left.A + 1, left.B + 1);
                return square;
            }
            public static Rectangle operator --(Rectangle left)
            {
                int side1 = left.A - 1;
                int side2 = left.B - 1;
                if (side1 >= 0 && side2 >= 0)
                {
                    Rectangle square = new Rectangle(side1, side2);
                    return square;
                }
                return left;
            }
            public static Rectangle operator +(Rectangle left, Rectangle right)
            {
                return new Rectangle(left.A + right.A, left.B + right.B);
            }
            public static Rectangle operator -(Rectangle left, Rectangle right)
            {
                int side1 = left.A - right.A;
                int side2 = left.B - right.B;
                if (side1 >= 0 && side2 >= 0)
                {
                    Rectangle square = new Rectangle(side1, side2);
                    return square;
                }
                return left;
            }
            public static Rectangle operator *(Rectangle left, Rectangle right)
            {
                return new Rectangle(left.A * right.A, left.B * left.B);
            }

            public static Rectangle operator /(Rectangle left, Rectangle right)
            {
                if (right.A == 0 || right.A == 0)
                {
                    throw new ArgumentException("Zero division");
                }
                return new Rectangle(left.A / right.A, left.B / right.B);
            }

            public override bool Equals(object obj)
            {
                Rectangle other = obj as Rectangle;

                if (obj == null)
                {
                    return false;
                }
                return this.A == other.A && this.B == other.B;
            }

            public static bool operator ==(Rectangle left, Rectangle right)
            {
                //if (ReferenceEquals(left, null))
                //{
                //    return ReferenceEquals(right, null);
                //}
                return left.Equals(right);
            }
            public static bool operator !=(Rectangle left, Rectangle right)
            {
                return !left.Equals(right);
            }
            public static bool operator >(Rectangle left, Rectangle right)
            {
                return left.A > right.A && left.B > right.B;
            }
            public static bool operator <(Rectangle left, Rectangle right)
            {
                return left.A < right.A && left.B < right.B;
            }
            public static bool operator <=(Rectangle left, Rectangle right)
            {
                return left.A < right.A && left.B < right.B || left.Equals(right);
            }
            public static bool operator >=(Rectangle left, Rectangle right)
            {
                return left.A > right.A && left.B > right.B || left.Equals(right);
            }
            public static bool operator true(Rectangle left)
            {
                return (left.A != 0 && left.B != 0);
            }
            public static bool operator false(Rectangle left)
            {
                return (left.A == 0 || left.B == 0);
            }

            public static explicit operator Square(Rectangle left)
            {
                return new Square(Math.Min(left.A, left.B));
            }

            public static explicit operator int(Rectangle left)
            {
                return left.A * left.B;
            }
        }



        static void Main(string[] args)
        {

            Square s1 = new Square(5);
            Square s2 = new Square(7);
            s1--;
            s2++;

            Console.WriteLine(s1.ToString());
            Console.WriteLine(s2.ToString());

            Square s3 = s2 - s1;
            Console.WriteLine(s3.ToString());
            s1 = s3 + s2;
            Console.WriteLine(s1.ToString());
            Console.WriteLine(s1 > s3);
            Console.WriteLine(s2 == s1);
            Console.WriteLine(s2 < s3);

            Square div = s1 / s3;
            Console.WriteLine(div.ToString());


            Rectangle r1 = new Rectangle(4, 6);
            Rectangle r2 = new Rectangle(2, 6);
            Console.WriteLine(++r1);
            Console.WriteLine(++r2);

            Rectangle div1 = r1 / r2;
            Console.WriteLine(div1.ToString());
            Rectangle mult = r1 * r2;
            Console.WriteLine(mult.ToString());
            Console.WriteLine(mult > r2);
            Rectangle test = new Rectangle(0, 0);
            if (test)
            {
                Console.WriteLine("test - true");
            }
            else { Console.WriteLine("test - false"); }

            Rectangle sq = s1;
            Console.WriteLine(sq.ToString());

            Console.WriteLine((int)sq);
            int sint = s1;
            Console.WriteLine(sint);
            Console.WriteLine(r2.ToString());
            Square rc = (Square)r2;
            Console.WriteLine(rc.ToString());
            Console.WriteLine(rc);
        }
    }
}