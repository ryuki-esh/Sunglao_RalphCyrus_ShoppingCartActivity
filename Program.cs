using System;
using System.Collections.Generic;
using System.Text;

namespace Shopping_Cart_Activity_Sunglao
{
    internal class Program
    {
        static void Main()
        {
            Product[] products = new Product[]
            {
                new Product(1, "Milk", 50.00, 50),
                new Product(2, "Eggs", 10.00, 1000),
                new Product(3, "Meat (1 kg)", 250.00, 200),
                new Product(4, "Bread (1 Loaf)", 75.00, 500),
                new Product(5, "Turon", 25.00, 100),
            };

            ItemCart[] cart = new ItemCart[5];
            int cartCount = 0;

            bool continueShopping = true;

            while (continueShopping)
            {
                Console.Writeline("========WELCOME TO RALPH'S GROCERY STORE========");
                foreach (var p in products)
                {
                    p.DisplayProduct();
                }
                Console.Write("Enter Product Number:");
                int productNumber = int.Parse(Console.ReadLine());
                Console.Write("Enter Quantity:");
                int quantity = int.Parse(Console.ReadLine());
                selectedProduct.DeductStock(quantity);
                Console.WriteLine("Item added to cart!");

                Console.Write("Add more items? (Y/N): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "N")
                    continueShopping = false;

                Console.WriteLine("\n===== RECEIPT =====");
                double grandTotal = 0;

                for (int i = 0; i < cartCount; i++)
                {
                    Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
                    grandTotal += cart[i].Subtotal;
                }

                Console.WriteLine($"Grand Total: ₱{grandTotal}");

                Console.WriteLine("\n===== UPDATED STOCK =====");
                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name} - Remaining: {p.RemainingStock}");
                }

                Console.WriteLine("\nThank you for shopping at Ralph's Grocery Store!");
            
        }

    }
        }
    }