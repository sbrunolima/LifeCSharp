using System;

namespace Life
{
    class MainClass
    {
        public static double isValidNumber(string input_data)
        {
            double verified_data = 0;

            if (double.TryParse(input_data, out verified_data))
            {
                return verified_data;
            }
            else
            {
                return -1;
            }
        }

        public static void Solve()
        {
            int day_hours = 24;
            int year_days = 365;

            string[] input_data = new string[6];
            double[] verified_data = new double[6];
            double data_return = 0;

            do
            {
                Console.Write("1 - Enter your age: ");
                input_data[0] = Console.ReadLine();

                Console.Write("2 - How many years do you want to live: ");
                input_data[1] = Console.ReadLine();

                Console.Write("3 - How many years have you been working: ");
                input_data[2] = Console.ReadLine();

                Console.Write("4 - Daily hours worked: ");
                input_data[3] = Console.ReadLine();

                Console.Write("5 - Daily hours sleeping: ");
                input_data[4] = Console.ReadLine();

                Console.Write("6 - What age do you want to retire: ");
                input_data[5] = Console.ReadLine();

                Console.WriteLine();

                //Loop to verify if the user enterd a valid number
                for (int i = 0; i < input_data.Length; i++)
                {
                    verified_data[i] = isValidNumber(input_data[i]);
                    if (verified_data[i] < 0)
                    {
                        Console.WriteLine("Item: " + (i + 1) + " is not a valid number!");
                        data_return = verified_data[i];
                    }
                }

                Console.WriteLine();

                //Restart or Exit if the user enter a invalid data
                if (data_return < 0)
                {
                    Console.Write("Try again? yes or no: ");
                    string try_again = Console.ReadLine();

                    if (try_again.ToLower() == "yes")
                    {
                        Console.Clear();
                        Solve();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }

            } while (data_return < 0);


            //Variables to do all calculations
            double years_remaining; //How many years of life are left

            //Life in hours
            double lived_until_now; //How many hours have you lived since birth
            double enjoyed_until_now; //How many hours have you liked so far
            double hours_still_have; //How many hours of lives are left


            //Sum
            double sleeped_until_now; //Sum of hours slept so far
            double worked_until_now; //Sum of hours worked so far

            //Total hours spent during life
            double life_hours_sleeped; //Hours of sleep during life
            double life_hours_enjoyed; //Hours of fun during life
            double life_hours_total; //All life in hours
            double life_hours_worked; //Hours worked during life


            //Do all calculations
            years_remaining = verified_data[1] - verified_data[0]; //How many years of life are left

            worked_until_now = (verified_data[3] * year_days) * verified_data[2]; //Sum of hours worked so far
            sleeped_until_now = (verified_data[4] * year_days) * verified_data[0]; //Sum of hours slept so far

            lived_until_now = (verified_data[0] * year_days) * day_hours; //How many hours have you lived since birth
            enjoyed_until_now = lived_until_now - (sleeped_until_now + worked_until_now);//How many hours have you liked so far
            hours_still_have = (years_remaining * year_days) * day_hours; //How many hours of lives are left

            life_hours_sleeped = (verified_data[4] * year_days) * verified_data[1];  //Hours of sleep during life
            life_hours_enjoyed = (((verified_data[1] - verified_data[5]) + (verified_data[0] - verified_data[2])) *
                year_days) * day_hours; //Hours of fun during life
            life_hours_total = (verified_data[1] * year_days) * day_hours; //All life in hours
            life_hours_worked = life_hours_total - (life_hours_enjoyed + life_hours_sleeped); //Hours worked during life


            //Outputs
            Console.WriteLine("LIFE IN HOURS/DAYS UNTIL NOW:\n");
            Console.WriteLine($"Hours worked so far: {worked_until_now} hours, or " + Math.Round(worked_until_now / day_hours, 2) + " days.");
            Console.WriteLine($"Sleep hours so far: {sleeped_until_now} hours, or " + Math.Round(sleeped_until_now / day_hours, 2) + " days.");
            Console.WriteLine($"Hours lived so far: {lived_until_now} hours, or " + Math.Round(lived_until_now / day_hours, 2) + " days.");
            Console.WriteLine($"Enjoying hours so far: {enjoyed_until_now} hours, or " + Math.Round(enjoyed_until_now / day_hours, 2) + " days.");
            Console.WriteLine();

            Console.WriteLine("WILL LIVE IN HOURS/DAYS:\n");
            Console.WriteLine($"Total hours you will live: {life_hours_total} hours, or " + Math.Round(life_hours_total / day_hours, 2) + " days.\n");
            Console.WriteLine($"Sleep during your lifetime: {life_hours_sleeped} hours, or " + Math.Round(life_hours_sleeped / day_hours, 2) + " days.");
            Console.WriteLine($"Enjoy during your lifetime: {life_hours_enjoyed} hours, or " + Math.Round(life_hours_enjoyed / day_hours, 2) + " days.");
            Console.WriteLine($"Work during your lifetime: {life_hours_worked} hours, or " + Math.Round(life_hours_worked / day_hours, 2) + " days.\n");
            Console.WriteLine($"Total hours remaining: {hours_still_have} hours, or " + Math.Round(hours_still_have / day_hours, 2) + " days.");
            Console.WriteLine();


            Console.Write("Again? yes or no: ");
            string again = Console.ReadLine();
            if (again.ToLower() == "yes")
            {
                Console.Clear();
                Solve();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void Main(string[] args)
        {
            Solve();
        }
    }
}
