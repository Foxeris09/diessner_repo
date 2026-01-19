using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace matFunkce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            List<MathFunction> funkce = new List<MathFunction>
            {
                new LinearniFunkce(2,3),
                new LinearniFunkceSAbsHodnotou(-2,-3, 4),
                new LinearniLomenaFunkce(2,-3, 4, 5),
                new KvadratickaFunkce(1,-2,1)
            };
            double x = 2;
            foreach (var fun in funkce)
            {
                fun.VypisInfo();
                Console.WriteLine($"f({x}) = {fun.Vypocitej(x)}\n");
                if (fun is IDerivovatelne)
                    Console.WriteLine(((IDerivovatelne)fun).Derivace()+ "\n");
                if (fun is IInvertovatelne)
                    Console.WriteLine(((IInvertovatelne)fun).Inverze() + "\n");

            }
        }
    }

    struct Interval
    {
        public double Min { get; }
        public double Max { get; }
        public bool ZlevaUzavreno { get; }
        public bool ZpravaUzavreno { get; }
        public Interval(bool leva, double min, double max,  bool prava)
        {
            Min = min;
            Max = max;
            ZlevaUzavreno = leva;
            ZpravaUzavreno = prava;
        }

        public override string ToString()
        {
            string levaZavorka = null;
            string pravaZavorka = null;
            string levyInterval = null;
            string pravyInterval = null;
            if (ZlevaUzavreno)
            {
                levaZavorka = "[";
            }
            else { levaZavorka = "("; }
            if (ZpravaUzavreno)
            {
                pravaZavorka = "]";
            }

            else { pravaZavorka = ")"; }
            if (double.IsNegativeInfinity(Min)) { levyInterval = "-∞"; }
            else { levyInterval = Min.ToString(); }
            if (double.IsPositiveInfinity(Max)) { pravyInterval = "∞"; }
            else { pravyInterval = Max.ToString(); }

            return $"{levaZavorka}{levyInterval}, {pravyInterval}{pravaZavorka}";
        }
    }
    abstract class MathFunction
    {
        public string Jmeno { get; }
        public string Rovnice { get; }
        public Interval DefinicniObor { get; protected set; }
        public Interval OborHodnot { get; protected set; }
        public string Prubeh { get; }
        protected MathFunction(string jmeno, string rovnice, string prubeh)
        {
            Jmeno = jmeno;
            Rovnice = rovnice;
            Prubeh = $"Funkce má {prubeh} průběh.";
        }
        public abstract double Vypocitej(double x);
        public virtual void VypisInfo()
        {
            Console.WriteLine($"{Jmeno}: {Rovnice} na D(f) = {DefinicniObor}");
            Console.WriteLine($"H(f) = {OborHodnot}");
            Console.WriteLine(Prubeh);
        }
    }

    interface IDerivovatelne
    {
        string Derivace();
    }
    interface IInvertovatelne
    {
        string Inverze();
    }

    class LinearniFunkce : MathFunction, IDerivovatelne, IInvertovatelne
    {
        private double a, b;
        public LinearniFunkce(double a, double b) : base("Lineární funkce", $"f(x) = {a}x + {b}", "lineární")
        {
            this.a = a;
            this.b = b;
            DefinicniObor = new Interval(false, double.NegativeInfinity, double.PositiveInfinity, false);
            OborHodnot = new Interval(false, double.NegativeInfinity, double.PositiveInfinity, false);
        }
        public override double Vypocitej(double x) => a * x + b;
        public string Derivace() => $"f'(x) = {a}";
        public string Inverze()
        {
            if (a == 0)
                return "Nelze, jelikož a = 0.";
            return $"f^(-1)(x) = (x - {b}) / {a}";
        }
    }
    class LinearniFunkceSAbsHodnotou : MathFunction
    {
        private double a, b, c;
        public LinearniFunkceSAbsHodnotou(double a, double b, double c) : base("Lineární funkce s absolutní hodnotou", $"f(x) = {a}|(x + {b})| + {c}", "lomený")
        {
            this.a = a;
            this.b = b;
            this.c = c;
            DefinicniObor = new Interval(false, double.NegativeInfinity , double.PositiveInfinity, false);
            if (a > 0)
                OborHodnot = new Interval(true, -b, double.PositiveInfinity, false) ;
            else
                OborHodnot = new Interval(false, double.NegativeInfinity, -b, true) ;
        }
        public override double Vypocitej(double x) => a * Math.Abs(x + b) + c;
    }
    class LinearniLomenaFunkce : MathFunction, IDerivovatelne, IInvertovatelne
    {
        private double a, b, c, d;
        public LinearniLomenaFunkce(double a, double b, double c, double d) : base("Lineární lomená funkce", $"f(x) ({a}x + {b})/({c}x + {d})", "hyperbolický")
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            DefinicniObor = new Interval(false, double.NegativeInfinity, double.PositiveInfinity, false);
            OborHodnot = new Interval(false, double.NegativeInfinity, double.PositiveInfinity, false);
        }
        
        public override double Vypocitej(double x) => (a * x + b) / (c * x + d);
        public string Derivace() => $"f'(x) = ({a}*{d} - {c}*{b})/({c}*x + {d})^2";
        public string Inverze() => $"f^(-1)(x) = ({-d}x + {b})/({c}x - a)";
        public override void VypisInfo()
        {
            Console.WriteLine($"{Jmeno}: {Rovnice} na D(f) = {DefinicniObor} \\ {{{-d/c}}} ");
            Console.WriteLine($"H(f) = {OborHodnot} \\ {{{a/c}}}");
            Console.WriteLine(Prubeh);
        }

    }
    class KvadratickaFunkce : MathFunction, IDerivovatelne 
    {
        private double a, b, c;
        public KvadratickaFunkce(double a, double b, double c) : base ("Kvadratická funkce", $"f(x) = {a}x^2 + {b}x + c", "parabolický")
        {
            this.a = a;
            this.b = b;
            this.c = c;
            double vrchol = c - ((b*b)/(4*a));
            DefinicniObor = new Interval(false,double.NegativeInfinity, double.PositiveInfinity,false);
            if (a > 0)
                OborHodnot = new Interval(true, vrchol, double.PositiveInfinity, false);
            else if (a<0)
                OborHodnot = new Interval(false, double.NegativeInfinity, vrchol, true);
        }

        public override double Vypocitej(double x) => a * x * x + b * x + c;

        public string Derivace() => $"f'(x) = {2 * a}x + {b}";
    }

    
}
