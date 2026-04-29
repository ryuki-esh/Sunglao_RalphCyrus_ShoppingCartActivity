using System;
using System.Collections.Generic;

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
                new Product(6, "Siopao", 30.00, 100),
                new Product(7, "SM Bonus Water (1L)", 30.00, 500),
                new Product(8, "Fish (1 kg)", 150.00, 200),
                new Product(9, "Mr. Chips", 30.00, 500),
                new Product(10, "Cheetos", 90.00, 100),
            };

            List<ItemCart> cart = new List<ItemCart>();

            bool running = true;

            while (running)
            {
                Console.WriteLine("\n====== MAIN MENU ======");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. Manage Cart");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Checkout");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItem(products, cart);
                        break;

                    case "2":
                        ManageCart(cart);
                        break;

                    case "3":
                        SearchProduct(products);
                        break;

                    case "4":
                        Checkout(cart, products);
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        // ================= ADD ITEM =================
        static void AddItem(Product[] products, List<ItemCart> cart)
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

            Console.Write("Enter Product ID: ");
            if (!int.TryParse(Console.ReadLine(), out int productChoice) ||
                productChoice < 1 || productChoice > products.Length)
            {
                Console.WriteLine("Invalid product number.");
                return;
            }

            Product selectedProduct = products[productChoice - 1];

            if (selectedProduct.RemainingStock == 0)
            {
                Console.WriteLine("This product is out of stock.");
                return;
            }

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity <= 0)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            if (quantity > selectedProduct.RemainingStock)
            {
                Console.WriteLine("Not enough stock.");
                return;
            }

            selectedProduct.DeductStock(quantity);
            cart.Add(new ItemCart(selectedProduct, quantity));

            Console.WriteLine("Item added to cart!");
        }

        // ================= CART MENU =================
        static void ManageCart(List<ItemCart> cart)
        {
            bool managing = true;

            while (managing)
            {
                Console.WriteLine("\n====== CART MENU ======");
                Console.WriteLine("1. View Cart");
                Console.WriteLine("2. Remove Item");
                Console.WriteLine("3. Clear Cart");
                Console.WriteLine("4. Back");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewCart(cart);
                        break;

                    case "2":
                        RemoveItem(cart);
                        break;

                    case "3":
                        cart.Clear();
                        Console.WriteLine("Cart cleared.");
                        break;

                    case "4":
                        managing = false;
                        break;
                }
            }
        }

        // ================= VIEW CART =================
        static void ViewCart(List<ItemCart> cart)
        {
            if (cart.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
                return;
            }

            Console.WriteLine("\n--- CART ITEMS ---");
            for (int i = 0; i < cart.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cart[i].Product.Name} - Qty: {cart[i].Quantity}");
            }
        }

        // ================= REMOVE ITEM =================
        static void RemoveItem(List<ItemCart> cart)
        {
            ViewCart(cart);

            Console.Write("Enter item number: ");
            if (int.TryParse(Console.ReadLine(), out int index) &&
                index > 0 && index <= cart.Count)
            {
                cart[index - 1].Product.RemainingStock += cart[index - 1].Quantity;
                cart.RemoveAt(index - 1);

                Console.WriteLine("Item removed.");
            }
        }

        static void SearchProduct(Product[] products)
        {
            Console.Write("\nEnter product name to search: ");
            string search = Console.ReadLine().ToLower();

            bool found = false;

            Console.WriteLine("\nSearch Results:");
            Console.WriteLine("-------------------------------------------");

            foreach (var p in products)
            {
                if (p.Name.ToLower().Contains(search))
                {
                    Console.WriteLine($"\n{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
                    Console.WriteLine("-------------------------------------------");
                    p.DisplayProduct(
                    );
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine("No matching products found.");
            }
        }

        // ================= CHECKOUT =================
        static void Checkout(List<ItemCart> cart, Product[] products)
        {
            Console.WriteLine("\n===========================================");
            Console.WriteLine("                 RECEIPT                  ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"Item",-15} {"Qty",-7} {"Price",-10} {"Subtotal",-10}");
            Console.WriteLine("-------------------------------------------");

            double grandTotal = 0;

            foreach (var item in cart)
            {
                Console.WriteLine(
                    $"{item.Product.Name,-15} " +
                    $"{item.Quantity,-7} " +
                    $"PHP {item.Product.Price,-9:F2} " +
                    $"PHP {item.Subtotal,-10:F2}"
                );

                grandTotal += item.Subtotal;
            }

            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"{"Grand Total:",-30} PHP {grandTotal:F2}");

            double discount = 0;
            if (grandTotal >= 5000)
            {
                discount = grandTotal * 0.10;
            }

            if (discount > 0)
            {
                Console.WriteLine($"{"Discount (10%):",-30} PHP {discount:F2}");
            }

            double finalTotal = grandTotal - discount;
            Console.WriteLine($"{"Final Total:",-30} PHP {finalTotal:F2}");
            Console.WriteLine("===========================================");

            Console.WriteLine("\nThank you for shopping at Ralph's Grocery Store!");

            // UPDATED STOCK 
            Console.WriteLine("\n===========================================");
            Console.WriteLine("         UPDATED STOCK AFTER PURCHASE      ");
            Console.WriteLine("===========================================");
            Console.WriteLine($"{"ID",-5} {"Product",-15} {"Price",-10} {"Stock",-5}");
            Console.WriteLine("-------------------------------------------");

            foreach (var p in products)
            {
                p.DisplayProduct();
            }
        }
    }
}