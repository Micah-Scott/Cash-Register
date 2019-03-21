/* Micah Scott 3-12-19
 *  This program allows a user to enter item prices, counts how many items they have entered, 
 *  calculates total price after tax/shipping costs and dispalys the output
 */

using System;

namespace RegisterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //vars
            const double taxRate = .0775;
            int itemNumbers = 0;
            double itemPrice1 = 0;
            double currentPrice = 0;
            double shippingCost = 0;
            double tax = 0;
            bool running = true;

            //do while loop
            do
            {
                while (true)
                {
                    //enter item price, add price to total, +1 to itemNumbers
                    Console.WriteLine("Item price: ");
                    string itemPrice = Console.ReadLine();

                    if (Double.TryParse(itemPrice, out itemPrice1)) //I'm not sure why this works but it does
                    {
                        currentPrice += itemPrice1;
                        itemNumbers++;
                        break;
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("Invalid input!");
                    }
                }

                //enter another item question
                while (true)
                {
                    Console.WriteLine("Enter another item?\n(Yes/No)");
                    string ans = Console.ReadLine().ToLower();
                    if (ans == "no")
                    {
                        running = false;
                        break;
                    }
                    else if (ans == "yes")
                    {
                        break;
                    }
                    if (ans == "")
                    {
                        Console.Beep();
                        Console.WriteLine("Invalid input!");
                    }
                    else
                    {
                        Console.Beep();
                        Console.WriteLine("Invalid Input!");
                        // then repeat question
                    }
                }

                //free shipping check
                if (currentPrice >= 90 && currentPrice < 100)
                {
                    Console.WriteLine(string.Format("You are only ${0} away from free shipping!", 100 - currentPrice));
                    Console.WriteLine("Would you like to add another item to get free shipping?(Yes/No)");
                    string ans1 = Console.ReadLine().ToLower();
                    if (ans1 == "yes")
                    {
                        running = true; //do nothing
                    }
                    else
                    {
                        running = false;
                    }
                }
            } while (running);

            //check itemNumbers and price to get shipping cost
            if (currentPrice >= 100)
            {
                shippingCost = 0.0;
            }
            else if (itemNumbers < 3)
            {
                shippingCost = 3.50;
            }
            else if (itemNumbers <= 3 && itemNumbers <= 6)
            {
                shippingCost = 5.00;
            }
            else if (itemNumbers >= 7 && itemNumbers <= 10)
            {
                shippingCost = 7.00;
            }
            else if (itemNumbers >= 11 && itemNumbers <= 15)
            {
                shippingCost = 9.00;
            }
            else if (itemNumbers > 15)
            {
                shippingCost = 10.00;
            }

            //add shipping costs
            currentPrice = currentPrice + shippingCost;
            //add taxation
            tax = currentPrice * taxRate;
            currentPrice = currentPrice + tax;

            //display purchase info to user
            Console.WriteLine(string.Format("Your total today is {0:c2}. Thank you for shopping with us!\n" +
                "MORE DETAILS:\nshipping: {3:c2}\ntotal items: {2}\ntotal tax: {1:c2}", currentPrice, tax,
                itemNumbers, shippingCost));
        }
    }
}