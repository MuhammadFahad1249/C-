using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crudnew
{
    internal class Program
    {
        static void Main(string[] args)
        {
          // ye class hai , ye variable hai
            SqlConnection sqlconnection;
            string connectionSting = @"Data Source=DESKTOP-USHD07Q\SQLEXPRESS;Initial Catalog=CoDb;Integrated Security=True";
            try
            {
                sqlconnection = new SqlConnection(connectionSting);
                sqlconnection.Open();
                Console.WriteLine("Connection Established Successfully !");

                // create => C

                Console.WriteLine("Enter your name :");
                string userName = Console.ReadLine();

                Console.WriteLine("Enter your Age :");
                int userAge = int.Parse(Console.ReadLine());
                string insertQuery = "INSERT INTO  DETAILS(user_name,user_age) VALUES('" + userName + "','" + userAge + "')";
                SqlCommand insertCommand = new SqlCommand(insertQuery, sqlconnection);
                insertCommand.ExecuteNonQuery();
                Console.WriteLine("Data is sucessfully entered into the table ");


                // Retrieve => R
                string displayQuery = "SELECT * FROM DETAILS";
                SqlCommand displayCommand = new SqlCommand(displayQuery, sqlconnection);
                
              // class      , object  this displays record by record   
                SqlDataReader datareader = displayCommand.ExecuteReader();
                while (datareader.Read()) 
                {
                    Console.WriteLine("ID : "+datareader.GetValue(0).ToString());
                    Console.WriteLine("Name : "+datareader.GetValue(1).ToString());
                    Console.WriteLine("Age : "+datareader.GetValue(2).ToString());
                    Console.WriteLine("==========================================");
                }
                datareader.Close();

                // UPDATE => U

                int u_id;
                string u_name;

                Console.WriteLine("Enter the id you want to change the field :");
                u_id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new name you have to update :");
                u_name = Console.ReadLine();

                string updateQuery = "UPDATE DETAILS SET user_name = '" + u_name + "' WHERE user_id = " + u_id;
                SqlCommand updateCommand = new SqlCommand(updateQuery, sqlconnection);
                updateCommand.ExecuteNonQuery();
                Console.WriteLine("Name is successfully changed");


                // Delete => D
                int D_id;
                Console.WriteLine("Enter the record id you want to delete :");
                D_id = int.Parse(Console.ReadLine());

                string deleteQuery = "DELETE FROM DETAILS WHERE user_id ="+D_id;
                SqlCommand deleteCommand = new SqlCommand(deleteQuery, sqlconnection);
                deleteCommand.ExecuteNonQuery();
                Console.WriteLine("Deleted Successfully! ");




                
                sqlconnection.Close();
            }

            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            ////https://www.youtube.com/watch?v=6hVp8NFcgdw

    

            Console.ReadLine();
        }
    }
}
