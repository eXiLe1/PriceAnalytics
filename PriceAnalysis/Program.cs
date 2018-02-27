using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceAnalysis
{
    class Program
    {
        static int CurrentPrice;
        static int OriginalPrice;
        static float LastMultiplierUsed = 0.4F;

        static void Main(string[] args)
        {
            ShowMenu();
            Console.ReadLine();
            //AnalysePrices();
        }

        static void ShowMenu()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("1) Get new price from two months ");
            Console.WriteLine("--------------------------");
            var MenuOptionSelected = Console.ReadLine();
            switch (MenuOptionSelected)
            {
                case "1":
                    OptionOne();
                    break;
                default:
                    Console.WriteLine("Please choose an option from the menu");
                    break;
            }
        }

        static void OptionOne()
        {
            Console.WriteLine("Enter price per night for month one.");
            Console.Write("- ");
            OriginalPrice = int.Parse(Console.ReadLine());

            Console.WriteLine("--------------------------");
            Console.WriteLine("1) Increase price");
            Console.WriteLine("2) Increase price less");
            Console.WriteLine("--------------------------");
            var MenuOptionSelected = Console.ReadLine();
            switch (MenuOptionSelected)
            {
                case "1":
                    IncreasePrice();
                    OptionOne();
                    break;
                case "2":
                    IncreasePriceLess();
                    OptionOne();
                    break;
                default:
                    Console.WriteLine("Please choose an option from the menu");
                    break;
            }
        }

        static void IncreasePrice()
        {
            CurrentPrice = OriginalPrice;
            CurrentPrice = (int)Math.Round(CurrentPrice + (LastMultiplierUsed * CurrentPrice));
            Console.WriteLine("It is recommended you change the price from £" + OriginalPrice + " to £" + CurrentPrice + ".");
        }

        static void IncreasePriceLess()
        {
            LastMultiplierUsed = LastMultiplierUsed / 2;
            CurrentPrice = (int)Math.Round(OriginalPrice + (LastMultiplierUsed * OriginalPrice));
            Console.WriteLine("Multiplier used:" + LastMultiplierUsed);
            Console.WriteLine("It is recommended you change the price from £" + OriginalPrice + " to £" + CurrentPrice + ".");
        }

        static void DecreasePrice()
        {

        }

        static void AnalysePrices()
        {
            string[] input1 = new string[9];
            string[] input2 = new string[9];
            input1 = GetInformation(input1);
            input2 = GetInformation(input2);
            ComparePreviousYear(input1, input2);
            Console.ReadLine();
        }

        static void ComparePreviousYear(string[] Previous, string[] Current)
        {
            if (int.Parse(Current[2]) < int.Parse(Previous[2]))
            {
                Console.WriteLine("Bookings have gone down.");
                if (int.Parse(Current[3]) < int.Parse(Previous[3]))
                {
                    var PreviousNights = int.Parse(Previous[3]);
                    var CurrentNights = int.Parse(Current[3]);
                    Console.WriteLine("Night bookings have gone down. \nPrevious: "+ PreviousNights +"\nCurrent: "+ CurrentNights);
                    /*if (Current[8] == "Increase")
                    {
                        var MultiplierUsed = float.Parse(Current[7]);
                        var FixedPrice = int.Parse(Previous[5]) / (MultiplierUsed - (MultiplierUsed * .1));
                        Console.WriteLine("" + MultiplierUsed, int.Parse(Previous[5]), float.Parse(Current[7]));
                        FixedPrice = (int)Math.Ceiling(FixedPrice);
                        Console.WriteLine("It is recommended you change the price from £" + Current[5] + " to £" + FixedPrice + ".");
                    }*/
                    if (Current[8] == "Increase")
                    {
                        var MultiplierUsed = float.Parse(Current[7]);
                        var MultiplierToUse = MultiplierUsed / 2;
                        var FixedPrice = int.Parse(Previous[5]) + (int.Parse(Previous[5]) * MultiplierToUse);
                        Console.WriteLine("Multiplier used:" + MultiplierToUse);
                        FixedPrice = (int)Math.Ceiling(FixedPrice);
                        Console.WriteLine("It is recommended you change the price from £" + Current[5] + " to £" + FixedPrice + ".");
                    }
                    AnalysePrices();
                    //var NewPrice = DecreasePrice(int.Parse(Current[5]));
                    //Console.WriteLine("It is recommended you change the price from £" + Current[5] + " to £" + NewPrice + ".");
                }
                else if (int.Parse(Current[4]) < int.Parse(Previous[4]))
                {
                    var PreviousWeeks = int.Parse(Previous[4]);
                    var CurrentWeeks = int.Parse(Current[4]);
                    Console.WriteLine("Week bookings have gone down. \nPrevious: " + PreviousWeeks + "\nCurrent: " + CurrentWeeks);
                }
            }
        }

        static string[] GetInformation(string[] list)
        {
            Console.WriteLine("For what month/year are you entering data?");
            Console.WriteLine("Jan/Feb/Mar/Apr/May/Jun/Jul/Aug/Sep/Oct/Nov/Dec");
            Console.Write("Month: ");
            var UserInputMonth = Console.ReadLine();
            Console.WriteLine("YYYY");
            Console.Write("Year: ");
            var UserInputYear = Console.ReadLine();
            Console.Write("How many days were booked: ");
            var UserInputDaysBooked = Console.ReadLine();
            Console.WriteLine("How many bookings of each type?");
            Console.Write("Night bookings: ");
            var UserInputNightBookings = Console.ReadLine();
            Console.Write("Week bookings: ");
            var UserInputWeekBookings = Console.ReadLine();
            Console.WriteLine("What was the price for that month?");
            Console.Write("Per Night: £");
            var UserInputPerNight = Console.ReadLine();
            Console.Write("Per Week: £");
            var UserInputPerWeek = Console.ReadLine();
            Console.Write("Multiplier Used: ");
            var UserInputMultiplier = Console.ReadLine();
            Console.Write("Increase/Decrease: ");
            var UserInputChange = Console.ReadLine();
            list[0] = UserInputMonth;
            list[1] = UserInputYear;
            list[2] = UserInputDaysBooked;
            list[3] = UserInputNightBookings;
            list[4] = UserInputWeekBookings;
            list[5] = UserInputPerNight;
            list[6] = UserInputPerWeek;
            list[7] = UserInputMultiplier;
            list[8] = UserInputChange;
            return list;
        }
    }
}
