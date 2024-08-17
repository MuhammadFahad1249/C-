using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace operatorsInC_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Operators In C#
           //  1. Arithmetic Operators

            int a = 8;
            int b =4;

            Console.WriteLine("Arithmetic Operators :");

            Console.WriteLine("The Value of a + b is : " + (a + b));
            Console.WriteLine("The Value of a - b is : " + (a - b));
            Console.WriteLine("The Value of a * b is : " + ( a * b));
            Console.WriteLine("The Value of a / b is : " + (a / b));


            //  2. Assignment Operators


            Console.WriteLine("Assignment Operators :");

            int x = 4;
            int y = x;
            y += 8;
            Console.WriteLine(y);
            y -= 2;
            Console.WriteLine(y);
            y *= 3;
            Console.WriteLine(y);
            y /= 2;
            Console.WriteLine(y);


            //  3. Logical Operators
            Console.WriteLine("Logical Operators : ");
            // AND Operator "&&"
            Console.WriteLine("--------------> And Operators :");
            Console.WriteLine(true  && false);
            Console.WriteLine(false && true);
            Console.WriteLine(true  && true);
            Console.WriteLine(false && false);

            // OR Operator "||"

            Console.WriteLine("--------------> OR Operators : ");
            Console.WriteLine(true  || false);
            Console.WriteLine(false || true);
            Console.WriteLine(true  || true);
            Console.WriteLine(false || false);

            Console.WriteLine(!false);
            Console.WriteLine(!true);
            
      

            //  4. Comparison Operators


            Console.WriteLine("Comparison Operators");
            Console.WriteLine( 324 > 4);
            Console.WriteLine(324 < 4);
            Console.WriteLine(324 >= 4);  // 324 is greater than or equal to 4
            Console.WriteLine(324 <= 4);  // 324 is less than or equal to 4
            Console.WriteLine(324 != 4);


            // Math Functions 

            
            Console.Write("enter value 1 : ");
            string val1 = Console.ReadLine();

            Console.Write("enter value 2 : ");
            string val2 = Console.ReadLine();



            double s = Math.Max( Convert.ToDouble(val1 ), Convert.ToDouble(val2));

            Console.WriteLine("The Max Value is : " + s);

            double v = Math.Min(Convert.ToDouble(val1), Convert.ToDouble(val2));
            Console.WriteLine("The Min Value is : " + v);

            // sqrt
            double l = Math.Sqrt(36);
            Console.WriteLine("sqrt of 36 is: "+l);

            //abs

            double m = Math.Abs(-38.88);     // abs converts the -ve into +ve
            Console.WriteLine(m);
            Console.WriteLine("absoule abs of -38.88 is: " + m);

            // length of string
            string intro = "my name is fahad";
            Console.WriteLine("The length of intro is : " + intro.Length);

            //name in upper format
            Console.WriteLine(intro.ToUpper());

            //name in lower format
            Console.WriteLine(intro.ToLower());

            // string concatenation funvtion
            Console.WriteLine(String.Concat(intro, " i m feeling good "));

            
            Console.WriteLine("enter your name : ");
            string name = Console.ReadLine();
            Console.WriteLine("enter any candy name : ");
            string candies = Console.ReadLine();
            // string interpolation  -------------- it removes the traditional + concatenation method & enhanced the concatenation code
            Console.WriteLine($" hi there {name} , we are offering you {candies}");


            Console.ReadLine(); 

        }
    }
}
