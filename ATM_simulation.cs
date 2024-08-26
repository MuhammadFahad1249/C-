using System;
using System.Data.SqlClient;

namespace ATM_Simulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection sqlconnection;
            string connectionString = @"Data Source=DESKTOP-USHD07Q\SQLEXPRESS;Initial Catalog=ATM_Automation;Integrated Security=True";

            try
            {
                sqlconnection = new SqlConnection(connectionString);
                sqlconnection.Open();
                Console.WriteLine("Connection Established Successfully!");

                // Verify Card Number
                Console.WriteLine("Enter your ATM Card number:");
                string cardNumber = Console.ReadLine();

                // Verify PIN
                Console.WriteLine("Enter your PIN:");
                string pinNumber = Console.ReadLine();

                string authQuery = "SELECT COUNT(*) FROM AuthDetails WHERE card_num = @card_num AND pin_num = @pin_num";
                SqlCommand authCommand = new SqlCommand(authQuery, sqlconnection);
                authCommand.Parameters.AddWithValue("@card_num", cardNumber);
                authCommand.Parameters.AddWithValue("@pin_num", pinNumber);
                int userExists = (int)authCommand.ExecuteScalar();

                if (userExists == 1)
                {
                    Console.WriteLine("Authentication Successful!");
                    // Show options to the user
                    while (true)
                    {
                        Console.WriteLine("\nSelect an option:");
                        Console.WriteLine("1. Fast Cash Withdrawal");
                        Console.WriteLine("2. Other Cash Amount Withdraw");
                        Console.WriteLine("3. Change PIN");
                        Console.WriteLine("4. Exit");

                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                FastCash(sqlconnection, cardNumber);
                                break;
                            case "2":
                                OtherCashWithdraw(sqlconnection, cardNumber);
                                break;
                            case "3":
                                ChangePin(sqlconnection, cardNumber);
                                break;
                            case "4":
                                Console.WriteLine("Thank you for using our ATM. Goodbye!");
                                sqlconnection.Close();
                                return;
                            default:
                                Console.WriteLine("Wrong Input! Please select a valid option.");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Card Number or PIN. Exiting the application.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        static void FastCash(SqlConnection sqlconnection, string cardNumber)
        {
            Console.WriteLine("\nSelect amount to withdraw:");
            Console.WriteLine("1. 100");
            Console.WriteLine("2. 500");
            Console.WriteLine("3. 1000");

            string option = Console.ReadLine();
            int amount = 0;

            switch (option)
            {
                case "1":
                    amount = 100;
                    break;
                case "2":
                    amount = 500;
                    break;
                case "3":
                    amount = 1000;
                    break;
                default:
                    Console.WriteLine("Invalid option. Returning to main menu.");
                    return;
            }

            WithdrawAmount(sqlconnection, cardNumber, amount);
        }

        static void OtherCashWithdraw(SqlConnection sqlconnection, string cardNumber)
        {
            Console.WriteLine("Enter amount to withdraw:");
            int amount = int.Parse(Console.ReadLine());

            if (amount > 1000)
            {
                Console.WriteLine("Withdrawal limit is 1000. Please enter a lower amount.");
                return;
            }

            WithdrawAmount(sqlconnection, cardNumber, amount);
        }

        static void WithdrawAmount(SqlConnection sqlconnection, string cardNumber, int amount)
        {
            // Assuming there's a table 'AccountBalance' with columns 'card_num' and 'balance'
            string balanceQuery = "SELECT balance FROM AccountBalance WHERE card_num = @card_num";
            SqlCommand balanceCommand = new SqlCommand(balanceQuery, sqlconnection);
            balanceCommand.Parameters.AddWithValue("@card_num", cardNumber);

            int balance = (int)balanceCommand.ExecuteScalar();

            if (amount > balance)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }

            string withdrawQuery = "UPDATE AccountBalance SET balance = balance - @amount WHERE card_num = @card_num";
            SqlCommand withdrawCommand = new SqlCommand(withdrawQuery, sqlconnection);
            withdrawCommand.Parameters.AddWithValue("@amount", amount);
            withdrawCommand.Parameters.AddWithValue("@card_num", cardNumber);
            withdrawCommand.ExecuteNonQuery();

            Console.WriteLine("Withdrawal successful. New balance: " + (balance - amount));
        }

        static void ChangePin(SqlConnection sqlconnection, string cardNumber)
        {
            Console.WriteLine("Enter new 4-digit PIN:");
            string newPin = Console.ReadLine();

            if (newPin.Length != 4 || !int.TryParse(newPin, out _))
            {
                Console.WriteLine("Invalid PIN format. Must be 4 numeric digits.");
                return;
            }

            string updatePinQuery = "UPDATE AuthDetails SET pin_num = @pin_num WHERE card_num = @card_num";
            SqlCommand updatePinCommand = new SqlCommand(updatePinQuery, sqlconnection);
            updatePinCommand.Parameters.AddWithValue("@pin_num", newPin);
            updatePinCommand.Parameters.AddWithValue("@card_num", cardNumber);
            updatePinCommand.ExecuteNonQuery();

            Console.WriteLine("PIN changed successfully.");
        }
    }
}
