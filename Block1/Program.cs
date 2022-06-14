using System;

namespace Block1
{
    public struct MyFrac
    {
        public long nom, denom;
        public MyFrac(long nom_, long denom_)
        {
            nom = nom_;
            denom = denom_;
            long max;
            if (nom > denom)
            {
                max = Math.Abs(nom);
            }
            else
            {
                max = Math.Abs(denom);
            }
            for (long i = max; i >= 2; i--)
            {
                if (nom % i == 0 && denom % i == 0)
                {
                    nom /= i;
                    denom /= i;
                }
            }
            if (denom < 0)
            {
                nom = -1 * nom;
                denom = Math.Abs(denom);
            }
        }
        public override string ToString()
        {
            return $"{nom}/{denom}";
        }
    }
    class Program
    {
        static string ToStringWithIntegerPart(MyFrac f)
        {
            bool isNegative = false;
            string res = string.Empty;
            if (f.nom < 0 || f.denom < 0)
            {
                f.nom = Math.Abs(f.nom);
                f.denom = Math.Abs(f.denom);
                isNegative = true;
            }
            long num = f.nom / f.denom;
            long remaining = f.nom % f.denom;
            if (isNegative == true)
            {
                res = $"-({num}+{remaining}/{f.denom})";
            }
            else
            {
                res = $"({num}+{remaining}/{f.denom})";
            }
            return res;
        }
        static double DoubleValue(MyFrac f)
        {
            double nom = f.nom;
            double denom = f.denom;
            return nom / denom;
        }
        static MyFrac Plus(MyFrac f1, MyFrac f2)
        {
            long nok = 0;
            for (int i = 0; i < (f2.denom * f1.denom + 1); i++)
            {
                if (i % f1.denom == 0 && i % f2.denom == 0)
                {
                    nok = i;
                    if (i != 0)
                    {
                        break;
                    }
                }
            }
            f1.nom *= (nok / f1.denom);
            f2.nom *= (nok / f2.denom);
            MyFrac res = new MyFrac(f1.nom + f2.nom, nok);
            return res;
        }
        static MyFrac Minus(MyFrac f1, MyFrac f2)
        {
            long nok = 0;
            for (int i = 0; i < (f2.denom * f1.denom + 1); i++)
            {
                if (i % f1.denom == 0 && i % f2.denom == 0)
                {
                    nok = i;
                    if (i != 0)
                    {
                        break;
                    }
                }
            }
            f1.nom *= (nok / f1.denom);
            f2.nom *= (nok / f2.denom);
            MyFrac res = new MyFrac(f1.nom - f2.nom, nok);
            return res;
        }
        static MyFrac Multiply(MyFrac f1, MyFrac f2)
        {
            MyFrac res = new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
            return res;
        }
        static MyFrac Divide(MyFrac f1, MyFrac f2)
        {
            MyFrac res = new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
            return res;
        }
        static MyFrac CalcSum1(int n)
        {
            MyFrac res = new MyFrac(0, 1);
            for (int i = 1; i <= n; i++)
            {
                res = Plus(res, new MyFrac(1, i * (i + 1)));
            }
            return res;
        }
        static MyFrac CalcSum2(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                MyFrac minus = Minus(new MyFrac(1, 1), new MyFrac(1, i * i));
                res = Multiply(minus, res);
            }
            return res;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значение числителя дроби:");
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение знаменателя дроби:");
            long d = long.Parse(Console.ReadLine());
            MyFrac f = new MyFrac(n, d);
            Console.WriteLine($"Полученная дробь: {f.ToString()} ");
            Console.WriteLine(ToStringWithIntegerPart(f));
            Console.WriteLine($"Истинное значение дроби: {DoubleValue(f)}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Введите значение числителя первой дроби:");
            long n1 = long.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение знаменателя первой дроби:");
            long d1 = long.Parse(Console.ReadLine());
            MyFrac f1 = new MyFrac(n1, d1);
            Console.WriteLine($"Полученная дробь: {f1.ToString()} ");
            Console.WriteLine("Введите значение числителя второй дроби:");
            long n2 = long.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение знаменателя второй дроби:");
            long d2 = long.Parse(Console.ReadLine());
            MyFrac f2 = new MyFrac(n2, d2);
            Console.WriteLine($"Полученная дробь: {f2.ToString()}");
            MyFrac res = Plus(f1, f2);
            Console.WriteLine($"Результат сложения двух дробей: {res.ToString()} ");
            res = Minus(f1, f2);
            Console.WriteLine($"Результат вычитания двух дробей: {res.ToString()} ");
            res = Multiply(f1, f2);
            Console.WriteLine($"Результат умножения двух дробей: {res.ToString()} ");
            res = Divide(f1, f2);
            Console.WriteLine($"Результат деления двух дробей: {res.ToString()} ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine($"Введите значение n, для подсчета суммы дробей от 1 до 1/(n(n+1)) и 1-1/(n*n): ");
            int num = int.Parse(Console.ReadLine());
            res = CalcSum1(num);
            Console.WriteLine($"Результат: {res.ToString()}");
            res = CalcSum2(num);
            Console.WriteLine($"Результат: {res.ToString()}");
        }
    }
}
