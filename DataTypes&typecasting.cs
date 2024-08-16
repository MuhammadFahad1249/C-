using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 34; //integer datatype
            /*
             Data Types in C:
            =================
            integer ----------- int a; -------4 byte
            long -------------- long a; ------8 byte    integer ki trh hota
            floating number --- float a; ----- 4 byte
            double ------------ double a; ---- 8 byte    float ki trh hota 
            character --------- char a = 'A';--  2 byte       note char should use only ''
            Boolean ----------- bool isGreat = true;----  1 bit
            string ------------ string a = "Fahad" 2 byte per character
            
             */
            //Console.WriteLine("hello world"+ a);
            //Console.Write("This is Engineer");
            //Console.WriteLine("Muhammad Fahad");
            Console.Write("Enter the value: ");
            string inp = Console.ReadLine();
            Console.Write("The entered field is: " + inp);
            Console.ReadLine();



            int x = 133;
            float y = 33.4F;
            double z = 123.45;
            bool t = true;
            char u = 'f';
            string s = "This is String ";
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine(t);
            Console.WriteLine(u);
            Console.WriteLine(s);
            Console.ReadLine();

            // Type Casting
            int q = (int) 3.5;
            Console.WriteLine(q);
            Console.ReadLine();

            // There are two types of typecasting
            // 1. Implicit casting

            int a_ = 3;
            double b_ = a_;
            int c_ = 'y';
            Console.WriteLine(a_);
            Console.WriteLine(b_);
            Console.WriteLine(c_);
            // Rule: char to int to long to float to double
            // 2. Explicit casting
            double x1 = (double)3.2;
            int x2 = (int)3.2;
            Console.WriteLine(x1);
            Console.WriteLine(x2);
            Console.ReadLine();

            // build in fuctions for typecasting
            //ConvertToInt32(3.33)
            //Cnvet.ToDouble
            //Convert.ToDecimal
            //Convert.ToString

            float varr = Convert.ToInt32(33.34);
            int x4 = Convert.ToChar('A');
            Console.WriteLine(x4);
            Console.WriteLine(varr);
            Console.ReadLine();

        }


    }
}
