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
                Console.WriteLine("========WELCOME TO RALPH'S GROCERY STORE========");

                Console.WriteLine("\n===========================================");
                Console.WriteLine("               PRODUCT MENU               ");
                Console.WriteLine("===========================================");
                Console.WriteLine($"{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
                Console.WriteLine("-------------------------------------------");

                foreach (var p in products)
                {
                    p.DisplayProduct();
                }

                Console.WriteLine("===========================================");

                Console.Write("Enter Product Number: ");
                string inputProduct = Console.ReadLine();

                if (!int.TryParse(inputProduct, out int productChoice) ||
                    productChoice < 1 || productChoice > products.Length)
                {
                    Console.WriteLine("Invalid product number.");
                    continue;
                }

                Product selectedProduct = products[productChoice - 1];

                if (selectedProduct.RemainingStock == 0)
                {
                    Console.WriteLine("This product is out of stock.");
                    continue;
                }

                Console.Write("Enter Quantity: ");
                string inputQty = Console.ReadLine();

                if (!int.TryParse(inputQty, out int quantity) || quantity <= 0)
                {
                    Console.WriteLine("Invalid quantity.");
                    continue;
                }

                if (quantity > selectedProduct.RemainingStock)
                {
                    Console.WriteLine("Not enough stock.");
                    continue;
                }

              
                selectedProduct.DeductStock(quantity);

              
                cart[cartCount] = new ItemCart(selectedProduct, quantity);
                cartCount++;

                Console.WriteLine("Item added to cart!");

                Console.Write("Add more items? (Y/N): ");
                string choice = Console.ReadLine().ToUpper();

                if (choice == "N")
                    continueShopping = false;
            }

      
            Console.WriteLine("\n===== RECEIPT =====");
            double grandTotal = 0;

            for (int i = 0; i < cartCount; i++)
            {
                Console.WriteLine($"{cart[i].Product.Name} x{cart[i].Quantity} = ₱{cart[i].Subtotal}");
                grandTotal += cart[i].Subtotal;
            }

            Console.WriteLine($"Grand Total: ₱{grandTotal}");

            double discount = 0;
            if (grandTotal >= 5000)
            {
                discount = grandTotal * 0.10;
                Console.WriteLine($"Discount (10%): ₱{discount}");
            }

            double finalTotal = grandTotal - discount;
            Console.WriteLine($"Final Total: ₱{finalTotal}");


            Console.WriteLine("\n===== UPDATED STOCK =====");
            foreach (var p in products)
            {
                Console.WriteLine($"{p.Name} - Remaining: {p.RemainingStock}");
            }

            Console.WriteLine("\nThank you for shopping at Ralph's Grocery Store!");
        }
    }
}