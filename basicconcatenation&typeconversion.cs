using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter your Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Hey Hello "+ name);
        

            Console.WriteLine("Enter Number of candies do you want? ");
            string can = Console.ReadLine();
            Console.WriteLine("you are a nice student and you will get 4 more candies :" + (Convert.ToInt32(can) + 4));
            Console.WriteLine("you earned " + (Convert.ToInt32(can) + 4) + " candies");
            Console.ReadLine();
       }
    }
}
